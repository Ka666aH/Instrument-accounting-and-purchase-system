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
    public partial class Klad: Form
    {
        LoginForm login;
        bool changeUser=false;
        public Klad(LoginForm _login)
        {
            InitializeComponent();
            login = _login;
        }

        private void Klad_Load(object sender, EventArgs e)
        {

            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NonemclatureView". При необходимости она может быть перемещена или удалена.
            this.nonemclatureViewTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NonemclatureView);

            this.WindowState = FormWindowState.Maximized;
        }

        private void Klad_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(changeUser)
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
        public void ImportRefresh(string tableName)
        {
            //switch (tableName)
            //{
            //    case "Groups":

            //        groupsTableAdapter.Update(tOOLACCOUNTINGDataSet.Groups);
            //        InjLevel1.SelectedTab = InjGroupsPage;

            //        break;
            //    case "Nomenclature":

            //        nomenclatureTableAdapter.Update(tOOLACCOUNTINGDataSet.Nomenclature);
            //        nonemclatureViewTableAdapter.Fill(tOOLACCOUNTINGDataSet.NonemclatureView);
            //        InjLevel1.SelectedTab = InjNomenPage;

            //        break;
            //    case "AnalogTools":

            //        //обновление таблиц аналогов
            //        InjLevel1.SelectedTab = InjAnalogPage;

            //        break;
            //    case "Suppliers":

            //        suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
            //        InjLevel1.SelectedTab = InjProvidersPage;

            //        break;
            //}
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
    }
}
