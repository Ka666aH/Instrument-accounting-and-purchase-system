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
        private bool receivingSearchReseting = false;
        private ToolStripMenuItem nomenDefectiveMenuItem;
        private ToolStripMenuItem nomenMovingMenuItem;
        private ContextMenuStrip defectiveContextMenu;
        private ContextMenuStrip receivingContextMenu;
        private ContextMenuStrip movementsContextMenu;
        public Klad(LoginForm _login)
        {
            InitializeComponent();
            login = _login;
            WorkshopsMain.UserDeletingRow += WorkshopsMain_UserDeletingRow;

            // Подписка на пункты меню "Отчёты"
            отчетПоОстаткамToolStripMenuItem.Click += ReportBalances_Click;
            отчетПоДефектнымВедомостямToolStripMenuItem.Click += ReportDefective_Click;
            отчетПоЗаявкамToolStripMenuItem.Click += ReportApplications_Click;

            // ======== ДОБАВЛЕНО ========
            SetupContextMenus();
            SetupDefectiveContextMenu();
            SetupReceivingContextMenu();
            SetupMovementsContextMenu();
            // ======== КОНЕЦ ДОБАВЛЕНИЯ ========

            // ======== ДОБАВЛЕНИЕ ДЛЯ ДВИЖЕНИЙ ========
            // Кнопка «Провести» для движений
            WriteOff.Click += WriteOff_Click;

            // Переключение выбранного движения – меняем состояние кнопки
            dataGridView2.CurrentCellChanged += dataGridView2_CurrentCellChanged;
            UpdateWriteOffButtonState();
            // ======== КОНЕЦ ДОБАВЛЕНИЯ ========
        }

        private void Klad_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Balances". При необходимости она может быть перемещена или удалена.
            this.balancesTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Balances);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ToolMovements". При необходимости она может быть перемещена или удалена.
            this.toolMovementsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ToolMovements);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet1.ReceivingRequestsContent1". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContent1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContent1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet1.ReceivingRequests1". При необходимости она может быть перемещена или удалена.
            this.receivingRequests1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequests1);
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

            // Настраиваем очищаемые контроли
            // Nomen controls
            SetupClearableControl(NomenNumber);
            SetupClearableControl(textBox6);
            SetupClearableControl(NomenSize);
            SetupClearableControl(NomenMaterial);
            SetupClearableControl(NomenProducer);
            SetupClearableControl(NomenUsage);

            // Storages controls
            SetupClearableControl(textBox2);
            SetupClearableControl(textBox4);
            SetupClearableControl(textBox5);

            // Workshops controls
            SetupClearableControl(textBox3);
            SetupClearableControl(GroupsName);

            // ReceivingReq controls
            SetupClearableControl(textBox8);
            SetupClearableControl(textBox9);
            SetupClearableControl(comboBox1);
            SetupClearableControl(Planned);
            SetupClearableControl(NonPlanned);
            SetupClearableControl(ApplicationStatusSearch);

            // Defective lists controls
            SetupClearableControl(textBox1);
            SetupClearableControl(textBox11);
            SetupClearableControl(textBox14);
            SetupClearableControl(textBox13);
            SetupClearableControl(textBox15);

            // Ostatki (Остатки) controls
            SetupClearableControl(textBox12);   // Номер склада или иной фильтр
            SetupClearableControl(textBox7);    // Склад
            SetupClearableControl(OstatkiNumber); // Номенклатурный номер
            SetupClearableControl(textBox16);   // Цена

            // Подписка на события поиска
            SubscribeReceivingSearchEvents();
            SubscribeDefectiveSearchEvents();
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
            AddApplications addApplications = new AddApplications(tOOLACCOUNTINGDataSet);
            // Подписываемся на событие сохранения для обновления таблиц
            addApplications.RequestSaved += (s, args) => RefreshReceivingRequestsTables();
            addApplications.ShowDialog();
        }

        private void AddMoving_Click(object sender, EventArgs e)
        {
            AddMoving addMoving = new AddMoving();
            addMoving.MovementSaved += (s, args) => { RefreshToolMovementsTables(); OstatkiResetSearch(); };
            addMoving.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DefAdd defAdd = new DefAdd();
            defAdd.DefectiveSaved += (s, args) => RefreshDefectiveListsTables();
            defAdd.ShowDialog();
        }

        private void RefreshDefectiveListsTables()
        {
            try
            {
                this.defectiveListsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DefectiveLists);
                defectiveListsBindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления дефектных ведомостей: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RefreshToolMovementsTables()
        {
            try
            {
                this.toolMovementsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ToolMovements);
                this.balancesTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Balances);
                // Если источники привязки существуют – обновляем
                toolMovementsBindingSource?.ResetBindings(false);
                balancesBindingSource?.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления таблиц движения/остатков: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            receivingRequests1BindingSource.RemoveFilter();
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(dateTimePicker2.Text)) parameters.Add(new SearchParameter("DefectiveListDate", dateTimePicker2.Value, true));
            if (!string.IsNullOrEmpty(textBox15.Text)) parameters.Add(new SearchParameter("WorkshopID", Convert.ToInt32(textBox15.Text), true));
            if (!string.IsNullOrEmpty(textBox1.Text)) parameters.Add(new SearchParameter("NomenclatureNumber", textBox1.Text, true));
            if (!string.IsNullOrEmpty(textBox11.Text)) parameters.Add(new SearchParameter("BatchNumber", textBox11.Text, true));
            decimal priceVal; int quantityVal;
            if (!string.IsNullOrEmpty(textBox14.Text) && decimal.TryParse(textBox14.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out priceVal))
                parameters.Add(new SearchParameter("Price", priceVal, true));
            if (!string.IsNullOrEmpty(textBox13.Text) && int.TryParse(textBox13.Text, out quantityVal))
                parameters.Add(new SearchParameter("Quantity", quantityVal, true));
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
        private void CreateMove_Click(object sender, EventArgs e)
        {
            AddMoving addMoving = new AddMoving();
            addMoving.MovementSaved += (s, args) => { RefreshToolMovementsTables(); OstatkiResetSearch(); };
            addMoving.ShowDialog();
        }
        public void SetStoragesButtonsState()
        {
            bool state = StoragesTable.CurrentRow != null && !StoragesTable.CurrentRow.IsNewRow && !string.IsNullOrEmpty(StoragesTable.CurrentRow.Cells[0].Value.ToString());
            
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
                MessageBox.Show(ex.Message, "Ошибка удаления", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    if (string.IsNullOrWhiteSpace(storageNum)) {
                        e.Cancel = true;
                        NotificationService.Notify("Предупреждение", "Это поле не может быть пустым.", ToolTipIcon.Warning);
                        break;
                    }
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
            if (receivingSearchReseting) return;
            var parameters = new List<SearchParameter>();
            if (ApplicationNeedDate.Checked) parameters.Add(new SearchParameter("ReceivingRequestDate", ApplicationNeedDate.Value, true));
            if (!string.IsNullOrEmpty(textBox8.Text)) parameters.Add(new SearchParameter("ReceivingRequestID", Convert.ToInt32(textBox8.Text), true));
            if (!string.IsNullOrEmpty(textBox9.Text)) parameters.Add(new SearchParameter("WorkshopID", Convert.ToInt32(textBox9.Text), true));
            if (!string.IsNullOrEmpty(comboBox1.Text)) parameters.Add(new SearchParameter("Reason", comboBox1.Text, true));
            if (Planned.Checked) parameters.Add(new SearchParameter("ReceivingRequestType", "Плановая", true));
            if (NonPlanned.Checked) parameters.Add(new SearchParameter("ReceivingRequestType", "Внеплановая", true));
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
            bool state = WorkshopsMain.CurrentRow != null && !string.IsNullOrEmpty(WorkshopsMain.CurrentRow.Cells[0].Value.ToString());
          
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
                    if (string.IsNullOrWhiteSpace(workshopNum))
                    {
                        e.Cancel = true;
                        NotificationService.Notify("Предупреждение", "Это поле не может быть пустым.", ToolTipIcon.Warning);
                        break;
                    }
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

        private void AlterReceiving_Click(object sender, EventArgs e)
        {
            ////SetWorkshopsButtonsState();
            //if (WorkshopsMain.CurrentRow.DataBoundItem as DataRowView == null) return;
            //var selectedRow = WorkshopsMain.CurrentRow.DataBoundItem as DataRowView;
            //var workshopRow = selectedRow.Row as TOOLACCOUNTINGDataSet.Workshops1Row;

            //AddApplications addApplications = new AddApplications(tOOLACCOUNTINGDataSet, workshopsTableAdapter, FormMode.Edit, workshopRow);
            //addApplications.ShowDialog();
        }

        private void RefreshReceivingRequestsTables()
        {
            try
            {
                this.receivingRequests1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequests1);
                this.receivingRequestsContent1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContent1);

                // Обновляем привязку данных
                receivingRequests1BindingSource.ResetBindings(false);
                receivingRequests1ReceivingRequestsContent1BindingSource.ResetBindings(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка обновления таблиц: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #region Search Clear Helpers
        private Dictionary<Control, Button> clearButtons = new Dictionary<Control, Button>();
        private void SetupClearableControl(Control control)
        {
            // Добавляем контекстное меню
            var cms = new ContextMenuStrip();
            cms.Items.Add("Очистить", null, (s, e) => ClearControl(control));
            control.ContextMenuStrip = cms;
            if (control is RadioButton)
                return;
            // Создаём кнопку-крестик
            Button btn = new Button();
            btn.Size = new Size(17, control.Height - 2);
            btn.Text = "×"; // Символ крестика
            btn.Font = new Font(btn.Font.FontFamily, 6);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.BackColor = Color.Transparent;
            btn.TabStop = false;
            btn.Click += (s, e) => ClearControl(control);
            control.Parent.Controls.Add(btn);
            btn.BringToFront();
            PositionClearButton(control, btn);
            clearButtons[control] = btn;
            // Обновлять позицию при перемещении/изменении размера
            control.Resize += (s, e) => PositionClearButton(control, btn);
            control.LocationChanged += (s, e) => PositionClearButton(control, btn);
        }
        private void PositionClearButton(Control ctl, Button btn)
        {
            btn.Location = new Point(ctl.Right - btn.Width - 1, ctl.Top + 1);
        }
        private void ClearControl(Control ctl)
        {
            if (ctl is TextBox tb)
                tb.Text = string.Empty;
            if (ctl is MaskedTextBox mtb)
                mtb.Text = string.Empty;
            else if (ctl is ComboBox cb)
                cb.SelectedIndex = -1;
            else if (ctl is DateTimePicker dtp)
                dtp.Value = DateTime.Today;
        }
        #endregion

        #region Сброс поиска – Nomen (ранее создан)
        private bool isSearchReseting = false;
        private void NomenResetSearchNumber() { NomenNumber.Text = string.Empty; }
        private void NomenResetSearchName() { textBox6.Text = string.Empty; }
        private void NomenResetSearchSize() { NomenSize.Text = string.Empty; }
        private void NomenResetSearchMaterial() { NomenMaterial.Text = string.Empty; }
        private void NomenResetSearchProducer() { NomenProducer.Text = string.Empty; }
        private void NomenResetSearchUsage() { NomenUsage.SelectedIndex = 0; }
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

        private void button3_Click(object sender, EventArgs e)
        {
            NomenResetSearch();
        }
        #endregion

        #region Сброс поиска – Storages
        private void StoragesResetSearchID() { textBox2.Text = string.Empty; }
        private void StoragesResetSearchName() { textBox4.Text = string.Empty; }
        private void StoragesResetSearchWorkshop() { textBox5.Text = string.Empty; }
        private void StoragesResetSearch()
        {
            StoragesResetSearchID();
            StoragesResetSearchName();
            StoragesResetSearchWorkshop();
            storagesBindingSource.RemoveFilter();
        }
        private void StoragesResetButton_Click(object sender, EventArgs e)
        {
            StoragesResetSearch();
        }
        #endregion

        #region Сброс поиска – Workshops
        private void WorkshopsResetSearchID() { textBox3.Text = string.Empty; }
        private void WorkshopsResetSearchName() { GroupsName.Text = string.Empty; }
        private void WorkshopsResetSearch()
        {
            WorkshopsResetSearchID();
            WorkshopsResetSearchName();
            workshops1BindingSource.RemoveFilter();
        }
        private void WorkshopsResetButton_Click(object sender, EventArgs e)
        {
            WorkshopsResetSearch();
        }
        #endregion

        //private void RecReqClear()
        //{
        //    receivingRequests1BindingSource.RemoveFilter();
        //}

        #region Сброс поиска – Receiving Requests
        private void ReceivingResetSearchDate() { ApplicationNeedDate.Checked = false; }
        private void ReceivingResetSearchID() { textBox8.Text = string.Empty; }
        private void ReceivingResetSearchWorkshop() { textBox9.Text = string.Empty; }
        private void ReceivingResetSearchReason() { comboBox1.SelectedIndex = -1; }
        private void ReceivingResetSearchType() { Planned.Checked = false; NonPlanned.Checked = false; }
        private void ReceivingResetSearchStatus() { ApplicationStatusSearch.SelectedIndex = -1; }
        private void ReceivingResetSearch()
        {
            receivingSearchReseting = true;
            ReceivingResetSearchDate();
            ReceivingResetSearchID();
            ReceivingResetSearchWorkshop();
            ReceivingResetSearchReason();
            ReceivingResetSearchType();
            ReceivingResetSearchStatus();
            receivingSearchReseting = false;
            receivingRequests1BindingSource.RemoveFilter();
        }
        private void ReceivingResetButton_Click(object sender, EventArgs e)
        {
            ReceivingResetSearch();
        }
        #endregion

        #region Сброс поиска – DefectiveLists
        private void DefectiveResetSearchDate() { dateTimePicker2.Value = DateTime.Today; }
        private void DefectiveResetSearchWorkshop() { textBox15.Text = string.Empty; }
        private void DefectiveResetSearchNomen() { textBox1.Text = string.Empty; }
        private void DefectiveResetSearchBatch() { textBox11.Text = string.Empty; }
        private void DefectiveResetSearchPrice() { textBox14.Text = string.Empty; }
        private void DefectiveResetSearchQuantity() { textBox13.Text = string.Empty; }
        private void DefectiveResetSearchFlags() { radioButton1.Checked = radioButton2.Checked = false; }
        private void DefectiveResetSearch()
        {
            DefectiveResetSearchDate();
            DefectiveResetSearchWorkshop();
            DefectiveResetSearchNomen();
            DefectiveResetSearchBatch();
            DefectiveResetSearchPrice();
            DefectiveResetSearchQuantity();
            DefectiveResetSearchFlags();
            defectiveListsBindingSource.RemoveFilter();
        }
        private void DefectiveResetButton_Click(object sender, EventArgs e)
        {
            DefectiveResetSearch();
        }
        #endregion

        private void SubscribeReceivingSearchEvents()
        {
            // Заявки на получение
            textBox8.TextChanged += textBox8_TextChanged;
            textBox9.TextChanged += textBox8_TextChanged;
            comboBox1.SelectedIndexChanged += (s, e) => textBox8_TextChanged(s, e);
            Planned.CheckedChanged += (s, e) => textBox8_TextChanged(s, e);
            NonPlanned.CheckedChanged += (s, e) => textBox8_TextChanged(s, e);
            ApplicationStatusSearch.TextChanged += (s, e) => textBox8_TextChanged(s, e);
            ApplicationStatusSearch.SelectedIndexChanged += (s, e) => textBox8_TextChanged(s, e);
            ApplicationNeedDate.ValueChanged += (s, e) => textBox8_TextChanged(s, e);
        }

        private void SubscribeDefectiveSearchEvents()
        {
            // Дефектные ведомости
            dateTimePicker2.ValueChanged += textBox11_TextChanged;
            textBox15.TextChanged += textBox11_TextChanged;
            textBox1.TextChanged += textBox11_TextChanged;
            textBox11.TextChanged += textBox11_TextChanged; // уже есть, лишним не будет
            textBox14.TextChanged += textBox11_TextChanged;
            textBox13.TextChanged += textBox11_TextChanged;
            radioButton1.CheckedChanged += textBox11_TextChanged;
            radioButton2.CheckedChanged += textBox11_TextChanged;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            receivingSearchReseting = true;
            ReceivingResetSearchDate();
            ReceivingResetSearchID();
            ReceivingResetSearchWorkshop();
            ReceivingResetSearchReason();
            ReceivingResetSearchType();
            ReceivingResetSearchStatus();
            receivingSearchReseting = false;
            receivingRequests1BindingSource.RemoveFilter();
            DefectiveResetSearchDate();
            DefectiveResetSearchWorkshop();
            DefectiveResetSearchNomen();
            DefectiveResetSearchBatch();
            DefectiveResetSearchPrice();
            DefectiveResetSearchQuantity();
            DefectiveResetSearchFlags();
            defectiveListsBindingSource.RemoveFilter();
        }

        #region Контекстные меню
        private void SetupContextMenus()
        {
            SetupNomenContextMenu();
            SetupOstatkiContextMenu();
            SetupWorkshopContextMenu();
            SetupStorageContextMenu();
            SetupDefectiveContextMenu();
            SetupReceivingContextMenu();
            SetupMovementsContextMenu();
        }

        private void SetupNomenContextMenu()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Создать заявку на получение инструмента", null, NomenCreateApplication_Click);
            menu.Items.Add("Показать остатки", null, NomenShowOstatki_Click);
            menu.Items.Add(new ToolStripSeparator());
            nomenDefectiveMenuItem = new ToolStripMenuItem("Создать дефектную ведомость", null, NomenCreateDefective_Click);
            nomenMovingMenuItem   = new ToolStripMenuItem("Создать перемещение",        null, NomenCreateMoving_Click);
            menu.Items.Add(nomenDefectiveMenuItem);
            menu.Items.Add(nomenMovingMenuItem);

            // обработчик Opening для динамической активации
            menu.Opening += NomenContextMenu_Opening;
            NomenTable.ContextMenuStrip = menu;
        }

        /// <summary>
        /// Вызывается перед отображением контекстного меню NomenTable.
        /// Блокирует пункты «Создать дефектную ведомость» и «Создать перемещение»,
        /// если выбранно более одной строки или по номенклатуре нет остатков.
        /// </summary>
        private void NomenContextMenu_Opening(object sender, CancelEventArgs e)
        {
            // Если меню открывается не для текущего DataGridView – выходим
            if (!(sender is ContextMenuStrip)) return;

            // Проверяем количество выделенных строк
            int selectedCount = NomenTable.SelectedRows.Count;

            // По умолчанию блокируем пункты, если выбрано более одной строки
            bool enable = selectedCount == 1;

            if (enable && selectedCount == 1)
            {
                // Проверяем наличие остатков по номенклатуре
                var drv = NomenTable.SelectedRows[0].DataBoundItem as DataRowView;
                if (drv != null)
                {
                    string nomenNumber = drv["NomenclatureNumber"].ToString();
                    enable = tOOLACCOUNTINGDataSet.Balances.Any(b => b.NomenclatureNumber == nomenNumber && b.Quantity > 0);
                }
                else enable = false;
            }

            nomenDefectiveMenuItem.Enabled = enable;
            nomenMovingMenuItem.Enabled    = enable;
        }

        private void SetupOstatkiContextMenu()
        {
            var menu = new ContextMenuStrip();
            var itemDef = new ToolStripMenuItem("Создать дефектную ведомость", null, OstatkiCreateDefective_Click);
            var itemMove = new ToolStripMenuItem("Создать перемещение", null, OstatkiCreateMoving_Click);

            menu.Items.AddRange(new ToolStripItem[] { itemDef, itemMove });

            // активация только для склада 0
            menu.Opening += (s, e) =>
            {
                bool enable = false;
                if (OstatkiTable.CurrentRow?.DataBoundItem is DataRowView drv)
                {
                    int storageId = Convert.ToInt32(drv["StorageID"]);
                    enable = storageId == 0;
                }
                itemDef.Enabled = enable;
                itemMove.Enabled = enable;
            };
            OstatkiTable.ContextMenuStrip = menu;
        }

        private void SetupWorkshopContextMenu()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Создать заявку на получение инструмента", null, WorkshopCreateApplication_Click);
            WorkshopsMain.ContextMenuStrip = menu;
        }

        private void SetupStorageContextMenu()
        {
            var menu = new ContextMenuStrip();
            menu.Items.Add("Создать перемещение на данный склад", null, StorageCreateMovingTo_Click);
            menu.Items.Add("Показать остатки на этом складе", null, StorageShowOstatki_Click);
            StoragesTable.ContextMenuStrip = menu;
        }

        private void SetupDefectiveContextMenu()
        {
            defectiveContextMenu = new ContextMenuStrip();
            var createWriteOff = new ToolStripMenuItem("Создать списание");
            createWriteOff.Click += DefectiveCreateWriteOff_Click;
            var showBalances = new ToolStripMenuItem("Показать остатки по номенклатуре");
            showBalances.Click += DefectiveShowBalances_Click;
            defectiveContextMenu.Items.AddRange(new ToolStripItem[] { createWriteOff, showBalances });

            dataGridView3.ContextMenuStrip = defectiveContextMenu;

            defectiveContextMenu.Opening += (s, e) =>
            {
                bool enable = false;
                if (dataGridView3.CurrentRow != null && dataGridView3.CurrentRow.DataBoundItem is DataRowView drv)
                {
                    var defRow = drv.Row as TOOLACCOUNTINGDataSet.DefectiveListsRow;
                    enable = defRow != null && !tOOLACCOUNTINGDataSet.ToolMovements.Any(m => m.SourceDocumentType == "Дефектная ведомость" && m.SourceDocumentID == defRow.DefectiveListID);
                }
                createWriteOff.Enabled = enable;
            };
        }

        private void DefectiveCreateWriteOff_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                var defRow = drv.Row as TOOLACCOUNTINGDataSet.DefectiveListsRow;
                if (defRow == null) return;

                AddMoving frm = new AddMoving();
                frm.InitializeWriteOffFromDefective(defRow.DefectiveListID);
                frm.MovementSaved += (s, ev) => { RefreshToolMovementsTables(); RefreshDefectiveListsTables(); };
                frm.ShowDialog();
            }
        }

        private void DefectiveShowBalances_Click(object sender, EventArgs e)
        {
            if (dataGridView3.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                var defRow = drv.Row as TOOLACCOUNTINGDataSet.DefectiveListsRow;
                if (defRow == null) return;

                tabControl1.SelectedTab = tabPage7; // Остатки
                OstatkiNumber.Text = defRow.NomenclatureNumber;
                textBox12_TextChanged(null, EventArgs.Empty); // Обновляем фильтр
            }
        }

        private void SetupReceivingContextMenu()
        {
            if (WorkshopsRequestsRequestsTable == null) return;
            receivingContextMenu = new ContextMenuStrip();
            var createMove = new ToolStripMenuItem("Создать перемещение на основании");
            createMove.Click += (s, e) =>
            {
                if (WorkshopsRequestsRequestsTable.CurrentRow?.DataBoundItem is DataRowView drvReq)
                {
                    int reqId = Convert.ToInt32(drvReq["ReceivingRequestID"]);
                    AddMoving frm = new AddMoving();
                    frm.InitializeFromRequest(reqId, "Перемещение");
                    frm.ShowDialog();
                }
            };
            var createAdd = new ToolStripMenuItem("Создать приход на основании");
            createAdd.Click += (s, e) =>
            {
                if (WorkshopsRequestsRequestsTable.CurrentRow?.DataBoundItem is DataRowView drvReq)
                {
                    int reqId = Convert.ToInt32(drvReq["ReceivingRequestID"]);
                    AddMoving frm = new AddMoving();
                    frm.InitializeFromRequest(reqId, "Приход");
                    frm.ShowDialog();
                }
            };
            receivingContextMenu.Items.AddRange(new ToolStripItem[] { createMove, createAdd });

            // пункт меню «Сформировать отчёт»
            var createReport = new ToolStripMenuItem("Сформировать отчёт");
            createReport.Click += (s, e) =>
            {
                if (WorkshopsRequestsRequestsTable.CurrentRow?.DataBoundItem is DataRowView drvReq)
                {
                    var reqRow = drvReq.Row as TOOLACCOUNTINGDataSet.ReceivingRequests1Row;
                    if (reqRow == null) return;

                    var detailsRows = tOOLACCOUNTINGDataSet.ReceivingRequestsContent1.Where(r => r.ReceivingRequestID == reqRow.ReceivingRequestID);
                    if (!detailsRows.Any())
                    {
                        MessageBox.Show("У выбранной заявки нет содержания.", "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    System.Data.DataTable dt = detailsRows.CopyToDataTable();

                    new Excel().ExportReceivingRequestInj(
                        reqRow.ReceivingRequestID,
                        reqRow.PlannedDate,
                        reqRow.ReceivingRequestDate,
                        reqRow.Reason,
                        reqRow.Status,
                        dt);
                }
            };

            receivingContextMenu.Items.Add(createReport);

            WorkshopsRequestsRequestsTable.ContextMenuStrip = receivingContextMenu;
        }

        private void SetupMovementsContextMenu()
        {
            movementsContextMenu = new ContextMenuStrip();
            var postItem = new ToolStripMenuItem("Провести");
            postItem.Click += (s, e) => { WriteOff_Click(s, e); };
            var showNomenBalances = new ToolStripMenuItem("Остатки по номенклатуре");
            showNomenBalances.Click += (s, e) =>
            {
                if (dataGridView2.CurrentRow?.DataBoundItem is DataRowView dvr)
                {
                    var mvRow = dvr.Row as TOOLACCOUNTINGDataSet.ToolMovementsRow;
                    if (mvRow == null) return;
                    tabControl1.SelectedTab = tabPage7;
                    OstatkiNumber.Text = mvRow.NomenclatureNumber;
                    textBox12_TextChanged(null, EventArgs.Empty);
                }
            };
            var showToBalances = new ToolStripMenuItem("Остатки склада получателя");
            showToBalances.Click += (s, e) => ShowStorageBalances(true);
            var showFromBalances = new ToolStripMenuItem("Остатки склада отправителя");
            showFromBalances.Click += (s, e) => ShowStorageBalances(false);

            movementsContextMenu.Items.AddRange(new ToolStripItem[] { postItem, showNomenBalances, showToBalances, showFromBalances });

            dataGridView2.ContextMenuStrip = movementsContextMenu;

            movementsContextMenu.Opening += (s, e) =>
            {
                bool enablePost = false;
                if (dataGridView2.CurrentRow?.DataBoundItem is DataRowView dvr)
                {
                    var mvRow = dvr.Row as TOOLACCOUNTINGDataSet.ToolMovementsRow;
                    enablePost = mvRow != null && !mvRow.IsPosted;
                }
                postItem.Enabled = enablePost;
            };
        }

        private void ShowStorageBalances(bool isTo)
        {
            if (dataGridView2.CurrentRow?.DataBoundItem is DataRowView dvr)
            {
                var mvRow = dvr.Row as TOOLACCOUNTINGDataSet.ToolMovementsRow;
                if (mvRow == null) return;
                int storageId = isTo ? mvRow.ToStorageID : mvRow.FromStorageID;
                tabControl1.SelectedTab = tabPage7;
                textBox7.Text = storageId.ToString(); // поле склада в поиске остатков
                textBox12_TextChanged(null, EventArgs.Empty);
            }
        }
        #endregion

        #region Excel reports
        /// <summary>
        /// Создаёт копию исходной таблицы и добавляет к ней колонку "FullName", если в таблице присутствует поле "NomenclatureNumber".
        /// Колонка ставится сразу после номера номенклатуры.
        /// </summary>
        private System.Data.DataTable PrepareForExport(System.Data.DataTable source)
        {
            if (source == null) return null;

            var dt = source.Copy();

            // Если таблица не содержит номера номенклатуры – ничего не добавляем
            if (!dt.Columns.Contains("NomenclatureNumber")) return dt;

            // Добавляем колонку с полным наименованием при необходимости
            if (!dt.Columns.Contains("FullName"))
            {
                dt.Columns.Add("FullName", typeof(string));
            }

            // Заполняем её
            var nomenDict = tOOLACCOUNTINGDataSet.NomenclatureView
                .ToDictionary(n => n.NomenclatureNumber, n => n.FullName);

            foreach (System.Data.DataRow row in dt.Rows)
            {
                var num = row["NomenclatureNumber"]?.ToString();
                if (!string.IsNullOrEmpty(num) && nomenDict.TryGetValue(num, out var name))
                {
                    row["FullName"] = name;
                }
            }

            // Перемещаем колонку сразу после номера номенклатуры
            dt.Columns["FullName"].SetOrdinal(dt.Columns["NomenclatureNumber"].Ordinal + 1);

            return dt;
        }

        private void ExportTable(System.Data.DataTable table)
        {
            if (table == null || table.Rows.Count == 0)
            {
                NotificationService.Notify("Экспорт", "Нет данных для экспорта.", ToolTipIcon.Info);
                return;
            }

            try
            {
                new Excel().Export(table); // без сохранения, сразу открывается Excel
                NotificationService.Notify("Экспорт", "Отчёт открыт в Excel.", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReportBalances_Click(object sender, EventArgs e)
        {
            try
            {
                var table = PrepareForExport(tOOLACCOUNTINGDataSet.Balances);
                new Excel().ExportBalancesInj(table, null); // инженерная форма
                NotificationService.Notify("Экспорт", "Ведомость открыта в Excel.", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReportDefective_Click(object sender, EventArgs e)
        {
            var table = PrepareForExport(tOOLACCOUNTINGDataSet.DefectiveLists);
            if (table == null || table.Rows.Count == 0)
            {
                NotificationService.Notify("Экспорт", "Нет данных для экспорта.", ToolTipIcon.Info);
                return;
            }
            try
            {
                new Excel().ExportDefectiveInj(table, null);
                NotificationService.Notify("Экспорт", "Отчёт открыт в Excel.", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReportApplications_Click(object sender, EventArgs e)
        {
            var headers = tOOLACCOUNTINGDataSet.ReceivingRequests1.Copy();
            var contents = tOOLACCOUNTINGDataSet.ReceivingRequestsContent1.Copy();
            if (headers == null || headers.Rows.Count == 0)
            {
                NotificationService.Notify("Экспорт", "Нет данных для экспорта.", ToolTipIcon.Info);
                return;
            }
            try
            {
                new Excel().ExportReceivingRequestsSummaryInj(headers, contents);
                NotificationService.Notify("Экспорт", "Сводный отчёт открыт в Excel.", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        private void button8_Click_1(object sender, EventArgs e)
        {
            AddMoving addMoving = new AddMoving();
            addMoving.MovementSaved += (s, args) => { RefreshToolMovementsTables(); OstatkiResetSearch(); };
            addMoving.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DefAdd defAdd = new DefAdd();
            defAdd.DefectiveSaved += (s, args) => RefreshDefectiveListsTables();
            defAdd.ShowDialog();
        }

        private void CreateWorkshop_Click(object sender, EventArgs e)
        {
            AddApplications addApplications = new AddApplications(tOOLACCOUNTINGDataSet);
            // Подписываемся на событие сохранения для обновления таблиц
            addApplications.RequestSaved += (s, args) => RefreshReceivingRequestsTables();
            addApplications.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                new Excel().ExportBalancesForm(tOOLACCOUNTINGDataSet); // открываем Excel без сохранения
                NotificationService.Notify("Экспорт", "Ведомость открыта в Excel.", ToolTipIcon.Info);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка экспорта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #region Проведение движений

        /// <summary>
        /// Обновляет доступность кнопки «Провести» в зависимости от выбранного документа.
        /// </summary>
        private void UpdateWriteOffButtonState()
        {
            if (dataGridView2.CurrentRow == null || dataGridView2.CurrentRow.IsNewRow)
            {
                WriteOff.Enabled = false;
                return;
            }

            if (!(dataGridView2.CurrentRow.DataBoundItem is DataRowView drv))
            {
                WriteOff.Enabled = false;
                return;
            }

            var moveRow = drv.Row as TOOLACCOUNTINGDataSet.ToolMovementsRow;
            WriteOff.Enabled = moveRow != null && !moveRow.IsPosted;
        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            UpdateWriteOffButtonState();
        }

        private void WriteOff_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null) return;
            if (!(dataGridView2.CurrentRow.DataBoundItem is DataRowView drv)) return;

            var moveRow = drv.Row as TOOLACCOUNTINGDataSet.ToolMovementsRow;
            if (moveRow == null || moveRow.IsPosted) return;

            if (PostMovement(moveRow))
            {
                NotificationService.Notify("Успех", "Документ проведён.", ToolTipIcon.Info);
                RefreshToolMovementsTables();
                UpdateWriteOffButtonState();
            }
        }

        /// <summary>
        /// Проводит выбранное движение, пересчитывая остатки.
        /// </summary>
        private bool PostMovement(TOOLACCOUNTINGDataSet.ToolMovementsRow row)
        {
            try
            {
                string movementName = row.MovementTypeID;
                string nomenNumber = row.NomenclatureNumber;
                int qty = row.Quantity;
                decimal price = row.Price;

                int fromId = row.FromStorageID;
                int toId = row.ToStorageID;

                // Проверка и перерасчёт остатков
                if (movementName == "Списание")
                {
                    int available = tOOLACCOUNTINGDataSet.Balances.Where(b => b.StorageID == fromId && b.NomenclatureNumber == nomenNumber).Sum(b => b.Quantity);
                    if (qty > available)
                    {
                        NotificationService.Notify("Ошибка", $"Недостаточно остатка для проведения. Доступно {available}, требуется {qty}.", ToolTipIcon.Error);
                        return false;
                    }

                    // Списание со склада-отправителя
                    var balFrom = tOOLACCOUNTINGDataSet.Balances.FirstOrDefault(b => b.StorageID == fromId && b.NomenclatureNumber == nomenNumber);
                    if (balFrom != null) balFrom.Quantity -= qty;

                    // Приход на склад списанного инструмента (12)
                    int writeOffStorageId = 12;
                    var balDest = tOOLACCOUNTINGDataSet.Balances.FirstOrDefault(b => b.StorageID == writeOffStorageId && b.NomenclatureNumber == nomenNumber);
                    if (balDest != null) balDest.Quantity += qty;
                    else
                    {
                        int newBalId = tOOLACCOUNTINGDataSet.Balances.Count == 0 ? 1 : tOOLACCOUNTINGDataSet.Balances.Max(r => r.BalanceID) + 1;
                        var newBal = tOOLACCOUNTINGDataSet.Balances.NewBalancesRow();
                        newBal.BalanceID = newBalId;
                        newBal.NomenclatureNumber = nomenNumber;
                        newBal.StorageID = writeOffStorageId;
                        newBal.BalanceDate = DateTime.Now;
                        newBal.BatchNumber = row.BatchNumber;
                        newBal.Price = price;
                        newBal.Quantity = qty;
                        if (newBal.Table.Columns.Contains("Account")) newBal["Account"] = "Списание";
                        tOOLACCOUNTINGDataSet.Balances.AddBalancesRow(newBal);
                    }

                    row.ToStorageID = writeOffStorageId; // фиксируем получателя
                }
                else if (movementName == "Перемещение")
                {
                    // Проверяем остаток на складе-отправителе
                    int available = tOOLACCOUNTINGDataSet.Balances.Where(b => b.StorageID == fromId && b.NomenclatureNumber == nomenNumber).Sum(b => b.Quantity);
                    if (qty > available)
                    {
                        NotificationService.Notify("Ошибка", $"Недостаточно остатка для перемещения. Доступно {available}, требуется {qty}.", ToolTipIcon.Error);
                        return false;
                    }

                    var balFrom = tOOLACCOUNTINGDataSet.Balances.FirstOrDefault(b => b.StorageID == fromId && b.NomenclatureNumber == nomenNumber);
                    if (balFrom != null) balFrom.Quantity -= qty;

                    var balTo = tOOLACCOUNTINGDataSet.Balances.FirstOrDefault(b => b.StorageID == toId && b.NomenclatureNumber == nomenNumber);
                    if (balTo != null) balTo.Quantity += qty;
                    else
                    {
                        int newBalId = tOOLACCOUNTINGDataSet.Balances.Count == 0 ? 1 : tOOLACCOUNTINGDataSet.Balances.Max(r => r.BalanceID) + 1;
                        var newBal = tOOLACCOUNTINGDataSet.Balances.NewBalancesRow();
                        newBal.BalanceID = newBalId;
                        newBal.NomenclatureNumber = nomenNumber;
                        newBal.StorageID = toId;
                        newBal.BalanceDate = DateTime.Now;
                        newBal.BatchNumber = row.BatchNumber;
                        newBal.Price = price;
                        newBal.Quantity = qty;
                        if (newBal.Table.Columns.Contains("Account")) newBal["Account"] = "Перемещение";
                        tOOLACCOUNTINGDataSet.Balances.AddBalancesRow(newBal);
                    }
                }

                // Обновляем базы
                balancesTableAdapter.Update(tOOLACCOUNTINGDataSet.Balances);

                row.IsPosted = true;
                row.Executor = Environment.UserName;
                row.LastUpdated = DateTime.Now;

                toolMovementsTableAdapter.Update(tOOLACCOUNTINGDataSet.ToolMovements);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.RejectChanges();
                MessageBox.Show($"Ошибка проведения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        #endregion

        // ======== ЗАГЛУШКИ УДАЛЁННЫХ МЕТОДОВ (для сохранения совместимости) ========
        private void OstatkiResetSearch()
        {
            try
            {
                textBox12.Text = string.Empty;
                textBox7.Text = string.Empty;
                OstatkiNumber.Text = string.Empty;
                textBox16.Text = string.Empty;
                balancesBindingSource.RemoveFilter();
            }
            catch { }
        }

        private void NomenCreateApplication_Click(object sender, EventArgs e)
        {
            // Создать заявку на получение инструмента из выбранных номенклатур
            var selectedRows = NomenTable.SelectedRows.Count > 0 ? NomenTable.SelectedRows.Cast<DataGridViewRow>()
                                                                : new[] { NomenTable.CurrentRow };
            var nomenNumbers = selectedRows
                .Where(r => r?.DataBoundItem is DataRowView)
                .Select(r => ((DataRowView)r.DataBoundItem)["NomenclatureNumber"].ToString())
                .Where(n => !string.IsNullOrWhiteSpace(n))
                .Distinct()
                .ToList();

            if (nomenNumbers.Count == 0) return;

            var form = new AddApplications(tOOLACCOUNTINGDataSet, FormMode.Add);
            foreach (var num in nomenNumbers)
                form.AddNomenclature(num);

            form.RequestSaved += (s, args) => RefreshReceivingRequestsTables();
            form.ShowDialog();
        }

        private void NomenShowOstatki_Click(object sender, EventArgs e)
        {
            if (NomenTable.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                string nomenNumber = drv["NomenclatureNumber"].ToString();
                tabControl1.SelectedTab = tabPage7;
                OstatkiNumber.Text = nomenNumber;
                OstatkiNumber.Focus();
            }
        }

        private void NomenCreateDefective_Click(object sender, EventArgs e)
        {
            if (NomenTable.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                string nomenNumber = drv["NomenclatureNumber"].ToString();
                var balances = tOOLACCOUNTINGDataSet.Balances
                    .Where(b => b.NomenclatureNumber == nomenNumber && b.Quantity > 0)
                    .OrderByDescending(b => b.BalanceDate)
                    .ToList();

                if (balances.Count == 0)
                {
                    MessageBox.Show("По выбранной номенклатуре отсутствуют остатки.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (balances.Count == 1)
                {
                    OpenDefectiveForBalance(nomenNumber, balances[0]);
                    return;
                }

                var selectionMenu = new ContextMenuStrip();
                foreach (var bal in balances)
                {
                    string text = $"Склад {bal.StorageID}, Партия {bal.BatchNumber}, Кол-во {bal.Quantity}";
                    var item = new ToolStripMenuItem(text) { Tag = bal };
                    item.Click += (s, args) =>
                    {
                        selectionMenu.Close();
                        OpenDefectiveForBalance(nomenNumber, (TOOLACCOUNTINGDataSet.BalancesRow)((ToolStripMenuItem)s).Tag);
                    };
                    selectionMenu.Items.Add(item);
                }
                var pos = NomenTable.PointToClient(Cursor.Position);
                selectionMenu.Show(NomenTable, pos);
            }
        }

        private void NomenCreateMoving_Click(object sender, EventArgs e)
        {
            if (NomenTable.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                string nomenNumber = drv["NomenclatureNumber"].ToString();
                var balanceRow = tOOLACCOUNTINGDataSet.Balances
                    .Where(b => b.NomenclatureNumber == nomenNumber && b.Quantity > 0)
                    .OrderByDescending(b => b.BalanceDate)
                    .FirstOrDefault();
                if (balanceRow == null)
                {
                    MessageBox.Show("По выбранной номенклатуре отсутствуют остатки.", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int storageId = balanceRow.StorageID;
                string batch = balanceRow.BatchNumber;
                decimal price = balanceRow.Price;

                var form = new AddMoving();
                form.Prefill(nomenNumber, storageId, batch, price, true);
                form.MovementSaved += (s, args) => { RefreshToolMovementsTables(); OstatkiResetSearch(); };
                form.ShowDialog();
            }
        }

        private void OstatkiCreateDefective_Click(object sender, EventArgs e)
        {
            if (OstatkiTable.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                string nomenNumber = drv["NomenclatureNumber"].ToString();
                int storageId = Convert.ToInt32(drv["StorageID"]);
                string batch = drv["BatchNumber"].ToString();
                decimal price = Convert.ToDecimal(drv["Price"]);
                var storageRow = tOOLACCOUNTINGDataSet.Storages.FirstOrDefault(s => s.StorageID == storageId);
                int workshopId = storageRow != null ? storageRow.WorkshopID : 0;
                var form = new DefAdd();
                form.Prefill(nomenNumber, workshopId, price, batch);
                form.DefectiveSaved += (s, args) => RefreshDefectiveListsTables();
                form.ShowDialog();
            }
        }

        private void OstatkiCreateMoving_Click(object sender, EventArgs e)
        {
            if (OstatkiTable.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                string nomenNumber = drv["NomenclatureNumber"].ToString();
                int storageId = Convert.ToInt32(drv["StorageID"]);
                string batch = drv["BatchNumber"].ToString();
                decimal price = Convert.ToDecimal(drv["Price"]);
                var form = new AddMoving();
                form.Prefill(nomenNumber, storageId, batch, price, true);
                form.MovementSaved += (s, args) => { RefreshToolMovementsTables(); OstatkiResetSearch(); };
                form.ShowDialog();
            }
        }

        private void WorkshopCreateApplication_Click(object sender, EventArgs e)
        {
            if (WorkshopsMain.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                int workshopId = Convert.ToInt32(drv["WorkshopID"]);
                var form = new AddApplications(tOOLACCOUNTINGDataSet, FormMode.Add);
                form.PreselectWorkshop(workshopId);
                form.RequestSaved += (s, args) => RefreshReceivingRequestsTables();
                form.ShowDialog();
            }
        }

        private void StorageCreateMovingTo_Click(object sender, EventArgs e)
        {
            if (StoragesTable.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                int storageId = Convert.ToInt32(drv["StorageID"]);
                var form = new AddMoving();
                form.Prefill(string.Empty, null, string.Empty, 0m, true, storageId);
                form.MovementSaved += (s, args) => { RefreshToolMovementsTables(); OstatkiResetSearch(); };
                form.ShowDialog();
            }
        }

        private void StorageShowOstatki_Click(object sender, EventArgs e)
        {
            if (StoragesTable.CurrentRow?.DataBoundItem is DataRowView drv)
            {
                int storageId = Convert.ToInt32(drv["StorageID"]);
                tabControl1.SelectedTab = tabPage7;
                textBox7.Text = storageId.ToString();
                textBox7.Focus();
            }
        }

        private void OpenDefectiveForBalance(string nomenNumber, TOOLACCOUNTINGDataSet.BalancesRow balanceRow)
        {
            int storageId = balanceRow.StorageID;
            string batch = balanceRow.BatchNumber;
            decimal price = balanceRow.Price;
            var storageRow = tOOLACCOUNTINGDataSet.Storages.FirstOrDefault(s => s.StorageID == storageId);
            int workshopId = storageRow != null ? storageRow.WorkshopID : 0;

            var form = new DefAdd();
            form.Prefill(nomenNumber, workshopId, price, batch);
            form.DefectiveSaved += (s, args) => RefreshDefectiveListsTables();
            form.ShowDialog();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(textBox12.Text)) parameters.Add(new SearchParameter("BalanceID", Convert.ToInt32(textBox12.Text), true));
            if (!string.IsNullOrEmpty(OstatkiNumber.Text)) parameters.Add(new SearchParameter("NomenclatureNumber", OstatkiNumber.Text, true));
            if (!string.IsNullOrEmpty(textBox7.Text)) parameters.Add(new SearchParameter("StorageID", Convert.ToInt32(textBox7.Text), true));
            if (!string.IsNullOrEmpty(textBox16.Text)) parameters.Add(new SearchParameter("ButchNumber", textBox16.Text, true));

            try
            {
                string filter = Search.Filter(parameters);
                OstatkiTable.SuspendLayout();
                balancesBindingSource.Filter = filter;
                OstatkiTable.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OstatkiResetButton_Click(object sender, EventArgs e)
        {
            OstatkiResetSearch();
        }

        private void Otchet_Click(object sender, EventArgs e)
        {

        }
        // ======== КОНЕЦ ЗАГЛУШЕК ========
    }

}

