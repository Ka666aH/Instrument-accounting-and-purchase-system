using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_учёта_и_приобретения_инструмента
{
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

        private void Inj_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequests". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequests);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureLogs". При необходимости она может быть перемещена или удалена.
            this.nomenclatureLogsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureLogs);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.AnalogTools". При необходимости она может быть перемещена или удалена.
            this.analogToolsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.AnalogTools);
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
    }
}
