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
    public partial class GroupForm : Form
    {
        TOOLACCOUNTINGDataSet toolAccounting;
        GroupsTableAdapter tableAdapter;
        FormMode mode;
        TOOLACCOUNTINGDataSet.GroupsRow editRow;
        public GroupForm(
            TOOLACCOUNTINGDataSet _toolAccounting,
            GroupsTableAdapter _tableAdapter,
            FormMode _mode = FormMode.Add,
            TOOLACCOUNTINGDataSet.GroupsRow _editRow = null)
        {
            InitializeComponent();


            toolAccounting = _toolAccounting;
            tableAdapter = _tableAdapter;
            mode = _mode;
            editRow = _editRow;
        }

        private void GroupForm_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.Edit && editRow != null)
            {
                GroupFormRange.Text = editRow.RangeStart.ToString();
                GroupFormName.Text = editRow.Name;
            }
            else
            {
                var groups = toolAccounting.Groups;
                var groupsRanges = groups.Select(g => int.Parse(g.RangeStart)).ToList();
                GroupFormRange.Text = Enumerable.Range(1, 9999).FirstOrDefault(x => !groupsRanges.Contains(x)).ToString("0000");
            }
        }

        private void GroupFormSave_Click(object sender, EventArgs e)
        {
            if (TrySave())
            {
                ClearForm();
                GroupFormRange.Focus();
            }
        }

        private bool TrySave()
        {
            if (!AllRequiredFieldsFilled()) return false;
            if (!Validation.IsRangeValid(GroupFormRange.Text)) return false;
            if (!Validation.IsRangeUnique(GroupFormRange.Text, toolAccounting, mode, editRow)) return false;
            try
            {
                if (mode == FormMode.Add) CreateGroup();
                if (mode == FormMode.Edit) UpdateGroup();
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
            isReturn = !string.IsNullOrEmpty(GroupFormRange.Text) &&
                !string.IsNullOrEmpty(GroupFormName.Text);
            if (!isReturn) NotificationService.Notify("Предупреждение", "Необходимо заполнить все обязательные поля, отмеченные *.", ToolTipIcon.Warning);
            return isReturn;
        }

        private void CreateGroup()
        {
            var newRow = toolAccounting.Groups.NewGroupsRow();
            FillFields(newRow);
            toolAccounting.Groups.Rows.Add(newRow);
            UpdateTable();
        }

        private void UpdateGroup()
        {
            if (editRow == null) return;
            FillFields(editRow);
            tableAdapter.Update(toolAccounting.Groups);
            UpdateTable();
        }

        private void FillFields(TOOLACCOUNTINGDataSet.GroupsRow row)
        {
            row.RangeStart = GroupFormRange.Text;
            row.Name = GroupFormName.Text;
        }
        public void UpdateTable()
        {
            tableAdapter.Update(toolAccounting.Groups);
            tableAdapter.Fill(toolAccounting.Groups);
        }
        private void ClearForm()
        {
            GroupFormRange.ResetText();
            GroupFormName.Clear();
        }

        private void GroupFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave())
                Close();
        }

        private void GroupFormClose_Click(object sender, EventArgs e)
        {
            
            Close();
        }
        private bool AllFieldsEmpty()
        {
            return string.IsNullOrEmpty(GroupFormRange.Text) &&
            string.IsNullOrEmpty(GroupFormName.Text);
        }

        private void GroupFormRange_TextChanged(object sender, EventArgs e)
        {
            //if (GroupFormRange.Text.Length != 4) GroupFormRangeInfo.Text = string.Empty;
            //else
            //{
            //    if (toolAccounting.Groups.Select(g => g.RangeStart).Contains(GroupFormRange.Text))
            //        GroupFormRangeInfo.Text = $"Диапазон занят группой \"{toolAccounting.Groups.Where(g => g.RangeStart == GroupFormRange.Text).Select(g => g.Name).FirstOrDefault()}";
            //}
        }

        private void GroupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!AllFieldsEmpty())
            {
                DialogResult result = MessageBox.Show("Вы уверены, что закрыть форму? Все несохранённые данные будут потеряны.", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No) e.Cancel = true;
            }
        }
    }
}