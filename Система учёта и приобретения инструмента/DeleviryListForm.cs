using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class DeleviryListForm : Form
    {
        public DeleviryListForm()
        {
            InitializeComponent();
        }
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        int deliveryListNumber = 1;
        DeliveryListsTableAdapter dlta = new DeliveryListsTableAdapter();
        DeliveryListsInjTableAdapter dlita = new DeliveryListsInjTableAdapter();
        DeliveryListsContentTableAdapter dlcta = new DeliveryListsContentTableAdapter();
        DeliveryListsContentInjTableAdapter dlcita = new DeliveryListsContentInjTableAdapter();
        private void DeleviryListForm_Load(object sender, EventArgs e)
        {
            dlta.Fill(tOOLACCOUNTINGDataSet.DeliveryLists);
            dlita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsInj);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DeliveryListsContentInj". При необходимости она может быть перемещена или удалена.
            this.deliveryListsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DeliveryListsContent". При необходимости она может быть перемещена или удалена.
            this.purchaseRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.PurchaseRequestsInj". При необходимости она может быть перемещена или удалена.
            this.purchaseRequestsInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.PurchaseRequestsInj);


            // Создаём новую заявку на закупку с текущей датой и статусом "Не обработана"
            var dl = tOOLACCOUNTINGDataSet.DeliveryLists.NewDeliveryListsRow();
            dl.DeliveryListDate = DateTime.Today;
            new SuppliersTableAdapter().Fill(tOOLACCOUNTINGDataSet.Suppliers);
            dl.SupplierINN = tOOLACCOUNTINGDataSet.Suppliers.Select(x => x.INN).FirstOrDefault();
            tOOLACCOUNTINGDataSet.DeliveryLists.AddDeliveryListsRow(dl);
            dlta.Update(tOOLACCOUNTINGDataSet.DeliveryLists);
            dlta.Fill(tOOLACCOUNTINGDataSet.DeliveryLists);
            dlita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsInj);
            deliveryListsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);

            deliveryListNumber = (tOOLACCOUNTINGDataSet.DeliveryLists.Max(x => x.DeliveryListID));

            deliveryListsContentInjBindingSource.Filter = $"DeliveryListID = {deliveryListNumber}";

            DeliveryListFormNumber.Text = deliveryListNumber.ToString();
            DeliveryListFormDate.Text = DateTime.Today.ToString("dd.MM.yyyy");

            //purchaseRequestsInjBindingSource.Filter = 

            SetSuppliersSource();
        }

        private void SetSuppliersSource()
        {
            foreach (DataRow row in new SuppliersTableAdapter().GetData().Rows)
            {
                string fullName = row[1]?.ToString().Trim() ?? "";
                if (!string.IsNullOrEmpty(fullName))
                {
                    source.Add(fullName);
                }
            }
            DeliveryListFormSupplier.AutoCompleteCustomSource = source;
        }
        private void FindSupplier(TextBox sender)
        {
            string selectedText = sender.Text;
            sender.Text = new List<string>(source.Cast<string>()).Where(x => x.ToLower() == selectedText.ToLower()).FirstOrDefault();
        }

        private void DeliveryListFormSupplier_Leave(object sender, EventArgs e)
        {
            FindSupplier(sender as TextBox);
            if (string.IsNullOrEmpty(DeliveryListFormSupplier.Text)) return;
            DeliveryListFormButtonAdd.Enabled = true;
        }

        private void SetButtonsState()
        {
            if (DeliveryListFormPurchaseRequestContentTable.CurrentRow == null) DeliveryListFormButtonAdd.Enabled = false;
            else DeliveryListFormButtonAdd.Enabled = true;

            if (DeliveryListFormDeliveryListContentTable.CurrentRow == null) DeliveryListFormButtonRemove.Enabled = false;
            else DeliveryListFormButtonRemove.Enabled = true;
        }
        private void DeliveryListFormPurchaseRequestContentTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetButtonsState();
        }

        private void DeliveryListFormDeliveryListContentTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetButtonsState();
        }
        private void DeliveryListFormButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = DeliveryListFormPurchaseRequestContentTable.CurrentRow?.DataBoundItem as DataRowView;
                if (selectedRow == null) return;

                var row = selectedRow.Row as TOOLACCOUNTINGDataSet.PurchaseRequestsContentInjRow;
                if (row == null) return;

                //создание пункта заявки
                TOOLACCOUNTINGDataSet.DeliveryListsContentRow dlcRow = tOOLACCOUNTINGDataSet.DeliveryListsContent.NewDeliveryListsContentRow();
                dlcRow.DeliveryListID = deliveryListNumber;
                dlcRow.PurchaseContentID = row.PurchaseContentID;


                // Получаем PlannedDate из связанной заявки
                new ReceivingRequestsTableAdapter().Fill(tOOLACCOUNTINGDataSet.ReceivingRequests);
                new ReceivingRequestsContentTableAdapter().Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsContent);
                new PurchaseRequestsContentTableAdapter().Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);

                var prcRow = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.FindByPurchaseContentID(row.PurchaseContentID);
                var rrcRow = tOOLACCOUNTINGDataSet.ReceivingRequestsContent.FindByReceivingContentID(prcRow.ReceivingContentID);
                var rrRow = tOOLACCOUNTINGDataSet.ReceivingRequests.FindByReceivingRequestID(rrcRow.ReceivingRequestID);
                dlcRow.DeliveryContentDate = rrRow.PlannedDate;

                // Количество берем из ReceivingRequestsContent
                dlcRow.Quantity = rrcRow.Quantity;

                dlcRow.ContractNumber = "0";
                tOOLACCOUNTINGDataSet.DeliveryListsContent.AddDeliveryListsContentRow(dlcRow);
                dlcta.Update(tOOLACCOUNTINGDataSet.DeliveryListsContent);
                dlcta.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContent);
                dlcita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
            }
            catch { }
        }

        private void DeliveryListFormButtonRemove_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedRow = DeliveryListFormDeliveryListContentTable.CurrentRow?.DataBoundItem as DataRowView;
                if (selectedRow == null) return;

                var row = selectedRow.Row as TOOLACCOUNTINGDataSet.DeliveryListsContentInjRow;
                if (row == null) return;


                //dlcta.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContent);
                //dlcita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
                dlta.Fill(tOOLACCOUNTINGDataSet.DeliveryLists);
                dlita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsInj);
                var dlcRow = tOOLACCOUNTINGDataSet.DeliveryListsContent.FindByDeliveryContentID(row.DeliveryContentID);
                dlcRow.Delete();
                dlcta.Update(tOOLACCOUNTINGDataSet.DeliveryListsContent);
                dlcta.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContent);
                dlcita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
            }
            catch { } //bug ошибка параллелизма
        }

        private void DeleviryListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Дополнительно: проверка наличия записей и удаление пустых заявок

            bool hasOtherEntries = tOOLACCOUNTINGDataSet.DeliveryListsContent.Any(x => x.DeliveryListID == deliveryListNumber);
            if (!hasOtherEntries)
            {
                // Если других записей нет, можно удалить саму заявку
                var dlRow = tOOLACCOUNTINGDataSet.DeliveryLists.FindByDeliveryListID(deliveryListNumber);
                if (dlRow != null)
                {
                    dlRow.Delete();
                    dlta.Update(tOOLACCOUNTINGDataSet.DeliveryLists);
                    dlta.Fill(tOOLACCOUNTINGDataSet.DeliveryLists);
                    dlita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsInj);
                    deliveryListsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
                }
            }
        }

        private void DeliveryListFormButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
