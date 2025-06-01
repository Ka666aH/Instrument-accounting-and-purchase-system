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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
        NonemclatureViewTableAdapter nomenclatureViewAdapter = new NonemclatureViewTableAdapter();
        AutoCompleteStringCollection source = new AutoCompleteStringCollection();
        private void AnalogForm_Load(object sender, EventArgs e)
        {
            if (mode == FormMode.Edit && editRow != null)
            {
                AnalogFormOrigiinalNumber.Text = editRow.OriginalNomenclatureNumber.ToString();
                AnalogFormAnalogNumber.Text = editRow.AnalogNomenclatureNumber.ToString();
            }
            nomenclatureViewAdapter.Fill(toolAccounting.NonemclatureView);

            foreach (DataRow row in nomenclatureViewAdapter.GetData().Rows)
            {
                if (row.Table.Columns.Contains("FullName"))
                {
                    string fullName = row["FullName"]?.ToString().Trim() ?? "";
                    if (!string.IsNullOrEmpty(fullName))
                    {
                        source.Add(fullName);
                    }

                }
            }
            AnalogFormOrigiinalName.AutoCompleteCustomSource = source;
            AnalogFormAnalogName.AutoCompleteCustomSource = source;
        }

        private void AnalogFormOrigiinalName_Leave(object sender, EventArgs e)
        {
            FindNomenclatureNumber(sender as System.Windows.Forms.ComboBox, true);
        }

        private void AnalogFormAnalogName_Leave(object sender, EventArgs e)
        {
            FindNomenclatureNumber(sender as System.Windows.Forms.ComboBox, false);
        }

        private void FindNomenclatureNumber(System.Windows.Forms.ComboBox sender, bool isOriginal)
        {
            string selectedText = sender.Text;
            sender.Text = new List<string>(source.Cast<string>()).Where(x => x.ToLower() == selectedText.ToLower()).FirstOrDefault();
            var foundRow = nomenclatureViewAdapter.GetData().Select($"FullName = '{selectedText}'").FirstOrDefault();
            string nomenclatureNumber = foundRow["NomenclatureNumber"].ToString();
            if(isOriginal) AnalogFormOrigiinalNumber.Text = nomenclatureNumber;
            else AnalogFormAnalogNumber.Text = nomenclatureNumber;
        }

        private void AnalogFormOrigiinalNumber_TextChanged(object sender, EventArgs e)
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
            //if (!AllFieldsEmpty())
            //{
            //    DialogResult result = MessageBox.Show("Вы уверены, что закрыть форму? Все несохранённые данные будут потеряны.", "Подтверждение закрытия", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //    if (result == DialogResult.No) return;
            //}
            //Close();
        }


    }
}
