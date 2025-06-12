namespace Система_учёта_и_приобретения_инструмента
{
    partial class InvoiceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvoiceForm));
            this.DeliveryListFormDate = new System.Windows.Forms.TextBox();
            this.DeliveryListFormNumber = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tOOLACCOUNTINGDataSet = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet();
            this.deliveryListsContentInjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deliveryListsContentInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.DeliveryListsContentInjTableAdapter();
            this.DeliveryListFormDeliveryListContentTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.DeliveryListFormButtonClose = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.invoicesContentInjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoicesContentInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.InvoicesContentInjTableAdapter();
            this.invoiceContentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryContentIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomenclatureNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryListsContentInjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryListFormDeliveryListContentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesContentInjBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // DeliveryListFormDate
            // 
            this.DeliveryListFormDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeliveryListFormDate.Location = new System.Drawing.Point(125, 44);
            this.DeliveryListFormDate.Margin = new System.Windows.Forms.Padding(2);
            this.DeliveryListFormDate.Name = "DeliveryListFormDate";
            this.DeliveryListFormDate.ReadOnly = true;
            this.DeliveryListFormDate.Size = new System.Drawing.Size(447, 29);
            this.DeliveryListFormDate.TabIndex = 65;
            // 
            // DeliveryListFormNumber
            // 
            this.DeliveryListFormNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeliveryListFormNumber.Location = new System.Drawing.Point(125, 11);
            this.DeliveryListFormNumber.Margin = new System.Windows.Forms.Padding(2);
            this.DeliveryListFormNumber.Name = "DeliveryListFormNumber";
            this.DeliveryListFormNumber.ReadOnly = true;
            this.DeliveryListFormNumber.Size = new System.Drawing.Size(447, 29);
            this.DeliveryListFormNumber.TabIndex = 63;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label38.Location = new System.Drawing.Point(14, 53);
            this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 20);
            this.label38.TabIndex = 64;
            this.label38.Text = "Дата";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.Location = new System.Drawing.Point(14, 20);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 20);
            this.label32.TabIndex = 62;
            this.label32.Text = "Номер";
            // 
            // tOOLACCOUNTINGDataSet
            // 
            this.tOOLACCOUNTINGDataSet.DataSetName = "TOOLACCOUNTINGDataSet";
            this.tOOLACCOUNTINGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // deliveryListsContentInjBindingSource
            // 
            this.deliveryListsContentInjBindingSource.DataMember = "DeliveryListsContentInj";
            this.deliveryListsContentInjBindingSource.DataSource = this.tOOLACCOUNTINGDataSet;
            // 
            // deliveryListsContentInjTableAdapter
            // 
            this.deliveryListsContentInjTableAdapter.ClearBeforeFill = true;
            // 
            // DeliveryListFormDeliveryListContentTable
            // 
            this.DeliveryListFormDeliveryListContentTable.AllowUserToAddRows = false;
            this.DeliveryListFormDeliveryListContentTable.AllowUserToDeleteRows = false;
            this.DeliveryListFormDeliveryListContentTable.AllowUserToResizeRows = false;
            this.DeliveryListFormDeliveryListContentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DeliveryListFormDeliveryListContentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DeliveryListFormDeliveryListContentTable.Location = new System.Drawing.Point(18, 128);
            this.DeliveryListFormDeliveryListContentTable.Margin = new System.Windows.Forms.Padding(2);
            this.DeliveryListFormDeliveryListContentTable.MultiSelect = false;
            this.DeliveryListFormDeliveryListContentTable.Name = "DeliveryListFormDeliveryListContentTable";
            this.DeliveryListFormDeliveryListContentTable.ReadOnly = true;
            this.DeliveryListFormDeliveryListContentTable.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeliveryListFormDeliveryListContentTable.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DeliveryListFormDeliveryListContentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DeliveryListFormDeliveryListContentTable.Size = new System.Drawing.Size(1027, 185);
            this.DeliveryListFormDeliveryListContentTable.TabIndex = 66;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 337);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 24);
            this.label1.TabIndex = 68;
            this.label1.Text = "Поступившее количество:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(279, 335);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(365, 29);
            this.numericUpDown1.TabIndex = 69;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(650, 330);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(165, 39);
            this.button1.TabIndex = 70;
            this.button1.Text = "Зафиксировать";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(18, 102);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(352, 24);
            this.label4.TabIndex = 87;
            this.label4.Text = "Инструменты, ожидаемые в поставке";
            // 
            // DeliveryListFormButtonClose
            // 
            this.DeliveryListFormButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DeliveryListFormButtonClose.Location = new System.Drawing.Point(961, 611);
            this.DeliveryListFormButtonClose.Margin = new System.Windows.Forms.Padding(2);
            this.DeliveryListFormButtonClose.MaximumSize = new System.Drawing.Size(84, 26);
            this.DeliveryListFormButtonClose.MinimumSize = new System.Drawing.Size(84, 26);
            this.DeliveryListFormButtonClose.Name = "DeliveryListFormButtonClose";
            this.DeliveryListFormButtonClose.Size = new System.Drawing.Size(84, 26);
            this.DeliveryListFormButtonClose.TabIndex = 88;
            this.DeliveryListFormButtonClose.Text = "Закрыть";
            this.DeliveryListFormButtonClose.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 407);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1027, 200);
            this.dataGridView1.TabIndex = 89;
            // 
            // invoicesContentInjBindingSource
            // 
            this.invoicesContentInjBindingSource.DataMember = "InvoicesContentInj";
            this.invoicesContentInjBindingSource.DataSource = this.tOOLACCOUNTINGDataSet;
            // 
            // invoicesContentInjTableAdapter
            // 
            this.invoicesContentInjTableAdapter.ClearBeforeFill = true;
            // 
            // invoiceContentIDDataGridViewTextBoxColumn
            // 
            this.invoiceContentIDDataGridViewTextBoxColumn.DataPropertyName = "InvoiceContentID";
            this.invoiceContentIDDataGridViewTextBoxColumn.HeaderText = "InvoiceContentID";
            this.invoiceContentIDDataGridViewTextBoxColumn.Name = "invoiceContentIDDataGridViewTextBoxColumn";
            this.invoiceContentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.invoiceContentIDDataGridViewTextBoxColumn.Width = 171;
            // 
            // invoiceIDDataGridViewTextBoxColumn
            // 
            this.invoiceIDDataGridViewTextBoxColumn.DataPropertyName = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn.HeaderText = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn.Name = "invoiceIDDataGridViewTextBoxColumn";
            this.invoiceIDDataGridViewTextBoxColumn.Width = 170;
            // 
            // deliveryContentIDDataGridViewTextBoxColumn1
            // 
            this.deliveryContentIDDataGridViewTextBoxColumn1.DataPropertyName = "DeliveryContentID";
            this.deliveryContentIDDataGridViewTextBoxColumn1.HeaderText = "DeliveryContentID";
            this.deliveryContentIDDataGridViewTextBoxColumn1.Name = "deliveryContentIDDataGridViewTextBoxColumn1";
            this.deliveryContentIDDataGridViewTextBoxColumn1.Width = 171;
            // 
            // nomenclatureNumberDataGridViewTextBoxColumn1
            // 
            this.nomenclatureNumberDataGridViewTextBoxColumn1.DataPropertyName = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn1.HeaderText = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn1.Name = "nomenclatureNumberDataGridViewTextBoxColumn1";
            this.nomenclatureNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nomenclatureNumberDataGridViewTextBoxColumn1.Width = 171;
            // 
            // fullNameDataGridViewTextBoxColumn1
            // 
            this.fullNameDataGridViewTextBoxColumn1.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn1.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn1.Name = "fullNameDataGridViewTextBoxColumn1";
            this.fullNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.fullNameDataGridViewTextBoxColumn1.Width = 170;
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            this.quantityDataGridViewTextBoxColumn1.Width = 171;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(18, 381);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 24);
            this.label2.TabIndex = 90;
            this.label2.Text = "Распределение инструментов";
            // 
            // InvoiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 648);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DeliveryListFormButtonClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeliveryListFormDeliveryListContentTable);
            this.Controls.Add(this.DeliveryListFormDate);
            this.Controls.Add(this.DeliveryListFormNumber);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label32);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "InvoiceForm";
            this.Text = "Форма товарной накладной – Информационная система учета и приобретения инструмент" +
    "а";
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryListsContentInjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DeliveryListFormDeliveryListContentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesContentInjBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DeliveryListFormDate;
        private System.Windows.Forms.TextBox DeliveryListFormNumber;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label32;
        private TOOLACCOUNTINGDataSet tOOLACCOUNTINGDataSet;
        private System.Windows.Forms.BindingSource deliveryListsContentInjBindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.DeliveryListsContentInjTableAdapter deliveryListsContentInjTableAdapter;
        private System.Windows.Forms.DataGridView DeliveryListFormDeliveryListContentTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button DeliveryListFormButtonClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource invoicesContentInjBindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.InvoicesContentInjTableAdapter invoicesContentInjTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceContentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryContentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label2;
    }
}