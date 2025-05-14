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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void ExitLF_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            UsersLF.Text = Environment.UserName;
        }

        private void LoginLFKLAD_Click(object sender, EventArgs e)
        {
            Klad klad = new Klad(this);
            Hide();
            klad.ShowDialog();
        }

        private void LoginLFINJ_Click(object sender, EventArgs e)
        {
            Inj inj = new Inj(this);
            Hide();
            inj.ShowDialog();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if(this.Visible)
            //{
            //    e.Cancel = true;
            //    Show();
            //}

        }
    }
}
