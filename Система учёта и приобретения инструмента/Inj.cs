//using Microsoft.Office.Interop.Excel;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
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
           // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.BalancesInj". При необходимости она может быть перемещена или удалена.
            this.balancesInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.BalancesInj);
            OstatkiTable.Columns[0].Visible = false;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);
            ReceivingRequestsContentTable.Columns[0].Visible = false;
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

            ReceivingRequestsResetStatus();
            //Установка дат во вкладках с диапазоном
            PurchaseRequestsResetStart();
            PurchaseRequestsResetEnd();
            HistoryResetStart();
            HistoryResetEnd();
            LogResetStart();
            LogResetEnd();
        }
        private bool isSearchReseting = false;

        private void InjLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void AnalogListTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !NomenTable.Rows[e.RowIndex].IsNewRow)
        //        {
        //            AnalogListTable.Rows[e.RowIndex].Selected = true;
        //            SetAnalogContextMenuItems(true);
        //        }
        //        else SetAnalogContextMenuItems(false);
        //        AnalogsTableContextMenu.Show(Cursor.Position);
        //    }
        //}
        //private void SetAnalogContextMenuItems(bool isRow)
        //{
        //    AnalogsTableContextMenuAlter.Visible = isRow;
        //    AnalogsTableContextMenuDelete.Visible = isRow;
        //}

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
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            NomenDelete();
            e.Cancel = true;
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
            if (isSearchReseting) return;
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
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void NomenButtonResetSearch_Click(object sender, EventArgs e)
        {
            NomenResetSearch();
        }

        private void NomenTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !NomenTable.Rows[e.RowIndex].IsNewRow)
                {
                    //NomenTable.ClearSelection();
                    NomenTable.Rows[e.RowIndex].Selected = true;
                    SetNomenContextMenuItems(true);
                }
                else SetNomenContextMenuItems(false);
                NomenTableContextMenu.Show(Cursor.Position);
            }
        }
        private void SetNomenContextMenuItems(bool isRow)
        {
            NomenTableContexMenuAlter.Visible = isRow;
            NomenTableContexMenuDelete.Visible = isRow;
            NomenTableContexMenuSeparator1.Visible = isRow;
            NomenTableContexMenuOstatki.Visible = isRow;
            NomenTableContexMenuHistory.Visible = isRow;
            NomenTableContexMenuLogs.Visible = isRow;
            NomenTableContexMenuSeparator2.Visible = isRow;
            NomenTableContexMenuFindAnalogs.Visible = isRow;
            NomenTableContexMenuAddAnalog.Visible = isRow;
        }
        private void NomenTableContexMenuCreate_Click(object sender, EventArgs e)
        {
            NomenButtonCreate.PerformClick();
        }

        private void NomenTableContexMenuAlter_Click(object sender, EventArgs e)
        {
            NomenButtonAlter.PerformClick();
        }

        private void NomenTableContexMenuDelete_Click(object sender, EventArgs e)
        {
            NomenButtonDelete.PerformClick();
        }

        private void NomenTableContexMenuOstatki_Click(object sender, EventArgs e)
        {
            NomenButtonOstatki.PerformClick();
        }

        private void NomenTableContexMenuHistory_Click(object sender, EventArgs e)
        {
            NomenButtonHistory.PerformClick();
        }

        private void NomenTableContexMenuLogs_Click(object sender, EventArgs e)
        {
            NomenButtonLog.PerformClick();
        }

        private void NomenTableContexMenuFindAnalogs_Click(object sender, EventArgs e)
        {
            SetNomenButtonsState();
            if (NomenTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            AnalogMainNumber.Text = NomenTable.CurrentRow.Cells[0].Value.ToString();
            InjLevel1.SelectedTab = InjAnalogPage;
        }

        private void NomenTableContexMenuAddAnalog_Click(object sender, EventArgs e)
        {
            if (NomenTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            AnalogForm analogForm = new AnalogForm(tOOLACCOUNTINGDataSet, analogToolsTableAdapter);
            analogForm.AnalogFormOrigiinalName.Text = NomenTable.CurrentRow.Cells[8].Value.ToString().Trim();
            analogForm.AnalogFormOrigiinalNumber.Text = NomenTable.CurrentRow.Cells[0].Value.ToString().Trim();
            analogForm.AnalogFormAnalogName.TabIndex = 0;
            analogForm.ShowDialog();
        }
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
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            AnalogsDelete();
            e.Cancel = true;
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
            if (isSearchReseting) return;
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
                AnalogListTable.Columns[0].Visible = false;
                AnalogListTable.ResumeLayout();
                //AnalogCompareTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void AnalogButtonResetSearch_Click(object sender, EventArgs e)
        {
            AnalogsResetSearch();
        }
        private void AnalogListTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !AnalogListTable.Rows[e.RowIndex].IsNewRow)
                {
                    AnalogListTable.Rows[e.RowIndex].Selected = true;
                    SetAnalogContextMenuItems(true);
                }
                else SetAnalogContextMenuItems(false);
                AnalogsTableContextMenu.Show(Cursor.Position);
            }
        }
        private void SetAnalogContextMenuItems(bool isRow)
        {
            AnalogsTableContextMenuAlter.Visible = isRow;
            AnalogsTableContextMenuDelete.Visible = isRow;
        }
        private void AnalogsTableContextMenuCreate_Click(object sender, EventArgs e)
        {
            AnalogButtonCreate.PerformClick();
        }
        private void AnalogsTableContextMenuAlter_Click(object sender, EventArgs e)
        {
            AnalogButtonAlter.PerformClick();
        }
        private void AnalogsTableContextMenuDelete_Click(object sender, EventArgs e)
        {
            AnalogButtonDelete.PerformClick();
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

                if (tOOLACCOUNTINGDataSet.Nomenclature.Any(n => n.NomenclatureNumber.Substring(0, 4) == groupRow.RangeStart)) throw new Exception("Невозможно удалить эту группу, так к ней как привязаны инструменты.");

                groupRow.Delete();
                groupsTableAdapter.Update(tOOLACCOUNTINGDataSet.Groups);
                groupsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Groups);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            GroupsDelete();
            e.Cancel = true;
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
            if (isSearchReseting) return;
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
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void GroupsButtonResetSearch_Click(object sender, EventArgs e)
        {
            GroupsResetSearch();
        }
        private void GroupsTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !GroupsTable.Rows[e.RowIndex].IsNewRow)
                {
                    //NomenTable.ClearSelection();
                    GroupsTable.Rows[e.RowIndex].Selected = true;
                    SetGroupContextMenuItems(true);
                }
                else SetGroupContextMenuItems(false);
                GroupsTableContextMenu.Show(Cursor.Position);
            }
        }
        private void SetGroupContextMenuItems(bool isRow)
        {
            GroupTableContextMenuAlter.Visible = isRow;
            GroupTableContextMenuDelete.Visible = isRow;
            GroupTableContextMenuSeparator.Visible = isRow;
            GroupTableContextMenuFindNomen.Visible = isRow;
            GroupTableContextMenuAddNomen.Visible = isRow;
        }
        private void GroupTableContextMenuCreate_Click(object sender, EventArgs e)
        {
            GroupsButtonCreate.PerformClick();
        }
        private void GroupTableContextMenuAlter_Click(object sender, EventArgs e)
        {
            GroupsButtonAlter.PerformClick();
        }
        private void GroupTableContextMenuDelete_Click(object sender, EventArgs e)
        {
            GroupsButtonDelete.PerformClick();
        }
        private void GroupTableContextMenuFindNomen_Click(object sender, EventArgs e)
        {
            if (GroupsTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            NomenName.Text = GroupsTable.CurrentRow.Cells[1].Value.ToString();
            InjLevel1.SelectedTab = InjNomenPage;
        }
        private void GroupTableContextMenuAddNomen_Click(object sender, EventArgs e)
        {
            if (GroupsTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            NomenForm nomenForm = new NomenForm(tOOLACCOUNTINGDataSet, nomenclatureTableAdapter);
            nomenForm.NomenFormGroup.Text = GroupsTable.CurrentRow.Cells[1].Value.ToString().Trim();
            nomenForm.ShowDialog();
            //NomenForm analogForm = new NomenForm(tOOLACCOUNTINGDataSet, );
            //analogForm.AnalogFormOrigiinalName.Text = NomenTable.CurrentRow.Cells[8].Value.ToString().Trim();
            //analogForm.AnalogFormOrigiinalNumber.Text = NomenTable.CurrentRow.Cells[0].Value.ToString().Trim();
            //analogForm.AnalogFormAnalogName.TabIndex = 0;
            //analogForm.ShowDialog();
        }
        #endregion

        #region Приобретение инструмента

        #region Заявки от цехов

        public void SetReceivingRequestsButtonsState()
        {
            try
            {
                //bool state = ReceivingRequestsRequestsTable.CurrentRow != null && !string.IsNullOrEmpty(ReceivingRequestsRequestsTable.CurrentRow.Cells[0].Value.ToString());
                if (ReceivingRequestsRequestsTable.CurrentRow == null)
                {
                    ReceivingRequestsButtonConsider.Enabled = false;
                    ReceivingRequestsButtonAlter.Enabled = false;
                    ReceivingRequestsButtonDelete.Enabled = false;
                    return;
                }

                string status = ReceivingRequestsRequestsTable.CurrentRow.Cells[6].Value.ToString();
                if (status == "Не обработана" || status == "В работе")
                {
                    if (status == "Не обработана")
                    {
                        ReceivingRequestsButtonConsider.Enabled = true;
                        ReceivingRequestsButtonAlter.Enabled = false;
                        ReceivingRequestsButtonDelete.Enabled = false;
                    }
                    else
                    {
                        ReceivingRequestsButtonConsider.Enabled = false;
                        ReceivingRequestsButtonAlter.Enabled = true;
                        ReceivingRequestsButtonDelete.Enabled = true;
                    }
                }
                else
                {
                    ReceivingRequestsButtonConsider.Enabled = false;
                    ReceivingRequestsButtonAlter.Enabled = false;
                    ReceivingRequestsButtonDelete.Enabled = false;
                }
            }
            catch { }
        }

        private void ReceivingRequestsRequestsTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetReceivingRequestsButtonsState();
        }

        private void ReceivingRequestsButtonConsider_Click_1(object sender, EventArgs e)
        {
            if (ReceivingRequestsRequestsTable.CurrentRow == null) return;
            int requestNumber = int.Parse(ReceivingRequestsRequestsTable.CurrentRow.Cells[0].Value.ToString());
            RequestConsideration requestConsideration = new RequestConsideration(requestNumber, FormMode.Add);
            requestConsideration.ShowDialog();
            receivingRequestsInjTableAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsInj);
        }

        private void ReceivingRequestsButtonAlter_Click(object sender, EventArgs e)
        {
            //add
        }

        private void ReceivingRequestsButtonDelete_Click(object sender, EventArgs e)
        {
            //add
        }

        private void ReceivingRequests_TextChanged(object sender, EventArgs e)
        {
            if (isSearchReseting) return;
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(ReceivingRequestsWorkshop.Text)) parameters.Add(new SearchParameter("WorkshopNumberName", ReceivingRequestsWorkshop.Text, false));
            if (!string.IsNullOrEmpty(ReceivingRequestsStatus.Text) && ReceivingRequestsStatus.SelectedIndex > 0) parameters.Add(new SearchParameter("Status", ReceivingRequestsStatus.Text));
            if (!ReceivingRequestsAll.Checked) parameters.Add(new SearchParameter("ReceivingRequestType", ReceivingRequestsSearchType()));

            try
            {
                string filter = Search.Filter(parameters);
                ReceivingRequestsRequestsTable.SuspendLayout();
                ReceivingRequestsContentTable.SuspendLayout();
                receivingRequestsInjBindingSource.Filter = filter;
                ReceivingRequestsContentTable.Columns[0].Visible = false;
                ReceivingRequestsRequestsTable.ResumeLayout();
                ReceivingRequestsContentTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string ReceivingRequestsSearchType()
        {
            string type = "Плановая";
            if (ReceivingRequestsOutPlanned.Checked) type = "Внеплановая";
            return type;
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
        //        MessageBox.Show(ex.Message, "Ошибка фильтрации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        private void ReceivingRequestsButtonResetSearch_Click(object sender, EventArgs e)
        {
            ReceivingRequestsResetSearch();
        }
        private void ReceivingRequestsRequestsTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !ReceivingRequestsRequestsTable.Rows[e.RowIndex].IsNewRow)
                {
                    ReceivingRequestsRequestsTable.Rows[e.RowIndex].Selected = true;
                    SetReceivingRequestsContextMenuItems(true);
                }
                else SetReceivingRequestsContextMenuItems(false);
                ReceivingRequestsContextMenu.Show(Cursor.Position);
            }
        }
        private void SetReceivingRequestsContextMenuItems(bool isRow)
        {
            ReceivingRequestsContextMenuConsider.Visible = isRow;
            ReceivingRequestsContextMenuAlter.Visible = isRow;
            ReceivingRequestsContextMenuCancel.Visible = isRow;
        }
        private void ReceivingRequestsContextMenuConsider_Click(object sender, EventArgs e)
        {
            ReceivingRequestsButtonConsider.PerformClick();
        }
        private void ReceivingRequestsContextMenuAlter_Click(object sender, EventArgs e)
        {
            ReceivingRequestsButtonAlter.PerformClick();
        }
        private void ReceivingRequestsContextMenuCancel_Click(object sender, EventArgs e)
        {
            ReceivingRequestsButtonDelete.PerformClick();
        }
        #endregion

        #region Заявки на приобретение


        private void PurchaseRequestsButtonResetSearch_Click(object sender, EventArgs e)
        {
            PurchaseRequestsResetSearch();
        }
        private void PurchaseRequestsPurchaseRequestsTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !PurchaseRequestsPurchaseRequestsTable.Rows[e.RowIndex].IsNewRow)
                {
                    PurchaseRequestsPurchaseRequestsTable.Rows[e.RowIndex].Selected = true;
                    SetPurchaseRequestsContextMenuItems(true);
                }
                else SetPurchaseRequestsContextMenuItems(false);
                PurchaseRequestsContextMenu.Show(Cursor.Position);
            }
        }
        private void SetPurchaseRequestsContextMenuItems(bool isRow)
        {
            PurchaseRequestsContextMenuAlter.Visible = isRow;
            PurchaseRequestsContextMenuDelete.Visible = isRow;
            PurchaseRequestsContextMenuSeparator.Visible = isRow;
            PurchaseRequestsContextMenuExport.Visible = isRow;
        }

        private void PurchaseRequestsContextMenuCreate_Click(object sender, EventArgs e)
        {
            PurchaseRequestsButtonCreate.PerformClick();
        }
        private void PurchaseRequestsContextMenuAlter_Click(object sender, EventArgs e)
        {
            PurchaseRequestsButtonAlter.PerformClick();
        }
        private void PurchaseRequestsContextMenuDelete_Click(object sender, EventArgs e)
        {
            PurchaseRequestsButtonDelete.PerformClick();
        }
        private void PurchaseRequestsContextMenuExport_Click(object sender, EventArgs e)
        {
            PurchaseRequestsButtonExport.PerformClick();
        }
        #endregion

        #region Ведомости поставки
        private void StatementsButtonResetSearch_Click(object sender, EventArgs e)
        {
            StatementsResetSearch();
        }
        private void StatementsStatementsTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !StatementsStatementsTable.Rows[e.RowIndex].IsNewRow)
                {
                    StatementsStatementsTable.Rows[e.RowIndex].Selected = true;
                    SetStatementsTableContextMenuItems(true);
                }
                else SetStatementsTableContextMenuItems(false);
                StatementsTableContextMenu.Show(Cursor.Position);
            }
        }

        private void StatementsButtonCreate_Click(object sender, EventArgs e)
        {

        }

        private void StatementsButtonAlter_Click(object sender, EventArgs e)
        {

        }

        private void StatementsButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void SetStatementsTableContextMenuItems(bool isRow)
        {
            StatementsTableContextMenuAlter.Visible = isRow;
            StatementsTableContextMenuDelete.Visible = isRow;
            StatementsTableContextMenuSeparator.Visible = isRow;
            StatementsTableContextMenuExport.Visible = isRow;
        }
        private void StatementsTableContextMenuCreate_Click(object sender, EventArgs e)
        {
            StatementsButtonCreate.PerformClick();
        }
        private void StatementsTableContextMenuAlter_Click(object sender, EventArgs e)
        {
            StatementsButtonAlter.PerformClick();
        }
        private void StatementsTableContextMenuDelete_Click(object sender, EventArgs e)
        {
            StatementsButtonDelete.PerformClick();
        }
        private void StatementsTableContextMenuExport_Click(object sender, EventArgs e)
        {
            StatementsButtonExport.PerformClick();
        }
        #endregion

        #region Товарные накладные
        private void InvoicesButtonResetSearch_Click(object sender, EventArgs e)
        {
            InvoicesResetSearch();
        }
        private void InvoicesInvoicesTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !InvoicesInvoicesTable.Rows[e.RowIndex].IsNewRow)
                {
                    InvoicesInvoicesTable.Rows[e.RowIndex].Selected = true;
                    SetInvoicesContextMenuItems(true);
                }
                else SetInvoicesContextMenuItems(false);
                InvoicesTableContextMenu.Show(Cursor.Position);
            }
        }
        private void SetInvoicesContextMenuItems(bool isRow)
        {
            InvoicesTableContextMenuAlter.Visible = isRow;
            InvoicesTableContextMenuDelete.Visible = isRow;
            //InvoicesTableContextMenuSeparator.Visible = isRow;
            //InvoicesTableContextMenuExport.Visible = isRow;
        }
        private void InvoicesTableContextMenuCreate_Click(object sender, EventArgs e)
        {
            InvoicesButtonEnter.PerformClick();
        }
        private void InvoicesTableContextMenuAlter_Click(object sender, EventArgs e)
        {
            InvoicesButtonAlter.PerformClick();
        }
        private void InvoicesTableContextMenuDelete_Click(object sender, EventArgs e)
        {
            InvoicesButtonDelete.PerformClick();
        }
        #endregion

        #region История поступлений


        private void HistoryButtonResetSearch_Click(object sender, EventArgs e)
        {
            HistoryResetSearch();
        }


        //private void PurchaseRequestsResetStart() { PurchaseRequestsStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); PurchaseRequestsStart.Checked = false; }
        //private void PurchaseRequestsResetEnd() { PurchaseRequestsEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddMilliseconds(-1); PurchaseRequestsEnd.Checked = false; }
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
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void ProvidersTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetProvidersButtonsState();
        }
        private void SuppliersTextChanged(object sender, EventArgs e)
        {
            if (isSearchReseting) return;
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
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            ProvidersDelete();
            e.Cancel = true;
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
        private void ProvidersButtonReserSearch_Click(object sender, EventArgs e)
        {
            ProvidersResetSearch();
        }
        private void ProvidersTable_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && !ProvidersTable.Rows[e.RowIndex].IsNewRow)
                {
                    ProvidersTable.Rows[e.RowIndex].Selected = true;
                    SetProvidersContextMenuItems(true);
                }
                else SetProvidersContextMenuItems(false);
                ProvidersTableContextMenu.Show(Cursor.Position);
            }
        }
        private void SetProvidersContextMenuItems(bool isRow)
        {
            ProvidersTableContextMenuAlter.Visible = isRow;
            ProvidersTableContextMenuDelete.Visible = isRow;
            ProvidersTableContextMenuSeparator.Visible = isRow;
            ProvidersTableContextMenuCreateStatement.Visible = isRow;
        }
        private void ProvidersTableContextMenuCreate_Click(object sender, EventArgs e)
        {
            ProvidersButtonCreate.PerformClick();
        }
        private void ProvidersTableContextMenuAlter_Click(object sender, EventArgs e)
        {
            ProvidersButtonAlter.PerformClick();
        }
        private void ProvidersTableContextMenuDelete_Click(object sender, EventArgs e)
        {
            ProvidersButtonDelete.PerformClick();
        }
        private void ProvidersTableContextMenuCreateStatement_Click(object sender, EventArgs e)
        {
            //fill
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
            if (isSearchReseting) return;
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
                if (LogStart.Checked)
                {
                    if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                    filter += $"ChangedDate >= '{date1}'";
                }
                if (LogEnd.Checked)
                {
                    if (!string.IsNullOrEmpty(filter)) filter += " AND ";
                    filter += $"ChangedDate <'{date2}'";
                }

                LogTable.SuspendLayout();
                nomenclatureLogsBindingSource.Filter = filter;
                LogTable.Columns[0].Visible = false;
                //MessageBox.Show(filter);
                LogTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LogButtonResetSearch_Click(object sender, EventArgs e)
        {
            LogResetSearch();
        }
        #endregion

        #region Остатки номенклатуры

        private void Ostatki_TextChanged(object sender, EventArgs e)
        {
            if (isSearchReseting) return;
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(OstatkiNumber.Text)) parameters.Add(new SearchParameter("NomenclatureNumber", OstatkiNumber.Text));
            try
            {
                string filter = Search.Filter(parameters);
                balancesInjBindingSource.Filter = filter;
                OstatkiTable.Columns[0].Visible = false;
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OstatkiPrice_CheckedChanged(object sender, EventArgs e)
        {
            if(OstatkiPrice.Checked) OstatkiTable.Columns[5].Visible = true;
                else OstatkiTable.Columns[5].Visible = false;
        }

        private void OstatkiButtonResetSearch_Click(object sender, EventArgs e)
        {
            OstatkiResetSearch();
        }


        #endregion

        //private void maskedTextBox_Enter(object sender, EventArgs e)
        //{
        //    MaskedTextBox maskedTextBox = sender as MaskedTextBox;
        //    maskedTextBox.SelectionStart = 0;
        //    maskedTextBox.SelectionLength = 0;
        //}

        #region Сброс поиска

        private void NomenResetSearch()
        {
            isSearchReseting = true;
            NomenResetSearchNumber();
            NomenResetSearchName();
            NomenResetSearchSize();
            NomenResetSearchMaterial();
            NomenResetSearchProducer();
            NomenResetSearchUsage();
            isSearchReseting = false;
            nomenclatureViewBindingSource.RemoveFilter();
        }
        private void NomenResetSearchNumber() { NomenNumber.Text = string.Empty; }
        private void NomenResetSearchName() { NomenName.Text = string.Empty; }
        private void NomenResetSearchSize() { NomenSize.Text = string.Empty; }
        private void NomenResetSearchMaterial() { NomenMaterial.Text = string.Empty; }
        private void NomenResetSearchProducer() { NomenProducer.Text = string.Empty; }
        private void NomenResetSearchUsage() { NomenUsage.SelectedIndex = 0; }

        private void GroupsResetSearch()
        {
            isSearchReseting = true;
            GroupsResetName();
            isSearchReseting = false;
            groupsBindingSource.RemoveFilter();
        }
        private void GroupsResetName() { GroupsName.Text = string.Empty; }

        private void ReceivingRequestsResetSearch()
        {
            isSearchReseting = true;
            ReceivingRequestsResetWorkshop();
            ReceivingRequestsResetStatus();
            ReceivingRequestsResetType();
            isSearchReseting = false;
            receivingRequestsInjBindingSource.RemoveFilter();
        }
        private void ReceivingRequestsResetWorkshop() { ReceivingRequestsWorkshop.Text = string.Empty; }
        private void ReceivingRequestsResetStatus() { ReceivingRequestsStatus.SelectedIndex = 1; }
        private void ReceivingRequestsResetType() { ReceivingRequestsAll.Checked = true; }
        //remove filter #fix
        private void PurchaseRequestsResetSearch()
        {
            isSearchReseting = true;
            PurchaseRequestsResetStart();
            PurchaseRequestsResetEnd();
            PurchaseRequestsResetStatus();
            isSearchReseting = false;
        }
        private void PurchaseRequestsResetStart() { PurchaseRequestsStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); PurchaseRequestsStart.Checked = false; }
        private void PurchaseRequestsResetEnd() { PurchaseRequestsEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddMilliseconds(-1); PurchaseRequestsEnd.Checked = false; }
        private void PurchaseRequestsResetStatus() { PurchaseRequestsStatus.Text = string.Empty; }
        //remove filter #fix
        private void StatementsResetSearch()
        {
            isSearchReseting = true;
            StatementsResetName();
            StatementsResetDate();
            isSearchReseting = false;
        }
        private void StatementsResetName() { StatementsProvider.Text = string.Empty; }
        private void StatementsResetDate() { StatementsDate.Value = DateTime.Today; StatementsDate.Checked = false; }
        //remove filter #fix
        private void InvoicesResetSearch()
        {
            isSearchReseting = true;
            InvoicesResetDate();
            isSearchReseting = false;
        }
        private void InvoicesResetDate() { InvoicesDate.Value = DateTime.Today; InvoicesDate.Checked = false; }
        //remove filter #fix
        private void HistoryResetSearch()
        {
            isSearchReseting = true;
            HistoryResetStart();
            HistoryResetEnd();
            HistoryResetNumber();
            isSearchReseting = false;
        }
        private void HistoryResetStart() { HistoryStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); HistoryStart.Checked = false; }
        private void HistoryResetEnd() { HistoryEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddMilliseconds(-1); HistoryEnd.Checked = false; }
        private void HistoryResetNumber() { HistoryNumber.Text = string.Empty; }

        private void AnalogsResetSearch()
        {
            isSearchReseting = true;
            AnalogsResetMainName();
            AnalogsResetMainNumber();
            AnalogsResetAnalogName();
            AnalogsResetAnalogNumber();
            isSearchReseting = false;
            analogTools1BindingSource.RemoveFilter();
            AnalogListTable.Columns[0].Visible = false;
        }
        private void AnalogsResetMainName() { AnalogMainName.Text = string.Empty; }
        private void AnalogsResetMainNumber() { AnalogMainNumber.Text = string.Empty; }
        private void AnalogsResetAnalogName() { AnalogAnalogName.Text = string.Empty; }
        private void AnalogsResetAnalogNumber() { AnalogAnalogNumber.Text = string.Empty; }

        private void ProvidersResetSearch()
        {
            isSearchReseting = true;
            ProvidersResetName();
            ProvidersResetINN();
            isSearchReseting = false;
            suppliersBindingSource.RemoveFilter();
        }
        private void ProvidersResetName() { ProvidersName.Text = string.Empty; }
        private void ProvidersResetINN() { ProvidersINN.Text = string.Empty; }

        private void LogResetSearch()
        {
            isSearchReseting = true;
            LogResetNumber();
            LogResetField();
            LogResetValue();
            LogResetExecutor();
            LogResetStart();
            LogResetEnd();
            isSearchReseting = false;
            nomenclatureLogsBindingSource.RemoveFilter();
            LogTable.Columns[0].Visible = false;
        }
        private void LogResetNumber() { LogNumber.Text = string.Empty; }
        private void LogResetField() { LogField.Text = string.Empty; }
        private void LogResetValue() { LogValue.Text = string.Empty; }
        private void LogResetExecutor() { LogUser.Text = string.Empty; }
        private void LogResetStart() { LogStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1); LogStart.Checked = false; }
        private void LogResetEnd() { LogEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddMilliseconds(-1); LogEnd.Checked = false; }
        //remove filter #fix
        private void OstatkiResetSearch()
        {
            isSearchReseting = true;
            OstatkiResetNumber();
            OstatkiResetStorage();
            OstatkiResetPrice();
            isSearchReseting = false;
        }
        private void OstatkiResetNumber() { OstatkiNumber.Text = string.Empty; }
        private void OstatkiResetStorage() { OstatkiStorage.Text = string.Empty; }
        private void OstatkiResetPrice() { OstatkiPrice.Checked = false; }

        private void ResetSearchGroup_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripItem item)) return;
            if (!(item.Owner is ContextMenuStrip menu && menu.SourceControl is Control control)) return;
            if (!(control is System.Windows.Forms.GroupBox groupBox)) return;

            string groupName = groupBox.Name;

            switch (groupName)
            {
                case "NomenSearchGroup": NomenResetSearch(); break;
                case "GroupsSearchGroup": GroupsResetSearch(); break;
                case "ReceivingRequestsSearchGroup": ReceivingRequestsResetSearch(); break;
                case "PurchaseRequestsSearchGroup": PurchaseRequestsResetSearch(); break;
                case "StatementsSearchGroup": StatementsResetSearch(); break;
                case "InvoicesSearchGroup": InvoicesResetSearch(); break;
                case "HistorySearchGroup": HistoryResetSearch(); break;
                case "AnalogsSearchGroup": AnalogsResetSearch(); break;
                case "ProvidersSearchGroup": ProvidersResetSearch(); break;
                case "LogSearchGroup": LogResetSearch(); break;
                case "OstatkiSearchGroup": OstatkiResetSearch(); break;
                default: break;
            }
        }
        private void ResetSearchField_Click(object sender, EventArgs e)
        {
            if (!(sender is ToolStripItem item)) return;
            if (!(item.Owner is ContextMenuStrip menu && menu.SourceControl is Control field)) return;
            string fieldName = field.Name;
            switch (fieldName)
            {
                case "NomenNumber": NomenResetSearchNumber(); break;
                case "NomenName": NomenResetSearchName(); break;
                case "NomenSize": NomenResetSearchSize(); break;
                case "NomenMaterial": NomenResetSearchMaterial(); break;
                case "NomenProducer": NomenResetSearchProducer(); break;
                case "NomenUsage": NomenResetSearchUsage(); break;

                case "GroupsName": GroupsResetName(); break;

                case "ReceivingRequestsWorkshop": ReceivingRequestsResetWorkshop(); break;
                case "ReceivingRequestsStatus": ReceivingRequestsResetStatus(); break;

                case "PurchaseRequestsStart": PurchaseRequestsResetStart(); break;
                case "PurchaseRequestsEnd": PurchaseRequestsResetEnd(); break;
                case "PurchaseRequestsStatus": PurchaseRequestsResetStatus(); break;

                case "StatementsProvider": StatementsResetName(); break;
                case "StatementsDate": StatementsResetDate(); break;

                case "InvoicesDate": InvoicesResetDate(); break;

                case "HistoryStart": HistoryResetStart(); break;
                case "HistoryEnd": HistoryResetEnd(); break;
                case "HistoryNumber": HistoryResetNumber(); break;

                case "AnalogMainName": AnalogsResetMainName(); break;
                case "AnalogMainNumber": AnalogsResetMainNumber(); break;
                case "AnalogAnalogName": AnalogsResetAnalogName(); break;
                case "AnalogAnalogNumber": AnalogsResetAnalogNumber(); break;

                case "ProvidersName": ProvidersResetName(); break;
                case "ProvidersINN": ProvidersResetINN(); break;

                case "LogNumber": LogResetNumber(); break;
                case "LogField": LogResetField(); break;
                case "LogValue": LogResetValue(); break;
                case "LogUser": LogResetExecutor(); break;
                case "LogStart": LogResetStart(); break;
                case "LogEnd": LogResetEnd(); break;

                case "OstatkiNumber": OstatkiResetNumber(); break;
                case "OstatkiStorage": OstatkiResetStorage(); break;
                case "OstatkiPrice": OstatkiResetPrice(); break;

                default: break;
            }
        }
        #endregion

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