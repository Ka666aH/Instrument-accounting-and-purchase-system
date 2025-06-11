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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class AddApplications : Form
    {
        private TOOLACCOUNTINGDataSet dataSet;
        private int? editingRequestId = null;
        private FormMode mode;
        private TOOLACCOUNTINGDataSet.ReceivingRequestsRow editRow;

        public event EventHandler RequestSaved;

        public AddApplications(
            TOOLACCOUNTINGDataSet _dataSet,
            FormMode _mode = FormMode.Add,
            TOOLACCOUNTINGDataSet.ReceivingRequests1Row _editRow = null)
        {
            InitializeComponent();
            dataSet = _dataSet;
            mode = _mode;
            if (_editRow != null)
            {
                editRow = dataSet.ReceivingRequests.Where(s => s.ReceivingRequestID == _editRow.ReceivingRequestID).FirstOrDefault();
            }
            else
            {
                editRow = null;
            }
            this.FormClosing += AddApplications_FormClosing;
        }
        NomenclatureViewTableAdapter nomenclatureViewAdapter = new NomenclatureViewTableAdapter();
        WorkshopsTableAdapter workshopTableAdapter = new WorkshopsTableAdapter();
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();


        //private void FindNomenclatureNumber(System.Windows.Forms.TextBox sender)
        //{
        //    string selectedText = sender.Text;
        //    sender.Text = new List<string>(source.Cast<string>()).Where(x => x.ToLower() == selectedText.ToLower()).FirstOrDefault();
        //    var foundRow = nomenclatureViewAdapter.GetData().Select($"FullName = '{selectedText}'").FirstOrDefault();
           
        //}


        private void AddApplications_Load(object sender, EventArgs e)
        {
            

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

            if (mode == FormMode.Edit && editRow != null)
            {
                // Заполняем поля формы из editRow
                textBox1.Text = editRow.ReceivingRequestID.ToString();
                ApplicationDate.Text = editRow.ReceivingRequestDate.ToShortDateString();
                Workshop.SelectedValue = editRow.WorkshopID;
                dateTimePicker1.Value = editRow.PlannedDate;
                ApplicationType.Text = editRow.ReceivingRequestType;
                Reason.Text = editRow.Reason;
            }
            else
            {
                ApplicationDate.Text = DateTime.Today.ToShortDateString();
                ApplicationType.SelectedIndex = 0;
                dateTimePicker1.MinDate = DateTime.Today;
                dateTimePicker1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(3).Month, 1);
            }

            // Автоматическая подстановка номера заявки
            if (editingRequestId.HasValue)
            {
                textBox1.Text = editingRequestId.Value.ToString();
            }
            else
            {
                // Обновляем данные из базы перед проверкой
                var requestsAdapter = new ReceivingRequestsTableAdapter();
                requestsAdapter.Fill(dataSet.ReceivingRequests);
                
                int newNumber;
                if (dataSet.ReceivingRequests.Count == 0)
                    newNumber = 1;
                else
                    newNumber = dataSet.ReceivingRequests.Max(r => r.ReceivingRequestID) + 1;
                textBox1.Text = newNumber.ToString();
            }

            UpdateReasonItems();
            ApplicationType.SelectedIndexChanged += ApplicationType_SelectedIndexChanged;

            // Подписка на автодополнение
            ApplicationsCompound.EditingControlShowing += ApplicationsCompound_EditingControlShowing;
            // Подписка на автоподстановку
            ApplicationsCompound.CellValueChanged += ApplicationsCompound_CellValueChanged;
            // Подписка на валидацию
            
        }

        private void CloseNewApplication_Click(object sender, EventArgs e)
        {
            new ReceivingRequests1TableAdapter().Fill(tOOLACCOUNTINGDataSet.ReceivingRequests1);
            new ReceivingRequestsContent1TableAdapter().Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsContent1);
            this.Close();
        }

        private bool AllRequiredFieldsFilled()
        {
            bool isReturn = Workshop.SelectedValue != null &&
                !string.IsNullOrWhiteSpace(ApplicationType.Text) &&
                !string.IsNullOrWhiteSpace(Reason.Text) &&
                ApplicationsCompound.Rows.Count > 1;
            if (!isReturn)
                NotificationService.Notify("Предупреждение", "Необходимо заполнить все обязательные поля и добавить хотя бы одну позицию.", ToolTipIcon.Warning);
            return isReturn;
        }

        private bool TrySave()
        {
            if (!AllRequiredFieldsFilled()) return false;
            int workshopId = Convert.ToInt32(Workshop.SelectedValue.ToString());
            DateTime plannedDate = dateTimePicker1.Value.Date;
            string requestType = ApplicationType.Text;
            string reason = Reason.Text;
            string status;
            if (editingRequestId.HasValue)
            {
                // Если редактирование — оставляем старый статус
                var existingRow = dataSet.ReceivingRequests
                    .Cast<TOOLACCOUNTINGDataSet.ReceivingRequestsRow>()
                    .FirstOrDefault(r => r.ReceivingRequestID == editingRequestId.Value);
                status = existingRow != null ? existingRow.Status : "Не обработана";
            }
            else
            {
                // Если создание — всегда 'Не обработана'
                status = "Не обработана";
            }
            DateTime requestDate = DateTime.Now;

            if (!Validation.IsReceivingRequestValid(workshopId, plannedDate, requestType, reason))
                return false;

            try
            {
                var newRequest = dataSet.ReceivingRequests.NewReceivingRequestsRow();
                newRequest.ReceivingRequestID = Convert.ToInt32(textBox1.Text);
                newRequest.ReceivingRequestDate = requestDate;
                newRequest.WorkshopID = workshopId;
                newRequest.PlannedDate = plannedDate;
                newRequest.ReceivingRequestType = requestType;
                newRequest.Reason = reason;
                newRequest.Status = status;
                dataSet.ReceivingRequests.Rows.Add(newRequest);
                var requestsAdapter = new ReceivingRequestsTableAdapter();
                requestsAdapter.Update(dataSet.ReceivingRequests);
                requestsAdapter.Fill(dataSet.ReceivingRequests);
                int requestId = Convert.ToInt32(textBox1.Text);

                // Обновляем глобальный DataSet
                var globalRequestsAdapter = new ReceivingRequests1TableAdapter();
                var globalContentAdapter = new ReceivingRequestsContent1TableAdapter();

                foreach (DataGridViewRow dataGridRow in ApplicationsCompound.Rows)
                {
                    if (dataGridRow.IsNewRow)
                        continue;
                    
                    var dataRowView = dataGridRow.DataBoundItem as DataRowView;
                    var row = dataRowView?.Row as TOOLACCOUNTINGDataSet.ReceivingRequestsContentRow;
                    if (row == null) continue;

                    TOOLACCOUNTINGDataSet.ReceivingRequestsContentRow newRow;
                    if (dataSet.ReceivingRequestsContent.Any(l => l.ReceivingContentID == row.ReceivingContentID))
                    {
                        newRow = dataSet.ReceivingRequestsContent.First(l => l.ReceivingContentID == row.ReceivingContentID);
                    }
                    else
                    {
                        newRow = dataSet.ReceivingRequestsContent.NewReceivingRequestsContentRow();
                    }
                    newRow.ReceivingRequestID = requestId;
                    if (!row.IsNomenclatureNumberNull())
                        newRow.NomenclatureNumber = row.NomenclatureNumber;
                    newRow.FullName = row.FullName;
                    newRow.Quantity = row.Quantity;
                    if(!dataSet.ReceivingRequestsContent.Any(l => l.ReceivingContentID == row.ReceivingContentID))
                    {
                        dataSet.ReceivingRequestsContent.AddReceivingRequestsContentRow(newRow);
                    }
                    receivingRequestsContentTableAdapter.Update(dataSet.ReceivingRequestsContent);
                    receivingRequestsContentTableAdapter.Fill(dataSet.ReceivingRequestsContent);

                    // Явное обновление глобального DataSet
                    globalRequestsAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequests1);
                    globalContentAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsContent1);
                }

                // Вызываем событие после успешного сохранения
                RequestSaved?.Invoke(this, EventArgs.Empty);

                NotificationService.Notify("Успех", "Заявка успешно добавлена!", ToolTipIcon.Info);
                ClearForm();
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


        private void WorkshopFormClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Автодополнение для DataGridView по справочнику номенклатуры
        private void ApplicationsCompound_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ApplicationsCompound.CurrentCell == null) return;
            var col = ApplicationsCompound.CurrentCell.OwningColumn;
            if (col.Name == "nomenclatureNumberDataGridViewTextBoxColumn" || col.Name == "fullNameDataGridViewTextBoxColumn")
            {
                if (e.Control is System.Windows.Forms.TextBox tb)
                {
                    tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    var autoSource = new AutoCompleteStringCollection();
                    var nomenTable = nomenclatureViewAdapter.GetData();
                    if (col.Name == "nomenclatureNumberDataGridViewTextBoxColumn")
                    {
                        foreach (DataRow row in nomenTable.Rows)
                            autoSource.Add(row["NomenclatureNumber"].ToString());
                    }
                    else if (col.Name == "fullNameDataGridViewTextBoxColumn")
                    {
                        foreach (DataRow row in nomenTable.Rows)
                            autoSource.Add(row["FullName"].ToString());
                    }
                    tb.AutoCompleteCustomSource = autoSource;
                }
            }
        }

        // Автоподстановка по номенклатурному номеру или полному наименованию
        private void ApplicationsCompound_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = ApplicationsCompound.Rows[e.RowIndex];
            var nomenTable = nomenclatureViewAdapter.GetData();

            // Если изменился номер номенклатуры
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
            // Если изменилось полное наименование
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
            //Просто подавляем ошибку, можно добавить логирование
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

        private void ApplicationsCompound_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var col = ApplicationsCompound.Columns[e.ColumnIndex];
            var row = ApplicationsCompound.Rows[e.RowIndex];
            var nomenTable = nomenclatureViewAdapter.GetData();

            if (col.Name == "nomenclatureNumberDataGridViewTextBoxColumn")
            {
                var val = row.Cells["nomenclatureNumberDataGridViewTextBoxColumn"].Value?.ToString();
                if (!string.IsNullOrEmpty(val))
                {
                    var found = nomenTable.Rows.Cast<DataRow>().FirstOrDefault(n => n["NomenclatureNumber"].ToString() == val);
                    if (found != null)
                        row.Cells["fullNameDataGridViewTextBoxColumn"].Value = found["FullName"].ToString();
                    // Если не найдено — ничего не делаем, пользовательский ввод сохраняется
                }
            }
            else if (col.Name == "fullNameDataGridViewTextBoxColumn")
            {
                var val = row.Cells["fullNameDataGridViewTextBoxColumn"].Value?.ToString();
                if (!string.IsNullOrEmpty(val))
                {
                    var found = nomenTable.Rows.Cast<DataRow>().FirstOrDefault(n => n["FullName"].ToString().ToLower() == val.ToLower());
                    if (found != null)
                        row.Cells["nomenclatureNumberDataGridViewTextBoxColumn"].Value = found["NomenclatureNumber"].ToString();
                    // Если не найдено — ничего не делаем, пользовательский ввод сохраняется
                }
            }
        }
        
        private void WorkshopFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave())
                Close();
        }


        private void ApplicationsCompound_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (ApplicationsCompound.Rows[e.RowIndex].IsNewRow || ApplicationsCompound.Rows[e.RowIndex].DataBoundItem == null)
            {
                return;
            }
     
            var dataRowView = ApplicationsCompound.Rows[e.RowIndex].DataBoundItem as DataRowView;
            var row = dataRowView?.Row as TOOLACCOUNTINGDataSet.ReceivingRequestsContentRow;
            row.ReceivingRequestID = Convert.ToInt32(textBox1.Text);
        }

        private void ApplicationsCompound_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = ApplicationsCompound.Rows[e.RowIndex];
            if (row.Cells[3] != null &&
                string.IsNullOrEmpty(row.Cells[3].Value?.ToString()) && !row.IsNewRow)
            {
                e.Cancel = true;
                NotificationService.Notify("Предупреждение", "Поле полного наименования не может быть пустым.", ToolTipIcon.Warning);
            }
            // Проверка поля Quantity
            if (row.Cells[4] != null && 
                string.IsNullOrEmpty(row.Cells[4].Value?.ToString()) && !row.IsNewRow)
            {
                e.Cancel = true;
                NotificationService.Notify("Предупреждение", "Поле количества не может быть пустым.", ToolTipIcon.Warning);
                return;
            }
            
            // Проверка поля FullName
           
            
        }
    }
}

