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
            {"FullName", "Наименование"},

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

            // Новые поля
            {"DefectiveListID", "№ ведомости"},
            {"DefectiveListDate", "Дата ведомости"},
            {"ReceivingRequestID", "№ заявки"},
            {"PlannedDate", "Плановая дата"},
            {"RequestType", "Тип заявки"},
        };

        /// <summary>
        /// Возвращает русскоязычное название столбца, если оно известно.
        /// </summary>
        private static string GetHeader(string technicalName)
        {
            return ColumnTranslations.TryGetValue(technicalName, out var caption) ? caption : technicalName;
        }

        private static readonly HashSet<string> TextColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "NomenclatureNumber", "RangeStart", "Group", "BatchNumber"
        };

        public void Export(System.Data.DataTable table, string path = null)
        {
            if (table == null) return;

            MSExcel.Application excelApp = null;
            try
            {
                excelApp = new MSExcel.Application();
                bool openOnly = string.IsNullOrWhiteSpace(path);
                excelApp.Visible = true; // всегда показываем Excel
                var wb = excelApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                int columnCount = table.Columns.Count;

                // Заголовки
                for (int col = 0; col < columnCount; col++)
                {
                    string header = GetHeader(table.Columns[col].ColumnName);
                    ws.Cells[1, col + 1] = header;
                    if (TextColumns.Contains(table.Columns[col].ColumnName))
                        ws.Columns[col + 1].NumberFormat = "@"; // текстовый формат
                }

                // Данные
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        ws.Cells[row + 2, col + 1] = table.Rows[row][col];
                    }
                }

                // Стилизация "крутого" отчёта
                MSExcel.Range headerRange = ws.Range[ws.Cells[1, 1], ws.Cells[1, columnCount]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = (int)MSExcel.XlRgbColor.rgbLightGray;
                headerRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                // Автофит столбцов
                ws.Columns.AutoFit();

                // Закрепление строки заголовков
                excelApp.ActiveWindow.SplitRow = 1;
                excelApp.ActiveWindow.FreezePanes = true;

                // Превращаем диапазон в таблицу с красивым стилем
                MSExcel.Range fullRange = ws.Range[ws.Cells[1, 1], ws.Cells[table.Rows.Count + 1, columnCount]];
                var listObj = ws.ListObjects.Add(MSExcel.XlListObjectSourceType.xlSrcRange, fullRange, Type.Missing, MSExcel.XlYesNoGuess.xlYes);
                listObj.TableStyle = "TableStyleMedium2";

                if (!openOnly)
                {
                    wb.SaveAs(path);
                    // оставляем книгу открытой, пользователь сам решит закрыть/сохранить
                }
            }
            finally
            {
                // Закрываем Excel только если мы его сохраняли скрыто
                // В режиме открытия для пользователя оставляем приложение работать
                if (excelApp != null && !excelApp.Visible)
                    excelApp.Quit();
            }
        }

        public void ExportBalancesForm(TOOLACCOUNTINGDataSet dataSet, string path = null)
        {
            if (dataSet == null) return;
            var balances = dataSet.Balances;
            if (balances.Count == 0) return;

            // Предподготовка данных – группируем по номеру, складу и цене, суммируя количество
            var rows = balances.GroupBy(b => new { b.NomenclatureNumber, b.StorageID, b.Price })
                .Select(g => new
                {
                    g.Key.NomenclatureNumber,
                    g.Key.StorageID,
                    g.Key.Price,
                    Quantity = g.Sum(x => x.Quantity),
                    LastDate = g.Max(x => x.BalanceDate)
                })
                .OrderBy(r => r.NomenclatureNumber)
                .ThenBy(r => r.StorageID)
                .ToList();

            // Справочник наименований и ед. измерения
            var nomenDict = dataSet.NomenclatureView
                .ToDictionary(n => n.NomenclatureNumber, n => new { n.FullName, Unit = n.Unit, MinStock = n.MinStock });

            // Справочник складов
            var storageDict = dataSet.Storages.ToDictionary(s => s.StorageID, s => s.Name);

            // Справочник групп
            var groupDict = dataSet.Groups.ToDictionary(g => g.RangeStart, g => g.Name);

            string GetGroupName(string key) => groupDict.ContainsKey(key) ? groupDict[key] : key;
            string GetStorageName(int id) => storageDict.ContainsKey(id) ? storageDict[id] : id.ToString();

            MSExcel.Application xlApp = null;
            try
            {
                xlApp = new MSExcel.Application();
                xlApp.Visible = false;
                var wb = xlApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                int currentRow = 1;

                // Заголовок формы
                ws.Range["A" + currentRow, "G" + currentRow].Merge();
                ws.Cells[currentRow, 1] = "ВЕДОМОСТЬ";
                ws.Range["A" + currentRow].Font.Bold = true;
                ws.Range["A" + currentRow].Font.Size = 14;
                ws.Range["A" + currentRow].HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                currentRow++;
                ws.Range["A" + currentRow, "G" + currentRow].Merge();
                ws.Cells[currentRow, 1] = "УЧЁТА ОСТАТКОВ ПРОДУКТОВ И ТОВАРОВ НА СКЛАДЕ (В КЛАДОВОЙ)";
                ws.Range["A" + currentRow].HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                currentRow += 1; // компактнее: одна пустая строка

                // Колонки с текстовым форматом (2 – номер, 4 – группа)
                ws.Columns[2].NumberFormat = "@";
                ws.Columns[4].NumberFormat = "@";

                // Шапка таблицы
                string[] headers = {
                    "№ п/п",                 //1
                    "Номенклатурный номер",   //2
                    "Наименование",           //3
                    "Группа",                 //4
                    "Склад",                  //5
                    "Учётная цена, руб.",     //6
                    "Количество",             //7
                    "Сумма (цена × кол-во), руб.", //8
                    "Дата последнего движения" //9
                };

                for (int col = 0; col < headers.Length; col++)
                {
                    ws.Cells[currentRow, col + 1] = headers[col];
                }

                // Стиль шапки
                var headerRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, headers.Length]];
                headerRange.Font.Bold = true;
                headerRange.Interior.Color = (int)MSExcel.XlRgbColor.rgbLightGray;
                headerRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                currentRow++; // сразу переходим на строку данных
                int index = 1;
                decimal grandQty = 0;
                decimal grandSum = 0;

                string currentGroupKey = null;
                decimal groupQty = 0;
                decimal groupSum = 0;

                foreach (var r in rows)
                {
                    string groupKey = r.NomenclatureNumber.Substring(0, 4);
                    if (currentGroupKey != null && groupKey != currentGroupKey)
                    {
                        // вывод промежуточного итога по группе
                        ws.Cells[currentRow, 3] = $"Итого по группе: {GetGroupName(currentGroupKey)}";
                        ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 6]].Merge();
                        ws.Cells[currentRow, 7] = groupQty;
                        ws.Cells[currentRow, 8] = groupSum;
                        ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 9]].Font.Bold = true;
                        currentRow++;
                        groupQty = groupSum = 0;
                    }

                    currentGroupKey = groupKey;

                    var fullName = nomenDict.TryGetValue(r.NomenclatureNumber, out var info) ? info.FullName : string.Empty;
                    var unit = nomenDict.TryGetValue(r.NomenclatureNumber, out info) ? info.Unit : string.Empty;
                    int minStock = info?.MinStock ?? 0;
                    string groupName = GetGroupName(groupKey);
                    string storageName = GetStorageName(r.StorageID);

                    decimal sum = r.Price * r.Quantity;

                    ws.Cells[currentRow, 1] = index;
                    ws.Cells[currentRow, 2] = r.NomenclatureNumber;
                    ws.Cells[currentRow, 3] = fullName;
                    ws.Cells[currentRow, 4] = groupName;
                    ws.Cells[currentRow, 5] = storageName;
                    ws.Cells[currentRow, 6] = r.Price;
                    ws.Cells[currentRow, 7] = r.Quantity;
                    ws.Cells[currentRow, 8] = sum;
                    ws.Cells[currentRow, 9] = r.LastDate;

                    groupQty += r.Quantity;
                    groupSum += sum;
                    grandQty += r.Quantity;
                    grandSum += sum;

                    index++;
                    currentRow++;
                }

                // последний итог по группе
                if (currentGroupKey != null)
                {
                    ws.Cells[currentRow, 3] = $"Итого по группе: {GetGroupName(currentGroupKey)}";
                    ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 6]].Merge();
                    ws.Cells[currentRow, 7] = groupQty;
                    ws.Cells[currentRow, 8] = groupSum;
                    ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 9]].Font.Bold = true;
                    currentRow++;
                }

                // Общий итог
                ws.Cells[currentRow, 3] = "Итого по ведомости";
                ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 6]].Merge();
                ws.Cells[currentRow, 7] = grandQty;
                ws.Cells[currentRow, 8] = grandSum;
                ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 9]].Font.Bold = true;

                currentRow += 3; // пропустить пару строк

                // Подписи
                ws.Cells[currentRow, 2] = "Кладовщик:";
                ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 5]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;
                currentRow += 2;
                ws.Cells[currentRow, 2] = "Нач. склада:";
                ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 5]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;
                currentRow += 2;
                ws.Cells[currentRow, 2] = "Главный инженер:";
                ws.Range[ws.Cells[currentRow, 3], ws.Cells[currentRow, 5]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;

                // Форматирование: автофит
                ws.Columns.AutoFit();

                // Автофильтр
                int headerRowIndex = 3; // строка с названиями столбцов
                var dataRange = ws.Range[ws.Cells[headerRowIndex, 1], ws.Cells[currentRow - 8, headers.Length]]; // до итогов
                dataRange.AutoFilter();

                // Закрепление первых трёх строк (заголовок + шапка)
                xlApp.ActiveWindow.SplitRow = 3;
                xlApp.ActiveWindow.FreezePanes = true;

                // Колонтитул
                ws.PageSetup.CenterHeader = $"Ведомость остатков  {DateTime.Today:dd.MM.yyyy}   {Environment.UserName}   Стр.&P из &N";

                bool openOnly = string.IsNullOrWhiteSpace(path);
                xlApp.Visible = true;
                if (!openOnly)
                {
                    wb.SaveAs(path);
                }
            }
            finally
            {
                if (xlApp != null && !xlApp.Visible)
                    xlApp.Quit();
            }
        }
    }
}