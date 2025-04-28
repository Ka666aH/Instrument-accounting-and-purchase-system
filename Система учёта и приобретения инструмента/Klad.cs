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
    }
}
