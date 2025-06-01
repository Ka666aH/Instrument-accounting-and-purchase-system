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
    public partial class Klad : Form
    {
        LoginForm login;
        bool changeUser = false;
        public Klad(LoginForm _login)
        {
            InitializeComponent();
            login = _login;
        }

        private void Klad_Load(object sender, EventArgs e)
        {
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NonemclatureView". При необходимости она может быть перемещена или удалена.
            this.nonemclatureViewTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NonemclatureView);

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
            //switch (tableName)
            //{
            //    case "Groups":

            //        try
            //        {
            //            groupsTableAdapter.Update(tOOLACCOUNTINGDataSet.Groups);
            //            InjLevel1.SelectedTab = InjGroupsPage;
            //            return null;
            //        }
            //        catch (Exception ex)
            //        {
            //            return ex.Message;
            //        }

            //    case "Nomenclature":

            //        try
            //        {
            //            nomenclatureTableAdapter.Update(tOOLACCOUNTINGDataSet.Nomenclature);
            //            nonemclatureViewTableAdapter.Fill(tOOLACCOUNTINGDataSet.NonemclatureView);
            //            InjLevel1.SelectedTab = InjNomenPage;
            //            return null;
            //        }
            //        catch (Exception ex)
            //        {
            //            return ex.Message;
            //        }

            //    case "AnalogTools":

            //        //обновление таблиц аналогов
            //        try
            //        {
            //            analogToolsTableAdapter.Update(tOOLACCOUNTINGDataSet.AnalogTools);
            //            analogToolsTableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools);
            //            analogTools1TableAdapter.Fill(tOOLACCOUNTINGDataSet.AnalogTools1);
            //            dataTable1TableAdapter.Fill(tOOLACCOUNTINGDataSet.DataTable1);
            //            InjLevel1.SelectedTab = InjAnalogPage;
            //            return null;
            //        }
            //        catch (Exception ex)
            //        {
            //            return ex.Message;
            //        }

            //    case "Suppliers":

            //        try
            //        {
            //            suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
            //            InjLevel1.SelectedTab = InjProvidersPage;
            //            return null;
            //        }
            //        catch (Exception ex)
            //        {
            //            return ex.Message;
            //        }

            //    default: return "Не найдена таблица.";
            //}
            return null; // это надо убрать
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
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #region storages
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var parameters = new List<SearchParameter>();
            if (!string.IsNullOrEmpty(textBox2.Text)) parameters.Add(new SearchParameter("StorageID", textBox2.Text, true));
            if (!string.IsNullOrEmpty(textBox4.Text)) parameters.Add(new SearchParameter("Name", textBox4.Text, false));
            if (!string.IsNullOrEmpty(textBox5.Text)) parameters.Add(new SearchParameter("WorkshopID", textBox5.Text, true));
            try
            {
                string filter = Search.Filter(parameters);
                dataGridView4.SuspendLayout();
                storagesBindingSource.Filter = filter;
                dataGridView4.ResumeLayout();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Ошибка преобразования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion



        private void CreateWorkshop_Click(object sender, EventArgs e)
        {
            WorkshopForm workshopForm = new WorkshopForm(tOOLACCOUNTINGDataSet, workshopsTableAdapter);
            workshopForm.ShowDialog();
        }
        public void SetWorkshopsButtonsState()
        {
            bool state = WorkshopsMain.CurrentRow != null && !string.IsNullOrEmpty(WorkshopsMain.CurrentRow.Cells[0].Value.ToString());
            AlterWorkshop.Enabled = state;
            DeleteWorkshop.Enabled = state;
        }
        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            SetWorkshopsButtonsState();
        }

        #endregion



    }
}
