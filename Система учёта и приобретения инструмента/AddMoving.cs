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
            SourceDocument.SelectionChangeCommitted += SourceDocument_SelectionChanged;
            SourceDocument.Leave += SourceDocument_Leave;
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
            bool hasStorage = int.TryParse(StorageFrom.Text.Trim(), out storageId);

            if (hasStorage)
            {
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
            }

            // Если это приход (Add):
            if (Add.Checked)
            {
                // Генерируем партию, если не указана
                if (string.IsNullOrWhiteSpace(BatchNumber.Text))
                {
                    BatchNumber.Text = GenerateBatchNumber();
                }
            }

            // Если основание – товарная накладная, подтягиваем остаток и генерируем правильную партию
            if (SourceDocumentType.Text == "Товарная накладная")
            {
                string src = SourceDocument.Text;
                int dashSrc = src.IndexOf('-');
                if (dashSrc > -1) src = src.Substring(0, dashSrc).Trim();
                if (int.TryParse(src, out int invId))
                {
                    FillFromInvoice(invId, Nomenclature.Text);
                }
            }
            else if (SourceDocumentType.Text == "Заявка на получение")
            {
                string src = SourceDocument.Text;
                int dashSrc = src.IndexOf('-');
                if (dashSrc > -1) src = src.Substring(0, dashSrc).Trim();
                if (int.TryParse(src, out int reqId))
                {
                    FillFromRequest(reqId, Nomenclature.Text);
                }
            }
        }

        private void Add_CheckedChanged(object sender, EventArgs e)
        {
            Check_MoveType();
        }

        private void Check_MoveType()
        {
            // При смене вида движения обнуляем динамические поля
            ClearAllDynamicFields();

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
            // ======== Проверка обязательных полей ========
            if (Add.Checked)
            {
                if (string.IsNullOrWhiteSpace(StorageTo.Text) || string.IsNullOrWhiteSpace(Nomenclature.Text) || string.IsNullOrWhiteSpace(Quantity.Text))
                {
                    NotificationService.Notify("Предупреждение", "Для прихода укажите склад-получатель, номенклатуру и количество.", ToolTipIcon.Warning);
                    return false;
                }
            }
            else if (Moving.Checked)
            {
                if (string.IsNullOrWhiteSpace(StorageFrom.Text) || string.IsNullOrWhiteSpace(StorageTo.Text) || string.IsNullOrWhiteSpace(Nomenclature.Text) || string.IsNullOrWhiteSpace(Quantity.Text))
                {
                    NotificationService.Notify("Предупреждение", "Для перемещения заполните оба склада, номенклатуру и количество.", ToolTipIcon.Warning);
                    return false;
                }
            }
            else if (NonAdd.Checked)
            {
                if (string.IsNullOrWhiteSpace(StorageFrom.Text) || string.IsNullOrWhiteSpace(Nomenclature.Text) || string.IsNullOrWhiteSpace(Quantity.Text))
                {
                    NotificationService.Notify("Предупреждение", "Для расхода заполните склад-отправитель, номенклатуру и количество.", ToolTipIcon.Warning);
                    return false;
                }
            }

            int fromId = 0, toId, qty;
            if (Moving.Checked || NonAdd.Checked)
            {
                if (!int.TryParse(StorageFrom.Text.Trim(), out fromId))
                {
                    NotificationService.Notify("Ошибка", "Некорректный склад-отправитель.", ToolTipIcon.Error);
                    return false;
                }
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
            string movementName;
            if (Moving.Checked)
            {
                movementName = "Перемещение";   
            } else
            {
                if (NonAdd.Checked)
                    movementName = "Списание";
                else
                    movementName = "Приход";
            }
       

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
                if (Add.Checked)
                {
                    newRow.SetFromStorageIDNull(); // для прихода склада-отправителя нет
                }
                else
                {
                    newRow.FromStorageID = fromId;
                }
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
                else if (movementName == "Приход" && posted)
                {
                    // Увеличиваем остаток на складе-получателе
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
                            newBal["Account"] = "Приход";
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
            // При смене типа документа-основания очищаем выбранную номенклатуру и связанные поля
            ClearNomenFields();

            if (SourceDocumentType.Text == "Дефектная ведомость")
            {
                BuildDefectiveSourceList();
                SourceDocument.SelectedIndex = -1;
            }
            else if (SourceDocumentType.Text == "Товарная накладная")
            {
                BuildInvoiceSourceList();
                SourceDocument.SelectedIndex = -1;
            }
            else if (SourceDocumentType.Text == "Заявка на получение")
            {
                BuildRequestSourceList();
                SourceDocument.SelectedIndex = -1;
            }
            else if (SourceDocumentType.Text == "Акт о перемещении")
            {
                BuildActSourceList();
                SourceDocument.SelectedIndex = -1;
            }
            else
            {
                SourceDocument.Items.Clear();
                SourceDocument.Text = string.Empty;
            }
        }

        private void BuildDefectiveSourceList()
        {
            // Обновляем движений
            DefectiveListsTableAdapter dfList = new DefectiveListsTableAdapter();
            dfList.Fill(tOOLACCOUNTINGDataSet.DefectiveLists);
            movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);
            SourceDocument.Items.Clear();
            var dl = tOOLACCOUNTINGDataSet.DefectiveLists;
            
            var workshopAdapter = new TOOLACCOUNTINGDataSetTableAdapters.WorkshopsTableAdapter();
            workshopAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops);

            foreach (var row in dl)
            {
                bool already = tOOLACCOUNTINGDataSet.ToolMovements.Any(m => m.SourceDocumentType == "Дефектная ведомость" && m.SourceDocumentID == row.DefectiveListID);
                if (already) continue;

                var fullName = tOOLACCOUNTINGDataSet.NomenclatureView.FirstOrDefault(n => n.NomenclatureNumber == row.NomenclatureNumber)?.FullName ?? string.Empty;
                var workshopName = tOOLACCOUNTINGDataSet.Workshops.FirstOrDefault(w => w.WorkshopID == row.WorkshopID)?.Name ?? string.Empty;
                SourceDocument.Items.Add($"{row.DefectiveListID} - {workshopName} - {row.NomenclatureNumber} - {fullName} - {row.Quantity}");
            }
        }

        private void BuildInvoiceSourceList()
        {
            // загрузим содержание для дальнейших вычислений
            var invAdapter = new TOOLACCOUNTINGDataSetTableAdapters.InvoicesInjTableAdapter();
            invAdapter.Fill(tOOLACCOUNTINGDataSet.InvoicesInj);

            var invContAdapter = new TOOLACCOUNTINGDataSetTableAdapters.InvoicesContentInjTableAdapter();
            invContAdapter.Fill(tOOLACCOUNTINGDataSet.InvoicesContentInj);

            SourceDocument.Items.Clear();

            movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);

            foreach (var inv in tOOLACCOUNTINGDataSet.InvoicesInj)
            {
                var contents = tOOLACCOUNTINGDataSet.InvoicesContentInj.Where(c => c.InvoiceID == inv.InvoiceID).ToList();

                bool allDone = true;
                foreach (var c in contents)
                {
                    int moved = tOOLACCOUNTINGDataSet.ToolMovements.Where(m => m.SourceDocumentType == "Товарная накладная" && m.SourceDocumentID == inv.InvoiceID && m.NomenclatureNumber == c.NomenclatureNumber).Sum(m => m.Quantity);
                    if (moved < c.Quantity)
                    {
                        allDone = false;
                        break;
                    }
                }

                if (allDone) continue; // всю номенклатуру уже обработали

                SourceDocument.Items.Add($"{inv.InvoiceID} - {inv.InvoiceDate:dd.MM.yyyy}");
            }
        }

        private void BuildRequestSourceList()
        {
            // Загрузим заголовки и содержание заявок
            var reqAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsInjTableAdapter();
            reqAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsInj);

            var reqContAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentInjTableAdapter();
            reqContAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);

            SourceDocument.Items.Clear();

            movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);

            // подгружаем инвойсы
            var invContAdapter = new TOOLACCOUNTINGDataSetTableAdapters.InvoicesContentInjTableAdapter();
            invContAdapter.Fill(tOOLACCOUNTINGDataSet.InvoicesContentInj);

            foreach (var req in tOOLACCOUNTINGDataSet.ReceivingRequestsInj)
            {
                // учитываем только статусы «Исполнена полностью» и «Исполнена частично»
                if (!(req.Status.Contains("Исполнена"))) continue;

                var contents = tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj.Where(c => c.ReceivingRequestID == req.ReceivingRequestID).ToList();

                // Проверяем, что по всем связанным товарным накладным номенклатура перемещена на склад 0
                var invRows = tOOLACCOUNTINGDataSet.InvoicesContentInj.Where(i => i.ReceivingRequestID == req.ReceivingRequestID).ToList();

                bool allInvMoved = true;
                foreach (var inv in invRows)
                {
                    int movedToCis = tOOLACCOUNTINGDataSet.ToolMovements.Where(m => m.SourceDocumentType == "Товарная накладная" && m.SourceDocumentID == inv.InvoiceID && m.NomenclatureNumber == inv.NomenclatureNumber && m.ToStorageID == 0).Sum(m => m.Quantity);
                    if (movedToCis < inv.Quantity)
                    {
                        allInvMoved = false; break;
                    }
                }

                if (!allInvMoved) continue;

                bool allDone = true;
                foreach (var c in contents)
                {
                    int moved = tOOLACCOUNTINGDataSet.ToolMovements.Where(m => m.SourceDocumentType == "Заявка на получение" && m.SourceDocumentID == req.ReceivingRequestID && m.NomenclatureNumber == c.NomenclatureNumber).Sum(m => m.Quantity);
                    if (moved < c.Quantity)
                    {
                        allDone = false;
                        break;
                    }
                }

                if (allDone) continue; // всё уже переместили

                SourceDocument.Items.Add($"{req.ReceivingRequestID} - {req.ReceivingRequestDate:dd.MM.yyyy}");
            }
        }

        private void BuildActSourceList()
        {
            var prcAdapter = new TOOLACCOUNTINGDataSetTableAdapters.PurchaseRequestsContentInjTableAdapter();
            prcAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);

            var reqAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsInjTableAdapter();
            reqAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsInj);

            SourceDocument.Items.Clear();
            movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);

            // выбираем заявки, у которых есть пункты с IsPurchase = false
            var reqIds = tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj.Where(p => !p.IsPurchase).Select(p => p.ReceivingRequestID).Distinct();

            foreach (var reqId in reqIds)
            {
                var reqRow = tOOLACCOUNTINGDataSet.ReceivingRequestsInj.FirstOrDefault(r => r.ReceivingRequestID == reqId);
                if (reqRow == null) continue;

                // Проверяем, есть ли ещё что перемещать
                var prcRows = tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj.Where(p => p.ReceivingRequestID == reqId && !p.IsPurchase).ToList();

                bool allMoved = true;
                foreach (var pr in prcRows)
                {
                    var rrc = tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj.FirstOrDefault(c => c.ReceivingContentID == pr.ReceivingContentID);
                    if (rrc == null) continue;

                    int moved = tOOLACCOUNTINGDataSet.ToolMovements.Where(m => m.SourceDocumentType == "Акт о перемещении" && m.SourceDocumentID == reqId && m.NomenclatureNumber == rrc.NomenclatureNumber).Sum(m => m.Quantity);
                    if (moved < rrc.Quantity)
                    {
                        allMoved = false; break;
                    }
                }

                if (allMoved) continue;

                SourceDocument.Items.Add($"{reqRow.ReceivingRequestID} - {reqRow.ReceivingRequestDate:dd.MM.yyyy}");
            }
        }

        private void ApplyDefectiveData()
        {
            string txt = SourceDocument.Text;
            int dash = txt.IndexOf('-');
            if (dash > -1) txt = txt.Substring(0, dash).Trim();
            if (!int.TryParse(txt, out int defId)) return;
            var defRow = tOOLACCOUNTINGDataSet.DefectiveLists.FirstOrDefault(d => d.DefectiveListID == defId);
            if (defRow == null) return;

            StorageFrom.Text = tOOLACCOUNTINGDataSet.Storages.FirstOrDefault(s => s.WorkshopID == defRow.WorkshopID)?.StorageID.ToString() ?? string.Empty;
            Nomenclature.Text = defRow.NomenclatureNumber;
            BatchNumber.Text = defRow.BatchNumber;
            Price.Text = defRow.Price.ToString("0.##");
            Quantity.Text = defRow.Quantity.ToString();

            // склад-получатель по сценарию: ремонт → 13, списание → 12
            if (defRow.IsWriteOff)
                StorageTo.Text = "12"; // списание
            else
                StorageTo.Text = "13"; // ремонт
        }

        private void ApplyInvoiceData()
        {
            string txt = SourceDocument.Text;
            int dash = txt.IndexOf('-');
            if (dash > -1) txt = txt.Substring(0, dash).Trim();
            if (!int.TryParse(txt, out int invId)) return;

            // Загружаем содержание накладной
            var invContAdapter = new TOOLACCOUNTINGDataSetTableAdapters.InvoicesContentInjTableAdapter();
            invContAdapter.Fill(tOOLACCOUNTINGDataSet.InvoicesContentInj);

            // построим список номеклатуры, которая ещё не приходовала по этой накладной
            var rowsGrouped = tOOLACCOUNTINGDataSet.InvoicesContentInj
                .Where(r => r.InvoiceID == invId)
                .GroupBy(r => r.NomenclatureNumber)
                .Select(g => new { Nomen = g.Key, Qty = g.Sum(x => x.Quantity) })
                .ToList();

            // обновим движения
            movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);

            nomenSource.Clear();
            foreach (var gr in rowsGrouped)
            {
                bool already = tOOLACCOUNTINGDataSet.ToolMovements.Any(m => m.SourceDocumentType == "Товарная накладная" && m.SourceDocumentID == invId && m.NomenclatureNumber == gr.Nomen);
                if (already) continue;
                var fullName = tOOLACCOUNTINGDataSet.NomenclatureView.FirstOrDefault(n => n.NomenclatureNumber == gr.Nomen)?.FullName ?? string.Empty;
                nomenSource.Add($"{gr.Nomen} - {fullName} - {gr.Qty}");
            }

            Nomenclature.AutoCompleteCustomSource = nomenSource;
            Nomenclature.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Nomenclature.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // если осталась только одна позиция – сразу заполняем поля
            if (nomenSource.Count == 1)
            {
                Nomenclature.Text = nomenSource[0].Split('-')[0].Trim();
                FillFromInvoice(invId, Nomenclature.Text);
            }
        }

        private void ApplyRequestData()
        {
            string txt = SourceDocument.Text;
            int dash = txt.IndexOf('-');
            if (dash > -1) txt = txt.Substring(0, dash).Trim();
            if (!int.TryParse(txt, out int reqId)) return;

            // Загрузка таблиц
            var reqContAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentInjTableAdapter();
            reqContAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);

            var reqAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsInjTableAdapter();
            reqAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsInj);

            var storAdapter = new TOOLACCOUNTINGDataSetTableAdapters.StoragesTableAdapter();
            storAdapter.Fill(tOOLACCOUNTINGDataSet.Storages);

            // Определяем склад-получатель по цеху заявки
            var reqRow = tOOLACCOUNTINGDataSet.ReceivingRequestsInj.FirstOrDefault(r => r.ReceivingRequestID == reqId);
            if (reqRow != null)
            {
                int workshopId = 0;
                if (!reqRow.IsWorkshopNumberNameNull())
                {
                    string wn = reqRow.WorkshopNumberName;
                    int d = wn.IndexOf('-');
                    if (d > -1) wn = wn.Substring(0, d).Trim();
                    int.TryParse(wn, out workshopId);
                }

                if (workshopId > 0)
                {
                    var storageRow = tOOLACCOUNTINGDataSet.Storages.FirstOrDefault(s => s.WorkshopID == workshopId);
                    if (storageRow != null)
                    {
                        StorageTo.Text = storageRow.StorageID.ToString();
                    }
                }
            }

            // Обновим движения
            movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);

            nomenSource.Clear();
            var rows = tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj.Where(r => r.ReceivingRequestID == reqId).ToList();

            foreach (var r in rows)
            {
                int moved = tOOLACCOUNTINGDataSet.ToolMovements.Where(m => m.SourceDocumentType == "Заявка на получение" && m.SourceDocumentID == reqId && m.NomenclatureNumber == r.NomenclatureNumber).Sum(m => m.Quantity);
                int remaining = r.Quantity - moved;
                if (remaining <= 0) continue;
                var fullName = r.FullName ?? string.Empty;
                nomenSource.Add($"{r.NomenclatureNumber} - {fullName} - {remaining}");
            }

            Nomenclature.AutoCompleteCustomSource = nomenSource;
            Nomenclature.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Nomenclature.AutoCompleteSource = AutoCompleteSource.CustomSource;

            if (nomenSource.Count == 1)
            {
                Nomenclature.Text = nomenSource[0].Split('-')[0].Trim();
                FillFromRequest(reqId, Nomenclature.Text);
            }
        }

        private void ApplyActData()
        {
            string txt = SourceDocument.Text;
            int dash = txt.IndexOf('-');
            if (dash > -1) txt = txt.Substring(0, dash).Trim();
            if (!int.TryParse(txt, out int reqId)) return;

            var prcAdapter = new TOOLACCOUNTINGDataSetTableAdapters.PurchaseRequestsContentInjTableAdapter();
            prcAdapter.Fill(tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);

            var reqContAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentInjTableAdapter();
            reqContAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);

            var reqAdapter = new TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsInjTableAdapter();
            reqAdapter.Fill(tOOLACCOUNTINGDataSet.ReceivingRequestsInj);

            var storAdapter = new TOOLACCOUNTINGDataSetTableAdapters.StoragesTableAdapter();
            storAdapter.Fill(tOOLACCOUNTINGDataSet.Storages);

            // склад-получатель определяется как склад цеха заявки
            var reqRow = tOOLACCOUNTINGDataSet.ReceivingRequestsInj.FirstOrDefault(r => r.ReceivingRequestID == reqId);
            if (reqRow != null && !reqRow.IsWorkshopNumberNameNull())
            {
                string wn = reqRow.WorkshopNumberName;
                int d = wn.IndexOf('-');
                if (d > -1) wn = wn.Substring(0, d).Trim();
                if (int.TryParse(wn, out int wid))
                {
                    var stor = tOOLACCOUNTINGDataSet.Storages.FirstOrDefault(s => s.WorkshopID == wid);
                    if (stor != null) StorageTo.Text = stor.StorageID.ToString();
                }
            }

            movementsAdapter.Fill(tOOLACCOUNTINGDataSet.ToolMovements);

            nomenSource.Clear();

            var prcRows = tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj.Where(p => p.ReceivingRequestID == reqId && !p.IsPurchase).ToList();

            foreach (var pr in prcRows)
            {
                var rrc = tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj.FirstOrDefault(c => c.ReceivingContentID == pr.ReceivingContentID);
                if (rrc == null) continue;

                int moved = tOOLACCOUNTINGDataSet.ToolMovements.Where(m => m.SourceDocumentType == "Акт о перемещении" && m.SourceDocumentID == reqId && m.NomenclatureNumber == rrc.NomenclatureNumber).Sum(m => m.Quantity);
                int remaining = rrc.Quantity - moved;
                if (remaining <= 0) continue;

                nomenSource.Add($"{rrc.NomenclatureNumber} - {rrc.FullName} - {remaining}");
            }

            Nomenclature.AutoCompleteCustomSource = nomenSource;
            Nomenclature.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            Nomenclature.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void SourceDocument_SelectionChanged(object sender, EventArgs e)
        {
            // При выборе другого конкретного документа сначала очищаем связанные поля
            ClearNomenFields();

            if (_updatingSourceDoc) return;
            if (SourceDocumentType.Text == "Дефектная ведомость")
            {
                ApplyDefectiveData();
            }
            else if (SourceDocumentType.Text == "Товарная накладная")
            {
                ApplyInvoiceData();
            }
            else if (SourceDocumentType.Text == "Заявка на получение")
            {
                ApplyRequestData();
            }
            else if (SourceDocumentType.Text == "Акт о перемещении")
            {
                ApplyActData();
            }
        }

        private void SourceDocument_Leave(object sender, EventArgs e)
        {
            if (SourceDocumentType.Text == "Дефектная ведомость") ApplyDefectiveData();
            else if (SourceDocumentType.Text == "Товарная накладная") ApplyInvoiceData();
            else if (SourceDocumentType.Text == "Заявка на получение") ApplyRequestData();
            else if (SourceDocumentType.Text == "Акт о перемещении") ApplyActData();
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
                SourceDocumentType.Items.Add("Акт о перемещении");
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

        private void MoveFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // ======== КОНЕЦ БЛОКА ПУБЛИЧНЫХ МЕТОДОВ ========

        // ======== ГЕНЕРАЦИЯ ПАРТИИ ========
        private string GenerateBatchNumber()
        {
            string datePart = DateTime.Today.ToString("yyyyMMdd");
            // найти максимальный порядковый номер среди существующих партий с такой датой
            var existing = tOOLACCOUNTINGDataSet.Balances
                .Cast<TOOLACCOUNTINGDataSet.BalancesRow>()
                .Where(b => !string.IsNullOrEmpty(b.BatchNumber) && b.BatchNumber.StartsWith(datePart))
                .Select(b =>
                {
                    string[] parts = b.BatchNumber.Split('-');
                    if (parts.Length == 2 && int.TryParse(parts[1], out int num)) return num; else return 0;
                })
                .ToList();
            int next = existing.Count == 0 ? 1 : existing.Max() + 1;
            return $"{datePart}-{next:000}";
        }

        private void FillFromInvoice(int invoiceId, string nomenNumber)
        {
            var contRow = tOOLACCOUNTINGDataSet.InvoicesContentInj.FirstOrDefault(c => c.InvoiceID == invoiceId && c.NomenclatureNumber == nomenNumber);
            if (contRow == null) return;
            int total = tOOLACCOUNTINGDataSet.InvoicesContentInj
                .Where(c => c.InvoiceID == invoiceId && c.NomenclatureNumber == nomenNumber)
                .Sum(c => c.Quantity);

            if (total == 0) return;
            int already = tOOLACCOUNTINGDataSet.ToolMovements.Where(m => m.SourceDocumentType == "Товарная накладная" && m.SourceDocumentID == invoiceId && m.NomenclatureNumber == nomenNumber).Sum(m => m.Quantity);
            int remaining = total - already;
            if (remaining < 0) remaining = 0;
            Quantity.Text = remaining.ToString();
            if (string.IsNullOrWhiteSpace(BatchNumber.Text)) BatchNumber.Text = GenerateBatchNumber();
        }

        private void FillFromRequest(int requestId, string nomenNumber)
        {
            var contRow = tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj.FirstOrDefault(c => c.ReceivingRequestID == requestId && c.NomenclatureNumber == nomenNumber);
            if (contRow == null) return;

            int already = tOOLACCOUNTINGDataSet.ToolMovements.Where(m => m.SourceDocumentType == "Заявка на получение" && m.SourceDocumentID == requestId && m.NomenclatureNumber == nomenNumber).Sum(m => m.Quantity);
            int remaining = contRow.Quantity - already;
            if (remaining < 0) remaining = 0;

            Quantity.Text = remaining.ToString();

            // Пытаемся подобрать существующую партию из остатков (склад зависит от вида движения)
            int searchStorageId = -1;
            if (Moving.Checked && int.TryParse(StorageFrom.Text.Trim(), out int fid)) searchStorageId = fid;
            else if (!Moving.Checked && int.TryParse(StorageTo.Text.Trim(), out int tid)) searchStorageId = tid;

            if (searchStorageId > 0)
            {
                var bal = tOOLACCOUNTINGDataSet.Balances
                    .Where(b => b.StorageID == searchStorageId && b.NomenclatureNumber == nomenNumber && b.Quantity > 0)
                    .OrderByDescending(b => b.BalanceDate)
                    .FirstOrDefault();

                if (bal != null)
                {
                    BatchNumber.Text = bal.BatchNumber;
                }
            }

            // Если партия всё ещё не определена – генерируем новую
            if (string.IsNullOrWhiteSpace(BatchNumber.Text))
            {
                BatchNumber.Text = GenerateBatchNumber();
            }
        }

        /// <summary>
        /// Очищает поля, связанные с выбранной номенклатурой.
        /// </summary>
        private void ClearNomenFields()
        {
            Nomenclature.Text = string.Empty;
            BatchNumber.Text = string.Empty;
            Quantity.Text = string.Empty;
            Price.Text = string.Empty;
        }

        /// <summary>
        /// Полная очистка динамических полей (используется при смене вида движения).
        /// </summary>
        private void ClearAllDynamicFields()
        {
            ClearNomenFields();
            SourceDocument.Text = string.Empty;
            // Дополнительно обнулим списки документов-оснований
            SourceDocument.Items.Clear();
        }
    }
}

