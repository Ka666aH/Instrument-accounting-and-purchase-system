using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_учёта_и_приобретения_инструмента
{
    public enum FormMode
    {
        Add,
        Edit
    }
    public partial class Inj : Form
    {
        LoginForm login;
        bool changeUser = false;
        public Inj(LoginForm _login)
        {
            InitializeComponent();
            login = _login;
            //DateTime date = DateTime.Today;
            //MessageBox.Show(date.ToString());
        }

        private void Inj_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changeUser)
                login.Show();
            else
                login.Close();
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeUser = true;
            Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inj_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureLogs". При необходимости она может быть перемещена или удалена.
            this.nomenclatureLogsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureLogs);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Groups". При необходимости она может быть перемещена или удалена.
            this.groupsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Groups);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureWithFullName". При необходимости она может быть перемещена или удалена.
            this.nomenclatureWithFullNameTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureWithFullName);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Suppliers);

            WindowState = FormWindowState.Maximized;

            LogStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            LogEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddDays(-1);
        }

        private void InjLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (InjLevel1.SelectedIndex == 4)
            {
                //suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
                //suppliersTableAdapter.Fill(tOOLACCOUNTINGDataSet.Suppliers);
            }
        }

        #region Номенклатура инструмента

        #endregion

        #region Группы инструментов

        #endregion

        #region Приобретение инструмента

        #region Заявки от цехов

        #endregion

        #region Принятые заявки от цехов

        #endregion

        #region Создание заявки на приобретение

        #endregion

        #region Список заявок на приобретение

        #endregion

        #region Ведомости поставки

        #endregion

        #region Товарные накладные

        #endregion

        #region История поступлений

        #endregion

        #endregion

        #region Поставщики

        private void ProvidersButtonCreate_Click(object sender, EventArgs e)
        {
            SupForm supForm = new SupForm(tOOLACCOUNTINGDataSet, suppliersTableAdapter);
            supForm.ShowDialog();
        }

        private void ProvidersButtonAlter_Click(object sender, EventArgs e)
        {
            if (ProvidersTable.CurrentRow == null)
            {
                AlterDeleteButtonsState(false);
                return;
            }
            var selectedRow = ProvidersTable.CurrentRow.DataBoundItem as DataRowView;
            var supplierRow = selectedRow.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
            SupForm supForm = new SupForm(tOOLACCOUNTINGDataSet, suppliersTableAdapter, FormMode.Edit, supplierRow);
            supForm.ShowDialog();
        }

        private void ProvidersButtonDelete_Click(object sender, EventArgs e)
        {
            if (ProvidersTable.CurrentRow == null)
            {
                AlterDeleteButtonsState(false);
                return;
            }

            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление поставщика", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return;

            try
            {
                var selectedRow = ProvidersTable.CurrentRow.DataBoundItem as DataRowView;
                var supplierRow = selectedRow.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
                supplierRow.Delete();
                suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProvidersTable_CurrentCellChanged(object sender, EventArgs e)
        {
            if (ProvidersTable.CurrentRow == null)
            {
                AlterDeleteButtonsState(false);
            }
            else
            {
                AlterDeleteButtonsState(true);
            }
        }
        private void SuppliersTextChanged(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(ProvidersINN.Text)) parameters.Add("INN", ProvidersINN.Text);
            if (!string.IsNullOrEmpty(ProvidersName.Text)) parameters.Add("Name", ProvidersName.Text);
            try
            {
                string filter = Search.Filter(parameters);
                ProvidersTable.SuspendLayout();
                suppliersBindingSource.Filter = filter;
                ProvidersTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AlterDeleteButtonsState(bool state)
        {
            ProvidersButtonAlter.Enabled = state;
            ProvidersButtonDelete.Enabled = state;
        }

        private void ProvidersTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (ProvidersTable.CurrentCell.ColumnIndex == 0)
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= INN_KeyPress;
                    textBox.KeyPress += INN_KeyPress;
                }
            }
        }

        private void INN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        private void ProvidersTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //var row = ProvidersTable.CurrentRow;
            //var cell = ProvidersTable.CurrentCell;
            //switch (cell.ColumnIndex)
            //{
            //    case 0:

            //        var inn = cell.Value.ToString();
            //        if(row.IsNewRow) //проблема
            //        {
            //            if (!Validation.IsInnValid(inn) || !Validation.IsINNUnique(inn, tOOLACCOUNTINGDataSet, FormMode.Add)) e.Cancel = true;
            //        }
            //        else
            //        {
            //            var dataRowView= row.DataBoundItem as DataRowView;
            //            var originRow = dataRowView.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
            //            if (!Validation.IsInnValid(inn) || !Validation.IsINNUnique(inn, tOOLACCOUNTINGDataSet, FormMode.Edit,originRow)) e.Cancel = true;

            //        }
                    
            //        break;
            //    default:

            //        break;
            //}
        }
        private void ProvidersTable_RowValidated(object sender, DataGridViewCellEventArgs e)
        {

        }
        #endregion

        #region Аналоги инструментов

        #endregion

        #region Поставщики

        #endregion

        #region Логи корректировокв

        #endregion

        #region Остатки номенклатуры

        #endregion


    }
}
