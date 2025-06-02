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
    public partial class AnalogForm : Form
    {
        TOOLACCOUNTINGDataSet toolAccounting;
        AnalogToolsTableAdapter tableAdapter;
        FormMode mode;
        TOOLACCOUNTINGDataSet.AnalogToolsRow editRow;
        public AnalogForm(
            TOOLACCOUNTINGDataSet _toolAccounting,
            AnalogToolsTableAdapter _tableAdapter,
            FormMode _mode = FormMode.Add,
            TOOLACCOUNTINGDataSet.AnalogTools1Row _editRow = null)
        {
            InitializeComponent();
            toolAccounting = _toolAccounting;
            tableAdapter = _tableAdapter;
            mode = _mode;
            if (_editRow != null) editRow = toolAccounting.AnalogTools.FindByID(_editRow.ID);
            else editRow = null;
        }
        NonemclatureViewTableAdapter nomenclatureViewAdapter = new NonemclatureViewTableAdapter();
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        private void AnalogForm_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.Edit && editRow != null)
            {
                AnalogFormOrigiinalNumber.Text = editRow.OriginalNomenclatureNumber.ToString();
                AnalogFormAnalogNumber.Text = editRow.AnalogNomenclatureNumber.ToString();
                AnalogFormOrigiinalName.Text = toolAccounting.AnalogTools1.Where(a => a.OriginalNomenclatureNumber == AnalogFormOrigiinalNumber.Text).Select(a => a.OriginalFullName).FirstOrDefault();
                AnalogFormAnalogName.Text = toolAccounting.AnalogTools1.Where(a => a.AnalogNomenclatureNumber == AnalogFormAnalogNumber.Text).Select(a => a.AnalogFullName).FirstOrDefault();
            }
            nomenclatureViewAdapter.Fill(toolAccounting.NonemclatureView);

            foreach (DataRow row in nomenclatureViewAdapter.GetData().Rows)
            {
                if (row.Table.Columns.Contains("FullName"))
                {
                    string fullName = row["FullName"]?.ToString().Trim() ?? "";
                    if (!string.IsNullOrEmpty(fullName))
                    {
                        source.Add(fullName);
                    }

                }
            }
            AnalogFormOrigiinalName.AutoCompleteCustomSource = source;
            AnalogFormAnalogName.AutoCompleteCustomSource = source;
        }

        private void AnalogFormOrigiinalName_Leave(object sender, EventArgs e)
        {
            FindNomenclatureNumber(sender as System.Windows.Forms.ComboBox, true);
        }

        private void AnalogFormAnalogName_Leave(object sender, EventArgs e)
        {
            FindNomenclatureNumber(sender as System.Windows.Forms.ComboBox, false);
        }

        private void FindNomenclatureNumber(System.Windows.Forms.ComboBox sender, bool isOriginal)
        {
            string selectedText = sender.Text;
            sender.Text = new List<string>(source.Cast<string>()).Where(x => x.ToLower() == selectedText.ToLower()).FirstOrDefault();
            var foundRow = nomenclatureViewAdapter.GetData().Select($"FullName = '{selectedText}'").FirstOrDefault();
            if (foundRow != null)
            {
                string nomenclatureNumber = foundRow["NomenclatureNumber"].ToString();
                if (isOriginal) AnalogFormOrigiinalNumber.Text = nomenclatureNumber;
                else AnalogFormAnalogNumber.Text = nomenclatureNumber;
            }
        }

        private void AnalogFormOrigiinalNumber_TextChanged(object sender, EventArgs e)
        {

        }


        private void AnalogFormAnalogNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void AnalogFormSave_Click(object sender, EventArgs e)
        {
            TrySave();
        }

        private bool TrySave()
        {
            if (!AllRequiredFieldsFilled()) return false;
            if (!Validation.IsNomenclatureNumberExist(AnalogFormOrigiinalNumber.Text, toolAccounting)) return false;
            if (!Validation.IsNomenclatureNumberExist(AnalogFormOrigiinalNumber.Text, toolAccounting)) return false;

            try
            {
                if (AnalogFormOrigiinalNumber.Text == AnalogFormAnalogNumber.Text) throw new Exception("Номенклатурные номера основного и аналогичного инструмента не могут совпадать.");
                if (mode == FormMode.Add) CreateAnalog();
                if (mode == FormMode.Edit) UpdateAnalog();
                ClearForm();
                AnalogFormOrigiinalName.Focus();
                return true;
            }
            catch (Exception ex)
            {
                toolAccounting.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private bool AllRequiredFieldsFilled()
        {
            bool isReturn;
            isReturn = !string.IsNullOrEmpty(AnalogFormOrigiinalNumber.Text) &&
                !string.IsNullOrEmpty(AnalogFormAnalogNumber.Text);
            if (!isReturn) NotificationService.Notify("Предупреждение", "Необходимо заполнить все обязательные поля, отмеченные *.", ToolTipIcon.Warning);
            return isReturn;

        }
        private void CreateAnalog()
        {
            bool exists = toolAccounting.AnalogTools
                        .Any(r =>
                        r.OriginalNomenclatureNumber == AnalogFormOrigiinalNumber.Text &&
                        r.AnalogNomenclatureNumber == AnalogFormAnalogNumber.Text);

            if (exists)
            {
                throw new Exception("Такая пара аналогов уже существует.");
            }
            var newRow = toolAccounting.AnalogTools.NewAnalogToolsRow();
            FillFields(newRow);
            toolAccounting.AnalogTools.Rows.Add(newRow);
            UpdateTable();
        }

        private void UpdateAnalog()
        {
            bool exists = toolAccounting.AnalogTools
                        .Any(r =>
                        r.OriginalNomenclatureNumber == AnalogFormOrigiinalNumber.Text &&
                        r.AnalogNomenclatureNumber == AnalogFormAnalogNumber.Text &&
                        r.ID != editRow.ID);
            if (exists)
            {
                throw new Exception("Такая пара аналогов уже существует.");
            }
            if (editRow == null) return;
            FillFields(editRow);
            UpdateTable();
        }

        private void FillFields(TOOLACCOUNTINGDataSet.AnalogToolsRow row)
        {
            row.OriginalNomenclatureNumber = AnalogFormOrigiinalNumber.Text;
            row.AnalogNomenclatureNumber = AnalogFormAnalogNumber.Text;
        }

        public void UpdateTable()
        {
            try
            {
                tableAdapter.Update(toolAccounting.AnalogTools);
                tableAdapter.Fill(toolAccounting.AnalogTools);
                new AnalogTools1TableAdapter().Fill(toolAccounting.AnalogTools1);
                new DataTable1TableAdapter().Fill(toolAccounting.DataTable1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearForm()
        {
            AnalogFormOrigiinalName.Text = string.Empty;
            AnalogFormAnalogName.Text = string.Empty;
            AnalogFormOrigiinalNumber.Clear();
            AnalogFormAnalogNumber.Clear();
        }

        private void AnalogFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave())
                Close();
        }

        private void AnalogFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AnalogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnalogFormClose.Focus();
            if (!AllFieldsEmpty())
            {
                DialogResult result = MessageBox.Show("Вы уверены, что закрыть форму? Все несохранённые данные будут потеряны.", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }
        }
        private bool AllFieldsEmpty()
        {
            return string.IsNullOrEmpty(AnalogFormOrigiinalName.Text) &&
            string.IsNullOrEmpty(AnalogFormAnalogName.Text) &&
            string.IsNullOrEmpty(AnalogFormOrigiinalNumber.Text) &&
            string.IsNullOrEmpty(AnalogFormAnalogNumber.Text);
        }

        //private void SupFormINN_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        //}
    }
}
