using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSExcel = Microsoft.Office.Interop.Excel;
using System.Data;

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
            {"Total", "Сумма"},
            {"Account", "Счёт"},
            {"IsPosted", "Проведён"},
            {"Executor", "Исполнитель"},
            {"LastUpdated", "Последнее обновление"},
            {"ToStorageID", "Склад-получатель"},
            {"FromStorageID", "Склад-отправитель"},
            {"MovementTypeID", "Вид движения"},
            {"IsWriteOff", "Списание"},
            {"InvoiceType", "Тип накладной"},
            {"Supplier", "Поставщик"},
            {"FullName", "Наименование"},
            {"BalanceDate", "Дата"},

            // Дефектные ведомости
            {"DefectiveID", "№ ведомости"},
            {"DefectiveDate", "Дата ведомости"},

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
            // История поступлений
            {"InvoiceID", "№ накладной"},
            {"InvoiceDate", "Дата накладной"},
            {"SupplierName", "Поставщик"},
            // Содержимое заявок на получение
            {"ReceivingContentID", "№ строки"},
            {"ReceivingRequestContentID", "№ строки"},
            // Заявки на получение (шапка)
            {"ReceivingRequestDate", "Дата заявки"},
            {"ReceivingRequestType", "Тип заявки"}
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
                    string header = !string.IsNullOrEmpty(table.Columns[col].Caption) ? table.Columns[col].Caption : GetHeader(table.Columns[col].ColumnName);
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
                headerRange.Interior.ColorIndex = 0; // белый фон
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
                headerRange.Interior.ColorIndex = 0; // белый фон
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

        public void ExportBalancesInj(DataTable table, List<SearchParameter> parameters)
        {
            if (table == null || table.Rows.Count == 0) return;

            MSExcel.Application excelApp = null;
            try
            {
                excelApp = new MSExcel.Application();
                excelApp.Visible = true; // Показываем Excel пользователю
                var wb = excelApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                int currentRow = 1;
                int columnCount = table.Columns.Count;

                // 1. Заголовок отчёта
                ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]].Merge();
                ws.Cells[currentRow, 1] = "ОТЧЁТ ОБ ОСТАТКАХ ИНСТРУМЕНТА НА ЦИС";
                MSExcel.Range titleRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 14;
                titleRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                currentRow += 1;
                currentRow += 1;
                ws.Cells[currentRow,1] = $"Дата формирования отчёта: {DateTime.Today:dd.MM.yyyy}";
                currentRow += 1; // пустая строка после даты
                currentRow += 1;

                // 2. Параметры поиска (если они заданы)
                if (parameters != null && parameters.Count > 0)
                {
                    // Заголовок параметров
                    ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]].Merge();
                    ws.Cells[currentRow, 1] = "ПАРАМЕТРЫ ОТЧЁТА";
                    MSExcel.Range paramsHeader = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                    paramsHeader.Font.Bold = true;
                    paramsHeader.Font.Size = 12;
                    paramsHeader.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignLeft;
                    currentRow++;

                    foreach (var p in parameters)
                    {
                        string header = p.Field;
                        ws.Cells[currentRow, 1] = header + ":";
                        var valueCell = ws.Cells[currentRow, 2];
                        // Форматируем значение как текст, прежде чем присвоить
                        valueCell.NumberFormat = "@";
                        valueCell.Value = p.Value?.ToString();
                        currentRow++;
                    }
                    currentRow++; // пустая строка после параметров
                }

                // 3. Заголовки столбцов
                for (int col = 0; col < columnCount; col++)
                {
                    string header = !string.IsNullOrEmpty(table.Columns[col].Caption) ? table.Columns[col].Caption : GetHeader(table.Columns[col].ColumnName);
                    ws.Cells[currentRow, col + 1] = header;
                    // Текстовый формат для определённых колонок
                    if (TextColumns.Contains(table.Columns[col].ColumnName))
                        ws.Columns[col + 1].NumberFormat = "@";
                    else if (header.Contains("Дата"))
                        ws.Columns[col + 1].NumberFormat = "dd.MM.yyyy";
                }

                MSExcel.Range headerRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                headerRange.Font.Bold = true;
                headerRange.Interior.ColorIndex = 0; // белый фон
                headerRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                // 4. Данные
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        ws.Cells[currentRow + 1 + row, col + 1] = table.Rows[row][col];
                    }
                }

                // 5. Преобразуем диапазон в "умную" таблицу
                MSExcel.Range fullRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow + table.Rows.Count, columnCount]];
                var listObj = ws.ListObjects.Add(MSExcel.XlListObjectSourceType.xlSrcRange, fullRange, Type.Missing, MSExcel.XlYesNoGuess.xlYes);
                listObj.TableStyle = "TableStyleLight1";

                // 6. Автофит и фиксация шапки
                ws.Columns.AutoFit();
                excelApp.ActiveWindow.SplitRow = currentRow;
                excelApp.ActiveWindow.FreezePanes = true;

                //// 7. Блок подписей
                //int signRow = currentRow + table.Rows.Count + 3;
                //ws.Cells[signRow, 1] = "Ответственный:";
                //ws.Range[ws.Cells[signRow, 2], ws.Cells[signRow, 4]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;
                //ws.Cells[signRow, 6] = "Дата:";
                //ws.Range[ws.Cells[signRow, 7], ws.Cells[signRow, 8]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;

                // 7. Колонтитул
                ws.PageSetup.CenterHeader = "";
            }
            finally
            {
                // Если Excel был открыт невидимым (что не наш случай) – закрываем
                if (excelApp != null && !excelApp.Visible)
                    excelApp.Quit();
            }
        }

        public void ExportHistoryInj(System.Data.DataTable table, List<SearchParameter> parameters)
        {
            if (table == null || table.Rows.Count == 0) return;

            MSExcel.Application excelApp = null;
            try
            {
                excelApp = new MSExcel.Application();
                excelApp.Visible = true;
                var wb = excelApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                int currentRow = 1;
                int columnCount = table.Columns.Count;

                // Заголовок отчёта
                ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]].Merge();
                ws.Cells[currentRow, 1] = "ОТЧЁТ ПО ИСТОРИИ ПОСТУПЛЕНИЙ";
                MSExcel.Range titleRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 14;
                titleRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                currentRow += 1;
                currentRow += 1;
                ws.Cells[currentRow,1] = $"Дата формирования отчёта: {DateTime.Today:dd.MM.yyyy}";
                currentRow += 1; // пустая строка после даты
                currentRow += 1;

                // Параметры (если есть)
                if (parameters != null && parameters.Count > 0)
                {
                    ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]].Merge();
                    ws.Cells[currentRow, 1] = "ПАРАМЕТРЫ ОТЧЁТА";
                    MSExcel.Range paramsHeader = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                    paramsHeader.Font.Bold = true;
                    paramsHeader.Font.Size = 12;
                    paramsHeader.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignLeft;
                    currentRow++;

                    foreach (var p in parameters)
                    {
                        string header = p.Field;
                        ws.Cells[currentRow, 1] = header + ":";
                        var valueCell = ws.Cells[currentRow, 2];
                        valueCell.NumberFormat = "@"; // текстово
                        valueCell.Value = p.Value?.ToString();
                        currentRow++;
                    }
                    currentRow++; // пустая строка
                }

                // Шапка столбцов
                for (int col = 0; col < columnCount; col++)
                {
                    string header = !string.IsNullOrEmpty(table.Columns[col].Caption) ? table.Columns[col].Caption : GetHeader(table.Columns[col].ColumnName);
                    ws.Cells[currentRow, col + 1] = header;
                    if (TextColumns.Contains(table.Columns[col].ColumnName))
                        ws.Columns[col + 1].NumberFormat = "@";
                    else if (header.Contains("Дата"))
                        ws.Columns[col + 1].NumberFormat = "dd.MM.yyyy";
                }
                MSExcel.Range headerRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                headerRange.Font.Bold = true;
                headerRange.Interior.ColorIndex = 0; // белый фон
                headerRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                // Данные
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        ws.Cells[currentRow + 1 + row, col + 1] = table.Rows[row][col];
                    }
                }

                // Smart table
                MSExcel.Range fullRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow + table.Rows.Count, columnCount]];
                var listObj = ws.ListObjects.Add(MSExcel.XlListObjectSourceType.xlSrcRange, fullRange, Type.Missing, MSExcel.XlYesNoGuess.xlYes);
                listObj.TableStyle = "TableStyleLight1";

                // Автофит и фиксация шапки
                ws.Columns.AutoFit();
                excelApp.ActiveWindow.SplitRow = currentRow;
                excelApp.ActiveWindow.FreezePanes = true;

                // Колонтитул
                ws.PageSetup.CenterHeader = "";
            }
            finally
            {
                if (excelApp != null && !excelApp.Visible)
                    excelApp.Quit();
            }
        }

        public void ExportPurchaseRequestInj(int requestId, DateTime requestDate, string status, System.Data.DataTable details)
        {
            if (details == null || details.Rows.Count == 0) return;

            MSExcel.Application excelApp = null;
            try
            {
                excelApp = new MSExcel.Application();
                excelApp.Visible = true;
                var wb = excelApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                int currentRow = 1;
                int columnCount = details.Columns.Count;

                // Заголовок
                ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]].Merge();
                ws.Cells[currentRow, 1] = $"ЗАЯВКА НА ПРИОБРЕТЕНИЕ № {requestId} от {requestDate:dd.MM.yyyy}";
                MSExcel.Range titleRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 14;
                titleRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // Можно добавить дату печати
                currentRow += 1;

                // Заголовки деталей
                for (int col = 0; col < columnCount; col++)
                {
                    string header = !string.IsNullOrEmpty(details.Columns[col].Caption) ? details.Columns[col].Caption : GetHeader(details.Columns[col].ColumnName);
                    ws.Cells[currentRow, col + 1] = header;
                    if (TextColumns.Contains(details.Columns[col].ColumnName))
                        ws.Columns[col + 1].NumberFormat = "@";
                    else if (header.Contains("Дата"))
                        ws.Columns[col + 1].NumberFormat = "dd.MM.yyyy";
                }
                MSExcel.Range hdrRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                hdrRange.Font.Bold = true;
                hdrRange.Interior.ColorIndex = 0; // белый фон
                hdrRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                // Данные
                for (int row = 0; row < details.Rows.Count; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        ws.Cells[currentRow + 1 + row, col + 1] = details.Rows[row][col];
                    }
                }

                // Smart table
                MSExcel.Range fullRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow + details.Rows.Count, columnCount]];
                var listObj = ws.ListObjects.Add(MSExcel.XlListObjectSourceType.xlSrcRange, fullRange, Type.Missing, MSExcel.XlYesNoGuess.xlYes);
                listObj.TableStyle = "TableStyleLight1";

                // Подсчитать итог кол-ва
                int qtyColIndex = -1;
                for (int col = 0; col < columnCount; col++)
                {
                    string lowerHeader = details.Columns[col].Caption.ToLowerInvariant();
                    if (lowerHeader.Contains("колич")) { qtyColIndex = col; break; }
                }
                if (qtyColIndex >= 0)
                {
                    int summaryRow = currentRow + 1 + details.Rows.Count;
                    ws.Cells[summaryRow, qtyColIndex] = "Итого:";
                    ws.Cells[summaryRow, qtyColIndex + 1].Formula = $"=SUBTOTAL(109,{ws.Range[ws.Cells[currentRow + 1, qtyColIndex + 1], ws.Cells[summaryRow - 1, qtyColIndex + 1]].Address[false,false]})";
                    ws.Range[ws.Cells[summaryRow, qtyColIndex], ws.Cells[summaryRow, qtyColIndex + 1]].Font.Bold = true;
                }

                //--- ADD DATE AND SIGNATURE FOR PURCHASE REQUEST
                // Date under table
                int prDateRow = currentRow + details.Rows.Count + 3;
                ws.Cells[prDateRow,1] = "Дата: _________________";
                //ws.Cells[prDateRow,2] = DateTime.Today.ToString("dd.MM.yyyy");
                MSExcel.Range prDateRange = ws.Range[ws.Cells[prDateRow, 2], ws.Cells[prDateRow, 2]];
                //prDateRange.Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;
                // Signatures
                int prSignStart = prDateRow + 2;
                ws.Cells[prSignStart,1] = "Должность";
                ws.Cells[prSignStart,2] = "Подпись";
                ws.Cells[prSignStart,3] = "ФИО";
                MSExcel.Range prSignRange = ws.Range[ws.Cells[prSignStart,1], ws.Cells[prSignStart,3]];
                //prSignRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                prSignRange.VerticalAlignment = MSExcel.XlVAlign.xlVAlignCenter;
                for(int c=1;c<=3;c++)
                    ws.Cells[prSignStart+1,c].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;

                // Автофит, фиксация шапки
                ws.Columns.AutoFit();
                excelApp.ActiveWindow.SplitRow = currentRow;
                excelApp.ActiveWindow.FreezePanes = true;

                // Блок подписей
                //int signStartRow = currentRow + details.Rows.Count + 6; // немного отступить

                //ws.Cells[signStartRow, 1] = "Должность";
                //ws.Cells[signStartRow, 2] = "Подпись";
                //ws.Cells[signStartRow, 3] = "ФИО";

                //// Получаем диапазон этих ячеек
                //MSExcel.Range headerRange = ws.Range[ws.Cells[signStartRow, 1], ws.Cells[signStartRow, 1]];

                //// Выравниваем по центру по горизонтали и вертикали
                //headerRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                //headerRange.VerticalAlignment = MSExcel.XlVAlign.xlVAlignCenter;

                // Линии подписи (нижняя граница)
                //ws.Range[ws.Cells[signStartRow + 1, 1], ws.Cells[signStartRow + 1, 1]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;
                //ws.Range[ws.Cells[signStartRow + 1, 2], ws.Cells[signStartRow + 1, 2]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;
                //ws.Range[ws.Cells[signStartRow + 1, 3], ws.Cells[signStartRow + 1, 3]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;

                // Убираем колонтитул
                ws.PageSetup.CenterHeader = "";
            }
            finally
            {
                if (excelApp != null && !excelApp.Visible) excelApp.Quit();
            }
        }

        public void ExportDeliveryListInj(int listId, DateTime listDate, string supplier, System.Data.DataTable details)
        {
            if (details == null || details.Rows.Count == 0) return;
            MSExcel.Application excelApp = null;
            try
            {
                excelApp = new MSExcel.Application();
                excelApp.Visible = true;
                var wb = excelApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                int row = 1;
                int cols = details.Columns.Count;

                // Header
                ws.Range[ws.Cells[row,1], ws.Cells[row, cols]].Merge();
                ws.Cells[row,1] = $"ВЕДОМОСТЬ ПОСТАВКИ № {listId} от {listDate:dd.MM.yyyy}";
                MSExcel.Range tRange = ws.Range[ws.Cells[row,1], ws.Cells[row,cols]];
                tRange.Font.Bold = true; tRange.Font.Size = 14; tRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                row += 2;

                ws.Cells[row,1] = $"Поставщик: {supplier}";
                ws.Cells[row,1].Font.Bold = true;
                row += 2;

                // columns
                for(int c=0;c<cols;c++)
                {
                    string header = !string.IsNullOrEmpty(details.Columns[c].Caption)?details.Columns[c].Caption:GetHeader(details.Columns[c].ColumnName);
                    ws.Cells[row,c+1]=header;
                    if(TextColumns.Contains(details.Columns[c].ColumnName)) ws.Columns[c+1].NumberFormat="@";
                    else if(header.Contains("Дата")) ws.Columns[c+1].NumberFormat="dd.MM.yyyy";
                }
                MSExcel.Range hdr = ws.Range[ws.Cells[row,1], ws.Cells[row,cols]];
                hdr.Font.Bold = true;
                hdr.Interior.ColorIndex = 0;
                hdr.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                // data
                for(int r=0;r<details.Rows.Count;r++)
                {
                    for(int c=0;c<cols;c++) ws.Cells[row+1+r,c+1]=details.Rows[r][c];
                }

                MSExcel.Range full = ws.Range[ws.Cells[row,1], ws.Cells[row+details.Rows.Count, cols]];
                var table = ws.ListObjects.Add(MSExcel.XlListObjectSourceType.xlSrcRange, full, Type.Missing, MSExcel.XlYesNoGuess.xlYes);
                table.TableStyle = "TableStyleLight1";

                // Date field
                int dateRow = row + details.Rows.Count + 3;
                ws.Cells[dateRow,1] = "Дата: _________________";

                // Signature block
                int signStart = dateRow + 2;
                ws.Cells[signStart,1] = "Должность";
                ws.Cells[signStart,2] = "Подпись";
                ws.Cells[signStart,3] = "ФИО";
                MSExcel.Range signRange = ws.Range[ws.Cells[signStart,1], ws.Cells[signStart,3]];
                signRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                signRange.VerticalAlignment = MSExcel.XlVAlign.xlVAlignCenter;
                for(int c=1;c<=4;c++)
                    ws.Cells[signStart+1,c].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;

                // totals
                int qtyIndex=-1;
                for(int c=0;c<cols;c++) if(details.Columns[c].Caption.ToLowerInvariant().Contains("колич")){qtyIndex=c;break;}
                if(qtyIndex>=0){int totalRow=row+1+details.Rows.Count; ws.Cells[totalRow,qtyIndex+1-1]="Итого:"; ws.Cells[totalRow,qtyIndex+1].Formula=$"=SUBTOTAL(109,{ws.Range[ws.Cells[row+1,qtyIndex+1], ws.Cells[totalRow-1,qtyIndex+1]].Address[false,false]})"; ws.Range[ws.Cells[totalRow,qtyIndex],ws.Cells[totalRow,qtyIndex+1]].Font.Bold=true;}

                ws.Columns.AutoFit();
                excelApp.ActiveWindow.SplitRow=row;
                excelApp.ActiveWindow.FreezePanes=true;
            }
            finally{if(excelApp!=null&&!excelApp.Visible) excelApp.Quit();}
        }

        public void ExportReceivingRequestInj(int requestId, DateTime requirementDate, DateTime requestDate, string reason, string status, System.Data.DataTable details)
        {
            if (details == null || details.Rows.Count == 0) return;

            MSExcel.Application excelApp = null;
            try
            {
                excelApp = new MSExcel.Application();
                excelApp.Visible = true;
                var wb = excelApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                int currentRow = 1;
                int columnCount = details.Columns.Count;

                // 1. Шапка документа
                ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]].Merge();
                ws.Cells[currentRow, 1] = $"ЗАЯВКА НА ПОЛУЧЕНИЕ № {requestId} от {requestDate:dd.MM.yyyy}";
                MSExcel.Range titleRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 14;
                titleRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                currentRow += 2;

                // 2. Реквизиты заявки
                ws.Cells[currentRow, 1] = $"Дата потребности: {requirementDate:dd.MM.yyyy}";
                ws.Cells[currentRow, 3] = $"Основание: {reason}";
                ws.Cells[currentRow, 6] = $"Статус: {status}";
                ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, 6]].Font.Bold = true;
                currentRow += 2;

                // 3. Заголовки таблицы содержания
                for (int col = 0; col < columnCount; col++)
                {
                    string header = !string.IsNullOrEmpty(details.Columns[col].Caption) ? details.Columns[col].Caption : GetHeader(details.Columns[col].ColumnName);
                    ws.Cells[currentRow, col + 1] = header;
                    if (TextColumns.Contains(details.Columns[col].ColumnName))
                        ws.Columns[col + 1].NumberFormat = "@";
                    else if (header.Contains("Дата"))
                        ws.Columns[col + 1].NumberFormat = "dd.MM.yyyy";
                }
                MSExcel.Range hdrRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow, columnCount]];
                hdrRange.Font.Bold = true;
                hdrRange.Interior.ColorIndex = 0;
                hdrRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;

                // 4. Данные
                for (int row = 0; row < details.Rows.Count; row++)
                {
                    for (int col = 0; col < columnCount; col++)
                    {
                        ws.Cells[currentRow + 1 + row, col + 1] = details.Rows[row][col];
                    }
                }

                // 5. Преобразование диапазона в таблицу
                MSExcel.Range fullRange = ws.Range[ws.Cells[currentRow, 1], ws.Cells[currentRow + details.Rows.Count, columnCount]];
                var listObj = ws.ListObjects.Add(MSExcel.XlListObjectSourceType.xlSrcRange, fullRange, Type.Missing, MSExcel.XlYesNoGuess.xlYes);
                listObj.TableStyle = "TableStyleLight1";

                // 6. Итоговая строка по количеству (если есть колонка)
                int qtyColIndex = -1;
                for (int col = 0; col < columnCount; col++)
                {
                    string lowerHeader = details.Columns[col].Caption.ToLowerInvariant();
                    if (lowerHeader.Contains("колич")) { qtyColIndex = col; break; }
                }
                if (qtyColIndex >= 0)
                {
                    int summaryRow = currentRow + 1 + details.Rows.Count;
                    ws.Cells[summaryRow, qtyColIndex] = "Итого:";
                    ws.Cells[summaryRow, qtyColIndex + 1].Formula = $"=SUBTOTAL(109,{ws.Range[ws.Cells[currentRow + 1, qtyColIndex + 1], ws.Cells[summaryRow - 1, qtyColIndex + 1]].Address[false, false]})";
                    ws.Range[ws.Cells[summaryRow, qtyColIndex], ws.Cells[summaryRow, qtyColIndex + 1]].Font.Bold = true;
                }

                // 7. Дата и подписи
                int dateRow = currentRow + details.Rows.Count + 3;
                ws.Cells[dateRow, 1] = "Дата: _________________";
                int signStart = dateRow + 2;
                ws.Cells[signStart, 1] = "Должность";
                ws.Cells[signStart, 2] = "Подпись";
                ws.Cells[signStart, 3] = "ФИО";
                MSExcel.Range signRange = ws.Range[ws.Cells[signStart, 1], ws.Cells[signStart, 3]];
                signRange.HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                signRange.VerticalAlignment = MSExcel.XlVAlign.xlVAlignCenter;
                for (int c = 1; c <= 3; c++)
                    ws.Cells[signStart + 1, c].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;

                // 8. Автофит и фиксация шапки
                ws.Columns.AutoFit();
                excelApp.ActiveWindow.SplitRow = currentRow;
                excelApp.ActiveWindow.FreezePanes = true;

                ws.PageSetup.CenterHeader = "";
            }
            finally
            {
                if (excelApp != null && !excelApp.Visible) excelApp.Quit();
            }
        }

        // --- ДЕФЕКТНЫЕ ВЕДОМОСТИ (Сводный отчёт) ---
        public void ExportDefectiveInj(System.Data.DataTable table, List<SearchParameter> parameters)
        {
            if (table == null || table.Rows.Count == 0) return;

            MSExcel.Application xlApp = null;
            try
            {
                xlApp = new MSExcel.Application();
                xlApp.Visible = true;
                var wb = xlApp.Workbooks.Add();
                MSExcel.Worksheet ws = wb.ActiveSheet;

                int r = 1;
                ws.Range[ws.Cells[r,1], ws.Cells[r, table.Columns.Count]].Merge();
                ws.Cells[r,1] = "ОТЧЁТ ПО ДЕФЕКТНЫМ ВЕДОМОСТЯМ";
                ws.Cells[r,1].Font.Bold = true;
                ws.Cells[r,1].Font.Size = 14;
                ws.Cells[r,1].HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                r+=2;

                // параметры
                if(parameters!=null && parameters.Count>0)
                {
                    foreach(var p in parameters)
                    {
                        ws.Cells[r,1] = p.Field + ":";
                        ws.Cells[r,2] = p.Value?.ToString();
                        r++;
                    }
                    r++;
                }

                // шапка
                for(int c=0;c<table.Columns.Count;c++)
                {
                    string header = !string.IsNullOrEmpty(table.Columns[c].Caption)?table.Columns[c].Caption:GetHeader(table.Columns[c].ColumnName);
                    ws.Cells[r, c+1] = header;
                    if(TextColumns.Contains(table.Columns[c].ColumnName)) ws.Columns[c+1].NumberFormat="@";
                    else if(header.Contains("Дата")) ws.Columns[c+1].NumberFormat="dd.MM.yyyy";
                }
                ws.Range[ws.Cells[r,1], ws.Cells[r, table.Columns.Count]].Font.Bold = true;
                ws.Range[ws.Cells[r,1], ws.Cells[r, table.Columns.Count]].HorizontalAlignment = MSExcel.XlHAlign.xlHAlignCenter;
                int dataStart = r+1;

                // данные
                for(int row=0; row<table.Rows.Count; row++)
                    for(int col=0; col<table.Columns.Count; col++)
                        ws.Cells[dataStart+row, col+1] = table.Rows[row][col];

                // форматирование
                MSExcel.Range full = ws.Range[ws.Cells[r,1], ws.Cells[dataStart+table.Rows.Count-1, table.Columns.Count]];
                ws.ListObjects.Add(MSExcel.XlListObjectSourceType.xlSrcRange, full, Type.Missing, MSExcel.XlYesNoGuess.xlYes).TableStyle = "TableStyleLight1";
                ws.Columns.AutoFit();
                xlApp.ActiveWindow.SplitRow = r;
                xlApp.ActiveWindow.FreezePanes = true;

                // подписи
                int sign = dataStart + table.Rows.Count + 2;
                ws.Cells[sign,1]="Ответственный:";
                ws.Range[ws.Cells[sign,2], ws.Cells[sign,4]].Borders[MSExcel.XlBordersIndex.xlEdgeBottom].LineStyle = MSExcel.XlLineStyle.xlContinuous;
            }
            finally { if(xlApp!=null && !xlApp.Visible) xlApp.Quit(); }
        }

        // --- Сводный отчёт по всем заявкам на получение ---
        public void ExportReceivingRequestsSummaryInj(System.Data.DataTable headers, System.Data.DataTable contents)
        {
            if(headers==null || headers.Rows.Count==0) return;

            MSExcel.Application app=null;
            try
            {
                app=new MSExcel.Application();
                app.Visible=true;
                var wb=app.Workbooks.Add();
                MSExcel.Worksheet ws=wb.ActiveSheet;

                int row=1;
                foreach(System.Data.DataRow h in headers.Rows)
                {
                    int requestId = Convert.ToInt32(h["ReceivingRequestID"]);
                    DateTime reqDate = (DateTime)h["ReceivingRequestDate"];
                    string type = h["ReceivingRequestType"].ToString();
                    int workshop = Convert.ToInt32(h["WorkshopID"]);
                    DateTime planned = (DateTime)h["PlannedDate"];
                    string reason = h["Reason"].ToString();
                    string status = h["Status"].ToString();

                    // Header for request
                    ws.Cells[row,1] = $"Заявка № {requestId} от {reqDate:dd.MM.yyyy}";
                    ws.Cells[row,1].Font.Bold = true;
                    row++;
                    ws.Cells[row,1] = $"Тип: {type}, Цех: {workshop}, Плановая дата: {planned:dd.MM.yyyy}, Статус: {status}";
                    row++;
                    ws.Cells[row,1] = $"Основание: {reason}";
                    row+=1;

                    // Detail headers indent 1 cell
                    var detailRows = contents.Select($"ReceivingRequestID = {requestId}");
                    if(detailRows.Length==0){ row+=2; continue; }
                    var sample=detailRows[0].Table;
                    int colCount = sample.Columns.Count;
                    for(int c=0;c<colCount;c++)
                    {
                        ws.Cells[row, c+2] = GetHeader(sample.Columns[c].ColumnName);
                    }
                    ws.Range[ws.Cells[row,2], ws.Cells[row, colCount+1]].Font.Bold = true;
                    row++;
                    foreach(var dr in detailRows)
                    {
                        for(int c=0;c<colCount;c++) ws.Cells[row, c+2] = dr[c];
                        row++;
                    }
                    row+=2; // space between requests
                }

                ws.Columns.AutoFit();
                ws.PageSetup.CenterHeader="Сводный отчёт по заявкам на получение";
            }
            finally{ if(app!=null && !app.Visible) app.Quit(); }
        }
    }
}