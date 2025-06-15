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
            this.InvoiceFormDate = new System.Windows.Forms.TextBox();
            this.InvoiceFormNumber = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.tOOLACCOUNTINGDataSet = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet();
            this.deliveryListsContentInjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.deliveryListsContentInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.DeliveryListsContentInjTableAdapter();
            this.InvoiceFormDeliveryTable = new System.Windows.Forms.DataGridView();
            this.deliveryContentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryListIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivingRequestIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workshopDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomenclatureNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryContentDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.InvoiceFormQuantity = new System.Windows.Forms.NumericUpDown();
            this.InvoiceFormButtonsFix = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.InvoiceFormClose = new System.Windows.Forms.Button();
            this.InvoiceFormInvoicesTable = new System.Windows.Forms.DataGridView();
            this.invoiceContentIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deliveryContentIDDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivingRequestIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomenclatureNumberDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceFormDeliveryTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceFormQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceFormInvoicesTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesContentInjBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // InvoiceFormDate
            // 
            this.InvoiceFormDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InvoiceFormDate.Location = new System.Drawing.Point(125, 44);
            this.InvoiceFormDate.Margin = new System.Windows.Forms.Padding(2);
            this.InvoiceFormDate.Name = "InvoiceFormDate";
            this.InvoiceFormDate.ReadOnly = true;
            this.InvoiceFormDate.Size = new System.Drawing.Size(447, 29);
            this.InvoiceFormDate.TabIndex = 65;
            // 
            // InvoiceFormNumber
            // 
            this.InvoiceFormNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InvoiceFormNumber.Location = new System.Drawing.Point(125, 11);
            this.InvoiceFormNumber.Margin = new System.Windows.Forms.Padding(2);
            this.InvoiceFormNumber.Name = "InvoiceFormNumber";
            this.InvoiceFormNumber.ReadOnly = true;
            this.InvoiceFormNumber.Size = new System.Drawing.Size(447, 29);
            this.InvoiceFormNumber.TabIndex = 63;
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
            // InvoiceFormDeliveryTable
            // 
            this.InvoiceFormDeliveryTable.AllowUserToAddRows = false;
            this.InvoiceFormDeliveryTable.AllowUserToDeleteRows = false;
            this.InvoiceFormDeliveryTable.AllowUserToResizeRows = false;
            this.InvoiceFormDeliveryTable.AutoGenerateColumns = false;
            this.InvoiceFormDeliveryTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InvoiceFormDeliveryTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.InvoiceFormDeliveryTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvoiceFormDeliveryTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deliveryContentIDDataGridViewTextBoxColumn,
            this.deliveryListIDDataGridViewTextBoxColumn,
            this.receivingRequestIDDataGridViewTextBoxColumn,
            this.workshopDataGridViewTextBoxColumn,
            this.nomenclatureNumberDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.deliveryContentDateDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.InvoiceFormDeliveryTable.DataSource = this.deliveryListsContentInjBindingSource;
            this.InvoiceFormDeliveryTable.Location = new System.Drawing.Point(18, 128);
            this.InvoiceFormDeliveryTable.Margin = new System.Windows.Forms.Padding(2);
            this.InvoiceFormDeliveryTable.MultiSelect = false;
            this.InvoiceFormDeliveryTable.Name = "InvoiceFormDeliveryTable";
            this.InvoiceFormDeliveryTable.ReadOnly = true;
            this.InvoiceFormDeliveryTable.RowHeadersVisible = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InvoiceFormDeliveryTable.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.InvoiceFormDeliveryTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InvoiceFormDeliveryTable.Size = new System.Drawing.Size(1027, 185);
            this.InvoiceFormDeliveryTable.TabIndex = 66;
            this.InvoiceFormDeliveryTable.CurrentCellChanged += new System.EventHandler(this.InvoiceFormDeliveryTable_CurrentCellChanged);
            // 
            // deliveryContentIDDataGridViewTextBoxColumn
            // 
            this.deliveryContentIDDataGridViewTextBoxColumn.DataPropertyName = "DeliveryContentID";
            this.deliveryContentIDDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.deliveryContentIDDataGridViewTextBoxColumn.Name = "deliveryContentIDDataGridViewTextBoxColumn";
            this.deliveryContentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryContentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // deliveryListIDDataGridViewTextBoxColumn
            // 
            this.deliveryListIDDataGridViewTextBoxColumn.DataPropertyName = "DeliveryListID";
            this.deliveryListIDDataGridViewTextBoxColumn.HeaderText = "Номер ведомости поставки";
            this.deliveryListIDDataGridViewTextBoxColumn.Name = "deliveryListIDDataGridViewTextBoxColumn";
            this.deliveryListIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryListIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // receivingRequestIDDataGridViewTextBoxColumn
            // 
            this.receivingRequestIDDataGridViewTextBoxColumn.DataPropertyName = "ReceivingRequestID";
            this.receivingRequestIDDataGridViewTextBoxColumn.HeaderText = "Номер заявки на получение";
            this.receivingRequestIDDataGridViewTextBoxColumn.Name = "receivingRequestIDDataGridViewTextBoxColumn";
            this.receivingRequestIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // workshopDataGridViewTextBoxColumn
            // 
            this.workshopDataGridViewTextBoxColumn.DataPropertyName = "Workshop";
            this.workshopDataGridViewTextBoxColumn.HeaderText = "Цех";
            this.workshopDataGridViewTextBoxColumn.Name = "workshopDataGridViewTextBoxColumn";
            this.workshopDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nomenclatureNumberDataGridViewTextBoxColumn
            // 
            this.nomenclatureNumberDataGridViewTextBoxColumn.DataPropertyName = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn.HeaderText = "Номенклатурный номер";
            this.nomenclatureNumberDataGridViewTextBoxColumn.Name = "nomenclatureNumberDataGridViewTextBoxColumn";
            this.nomenclatureNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Полное наименование";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deliveryContentDateDataGridViewTextBoxColumn
            // 
            this.deliveryContentDateDataGridViewTextBoxColumn.DataPropertyName = "DeliveryContentDate";
            this.deliveryContentDateDataGridViewTextBoxColumn.HeaderText = "Дата поставки";
            this.deliveryContentDateDataGridViewTextBoxColumn.Name = "deliveryContentDateDataGridViewTextBoxColumn";
            this.deliveryContentDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.deliveryContentDateDataGridViewTextBoxColumn.Visible = false;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
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
            // InvoiceFormQuantity
            // 
            this.InvoiceFormQuantity.Location = new System.Drawing.Point(279, 335);
            this.InvoiceFormQuantity.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.InvoiceFormQuantity.Name = "InvoiceFormQuantity";
            this.InvoiceFormQuantity.Size = new System.Drawing.Size(365, 29);
            this.InvoiceFormQuantity.TabIndex = 69;
            this.InvoiceFormQuantity.ValueChanged += new System.EventHandler(this.InvoiceFormQuantity_ValueChanged);
            // 
            // InvoiceFormButtonsFix
            // 
            this.InvoiceFormButtonsFix.Location = new System.Drawing.Point(650, 330);
            this.InvoiceFormButtonsFix.Name = "InvoiceFormButtonsFix";
            this.InvoiceFormButtonsFix.Size = new System.Drawing.Size(165, 39);
            this.InvoiceFormButtonsFix.TabIndex = 70;
            this.InvoiceFormButtonsFix.Text = "Зафиксировать";
            this.InvoiceFormButtonsFix.UseVisualStyleBackColor = true;
            this.InvoiceFormButtonsFix.Click += new System.EventHandler(this.InvoiceFormButtonsFix_Click);
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
            // InvoiceFormClose
            // 
            this.InvoiceFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InvoiceFormClose.Location = new System.Drawing.Point(961, 611);
            this.InvoiceFormClose.Margin = new System.Windows.Forms.Padding(2);
            this.InvoiceFormClose.MaximumSize = new System.Drawing.Size(84, 26);
            this.InvoiceFormClose.MinimumSize = new System.Drawing.Size(84, 26);
            this.InvoiceFormClose.Name = "InvoiceFormClose";
            this.InvoiceFormClose.Size = new System.Drawing.Size(84, 26);
            this.InvoiceFormClose.TabIndex = 88;
            this.InvoiceFormClose.Text = "Закрыть";
            this.InvoiceFormClose.UseVisualStyleBackColor = true;
            this.InvoiceFormClose.Click += new System.EventHandler(this.InvoiceFormClose_Click);
            // 
            // InvoiceFormInvoicesTable
            // 
            this.InvoiceFormInvoicesTable.AllowUserToAddRows = false;
            this.InvoiceFormInvoicesTable.AllowUserToDeleteRows = false;
            this.InvoiceFormInvoicesTable.AllowUserToResizeRows = false;
            this.InvoiceFormInvoicesTable.AutoGenerateColumns = false;
            this.InvoiceFormInvoicesTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.InvoiceFormInvoicesTable.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.InvoiceFormInvoicesTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.InvoiceFormInvoicesTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceContentIDDataGridViewTextBoxColumn1,
            this.invoiceIDDataGridViewTextBoxColumn1,
            this.deliveryContentIDDataGridViewTextBoxColumn2,
            this.receivingRequestIDDataGridViewTextBoxColumn1,
            this.nomenclatureNumberDataGridViewTextBoxColumn2,
            this.fullNameDataGridViewTextBoxColumn2,
            this.quantityDataGridViewTextBoxColumn2});
            this.InvoiceFormInvoicesTable.DataSource = this.invoicesContentInjBindingSource;
            this.InvoiceFormInvoicesTable.Location = new System.Drawing.Point(18, 407);
            this.InvoiceFormInvoicesTable.Margin = new System.Windows.Forms.Padding(2);
            this.InvoiceFormInvoicesTable.MultiSelect = false;
            this.InvoiceFormInvoicesTable.Name = "InvoiceFormInvoicesTable";
            this.InvoiceFormInvoicesTable.ReadOnly = true;
            this.InvoiceFormInvoicesTable.RowHeadersVisible = false;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InvoiceFormInvoicesTable.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.InvoiceFormInvoicesTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.InvoiceFormInvoicesTable.Size = new System.Drawing.Size(1027, 200);
            this.InvoiceFormInvoicesTable.TabIndex = 89;
            // 
            // invoiceContentIDDataGridViewTextBoxColumn1
            // 
            this.invoiceContentIDDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceContentID";
            this.invoiceContentIDDataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.invoiceContentIDDataGridViewTextBoxColumn1.Name = "invoiceContentIDDataGridViewTextBoxColumn1";
            this.invoiceContentIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.invoiceContentIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // invoiceIDDataGridViewTextBoxColumn1
            // 
            this.invoiceIDDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn1.HeaderText = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn1.Name = "invoiceIDDataGridViewTextBoxColumn1";
            this.invoiceIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.invoiceIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // deliveryContentIDDataGridViewTextBoxColumn2
            // 
            this.deliveryContentIDDataGridViewTextBoxColumn2.DataPropertyName = "DeliveryContentID";
            this.deliveryContentIDDataGridViewTextBoxColumn2.HeaderText = "DeliveryContentID";
            this.deliveryContentIDDataGridViewTextBoxColumn2.Name = "deliveryContentIDDataGridViewTextBoxColumn2";
            this.deliveryContentIDDataGridViewTextBoxColumn2.ReadOnly = true;
            this.deliveryContentIDDataGridViewTextBoxColumn2.Visible = false;
            // 
            // receivingRequestIDDataGridViewTextBoxColumn1
            // 
            this.receivingRequestIDDataGridViewTextBoxColumn1.DataPropertyName = "ReceivingRequestID";
            this.receivingRequestIDDataGridViewTextBoxColumn1.HeaderText = "Номер заявки на получение";
            this.receivingRequestIDDataGridViewTextBoxColumn1.Name = "receivingRequestIDDataGridViewTextBoxColumn1";
            this.receivingRequestIDDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // nomenclatureNumberDataGridViewTextBoxColumn2
            // 
            this.nomenclatureNumberDataGridViewTextBoxColumn2.DataPropertyName = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn2.HeaderText = "Номенклатурный номер";
            this.nomenclatureNumberDataGridViewTextBoxColumn2.Name = "nomenclatureNumberDataGridViewTextBoxColumn2";
            this.nomenclatureNumberDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn2
            // 
            this.fullNameDataGridViewTextBoxColumn2.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn2.HeaderText = "Полное наименование";
            this.fullNameDataGridViewTextBoxColumn2.Name = "fullNameDataGridViewTextBoxColumn2";
            this.fullNameDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn2
            // 
            this.quantityDataGridViewTextBoxColumn2.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn2.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn2.Name = "quantityDataGridViewTextBoxColumn2";
            this.quantityDataGridViewTextBoxColumn2.ReadOnly = true;
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
            this.Controls.Add(this.InvoiceFormInvoicesTable);
            this.Controls.Add(this.InvoiceFormClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.InvoiceFormButtonsFix);
            this.Controls.Add(this.InvoiceFormQuantity);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InvoiceFormDeliveryTable);
            this.Controls.Add(this.InvoiceFormDate);
            this.Controls.Add(this.InvoiceFormNumber);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label32);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "InvoiceForm";
            this.Text = "Форма товарной накладной – Информационная система учета и приобретения инструмент" +
    "а";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InvoiceForm_FormClosing);
            this.Load += new System.EventHandler(this.InvoiceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deliveryListsContentInjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceFormDeliveryTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceFormQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InvoiceFormInvoicesTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.invoicesContentInjBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox InvoiceFormDate;
        private System.Windows.Forms.TextBox InvoiceFormNumber;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label32;
        private TOOLACCOUNTINGDataSet tOOLACCOUNTINGDataSet;
        private System.Windows.Forms.BindingSource deliveryListsContentInjBindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.DeliveryListsContentInjTableAdapter deliveryListsContentInjTableAdapter;
        private System.Windows.Forms.DataGridView InvoiceFormDeliveryTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown InvoiceFormQuantity;
        private System.Windows.Forms.Button InvoiceFormButtonsFix;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button InvoiceFormClose;
        private System.Windows.Forms.DataGridView InvoiceFormInvoicesTable;
        private System.Windows.Forms.BindingSource invoicesContentInjBindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.InvoicesContentInjTableAdapter invoicesContentInjTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceContentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryContentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryContentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryListIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingRequestIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn workshopDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryContentDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceContentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn deliveryContentIDDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingRequestIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn2;
    }
}