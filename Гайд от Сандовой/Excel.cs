using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Exel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace Excel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); 
            openFileDialog1.Filter = "Excel files(*.xls)|*.xlsx";
        }

        Exel.Application application;//приложение
        Exel.Sheets sheets;//отдельный лист
        Exel.Worksheet worksheet, worksheet1;//книга
        Exel.Range cells;//ячейка
       
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDDataSet.Students1". При необходимости она может быть перемещена или удалена.
            this.students1TableAdapter.Fill(this.sTUDDataSet.Students1);


            // TODO: данная строка кода позволяет загрузить данные в таблицу "sTUDDataSet.Students". При необходимости она может быть перемещена или удалена.
            this.studentsTableAdapter.Fill(this.sTUDDataSet.Students);

        }

        private void button1_Click(object sender, EventArgs e)  //запрос
        {
            var id1 = Convert.ToInt32(listBox1.SelectedValue);
            usp1TableAdapter.Fill(sTUDDataSet.Usp1, id1);
            if (usp1BindingSource.Count == 0)
                MessageBox.Show("Оценок у данного студента нет");
            else
            {
                DialogResult dialogResult = MessageBox.Show("Открыть существующий документ?", "",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    openFileDialog1.ShowDialog();
                    application = new Exel.Application();
                   
                    application.Workbooks.Open(openFileDialog1.FileName,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing);
                    sheets = application.ActiveWorkbook.Worksheets;
                    //worksheet = (application.Worksheet)ObjWorkBook.Worksheets["Запрос"];

                    //обратиться к 1 странице(сделать текущей)
                    worksheet = (Exel.Worksheet)sheets.get_Item(1);
                    worksheet1 = (Exel.Worksheet)sheets.get_Item(2);
                    if (worksheet.Name != "Таблица" || worksheet1.Name != "Запрос")
                    { MessageBox.Show("Это не та книга!"); return; }
                    else
                    {
                        application.Visible = true;
                        worksheet = (Exel.Worksheet)sheets.get_Item(2);
                    }
                }
                else if (dialogResult == DialogResult.No)
                {
                    //создание нового приложения
                    application = new Exel.Application();
                    application.Visible = true;

                    //установить 3 страницы для приложения
                    application.SheetsInNewWorkbook = 4;
                    application.Workbooks.Add(Type.Missing);
                    sheets = application.ActiveWorkbook.Worksheets;

                    //обратиться к 1 странице(сделать текущей)
                    worksheet = (Exel.Worksheet)sheets.get_Item(1);

                    //присвоить имя Запрос
                    worksheet.Name = "Таблица";

                    //присвоить имя второй и третьей обратно перейти на 2
                    worksheet = (Exel.Worksheet)sheets.get_Item(2);
                    worksheet.Name = "Запрос";
                    worksheet = (Exel.Worksheet)sheets.get_Item(3);
                    worksheet.Name = "Диаграмма";
                    worksheet = (Exel.Worksheet)sheets.get_Item(4);
                    worksheet.Name = "Круговая";
                    worksheet = (Exel.Worksheet)sheets.get_Item(2);
                }
                //антивировать выбранную страницу
                worksheet.Activate();
                string dat = "Успеваемость студента " + listBox1.Text;

                //выбрать ячейки для объединения
                cells = worksheet.get_Range("A1", "D1");

                //Объединение
                cells.Merge(Type.Missing);

                //выравнивание по центру
                cells.HorizontalAlignment = Exel.Constants.xlLeft;
                cells.VerticalAlignment = Exel.Constants.xlCenter;

                //текст
                cells.Value2 = dat;

                //форматирование текста
                cells.Font.Size = 14;
                cells.Font.Color = Color.Red;
                cells.Font.Italic = 1;
                cells.Font.Bold = 1;
                

                //количество строк и столобцов
                int row = sTUDDataSet.Usp1.Rows.Count;
                int col = sTUDDataSet.Usp1.Columns.Count;

                //Занести заголовки таблиц
                for (int i = 0;i<col;i++)
                {
                    cells = (Exel.Range)worksheet.Cells[2, i + 1];
                    cells.Font.Size = 14;
                    cells.Font.Color = Color.Green;
                    cells.Font.Italic = 0;
                    cells.Value2 = sTUDDataSet.Usp1.Columns[i].ToString();
                }

                //заполнение таблицы
              
                for (int i = 0; i<row;i++)
                    for (int j = 0;j<col;j++)
                    {
                        cells = (Exel.Range)worksheet.Cells[i+3, j+1];
                        cells.Font.Size = 12;
                        cells.Font.Color = Color.DarkBlue;
                                                 
                        cells.Font.Bold = 0;
                        cells.Borders.Weight = 1;
                        if (j == 3)
                        {
                            string s = sTUDDataSet.Usp1.Rows[i][j].ToString();
                            s = s.Remove(10);
                            cells.Value2 = s;
                        }
                        else
                            cells.Value2 = sTUDDataSet.Usp1.Rows[i][j].ToString();
                    }
                worksheet.Columns.AutoFit();
            }
        }

        private void button2_Click(object sender, EventArgs e)  //диаграмма
        {
            DialogResult dialogResult = MessageBox.Show("Открыть существующий документ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                openFileDialog1.ShowDialog();
                application = new Exel.Application();

                application.Workbooks.Open(openFileDialog1.FileName,
Type.Missing, Type.Missing, Type.Missing, Type.Missing,
Type.Missing, Type.Missing, Type.Missing, Type.Missing,
Type.Missing, Type.Missing, Type.Missing, Type.Missing,
Type.Missing, Type.Missing);
                sheets = application.ActiveWorkbook.Worksheets;
                //worksheet = (application.Worksheet)ObjWorkBook.Worksheets["Запрос"];

                //обратиться к 1 странице(сделать текущей)
                worksheet = (Exel.Worksheet)sheets.get_Item(1);
                worksheet1 = (Exel.Worksheet)sheets.get_Item(2);
                if (worksheet.Name != "Таблица" || worksheet1.Name != "Запрос")
                { MessageBox.Show("Это не та книга!"); return; }
                else
                {
                    worksheet = (Exel.Worksheet)sheets.get_Item(3);
                }
            }
            else if (dialogResult == DialogResult.No)
            {        //создание нового приложения 
                application = new Exel.Application();


                application.Visible = true;

                //установить 3 страницы для приложения
                application.SheetsInNewWorkbook = 4;
                application.Workbooks.Add(Type.Missing);
                sheets = application.ActiveWorkbook.Worksheets;

                //обратиться к 1 странице(сделать текущей)
                worksheet = (Exel.Worksheet)sheets.get_Item(1);
                worksheet.Name = "Таблица";

                worksheet = (Exel.Worksheet)sheets.get_Item(2);
                worksheet.Name = "Запрос";

                worksheet = (Exel.Worksheet)sheets.get_Item(4);
                worksheet.Name = "Круговая";

                //присвоить имя третьей и сделать текущей 
                worksheet = (Exel.Worksheet)sheets.get_Item(3);
                worksheet.Name = "Диаграмма";
            }
            worksheet.Activate();


         //   application.Visible = true;



            //количество строк и столобцов
            int row = sTUDDataSet.Students1.Rows.Count;
            int col = sTUDDataSet.Students1.Columns.Count;

            //Занести заголовки таблиц
            for (int i = 0; i < col; i++)
            {
                cells = (Exel.Range)worksheet.Cells[1, i + 1];
                cells.Value2 = sTUDDataSet.Students1.Columns[i].ToString();
            }

            //заполнение таблицы
            for (int i = 0; i < row; i++)
                for (int j = 0; j < col; j++)
                {
                    cells = (Exel.Range)worksheet.Cells[i + 2, j + 1];
                    cells.Value2 = sTUDDataSet.Students1.Rows[i][j].ToString();
                }

            //выбор диапазона и выделение
            string cur = "c" + (row+1);
            cells = worksheet.get_Range("a1", cur.ToString());
            cells.Select();

            //добавление диаграммы
            Exel.Chart chart = (Exel.Chart)application.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);
            


            //выбор диаграммы и открытия листа с диаграммой
            chart.Activate();
            chart.Select(Type.Missing);

            //определить, находятся ли данные для каждого ряда в строках или столбцах
            application.ActiveChart.PlotBy = Exel.XlRowCol.xlColumns;
            //application.ActiveChart.PlotBy = Exel.XlRowCol.xlRows;

            //заголовок и оформление диаграммы
            //надпись
            application.ActiveChart.HasTitle = true;
            application.ActiveChart.ChartTitle.Text = "Оценки студентов";

            //Изменение параметров шрифта


            //Обрамление для надписи с тенями
            application.ActiveChart.ChartTitle.Shadow = true;
            application.ActiveChart.ChartTitle.Border.LineStyle = Exel.Constants.xlSolid;

            //Отображение легенды
            application.ActiveChart.HasLegend = true;

            //расположение легенды
            application.ActiveChart.Legend.Position = Exel.XlLegendPosition.xlLegendPositionBottom;

            //Переместить диаграмму на лист диаграммы
           //  application.ActiveChart.ChartType = Exel.XlChartType.xlBarClustered;
           application.ActiveChart.ChartType = Exel.XlChartType.xl3DColumnClustered;
            application.ActiveChart.Location(Exel.XlChartLocation.xlLocationAsObject, "Диаграмма");

            //получить ссылку на лист 3
            worksheet = (Exel.Worksheet)sheets.get_Item(3);

            //добавление диаграммы
            Exel.Chart chart1 = (Exel.Chart)application.Charts.Add(Type.Missing, Type.Missing, Type.Missing, Type.Missing);



            //выбор диаграммы и открытия листа с диаграммой
            chart1.Activate();
            chart1.Select(Type.Missing);

            //определить, находятся ли данные для каждого ряда в строках или столбцах
            application.ActiveChart.PlotBy = Exel.XlRowCol.xlColumns;
            //application.ActiveChart.PlotBy = Exel.XlRowCol.xlRows;

            //заголовок и оформление диаграммы
            //надпись
            application.ActiveChart.HasTitle = true;
            application.ActiveChart.ChartTitle.Text = "Оценки студентов";

            //Изменение параметров шрифта


            //Обрамление для надписи с тенями
            application.ActiveChart.ChartTitle.Shadow = true;
            application.ActiveChart.ChartTitle.Border.LineStyle = Exel.Constants.xlSolid;

            //Отображение легенды
            application.ActiveChart.HasLegend = true;

            //расположение легенды
            application.ActiveChart.Legend.Position = Exel.XlLegendPosition.xlLegendPositionBottom;

            //Переместить диаграмму на лист диаграммы
            
            application.ActiveChart.ChartType = Exel.XlChartType.xl3DPie;
            application.ActiveChart.Location(Exel.XlChartLocation.xlLocationAsObject, "Круговая");
            application.ActiveChart.ApplyDataLabels(Exel.XlDataLabelsType.xlDataLabelsShowLabel, false, true, false, false, false, false, true, false, true);

            //получить ссылку на лист 1
            worksheet = (Exel.Worksheet)sheets.get_Item(2);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e) //таблица
        {
            string[] titul = { "номер", "фамилия", "имя", "отчетство", "стипендия", "дата рождения", "город" };
            DialogResult dialogResult = MessageBox.Show("Открыть существующий документ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    openFileDialog1.ShowDialog();
                    application = new Exel.Application();

                    application.Workbooks.Open(openFileDialog1.FileName,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing, Type.Missing, Type.Missing,
  Type.Missing, Type.Missing);
                    sheets = application.ActiveWorkbook.Worksheets;
                    //worksheet = (application.Worksheet)ObjWorkBook.Worksheets["Запрос"];

                    //обратиться к 1 странице(сделать текущей)
                    worksheet = (Exel.Worksheet)sheets.get_Item(1);
                    worksheet1 = (Exel.Worksheet)sheets.get_Item(2);
                    if (worksheet.Name != "Таблица" || worksheet1.Name != "Запрос")
                    { MessageBox.Show("Это не та книга!"); return; }
                    else application.Visible = true;
                }
                else if (dialogResult == DialogResult.No)
                    application = new Exel.Application();
            application.SheetsInNewWorkbook = 4;
            application.Workbooks.Add(Type.Missing);
            sheets = application.ActiveWorkbook.Worksheets;
            worksheet = (Exel.Worksheet)sheets.get_Item(1);
            worksheet.Name = "Таблица";
            worksheet = (Exel.Worksheet)sheets.get_Item(2);
            worksheet.Name = "Запрос";
            worksheet = (Exel.Worksheet)sheets.get_Item(3);
            worksheet.Name = "Диаграмма";
            worksheet = (Exel.Worksheet)sheets.get_Item(4);
            worksheet.Name = "Круговая";
            application.Visible = true;

            worksheet = (Exel.Worksheet)sheets.get_Item(1);
            worksheet.Activate();
            worksheet.Columns.AutoFit();
            string dat = "Список студентов ";
            cells = worksheet.get_Range("A1", "g1");
            cells.Merge(Type.Missing);

            cells.HorizontalAlignment = Exel.Constants.xlCenter;
            cells.VerticalAlignment = Exel.Constants.xlCenter;

            cells.Value2 = dat;
            cells.Font.Size = 12;
            cells.Font.Color = Color.Blue;
            cells.Font.Italic = 1;
            cells.Font.Bold = 1;

            /*worksheet.Cells[2,1].Value = "номер";
            worksheet.Cells[2, 2].Value = "фамилия";
            worksheet.Cells[2, 3].Value = "имя";
            worksheet.Cells[2, 4].Value = "отчество";
            worksheet.Cells[2, 5].Value = "стипендия";
            worksheet.Cells[2, 6].Value = "дата рождения";
            worksheet.Cells[2, 7].Value = "город";*/
             for (int i = 0; i < sTUDDataSet.Students.Columns.Count; i++)
              {
                 // MessageBox.Show("");
                  cells = (Exel.Range)worksheet.Cells[2, i + 1];
                  cells.Value2 = titul[i];
                  cells.Font.Bold = 1;
                  cells.Borders.Weight = 2;
              }
              for (int i = 0; i < sTUDDataSet.Students.Columns.Count; i++)
              {
                  for (int j = 0; j < sTUDDataSet.Students.Rows.Count; j++)
                  {
                      cells = (Exel.Range)worksheet.Cells[j + 3, i + 1];
                      if (i == 5)
                          cells.NumberFormat = "DD.MM.YYYY";
                      cells.Value2 = sTUDDataSet.Students.Rows[j][i];
                      cells.Borders.Weight = 2;



                  }
              }
            worksheet.Columns.AutoFit(); //ширина столбца по содержимому
        }

    }
}

