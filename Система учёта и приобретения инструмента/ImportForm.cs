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
    public partial class ImportForm : Form
    {
        enum Forms
        {
            Inj,
            Klad
        }

        Forms owner;

        Dictionary<string, string> tables;

        MSExcel.Application application;
        MSExcel.Workbook workbook;
        MSExcel.Worksheet worksheet;
        MSExcel.Range range;

        TOOLACCOUNTINGDataSet toolAccounting;

        List<string> importErrorReport = new List<string>();
        public ImportForm(TOOLACCOUNTINGDataSet _toolAccounting)
        {
            InitializeComponent();
            toolAccounting = _toolAccounting;
            Cursor.Current = Cursors.Default;
        }

        private void ImportForm_Load(object sender, EventArgs e)
        {
            DefineOwner();
            DefineAvalibleTables();
        }

        public void DefineOwner()
        {
            switch (Owner.GetType().Name)
            {
                case "Inj": owner = Forms.Inj; break;
                case "Klad": owner = Forms.Klad; break;
                default: throw new Exception("Вызов с неизвестной формы.");
            }
        }

        public void DefineAvalibleTables()
        {
            if (owner == Forms.Inj)
            {
                tables = new Dictionary<string, string>
        {
            { "Groups","Группы инструментов" },
            { "Nomenclature","Номенклатура инструментов" },
            { "AnalogTools","Аналоги инструментов" },
            { "Suppliers","Поставщики" }
        };
            }

            if (owner == Forms.Klad)
            {
                tables = new Dictionary<string, string>
        {
            { "Workshops","Цеха" },
            { "Storages","Склады" },
            { "Balances","Остатки" }
        };
            }

            ImportFormTable.Items.AddRange(tables.Values.ToArray());
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

        int importedRows = 0;
        int errorRows = 0;
        string tableName = null;
        private void ImportFormImport_Click(object sender, EventArgs e)
        {
            Import();
            if (importedRows > 0) UpdateMainForm(tableName);
            NotificationService.Notify("Импорт", $"В таблицу \"{ImportFormTable.Text}\" закончен.\nДобавлено строк: {importedRows}.\nСтрок с ошибками: {errorRows}.", ToolTipIcon.Info);
            ImportFormSheet.SelectedIndex = -1;
            ImportFormTable.SelectedIndex = -1;
            if (errorRows > 0) MessageBox.Show(string.Join("\n", importErrorReport), "Строки с ошибками", MessageBoxButtons.OK, MessageBoxIcon.Error);
            importedRows = 0;
            errorRows = 0;
            importErrorReport.Clear();
            Cursor.Current = Cursors.Default;
        }

        public void Import(int startRow = 2)
        {
            Cursor.Current = Cursors.WaitCursor;
            int currentRow = -1;
            try
            {
                worksheet = workbook.Worksheets[ImportFormSheet.Text];
                range = worksheet.UsedRange;
                object[,] allData = range.Value2;
                int rows = allData.GetLength(0);
                int cols = allData.GetLength(1);

                //получаем имя таблицы и определяем её
                tableName = tables.FirstOrDefault(x => x.Value == ImportFormTable.Text).Key;
                var table = toolAccounting.Tables[tableName];

                if (table.Columns.Count != cols)
                    throw new Exception($"Не совпадает количество столбцов. В таблице: {table.Columns.Count}, в файле: {cols}.");

                for (int row = startRow; row <= rows; row++)
                {
                    DataRow newRow = table.NewRow();
                    bool rowHasData = false;
                    for (int col = 1; col <= cols; col++)
                    {
                        object value = allData[row, col];

                        // Пропускаем пустые строки
                        if (value == null && col == 1) break;

                        if (value != null)
                        {
                            rowHasData = true;
                            //Безопасное преобразование типов
                            try
                            {
                                if (value.GetType() != table.Columns[col - 1].DataType)
                                {
                                    value = Convert.ChangeType(value, table.Columns[col - 1].DataType);
                                }
                                newRow[col - 1] = value;
                            }
                            catch { }
                        }
                        else
                        {
                            currentRow = row;
                            newRow[col - 1] = DBNull.Value;
                        }

                    }
                    if (rowHasData)
                    {
                        table.Rows.Add(newRow);
                        importedRows++;
                    }
                }
            }
            catch (Exception ex)
            {
                importErrorReport.Add($"Строка {currentRow}: {ex.Message}");
                errorRows++;
                Import(currentRow + 1);
            }
            finally
            {
                ReleaseComObject(range);
                ReleaseComObject(worksheet);
            }
        }

        public void UpdateMainForm(string tableName)
        {
            if (tableName == null) return;
            switch (owner)
            {
                case Forms.Inj:

                    Inj injForm = Owner as Inj;
                    injForm.ImportRefresh(tableName);

                    break;
                case Forms.Klad:

                    Klad kladForm = Owner as Klad;
                    kladForm.ImportRefresh(tableName);

                    break;
                default: throw new Exception("Вызов с неизвестной формы.");
            }
        }

        private void ImportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (workbook != null)
            {
                workbook.Close(false);
                ReleaseComObject(workbook);
                workbook = null;
            }
            if (application != null)
            {
                application.Quit();
                ReleaseComObject(application);
                application = null;
            }

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
                    while (Marshal.ReleaseComObject(obj) > 0) { };
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