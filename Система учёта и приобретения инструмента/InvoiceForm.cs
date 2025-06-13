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
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
        }

        int invoiceNumber = 1;

        InvoicesTableAdapter ita = new InvoicesTableAdapter();
        InvoicesContentTableAdapter icta = new InvoicesContentTableAdapter();

        InvoicesInjTableAdapter iita = new InvoicesInjTableAdapter();
        InvoicesContentInjTableAdapter icita = new InvoicesContentInjTableAdapter();

        private void InvoiceForm_Load(object sender, EventArgs e)
        {
            this.deliveryListsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.InvoicesContentInj". При необходимости она может быть перемещена или удалена.
            this.invoicesContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.InvoicesContentInj);

            ita.Fill(tOOLACCOUNTINGDataSet.Invoices);
            iita.Fill(tOOLACCOUNTINGDataSet.InvoicesInj);

            // Создаём новую заявку на закупку с текущей датой и статусом "Не обработана"
            var i = tOOLACCOUNTINGDataSet.Invoices.NewInvoicesRow();
            i.InvoiceDate = DateTime.Today;
            tOOLACCOUNTINGDataSet.Invoices.AddInvoicesRow(i);
            ita.Update(tOOLACCOUNTINGDataSet.Invoices);
            ita.Fill(tOOLACCOUNTINGDataSet.Invoices);
            //iita.Fill(tOOLACCOUNTINGDataSet.DeliveryListsInj);

            invoiceNumber = (tOOLACCOUNTINGDataSet.Invoices.Max(x => x.InvoiceID));

            InvoiceFormNumber.Text = invoiceNumber.ToString();
            InvoiceFormDate.Text = DateTime.Today.ToString("dd.MM.yyyy");
        }
        private void SetState()
        {
            try
            {
                if (InvoiceFormDeliveryTable.CurrentRow == null) return;

                var selectedRow = InvoiceFormDeliveryTable.CurrentRow?.DataBoundItem as DataRowView;
                if (selectedRow == null)
                {
                    InvoiceFormQuantity.Enabled = false;
                    InvoiceFormButtonsFix.Enabled = false;
                    return;
                }

                var row = selectedRow.Row as TOOLACCOUNTINGDataSet.DeliveryListsContentInjRow;
                if (row == null)
                {
                    InvoiceFormQuantity.Enabled = false;
                    InvoiceFormButtonsFix.Enabled = false;
                    return;
                }

                int alreadyFixed = tOOLACCOUNTINGDataSet.InvoicesContent.Where(x => x.DeliveryContentID == row.DeliveryContentID).Sum(x => x.Quantity);
                InvoiceFormQuantity.Maximum = row.Quantity - alreadyFixed;
                InvoiceFormQuantity.Value = InvoiceFormQuantity.Maximum;

                InvoiceFormQuantity.Enabled = true;
                InvoiceFormButtonsFix.Enabled = true;
            }
            catch { }
        }

        private void InvoiceFormDeliveryTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetState();
        }
        private void InvoiceFormButtonsFix_Click(object sender, EventArgs e)
        {
            try
            {
                if (InvoiceFormQuantity.Value == 0)
                {
                    NotificationService.Notify("Нельзя добавить в накладную номенклатуру с количеством 0.", "Предупреждение", ToolTipIcon.Warning);
                    return;
                }

                var selectedRow = InvoiceFormDeliveryTable.CurrentRow?.DataBoundItem as DataRowView;
                if (selectedRow == null) return;
                var row = selectedRow.Row as TOOLACCOUNTINGDataSet.DeliveryListsContentInjRow;
                if (row == null) return;

                // Создание новой строки в InvoicesContent
                var ic = tOOLACCOUNTINGDataSet.InvoicesContent.NewInvoicesContentRow();
                ic.InvoiceID = invoiceNumber;
                ic.DeliveryContentID = row.DeliveryContentID;
                ic.Quantity = (int)InvoiceFormQuantity.Value;

                tOOLACCOUNTINGDataSet.InvoicesContent.AddInvoicesContentRow(ic);
                icta.Update(tOOLACCOUNTINGDataSet.InvoicesContent);
                icta.Fill(tOOLACCOUNTINGDataSet.InvoicesContent);
                icita.Fill(tOOLACCOUNTINGDataSet.InvoicesContentInj);

                SetState();

                // Загрузка всех необходимых данных
                var rrta = new ReceivingRequestsTableAdapter();
                var prcta = new PurchaseRequestsContentTableAdapter();
                var dlcAdapter = new DeliveryListsContentTableAdapter();

                rrta.Fill(tOOLACCOUNTINGDataSet.ReceivingRequests);
                prcta.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContent);
                dlcAdapter.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContent);

                // Получение связей
                var dlc = tOOLACCOUNTINGDataSet.DeliveryListsContent.FindByDeliveryContentID(row.DeliveryContentID);
                var prc = tOOLACCOUNTINGDataSet.PurchaseRequestsContent.FindByPurchaseContentID(dlc.PurchaseContentID);
                var rrc = tOOLACCOUNTINGDataSet.ReceivingRequestsContent.FindByReceivingContentID(prc.ReceivingContentID);
                var rr = tOOLACCOUNTINGDataSet.ReceivingRequests.FindByReceivingRequestID(rrc.ReceivingRequestID);

                #region Обновление статуса заявки на получение

                var relatedRequestsContent = tOOLACCOUNTINGDataSet.ReceivingRequestsContent
                    .Where(r => r.ReceivingRequestID == rr.ReceivingRequestID)
                    .ToList();

                bool allCompleted = true;

                foreach (var item in relatedRequestsContent)
                {
                    var prc1 = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                        .FirstOrDefault(p => p.ReceivingContentID == item.ReceivingContentID);

                    if (prc1 == null) continue;

                    var dlc1 = tOOLACCOUNTINGDataSet.DeliveryListsContent
                        .FirstOrDefault(d => d.PurchaseContentID == prc1.PurchaseContentID);

                    if (dlc1 == null) continue;

                    var deliveryContentID = dlc1.DeliveryContentID;

                    var delivered = tOOLACCOUNTINGDataSet.InvoicesContent
                        .Where(x => x.DeliveryContentID == deliveryContentID)
                        .Sum(x => x.Quantity);

                    if (delivered < item.Quantity)
                    {
                        allCompleted = false;
                        break;
                    }
                }

                rr.Status = allCompleted ? "Исполнена полностью" : "Исполнена частично";
                rrta.Update(tOOLACCOUNTINGDataSet.ReceivingRequests);
                rrta.Fill(tOOLACCOUNTINGDataSet.ReceivingRequests);
                deliveryListsContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.DeliveryListsContentInj);

                #endregion

                #region Обновление статуса заявки на приобретение

                var purchaseRequestID = prc.PurchaseRequestID;
                var pr = tOOLACCOUNTINGDataSet.PurchaseRequests.FindByPurchaseRequestID(purchaseRequestID);

                if (pr != null)
                {
                    var relatedPurchaseItems = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                        .Where(p => p.PurchaseRequestID == purchaseRequestID)
                        .ToList();

                    bool allPurchaseCompleted = true;

                    foreach (var purchaseItem in relatedPurchaseItems)
                    {
                        var receivingItem = tOOLACCOUNTINGDataSet.ReceivingRequestsContent
                            .FirstOrDefault(r => r.ReceivingContentID == purchaseItem.ReceivingContentID);

                        if (receivingItem == null) continue;

                        var prc1 = tOOLACCOUNTINGDataSet.PurchaseRequestsContent
                            .FirstOrDefault(p => p.ReceivingContentID == receivingItem.ReceivingContentID);

                        if (prc1 == null) continue;

                        var dlc1 = tOOLACCOUNTINGDataSet.DeliveryListsContent
                            .FirstOrDefault(d => d.PurchaseContentID == prc1.PurchaseContentID);

                        if (dlc1 == null) continue;

                        var deliveryContentID = dlc1.DeliveryContentID;

                        var delivered = tOOLACCOUNTINGDataSet.InvoicesContent
                            .Where(x => x.DeliveryContentID == deliveryContentID)
                            .Sum(x => x.Quantity);

                        if (delivered < receivingItem.Quantity)
                        {
                            allPurchaseCompleted = false;
                            break;
                        }
                    }

                    pr.Status = allPurchaseCompleted ? "Исполнена полностью" : "Исполнена частично";
                    new PurchaseRequestsTableAdapter().Update(pr);
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обработке заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InvoiceFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InvoiceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool hasOtherEntries = tOOLACCOUNTINGDataSet.InvoicesContent.Any(x => x.InvoiceID == invoiceNumber);
            if (!hasOtherEntries)
            {
                // Если других записей нет, можно удалить саму заявку
                var iRow = tOOLACCOUNTINGDataSet.Invoices.FindByInvoiceID(invoiceNumber);
                if (iRow != null)
                {
                    iRow.Delete();
                    ita.Update(tOOLACCOUNTINGDataSet.Invoices);
                    ita.Fill(tOOLACCOUNTINGDataSet.Invoices);
                    iita.Fill(tOOLACCOUNTINGDataSet.InvoicesInj);
                    invoicesContentInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.InvoicesContentInj);
                }
            }
        }
    }
}
