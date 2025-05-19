using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_учёта_и_приобретения_инструмента
{
    public enum FormMode
    {
        Add,
        Edit
    }
    public partial class Inj : Form
    {
        LoginForm login;
        bool changeUser = false;
        public Inj(LoginForm _login)
        {
            InitializeComponent();
            login = _login;
            //DateTime date = DateTime.Today;
            //MessageBox.Show(date.ToString());
        }

        private void Inj_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (changeUser)
                login.Show();
            else
                login.Close();
        }

        private void сменитьПользователяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            changeUser = true;
            Close();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Inj_Load(object sender, EventArgs e)
        {
            
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureLogs". При необходимости она может быть перемещена или удалена.
            this.nomenclatureLogsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureLogs);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Groups". При необходимости она может быть перемещена или удалена.
            this.groupsTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Groups);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.NomenclatureWithFullName". При необходимости она может быть перемещена или удалена.
            this.nomenclatureWithFullNameTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.NomenclatureWithFullName);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.Suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.Suppliers);
            
            WindowState = FormWindowState.Maximized;

            LogStart.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            LogEnd.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month + 1, 1).AddDays(-1);
        }

        private void InjLevel1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (InjLevel1.SelectedIndex == 4)
            {
                //suppliersTableAdapter.Update(tOOLACCOUNTINGDataSet.Suppliers);
                //suppliersTableAdapter.Fill(tOOLACCOUNTINGDataSet.Suppliers);
            }
        }

        #region Номенклатура инструмента

        #endregion

        #region Группы инструментов

        #endregion

        #region Приобретение инструмента

        #region Заявки от цехов

        #endregion

        #region Принятые заявки от цехов

        #endregion

        #region Создание заявки на приобретение

        #endregion

        #region Список заявок на приобретение

        #endregion

        #region Ведомости поставки

        #endregion

        #region Товарные накладные

        #endregion

        #region История поступлений

        #endregion

        #endregion

        #region Поставщики

        private void ProvidersButtonCreate_Click(object sender, EventArgs e)
        {
            SupForm supForm = new SupForm(tOOLACCOUNTINGDataSet,suppliersTableAdapter);
            supForm.ShowDialog();
        }

        private void ProvidersButtonAlter_Click(object sender, EventArgs e)
        {
            var selectedRow = ProvidersTable.CurrentRow.DataBoundItem as DataRowView;
            if (selectedRow != null)
            {
                var supplierRow = selectedRow.Row as TOOLACCOUNTINGDataSet.SuppliersRow;
                SupForm supForm = new SupForm(tOOLACCOUNTINGDataSet, suppliersTableAdapter, FormMode.Edit, supplierRow);
                supForm.ShowDialog();
            }     
        }

        private void ProvidersButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void ProvidersTable_CurrentCellChanged(object sender, EventArgs e)
        {
            if (ProvidersTable.CurrentRow == null) ProvidersButtonAlter.Enabled = false;
            else ProvidersButtonAlter.Enabled = true;
        }
        private void SuppliersTextChanged(object sender, EventArgs e)
        {
            var parameters = new Dictionary<string, object>();
            if (!string.IsNullOrEmpty(ProvidersINN.Text)) parameters.Add("INN", ProvidersINN.Text);
            if (!string.IsNullOrEmpty(ProvidersName.Text)) parameters.Add("Name", ProvidersName.Text);
            string filter = Search.Filter(parameters);
            ProvidersTable.SuspendLayout();
            suppliersBindingSource.Filter = filter;
            ProvidersTable.ResumeLayout();
        }


        #endregion

        #region Аналоги инструментов

        #endregion

        #region Поставщики

        #endregion

        #region Логи корректировокв

        #endregion

        #region Остатки номенклатуры

        #endregion

    }
}
