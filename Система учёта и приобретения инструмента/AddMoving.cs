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
using System.Runtime.InteropServices;
using System.Reflection.Emit;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class AddMoving : Form
    {
        AutoCompleteStringCollection storageSource = new AutoCompleteStringCollection();
        AutoCompleteStringCollection nomenSource = new AutoCompleteStringCollection();
        private ToolTip qtyTip = new ToolTip();
        public event EventHandler MovementSaved;
        private bool _updatingSourceDoc = false;

        // Адаптер для сохранения перемещений
        ToolMovementsTableAdapter movementsAdapter = new ToolMovementsTableAdapter();

        public AddMoving()
        {
            InitializeComponent();

            // Устанавливаем начальные значения
            Moving.Checked = true; // по умолчанию тип «Перемещение»
            Add_CheckedChanged(this, EventArgs.Empty); // синхронизируем доступность полей
            ApplicationDate.Text = DateTime.Now.ToShortDateString();
            User.Text = Environment.UserName;

            // Загружаем склады для автодополнения
            var storagesAdapter = new StoragesTableAdapter();
            storagesAdapter.Fill(tOOLACCOUNTINGDataSet.Storages);

            // Добавляем все склады в источник автодополнения
            foreach (var sRow in tOOLACCOUNTINGDataSet.Storages)
            {
                storageSource.Add($"{sRow.StorageID} - {sRow.Name}");
            }

            // Номенклатура и остатки
            var balancesAdapter = new BalancesTableAdapter();
            balancesAdapter.Fill(tOOLACCOUNTINGDataSet.Balances);

            var nomenAdapter = new NomenclatureViewTableAdapter();
            nomenAdapter.Fill(tOOLACCOUNTINGDataSet.NomenclatureView);

            ConfigureStorageAutoComplete(StorageFrom);
            ConfigureStorageAutoComplete(StorageTo);

            StorageFrom.Leave += Storage_Leave;
            StorageTo.Leave += Storage_Leave;

            // Автокомплит для номенклатуры
            Nomenclature.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Nomenclature.AutoCompleteSource = AutoCompleteSource.CustomSource;
            Nomenclature.AutoCompleteCustomSource = nomenSource;
            Nomenclature.Leave += Nomenclature_Leave;

            // обработчик выбора типа документа-источника
            SourceDocumentType.SelectedIndexChanged += SourceDocumentType_SelectedIndexChanged;
            SourceDocument.Leave += SourceDocument_Leave;
            SourceDocument.TextChanged += SourceDocument_TextChanged;
        }

        private void ConfigureStorageAutoComplete(TextBox tb)
        {
            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // динамически формируем источник при входе в поле, исключая другой выбранный склад
            tb.Enter += (s, e) =>
            {
                int excludeId = 0;
                if (tb == StorageFrom)
                    int.TryParse(StorageTo.Text.Split('-')[0].Trim(), out excludeId);
                else
                    int.TryParse(StorageFrom.Text.Split('-')[0].Trim(), out excludeId);

                AutoCompleteStringCollection filtered = new AutoCompleteStringCollection();
                foreach (var sRow in tOOLACCOUNTINGDataSet.Storages)
                {
                    if (sRow.StorageID == excludeId) continue;
                    filtered.Add($"{sRow.StorageID} - {sRow.Name}");
                }
                tb.AutoCompleteCustomSource = filtered;
            };
        }

        private void Storage_Leave(object sender, EventArgs e)
        {
            if (sender is TextBox tb)
            {
                string txt = tb.Text;
                int dash = txt.IndexOf('-');
                if (dash > -1)
                {
                    tb.Text = txt.Substring(0, dash).Trim(); // оставляем только номер склада/цеха
                }

                // Обновляем автокомплит номенклатуры для выбранного склада-отправителя
                if (tb == StorageFrom)
                {
                    int storageId;
                    if (int.TryParse(StorageFrom.Text.Trim(), out storageId))
                    {
                        BuildNomenSource(storageId);
                    }
                }

                if (tb == StorageFrom && StorageTo.Text.Trim() == tb.Text.Trim() && !string.IsNullOrWhiteSpace(tb.Text))
                {
                    NotificationService.Notify("Ошибка", "Склад-отправитель и склад-получатель не могут совпадать.", ToolTipIcon.Error);
                    tb.Focus();
                    return;
                }
                if (tb == StorageTo && StorageFrom.Text.Trim() == tb.Text.Trim() && !string.IsNullOrWhiteSpace(tb.Text))
                {
                    NotificationService.Notify("Ошибка", "Склад-отправитель и склад-получатель не могут совпадать.", ToolTipIcon.Error);
                    tb.Focus();
                    return;
                }
            }
        }

        private void BuildNomenSource(int storageId)
        {
            nomenSource.Clear();
            var noms = tOOLACCOUNTINGDataSet.Balances
                .Where(b => b.StorageID == storageId && b.Quantity > 0)
                .Select(b => b.NomenclatureNumber)
                .Distinct()
                .ToList();

            foreach (var num in noms)
            {
                var fullName = tOOLACCOUNTINGDataSet.NomenclatureView.FirstOrDefault(n => n.NomenclatureNumber == num)?.FullName ?? string.Empty;
                nomenSource.Add($"{num} - {fullName}");
            }
        }

        private void Nomenclature_Leave(object sender, EventArgs e)
        {
            string txt = Nomenclature.Text;
            int dash = txt.IndexOf('-');
            if (dash > -1) txt = txt.Substring(0, dash).Trim();
            Nomenclature.Text = txt;

            int storageId;
            if (!int.TryParse(StorageFrom.Text.Trim(), out storageId)) return;

            int available = tOOLACCOUNTINGDataSet.Balances
                .Where(b => b.StorageID == storageId && b.NomenclatureNumber == txt)
                .Sum(b => b.Quantity);

            qtyTip.SetToolTip(Quantity, $"Доступно на складе: {available}");

            // Автоподстановка партии (последняя партия по дате баланса)
            var lastBalance = tOOLACCOUNTINGDataSet.Balances
                .Where(b => b.StorageID == storageId && b.NomenclatureNumber == txt)
                .OrderByDescending(b => b.BalanceDate)
                .FirstOrDefault();

            if (lastBalance != null)
            {
                BatchNumber.Text = lastBalance.BatchNumber;
            }

            // Если это приход (Add) и партия ещё не указана – формируем автоматически
            if (Add.Checked && string.IsNullOrWhiteSpace(BatchNumber.Text))
            {
                BatchNumber.Text = $"B{DateTime.Now:yyMMddHHmmss}";
            }
        }

        private void Add_CheckedChanged(object sender, EventArgs e)
        {
            Check_MoveType();
        }

        private void Check_MoveType()
        {
            if (Add.Checked)
            {
                ToggleNomenAutocomplete(false);

                StorageTo.ReadOnly = false;
                label15.Text = "Тип документа *";
                label7.Text = "Документ-основание *";
                label5.Text = "Склад-отправитель";
                SourceDocumentType.Text = null;
                RefreshSourceDocumentType();
                StorageTo.Text = "0";
                StorageFrom.Text = null;
                StorageFrom.ReadOnly = true;
                Nomenclature.ReadOnly = false;
                RefreshSourceDocumentType();
            }
            else
            {
                if (NonAdd.Checked)
                {
                    ToggleNomenAutocomplete(true);
                    Nomenclature.ReadOnly = true;
                    StorageTo.Text = "12";
                    StorageTo.ReadOnly = true;
                    label15.Text = "Тип документа *";
                    label7.Text = "Документ-основание *";
                    label5.Text = "Склад-отправитель *";
                    SourceDocumentType.Text = "Дефектная ведомость";
                    RefreshSourceDocumentType();
                    // обновим список документов источников
                    SourceDocumentType_SelectedIndexChanged(null, EventArgs.Empty);
                }
                else
                {
                    
                    ToggleNomenAutocomplete(true);
                    label15.Text = "Тип документа";
                    Nomenclature.ReadOnly = false;
                    StorageTo.Text = null;
                    StorageFrom.Text = "0";
                    label7.Text = "Документ-основание";
                    StorageTo.ReadOnly = false;
                    label5.Text = "Склад-отправитель *";
                    SourceDocumentType.Text = null;
                    RefreshSourceDocumentType();
                }
            }
        }

        private void ToggleNomenAutocomplete(bool enable)
        {
            if (enable)
            {
                Nomenclature.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                Nomenclature.AutoCompleteSource = AutoCompleteSource.CustomSource;
                Nomenclature.AutoCompleteCustomSource = nomenSource;

                // обновим источник, если известен склад
                int sid;
                if (int.TryParse(StorageFrom.Text.Trim(), out sid))
                {
                    BuildNomenSource(sid);
                }
            }
            else
            {
                Nomenclature.AutoCompleteMode = AutoCompleteMode.None;
                Nomenclature.AutoCompleteCustomSource = null;
            }
        }

        /// <summary>
        /// Предварительно заполняет форму перемещения.
        /// </summary>
        public void Prefill(string nomenNumber, int? storageFromId, string batchNumber, decimal price, bool setMoving = true, int? storageToId = null)
        {
            try
            {
                Nomenclature.Text = nomenNumber;
                if (storageFromId.HasValue)
                    StorageFrom.Text = storageFromId.Value.ToString();
                BatchNumber.Text = batchNumber;
                Price.Text = price.ToString("0.##");

                if (storageToId.HasValue)
                    StorageTo.Text = storageToId.Value.ToString();

                if (setMoving)
                {
                    Moving.Checked = true;
                }
            }
            catch { /* в случае ошибок просто игнорируем */ }
        }

        private void AddMoving_Load(object sender, EventArgs e)
        {
            Check_MoveType();
            var TMTableAdapter = new ToolMovementsTableAdapter();
            TMTableAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);
            int newId = tOOLACCOUNTINGDataSet.ToolMovements.Count() == 0 ? 1 : tOOLACCOUNTINGDataSet.ToolMovements.Max(r => r.MovementID) + 1;
            textBox1.Text = newId.ToString();
            textBox7.Text = DateTime.Now.ToString();
        }

        private void MoveFormSave_Click(object sender, EventArgs e)
        {
            if (TrySave())
            {
                NotificationService.Notify("Успех", "Перемещение сохранено.", ToolTipIcon.Info);
            }
        }

        private void MoveFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave()) this.Close();
        }

        private bool TrySave()
        {
            // Валидация обязательных полей
            if (string.IsNullOrWhiteSpace(StorageFrom.Text) || string.IsNullOrWhiteSpace(StorageTo.Text) ||
                string.IsNullOrWhiteSpace(Nomenclature.Text) || string.IsNullOrWhiteSpace(Quantity.Text))
            {
                NotificationService.Notify("Предупреждение", "Заполните все обязательные поля.", ToolTipIcon.Warning);
                return false;
            }

            int fromId, toId, qty;
            if (!int.TryParse(StorageFrom.Text.Trim(), out fromId))
            {
                NotificationService.Notify("Ошибка", "Некорректный склад-отправитель.", ToolTipIcon.Error);
                return false;
            }
            if (!int.TryParse(StorageTo.Text.Trim(), out toId))
            {
                NotificationService.Notify("Ошибка", "Некорректный склад-получатель.", ToolTipIcon.Error);
                return false;
            }
            if (!int.TryParse(Quantity.Text.Trim(), out qty) || qty <= 0)
            {
                NotificationService.Notify("Ошибка", "Количество должно быть положительным числом.", ToolTipIcon.Error);
                return false;
            }

            string nomenNumber = Nomenclature.Text.Split('-')[0].Trim();
            string movementName = Moving.Checked ? "Перемещение" : "Списание";

            // Флаг «Проведён»
            bool posted = isWriteOff.Checked;

            // Документ-основание
            string srcDocType = string.IsNullOrWhiteSpace(SourceDocumentType.Text) ? null : SourceDocumentType.Text.Trim();
            int? srcDocId = null;
            if (!string.IsNullOrWhiteSpace(SourceDocument.Text))
            {
                var idPart = SourceDocument.Text.Split('-')[0].Trim();
                int idParsed;
                if (int.TryParse(idPart, out idParsed)) srcDocId = idParsed;
            }

            if (!string.IsNullOrWhiteSpace(srcDocType) && srcDocId == null)
            {
                NotificationService.Notify("Ошибка", "Укажите номер документа-основания.", ToolTipIcon.Error);
                return false;
            }

            // Проверка остатка выполняется только при проведённом документе
            if (posted && (movementName == "Списание" || movementName == "Перемещение"))
            {
                int availableQty = tOOLACCOUNTINGDataSet.Balances
                    .Where(b => b.StorageID == fromId && b.NomenclatureNumber == nomenNumber)
                    .Sum(b => b.Quantity);

                if (qty > availableQty)
                {
                    NotificationService.Notify("Ошибка", $"Недостаточно остатка. Доступно {availableQty}, запрошено {qty}.", ToolTipIcon.Error);
                    return false;
                }
            }

            try
            {
                movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);
                int newId = tOOLACCOUNTINGDataSet.ToolMovements.Count == 0 ? 1 : tOOLACCOUNTINGDataSet.ToolMovements.Max(r => r.MovementID) + 1;

                var newRow = tOOLACCOUNTINGDataSet.ToolMovements.NewToolMovementsRow();
                newRow.MovementID = newId;
                newRow.MovementDate = DateTime.Now;
                newRow.ToStorageID = toId;
                newRow.FromStorageID = fromId;
                newRow.MovementTypeID = movementName; // записываем название, а не код
                newRow.NomenclatureNumber = nomenNumber;
                newRow.BatchNumber = string.IsNullOrWhiteSpace(BatchNumber.Text) ? "-" : BatchNumber.Text.Trim();
                decimal price;
                decimal.TryParse(Price.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out price);
                newRow.Price = price;
                newRow.Quantity = qty;
                newRow.Executor = Environment.UserName.ToString();
                newRow.IsPosted = posted;
                newRow.LastUpdated = DateTime.Now;
                newRow.Total = price * qty;
                if (srcDocType != null) newRow.SourceDocumentType = srcDocType;
                if (srcDocId.HasValue) newRow.SourceDocumentID = srcDocId.Value;

                if (movementName == "Списание")
                {
                    // При непроведённом документе только фиксируем склад 12, без изменения балансов
                    int writeOffStorageId = 12;
                    if (!posted)
                    {
                        newRow.ToStorageID = writeOffStorageId;
                    }

                    if (!posted)
                    {
                        // изменения остатков будут выполнены при проведении
                    }
                    else
                    {
                        // проверяем остаток и списываем со склада-отправителя
                        var balRow = tOOLACCOUNTINGDataSet.Balances.FirstOrDefault(b => b.StorageID == fromId && b.NomenclatureNumber == nomenNumber);
                        if (balRow != null)
                        {
                            int newQty = balRow.Quantity - qty;
                            // Проверка мин. остатка
                            var nRow = tOOLACCOUNTINGDataSet.NomenclatureView.FirstOrDefault(n => n.NomenclatureNumber == nomenNumber);
                            int minStock = nRow?.MinStock ?? 0;
                            if (newQty < minStock)
                            {
                                if (MessageBox.Show($"Итоговый остаток ({newQty}) станет меньше неснижаемого ({minStock}). Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                                {
                                    return false;
                                }
                            }
                            balRow.Quantity = newQty;
                        }

                        // Перемещаем списанную номенклатуру на склад списанного инструмента (ID = 12)
                        toId = writeOffStorageId; // гарантируем, что запись движения указывает на склад 12
                        StorageTo.Text = writeOffStorageId.ToString();
                        newRow.ToStorageID = writeOffStorageId; // корректируем строку движения

                        var balDest = tOOLACCOUNTINGDataSet.Balances.FirstOrDefault(b => b.StorageID == writeOffStorageId && b.NomenclatureNumber == nomenNumber);

                        if (balDest != null)
                        {
                            // Если остаток уже есть – увеличиваем количество
                            balDest.Quantity += qty;
                        }
                        else
                        {
                            // Иначе создаём новый остаток на складе 12
                            int newBalId = tOOLACCOUNTINGDataSet.Balances.Count == 0 ? 1 : tOOLACCOUNTINGDataSet.Balances.Max(r => r.BalanceID) + 1;
                            var newBal = tOOLACCOUNTINGDataSet.Balances.NewBalancesRow();
                            newBal.BalanceID = newBalId;
                            newBal.NomenclatureNumber = nomenNumber;
                            newBal.StorageID = writeOffStorageId;
                            newBal.BalanceDate = DateTime.Now;
                            newBal.BatchNumber = string.IsNullOrWhiteSpace(BatchNumber.Text) ? "-" : BatchNumber.Text.Trim();
                            newBal.Price = price;
                            newBal.Quantity = qty;
                            // Столбец Account может отсутствовать, поэтому заполняем, только если он существует
                            if (newBal.Table.Columns.Contains("Account"))
                            {
                                newBal["Account"] = "Списание";
                            }

                            tOOLACCOUNTINGDataSet.Balances.AddBalancesRow(newBal);
                        }

                        // Сохраняем изменения остатков
                        new BalancesTableAdapter().Update(tOOLACCOUNTINGDataSet.Balances);
                    }
                }
                else if (movementName == "Перемещение" && posted)
                {
                    // Списание со склада-отправителя
                    var balFrom = tOOLACCOUNTINGDataSet.Balances.FirstOrDefault(b => b.StorageID == fromId && b.NomenclatureNumber == nomenNumber);
                    if (balFrom != null)
                    {
                        int newQtyFrom = balFrom.Quantity - qty;

                        // Проверка неснижаемого остатка
                        var nRow = tOOLACCOUNTINGDataSet.NomenclatureView.FirstOrDefault(n => n.NomenclatureNumber == nomenNumber);
                        int minStock = nRow?.MinStock ?? 0;
                        if (newQtyFrom < minStock)
                        {
                            if (MessageBox.Show($"После перемещения остаток на складе {fromId} составит {newQtyFrom}, что ниже неснижаемого ({minStock}). Продолжить?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                            {
                                return false;
                            }
                        }

                        balFrom.Quantity = newQtyFrom;
                    }

                    // Приход на склад-получатель
                    var balTo = tOOLACCOUNTINGDataSet.Balances.FirstOrDefault(b => b.StorageID == toId && b.NomenclatureNumber == nomenNumber);

                    if (balTo != null)
                    {
                        balTo.Quantity += qty;
                    }
                    else
                    {
                        int newBalId = tOOLACCOUNTINGDataSet.Balances.Count == 0 ? 1 : tOOLACCOUNTINGDataSet.Balances.Max(r => r.BalanceID) + 1;
                        var newBal = tOOLACCOUNTINGDataSet.Balances.NewBalancesRow();
                        newBal.BalanceID = newBalId;
                        newBal.NomenclatureNumber = nomenNumber;
                        newBal.StorageID = toId;
                        newBal.BalanceDate = DateTime.Now;
                        newBal.BatchNumber = string.IsNullOrWhiteSpace(BatchNumber.Text) ? "-" : BatchNumber.Text.Trim();
                        newBal.Price = price;
                        newBal.Quantity = qty;

                        if (newBal.Table.Columns.Contains("Account"))
                        {
                            newBal["Account"] = "Перемещение";
                        }

                        tOOLACCOUNTINGDataSet.Balances.AddBalancesRow(newBal);
                    }

                    new BalancesTableAdapter().Update(tOOLACCOUNTINGDataSet.Balances);
                }

                tOOLACCOUNTINGDataSet.ToolMovements.AddToolMovementsRow(newRow);
                movementsAdapter.Update(tOOLACCOUNTINGDataSet.ToolMovements);
                movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);

                MovementSaved?.Invoke(this, EventArgs.Empty);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.ToolMovements.RejectChanges();
                MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Привязываем кнопки к обработчикам (обеспечиваем, если дизайнер не сделал)
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (MoveFormSave != null) MoveFormSave.Click += MoveFormSave_Click;
            if (MoveFormSaveClose != null) MoveFormSaveClose.Click += MoveFormSaveClose_Click;

            Quantity.Enter += (s, ev) =>
            {
                // обновляем подсказку при каждом входе в поле
                Nomenclature_Leave(null, EventArgs.Empty);
            };
        }

        private void SourceDocumentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SourceDocumentType.Text == "Дефектная ведомость")
            {
                BuildDefectiveSourceList();
                SourceDocument.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                SourceDocument.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
            else
            {
                SourceDocument.AutoCompleteMode = AutoCompleteMode.None;
                SourceDocument.AutoCompleteCustomSource = null;
            }
        }

        private void BuildDefectiveSourceList()
        {

            // Обновляем движений
            DefectiveListsTableAdapter dfList = new DefectiveListsTableAdapter();
            dfList.Fill(tOOLACCOUNTINGDataSet.DefectiveLists);
            movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);
            AutoCompleteStringCollection src = new AutoCompleteStringCollection();
            var dl = tOOLACCOUNTINGDataSet.DefectiveLists;
            
            foreach (var row in dl)
            {
                bool already = tOOLACCOUNTINGDataSet.ToolMovements.Any(m => m.SourceDocumentType == "Дефектная ведомость" && m.SourceDocumentID == row.DefectiveListID);
                if (!already)
                {
                    var fullName = tOOLACCOUNTINGDataSet.NomenclatureView.FirstOrDefault(n => n.NomenclatureNumber == row.NomenclatureNumber)?.FullName ?? string.Empty;
                    src.Add($"{row.DefectiveListID} - {row.NomenclatureNumber} - {fullName} - {row.Quantity}");
                }
            }
            SourceDocument.AutoCompleteCustomSource = src;
        }

        private void SourceDocument_Leave(object sender, EventArgs e)
        {
            ApplyDefectiveData();
        }

        private void SourceDocument_TextChanged(object sender, EventArgs e)
        {
            if (_updatingSourceDoc) return;
            if (SourceDocumentType.Text != "Дефектная ведомость") return;
            if (!SourceDocument.Text.Contains("-")) return; // ждём выбор из автокомплита
            ApplyDefectiveData();
        }

        private void ApplyDefectiveData()
        {
            string txt = SourceDocument.Text;
            int dash = txt.IndexOf('-');
            if (dash > -1) txt = txt.Substring(0, dash).Trim();
            if (!int.TryParse(txt, out int defId)) return;
            var defRow = tOOLACCOUNTINGDataSet.DefectiveLists.FirstOrDefault(d => d.DefectiveListID == defId);
            if (defRow == null) return;

            _updatingSourceDoc = true;
            SourceDocument.Text = defId.ToString();
            _updatingSourceDoc = false;

            StorageFrom.Text = tOOLACCOUNTINGDataSet.Storages.FirstOrDefault(s => s.WorkshopID == defRow.WorkshopID)?.StorageID.ToString() ?? string.Empty;
            Nomenclature.Text = defRow.NomenclatureNumber;
            BatchNumber.Text = defRow.BatchNumber;
            Price.Text = defRow.Price.ToString("0.##");
            Quantity.Text = defRow.Quantity.ToString();
        }

        private void RefreshSourceDocumentType()
        {
            SourceDocumentType.Items.Clear();

            if (Add.Checked)
            {
                SourceDocumentType.Items.Add("Товарная накладная");
            }
            else if (Moving.Checked)
            {
                SourceDocumentType.Items.Add("");
                SourceDocumentType.Items.Add("Заявка на получение");
            }
            else if (NonAdd.Checked)
            {
                SourceDocumentType.Items.Add("Дефектная ведомость");
            }

            // если текущий выбранный тип не подходит – сбрасываем
            if (!SourceDocumentType.Items.Contains(SourceDocumentType.Text))
            {
                SourceDocumentType.Text = SourceDocumentType.Items.Count > 0 ? SourceDocumentType.Items[0].ToString() : string.Empty;
            }
        }

        // ======== ПУБЛИЧНЫЕ МЕТОДЫ ДЛЯ ВНЕШНЕЙ ИНИЦИАЛИЗАЦИИ ========
        public void InitializeWriteOffFromDefective(int defectiveId)
        {
            NonAdd.Checked = true; // режим «Списание»
            Check_MoveType();
            SourceDocumentType.Text = "Дефектная ведомость";
            SourceDocument.Text = defectiveId.ToString();
            ApplyDefectiveData();
        }

        /// <summary>
        /// Устанавливает тип движения: "Приход", "Перемещение", "Списание".
        /// </summary>
        public void SelectType(string type)
        {
            switch (type)
            {
                case "Приход":
                    Add.Checked = true;
                    break;
                case "Перемещение":
                    Moving.Checked = true;
                    break;
                case "Списание":
                    NonAdd.Checked = true;
                    break;
            }
            Check_MoveType();
        }

        public void InitializeFromRequest(int requestId, string movementKind)
        {
            // movementKind: "Перемещение" или "Приход"
            SelectType(movementKind);
            SourceDocumentType.Text = "Заявка на получение";
            SourceDocument.Text = requestId.ToString();
        }
        // ======== КОНЕЦ БЛОКА ПУБЛИЧНЫХ МЕТОДОВ ========
    }
}

