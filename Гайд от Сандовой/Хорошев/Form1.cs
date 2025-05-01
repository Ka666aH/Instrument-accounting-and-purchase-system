using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDDataSet.Query2". При необходимости она может быть перемещена или удалена.
                        this.predmetTableAdapter.Fill(this.sTUDDataSet1.Predmet);
            this.query2TableAdapter.Fill(this.sTUDDataSet.Query2);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDDataSet1.Predmet". При необходимости она может быть перемещена или удалена.
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDDataSet.Query1". При необходимости она может быть перемещена или удалена.
         //   this.query1TableAdapter.Fill(this.sTUDDataSet.Query1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || listBox1.SelectedIndex<0)
            { MessageBox.Show("пусто!"); return; }
            query2BindingSource.RemoveFilter();

            string filt= "(ocenka = "+textBox1.Text+") and (att = '"+
   listBox1.Text+ " ') and (pnam='" + textBox2.Text + " ')";
            query2BindingSource.Filter = filt;

            int count = query2BindingSource.Count;
               // sTUDDataSet.Query1.DefaultView.Count;
            if (count == 0) MessageBox.Show("Таких нет!");
          

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            query2BindingSource.RemoveFilter();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" ||  listBox1.SelectedIndex < 0)
            { MessageBox.Show("пусто!"); return; }
            query2BindingSource.RemoveFilter();

            string filt = "(ocenka = " + textBox1.Text + ") and (att = '" +
   listBox1.Text + " ') and (pnam='" + comboBox1.Text + " ')";
            query2BindingSource.Filter = filt;

            int count = query2BindingSource.Count;
            // sTUDDataSet.Query1.DefaultView.Count;
            if (count == 0) MessageBox.Show("Таких нет!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            query2BindingSource.RemoveFilter();

            string filt = "(Year>=" + numericUpDown1.Value + ") and (Year<=" + numericUpDown2.Value + ")";
            query2BindingSource.Filter = filt;

            int count = query2BindingSource.Count;
            // sTUDDataSet.Query1.DefaultView.Count;
            if (count == 0) MessageBox.Show("Таких нет!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && e.RowIndex>0)
            {
                predmet1TableAdapter.Fill(sTUDDataSet.Predmet1,this.dataGridView1.CurrentCell.Value.ToString());


                var id = ((DataRowView)predmet1BindingSource.Current)
 .Row.Field<string>("Tfam"); 
                var id1 = ((DataRowView)predmet1BindingSource.Current)
     .Row.Field<Int16>("Cours");
                var id2 = ((DataRowView)predmet1BindingSource.Current)
    .Row.Field<int>("Hours");
                MessageBox.Show("Преподаватель "+id.ToString()+ "  курс - " + id1.ToString()+"  часов " + id2.ToString());
               // MessageBox.Show(id1.ToString());
            }
     

            //MessageBox.Show(this.dataGridView1.CurrentCell.Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*
            DataRow myRow = this.sTUDDataSet.Predmet.NewRow();
            var id = ((DataRowView)predmetBindingSource.Current)
    .Row.Field<int>("Pnum");


            MessageBox.Show(id.ToString()); 



            // **********вывод значения поля ************************************
       textBox3.DataBindings.Add("Text", predmetBindingSource, "Pnam");
            // **********
            */
            query2BindingSource.RemoveFilter();

            /*  SqlDataAdapter adapterInvChek = new SqlDataAdapter(predmetTableAdapter);
              DataSet dsInvChek = new DataSet();
              adapterInvChek.Fill(dsInvChek, "Pnam");
              textBox3.DataBindings.Add("Text", dsInvChek, "Inventory_Number.FIO");
              MessageBox.Show(ex.ToString());*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();

        }
    }
}
