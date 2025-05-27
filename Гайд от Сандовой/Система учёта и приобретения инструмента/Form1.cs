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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Nomenclature1". При необходимости она может быть перемещена или удалена.
            this.nomenclature1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Nomenclature1);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ToolGroups1". При необходимости она может быть перемещена или удалена.
            this.toolGroups1TableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ToolGroups1);

        }
    }
}
