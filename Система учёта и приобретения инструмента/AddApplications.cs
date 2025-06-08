using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class AddApplications : Form
    {
        private TOOLACCOUNTINGDataSet dataSet;
        private TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsTableAdapter requestsAdapter;
        private TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentTableAdapter contentAdapter;
        private TOOLACCOUNTINGDataSetTableAdapters.NomenclatureViewTableAdapter nomenclatureViewAdapter;
        private TOOLACCOUNTINGDataSetTableAdapters.WorkshopsTableAdapter workshopsAdapter;
        private int? editingRequestId = null;

        public AddApplications()
        {
            InitializeComponent();
            this.FormClosing += AddApplications_FormClosing;
        }

        private void AddApplications_Load(object sender, EventArgs e)
        {
            dataSet = new TOOLACCOUNTINGDataSet();
            requestsAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsTableAdapter();
            contentAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentTableAdapter();
            nomenclatureViewAdapter = new TOOLACCOUNTINGDataSetTableAdapters.NomenclatureViewTableAdapter();
            workshopsAdapter = new TOOLACCOUNTINGDataSetTableAdapters.WorkshopsTableAdapter();

            nomenclatureViewAdapter.Fill(dataSet.NomenclatureView);
            requestsAdapter.Fill(dataSet.ReceivingRequests);
            workshopsAdapter.Fill(dataSet.Workshops);

            // Формируем список для ComboBox Workshop
            var workshopList = dataSet.Workshops
                .Select<DataRow, WorkshopDisplay>(row => new WorkshopDisplay
                {
                    WorkshopID = (int)row["WorkshopID"],
                    Display = string.IsNullOrWhiteSpace(row["Name"].ToString())
                        ? row["WorkshopID"].ToString()
                        : $"{row["WorkshopID"]} - {row["Name"]}"
                })
                .ToList();
            Workshop.DataSource = workshopList;
            Workshop.DisplayMember = "Display";
            Workshop.ValueMember = "WorkshopID";
            Workshop.SelectedIndex = -1;

            ApplicationsCompound.AutoGenerateColumns = false;
            ApplicationsCompound.DataSource = receivingRequestsContentBindingSource;
            ApplicationsCompound.AllowUserToAddRows = false;
            ApplicationsCompound.DataError += ApplicationsCompound_DataError;
            ApplicationsCompound.UserDeletingRow += ApplicationsCompound_UserDeletingRow;

            ApplicationDate.Text = DateTime.Today.ToShortDateString();
            ApplicationType.SelectedIndex = 0;
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(3).Month, 1);
            ApplicationDate.Text = DateTime.Today.ToShortDateString();

            // Автоматическая подстановка номера заявки
            if (editingRequestId.HasValue)
            {
                textBox1.Text = editingRequestId.Value.ToString();
            }
            else
            {
                int newNumber = 1;
                if (dataSet.ReceivingRequests.Rows.Count > 0)
                {
                    newNumber = dataSet.ReceivingRequests.Max(r => ((TOOLACCOUNTINGDataSet.ReceivingRequestsRow)r).ReceivingRequestID) + 1;
                }
                textBox1.Text = newNumber.ToString();
            }

            UpdateReasonItems();
            ApplicationType.SelectedIndexChanged += ApplicationType_SelectedIndexChanged;
        }

        private void CloseNewApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool AllRequiredFieldsFilled()
        {
            bool isReturn = Workshop.SelectedValue != null &&
                !string.IsNullOrWhiteSpace(ApplicationType.Text) &&
                !string.IsNullOrWhiteSpace(Reason.Text) &&
                dataSet.ReceivingRequestsContent.Rows.Count > 0;
            if (!isReturn)
                NotificationService.Notify("Предупреждение", "Необходимо заполнить все обязательные поля и добавить хотя бы одну позицию.", ToolTipIcon.Warning);
            return isReturn;
        }

        private bool TrySave()
        {
            if (!AllRequiredFieldsFilled()) return false;
            int workshopId = Convert.ToInt32(Workshop.SelectedValue);
            DateTime plannedDate = dateTimePicker1.Value;
            string requestType = ApplicationType.Text;
            string reason = Reason.Text;
            string status = "Создана";
            DateTime requestDate = DateTime.Now;

            if (!Validation.IsReceivingRequestValid(workshopId, plannedDate, requestType, reason))
                return false;

            try
            {
                var newRequest = dataSet.ReceivingRequests.NewReceivingRequestsRow();
                newRequest.ReceivingRequestDate = requestDate;
                newRequest.WorkshopID = workshopId;
                newRequest.PlannedDate = plannedDate;
                newRequest.ReceivingRequestType = requestType;
                newRequest.Reason = reason;
                newRequest.Status = status;
                dataSet.ReceivingRequests.Rows.Add(newRequest);
                requestsAdapter.Update(dataSet.ReceivingRequests);
                requestsAdapter.Fill(dataSet.ReceivingRequests);
                int requestId = newRequest.ReceivingRequestID;
                foreach (TOOLACCOUNTINGDataSet.ReceivingRequestsContentRow row in dataSet.ReceivingRequestsContent.Rows)
                {
                    row.ReceivingRequestID = requestId;
                }
                contentAdapter.Update(dataSet.ReceivingRequestsContent);
                NotificationService.Notify("Успех", "Заявка успешно добавлена!", ToolTipIcon.Info);
                ClearForm();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return true;
            }
            catch (Exception ex)
            {
                NotificationService.Notify("Ошибка", $"Ошибка при добавлении заявки: {ex.Message}", ToolTipIcon.Error);
                return false;
            }
        }

        private void WorkshopFormSave_Click(object sender, EventArgs e)
        {
            TrySave();
        }

        private void Reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reason.Text == "Другое")
            {
                OtherReasonText.Visible = true;
                OtherReason.Visible = true;
            }
            else
            {
                OtherReasonText.Visible = false;
                OtherReason.Visible = false;
            }
        }

        private void ApplicationsCompound_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void WorkshopFormClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Автоподстановка и фильтрация по вводу в ApplicationsCompound
        private void ApplicationsCompound_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox tb)
            {
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                var col = ApplicationsCompound.CurrentCell.ColumnIndex;
                var autoSource = new AutoCompleteStringCollection();
                var nomenTable = nomenclatureViewAdapter.GetData();
                if (col == ApplicationsCompound.Columns["nomenclatureNumberDataGridViewTextBoxColumn"].Index)
                {
                    foreach (DataRow row in nomenTable.Rows)
                        autoSource.Add(row["NomenclatureNumber"].ToString());
                }
                else if (col == ApplicationsCompound.Columns["fullNameDataGridViewTextBoxColumn"].Index)
                {
                    foreach (DataRow row in nomenTable.Rows)
                        autoSource.Add(row["FullName"].ToString());
                }
                tb.AutoCompleteCustomSource = autoSource;
            }
        }

        private void ApplicationsCompound_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = ApplicationsCompound.Rows[e.RowIndex];
            var nomenTable = nomenclatureViewAdapter.GetData();
            if (ApplicationsCompound.Columns[e.ColumnIndex].Name == "nomenclatureNumberDataGridViewTextBoxColumn")
            {
                var val = row.Cells["nomenclatureNumberDataGridViewTextBoxColumn"].Value?.ToString();
                if (!string.IsNullOrEmpty(val))
                {
                    var found = nomenTable.Rows.Cast<DataRow>().FirstOrDefault(n => n["NomenclatureNumber"].ToString() == val);
                    if (found != null)
                        row.Cells["fullNameDataGridViewTextBoxColumn"].Value = found["FullName"].ToString();
                }
            }
            else if (ApplicationsCompound.Columns[e.ColumnIndex].Name == "fullNameDataGridViewTextBoxColumn")
            {
                var val = row.Cells["fullNameDataGridViewTextBoxColumn"].Value?.ToString();
                if (!string.IsNullOrEmpty(val))
                {
                    var found = nomenTable.Rows.Cast<DataRow>().FirstOrDefault(n => n["FullName"].ToString() == val);
                    if (found != null)
                        row.Cells["nomenclatureNumberDataGridViewTextBoxColumn"].Value = found["NomenclatureNumber"].ToString();
                }
            }
        }

        private void ClearForm()
        {
            Workshop.SelectedIndex = -1;
            ApplicationType.SelectedIndex = 0;
            Reason.SelectedIndex = -1;
            dateTimePicker1.Value = DateTime.Today;
            dataSet.ReceivingRequestsContent.Clear();
        }

        private bool AllFieldsEmpty()
        {
            return (Workshop.SelectedIndex == -1 || Workshop.SelectedValue == null)
                && string.IsNullOrWhiteSpace(ApplicationType.Text)
                && string.IsNullOrWhiteSpace(Reason.Text)
                && dataSet.ReceivingRequestsContent.Rows.Count == 0;
        }

        private void AddApplications_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllFieldsEmpty())
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть форму? Все несохранённые данные будут потеряны.", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }

        private void ApplicationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateReasonItems();
        }

        private void UpdateReasonItems()
        {
            Reason.Items.Clear();
            if (ApplicationType.SelectedIndex == 0) // Плановая
            {
                Reason.Items.Add("Годовой план производства");
            }
            else // Внеплановая
            {
                Reason.Items.AddRange(new object[] {
                    "Увеличение объемов производства",
                    "Передача инструмента в другой цех",
                    "Ввод нового оборудования",
                    "Преждевременный выход инструмента из строя",
                    "Другое"
                });
            }
            Reason.SelectedIndex = -1;
        }

        private class WorkshopDisplay
        {
            public int WorkshopID { get; set; }
            public string Display { get; set; }
        }

        // Обработчик ошибок DataGridView
        private void ApplicationsCompound_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Просто подавляем ошибку, можно добавить логирование
            e.ThrowException = false;
        }

        private void ApplicationsCompound_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (e.Row.DataBoundItem is DataRowView drv && drv.Row is TOOLACCOUNTINGDataSet.ReceivingRequestsContentRow row)
            {
                if (row.RowState == DataRowState.Added)
                {
                    // Просто удалить из таблицы (ещё не сохранено)
                    row.Delete();
                }
                else
                {
                    // Если уже сохранено в базе, можно пометить на удаление
                    row.Delete();
                }
            }
        }
    }
}
