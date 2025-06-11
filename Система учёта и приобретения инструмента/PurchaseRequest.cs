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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet1.PurchaseRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.purchaseRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);

            prcta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);

            PurchaseRequestNumber.Text = (tOOLACCOUNTINGDataSet.PurchaseRequests.Max(x => x.PurchaseRequestID) + 1).ToString();
            PurchaseRequestDate.Text = DateTime.Now.ToString("dd.MM.yyyy");
        }

        private void SetButtonsState()
        {
            if(PurchaseRequestsContentTable.CurrentRow == null) return;
            var selectedRow = PurchaseRequestsContentTable.CurrentRow.DataBoundItem as DataRowView;
            var row = selectedRow.Row as TOOLACCOUNTINGDataSet.PurchaseRequestsContentInjRow;
            if(row.PurchaseRequestID == 1)
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
            //var pr = tOOLACCOUNTINGDataSet.PurchaseRequests.NewPurchaseRequestsRow();
            //pr.PurchaseRequestDate = DateTime.Today;
            //pr.Status = "Не обработана";
            //tOOLACCOUNTINGDataSet.PurchaseRequests.AddPurchaseRequestsRow(pr);
            //prta.Update(tOOLACCOUNTINGDataSet.PurchaseRequests);
            //prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
            //prita.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsInj);

            //var selectedRow = PurchaseRequestsContentTable.CurrentRow.DataBoundItem as DataRowView;
            //var row = selectedRow.Row as TOOLACCOUNTINGDataSet.PurchaseRequestsContentInjRow;
            //var r = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.FindByPurchaseContentID(row.PurchaseContentID);
            ////r.PurchaseRequestID = Convert.ToInt32(PurchaseRequestNumber.Text);
            //r.PurchaseRequestID = tOOLACCOUNTINGDataSet.PurchaseRequests.Max(x => x.PurchaseRequestID);

            //prcta.Update(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            //prcta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            //purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);

            // Создаём новую заявку на закупку с текущей датой и статусом "Не обработана"
            var pr = tOOLACCOUNTINGDataSet.PurchaseRequests.NewPurchaseRequestsRow();
            pr.PurchaseRequestDate = DateTime.Today;
            pr.Status = "Не обработана";
            tOOLACCOUNTINGDataSet.PurchaseRequests.AddPurchaseRequestsRow(pr);

            // Сохраняем в БД
            prta.Update(tOOLACCOUNTINGDataSet.PurchaseRequests);

            // Обновляем таблицу, чтобы получить актуальные данные (включая автоинкрементный ID)
            prta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
            prita.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsInj);

            // Получаем выбранную строку из интерфейса (например, из DataGridView)
            var selectedRow = PurchaseRequestsContentTable.CurrentRow?.DataBoundItem as DataRowView;
            if (selectedRow == null) return;

            var row = selectedRow.Row as TOOLACCOUNTINGDataSet.PurchaseRequestsContentInjRow;
            if (row == null) return;

            // Находим соответствующую строку в PurchaseRequestsContent по PurchaseContentID
            var r = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.FindByPurchaseContentID(row.PurchaseContentID);
            if (r == null) return;

            // Устанавливаем связь с только что созданной заявкой
            // Вместо текстового поля используем последний ID из таблицы (только что созданный)
            r.PurchaseRequestID = tOOLACCOUNTINGDataSet.PurchaseRequests.Max(x => x.PurchaseRequestID);

            // Сохраняем изменения в PurchaseRequestsContent
            prcta.Update(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);

            // Обновляем адаптеры для отображения изменений в интерфейсе
            prcta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
        }

        private void PurchaseRequestButtonRemove_Click(object sender, EventArgs e)
        {
            //var selectedRow = PurchaseRequestsContentTable.CurrentRow.DataBoundItem as DataRowView;
            //var row = selectedRow.Row as TOOLACCOUNTINGDataSet.PurchaseRequestsContentInjRow;
            //var r = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.FindByPurchaseContentID(row.PurchaseContentID);
            //r.PurchaseRequestID = 1;

            ////add //удаление заявки, при убирании всех инструментов

            //prcta.Update(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            //prcta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            //purchaseRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
        }
    }
}