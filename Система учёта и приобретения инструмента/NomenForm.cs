using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters;

namespace Система_учёта_и_приобретения_инструмента
{

    public partial class NomenForm : Form
    {
        TOOLACCOUNTINGDataSet toolAccounting;
        NomenclatureTableAdapter tableAdapter;
        FormMode mode;
        TOOLACCOUNTINGDataSet.NomenclatureRow editRow;
        TOOLACCOUNTINGDataSet.NomenclatureViewRow editViewRow;

        TOOLACCOUNTINGDataSet.ReceivingRequestsContentRow requestsContentRow;
        public NomenForm(
            TOOLACCOUNTINGDataSet _toolAccounting,
            NomenclatureTableAdapter _tableAdapter,
            FormMode _mode = FormMode.Add,
            TOOLACCOUNTINGDataSet.NomenclatureViewRow _editRow = null,


            TOOLACCOUNTINGDataSet.ReceivingRequestsContentRow _requestsContentRow = null)
        {
            InitializeComponent();
            toolAccounting = _toolAccounting;
            tableAdapter = _tableAdapter;
            mode = _mode;
            editViewRow = _editRow;
            if (_editRow != null) editRow = toolAccounting.Nomenclature.FindByNomenclatureNumber(_editRow.NomenclatureNumber);
            else editRow = null;

            if (_requestsContentRow != null) requestsContentRow = _requestsContentRow;

            NomenFormUsage.SelectedIndex = 0;
        }
        AutoCompleteStringCollection groupSource = new AutoCompleteStringCollection();
        AutoCompleteStringCollection unitSource = new AutoCompleteStringCollection();
        AutoCompleteStringCollection sizesSource = new AutoCompleteStringCollection();
        AutoCompleteStringCollection materialSource = new AutoCompleteStringCollection();
        AutoCompleteStringCollection docSource = new AutoCompleteStringCollection();
        AutoCompleteStringCollection producerSource = new AutoCompleteStringCollection();
        //AutoCompleteStringCollection usageSource = new AutoCompleteStringCollection();

        GroupsTableAdapter groupsTableAdapter = new GroupsTableAdapter();
        NomenclatureViewTableAdapter nomenclatureViewTableAdapter = new NomenclatureViewTableAdapter();
        private void NomenForm_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.Edit && editRow != null)
            {
                NomenFormGroup.Text = editViewRow.Name;
                NomenFormNumber.Text = editViewRow.NomenclatureNumber;
                NomenFormOboz.Text = editViewRow.Designation;
                NomenFormUnits.Text = editViewRow.Unit;
                NomenFormSize.Text = editViewRow.Dimensions;
                NomenFormMaterial.Text = editViewRow.CuttingMaterial;
                NomenFormDocument.Text = editViewRow.RegulatoryDoc;
                NomenFormProducer.Text = editViewRow.Producer;
                //NomenFormFullName.Text = editViewRow.FullName;
                NomenFormUsage.SelectedIndex = editViewRow.UsageFlag + 1;
                NomenFormOstatok.Value = editViewRow.MinStock;
                FillFullName();
            }

            FillGroupsSource();

            nomenclatureViewTableAdapter.Fill(toolAccounting.NomenclatureView);

            NomenFormUnits.AutoCompleteCustomSource = NomenclatureSource(nomenclatureViewTableAdapter, 3, unitSource);
            NomenFormSize.AutoCompleteCustomSource = NomenclatureSource(nomenclatureViewTableAdapter, 4, sizesSource);
            NomenFormMaterial.AutoCompleteCustomSource = NomenclatureSource(nomenclatureViewTableAdapter, 5, materialSource);
            NomenFormDocument.AutoCompleteCustomSource = NomenclatureSource(nomenclatureViewTableAdapter, 6, docSource);
            NomenFormProducer.AutoCompleteCustomSource = NomenclatureSource(nomenclatureViewTableAdapter, 7, producerSource);
            //NomenFormUsage.AutoCompleteCustomSource = NomenclatureSource(nomenclatureViewTableAdapter, "UsageFlag", unitSource);
        }
        private void FillGroupsSource()
        {
            groupsTableAdapter.Fill(toolAccounting.Groups);
            foreach (DataRow row in groupsTableAdapter.GetData().Rows)
            {
                string name = row[1]?.ToString().Trim() ?? "";
                if (!string.IsNullOrEmpty(name))
                {
                    groupSource.Add(name);
                }
            }
            NomenFormGroup.AutoCompleteCustomSource = groupSource;
        }
