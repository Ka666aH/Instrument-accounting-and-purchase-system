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
    public partial class RequestConsideration : Form
    {
        int requestNumber;
        FormMode mode;
        public RequestConsideration(int _requestNumber, FormMode _mode)
        {
            InitializeComponent();
            requestNumber = _requestNumber;
            mode = _mode;
        }

        AutoCompleteStringCollection workshops = new AutoCompleteStringCollection();
        private void RequestConsideration_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContent". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContentTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContent);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReplacementFixationInj". При необходимости она может быть перемещена или удалена.
            this.replacementFixationInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReplacementFixationInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);

            purchaseRequestsTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
            purchaseRequestsContentTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            workshopsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops);

            string filter = $"ReceivingRequestID = {requestNumber}";
            receivingRequestsContentInjBindingSource.Filter = filter;

            foreach (DataRow row in new WorkshopsTableAdapter().GetData().Rows)
            {
                string fullName = $"{row[1]?.ToString().Trim()}";
                if (!string.IsNullOrEmpty(fullName))
                {
                    workshops.Add(fullName);
                }
            }
            RequestConsiderationDonor.AutoCompleteCustomSource = workshops;
        }

        private void SetRequestConsiderationDecisionButtonsState()
        {
            try
            {
                if (RequestConsiderationContentTable.CurrentRow == null) return;

                var selectedRow = RequestConsiderationContentTable.CurrentRow.DataBoundItem as DataRowView;
                var contentRow = selectedRow.Row as TOOLACCOUNTINGDataSet.ReceivingRequestsContentInjRow;

                if (contentRow == null) return;

                int receivingContentId = contentRow.ReceivingContentID;

                // Ищем по ID напрямую
                var purchaseRows = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                    .Where(x => x.ReceivingContentID == receivingContentId);

                if (!purchaseRows.Any())
                {
                    RequestConsiderationBuy.Checked = false;
                    RequestConsiderationTransfer.Checked = false;
                    RequestConsiderationDonor.Text = string.Empty;
                }
                else
                {
                    var purchaseRow = purchaseRows.First();
                    RequestConsiderationBuy.Checked = purchaseRow.IsPurchase;
                    RequestConsiderationTransfer.Checked = !purchaseRow.IsPurchase;

                    if (!purchaseRow.IsPurchase)
                    {
                        int donorId = purchaseRow.DonorWorkshopID;
                        var donorWorkshop = tOOLACCOUNTINGDataSet.Workshops.Where(w => w.WorkshopID == donorId).Select(x => x.Name).FirstOrDefault(); //bug

                        RequestConsiderationDonor.Text = donorWorkshop;
                    }
                }

                RequestConsiderationButtonDeсide.Enabled =
                    RequestConsiderationBuy.Checked || RequestConsiderationTransfer.Checked;
            }
            catch //(Exception ex)
            {
                // Лучше выводить ошибку для диагностики
                //MessageBox.Show($"Ошибка при обработке состояния кнопок: {ex.Message}");
            }
        }

        private void SetRequestConsiderationButtonsState()
        {
            try
            {
                bool state = RequestConsiderationFixationTable.CurrentRow != null;
                RequestConsiderationButtonAlter.Enabled = state;
                RequestConsiderationButtonDelete.Enabled = state;
            }
            catch { }
        }

        private void RequestConsiderationContentTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetRequestConsiderationDecisionButtonsState();
        }

        private void RequestConsiderationContentTable_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationFixationTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetRequestConsiderationButtonsState();
        }

        private void RequestConsiderationButtonDeсide_Click(object sender, EventArgs e)
        {
            var selectedRow = RequestConsiderationContentTable.CurrentRow.DataBoundItem as DataRowView;
            var contentRow = selectedRow.Row as TOOLACCOUNTINGDataSet.ReceivingRequestsContentInjRow;

            if (!tOOLACCOUNTINGDataSet.PurchaseRequests.Any(x => x.PurchaseRequestID == 1))
            {
                var prr = tOOLACCOUNTINGDataSet.PurchaseRequests.NewPurchaseRequestsRow();
                //prr.PurchaseRequestID = -1;
                prr.PurchaseRequestDate = DateTime.MinValue;
                prr.Status = "Исполнена полностью";
                tOOLACCOUNTINGDataSet.PurchaseRequests.AddPurchaseRequestsRow(prr);
                new PurchaseRequestsTableAdapter().Update(tOOLACCOUNTINGDataSet.PurchaseRequests);
                new PurchaseRequestsTableAdapter().Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
            }

            if (tOOLACCOUNTINGDataSet.PurchaseRequestsContent.Any(x => x.ReceivingContentID == contentRow.ReceivingContentID))
            {
                var prcr = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.Where(x => x.ReceivingContentID == contentRow.ReceivingContentID).FirstOrDefault();
                if (prcr.IsPurchase != RequestConsiderationBuy.Checked) prcr.IsPurchase = RequestConsiderationBuy.Checked;
                if (prcr.IsPurchase) prcr.SetDonorWorkshopIDNull();
                else
                {
                    int donor = tOOLACCOUNTINGDataSet.Workshops.Where(x => x.Name == RequestConsiderationDonor.Text).Select(x => x.WorkshopID).FirstOrDefault();
                    if (prcr.DonorWorkshopID != donor) prcr.DonorWorkshopID = donor;
                }
            }
            else
            {
                var prcr = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.NewPurchaseRequestsContentRow();
                prcr.PurchaseRequestID = 1;
                prcr.ReceivingContentID = contentRow.ReceivingContentID;
                prcr.IsPurchase = RequestConsiderationBuy.Checked;
                if (!RequestConsiderationBuy.Checked)
                    prcr.DonorWorkshopID = tOOLACCOUNTINGDataSet.Workshops
                        .Where(x => x.Name.ToLower() == RequestConsiderationDonor.Text.ToLower())
                        .Select(x => x.WorkshopID)
                        .FirstOrDefault();
                tOOLACCOUNTINGDataSet.PurchaseRequestsContent.AddPurchaseRequestsContentRow(prcr);
            }

            new PurchaseRequestsContentTableAdapter().Update(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            new PurchaseRequestsContentTableAdapter().Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
        }

        private void RequestConsiderationButtonCreate_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonAlter_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonSave_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonSaveClose_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonClose_Click(object sender, EventArgs e)
        {

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!RequestConsiderationTransfer.Checked)
            {
                RequestConsiderationDonor.Enabled = false;
                RequestConsiderationDonor.Text = string.Empty;
            }
            else RequestConsiderationDonor.Enabled = true;
            if (RequestConsiderationBuy.Checked || RequestConsiderationTransfer.Checked) RequestConsiderationButtonDeсide.Enabled = true;
        }
    }
}
