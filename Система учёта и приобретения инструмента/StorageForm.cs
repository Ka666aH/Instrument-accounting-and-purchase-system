using Microsoft.Office.Interop.Excel;
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
using static Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class StorageForm: Form
    {
        TOOLACCOUNTINGDataSet toolAccounting;
        StoragesTableAdapter tableAdapter;
        FormMode mode;
        TOOLACCOUNTINGDataSet.StoragesRow editRow;
        public StorageForm(TOOLACCOUNTINGDataSet _toolAccounting,
            StoragesTableAdapter _tableAdapter,
            FormMode _mode = FormMode.Add,
            TOOLACCOUNTINGDataSet.StoragesRow _editRow = null)
        {
            
            InitializeComponent();
            toolAccounting = _toolAccounting;
            tableAdapter = _tableAdapter;
            mode = _mode;
            if (_editRow != null)
            {
                editRow = toolAccounting.Storages.Where(s => s.StorageID == _editRow.StorageID).FirstOrDefault();
                editRow.WorkshopID = _editRow.WorkshopID;
                editRow.Name = _editRow.Name;
            }
            else
            {
                editRow = null;
            }
        }

        private void StorageFormSave_Click(object sender, EventArgs e)
        {
            TrySave();
        }

        private bool AllRequiredFieldsFilled()
        {
            bool isReturn;
            isReturn = !string.IsNullOrEmpty(StorageNumber.Text) &&
                !string.IsNullOrEmpty(StorageName.Text) &&
                !string.IsNullOrEmpty(WorkshopNumber.Text);
            if (!isReturn) NotificationService.Notify("Предупреждение", "Необходимо заполнить все обязательные поля, отмеченные *.", ToolTipIcon.Warning);
            return isReturn;

        }

        private void ClearForm()
        {
            StorageNumber.Clear();
            StorageName.Clear();
            WorkshopNumber.Clear();
        }

        private void CreateStorage()
        {
            var newRow = toolAccounting.Storages.NewStoragesRow();
            FillFields(newRow);
            toolAccounting.Storages.Rows.Add(newRow);
            UpdateTable();
        }

        public void UpdateTable()
        {
            tableAdapter.Update(toolAccounting.Storages);
            tableAdapter.Fill(toolAccounting.Storages);
            Storages1TableAdapter WP1 = new Storages1TableAdapter();
            WP1.Fill(toolAccounting.Storages1);
        }

        private void UpdateStorage()
        {
            if (editRow == null) return;
            FillFields(editRow);
            UpdateTable();
        }
        private void FillFields(TOOLACCOUNTINGDataSet.StoragesRow row)
        {
            row.StorageID = Convert.ToInt32(StorageNumber.Text);
            row.Name = StorageName.Text;
            row.WorkshopID = Convert.ToInt32(WorkshopNumber.Text);

        }

        private bool TrySave()
        {
            if (!AllRequiredFieldsFilled()) return false;
            if (!Validation.IsStorageUnique(StorageNumber.Text, toolAccounting, mode, editRow)) return false;
            if (!Validation.IsStorageConnectedToWorkshop(Convert.ToInt32(WorkshopNumber.Text),toolAccounting, mode, editRow)) return false;
            try
            {
                if (mode == FormMode.Add) CreateStorage();
                if (mode == FormMode.Edit) UpdateStorage();
                ClearForm();
                StorageNumber.Focus();
                return true;
            }
            catch (Exception ex)
            {
                toolAccounting.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private void StorageFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave())
                Close();
        }
        private bool AllFieldsEmpty()
        {
            return string.IsNullOrEmpty(WorkshopNumber.Text) &&
            string.IsNullOrEmpty(StorageName.Text) &&
            string.IsNullOrEmpty(StorageNumber.Text);
        }



        private void StorageFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void StorageForm_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.Edit && editRow != null)
            {
                StorageNumber.Text = editRow.StorageID.ToString();
                StorageName.Text = editRow.Name;
                WorkshopNumber.Text = editRow.WorkshopID.ToString();
            }
        }

        private void StorageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllFieldsEmpty())
            {
                DialogResult result = MessageBox.Show("Вы уверены, что закрыть форму? Все несохранённые данные будут потеряны.", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }

        private void StorageNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        private void WorkshopNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }
    }
}
