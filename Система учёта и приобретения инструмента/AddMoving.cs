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
        }

        private void ConfigureStorageAutoComplete(TextBox tb)
        {
            tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            tb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            tb.AutoCompleteCustomSource = storageSource;
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
        }

        private void Add_CheckedChanged(object sender, EventArgs e)
        {
            Check_MoveType();
        }

        private void Check_MoveType()
        {
            if (Add.Checked)
            {

                StorageTo.ReadOnly = false;
                label15.Text = "Тип документа *";
                label7.Text = "Документ-основание *";
                label5.Text = "Склад-отправитель";
                SourceDocumentType.Text = null;
                StorageTo.Text = "0";
                StorageFrom.Text = null;
                StorageFrom.ReadOnly = true;
            }
            else
            {
                if (NonAdd.Checked)
                {

                    StorageTo.Text = "12";
                    StorageTo.ReadOnly = true;
                    label15.Text = "Тип документа *";
                    label7.Text = "Документ-основание *";
                    label5.Text = "Склад-отправитель *";
                    SourceDocumentType.Text = "Дефектная ведомость";
                }
                else
                {
                    label15.Text = "Тип документа";
                    StorageTo.Text = null;
                    StorageFrom.Text = "0";
                    label7.Text = "Документ-основание";
                    StorageTo.ReadOnly = false;
                    label5.Text = "Склад-отправитель *";
                    SourceDocumentType.Text = null;
                }
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
    }
}
