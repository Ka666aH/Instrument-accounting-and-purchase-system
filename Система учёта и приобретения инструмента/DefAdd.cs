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

        private void DefAdd_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureView". При необходимости она может быть перемещена или удалена.
            this.nomenclatureViewTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureView);

        }
    }
}
