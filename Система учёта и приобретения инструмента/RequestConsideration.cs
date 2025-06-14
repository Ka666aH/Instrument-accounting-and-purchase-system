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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DataTable2". При необходимости она может быть перемещена или удалена.
            this.dataTable2TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DataTable2);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DataTable2". При необходимости она может быть перемещена или удалена.
            this.dataTable2TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DataTable2);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContent". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContentTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContent);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReplacementFixationInj". При необходимости она может быть перемещена или удалена.
            this.replacementFixationInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReplacementFixationInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);

            purchaseRequestsTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequests);
            purchaseRequestsContentTableAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            workshopsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops);
            balancesInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.BalancesInj);
            //replacementFixationTableAdapter.Fill(tOOLACCOUNTINGDataSet.ReplacementFixation);

            ReceivingContentFilter();
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

                //// Ищем по ID напрямую
                //var purchaseRows = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                //    .Where(x => x.ReceivingContentID == receivingContentId);

                //if (!purchaseRows.Any())
                //{
                //    RequestConsiderationBuy.Checked = false;
                //    RequestConsiderationTransfer.Checked = false;
                //    //RequestConsiderationDonor.Text = string.Empty;
                //}
                //else
                //{
                //    var purchaseRow = purchaseRows.First();
                //    RequestConsiderationBuy.Checked = purchaseRow.IsPurchase;
                //    RequestConsiderationTransfer.Checked = !purchaseRow.IsPurchase;

                //    if (!purchaseRow.IsPurchase)
                //    {
                //        int donorId = purchaseRow.DonorWorkshopID;
                //        var donorWorkshop = tOOLACCOUNTINGDataSet.Workshops.Where(w => w.WorkshopID == donorId).Select(x => x.Name).FirstOrDefault();

                //        //RequestConsiderationDonor.Text = donorWorkshop;
                //    }
                //}

                RequestConsiderationButtonDeсide.Enabled = RequestConsiderationBuy.Checked || RequestConsiderationTransfer.Checked;

                //Сравнение с доступным количеством
                if (Convert.ToInt32(RequestConsiderationQuantity.Text) < contentRow.Quantity)
                {
                    RequestConsiderationTransfer.Enabled = false;
                    RequestConsiderationBuy.Checked = true;
                }
                else RequestConsiderationTransfer.Enabled = true;
            }
            catch //(Exception ex)
            {
                // Лучше выводить ошибку для диагностики
                //MessageBox.Show($"Ошибка при обработке состояния кнопок: {ex.Message}");
            }
        }

        private void SetRequestConsiderationFixationButtonsState()
        {
            try
            {
                //bool state = RequestConsiderationFixationTable.CurrentRow != null;
                //RequestConsiderationButtonReplace.Enabled = state;
                if (RequestConsiderationFixationTable.CurrentRow == null || tOOLACCOUNTINGDataSet.ReplacementFixationInj.Any(x => x.ReceivingContentID == Convert.ToInt32(RequestConsiderationFixationTable.CurrentRow.Cells[0].Value.ToString())))
                {
                    RequestConsiderationButtonReplace.Enabled = false;
                }
                else
                {
                    if(RequestConsiderationTransfer.Checked) RequestConsiderationButtonReplace.Enabled = true;
                    else RequestConsiderationButtonReplace.Enabled = false;
                }
                //RequestConsiderationButtonAlter.Enabled = state;
                //RequestConsiderationButtonDelete.Enabled = state;
            }
            catch { }
        }

        private void RequestConsiderationContentTable_CurrentCellChanged(object sender, EventArgs e)
        {
            if (RequestConsiderationContentTable.CurrentRow != null && string.IsNullOrEmpty(RequestConsiderationContentTable.CurrentRow.Cells[1].Value.ToString()))
            {
                RequestConsiderationButtonAddNomenclature.Enabled = true;
                RequestConsiderationButtonAddNomenclature.Visible = true;
                RequestConsiderationButtonDeсide.Enabled= false;
                RequestConsiderationButtonReplace.Enabled = false;
                return;
            }
            else
            {
                RequestConsiderationButtonAddNomenclature.Enabled = false;
                RequestConsiderationButtonAddNomenclature.Visible = false;
            }



            SetRequestConsiderationDecisionButtonsState();
            if (RequestConsiderationContentTable.CurrentRow == null) return;
            var selectedRow = RequestConsiderationContentTable.CurrentRow.DataBoundItem as DataRowView;
            var contentRow = selectedRow.Row as TOOLACCOUNTINGDataSet.ReceivingRequestsContentInjRow;
            if (contentRow == null) return;
            int quantity = tOOLACCOUNTINGDataSet.BalancesInj.Where(b => b.NomenclatureNumber == contentRow.NomenclatureNumber).Sum(b => b.Quantity);
            RequestConsiderationQuantity.Text = quantity.ToString();
        }

        private void RequestConsiderationFixationTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetRequestConsiderationFixationButtonsState();
        }

        private void RequestConsiderationButtonAddNomenclature_Click(object sender, EventArgs e)
        {
            var selectedRow = RequestConsiderationContentTable.CurrentRow.DataBoundItem as DataRowView;
            var contentRow = selectedRow.Row as TOOLACCOUNTINGDataSet.ReceivingRequestsContentInjRow;
            receivingRequestsContentTableAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsContent);
            TOOLACCOUNTINGDataSet.ReceivingRequestsContentRow rrcRow = tOOLACCOUNTINGDataSet.ReceivingRequestsContent.FindByReceivingContentID(contentRow.ReceivingContentID);
            NomenclatureTableAdapter nta = new NomenclatureTableAdapter();
            nta.Fill(tOOLACCOUNTINGDataSet.Nomenclature);
            NomenForm nomenForm = new NomenForm(tOOLACCOUNTINGDataSet,nta,FormMode.Add,null, rrcRow);
            nomenForm.ShowDialog();
            nta.Fill(tOOLACCOUNTINGDataSet.Nomenclature);
            receivingRequestsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);
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
                else prcr.DonorWorkshopID = 0;
                //else
                //{
                //    int donor = tOOLACCOUNTINGDataSet.Workshops.Where(x => x.Name == RequestConsiderationDonor.Text).Select(x => x.WorkshopID).FirstOrDefault();
                //    if (prcr.DonorWorkshopID != donor) prcr.DonorWorkshopID = donor;
                //}
            }
            else
            {
                var prcr = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.NewPurchaseRequestsContentRow();
                prcr.PurchaseRequestID = 1;
                prcr.ReceivingContentID = contentRow.ReceivingContentID;
                prcr.IsPurchase = RequestConsiderationBuy.Checked;
                if (RequestConsiderationTransfer.Checked) prcr.DonorWorkshopID = 0;
                //    prcr.DonorWorkshopID = tOOLACCOUNTINGDataSet.Workshops
                //        .Where(x => x.Name.ToLower() == RequestConsiderationDonor.Text.ToLower())
                //        .Select(x => x.WorkshopID)
                //        .FirstOrDefault();
                tOOLACCOUNTINGDataSet.PurchaseRequestsContent.AddPurchaseRequestsContentRow(prcr);
            }

            new PurchaseRequestsContentTableAdapter().Update(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            new PurchaseRequestsContentTableAdapter().Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
            #region Обработка статуса
            // Получаем ID документа
            int receivingRequestID = contentRow.ReceivingRequestID;

            // Получаем список всех ReceivingContentID для этого документа
            var receivingContentIds = tOOLACCOUNTINGDataSet.ReceivingRequestsContent
                .Where(x => x.ReceivingRequestID == receivingRequestID)
                .Select(x => x.ReceivingContentID)
                .ToList();

            // Получаем список ReceivingContentID, которые уже есть в PurchaseRequestsContent
            var purchaseContentIds = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                //.Where(x => x.IsPurchase == true)
                .Select(x => x.ReceivingContentID)
                .ToList();

            // Проверяем, содержатся ли все ReceivingContentID в PurchaseRequestsContent
            bool allExist = receivingContentIds.All(id => purchaseContentIds.Contains(id));
            if (allExist)
            {
                new ReceivingRequestsTableAdapter().Fill(tOOLACCOUNTINGDataSet.ReceivingRequests);
                var r = tOOLACCOUNTINGDataSet.ReceivingRequests.FindByReceivingRequestID(receivingRequestID);
                r.Status = "Обработана";
                new ReceivingRequestsTableAdapter().Update(tOOLACCOUNTINGDataSet.ReceivingRequests);
                new ReceivingRequestsTableAdapter().Fill(tOOLACCOUNTINGDataSet.ReceivingRequests);
                new ReceivingRequestsInjTableAdapter().Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsInj);
            }
            #endregion
            ReceivingContentFilter();
        }
        private void ReceivingContentFilter()
        {
            string filter = $"ReceivingRequestID = {requestNumber}";

            try
            {
                // 1. Получаем все ReceivingContentID для текущей заявки
                var receivingContentIDs = tOOLACCOUNTINGDataSet.ReceivingRequestsContent
                    .Where(rrc => rrc.ReceivingRequestID == requestNumber)
                    .Select(rrc => rrc.ReceivingContentID)
                    .ToList();

                // 2. Находим те, что связаны с PurchaseRequestsContent
                var linkedIDs = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                    .Where(prc => receivingContentIDs.Contains(prc.ReceivingContentID))
                    .Select(prc => prc.ReceivingContentID)
                    .ToList();

                if (linkedIDs.Count > 0)
                {
                    string excludedIDs = string.Join(",", linkedIDs);
                    filter += $"AND ReceivingContentID NOT IN ({excludedIDs})";
                }

                // 4. Применяем фильтр
                receivingRequestsContentInjBindingSource.Filter = filter;
            }
            catch { }
        }

        private void RequestConsiderationButtonReplace_Click(object sender, EventArgs e)
        {
            // Проверяем выделенную строку
            if (RequestConsiderationFixationTable.CurrentRow == null)
                return;

            // Получаем ID из ячейки
            var cellValue = RequestConsiderationFixationTable.CurrentRow.Cells[0].Value;
            if (cellValue == null || !int.TryParse(cellValue.ToString(), out int id))
                return;

            // Находим запись в DataTable2 по ReceivingContentID
            var row = tOOLACCOUNTINGDataSet.DataTable2
                .FirstOrDefault(x => x.ReceivingContentID == id);

            if (row == null)
                return;

            // Проверяем, не существует ли уже запись с таким ReceivingContentID
            if (tOOLACCOUNTINGDataSet.ReplacementFixationInj.Any(x => x.ReceivingContentID == row.ReceivingContentID))
                return;

            // Создаем новую строку для ReplacementFixation
            var rpf = tOOLACCOUNTINGDataSet.ReplacementFixation.NewReplacementFixationRow();

            rpf.ReceivingContentID = row.ReceivingContentID;
            rpf.AnalogNomenclatureNumber = row.AnalogNumber;

            // Получаем количество из ReceivingRequestsContent
            var quantity = tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj
                .Where(x => x.ReceivingContentID == row.ReceivingContentID)
                .Select(x => x.Quantity)
                .FirstOrDefault();

            rpf.Quantity = quantity;

            // Добавляем новую строку и сохраняем изменения
            tOOLACCOUNTINGDataSet.ReplacementFixation.AddReplacementFixationRow(rpf);

            // Обновляем адаптеры
            var adapter = new ReplacementFixationTableAdapter();
            adapter.Update(tOOLACCOUNTINGDataSet.ReplacementFixation);
            tOOLACCOUNTINGDataSet.ReplacementFixation.Clear();
            adapter.Fill(tOOLACCOUNTINGDataSet.ReplacementFixation);
            replacementFixationInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.ReplacementFixationInj);
            RequestConsiderationButtonDeсide.PerformClick();
            //SetRequestConsiderationFixationButtonsState();
        }
        private void RequestConsiderationQuantity_TextChanged(object sender, EventArgs e)
        {
            var selectedRow = RequestConsiderationContentTable.CurrentRow.DataBoundItem as DataRowView;
            var contentRow = selectedRow.Row as TOOLACCOUNTINGDataSet.ReceivingRequestsContentInjRow;
            if(Convert.ToInt32(RequestConsiderationQuantity.Text) < contentRow.Quantity)
            {
                RequestConsiderationTransfer.Enabled = false;
                RequestConsiderationBuy.Checked = true;
            }
            else RequestConsiderationTransfer.Enabled = true;
        }

        private void RequestConsiderationButtonSave_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonSaveClose_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RequestConsiderationBuy.Checked || RequestConsiderationTransfer.Checked) RequestConsiderationButtonDeсide.Enabled = true;

            if (RequestConsiderationTransfer.Checked) RequestConsiderationButtonReplace.Enabled = true;
            else RequestConsiderationButtonReplace.Enabled = false;
        }
    }
}
