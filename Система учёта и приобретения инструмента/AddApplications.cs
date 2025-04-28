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
    public partial class AddApplications: Form
    {
        public AddApplications()
        {
            InitializeComponent();
        }

        private void AddApplications_Load(object sender, EventArgs e)
        {
            ApplicationDate.Text = DateTime.Today.ToShortDateString();
            ApplicationType.SelectedIndex = 0;
            dateTimePicker1.MinDate = DateTime.Today;
            dateTimePicker1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.AddMonths(3).Month, 1);
        }

        private void Reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Reason.Text == "Другое")
            {
                OtherReasonText.Visible = true;
                OtherReason.Visible = true;
            }
            else
            {
                OtherReasonText.Visible = false;
                OtherReason.Visible = false;
            }
        }

        private void CloseNewApplication_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
