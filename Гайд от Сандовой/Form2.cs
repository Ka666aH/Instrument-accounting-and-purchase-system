using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _16_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {//предмет
            int clat;
            clat = Convert.ToInt32(textBox2.Text);


            if (clat < 10 || clat > 1000)
            {
                MessageBox.Show("Неверное количество часов!"); textBox2.Text = ""; return;
            }
            DataRow myRow2 = pRIM3DataSet.Tables["Predmet"].NewRow();

            myRow2["pnum"] = 0;
            myRow2["pnam"] = textBox1.Text;
            myRow2["hours"] = Convert.ToInt32(textBox2.Text);
            myRow2["kontr"] = comboBox3.Text;
//занесение
            pRIM3DataSet.Predmet.Rows.Add(myRow2);
//обновление
            this.predmetTableAdapter.Update(this.pRIM3DataSet.Predmet);
//заполнение источника
            this.predmetTableAdapter.Fill(this.pRIM3DataSet.Predmet);

            textBox1.Text = "";
            textBox2.Text = "";
            comboBox3.SelectedIndex = -1;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pRIM3DataSet.Teachers". При необходимости она может быть перемещена или удалена.
            this.teachersTableAdapter.Fill(this.pRIM3DataSet.Teachers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pRIM3DataSet.Usp". При необходимости она может быть перемещена или удалена.
            this.uspTableAdapter.Fill(this.pRIM3DataSet.Usp);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pRIM3DataSet.Teachers". При необходимости она может быть перемещена или удалена.
            this.teachersTableAdapter.Fill(this.pRIM3DataSet.Teachers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pRIM3DataSet.Students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.pRIM3DataSet.Students);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pRIM3DataSet.Predmet". При необходимости она может быть перемещена или удалена.
            this.predmetTableAdapter.Fill(this.pRIM3DataSet.Predmet);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "pRIM3DataSet.Grupp". При необходимости она может быть перемещена или удалена.
            this.gruppTableAdapter.Fill(this.pRIM3DataSet.Grupp);
           

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataRow myRow2 = pRIM3DataSet.Tables["Students"].NewRow();

            myRow2["snum"] = 0;
            myRow2["sfam"] = t_sfam.Text;
            myRow2["snam"] = t_snam.Text;
            myRow2["sotch"] = t_sotch.Text;
            myRow2["stip"] = Convert.ToInt32(t_stip.Text);
            myRow2["dat_r"] = tp_sdr.Value.ToShortDateString();
           // MessageBox.Show(dateTimePicker1.Value.ToShortDateString());
            myRow2["hobby"] = cb_shob.Text;
            myRow2["k_gr"] = Convert.ToInt32(cb_sgr.SelectedValue);

            //  MessageBox.Show(comboBox2.SelectedValue.ToString());
            pRIM3DataSet.Students.Rows.Add(myRow2);

            this.studentsTableAdapter.Update(this.pRIM3DataSet.Students);

            this.studentsTableAdapter.Fill(this.pRIM3DataSet.Students);


        }

        private void button6_Click(object sender, EventArgs e)
        {
            int oc= Convert.ToInt32(textBox7.Text);
            if (oc <= 0 || oc > 5)
            {
                MessageBox.Show("Неверное значение оценки!"); textBox7.Text = ""; return;
            }

            DataRow myRow2 = pRIM3DataSet.Tables["Usp"].NewRow();

            myRow2["snum"] = Convert.ToInt32(listBox1.SelectedValue); 
            myRow2["tnum"] = Convert.ToInt32(listBox2.SelectedValue); 
            myRow2["pnum"] = Convert.ToInt32(listBox3.SelectedValue); 
            myRow2["ocenka"] = Convert.ToInt32(textBox7.Text);
            myRow2["udate"] = dateTimePicker2.Value.ToShortDateString();
           
            
            pRIM3DataSet.Usp.Rows.Add(myRow2);

            this.uspTableAdapter.Update(this.pRIM3DataSet.Usp);

            this.uspTableAdapter.Fill(this.pRIM3DataSet.Usp);
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }
    }
}
