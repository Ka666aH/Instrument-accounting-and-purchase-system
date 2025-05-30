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
using Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters;

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

        private void импортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ImportForm importForm = new ImportForm(tOOLACCOUNTINGDataSet);
            importForm.Owner = this;
            importForm.ShowDialog();

        }

        public string ImportRefresh(string tableName)
        {
            try
            {

                switch (tableName)
                {
                    case "Groups":

                        groupsTableAdapter.Update(tOOLACCOUNTINGDataSet.Groups);
                        InjLevel1.SelectedTab = InjGroupsPage;
                        return null;

                    case "Nomenclature":

                        nomenclatureTableAdapter.Update(tOOLACCOUNTINGDataSet.Nomenclature);
                        nomenclatureTableAdapter.Fill(tOOLACCOUNTINGDataSet.Nomenclature);
                        nonemclatureViewTableAdapter.Fill(tOOLACCOUNTINGDataSet.NonemclatureView);
                        InjLevel1.SelectedTab = InjNomenPage;
                        return null;

                    case "AnalogTools":

                        //обновление таблиц аналогов

                        analogToolsTableAdapter.Update(tOOLACCOUNTINGDataSet.AnalogTools);
                        analogToolsTableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools);
                        analogTools1TableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools1);
                        dataTable1TableAdapter.Fill(tOOLACCOUNTINGDataSet.DataTable1);
                        InjLevel1.SelectedTab = InjAnalogPage;
                        return null;

                    case "Suppliers":

                        suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
                        InjLevel1.SelectedTab = InjProvidersPage;
                        return null;

                    default: return "Не найдена таблица.";

                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private void Inj_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.AnalogTools". При необходимости она может быть перемещена или удалена.
            this.analogToolsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.AnalogTools);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DataTable1". При необходимости она может быть перемещена или удалена.
            this.dataTable1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DataTable1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.AnalogTools1". При необходимости она может быть перемещена или удалена.
            this.analogTools1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.AnalogTools1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Balances". При необходимости она может быть перемещена или удалена.
            this.balancesTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Balances);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.AnalogTools". При необходимости она может быть перемещена или удалена.
            //this.analogToolsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.AnalogTools);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NonemclatureView". При необходимости она может быть перемещена или удалена.
            this.nonemclatureViewTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NonemclatureView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Nomenclature". При необходимости она может быть перемещена или удалена.
            this.nomenclatureTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Nomenclature);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureLogs". При необходимости она может быть перемещена или удалена.
            this.nomenclatureLogsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureLogs);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Groups". При необходимости она может быть перемещена или удалена.
            this.groupsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Groups);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Suppliers);

            WindowState = FormWindowState.Maximized;

            LogStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            LogEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddMilliseconds(-1);
        }

        private void InjLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        public void SetProvidersButtonsState()
        {
            bool state = ProvidersTable.CurrentRow != null && !string.IsNullOrEmpty(ProvidersTable.CurrentRow.Cells[0].Value.ToString());
            ProvidersButtonAlter.Enabled = state;
            ProvidersButtonDelete.Enabled = state;
        }

        private void ProvidersButtonAlter_Click(object sender, EventArgs e)
        {
            SetProvidersButtonsState();
            if (ProvidersTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            var selectedRow = ProvidersTable.CurrentRow.DataBoundItem as DataRowView;
            var supplierRow = selectedRow.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
            SupForm supForm = new SupForm(tOOLACCOUNTINGDataSet, suppliersTableAdapter, FormMode.Edit, supplierRow);
            supForm.ShowDialog();
        }

        private void ProvidersButtonDelete_Click(object sender, EventArgs e)
        {
            ProvidersDelete();
        }

        private bool ProvidersDelete()
        {
            SetProvidersButtonsState();
            if (ProvidersTable.CurrentRow.DataBoundItem as DataRowView == null) return false;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление поставщика", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return false;

            try
            {
                var selectedRow = ProvidersTable.CurrentRow.DataBoundItem as DataRowView;
                var supplierRow = selectedRow.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
                supplierRow.Delete();
                suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ProvidersTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetProvidersButtonsState();
        }
        private void SuppliersTextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(ProvidersINN.Text)) parameters.Add(new SearchParameter("INN", ProvidersINN.Text, true));
            if (!string.IsNullOrEmpty(ProvidersName.Text)) parameters.Add(new SearchParameter("Name", ProvidersName.Text, false));
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

        private void ProvidersTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!ProvidersDelete()) e.Cancel = true;
        }

        private TOOLACCOUNTINGDataSet.SuppliersRow originSupplierRow = null;
        private bool userEditing = false;

        private void ProvidersTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            userEditing = true;
            var dataRowView = ProvidersTable.Rows[e.RowIndex].DataBoundItem as DataRowView;
            originSupplierRow = dataRowView?.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
        }

        private void ProvidersTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!userEditing) return;
            if (ProvidersTable.Rows[e.RowIndex] == null) return;
            var row = ProvidersTable.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            //var dataRowView = row.DataBoundItem as DataRowView;
            //var supplierRow = dataRowView?.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
            //if (supplierRow == null) return;
            switch (e.ColumnIndex)
            {
                case 0:

                    string inn = cell.EditedFormattedValue as string;
                    FormMode mode;
                    if (originSupplierRow == null) mode = FormMode.Add;
                    else mode = FormMode.Edit;
                    if (!Validation.IsInnValid(inn))
                    {
                        e.Cancel = true;
                        //NotificationService.Notify("Предупреждение", "ИНН должен содержать 10 цифр (для юридических лиц) или 12 цифр (для физических лиц и индивидуальных предпринимателей).", ToolTipIcon.Warning);
                    }
                    if (!Validation.IsINNUnique(inn, tOOLACCOUNTINGDataSet, mode, originSupplierRow))
                    {
                        e.Cancel = true;
                        NotificationService.Notify("Предупреждение", "Поставщик с таким ИНН уже существует.", ToolTipIcon.Warning);
                    }

                    break;
                case 4: break;
                default:

                    if (string.IsNullOrEmpty(cell.EditedFormattedValue as string))
                    {
                        e.Cancel = true;
                        NotificationService.Notify("Предупреждение", "Это поле не может быть пустым.", ToolTipIcon.Warning);
                    }

                    break;
            }
        }

        private void ProvidersTable_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
            userEditing = false;
        }

        #endregion

        #region Аналоги инструментов

        #endregion

        #region 

        #endregion

        #region Логи корректировокв

        #endregion

        #region Остатки номенклатуры

        #endregion

    }
}
