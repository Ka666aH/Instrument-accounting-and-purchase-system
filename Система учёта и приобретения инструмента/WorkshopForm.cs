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
    public partial class WorkshopForm: Form
    {
        TOOLACCOUNTINGDataSet toolAccounting;
        WorkshopsTableAdapter tableAdapter;
        FormMode mode;
        TOOLACCOUNTINGDataSet.WorkshopsRow editRow;
        public WorkshopForm(
            TOOLACCOUNTINGDataSet _toolAccounting,
            WorkshopsTableAdapter _tableAdapter,
            FormMode _mode = FormMode.Add,
            TOOLACCOUNTINGDataSet.Workshops1Row _editRow = null)
        {
            InitializeComponent();
            toolAccounting = _toolAccounting;
            tableAdapter = _tableAdapter;
            mode = _mode;
            if (_editRow != null)
            {
                    editRow = toolAccounting.Workshops.Where(s => s.WorkshopID == _editRow.WorkshopID).FirstOrDefault();
                    //editRow.WorkshopID = _editRow.WorkshopID;
                    //editRow.Name = _editRow.Name;
                }
            else
            {
                editRow = null;
            }
            
        }

        private void WorkshopForm_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.Edit && editRow != null)
            {
                WorkshopNumber.Text = editRow.WorkshopID.ToString();
                WorkshopName.Text = editRow.Name;
            }
        }

        private void WorkshopFormSave_Click(object sender, EventArgs e)
        {
            TrySave();
           
        }
        private bool AllRequiredFieldsFilled()
        {
            bool isReturn;
            isReturn = !string.IsNullOrEmpty(WorkshopNumber.Text) &&
                !string.IsNullOrEmpty(WorkshopName.Text);
            if (!isReturn) NotificationService.Notify("Предупреждение", "Необходимо заполнить все обязательные поля, отмеченные *.", ToolTipIcon.Warning);
            return isReturn;

        }
        private void ClearForm()
        {
            WorkshopName.Clear();
            WorkshopNumber.Clear();
        }

        private void CreateWorkshop()
        {
            var newRow = toolAccounting.Workshops.NewWorkshopsRow();
            FillFields(newRow);
            toolAccounting.Workshops.Rows.Add(newRow);
            UpdateTable();
        }

        public void UpdateTable()
        {
            tableAdapter.Update(toolAccounting.Workshops);
            tableAdapter.Fill(toolAccounting.Workshops);
            Workshops1TableAdapter WP1 = new Workshops1TableAdapter();
            WP1.Fill(toolAccounting.Workshops1);
        }

        private void UpdateWorkshop()
        {
            if (editRow == null) return;
            FillFields(editRow);
            UpdateTable();
        }
        private void FillFields(TOOLACCOUNTINGDataSet.WorkshopsRow row)
        {
            row.WorkshopID = Convert.ToInt32(WorkshopNumber.Text);
            row.Name = WorkshopName.Text;
         
        }


        private bool TrySave()
        {
            if (!AllRequiredFieldsFilled()) return false;
            if (!Validation.IsWorkshopUnique(WorkshopNumber.Text, toolAccounting, mode, editRow)) return false;

            try
            {
                if (mode == FormMode.Add) CreateWorkshop();
                if (mode == FormMode.Edit) UpdateWorkshop();
                ClearForm();
                WorkshopNumber.Focus();
                return true;
            }
            catch (Exception ex)
            {
                toolAccounting.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void WorkshopFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave())
                Close();
        }
        private bool AllFieldsEmpty()
        {
            return string.IsNullOrEmpty(WorkshopNumber.Text) &&
            string.IsNullOrEmpty(WorkshopName.Text);
        }

        private void WorkshopForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllFieldsEmpty())
            {
                DialogResult result = MessageBox.Show("Вы уверены, что закрыть форму? Все несохранённые данные будут потеряны.", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) e.Cancel = true;
            }

            
        }

        private void WorkshopNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        private void WorkshopFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