private AutoCompleteStringCollection NomenclatureSource(NomenclatureViewTableAdapter nvta, int col, AutoCompleteStringCollection source)
        {
            HashSet<string> uniqueValues = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // Игнорируем регистр

            foreach (DataRow row in nvta.GetData().Rows)
            {
                string n = row[col]?.ToString().Trim() ?? "";
                if (!string.IsNullOrEmpty(n))
                {
                    // Добавляем только уникальные значения
                    uniqueValues.Add(n);
                }
            }

            // Очистим исходный источник и добавим только уникальные значения
            source.Clear();
            source.AddRange(uniqueValues.ToArray());

            return source;
        }

        private void FindInSource(System.Windows.Forms.TextBox sender, AutoCompleteStringCollection source)
        {
            string selectedText = sender.Text;
            sender.Text = new List<string>(source.Cast<string>()).Where(x => x.ToLower() == selectedText.ToLower()).FirstOrDefault();
            if(string.IsNullOrEmpty( sender.Text))
            {
                sender.Text = selectedText;
            }
        }

        #region Leave
        private void NomenFormGroup_Leave(object sender, EventArgs e)
        {
            FindInSource(sender as System.Windows.Forms.TextBox, groupSource);

            if (string.IsNullOrEmpty(NomenFormGroup.Text) || mode == FormMode.Edit) return;

            string range = toolAccounting.Groups
                .Where(x => x.Name == NomenFormGroup.Text)
                .Select(x => x.RangeStart)
                .FirstOrDefault();

            if(range == null)
            {
                NomenFormNumber.Text = "Нет такой группы";
                FillFullName();
                return;
            }
            List<string> numbers = toolAccounting.Nomenclature
                .Where(x => x.NomenclatureNumber.StartsWith(range))
                .Select(x => x.NomenclatureNumber)
                .ToList();

            var numbersSet = new HashSet<string>(numbers);

            int start = int.Parse(range + "00001");

            string number = Enumerable.Range(start, 99999)
                .Select(x => x.ToString("000000000"))
                .FirstOrDefault(x => !numbersSet.Contains(x));

            NomenFormNumber.Text = number ?? "Нет свободных номеров";

            FillFullName();
        }
        private void NomenFormOboz_Leave(object sender, EventArgs e)
        {
            FillFullName();
        }
        private void NomenFormUnits_Leave(object sender, EventArgs e)
        {
            FindInSource(sender as System.Windows.Forms.TextBox, unitSource);
            FillFullName();
        }

        private void NomenFormSize_Leave(object sender, EventArgs e)
        {
            FindInSource(sender as System.Windows.Forms.TextBox, sizesSource);
            FillFullName();
        }

        private void NomenFormMaterial_Leave(object sender, EventArgs e)
        {
            FindInSource(sender as System.Windows.Forms.TextBox, materialSource);
            FillFullName();
        }

        private void NomenFormDocument_Leave(object sender, EventArgs e)
        {
            FindInSource(sender as System.Windows.Forms.TextBox, docSource);
            FillFullName();
        }
        private void NomenFormProducer_Leave(object sender, EventArgs e)
        {
            FindInSource(sender as System.Windows.Forms.TextBox, producerSource);
        }
        #endregion

        private void FillFullName()
        {
            string fullName = $"{NomenFormGroup.Text} {NomenFormOboz.Text} {NomenFormSize.Text} {NomenFormMaterial.Text} {NomenFormDocument.Text}";
            NomenFormFullName.Text = fullName.Trim();
        }

        private bool TrySave()
        {
            if (!AllRequiredFieldsFilled()) return false;
            //возможная валидация
            if (!Validation.IsNomenclatureNumberCorrect(NomenFormNumber.Text)) return false;
            if (!Validation.IsNomenclatureNumberValid(NomenFormNumber.Text,toolAccounting)) return false;
            try
            {
                if (mode == FormMode.Add) CreateNomenclature();
                if (mode == FormMode.Edit) UpdateNomenclature();
                ClearForm();
                NomenFormGroup.Focus();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private bool AllRequiredFieldsFilled()
        {
            bool isReturn;
            isReturn =
                !string.IsNullOrEmpty(NomenFormGroup.Text) &&
                !string.IsNullOrEmpty(NomenFormNumber.Text) &&
                !string.IsNullOrEmpty(NomenFormUnits.Text) &&
                !string.IsNullOrEmpty(NomenFormUsage.Text) &&
                !string.IsNullOrEmpty(NomenFormOstatok.Text);
            if (!isReturn) NotificationService.Notify("Предупреждение", "Необходимо заполнить все обязательные поля, отмеченные *.", ToolTipIcon.Warning);
            return isReturn;

        }
        private void CreateNomenclature()
        {
            try
            {
                var newRow = toolAccounting.Nomenclature.NewNomenclatureRow();
                FillFields(newRow); //заполнение полей
                toolAccounting.Nomenclature.Rows.Add(newRow);
                Logging(true, newRow); //созданние логов корректировки
                UpdateTable(); // обновление таблицы номенклатуры
                UpdateLogs(); // обновление таблицы логов

                if(requestsContentRow != null)
                {
                    requestsContentRow.NomenclatureNumber = NomenFormNumber.Text;
                    new ReceivingRequestsContentTableAdapter().Update(toolAccounting.ReceivingRequestsContent);
                    //requestsContentRow.FullName
                    ClearForm();
                    Close();
                }
            }
            catch (Exception ex)
            {
                toolAccounting.Nomenclature.RejectChanges();
                toolAccounting.NomenclatureLogs.RejectChanges();
                throw ex;
            }
        }

        private void UpdateNomenclature()
        {
            if (editRow == null) return;

            try
            {
                TOOLACCOUNTINGDataSet.NomenclatureRow alterRow = toolAccounting.Nomenclature.NewNomenclatureRow();
                alterRow.NomenclatureNumber = editRow.NomenclatureNumber;
                alterRow.Unit = editRow.Unit;
                alterRow.UsageFlag = editRow.UsageFlag;
                alterRow.MinStock = editRow.MinStock;

                if (!editRow.IsDesignationNull()) alterRow.Designation = editRow.Designation;
                if (!editRow.IsDimensionsNull()) alterRow.Dimensions = editRow.Dimensions;
                if (!editRow.IsCuttingMaterialNull()) alterRow.CuttingMaterial = editRow.CuttingMaterial;
                if (!editRow.IsRegulatoryDocNull()) alterRow.RegulatoryDoc = editRow.RegulatoryDoc;
                if (!editRow.IsProducerNull()) alterRow.Producer = editRow.Producer;

                editRow.BeginEdit();
                FillFields(editRow);
                editRow.EndEdit();
                Logging(false, editRow, alterRow);
                UpdateTable();
                UpdateLogs();
            }
            catch
            {
                toolAccounting.Nomenclature.RejectChanges();
                toolAccounting.NomenclatureLogs.RejectChanges();
            }
        }


        private void FillFields(TOOLACCOUNTINGDataSet.NomenclatureRow row)
        {
            row.NomenclatureNumber = NomenFormNumber.Text;
            row.Unit = NomenFormUnits.Text;
            row.UsageFlag = (byte)(NomenFormUsage.SelectedIndex - 1);
            row.MinStock = int.Parse(NomenFormOstatok.Value.ToString());

            if (!string.IsNullOrEmpty(NomenFormOboz.Text)) row.Designation = NomenFormOboz.Text;
            if (!string.IsNullOrEmpty(NomenFormSize.Text)) row.Dimensions = NomenFormSize.Text;
            if (!string.IsNullOrEmpty(NomenFormMaterial.Text)) row.CuttingMaterial = NomenFormMaterial.Text;
            if (!string.IsNullOrEmpty(NomenFormDocument.Text)) row.RegulatoryDoc = NomenFormDocument.Text;
            if (!string.IsNullOrEmpty(NomenFormProducer.Text)) row.Producer = NomenFormProducer.Text;
        }

        public void UpdateTable()
        {
            try
            {
                tableAdapter.Update(toolAccounting.Nomenclature);
                tableAdapter.Fill(toolAccounting.Nomenclature);
                new NomenclatureViewTableAdapter().Fill(toolAccounting.NomenclatureView);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Logging(bool isAdd, TOOLACCOUNTINGDataSet.NomenclatureRow row, TOOLACCOUNTINGDataSet.NomenclatureRow oldRow = null)
        {
            var table = toolAccounting.Nomenclature; // Получаем таблицу заранее

            for (int i = 1; i < table.Columns.Count; i++) // Пропускаем первый столбец (например, ID)
            {

                // Проверяем, доступны ли обе строки для сравнения
                bool currentIsNull = row.IsNull(i);
                bool oldIsNull = oldRow?.IsNull(i) ?? true;

                // Получаем значение текущей строки
                string currentValue = currentIsNull ? null : row[i].ToString();

                // Если это новая запись — пропускаем пустые поля
                if (isAdd && string.IsNullOrEmpty(currentValue))
                    continue;

                // Если это изменение — проверяем разницу с предыдущим значением
                if (!isAdd && oldRow != null)
                {
                    string previousValue = oldIsNull ? null : oldRow[i].ToString();

                    // Если значения совпадают — пропускаем
                    if (currentIsNull == oldIsNull && string.Equals(currentValue, previousValue))
                        continue;
                }

                // Создаём лог
                var log = toolAccounting.NomenclatureLogs.NewNomenclatureLogsRow();

                log.NomenclatureNumber = row.NomenclatureNumber;

                string columnName = table.Columns[i].ColumnName;
                string columnHeader = Logs.FieldName(columnName);
                if (columnHeader == null) continue;
                log.FieldName = columnHeader;

                if (isAdd) log.OldValue = null;
                else log.OldValue = oldIsNull ? null : oldRow[i].ToString();

                log.NewValue = currentValue;
                log.ChangedDate = DateTime.Now;
                log.Executor = Environment.UserName;

                // Добавляем лог в таблицу
                toolAccounting.NomenclatureLogs.AddNomenclatureLogsRow(log);
            }
        }
        private void UpdateLogs()
        {
            NomenclatureLogsTableAdapter nomenclatureLogsTableAdapter = new NomenclatureLogsTableAdapter();
            nomenclatureLogsTableAdapter.Update(toolAccounting.NomenclatureLogs);
            nomenclatureLogsTableAdapter.Fill(toolAccounting.NomenclatureLogs);
        }

        private void ClearForm()
        {
            NomenFormGroup.Text = string.Empty;
            NomenFormNumber.Text = string.Empty;
            NomenFormOboz.Text = string.Empty;
            NomenFormUnits.Text = string.Empty;
            NomenFormSize.Text = string.Empty;
            NomenFormMaterial.Text = string.Empty;
            NomenFormDocument.Text = string.Empty;
            NomenFormProducer.Text = string.Empty;
            NomenFormFullName.Text = string.Empty;
            NomenFormUsage.SelectedIndex = 0;
            NomenFormOstatok.Value = 0;
        }

        private void NomenFormSave_Click(object sender, EventArgs e)
        {
            TrySave();
        }

        private void NomenFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave())
                Close();
        }

        private void NomenFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NomenForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            NomenFormClose.Focus();
            if (!AllFieldsEmpty())
            {
                DialogResult result = MessageBox.Show("Вы уверены, что хотите закрыть форму? Все несохраненные данные будут потеряны.", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }
        private bool AllFieldsEmpty()
        {
            return string.IsNullOrEmpty(NomenFormGroup.Text) &&
            string.IsNullOrEmpty(NomenFormNumber.Text) &&
            string.IsNullOrEmpty(NomenFormOboz.Text) &&
            string.IsNullOrEmpty(NomenFormUnits.Text) &&
            string.IsNullOrEmpty(NomenFormSize.Text) &&
            string.IsNullOrEmpty(NomenFormMaterial.Text) &&
            string.IsNullOrEmpty(NomenFormDocument.Text) &&
            string.IsNullOrEmpty(NomenFormProducer.Text) &&
            string.IsNullOrEmpty(NomenFormFullName.Text) &&
            string.IsNullOrEmpty(NomenFormUnits.Text) &&
            NomenFormUsage.SelectedIndex <= 0 &&
            NomenFormOstatok.Value == 0;

        }

        private void NomenFormAddGroup_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm(toolAccounting, groupsTableAdapter);
            groupForm.ShowDialog();
            FillGroupsSource();
        }
    }
}