using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Система_учёта_и_приобретения_инструмента
{
    //не закрывается процесс EXCEL.EXE
    public partial class ImportForm : Form
    {
        Dictionary<string, string> tables = new Dictionary<string, string>
        {
            { "Groups","Группы инструментов" },
            { "Nomenclature","Номенклатура инструментов" },
            { "AnalogTools","Аналоги инструментов" },
            { "Workshops","Цеха" },
            { "Storages","Склады" },
            { "Suppliers","Поставщики" },
            { "Balances","Остатки" }
        };

        MSExcel.Application application;
        MSExcel.Workbook workbook;
        MSExcel.Worksheet worksheet;
        MSExcel.Range range;

        TOOLACCOUNTINGDataSet toolAccounting;
        public ImportForm(TOOLACCOUNTINGDataSet _toolAccounting)
        {
            InitializeComponent();
            ImportFormTable.Items.AddRange(tables.Values.ToArray());
            toolAccounting = _toolAccounting;
            Cursor.Current = Cursors.Default;
        }

        private void ImportFormSelectFileButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "(*.xls;*.xlsx)|*.xls;*.xlsx";
            openFileDialog1.Title = "Выберите файл Excel";
            openFileDialog1.FileName = string.Empty;
            openFileDialog1.Multiselect = false;
            if (openFileDialog1.ShowDialog() == DialogResult.OK) ImportFormFilePath.Text = openFileDialog1.FileName;
        }

        private void ImportFormFilePath_TextChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            application = new MSExcel.Application();
            workbook = application.Workbooks.Open(ImportFormFilePath.Text);
            ImportFormSheet.Items.Clear();
            AllowImport();
            ImportFormSheet.Enabled = true;
            foreach (Worksheet sheet in workbook.Worksheets)
            {
                ImportFormSheet.Items.Add(sheet.Name);
            }
            Cursor.Current = Cursors.Default;
        }

        private void ImportFormClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ImportFormSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowImport();
        }

        private void ImportFormTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            AllowImport();
        }

        private void AllowImport()
        {
            if (ImportFormSheet.SelectedItem != null && ImportFormTable.SelectedItem != null)
                ImportFormImportButton.Enabled = true;
            else ImportFormImportButton.Enabled = false;
        }

        private void ImportFormImport_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //int importedRows = 0;
            var data = new List<List<object>>();
            try
            {
                worksheet = workbook.Worksheets[ImportFormSheet.Text];
                range = worksheet.UsedRange;
                int rows = range.Rows.Count;
                int cols = range.Columns.Count;

                //получаем имя таблицы и определяем её
                var table = toolAccounting.Tables[tables.FirstOrDefault(x => x.Value == ImportFormTable.Text).Key];

                if (table.Columns.Count != cols) throw new Exception("Не совпадает количество столбцов в таблицах.");

                for (int row = 2; row <= rows; row++)
                {
                    var rowData = new List<object>();
                    for (int col = 1; col <= cols; col++)
                    {
                        var cell = range.Cells[row, col];
                        rowData.Add(cell.Value);
                        Marshal.ReleaseComObject(cell);
                    }
                    data.Add(rowData);
                }
                if (data.Count > 0)
                {
                    foreach (var rowItems in data)
                    {
                        DataRow newRow = table.NewRow();
                        for (int i = 0; i < rowItems.Count; i++)
                        {
                            if (i >= table.Columns.Count) throw new Exception("Количество столбцов в импортируемых данных превышает схему таблицы.");

                            // Преобразование типа данных при необходимости
                            object value = rowItems[i];
                            if (value != null && value.GetType() != table.Columns[i].DataType)
                            {
                                value = Convert.ChangeType(value, table.Columns[i].DataType);
                            }
                            newRow[i] = value ?? DBNull.Value;
                        }
                        table.Rows.Add(newRow);
                    }
                    //table.AcceptChanges();
                    //toolAccounting.AcceptChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка импорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                NotificationService.Notify("Импорт", $"В таблицу \"{ImportFormTable.Text}\" добавлено строк: {data.Count}.", ToolTipIcon.Info);
                ImportFormSheet.SelectedIndex = -1;
                ImportFormTable.SelectedIndex = -1;
                Cursor.Current = Cursors.Arrow;
                ReleaseComObject(range);
                ReleaseComObject(worksheet);
            }
        }

        private void ImportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workbook != null)
            {
                workbook.Close(false);
                ReleaseComObject(workbook);
            }
            application.Quit();
            ReleaseComObject(application);

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        private void ReleaseComObject(object obj)
        {
            try
            {
                if (obj != null && Marshal.IsComObject(obj))
                {
                    Marshal.ReleaseComObject(obj);
                }
            }
            catch { }
            finally
            {
                obj = null;
            }
        }
    }
}
