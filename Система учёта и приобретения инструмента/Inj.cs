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
using static Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet;

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
                        groupsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Groups);
                        InjLevel1.SelectedTab = InjGroupsPage;
                        return null;

                    case "Nomenclature":

                        nomenclatureTableAdapter.Update(tOOLACCOUNTINGDataSet.Nomenclature);
                        nomenclatureTableAdapter.Fill(tOOLACCOUNTINGDataSet.Nomenclature);
                        nomenclatureViewTableAdapter.Fill(tOOLACCOUNTINGDataSet.NomenclatureView);
                        InjLevel1.SelectedTab = InjNomenPage;
                        return null;

                    case "AnalogTools":

                        analogToolsTableAdapter.Update(tOOLACCOUNTINGDataSet.AnalogTools);
                        analogToolsTableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools);
                        analogTools1TableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools1);
                        dataTable1TableAdapter.Fill(tOOLACCOUNTINGDataSet.DataTable1);
                        AnalogListTable.Columns[0].Visible = false;
                        InjLevel1.SelectedTab = InjAnalogPage;
                        return null;

                    case "Suppliers":

                        suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
                        suppliersTableAdapter.Fill(tOOLACCOUNTINGDataSet.Suppliers);
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsInj". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.AnalogTools". При необходимости она может быть перемещена или удалена.
            this.analogToolsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.AnalogTools);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DataTable1". При необходимости она может быть перемещена или удалена.
            this.dataTable1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DataTable1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.AnalogTools1". При необходимости она может быть перемещена или удалена.
            this.analogTools1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.AnalogTools1);
            AnalogListTable.Columns[0].Visible = false;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Balances". При необходимости она может быть перемещена или удалена.
            this.balancesTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Balances);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.AnalogTools". При необходимости она может быть перемещена или удалена.
            this.nomenclatureViewTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureView);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Nomenclature". При необходимости она может быть перемещена или удалена.
            this.nomenclatureTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Nomenclature);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureLogs". При необходимости она может быть перемещена или удалена.
            this.nomenclatureLogsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureLogs);
            LogTable.Columns[0].Visible = false;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Groups". При необходимости она может быть перемещена или удалена.
            this.groupsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Groups);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Suppliers);

            WindowState = FormWindowState.Maximized;

            //ProvidersTable.Rows[0].Selected = true;

            LogStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            LogEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddMilliseconds(-1);


            //AnalogCompareTable.RowTemplate.Height = (AnalogCompareTable.Height-AnalogCompareTable.ColumnHeadersHeight-10)/2;
        }

        private void InjLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region Номенклатура инструмента

        public void SetNomenButtonsState()
        {
            try
            {
                bool state =
                    NomenTable.CurrentRow != null &&
                    !string.IsNullOrEmpty(NomenTable.CurrentRow.Cells[0].Value.ToString()) &&
                    !NomenTable.CurrentRow.IsNewRow;

                NomenButtonAlter.Enabled = state;
                NomenButtonDelete.Enabled = state;
                NomenButtonOstatki.Enabled = state;
                NomenButtonHistory.Enabled = state;
                NomenButtonLog.Enabled = state;
            }
            catch { }
        }

        private void NomenButtonCreate_Click(object sender, EventArgs e)
        {
            NomenForm nomenForm = new NomenForm(tOOLACCOUNTINGDataSet, nomenclatureTableAdapter);
            nomenForm.ShowDialog();
            LogTable.Columns[0].Visible = false;
        }

        private void NomenButtonAlter_Click(object sender, EventArgs e)
        {
            SetNomenButtonsState();
            if (NomenTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            var selectedRow = NomenTable.CurrentRow.DataBoundItem as DataRowView;
            var nomenViewRow = selectedRow.Row as TOOLACCOUNTINGDataSet.NomenclatureViewRow;
            NomenForm nomenForm = new NomenForm(tOOLACCOUNTINGDataSet, nomenclatureTableAdapter, FormMode.Edit, nomenViewRow);
            nomenForm.ShowDialog();
            LogTable.Columns[0].Visible = false;
        }

        private void NomenButtonDelete_Click(object sender, EventArgs e)
        {
            NomenDelete();
        }

        private bool NomenDelete()
        {
            SetNomenButtonsState();
            if (NomenTable.CurrentRow.DataBoundItem as DataRowView == null) return false;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return false;

            try
            {
                var selectedRow = NomenTable.CurrentRow.DataBoundItem as DataRowView;
                var nomenViewRow = selectedRow.Row as TOOLACCOUNTINGDataSet.NomenclatureViewRow;
                var nomenViewRowNumber = nomenViewRow.NomenclatureNumber;

                var nomenRow = tOOLACCOUNTINGDataSet.Nomenclature.Where(x => x.NomenclatureNumber == nomenViewRowNumber).FirstOrDefault();
                DeleteLogs(nomenRow);
                nomenRow.Delete();
                nomenclatureTableAdapter.Update(tOOLACCOUNTINGDataSet.Nomenclature);
                nomenclatureTableAdapter.Fill(tOOLACCOUNTINGDataSet.Nomenclature);
                nomenclatureViewTableAdapter.Fill(tOOLACCOUNTINGDataSet.NomenclatureView);

                nomenclatureLogsTableAdapter.Update(tOOLACCOUNTINGDataSet.NomenclatureLogs);
                nomenclatureLogsTableAdapter.Fill(tOOLACCOUNTINGDataSet.NomenclatureLogs);

                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.Nomenclature.RejectChanges();
                tOOLACCOUNTINGDataSet.NomenclatureLogs.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void NomenButtonOstatki_Click(object sender, EventArgs e)
        {
            SetNomenButtonsState();
            if (NomenTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            OstatkiNumber.Text = NomenTable.CurrentRow.Cells[0].Value.ToString();
            InjLevel1.SelectedTab = InjOstatkiPage;
        }

        private void NomenButtonHistory_Click(object sender, EventArgs e)
        {
            SetNomenButtonsState();
            if (NomenTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            HistoryNumber.Text = NomenTable.CurrentRow.Cells[0].Value.ToString();
            InjLevel1.SelectedTab = InjZayavkiPage;
            InjLevel2.SelectedTab = History;
        }

        private void NomenButtonLog_Click(object sender, EventArgs e)
        {
            SetNomenButtonsState();
            if (NomenTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            LogNumber.Text = NomenTable.CurrentRow.Cells[0].Value.ToString();
            InjLevel1.SelectedTab = InjLogPage;
        }

        private void NomenTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetNomenButtonsState();
        }

        private void NomenTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (
                NomenTable.CurrentCell.ColumnIndex == 0 ||
                NomenTable.CurrentCell.ColumnIndex == 9 ||
                NomenTable.CurrentCell.ColumnIndex == 10
                )
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= Digits_KeyPress;
                    textBox.KeyPress += Digits_KeyPress;
                }
            }
            else
            {
                if (e.Control is TextBox textBox) textBox.KeyPress -= Digits_KeyPress;
            }
        }

        private void NomenTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!NomenDelete()) e.Cancel = true;
        }
        private TOOLACCOUNTINGDataSet.NomenclatureRow nomenOriginRow = null;
        private bool nomenUserEditing = false;

        private void NomenTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            nomenUserEditing = true;
            var dataRowView = NomenTable.Rows[e.RowIndex].DataBoundItem as DataRowView;
            TOOLACCOUNTINGDataSet.NomenclatureViewRow nomenViewOriginRow = dataRowView?.Row as TOOLACCOUNTINGDataSet.NomenclatureViewRow;
            if (nomenViewOriginRow != null) nomenOriginRow = tOOLACCOUNTINGDataSet.Nomenclature.FindByNomenclatureNumber(nomenViewOriginRow.NomenclatureNumber);
            else nomenOriginRow = null;
            var row = NomenTable.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            if (cell.ColumnIndex == 0 && nomenOriginRow != null)
            {
                nomenUserEditing = false;
                e.Cancel = true;
            }

        }

        private void NomenTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!nomenUserEditing) return;
            if (NomenTable.Rows[e.RowIndex] == null) return;
            var row = NomenTable.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            FormMode mode;
            if (nomenOriginRow == null) mode = FormMode.Add;
            else mode = FormMode.Edit;
            switch (e.ColumnIndex)
            {
                case 0:
                    try
                    {
                        string nomenclatureNumber = cell.EditedFormattedValue?.ToString();
                        if (!Validation.IsNomenclatureNumberCorrect(nomenclatureNumber)) e.Cancel = true;
                        if (!Validation.IsNomenclatureNumberValid(nomenclatureNumber, tOOLACCOUNTINGDataSet)) e.Cancel = true;
                        if (!Validation.IsNomenclatureNumberUnique(nomenclatureNumber, tOOLACCOUNTINGDataSet, mode, nomenOriginRow)) e.Cancel = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка значения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    break;
                case 2:
                case 4:
                case 5:
                case 6:
                case 7:
                case 10:

                case 1:
                case 8:

                    //cell.Value = DBNull.Value;

                    break;
                default:

                    try
                    {
                        if (string.IsNullOrEmpty(cell.EditedFormattedValue as string))
                        {
                            e.Cancel = true;
                            NotificationService.Notify("Предупреждение", "Это поле не может быть пустым.", ToolTipIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка значения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    break;
            }
        }

        private void NomenTable_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!nomenUserEditing) return;

            DataGridViewRow row = null;
            try
            {
                row = NomenTable.Rows[e.RowIndex];
                DataRowView selectedRow = row.DataBoundItem as DataRowView;
                if (selectedRow == null) return;
                var nomenViewRow = selectedRow.Row as TOOLACCOUNTINGDataSet.NomenclatureViewRow;
                var nomenViewRowNumber = nomenViewRow.NomenclatureNumber;
                var nomenRow = tOOLACCOUNTINGDataSet.Nomenclature.Where(x => x.NomenclatureNumber == nomenViewRowNumber).FirstOrDefault();

                if (nomenRow != null)
                {
                    AlterLogs(nomenRow, nomenViewRow);
                    nomenRow.BeginEdit();
                    NomenFillFields(nomenRow, nomenViewRow);
                    nomenRow.EndEdit();
                }
                else
                {
                    var newRow = tOOLACCOUNTINGDataSet.Nomenclature.NewNomenclatureRow();
                    newRow.NomenclatureNumber = nomenViewRow.NomenclatureNumber;
                    NomenFillFields(newRow, nomenViewRow);
                    tOOLACCOUNTINGDataSet.Nomenclature.Rows.Add(newRow);
                    AddLogs(newRow);
                }
                nomenclatureTableAdapter.Update(tOOLACCOUNTINGDataSet.Nomenclature);
                nomenclatureTableAdapter.Fill(tOOLACCOUNTINGDataSet.Nomenclature);
                nomenclatureViewTableAdapter.Fill(tOOLACCOUNTINGDataSet.NomenclatureView);

                nomenclatureLogsTableAdapter.Update(tOOLACCOUNTINGDataSet.NomenclatureLogs);
                nomenclatureLogsTableAdapter.Fill(tOOLACCOUNTINGDataSet.NomenclatureLogs);
                LogTable.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                tOOLACCOUNTINGDataSet.Nomenclature.RejectChanges();
                tOOLACCOUNTINGDataSet.NomenclatureLogs.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void NomenFillFields(NomenclatureRow row, NomenclatureViewRow nomenViewRow)
        {
            row.Designation = nomenViewRow.Designation;
            row.Unit = nomenViewRow.Unit;
            row.Dimensions = nomenViewRow.Dimensions;
            row.CuttingMaterial = nomenViewRow.CuttingMaterial;
            row.RegulatoryDoc = nomenViewRow.RegulatoryDoc;
            row.Producer = nomenViewRow.Producer;
            row.UsageFlag = nomenViewRow.UsageFlag;
            row.MinStock = nomenViewRow.MinStock;
        }


        private void NomenTable_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            nomenUserEditing = false;
        }
        private void Nomen_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(NomenNumber.Text)) parameters.Add(new SearchParameter("NomenclatureNumber", NomenNumber.Text));
            if (!string.IsNullOrEmpty(NomenName.Text)) parameters.Add(new SearchParameter("FullName", NomenName.Text, false));
            if (!string.IsNullOrEmpty(NomenSize.Text)) parameters.Add(new SearchParameter("Dimensions", NomenSize.Text, false));
            if (!string.IsNullOrEmpty(NomenMaterial.Text)) parameters.Add(new SearchParameter("CuttingMaterial", NomenMaterial.Text));
            if (!string.IsNullOrEmpty(NomenProducer.Text)) parameters.Add(new SearchParameter("Producer", NomenProducer.Text));
            if (!string.IsNullOrEmpty(NomenUsage.Text)) parameters.Add(new SearchParameter("UsageFlag", NomenUsage.SelectedIndex - 1));

            try
            {
                string filter = Search.Filter(parameters);
                NomenTable.SuspendLayout();
                nomenclatureViewBindingSource.Filter = filter;
                NomenTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Группы инструментов

        public void SetGroupsButtonsState()
        {
            try
            {
                bool state = GroupsTable.CurrentRow != null && !string.IsNullOrEmpty(GroupsTable.CurrentRow.Cells[0].Value.ToString());
                GroupsButtonAlter.Enabled = state;
                GroupsButtonDelete.Enabled = state;
            }
            catch { }
        }

        private void GroupsButtonCreate_Click(object sender, EventArgs e)
        {
            GroupForm groupForm = new GroupForm(tOOLACCOUNTINGDataSet, groupsTableAdapter);
            groupForm.ShowDialog();
        }

        private void GroupsButtonAlter_Click(object sender, EventArgs e)
        {
            SetGroupsButtonsState();
            if (GroupsTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            var selectedRow = GroupsTable.CurrentRow.DataBoundItem as DataRowView;
            var groupRow = selectedRow.Row as TOOLACCOUNTINGDataSet.GroupsRow;
            GroupForm groupForm = new GroupForm(tOOLACCOUNTINGDataSet, groupsTableAdapter, FormMode.Edit, groupRow);
            groupForm.ShowDialog();
        }

        private void GroupsButtonDelete_Click(object sender, EventArgs e)
        {
            GroupsDelete();
        }

        private bool GroupsDelete()
        {
            SetGroupsButtonsState();
            if (GroupsTable.CurrentRow.DataBoundItem as DataRowView == null) return false;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return false;

            try
            {
                var selectedRow = GroupsTable.CurrentRow.DataBoundItem as DataRowView;
                var groupRow = selectedRow.Row as TOOLACCOUNTINGDataSet.GroupsRow;
                groupRow.Delete();
                groupsTableAdapter.Update(tOOLACCOUNTINGDataSet.Groups);
                groupsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Groups);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void GroupsTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetGroupsButtonsState();
        }

        private void GroupsTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (GroupsTable.CurrentCell.ColumnIndex == 0)
            {
                if (e.Control is TextBox textBox)
                {
                    textBox.KeyPress -= Digits_KeyPress;
                    textBox.KeyPress += Digits_KeyPress;
                }
            }
            else
            {
                if (e.Control is TextBox textBox) textBox.KeyPress -= Digits_KeyPress;
            }
        }

        private void GroupsTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!GroupsDelete()) e.Cancel = true;
        }

        private TOOLACCOUNTINGDataSet.GroupsRow groupOriginRow = null;
        private bool groupUserEditing = false;
        private void GroupsTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            groupUserEditing = true;
            var dataRowView = GroupsTable.Rows[e.RowIndex].DataBoundItem as DataRowView;
            groupOriginRow = dataRowView?.Row as TOOLACCOUNTINGDataSet.GroupsRow;
        }

        private void GroupsTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!groupUserEditing) return;
            if (GroupsTable.Rows[e.RowIndex] == null) return;
            var row = GroupsTable.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            switch (e.ColumnIndex)
            {
                case 0:

                    string range = cell.EditedFormattedValue as string;
                    FormMode mode;
                    if (groupOriginRow == null) mode = FormMode.Add;
                    else mode = FormMode.Edit;
                    if (!Validation.IsRangeValid(range)) e.Cancel = true;
                    if (!Validation.IsRangeUnique(range, tOOLACCOUNTINGDataSet, mode, groupOriginRow)) e.Cancel = true;

                    break;
                default:

                    if (string.IsNullOrEmpty(cell.EditedFormattedValue as string))
                    {
                        e.Cancel = true;
                        NotificationService.Notify("Предупреждение", "Это поле не может быть пустым.", ToolTipIcon.Warning);
                    }

                    break;
            }
        }
        private void GroupsTable_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (!groupUserEditing) return;
            try
            {
                groupsTableAdapter.Update(tOOLACCOUNTINGDataSet.Groups);
                groupsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Groups);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            groupUserEditing = false;
        }

        private void Groups_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(GroupsName.Text)) parameters.Add(new SearchParameter("Name", GroupsName.Text, true));
            try
            {
                string filter = Search.Filter(parameters);
                GroupsTable.SuspendLayout();
                groupsBindingSource.Filter = filter;
                GroupsTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Приобретение инструмента

        #region Заявки от цехов

        public void SetReceivingRequestButtonsState()
        {
            try
            {
                bool state = WorkshopsRequestsRequestsTable.CurrentRow != null && !string.IsNullOrEmpty(WorkshopsRequestsRequestsTable.CurrentRow.Cells[0].Value.ToString());
                //WorkshopsRequestsButtonConsider.Enabled = state;
            }
            catch { }
        }

        private void WorkshopsRequestsRequestsTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetReceivingRequestButtonsState();
        }

        private void WorkshopsRequestsButtonConsider_Click(object sender, EventArgs e)
        {
            if(WorkshopsRequestsRequestsTable.CurrentRow == null) return;
            int requestNumber = int.Parse(WorkshopsRequestsRequestsTable.CurrentRow.Cells[0].Value.ToString());
            RequestConsideration requestConsideration = new RequestConsideration(requestNumber, FormMode.Add);
            requestConsideration.ShowDialog();
        }

        private void WorkshopsRequests_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            //if (!string.IsNullOrEmpty(WorkshopsRequestsName.Text)) parameters.Add(new SearchParameter("FullName", WorkshopsRequestsName.Text, false)); //поиск по дочерней
            //if (!string.IsNullOrEmpty(WorkshopsRequestsNumber.Text)) parameters.Add(new SearchParameter("NomenclatureNumber", WorkshopsRequestsNumber.Text)); //поиск по дочерней
            if (!string.IsNullOrEmpty(WorkshopsRequestsWorkshop.Text)) parameters.Add(new SearchParameter("WorkshopNumberName", WorkshopsRequestsWorkshop.Text, false));
            if (!string.IsNullOrEmpty(WorkshopsRequestsStatus.Text)) parameters.Add(new SearchParameter("Status", WorkshopsRequestsStatus.Text));

            try
            {
                string filter = Search.Filter(parameters);
                WorkshopsRequestsRequestsTable.SuspendLayout();
                WorkshopsRequestsContentTable.SuspendLayout();
                //что тут?
                WorkshopsRequestsRequestsTable.ResumeLayout();
                WorkshopsRequestsContentTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Возможный вариант поиска
        //private void WorkshopsRequests_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Получаем DataSet/DataTable
        //        var parentTable = tOOLACCOUNTINGDataSet.ReceivingRequestsInj;
        //        var childTable = tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj;

        //        // Фильтруем дочерние записи по номеру
        //        var filteredChildRows = childTable.AsEnumerable()
        //            .Where(row => string.IsNullOrEmpty(WorkshopsRequestsNumber.Text) ||
        //                          row.Field<string>("NomenclatureNumber").Contains(WorkshopsRequestsNumber.Text));

        //        // Получаем ID родительских записей, у которых есть подходящие дочерние
        //        var validParentIds = filteredChildRows
        //            .Select(row => row.Field<int>("ReceivingRequestID"))
        //            .Distinct()
        //            .ToList();

        //        // Фильтруем родительскую таблицу
        //        var parentFilter = new StringBuilder();
        //        if (!string.IsNullOrEmpty(WorkshopsRequestsWorkshop.Text))
        //            parentFilter.Append($"WorkshopNumberName LIKE '%{WorkshopsRequestsWorkshop.Text}%' AND ");

        //        if (!string.IsNullOrEmpty(WorkshopsRequestsStatus.Text))
        //            parentFilter.Append($"Status = '{WorkshopsRequestsStatus.Text}' AND ");

        //        if (validParentIds.Any())
        //            parentFilter.Append($"ReceivingRequestID IN ({string.Join(",", validParentIds)})");
        //        else if (!string.IsNullOrEmpty(WorkshopsRequestsNumber.Text)) // Если ищем по номеру, но ничего не нашли
        //            parentFilter.Append("1=0"); // Фильтр, который ничего не вернет

        //        // Применяем фильтр к родительскому BindingSource
        //        receivingRequestsInjBindingSource.Filter = parentFilter.ToString();

        //        // Обновляем дочерний BindingSource
        //        receivingRequestsInjReceivingRequestsContentInjBindingSource.Filter =
        //            string.IsNullOrEmpty(WorkshopsRequestsNumber.Text) ? "" :
        //            $"NomenclatureNumber LIKE '%{WorkshopsRequestsNumber.Text}%'";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Ошибка фильтрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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

        #region Аналоги инструментов

        public void SetAnalogsButtonsState()
        {
            try
            {
                bool state =
                    AnalogListTable.CurrentRow != null &&
                    !string.IsNullOrEmpty(AnalogListTable.CurrentRow.Cells[0].Value.ToString()) &&
                    !AnalogListTable.CurrentRow.IsNewRow;
                AnalogButtonAlter.Enabled = state;
                AnalogButtonDelete.Enabled = state;
            }
            catch { }
        }

        private void AnalogButtonCreate_Click(object sender, EventArgs e)
        {
            AnalogForm analogForm = new AnalogForm(tOOLACCOUNTINGDataSet, analogToolsTableAdapter);
            analogForm.ShowDialog();
        }

        private void AnalogButtonAlter_Click(object sender, EventArgs e)
        {
            SetAnalogsButtonsState();
            if (AnalogListTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            var selectedRow = AnalogListTable.CurrentRow.DataBoundItem as DataRowView;
            var analogRow = selectedRow.Row as TOOLACCOUNTINGDataSet.AnalogTools1Row;
            AnalogForm analogForm = new AnalogForm(tOOLACCOUNTINGDataSet, analogToolsTableAdapter, FormMode.Edit, analogRow);
            analogForm.ShowDialog();
        }

        private void AnalogButtonDelete_Click(object sender, EventArgs e)
        {
            AnalogsDelete();
        }

        private bool AnalogsDelete()
        {
            SetAnalogsButtonsState();
            if (AnalogListTable.CurrentRow.DataBoundItem as DataRowView == null) return false;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return false;

            try
            {
                var selectedRow = AnalogListTable.CurrentRow.DataBoundItem as DataRowView;
                var analog1Row = selectedRow.Row as TOOLACCOUNTINGDataSet.AnalogTools1Row;
                var analog1RowId = analog1Row.ID;

                var analogRow = tOOLACCOUNTINGDataSet.AnalogTools.FindByID(analog1RowId);
                analogRow.Delete();
                analogToolsTableAdapter.Update(tOOLACCOUNTINGDataSet.AnalogTools);
                analogToolsTableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools);
                analogTools1TableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools1);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void AnalogListTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetAnalogsButtonsState();
        }
        private void AnalogListTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            //if (AnalogListTable.CurrentCell.ColumnIndex == 1 || AnalogListTable.CurrentCell.ColumnIndex == 2)
            //{
            if (e.Control is TextBox textBox)
            {
                textBox.KeyPress -= Digits_KeyPress;
                textBox.KeyPress += Digits_KeyPress;
            }
            //}

        }

        private void AnalogListTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!AnalogsDelete()) e.Cancel = true;
        }

        private TOOLACCOUNTINGDataSet.AnalogToolsRow analogOriginRow = null;
        private bool analogUserEditing = false;
        private void AnalogListTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            analogUserEditing = true;
            var dataRowView = AnalogListTable.Rows[e.RowIndex].DataBoundItem as DataRowView;
            analogOriginRow = dataRowView?.Row as TOOLACCOUNTINGDataSet.AnalogToolsRow;
        }

        private void AnalogListTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!analogUserEditing) return;
            if (AnalogListTable.Rows[e.RowIndex] == null) return;
            var row = AnalogListTable.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            switch (e.ColumnIndex)
            {
                case 1:
                case 2:

                    string nomenclatureNumber = cell.EditedFormattedValue as string;
                    //FormMode mode;
                    //if (analogOriginRow == null) mode = FormMode.Add;
                    //else mode = FormMode.Edit;
                    string originalNum = row.Cells[1].Value?.ToString();
                    string analogNum = row.Cells[2].Value?.ToString();
                    if (!Validation.IsNomenclatureNumberCorrect(nomenclatureNumber)) e.Cancel = true;
                    if (!Validation.IsNomenclatureNumberValid(nomenclatureNumber, tOOLACCOUNTINGDataSet)) e.Cancel = true;
                    if (!Validation.IsNomenclatureNumberExist(nomenclatureNumber, tOOLACCOUNTINGDataSet)) e.Cancel = true;
                    //if (originalNum == analogNum && (!string.IsNullOrEmpty(originalNum) || !string.IsNullOrEmpty(analogNum)))
                    //{
                    //    MessageBox.Show("Номенклатурные номера основного и аналогичного инструмента не могут совпадать.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    e.Cancel = true;
                    //}

                    //bool exists = false;
                    //if (mode == FormMode.Add)
                    //{
                    //    exists = tOOLACCOUNTINGDataSet.AnalogTools
                    //        .Any(r =>
                    //        r.OriginalNomenclatureNumber == originalNum &&
                    //        r.AnalogNomenclatureNumber == analogNum);
                    //}
                    //if (mode == FormMode.Edit)
                    //{
                    //    exists = tOOLACCOUNTINGDataSet.AnalogTools
                    //        .Any(r =>
                    //        r.OriginalNomenclatureNumber == originalNum &&
                    //        r.AnalogNomenclatureNumber == analogNum &&
                    //        r.ID != analogOriginRow.ID);
                    //}
                    //if (exists)
                    //{
                    //    e.Cancel = true;
                    //    MessageBox.Show("Такая пара аналогов уже существует.", "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //}

                    break;
                default: break;
            }
        }

        private void AnalogListTable_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            analogUserEditing = false;
        }

        private void AnalogListTable_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!analogUserEditing /*|| e.RowIndex < 0*/) return;

            DataGridViewRow row = null;
            try
            {
                row = AnalogListTable.Rows[e.RowIndex];
                string originalNum = row.Cells[1].Value?.ToString();
                string analogNum = row.Cells[2].Value?.ToString();

                if (string.IsNullOrEmpty(originalNum) ||
                    string.IsNullOrEmpty(analogNum)) return;

                if (originalNum == analogNum) throw new Exception("Номенклатурные номера основного и аналогичного инструмента не могут совпадать.");


                DataRowView rowView = row.DataBoundItem as DataRowView;
                var analogTools1Row = rowView.Row as TOOLACCOUNTINGDataSet.AnalogTools1Row;
                int relationId = analogTools1Row.ID;
                var analogToolsRow = tOOLACCOUNTINGDataSet.AnalogTools.FindByID(relationId);

                if (analogToolsRow != null)
                {
                    bool exists = tOOLACCOUNTINGDataSet.AnalogTools
                        .Any(r =>
                        r.OriginalNomenclatureNumber == originalNum &&
                        r.AnalogNomenclatureNumber == analogNum &&
                        r.ID != relationId);

                    if (exists)
                    {
                        throw new Exception("Такая пара аналогов уже существует.");
                    }

                    analogToolsRow.BeginEdit();
                    analogToolsRow.OriginalNomenclatureNumber = originalNum;
                    analogToolsRow.AnalogNomenclatureNumber = analogNum;
                    analogToolsRow.EndEdit();
                }
                else
                {
                    bool exists = tOOLACCOUNTINGDataSet.AnalogTools
                        .Any(r =>
                        r.OriginalNomenclatureNumber == originalNum &&
                        r.AnalogNomenclatureNumber == analogNum);

                    if (exists)
                    {
                        throw new Exception("Такая пара аналогов уже существует.");
                    }

                    var newRow = tOOLACCOUNTINGDataSet.AnalogTools.NewAnalogToolsRow();
                    newRow.OriginalNomenclatureNumber = originalNum;
                    newRow.AnalogNomenclatureNumber = analogNum;
                    tOOLACCOUNTINGDataSet.AnalogTools.Rows.Add(newRow);
                }
                analogToolsTableAdapter.Update(tOOLACCOUNTINGDataSet.AnalogTools);
                analogToolsTableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools);
                analogTools1TableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools1);
                dataTable1TableAdapter.Fill(tOOLACCOUNTINGDataSet.DataTable1);

            }
            catch (Exception ex)
            {
                e.Cancel = true;
                //tOOLACCOUNTINGDataSet.AnalogTools.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //finally
            //{
            //    //analogUserEditing = false;
            //    //e.Cancel = true;
            //}
        }

        private void Analog_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(AnalogMainNumber.Text)) parameters.Add(new SearchParameter("OriginalNomenclatureNumber", AnalogMainNumber.Text, true));
            if (!string.IsNullOrEmpty(AnalogAnalogNumber.Text)) parameters.Add(new SearchParameter("AnalogNomenclatureNumber", AnalogAnalogNumber.Text, true));
            if (!string.IsNullOrEmpty(AnalogMainName.Text)) parameters.Add(new SearchParameter("OriginalFullName", AnalogMainName.Text, true));
            if (!string.IsNullOrEmpty(AnalogMainName.Text)) parameters.Add(new SearchParameter("AnalogFullName", AnalogAnalogName.Text, true));
            //at.ID, at.OriginalNomenclatureNumber, n1.FullName AS OriginalFullName, at.AnalogNomenclatureNumber, n2.FullName AS AnalogFullName
            try
            {
                string filter = Search.Filter(parameters);
                AnalogListTable.SuspendLayout();
                //AnalogCompareTable.SuspendLayout();
                analogTools1BindingSource.Filter = filter;
                AnalogListTable.ResumeLayout();
                //AnalogCompareTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
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
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return false;

            try
            {
                var selectedRow = ProvidersTable.CurrentRow.DataBoundItem as DataRowView;
                var supplierRow = selectedRow.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
                supplierRow.Delete();
                suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
                suppliersTableAdapter.Fill(tOOLACCOUNTINGDataSet.Suppliers);
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
                    textBox.KeyPress -= Digits_KeyPress;
                    textBox.KeyPress += Digits_KeyPress;
                }
            }
            else
            {
                if (e.Control is TextBox textBox) textBox.KeyPress -= Digits_KeyPress;
            }

        }

        private void ProvidersTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!ProvidersDelete()) e.Cancel = true;
        }

        private TOOLACCOUNTINGDataSet.SuppliersRow supplierOriginRow = null;
        private bool supplierUserEditing = false;

        private void ProvidersTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            supplierUserEditing = true;
            var dataRowView = ProvidersTable.Rows[e.RowIndex].DataBoundItem as DataRowView;
            supplierOriginRow = dataRowView?.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
        }

        private void ProvidersTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!supplierUserEditing) return;
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
                    if (supplierOriginRow == null) mode = FormMode.Add;
                    else mode = FormMode.Edit;
                    if (!Validation.IsINNValid(inn)) e.Cancel = true;
                    if (!Validation.IsINNUnique(inn, tOOLACCOUNTINGDataSet, mode, supplierOriginRow)) e.Cancel = true;

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
            if (!supplierUserEditing) return;
            try
            {
                suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
                suppliersTableAdapter.Fill(tOOLACCOUNTINGDataSet.Suppliers);
                supplierUserEditing = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion

        #region Логи корректировок

        private void AddLogs(NomenclatureRow row)
        {
            for (int i = 1; i < row.Table.Columns.Count; i++)
            {
                if (string.IsNullOrEmpty(row[i].ToString())) continue;
                var log = tOOLACCOUNTINGDataSet.NomenclatureLogs.NewNomenclatureLogsRow();
                log.NomenclatureNumber = row.NomenclatureNumber;

                string columnName = row.Table.Columns[i].ColumnName;
                string columnHeader = Logs.FieldName(columnName);
                if (columnHeader == null) continue;
                log.FieldName = columnHeader;
                log.OldValue = null;
                log.NewValue = row[i].ToString();
                log.ChangedDate = DateTime.Now;
                log.Executor = Environment.UserName;

                tOOLACCOUNTINGDataSet.NomenclatureLogs.Rows.Add(log);
            }
        }

        private void AlterLogs(NomenclatureRow oldRow, NomenclatureViewRow newViewRow)
        {
            TOOLACCOUNTINGDataSet.NomenclatureRow newRow = tOOLACCOUNTINGDataSet.Nomenclature.NewNomenclatureRow();
            newRow.NomenclatureNumber = newViewRow.NomenclatureNumber;
            NomenFillFields(newRow, newViewRow);
            for (int i = 1; i < newRow.Table.Columns.Count; i++)
            {
                if (oldRow[i].ToString() == newRow[i].ToString()) continue;
                var log = tOOLACCOUNTINGDataSet.NomenclatureLogs.NewNomenclatureLogsRow();
                log.NomenclatureNumber = newRow.NomenclatureNumber;

                string columnName = newRow.Table.Columns[i].ColumnName;
                string columnHeader = Logs.FieldName(columnName);
                if (columnHeader == null) continue;
                log.FieldName = columnHeader;
                log.OldValue = oldRow[i].ToString();
                log.NewValue = newRow[i].ToString();
                log.ChangedDate = DateTime.Now;
                log.Executor = Environment.UserName;

                tOOLACCOUNTINGDataSet.NomenclatureLogs.Rows.Add(log);
            }
        }

        private void DeleteLogs(NomenclatureRow row)
        {
            for (int i = 1; i < row.Table.Columns.Count; i++)
            {
                if (string.IsNullOrEmpty(row[i].ToString())) continue;
                var log = tOOLACCOUNTINGDataSet.NomenclatureLogs.NewNomenclatureLogsRow();
                log.NomenclatureNumber = row.NomenclatureNumber;

                string columnName = row.Table.Columns[i].ColumnName;
                string columnHeader = Logs.FieldName(columnName);
                if (columnHeader == null) continue;
                log.FieldName = columnHeader;
                log.OldValue = row[i].ToString();
                log.NewValue = null;
                log.ChangedDate = DateTime.Now;
                log.Executor = Environment.UserName;

                tOOLACCOUNTINGDataSet.NomenclatureLogs.Rows.Add(log);
            }
        }


        private void Log_TextChanged(object sender, EventArgs e)
        {
            LogSearch();
        }


        private void Log_ValueChanged(object sender, EventArgs e)
        {
            LogSearch();
        }

        private void LogSearch()
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(LogNumber.Text)) parameters.Add(new SearchParameter("NomenclatureNumber", LogNumber.Text));
            if (!string.IsNullOrEmpty(LogField.Text)) parameters.Add(new SearchParameter("FieldName", LogField.Text));
            if (!string.IsNullOrEmpty(LogUser.Text)) parameters.Add(new SearchParameter("Executor", LogUser.Text));

            try
            {
                string filter = Search.Filter(parameters);

                if (!string.IsNullOrEmpty(LogValue.Text))
                {
                    if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                    filter += $"(OldValue LIKE '{LogValue.Text}%' OR NewValue LIKE '{LogValue.Text}%')";
                }

                string date1 = $"{LogStart.Value.ToString("yyyy-MM-dd")}";
                string date2 = $"{LogEnd.Value.AddDays(1).ToString("yyyy-MM-dd")}";
                if (!string.IsNullOrEmpty(date1) && !string.IsNullOrEmpty(date2))
                {
                    if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                    filter += $"ChangedDate >= '{date1}' AND ChangedDate <'{date2}'";
                }

                LogTable.SuspendLayout();
                nomenclatureLogsBindingSource.Filter = filter;
                LogTable.Columns[0].Visible = false;
                //MessageBox.Show(filter);
                LogTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Остатки номенклатуры

        #endregion

        //private void maskedTextBox_Enter(object sender, EventArgs e)
        //{
        //    MaskedTextBox maskedTextBox = sender as MaskedTextBox;
        //    maskedTextBox.SelectionStart = 0;
        //    maskedTextBox.SelectionLength = 0;
        //}
        private void Digits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }
    }
    public static class Logs
    {
        public static string FieldName(string columnName)
        {
            string columnHeader = null;
            switch (columnName)
            {
                case "Designation": columnHeader = "Обозначение"; break;
                case "Unit": columnHeader = "Единицы измерения"; break;
                case "Dimensions": columnHeader = "Типоразмеры"; break;
                case "CuttingMaterial": columnHeader = "Материал режущей части"; break;
                case "RegulatoryDoc": columnHeader = "Нормативная документация"; break;
                case "Producer": columnHeader = "Производитель"; break;
                case "UsageFlag": columnHeader = "Признак использования"; break;
                case "MinStock": columnHeader = "Неснижаемый остаток"; break;
            }
            return columnHeader;
        }
    }
}
