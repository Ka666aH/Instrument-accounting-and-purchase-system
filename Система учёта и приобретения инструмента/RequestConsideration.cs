using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Система_учёта_и_приобретения_инструмента
{
    public partial class RequestConsideration : Form
    {
        int requestNumber;
        FormMode mode;
        public RequestConsideration(int _requestNumber, FormMode _mode)
        {
            InitializeComponent();
            requestNumber = _requestNumber;
            mode = _mode;
        }

        private void RequestConsideration_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReplacementFixationInj". При необходимости она может быть перемещена или удалена.
            this.replacementFixationInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReplacementFixationInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContentInj);

            string filter = $"ReceivingRequestID = {requestNumber}";
            receivingRequestsContentInjBindingSource.Filter = filter;
        }

        private void SetRequestConsiderationButtonsState()
        {
            try
            {
                bool state = RequestConsiderationFixationTable.CurrentRow != null && !string.IsNullOrEmpty(RequestConsiderationFixationTable.CurrentRow.Cells[0].Value.ToString());
                RequestConsiderationButtonAlter.Enabled = state;
                RequestConsiderationButtonDelete.Enabled = state;
            }
            catch { }
        }

        private void RequestConsiderationFixationTable_CurrentCellChanged(object sender, EventArgs e)
        {
            SetRequestConsiderationButtonsState();
        }

        private void RequestConsiderationButtonCreate_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonAlter_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonDelete_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonSave_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonSaveClose_Click(object sender, EventArgs e)
        {

        }

        private void RequestConsiderationButtonClose_Click(object sender, EventArgs e)
        {

        }
    }
}
