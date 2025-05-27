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
    public partial class DefAdd : Form
    {
        public DefAdd()
        {
            InitializeComponent();
        }

        private void CloseNewApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
