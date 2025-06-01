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
    public partial class AnalogForm : Form
    {
        TOOLACCOUNTINGDataSet toolAccounting;
        AnalogTools1TableAdapter tableAdapter;
        FormMode mode;
        TOOLACCOUNTINGDataSet.AnalogTools1Row editRow;
        public AnalogForm(
            TOOLACCOUNTINGDataSet _toolAccounting,
            AnalogTools1TableAdapter _tableAdapter,
            FormMode _mode = FormMode.Add,
            TOOLACCOUNTINGDataSet.AnalogTools1Row _editRow = null)
        {
            InitializeComponent();
            toolAccounting = _toolAccounting;
            tableAdapter = _tableAdapter;
            mode = _mode;
            editRow = _editRow;
        }

        private void AnalogForm_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.Edit && editRow != null)
            {
                AnalogFormOrigiinalNumber.Text = editRow.OriginalNomenclatureNumber.ToString();
                AnalogFormAnalogNumber.Text = editRow.AnalogNomenclatureNumber.ToString();
            }
        }

        private void AnalogFormName_TextChanged(object sender, EventArgs e)
        {

        }

        private void AnalogFormOrigiinalName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AnalogFormOrigiinalNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void AnalogFormAnalogName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AnalogFormAnalogNumber_TextChanged(object sender, EventArgs e)
        {

        }
        private void AnalogFormSave_Click(object sender, EventArgs e)
        {

        }

        private void AnalogFormSaveClose_Click(object sender, EventArgs e)
        {

        }

        private void AnalogFormClose_Click(object sender, EventArgs e)
        {

        }
    }
}
