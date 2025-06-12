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
    public partial class DeleviryListForm : Form
    {
        public DeleviryListForm()
        {
            InitializeComponent();
        }

        private void DeleviryListForm_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DeliveryListsContentInj". При необходимости она может быть перемещена или удалена.
            this.deliveryListsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DeliveryListsContentInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.DeliveryListsContent". При необходимости она может быть перемещена или удалена.
            this.deliveryListsContentTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.DeliveryListsContent);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj". При необходимости она может быть перемещена или удалена.
            this.purchaseRequestsContentInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.PurchaseRequestsContentInj);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "tOOLACCOUNTINGDataSet.PurchaseRequestsInj". При необходимости она может быть перемещена или удалена.
            this.purchaseRequestsInjTableAdapter.Fill(this.tOOLACCOUNTINGDataSet.PurchaseRequestsInj);

        }
    }
}
