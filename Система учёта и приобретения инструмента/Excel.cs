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
        // Сопоставление технических имён столбцов с русскими заголовками для отчётов
        private static readonly Dictionary<string, string> ColumnTranslations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            // Общие поля
            {"BalanceID", "№ остатка"},
            {"NomenclatureNumber", "Номенклатурный номер"},
            {"StorageID", "Склад"},
            {"StorageFromID", "Склад-отправитель"},
            {"StorageToID", "Склад-получатель"},
            {"WorkshopID", "Цех"},
            {"Quantity", "Количество"},
            {"BatchNumber", "Партия"},
            {"Price", "Цена"},
            {"BalanceDate", "Дата"},

            // Дефектные ведомости
            {"DefectiveID", "№ ведомости"},
            {"DefectiveDate", "Дата ведомости"},
            {"IsWriteOff", "Списание" },

            // Заявки
            {"RequestID", "№ заявки"},
            {"RequirementDate", "Дата потребности"},
            {"RequestDate", "Дата заявки"},
            {"Reason", "Основание"},
            {"Status", "Статус"},

            // Перемещения
            {"MovementID", "№ перемещения"},
            {"MovementDate", "Дата перемещения"},
        };

        /// <summary>
        /// Возвращает русскоязычное название столбца, если оно известно.
        /// </summary>
        private static string GetHeader(string technicalName)
        {
            return ColumnTranslations.TryGetValue(technicalName, out var caption) ? caption : technicalName;
        }

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
                    string header = GetHeader(table.Columns[col].ColumnName);
                    ws.Cells[1, col + 1] = header;
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