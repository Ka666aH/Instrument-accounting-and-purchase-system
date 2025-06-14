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
using static Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class DefAdd : Form
    {
        AutoCompleteStringCollection nomenSource = new AutoCompleteStringCollection();
        AutoCompleteStringCollection workshopSource = new AutoCompleteStringCollection();

        // Адаптеры таблиц
        WorkshopsTableAdapter workshopsTableAdapter = new WorkshopsTableAdapter();
        NomenclatureViewTableAdapter nomenclatureViewTableAdapter = new NomenclatureViewTableAdapter();
        DefectiveListsTableAdapter defectiveListsTableAdapter = new DefectiveListsTableAdapter();
        StoragesTableAdapter storagesTableAdapter = new StoragesTableAdapter();
        BalancesTableAdapter balancesTableAdapter = new BalancesTableAdapter();

        // --- динамически создаваемые контроли (если отсутствуют в Designer) ---
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private RadioButton radioButton1;
        private RadioButton radioButton2;

        public event EventHandler DefectiveSaved;

        // Флаг, чтобы отличить программную установку значения от пользовательского ввода
        private bool _settingByCode = false;

        public DefAdd()
        {
            InitializeComponent();
            CreateDynamicControls();
            // Привязка обработчиков
            this.Load += DefAdd_Load;
            GroupFormSave.Click += GroupFormSave_Click;
            GroupFormSaveClose.Click += GroupFormSaveClose_Click;
            GroupFormClose.Click += CloseNewApplication_Click;
        }

        private void CreateDynamicControls()
        {
            // Проверяем, существуют ли уже контролы из дизайнера
            textBox5 = this.Controls.Find("textBox5", true).FirstOrDefault() as System.Windows.Forms.TextBox;
            textBox6 = this.Controls.Find("textBox6", true).FirstOrDefault() as System.Windows.Forms.TextBox;
            radioButton1 = this.Controls.Find("radioButton1", true).FirstOrDefault() as RadioButton;
            radioButton2 = this.Controls.Find("radioButton2", true).FirstOrDefault() as RadioButton;

            if (textBox5 == null)
            {
                textBox5 = new System.Windows.Forms.TextBox
                {
                    Name = "textBox5",
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Location = new Point(140, 54), // подберите при необходимости
                    Size = new Size(248, 26)
                };
                this.Controls.Add(textBox5);
            }
            if (textBox6 == null)
            {
                textBox6 = new System.Windows.Forms.TextBox
                {
                    Name = "textBox6",
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Location = new Point(140, 116), // рядом с партией; скорректируйте
                    Size = new Size(248, 26)
                };
                this.Controls.Add(textBox6);
            }
            if (radioButton1 == null)
            {
                radioButton1 = new RadioButton
                {
                    Name = "radioButton1",
                    Text = "Списание",
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Location = new Point(525, 150)
                };
                this.Controls.Add(radioButton1);
            }
            if (radioButton2 == null)
            {
                radioButton2 = new RadioButton
                {
                    Name = "radioButton2",
                    Text = "Ремонт",
                    Font = new Font("Microsoft Sans Serif", 12F),
                    Location = new Point(640, 150)
                };
                this.Controls.Add(radioButton2);
            }

            // Подписываемся на события выхода из полей для обрезки текста
            textBox5.Leave += TextBox5_Leave;
            textBox2.Leave += TextBox2_Leave;
        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {
            if (_settingByCode) return; // пропускаем обработку, если значение выставлялось кодом через Prefill

            string txt = textBox5.Text;
            int dashIdx = txt.IndexOf('-');
            if (dashIdx > 0) txt = txt.Substring(0, dashIdx).Trim();
            textBox5.Text = txt;
            // Обновляем список цехов под выбранную номенклатуру
            RefreshWorkshopSource();
            FillBatchAndPrice();
        }
        private void TextBox2_Leave(object sender, EventArgs e)
        {
            string txt = textBox2.Text;
            int dashIdx = txt.IndexOf('-');
            if (dashIdx > 0) txt = txt.Substring(0, dashIdx).Trim();
            textBox2.Text = txt;
            // Обновляем список номенклатур под выбранный цех
            RefreshNomenSource();
            FillBatchAndPrice();
        }

        /// <summary>
        /// Заполняет номер партии и учётную цену на основе остатков.
        /// </summary>
        private void FillBatchAndPrice()
        {
            string nomenNumber = textBox5.Text.Trim();
            if (string.IsNullOrWhiteSpace(nomenNumber)) return;

            int workshopId;
            bool hasWorkshop = int.TryParse(textBox2.Text.Trim(), out workshopId);

            IEnumerable<TOOLACCOUNTINGDataSet.BalancesRow> balancesQuery = tOOLACCOUNTINGDataSet.Balances
                .Where(b => b.NomenclatureNumber == nomenNumber && b.Quantity > 0);

            if (hasWorkshop)
            {
                var storageIds = tOOLACCOUNTINGDataSet.Storages.Where(s => s.WorkshopID == workshopId).Select(s => s.StorageID);
                balancesQuery = balancesQuery.Where(b => storageIds.Contains(b.StorageID));
            }

            var balanceRow = balancesQuery.OrderByDescending(b => b.BalanceDate).FirstOrDefault();

            if (balanceRow != null)
            {
                textBox6.Text = balanceRow.BatchNumber;
                textBox3.Text = balanceRow.Price.ToString("0.##");
            }
        }

        private void DefAdd_Load(object sender, EventArgs e)
        {
            // Загрузка справочных таблиц
            nomenclatureViewTableAdapter.Fill(tOOLACCOUNTINGDataSet.NomenclatureView);
            workshopsTableAdapter.Fill(tOOLACCOUNTINGDataSet.Workshops);
            storagesTableAdapter.Fill(tOOLACCOUNTINGDataSet.Storages);
            balancesTableAdapter.Fill(tOOLACCOUNTINGDataSet.Balances);
            
            RefreshWorkshopSource();
            RefreshNomenSource();

            // Назначаем источники
            textBox5.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox5.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox5.AutoCompleteCustomSource = nomenSource;

            textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
            textBox2.AutoCompleteCustomSource = workshopSource;

            // Устанавливаем номера и дату
            var defTableAdapter = new DefectiveListsTableAdapter();
            defTableAdapter.Fill(tOOLACCOUNTINGDataSet.DefectiveLists);
            ApplicationDate.Text = DateTime.Today.ToShortDateString();
            int newId = tOOLACCOUNTINGDataSet.DefectiveLists.Count == 0 ? 1 : tOOLACCOUNTINGDataSet.DefectiveLists.Max(r => r.DefectiveListID) + 1;
            textBox1.Text = newId.ToString();

        }

        private void RefreshNomenSource()
        {
            nomenSource.Clear();
            IEnumerable<string> availableNums;
            int workshopId;
            if (int.TryParse(textBox2.Text.Trim(), out workshopId))
            {
                // Получаем склады выбранного цеха
                var storageIds = tOOLACCOUNTINGDataSet.Storages.Where(s => s.WorkshopID == workshopId).Select(s => s.StorageID).ToList();
                availableNums = tOOLACCOUNTINGDataSet.Balances
                    .Where(b => storageIds.Contains(b.StorageID) && b.Quantity > 0)
                    .Select(b => b.NomenclatureNumber)
                    .Distinct();
            }
            else
            {
                // Все номенклатуры с остатком > 0
                availableNums = tOOLACCOUNTINGDataSet.Balances.Where(b => b.Quantity > 0).Select(b => b.NomenclatureNumber).Distinct();
            }
            foreach (var num in availableNums)
            {
                var name = tOOLACCOUNTINGDataSet.NomenclatureView.Where(n => n.NomenclatureNumber == num).Select(n => n.FullName).FirstOrDefault() ?? string.Empty;
                nomenSource.Add($"{num} - {name}");
            }
        }

        private void RefreshWorkshopSource()
        {
            workshopSource.Clear();
            IEnumerable<int> workshopIds;
            string nomenNumber = textBox5.Text.Trim();
            if (!string.IsNullOrWhiteSpace(nomenNumber))
            {
                var storageIds = tOOLACCOUNTINGDataSet.Balances
                    .Where(b => b.NomenclatureNumber == nomenNumber && b.Quantity > 0)
                    .Select(b => b.StorageID)
                    .Distinct();
                workshopIds = tOOLACCOUNTINGDataSet.Storages.Where(s => storageIds.Contains(s.StorageID)).Select(s => s.WorkshopID).Distinct();
            }
            else
            {
                workshopIds = tOOLACCOUNTINGDataSet.Storages.Select(s => s.WorkshopID).Distinct();
            }
            foreach (var wid in workshopIds)
            {
                var wRow = tOOLACCOUNTINGDataSet.Workshops.Where(w => w.WorkshopID == wid).FirstOrDefault();
                if (wRow != null) workshopSource.Add($"{wRow.WorkshopID} - {wRow.Name}");
            }
        }

        #region Сохранение
        private void GroupFormSave_Click(object sender, EventArgs e)
        {
            if (TrySave()) NotificationService.Notify("Успех", "Дефектная ведомость сохранена.", ToolTipIcon.Info);
        }
        private void GroupFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave()) this.Close();
        }

        private bool TrySave()
        {
            // Проверка обязательных полей
            if (string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text))
            {
                NotificationService.Notify("Предупреждение", "Заполните все обязательные поля.", ToolTipIcon.Warning);
                return false;
            }
            // Номенклатурный номер
            string nomenNumber = textBox5.Text.Trim();
            new NomenclatureTableAdapter().Fill(tOOLACCOUNTINGDataSet.Nomenclature);
            if (!Validation.IsNomenclatureNumberExist(nomenNumber, tOOLACCOUNTINGDataSet)) return false;
            // Цех
            int workshopId;
            if (!int.TryParse(textBox2.Text.Trim(), out workshopId))
            {
                NotificationService.Notify("Предупреждение", "Некорректный номер цеха.", ToolTipIcon.Warning);
                return false;
            }
            // Цена
            decimal price;
            if (!decimal.TryParse(textBox3.Text.Replace(',', '.'), System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out price))
            {
                NotificationService.Notify("Предупреждение", "Некорректная цена.", ToolTipIcon.Warning);
                return false;
            }
            // Количество
            int quantity;
            if (!int.TryParse(textBox4.Text, out quantity) || quantity <= 0)
            {
                NotificationService.Notify("Предупреждение", "Количество должно быть положительным числом.", ToolTipIcon.Warning);
                return false;
            }
            // Проверка остатков
            var storageIds = tOOLACCOUNTINGDataSet.Storages.Where(s => s.WorkshopID == workshopId).Select(s => s.StorageID).ToList();
            int availableQty = tOOLACCOUNTINGDataSet.Balances
                .Where(b => storageIds.Contains(b.StorageID) && b.NomenclatureNumber == nomenNumber)
                .Sum(b => b.Quantity);
            if (quantity > availableQty)
            {
                NotificationService.Notify("Предупреждение", $"Недостаточно остатка. Доступно {availableQty}, пытаетесь списать {quantity}.", ToolTipIcon.Warning);
                return false;
            }
            // Партия
            string batch = string.IsNullOrWhiteSpace(textBox6.Text) ? "-" : textBox6.Text.Trim();

            try
            {
                defectiveListsTableAdapter.Fill(tOOLACCOUNTINGDataSet.DefectiveLists);
                int newId = tOOLACCOUNTINGDataSet.DefectiveLists.Count == 0 ? 1 : tOOLACCOUNTINGDataSet.DefectiveLists.Max(r => r.DefectiveListID) + 1;
                var newRow = tOOLACCOUNTINGDataSet.DefectiveLists.NewDefectiveListsRow();
                newRow.DefectiveListID = newId;
                newRow.DefectiveListDate = DateTime.Today;
                newRow.NomenclatureNumber = nomenNumber;
                newRow.WorkshopID = workshopId;
                newRow.BatchNumber = batch;
                newRow.Price = price;
                newRow.Quantity = quantity;
                newRow.IsWriteOff = radioButton1.Checked; // списание == true, ремонт == false

                tOOLACCOUNTINGDataSet.DefectiveLists.AddDefectiveListsRow(newRow);
                defectiveListsTableAdapter.Update(tOOLACCOUNTINGDataSet.DefectiveLists);
                defectiveListsTableAdapter.Fill(tOOLACCOUNTINGDataSet.DefectiveLists);

                // Сообщаем внешним формам
                DefectiveSaved?.Invoke(this, EventArgs.Empty);
                return true;
            }
            catch (Exception ex)
            {
                tOOLACCOUNTINGDataSet.DefectiveLists.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка сохранения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        #endregion
        private void Digits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back) e.Handled = true;
        }

        private void CloseNewApplication_Click(object sender, EventArgs e)
        {
            new DefectiveListsTableAdapter().Fill(tOOLACCOUNTINGDataSet.DefectiveLists);
            this.Close();
        }

        /// <summary>
        /// Предварительно заполняет форму дефектной ведомости.
        /// </summary>
        public void Prefill(string nomenNumber, int workshopId, decimal price, string batchNumber)
        {
            // textBox5 – номер номенклатуры
            if (textBox5 != null)
            {
                _settingByCode = true;
                textBox5.Text = nomenNumber;
                _settingByCode = false;
            }
            // textBox2 – номер цеха (по дизайну)
            if (textBox2 != null) textBox2.Text = workshopId.ToString();
            // textBox3 – учётная цена
            if (textBox3 != null) textBox3.Text = price.ToString("0.##");
            // textBox6 – партия
            if (textBox6 != null) textBox6.Text = batchNumber;
        }
    }
}
