using Microsoft.Office.Interop.Excel;
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
        //AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        int deliveryListNumber = 1;
        DeliveryListsTableAdapter dlta = new DeliveryListsTableAdapter();
        DeliveryListsInjTableAdapter dlita = new DeliveryListsInjTableAdapter();
        DeliveryListsContentTableAdapter dlcta = new DeliveryListsContentTableAdapter();
        DeliveryListsContentInjTableAdapter dlcita = new DeliveryListsContentInjTableAdapter();

        PurchaseRequestsTableAdapter prta = new PurchaseRequestsTableAdapter();
        PurchaseRequestsInjTableAdapter prita = new PurchaseRequestsInjTableAdapter();
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
            // Создаем экземпляр Random
            var random = new Random();
            // Выбираем случайного поставщика и получаем его INN
            string randomINN = tOOLACCOUNTINGDataSet.Suppliers
                .OrderBy(x => random.Next())   // Перемешиваем список
                .Select(x => x.INN)            // Берём INN
                .FirstOrDefault();              // Берём первый (случайный)
            dl.SupplierINN = randomINN;
            DeliveryListFormSupplier.Text = dl.SupplierINN;
            tOOLACCOUNTINGDataSet.DeliveryLists.AddDeliveryListsRow(dl);
            dlta.Update(tOOLACCOUNTINGDataSet.DeliveryLists);
            dlta.Fill(tOOLACCOUNTINGDataSet.DeliveryLists);
            dlita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsInj);
            deliveryListsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);

            deliveryListNumber = (tOOLACCOUNTINGDataSet.DeliveryLists.Max(x => x.DeliveryListID));

            deliveryListsContentInjBindingSource.Filter = $"DeliveryListID = {deliveryListNumber}";
            purchaseRequestsInjBindingSource.Filter = "Status = 'Не обработана'";

            DeliveryListFormNumber.Text = deliveryListNumber.ToString();
            DeliveryListFormDate.Text = DateTime.Today.ToString("dd.MM.yyyy");

            //purchaseRequestsInjBindingSource.Filter = 

            //SetSuppliersSource();
            SetPurchaseRequestsContentFilter();
        }

        //private void SetSuppliersSource()
        //{
        //    foreach (DataRow row in new SuppliersTableAdapter().GetData().Rows)
        //    {
        //        string fullName = row[1]?.ToString().Trim() ?? "";
        //        if (!string.IsNullOrEmpty(fullName))
        //        {
        //            source.Add(fullName);
        //        }
        //    }
        //    DeliveryListFormSupplier.AutoCompleteCustomSource = source;
        //}
        //private void FindSupplier(TextBox sender)
        //{
        //    string selectedText = sender.Text;
        //    sender.Text = new List<string>(source.Cast<string>()).Where(x => x.ToLower() == selectedText.ToLower()).FirstOrDefault();
        //}

        //private void DeliveryListFormSupplier_Leave(object sender, EventArgs e)
        //{
        //    FindSupplier(sender as TextBox);

        //    //установка поставщика
        //    var dlRow = tOOLACCOUNTINGDataSet.DeliveryLists.FindByDeliveryListID(deliveryListNumber);
        //    string inn = tOOLACCOUNTINGDataSet.Suppliers.Where(x => x.Name == DeliveryListFormSupplier.Text).Select(x => x.INN).FirstOrDefault();
        //    if(!string.IsNullOrEmpty(inn))dlRow.SupplierINN = inn;
        //    dlta.Update(tOOLACCOUNTINGDataSet.DeliveryLists);
        //    dlta.Fill(tOOLACCOUNTINGDataSet.DeliveryLists);

        //    SetButtonsState();
        //}

        private void SetButtonsState()
        {
            try
            {
                if (string.IsNullOrEmpty(DeliveryListFormSupplier.Text))
                {
                    DeliveryListFormButtonAdd.Enabled = false;
                    DeliveryListFormButtonRemove.Enabled = false;
                    return;
                }
                if (DeliveryListFormPurchaseRequestContentTable.CurrentRow == null) DeliveryListFormButtonAdd.Enabled = false;
                else DeliveryListFormButtonAdd.Enabled = true;

                if (DeliveryListFormDeliveryListContentTable.CurrentRow == null) DeliveryListFormButtonRemove.Enabled = false;
                else DeliveryListFormButtonRemove.Enabled = true;
            }
            catch { }
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

                //установка поставщика
                //var dlRow = tOOLACCOUNTINGDataSet.DeliveryLists.FindByDeliveryListID(deliveryListNumber);
                //dlRow.SupplierINN = DeliveryListFormSupplier.Text;

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

                //Обновление статуса заявки на приобретение
                int purchaseRequestID = prcRow.PurchaseRequestID;
                // Получаем все строки PurchaseRequestsContent для указанного PurchaseRequestID
                var contentList = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                    .Where(prc => prc.PurchaseRequestID == purchaseRequestID)
                    .ToList();

                // Проверяем, все ли из них добавлены в DeliveryListsContent
                bool allInDelivery = contentList.All(prc =>
                    tOOLACCOUNTINGDataSet.DeliveryListsContent.Any(dlc =>
                        dlc.PurchaseContentID == prc.PurchaseContentID));

                if (allInDelivery)
                {

                    prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
                    //prRow = null
                    var prRow = tOOLACCOUNTINGDataSet.PurchaseRequests.FindByPurchaseRequestID(purchaseRequestID);
                    if (prRow != null && prRow.Status != "В работе")
                    {
                        prRow.Status = "В работе";
                        //new PurchaseRequestsTableAdapter().Update(prRow);
                        prta.Update(tOOLACCOUNTINGDataSet.PurchaseRequests);
                        prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
                        prita.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsInj);
                    }
                }


                // Обновление статуса заявки на получение
                rrRow.Status = "В работе";
                new ReceivingRequestsTableAdapter().Update(tOOLACCOUNTINGDataSet.ReceivingRequests);



                SetPurchaseRequestsContentFilter();
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

                int prcId = dlcRow.PurchaseContentID;

                dlcRow.Delete();
                dlcta.Update(tOOLACCOUNTINGDataSet.DeliveryListsContent);
                dlcta.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContent);
                dlcita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);

                // Получаем PurchaseRequestID через PurchaseRequestsContent
                prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
                var prcRow = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.FindByPurchaseContentID(prcId);
                if (prcRow == null) return;

                int purchaseRequestID = prcRow.PurchaseRequestID;

                // Получаем все строки PurchaseRequestsContent для этой заявки
                var contentList = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                    .Where(prc => prc.PurchaseRequestID == purchaseRequestID)
                    .ToList();

                if (!contentList.Any()) return;

                // Проверяем, все ли строки добавлены в поставку
                bool allInDelivery = contentList.All(prc =>
                    tOOLACCOUNTINGDataSet.DeliveryListsContent.Any(dlc =>
                        dlc.PurchaseContentID == prc.PurchaseContentID));

                string newStatus = allInDelivery ? "В работе" : "Не обработана";

                // Обновляем статус заявки
                var prRow = tOOLACCOUNTINGDataSet.PurchaseRequests.FindByPurchaseRequestID(purchaseRequestID);
                if (prRow == null || prRow.Status == newStatus) return;

                prRow.Status = newStatus;
                prRow.EndEdit();

                // Сохраняем изменения
                prta.Update(prRow);
                prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
                prita.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsInj);


                // Обновление статуса заявки на получение
                var rrcRow = tOOLACCOUNTINGDataSet.ReceivingRequestsContent
                    .FirstOrDefault(r => r.ReceivingContentID == prcRow.ReceivingContentID);
                int receivingRequestID = rrcRow.ReceivingRequestID;
                // 1. Получаем все ReceivingRequestsContent, связанные с этой заявкой
                var receivingContentIDs = tOOLACCOUNTINGDataSet.ReceivingRequestsContent
                    .Where(rrc => rrc.ReceivingRequestID == receivingRequestID)
                    .Select(rrc => rrc.ReceivingContentID)
                    .ToList();
                // 3. Находим все PurchaseRequestsContent, связанные с этими ReceivingContentID
                var prcList = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                    .Where(prc => receivingContentIDs.Contains(prc.ReceivingContentID) && prc.IsPurchase == true)
                    .Select(prc => prc.PurchaseContentID)
                    .ToList();
                // 4. Проверяем, есть ли связь с DeliveryListsContent
                bool hasDeliveryLink = tOOLACCOUNTINGDataSet.DeliveryListsContent
                    .Any(dlc => prcList.Contains(dlc.PurchaseContentID));
                // 5. Обновляем статус заявки на получение
                if (!hasDeliveryLink)
                {
                    var rrta = new ReceivingRequestsTableAdapter();
                    rrta.Fill(tOOLACCOUNTINGDataSet.ReceivingRequests);
                    var rrRow = tOOLACCOUNTINGDataSet.ReceivingRequests
                        .FindByReceivingRequestID(receivingRequestID);
                        rrRow.Status = "Обработана";
                    rrta.Update(tOOLACCOUNTINGDataSet.ReceivingRequests);
                }

                SetPurchaseRequestsContentFilter();
            }
            catch { }
        }

        private void SetPurchaseRequestsContentFilter() //bug Не обновляется после удаления в таблице, где несколько строк. Странное обновление в целом
        {
            //фильтр состава заявки
            // Получаем все PurchaseContentID, которые уже в поставке
            dlcta.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContent);
            dlcita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
            prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
            prita.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsInj);
            purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
            var assignedIDs = tOOLACCOUNTINGDataSet.DeliveryListsContent
                .Select(dlc => dlc.PurchaseContentID)
                .ToList();

            // Формируем строку фильтрации: исключаем те, что уже в поставке
            if (assignedIDs.Count() > 0)
            {
                string filter = $"PurchaseContentID NOT IN ({string.Join(",", assignedIDs)})";
                purchaseRequestsInjPurchaseRequestsContentInjBindingSource.Filter = filter;
            }
            else
            {
                purchaseRequestsInjPurchaseRequestsContentInjBindingSource.Filter = null;
            }
            dlcta.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContent);
            dlcita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
            prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
            prita.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsInj);
            purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
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
