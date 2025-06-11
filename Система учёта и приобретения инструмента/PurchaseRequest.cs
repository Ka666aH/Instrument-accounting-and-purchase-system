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
    public partial class PurchaseRequest : Form
    {
        public PurchaseRequest()
        {
            InitializeComponent();
        }

        private void PurchaseRequest_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsContentInjWithReplace". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsContentInjWithReplaceTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsContentInjWithReplace);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.ReceivingRequestsInj". При необходимости она может быть перемещена или удалена.
            this.receivingRequestsInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.ReceivingRequestsInj);

        }
    }
}
