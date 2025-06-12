using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class PurchaseRequest : Form
    {
        public PurchaseRequest()
        {
            InitializeComponent();
        }
        PurchaseRequestsTableAdapter prta = new PurchaseRequestsTableAdapter();
        PurchaseRequestsContentTableAdapter prcta = new PurchaseRequestsContentTableAdapter();
        PurchaseRequestsInjTableAdapter prita = new PurchaseRequestsInjTableAdapter();
        private void PurchaseRequest_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.purchaseRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet1.PurchaseRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.purchaseRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);

            prcta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);

            // Создаём новую заявку на закупку с текущей датой и статусом "Не обработана"
            var pr = tOOLACCOUNTINGDataSet.PurchaseRequests.NewPurchaseRequestsRow();
            pr.PurchaseRequestDate = DateTime.Today;
            pr.Status = "Не обработана";
            tOOLACCOUNTINGDataSet.PurchaseRequests.AddPurchaseRequestsRow(pr);
            prta.Update(tOOLACCOUNTINGDataSet.PurchaseRequests);
            prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
            prita.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsInj);
            purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);

            purchaseRequestsContentInjBindingSource.Filter = "PurchaseRequestID = 1";

            PurchaseRequestNumber.Text = (tOOLACCOUNTINGDataSet.PurchaseRequests.Max(x => x.PurchaseRequestID)).ToString();
            PurchaseRequestDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void SetButtonsState()
        {
            if (PurchaseRequestsContentTable.CurrentRow == null)
            {
                PurchaseRequestButtonAdd.Enabled = false;
                PurchaseRequestButtonRemove.Enabled = false;
                return;
            }

            var selectedRow = PurchaseRequestsContentTable.CurrentRow.DataBoundItem as DataRowView;
            var row = selectedRow.Row as TOOLACCOUNTINGDataSet.PurchaseRequestsContentInjRow;
            if (row.PurchaseRequestID == 1)
            {
                PurchaseRequestButtonAdd.Enabled = true;
                PurchaseRequestButtonRemove.Enabled = false;
            }
            else
            {
                PurchaseRequestButtonAdd.Enabled = false;
                PurchaseRequestButtonRemove.Enabled = true;
            }
        }

        private void PurchaseRequestsContentTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetButtonsState();
        }

        private void PurchaseRequestButtonAdd_Click(object sender, EventArgs e) //bug Обновляются только при перезаходе
        {
            var selectedRow = PurchaseRequestsContentTable.CurrentRow?.DataBoundItem as DataRowView;
            if (selectedRow == null) return;

            var row = selectedRow.Row as TOOLACCOUNTINGDataSet.PurchaseRequestsContentInjRow;
            if (row == null) return;

            // Находим соответствующую строку в PurchaseRequestsContent по PurchaseContentID
            var r = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.FindByPurchaseContentID(row.PurchaseContentID);
            if (r == null) return;

            r.PurchaseRequestID = Convert.ToInt32(PurchaseRequestNumber.Text);
            prcta.Update(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            prcta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
        }

        private void PurchaseRequestButtonRemove_Click(object sender, EventArgs e)
        {
            // Получаем выделенную строку из таблицы
            var selectedRow = PurchaseRequestsContentTable.CurrentRow?.DataBoundItem as DataRowView;
            if (selectedRow == null) return;

            var row = selectedRow.Row as TOOLACCOUNTINGDataSet.PurchaseRequestsContentInjRow;
            if (row == null) return;

            // Находим связанную запись в основной таблице PurchaseRequestsContent
            var r = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.FindByPurchaseContentID(row.PurchaseContentID);
            if (r == null) return;

            // Освобождаем связь с заявкой (можно установить NULL, если поле допускает это)
            r.PurchaseRequestID = 1;

            prcta.Update(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            prcta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
        }

        private void PurchaseRequestButtonClose_Click(object sender, EventArgs e)
        {
            // Дополнительно: проверка наличия записей и удаление пустых заявок
            int currentRequestID = Convert.ToInt32(PurchaseRequestNumber.Text);

            bool hasOtherEntries = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                .Any(x => x.PurchaseRequestID == currentRequestID);

            if (!hasOtherEntries)
            {
                // Если других записей нет, можно удалить саму заявку
                var requestRow = tOOLACCOUNTINGDataSet.PurchaseRequests.FindByPurchaseRequestID(currentRequestID);
                if (requestRow != null)
                {
                    requestRow.Delete();
                    prta.Update(tOOLACCOUNTINGDataSet.PurchaseRequests);
                    prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
                    prita.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsInj);
                    purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
                }
            }
            Close();
        }
    }
}