using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSExcel = Microsoft.Office.Interop.Excel;

namespace Система_учёта_и_приобретения_инструмента
{
    public class Excel
    {
        public void Import()
        {
            
        }
        public void Export(System.Data.DataTable table, string path)
        {
            if (table == null) return;

            MSExcel.Application excelApp = null;
            try
            {
                excelApp = new MSExcel.Application();
                excelApp.Visible = false;
                var wb = excelApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                // Заголовки
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    ws.Cells[1, col + 1] = table.Columns[col].ColumnName;
                }

                // Данные
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        ws.Cells[row + 2, col + 1] = table.Rows[row][col];
                    }
                }

                wb.SaveAs(path);
                wb.Close();
            }
            finally
            {
                if (excelApp != null)
                {
                    excelApp.Quit();
                }
            }
        }
    }
}