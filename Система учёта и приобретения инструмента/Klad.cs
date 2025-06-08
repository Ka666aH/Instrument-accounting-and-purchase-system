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
    public partial class Klad : Form
    {
        LoginForm login;
        bool changeUser = false;
        public Klad(LoginForm _login)
        {
            InitializeComponent();
            login = _login;
            WorkshopsMain.UserDeletingRow += WorkshopsMain_UserDeletingRow;
        }

        private void Klad_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet1.ReceivingRequestsContent1". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContent1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet1.ReceivingRequestsContent1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet1.ReceivingRequests1". При необходимости она может быть перемещена или удалена.
            this.receivingRequests1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet1.ReceivingRequests1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Workshops". При необходимости она может быть перемещена или удалена.
            this.workshopsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Workshops);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Balances". При необходимости она может быть перемещена или удалена.
            this.balancesTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Balances);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DefectiveLists". При необходимости она может быть перемещена или удалена.
            this.defectiveListsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DefectiveLists);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ToolMovements". При необходимости она может быть перемещена или удалена.
            this.toolMovementsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ToolMovements);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContent1". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContent1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContent1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequests1". При необходимости она может быть перемещена или удалена.
            this.receivingRequests1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequests1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Storages". При необходимости она может быть перемещена или удалена.
            this.storagesTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Storages);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Storages1". При необходимости она может быть перемещена или удалена.
            this.storages1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Storages1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Workshops1". При необходимости она может быть перемещена или удалена.
            this.workshops1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Workshops1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureView". При необходимости она может быть перемещена или удалена.
            this.nomenclatureViewTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureView);

            this.WindowState = FormWindowState.Maximized;
        }

        private void Klad_FormClosed(object sender, FormClosedEventArgs e)
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
                    case "Workshops":

                        workshopsTableAdapter.Update(tOOLACCOUNTINGDataSet.Workshops);
                        workshopsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops);
                        workshops1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops1);
                        tabControl1.SelectedTab = tabPage5;
                        return null;



                    case "Storages":


                        storagesTableAdapter.Update(tOOLACCOUNTINGDataSet.Storages);
                        storagesTableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages);
                        storages1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages1);
                        tabControl1.SelectedTab = tabPage6;
                        return null;


                    case "Balances":

                        //обновление таблиц аналогов

                        balancesTableAdapter.Update(tOOLACCOUNTINGDataSet.Balances);
                        balancesTableAdapter.Fill(tOOLACCOUNTINGDataSet.Balances);
                        tabControl1.SelectedTab = tabPage4;
                        return null;





                    default: return "Не найдена таблица.";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        private void AddApplication_Click(object sender, EventArgs e)
        {
            AddApplications addApplications = new AddApplications();
            addApplications.ShowDialog();
        }

        private void AddMoving_Click(object sender, EventArgs e)
        {
            AddMoving addMoving = new AddMoving();
            addMoving.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DefAdd defAdd = new DefAdd();
            defAdd.ShowDialog();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(dateTimePicker2.Text)) parameters.Add(new SearchParameter("DefectiveListDate", dateTimePicker2.Value, true));
            if (!string.IsNullOrEmpty(comboBox6.Text)) parameters.Add(new SearchParameter("WorkshopID", comboBox6.Text, true));
            if (!string.IsNullOrEmpty(textBox1.Text)) parameters.Add(new SearchParameter("NomenclatureNumber", textBox1.Text, true));
            if (!string.IsNullOrEmpty(textBox11.Text)) parameters.Add(new SearchParameter("BatchNumber", textBox11.Text, false));
            if (!string.IsNullOrEmpty(textBox14.Text)) parameters.Add(new SearchParameter("Price", textBox14.Text, true));
            if (!string.IsNullOrEmpty(textBox13.Text)) parameters.Add(new SearchParameter("Quantity", textBox13.Text, true));
            if (radioButton1.Checked) parameters.Add(new SearchParameter("IsWriteOff", true, true));
            if (radioButton2.Checked) parameters.Add(new SearchParameter("IsWriteOff", false, true));
            try
            {
                string filter = Search.Filter(parameters);
                dataGridView3.SuspendLayout();
                defectiveListsBindingSource.Filter = filter;
                dataGridView3.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #region storages
        #region storagesSearch
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(textBox2.Text)) parameters.Add(new SearchParameter("StorageID", Convert.ToInt32(textBox2.Text), true));
            if (!string.IsNullOrEmpty(textBox4.Text)) parameters.Add(new SearchParameter("Name", textBox4.Text, false));
            if (!string.IsNullOrEmpty(textBox5.Text)) parameters.Add(new SearchParameter("WorkshopID", Convert.ToInt32(textBox5.Text), true));
            try
            {
                string filter = Search.Filter(parameters);
                StoragesTable.SuspendLayout();
                storagesBindingSource.Filter = filter;
                StoragesTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion
        private void CreateStorage_Click(object sender, EventArgs e)
        {
            StorageForm storageForm = new StorageForm(tOOLACCOUNTINGDataSet, storagesTableAdapter);
            storageForm.ShowDialog();
        }
        public void SetStoragesButtonsState()
        {
            bool state = StoragesTable.CurrentRow != null && !StoragesTable.CurrentRow.IsNewRow && !string.IsNullOrEmpty(StoragesTable.CurrentRow.Cells[0].Value.ToString()) ; 
            AlterStorage.Enabled = state;
            DeleteStorage.Enabled = state;
        }
        private void StoragesTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetStoragesButtonsState();
        }
        private void AlterStorage_Click(object sender, EventArgs e)
        {
            SetStoragesButtonsState();
            if (StoragesTable.CurrentRow.DataBoundItem as DataRowView == null) return;
            var selectedRow = StoragesTable.CurrentRow.DataBoundItem as DataRowView;
            var storageRow = selectedRow.Row as TOOLACCOUNTINGDataSet.StoragesRow;

            StorageForm StorageForm = new StorageForm(tOOLACCOUNTINGDataSet, storagesTableAdapter, FormMode.Edit, storageRow);
            StorageForm.ShowDialog();
        }
        private void DeleteStorage_Click(object sender, EventArgs e)
        {
            StorageDelete();
        }

        private bool StorageDelete()
        {
            if (StoragesTable.CurrentRow.DataBoundItem as DataRowView == null) return false;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return false;

            try
            {
                var selectedRow = StoragesTable.CurrentRow.DataBoundItem as DataRowView;
                var storagesRow = selectedRow.Row as TOOLACCOUNTINGDataSet.StoragesRow;
                //var storages1RowId = storages1Row.StorageID;

                var StoragesRow = tOOLACCOUNTINGDataSet.Storages.Where(s => s.StorageID == storagesRow.StorageID).FirstOrDefault();
                //var hasRelatedTools = tOOLACCOUNTINGDataSet.Tools.Any(w => w.StorageID == storages1Row.StorageID);
                //if (hasRelatedTools)
                //{
                //    MessageBox.Show("Невозможно удалить хранилище, так как оно связано с инструментами.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
                StoragesRow.Delete();
                storagesTableAdapter.Update(tOOLACCOUNTINGDataSet.Storages);
                storagesTableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages);
                storages1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages1);
                //tools1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Tools1);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private TOOLACCOUNTINGDataSet.StoragesRow storagesOriginRow = null;
        private bool storagesUserEditing = false;

        private void StoragesTable_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            storagesUserEditing = true;
            var dataRowView = StoragesTable.Rows[e.RowIndex].DataBoundItem as DataRowView;
            storagesOriginRow = dataRowView?.Row as TOOLACCOUNTINGDataSet.StoragesRow;
        }

        private void StoragesTable_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!storagesUserEditing) return;
            if (StoragesTable.Rows[e.RowIndex] == null) return;
            var row = StoragesTable.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    string storageNum = cell.EditedFormattedValue?.ToString();
                    FormMode mode;
                    if (storagesOriginRow == null) mode = FormMode.Add;
                    else mode = FormMode.Edit;
                    if (!Validation.IsStorageUnique(storageNum, tOOLACCOUNTINGDataSet, mode, storagesOriginRow)) e.Cancel = true;
                    break;
                case 2:
                    string workshopNum = cell.EditedFormattedValue?.ToString();
                    if (storagesOriginRow == null) mode = FormMode.Add;
                    else mode = FormMode.Edit;
                    int workshopId;
                    if (!int.TryParse(workshopNum, out workshopId))
                    {
                        e.Cancel = true;
                        NotificationService.Notify("Предупреждение", "Это поле не может быть пустым.", ToolTipIcon.Warning);
                        break;
                    }
                    if (!Validation.IsStorageConnectedToWorkshop(workshopId, tOOLACCOUNTINGDataSet, mode, storagesOriginRow)) e.Cancel = true;
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

        private void StoragesTable_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            storagesUserEditing = false;
        }

        private void StoragesTable_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!storagesUserEditing) return;

            DataGridViewRow row = null;
            try
            {
                row = StoragesTable.Rows[e.RowIndex];
                DataRowView selectedRow = row.DataBoundItem as DataRowView;
                if (selectedRow == null) return;
                var storages1Row = selectedRow.Row as TOOLACCOUNTINGDataSet.StoragesRow;
                var storages1Number = storages1Row.StorageID;
                var storagesRow = tOOLACCOUNTINGDataSet.Storages.Where(x => x.StorageID == storages1Number).FirstOrDefault();

                if (storagesRow != null)
                {
                    storagesRow.Name = storages1Row.Name;
                    storagesRow.WorkshopID = storages1Row.WorkshopID;
                }
                else
                {
                    var newRow = tOOLACCOUNTINGDataSet.Storages.NewStoragesRow();
                    newRow.StorageID = storages1Row.StorageID;
                    newRow.Name = storages1Row.Name;
                    newRow.WorkshopID = storages1Row.WorkshopID;
                    tOOLACCOUNTINGDataSet.Storages.Rows.Add(newRow);
                }
                storagesTableAdapter.Update(tOOLACCOUNTINGDataSet.Storages);
                storagesTableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages);
                storages1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages1);
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                tOOLACCOUNTINGDataSet.Storages.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void StoragesTable_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            StorageDelete();
            e.Cancel = true;
        }

        #endregion

        #region ReceivingReq
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(ApplicationNeedDate.Text)) parameters.Add(new SearchParameter("ReceivingRequestDate", ApplicationNeedDate.Value, true));
            if (!string.IsNullOrEmpty(textBox8.Text)) parameters.Add(new SearchParameter("ReceivingRequestID", textBox8.Text, true));
            if (!string.IsNullOrEmpty(textBox9.Text)) parameters.Add(new SearchParameter("WorkshopID", textBox9.Text, true));
            if (!string.IsNullOrEmpty(comboBox1.Text)) parameters.Add(new SearchParameter("Reason", comboBox1.Text, false));
            if (!string.IsNullOrEmpty(comboBox3.Text)) parameters.Add(new SearchParameter("ReceivingRequestType", comboBox3.Text, true));
            if (!string.IsNullOrEmpty(ApplicationStatusSearch.Text)) parameters.Add(new SearchParameter("Status", ApplicationStatusSearch.Text, true));
            try
            {
                string filter = Search.Filter(parameters);
                WorkshopsRequestsRequestsTable.SuspendLayout();
                receivingRequests1BindingSource.Filter = filter;
                WorkshopsRequestsRequestsTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region workshops
        #region workshopsSearch
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(textBox3.Text)) parameters.Add(new SearchParameter("WorkshopID", Convert.ToInt32(textBox3.Text), true));
            if (!string.IsNullOrEmpty(GroupsName.Text)) parameters.Add(new SearchParameter("Name", GroupsName.Text, false));
            try
            {
                string filter = Search.Filter(parameters);
                WorkshopsMain.SuspendLayout();
                workshops1BindingSource.Filter = filter;
                WorkshopsMain.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region Цеха
        public void SetWorkshopsButtonsState()
        {
            bool state = WorkshopsMain.CurrentRow != null && !string.IsNullOrEmpty(WorkshopsMain.CurrentRow.Cells[0].Value.ToString())  ;
            AlterWorkshop.Enabled = state;
            DeleteWorkshop.Enabled = state;
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            SetWorkshopsButtonsState();
        }
        private void AlterWorkshop_Click(object sender, EventArgs e)
        {
            SetWorkshopsButtonsState();
            if (WorkshopsMain.CurrentRow.DataBoundItem as DataRowView == null) return;
            var selectedRow = WorkshopsMain.CurrentRow.DataBoundItem as DataRowView;
            var workshopRow = selectedRow.Row as TOOLACCOUNTINGDataSet.Workshops1Row;

            WorkshopForm WorkshopForm = new WorkshopForm(tOOLACCOUNTINGDataSet, workshopsTableAdapter, FormMode.Edit, workshopRow);
            WorkshopForm.ShowDialog();
        }
        private void DeleteWorkshop_Click(object sender, EventArgs e)
        {
            WorkshopsDelete();
        }
        private void WorkshopsMain_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            WorkshopsDelete();
            e.Cancel = true;
        }
        private bool WorkshopsDelete()
        {
            SetWorkshopsButtonsState();
            if (WorkshopsMain.CurrentRow.DataBoundItem as DataRowView == null) return false;
            DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No) return false;

            try
            {
                var selectedRow = WorkshopsMain.CurrentRow.DataBoundItem as DataRowView;
                var workshops1Row = selectedRow.Row as TOOLACCOUNTINGDataSet.Workshops1Row;
                var workshops1RowId = workshops1Row.WorkshopID;

                var WorkshopsRow = tOOLACCOUNTINGDataSet.Workshops.Where(s => s.WorkshopID == workshops1Row.WorkshopID).FirstOrDefault();
                var hasRelatedStorages = tOOLACCOUNTINGDataSet.Storages.Any(w => w.WorkshopID == workshops1Row.WorkshopID);
                if (hasRelatedStorages)
                {
                    MessageBox.Show("Невозможно удалить цех, так как он связан с хранилищами.", "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                WorkshopsRow.Delete();
                workshopsTableAdapter.Update(tOOLACCOUNTINGDataSet.Workshops);
                workshopsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops);
                workshops1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops1);
                storages1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages1);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private TOOLACCOUNTINGDataSet.WorkshopsRow workshopsOriginRow = null;
        private bool workshopsUserEditing = false;

        private void WorkshopsMain_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            workshopsUserEditing = true;
            var dataRowView = WorkshopsMain.Rows[e.RowIndex].DataBoundItem as DataRowView;
            var workshop1OriginRow = dataRowView?.Row as TOOLACCOUNTINGDataSet.Workshops1Row;   
    

            if (workshop1OriginRow != null) workshopsOriginRow = tOOLACCOUNTINGDataSet.Workshops.Where(s => s.WorkshopID == workshop1OriginRow.WorkshopID).FirstOrDefault();
            else workshopsOriginRow = null;
            var row = WorkshopsMain.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            if (cell.ColumnIndex == 0 && workshopsOriginRow != null)
            {
                workshopsUserEditing = false;
                e.Cancel = true;
            }

        }

        private void WorkshopsMain_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (!workshopsUserEditing) return;
            if (WorkshopsMain.Rows[e.RowIndex] == null) return;
            var row = WorkshopsMain.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            switch (e.ColumnIndex)
            {
                case 0:
                    string workshopNum = row.Cells[0].Value?.ToString();
                    string workshopName = row.Cells[1].Value?.ToString();
                    FormMode mode;
                    if (workshopsOriginRow == null) mode = FormMode.Add;
                    else mode = FormMode.Edit;
                    if (!Validation.IsWorkshopUnique(workshopNum, tOOLACCOUNTINGDataSet, mode, workshopsOriginRow)) e.Cancel = true;
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
        private void WorkshopsMain_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            workshopsUserEditing = false;
        }

        private void WorkshopsMain_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (!workshopsUserEditing) return;

            DataGridViewRow row = null;
            try
            {
                row = WorkshopsMain.Rows[e.RowIndex];
                DataRowView selectedRow = row.DataBoundItem as DataRowView;
                if (selectedRow == null) return;
                var workshop1Row = selectedRow.Row as TOOLACCOUNTINGDataSet.Workshops1Row;
                var workshop1Number = workshop1Row.WorkshopID;
                var workshopRow = tOOLACCOUNTINGDataSet.Workshops.Where(x => x.WorkshopID == workshop1Number).FirstOrDefault();

                if (workshopRow != null)
                {
                    workshopRow.Name = workshop1Row.Name;
                }
                else
                {
                    var newRow = tOOLACCOUNTINGDataSet.Workshops.NewWorkshopsRow();
                    newRow.WorkshopID = workshop1Row.WorkshopID;
                    newRow.Name = workshop1Row.Name;
                    tOOLACCOUNTINGDataSet.Workshops.Rows.Add(newRow);
         
                }
                workshopsTableAdapter.Update(tOOLACCOUNTINGDataSet.Workshops);
                workshopsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops);
                workshops1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops1);
                storages1TableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages1);    
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                tOOLACCOUNTINGDataSet.Workshops.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        #endregion
        #endregion


        #region Nomenclature

        private void NomenclatureSearchClear_Click(object sender, EventArgs e)
        {
            NomenNumber.Clear();
            textBox6.Clear();
            NomenSize.Clear();
            NomenMaterial.Clear();
            NomenProducer.Clear();
            NomenUsage.Text = "";

        }
        private void Nomen_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(NomenNumber.Text)) parameters.Add(new SearchParameter("NomenclatureNumber", NomenNumber.Text));
            if (!string.IsNullOrEmpty(textBox6.Text)) parameters.Add(new SearchParameter("FullName", textBox6.Text, false));
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











        #endregion

        private void StoragesTable_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (StoragesTable.CurrentCell.ColumnIndex == 0 || StoragesTable.CurrentCell.ColumnIndex == 2)
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
        private void Digits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }
    }

}

