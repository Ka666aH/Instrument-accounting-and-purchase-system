using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class SupForm : Form
    {
        TOOLACCOUNTINGDataSet toolAccounting;
        SuppliersTableAdapter suppliersTableAdapter;
        public SupForm(TOOLACCOUNTINGDataSet _toolAccounting, SuppliersTableAdapter _suppliersTableAdapter)
        {
            InitializeComponent();
            toolAccounting = _toolAccounting;
            suppliersTableAdapter = _suppliersTableAdapter;
        }

        private void SupForm_Load(object sender, EventArgs e)
        {
            //notifyIcon1.Visible = true;
            //notifyIcon1.ShowBalloonTip(0, "Добавление записи", "Новый поставщик добавлен.", ToolTipIcon.Info);
        }

        private void Notify(string title, string text, ToolTipIcon icon)
        {
            notifyIcon1.Visible = true;
            notifyIcon1.ShowBalloonTip(0, title, text, icon);
        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
        }

        private void SupFormSave_Click(object sender, EventArgs e)
        {
            if(TrySave())
            {
                ClearForm();
                SupFormINN.Focus();
            }
        }

        private bool TrySave()
        {
            if (!AllRequiredFieldsFilled())
            {
                Notify("Предупреждение", "Необходимо заполнить все обязательные поля (отмечены *).", ToolTipIcon.Warning);
                return false;
            }

            if (!IsInnValid())
            {
                Notify("Предупреждение", "ИНН должен содержать 10 цифр (для юридических лиц) или 12 цифр (для физических лиц и индивидуальных предпринимателей).", ToolTipIcon.Warning);
                return false;
            }

            if (!IsINNUnique())
            {
                Notify("Предупреждение", "Поставщик с таким ИНН уже существует.", ToolTipIcon.Warning);
                return false;
            }
            try
            {
                SaveSupplier();
                return true;
            }
            catch (Exception ex)
            {
                //toolAccounting.RejectChanges();
                MessageBox.Show(ex.Message, "Ошибка");
                return false;
            }
        }

        private bool AllRequiredFieldsFilled()
        {
            return !string.IsNullOrEmpty(SupFormINN.Text) &&
                   !string.IsNullOrEmpty(SupFormName.Text) &&
                   !string.IsNullOrEmpty(SupFormAddress.Text) &&
                   !string.IsNullOrEmpty(SupFormContacts.Text);
        }

        private bool IsInnValid()
        {
            return (SupFormINN.TextLength == 10 || SupFormINN.TextLength == 12) && SupFormINN.Text.All(char.IsDigit);
            //Стоит ли добавить проверку контрольной суммы ИНН?
        }

        private bool IsINNUnique()
        {
            string inn = SupFormINN.Text;
            return !toolAccounting.Suppliers.Any(s => s.INN == inn);
        }

        private void SaveSupplier()
        {
            var newRow = toolAccounting.Suppliers.NewSuppliersRow();

            newRow.INN = SupFormINN.Text;
            newRow.Name = SupFormName.Text;
            newRow.LegalAddress = SupFormAddress.Text;
            newRow.Contacts = SupFormContacts.Text;
            newRow.Notes = string.IsNullOrEmpty(SupFormNotes.Text)
                ? null
                : SupFormNotes.Text;

            toolAccounting.Suppliers.Rows.Add(newRow);
            suppliersTableAdapter.Update(toolAccounting.Suppliers);
            //suppliersTableAdapter.Fill(toolAccounting.Suppliers);
        }

        private void ClearForm()
        {
            SupFormINN.Clear();
            SupFormName.Clear();
            SupFormAddress.Clear();
            SupFormContacts.Clear();
            SupFormNotes.Clear();

            //foreach (Control control in this.Controls)
            //{
            //    if (control is TextBox textBox)
            //    {
            //        //textBox.Text = "БЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИБЕГИ";
            //        textBox.Text = string.Empty;
            //    }
            //}
        }

        private void SupFormSaveClose_Click(object sender, EventArgs e)
        {
            if (TrySave())
                Close();
        }

        private void SupFormClose_Click(object sender, EventArgs e)
        {
            if (!AllFieldsEmpty())
            {
                DialogResult result = MessageBox.Show("Вы уверены, что закрыть форму? Все несохранённые данные будут потеряны.", "Подтверждение закрытия", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (result == DialogResult.No) return;
            }

            Close();
        }

        private bool AllFieldsEmpty()
        {
            return string.IsNullOrEmpty(SupFormINN.Text) &&
            string.IsNullOrEmpty(SupFormName.Text) &&
            string.IsNullOrEmpty(SupFormAddress.Text) &&
            string.IsNullOrEmpty(SupFormContacts.Text) &&
            string.IsNullOrEmpty(SupFormNotes.Text);
        }
    }
}
