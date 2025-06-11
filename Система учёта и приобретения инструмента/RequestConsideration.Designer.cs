namespace Система_учёта_и_приобретения_инструмента
{
    partial class RequestConsideration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RequestConsideration));
            this.RequestConsiderationContentTable = new System.Windows.Forms.DataGridView();
            this.receivingRequestIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomenclatureNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivingContentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivingRequestsContentInjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tOOLACCOUNTINGDataSet = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.RequestConsiderationFixationTable = new System.Windows.Forms.DataGridView();
            this.receivingContentIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analogNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivingRequestsContentInjDataTable2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receivingRequestsContentInjReplacementFixationInjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.RequestConsiderationButtonClose = new System.Windows.Forms.Button();
            this.RequestConsiderationButtonSaveClose = new System.Windows.Forms.Button();
            this.RequestConsiderationButtonSave = new System.Windows.Forms.Button();
            this.RequestConsiderationButtonDeсide = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.RequestConsiderationBuy = new System.Windows.Forms.RadioButton();
            this.RequestConsiderationTransfer = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.RequestConsiderationQuantity = new System.Windows.Forms.TextBox();
            this.receivingRequestsContentInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentInjTableAdapter();
            this.replacementFixationInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.ReplacementFixationInjTableAdapter();
            this.purchaseRequestsContentTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.PurchaseRequestsContentTableAdapter();
            this.purchaseRequestsTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.PurchaseRequestsTableAdapter();
            this.purchaseRequestsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receivingRequestsContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receivingRequestsContentTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentTableAdapter();
            this.workshopsTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.WorkshopsTableAdapter();
            this.dataTable2TableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.DataTable2TableAdapter();
            this.balancesInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.BalancesInjTableAdapter();
            this.RequestConsiderationButtonReplace = new System.Windows.Forms.Button();
            this.replacementFixationTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.ReplacementFixationTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.RequestConsiderationContentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequestConsiderationFixationTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjDataTable2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjReplacementFixationInjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseRequestsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // RequestConsiderationContentTable
            // 
            this.RequestConsiderationContentTable.AllowUserToAddRows = false;
            this.RequestConsiderationContentTable.AllowUserToDeleteRows = false;
            this.RequestConsiderationContentTable.AutoGenerateColumns = false;
            this.RequestConsiderationContentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RequestConsiderationContentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequestConsiderationContentTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receivingRequestIDDataGridViewTextBoxColumn,
            this.nomenclatureNumberDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.receivingContentIDDataGridViewTextBoxColumn});
            this.RequestConsiderationContentTable.DataSource = this.receivingRequestsContentInjBindingSource;
            this.RequestConsiderationContentTable.Location = new System.Drawing.Point(12, 36);
            this.RequestConsiderationContentTable.MultiSelect = false;
            this.RequestConsiderationContentTable.Name = "RequestConsiderationContentTable";
            this.RequestConsiderationContentTable.ReadOnly = true;
            this.RequestConsiderationContentTable.RowHeadersVisible = false;
            this.RequestConsiderationContentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RequestConsiderationContentTable.Size = new System.Drawing.Size(694, 186);
            this.RequestConsiderationContentTable.TabIndex = 0;
            this.RequestConsiderationContentTable.CurrentCellChanged += new System.EventHandler(this.RequestConsiderationContentTable_CurrentCellChanged);
            // 
            // receivingRequestIDDataGridViewTextBoxColumn
            // 
            this.receivingRequestIDDataGridViewTextBoxColumn.DataPropertyName = "ReceivingRequestID";
            this.receivingRequestIDDataGridViewTextBoxColumn.HeaderText = "ReceivingRequestID";
            this.receivingRequestIDDataGridViewTextBoxColumn.Name = "receivingRequestIDDataGridViewTextBoxColumn";
            this.receivingRequestIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.receivingRequestIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nomenclatureNumberDataGridViewTextBoxColumn
            // 
            this.nomenclatureNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.nomenclatureNumberDataGridViewTextBoxColumn.DataPropertyName = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn.HeaderText = "Номенклатурный номер";
            this.nomenclatureNumberDataGridViewTextBoxColumn.Name = "nomenclatureNumberDataGridViewTextBoxColumn";
            this.nomenclatureNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomenclatureNumberDataGridViewTextBoxColumn.Width = 220;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Полное наименование";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            this.quantityDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn.Width = 125;
            // 
            // receivingContentIDDataGridViewTextBoxColumn
            // 
            this.receivingContentIDDataGridViewTextBoxColumn.DataPropertyName = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn.HeaderText = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn.Name = "receivingContentIDDataGridViewTextBoxColumn";
            this.receivingContentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.receivingContentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // receivingRequestsContentInjBindingSource
            // 
            this.receivingRequestsContentInjBindingSource.DataMember = "ReceivingRequestsContentInj";
            this.receivingRequestsContentInjBindingSource.DataSource = this.tOOLACCOUNTINGDataSet;
            // 
            // tOOLACCOUNTINGDataSet
            // 
            this.tOOLACCOUNTINGDataSet.DataSetName = "TOOLACCOUNTINGDataSet";
            this.tOOLACCOUNTINGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(504, 24);
            this.label3.TabIndex = 36;
            this.label3.Text = "Инструменты входящие в данную заявку на получение";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 24);
            this.label1.TabIndex = 38;
            this.label1.Text = "Доступные замены на аналоги";
            // 
            // RequestConsiderationFixationTable
            // 
            this.RequestConsiderationFixationTable.AllowUserToAddRows = false;
            this.RequestConsiderationFixationTable.AllowUserToDeleteRows = false;
            this.RequestConsiderationFixationTable.AutoGenerateColumns = false;
            this.RequestConsiderationFixationTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.RequestConsiderationFixationTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RequestConsiderationFixationTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receivingContentIDDataGridViewTextBoxColumn1,
            this.analogNumberDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn1});
            this.RequestConsiderationFixationTable.DataSource = this.receivingRequestsContentInjDataTable2BindingSource;
            this.RequestConsiderationFixationTable.Location = new System.Drawing.Point(12, 310);
            this.RequestConsiderationFixationTable.MultiSelect = false;
            this.RequestConsiderationFixationTable.Name = "RequestConsiderationFixationTable";
            this.RequestConsiderationFixationTable.ReadOnly = true;
            this.RequestConsiderationFixationTable.RowHeadersVisible = false;
            this.RequestConsiderationFixationTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RequestConsiderationFixationTable.Size = new System.Drawing.Size(694, 125);
            this.RequestConsiderationFixationTable.TabIndex = 37;
            this.RequestConsiderationFixationTable.CurrentCellChanged += new System.EventHandler(this.RequestConsiderationFixationTable_CurrentCellChanged);
            // 
            // receivingContentIDDataGridViewTextBoxColumn1
            // 
            this.receivingContentIDDataGridViewTextBoxColumn1.DataPropertyName = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn1.HeaderText = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn1.Name = "receivingContentIDDataGridViewTextBoxColumn1";
            this.receivingContentIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.receivingContentIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // analogNumberDataGridViewTextBoxColumn
            // 
            this.analogNumberDataGridViewTextBoxColumn.DataPropertyName = "AnalogNumber";
            this.analogNumberDataGridViewTextBoxColumn.HeaderText = "Номенклатурный номера аналога";
            this.analogNumberDataGridViewTextBoxColumn.Name = "analogNumberDataGridViewTextBoxColumn";
            this.analogNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // fullNameDataGridViewTextBoxColumn1
            // 
            this.fullNameDataGridViewTextBoxColumn1.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn1.HeaderText = "Полное наименование";
            this.fullNameDataGridViewTextBoxColumn1.Name = "fullNameDataGridViewTextBoxColumn1";
            this.fullNameDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // receivingRequestsContentInjDataTable2BindingSource
            // 
            this.receivingRequestsContentInjDataTable2BindingSource.DataMember = "ReceivingRequestsContentInj_DataTable2";
            this.receivingRequestsContentInjDataTable2BindingSource.DataSource = this.receivingRequestsContentInjBindingSource;
            // 
            // receivingRequestsContentInjReplacementFixationInjBindingSource
            // 
            this.receivingRequestsContentInjReplacementFixationInjBindingSource.DataMember = "ReceivingRequestsContentInj_ReplacementFixationInj";
            this.receivingRequestsContentInjReplacementFixationInjBindingSource.DataSource = this.receivingRequestsContentInjBindingSource;
            // 
            // RequestConsiderationButtonClose
            // 
            this.RequestConsiderationButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestConsiderationButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RequestConsiderationButtonClose.Location = new System.Drawing.Point(793, 447);
            this.RequestConsiderationButtonClose.MaximumSize = new System.Drawing.Size(103, 31);
            this.RequestConsiderationButtonClose.MinimumSize = new System.Drawing.Size(103, 31);
            this.RequestConsiderationButtonClose.Name = "RequestConsiderationButtonClose";
            this.RequestConsiderationButtonClose.Size = new System.Drawing.Size(103, 31);
            this.RequestConsiderationButtonClose.TabIndex = 44;
            this.RequestConsiderationButtonClose.Text = "Закрыть";
            this.RequestConsiderationButtonClose.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonClose.Click += new System.EventHandler(this.RequestConsiderationButtonClose_Click);
            // 
            // RequestConsiderationButtonSaveClose
            // 
            this.RequestConsiderationButtonSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestConsiderationButtonSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RequestConsiderationButtonSaveClose.Location = new System.Drawing.Point(559, 447);
            this.RequestConsiderationButtonSaveClose.Name = "RequestConsiderationButtonSaveClose";
            this.RequestConsiderationButtonSaveClose.Size = new System.Drawing.Size(228, 31);
            this.RequestConsiderationButtonSaveClose.TabIndex = 43;
            this.RequestConsiderationButtonSaveClose.Text = "Сохранить и закрыть";
            this.RequestConsiderationButtonSaveClose.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonSaveClose.Visible = false;
            this.RequestConsiderationButtonSaveClose.Click += new System.EventHandler(this.RequestConsiderationButtonSaveClose_Click);
            // 
            // RequestConsiderationButtonSave
            // 
            this.RequestConsiderationButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestConsiderationButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RequestConsiderationButtonSave.Location = new System.Drawing.Point(421, 447);
            this.RequestConsiderationButtonSave.Name = "RequestConsiderationButtonSave";
            this.RequestConsiderationButtonSave.Size = new System.Drawing.Size(132, 31);
            this.RequestConsiderationButtonSave.TabIndex = 42;
            this.RequestConsiderationButtonSave.Text = "Сохранить";
            this.RequestConsiderationButtonSave.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonSave.Visible = false;
            this.RequestConsiderationButtonSave.Click += new System.EventHandler(this.RequestConsiderationButtonSave_Click);
            // 
            // RequestConsiderationButtonDeсide
            // 
            this.RequestConsiderationButtonDeсide.Enabled = false;
            this.RequestConsiderationButtonDeсide.Location = new System.Drawing.Point(714, 36);
            this.RequestConsiderationButtonDeсide.Name = "RequestConsiderationButtonDeсide";
            this.RequestConsiderationButtonDeсide.Size = new System.Drawing.Size(182, 44);
            this.RequestConsiderationButtonDeсide.TabIndex = 45;
            this.RequestConsiderationButtonDeсide.Text = "Записать решение";
            this.RequestConsiderationButtonDeсide.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonDeсide.Click += new System.EventHandler(this.RequestConsiderationButtonDeсide_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(712, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 24);
            this.label2.TabIndex = 46;
            this.label2.Text = "Решение";
            // 
            // RequestConsiderationBuy
            // 
            this.RequestConsiderationBuy.AutoSize = true;
            this.RequestConsiderationBuy.Location = new System.Drawing.Point(716, 111);
            this.RequestConsiderationBuy.Name = "RequestConsiderationBuy";
            this.RequestConsiderationBuy.Size = new System.Drawing.Size(88, 24);
            this.RequestConsiderationBuy.TabIndex = 47;
            this.RequestConsiderationBuy.Text = "Закупка";
            this.RequestConsiderationBuy.UseVisualStyleBackColor = true;
            this.RequestConsiderationBuy.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // RequestConsiderationTransfer
            // 
            this.RequestConsiderationTransfer.AutoSize = true;
            this.RequestConsiderationTransfer.Location = new System.Drawing.Point(716, 141);
            this.RequestConsiderationTransfer.Name = "RequestConsiderationTransfer";
            this.RequestConsiderationTransfer.Size = new System.Drawing.Size(104, 24);
            this.RequestConsiderationTransfer.TabIndex = 48;
            this.RequestConsiderationTransfer.Text = "Передача";
            this.RequestConsiderationTransfer.UseVisualStyleBackColor = true;
            this.RequestConsiderationTransfer.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 24);
            this.label4.TabIndex = 49;
            this.label4.Text = "Остаток на ЦИС:";
            // 
            // RequestConsiderationQuantity
            // 
            this.RequestConsiderationQuantity.Location = new System.Drawing.Point(177, 238);
            this.RequestConsiderationQuantity.Name = "RequestConsiderationQuantity";
            this.RequestConsiderationQuantity.ReadOnly = true;
            this.RequestConsiderationQuantity.Size = new System.Drawing.Size(167, 26);
            this.RequestConsiderationQuantity.TabIndex = 50;
            // 
            // receivingRequestsContentInjTableAdapter
            // 
            this.receivingRequestsContentInjTableAdapter.ClearBeforeFill = true;
            // 
            // replacementFixationInjTableAdapter
            // 
            this.replacementFixationInjTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseRequestsContentTableAdapter
            // 
            this.purchaseRequestsContentTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseRequestsTableAdapter
            // 
            this.purchaseRequestsTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseRequestsBindingSource
            // 
            this.purchaseRequestsBindingSource.DataMember = "PurchaseRequests";
            this.purchaseRequestsBindingSource.DataSource = this.tOOLACCOUNTINGDataSet;
            // 
            // receivingRequestsContentBindingSource
            // 
            this.receivingRequestsContentBindingSource.DataMember = "ReceivingRequestsContent";
            this.receivingRequestsContentBindingSource.DataSource = this.tOOLACCOUNTINGDataSet;
            // 
            // receivingRequestsContentTableAdapter
            // 
            this.receivingRequestsContentTableAdapter.ClearBeforeFill = true;
            // 
            // workshopsTableAdapter
            // 
            this.workshopsTableAdapter.ClearBeforeFill = true;
            // 
            // dataTable2TableAdapter
            // 
            this.dataTable2TableAdapter.ClearBeforeFill = true;
            // 
            // balancesInjTableAdapter
            // 
            this.balancesInjTableAdapter.ClearBeforeFill = true;
            // 
            // RequestConsiderationButtonReplace
            // 
            this.RequestConsiderationButtonReplace.Enabled = false;
            this.RequestConsiderationButtonReplace.Location = new System.Drawing.Point(714, 310);
            this.RequestConsiderationButtonReplace.Name = "RequestConsiderationButtonReplace";
            this.RequestConsiderationButtonReplace.Size = new System.Drawing.Size(182, 44);
            this.RequestConsiderationButtonReplace.TabIndex = 51;
            this.RequestConsiderationButtonReplace.Text = "Заменить";
            this.RequestConsiderationButtonReplace.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonReplace.Click += new System.EventHandler(this.RequestConsiderationButtonReplace_Click);
            // 
            // replacementFixationTableAdapter
            // 
            this.replacementFixationTableAdapter.ClearBeforeFill = true;
            // 
            // RequestConsideration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 493);
            this.Controls.Add(this.RequestConsiderationButtonReplace);
            this.Controls.Add(this.RequestConsiderationQuantity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RequestConsiderationTransfer);
            this.Controls.Add(this.RequestConsiderationBuy);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RequestConsiderationButtonDeсide);
            this.Controls.Add(this.RequestConsiderationButtonClose);
            this.Controls.Add(this.RequestConsiderationButtonSaveClose);
            this.Controls.Add(this.RequestConsiderationButtonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RequestConsiderationFixationTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.RequestConsiderationContentTable);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RequestConsideration";
            this.Text = "Форма рассмотрения заявки на получение – Информационная система учета и приобрете" +
    "ния инструмента";
            this.Load += new System.EventHandler(this.RequestConsideration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RequestConsiderationContentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequestConsiderationFixationTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjDataTable2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjReplacementFixationInjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseRequestsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView RequestConsiderationContentTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView RequestConsiderationFixationTable;
        private TOOLACCOUNTINGDataSet tOOLACCOUNTINGDataSet;
        private System.Windows.Forms.BindingSource receivingRequestsContentInjBindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentInjTableAdapter receivingRequestsContentInjTableAdapter;
        private TOOLACCOUNTINGDataSetTableAdapters.ReplacementFixationInjTableAdapter replacementFixationInjTableAdapter;
        private System.Windows.Forms.Button RequestConsiderationButtonClose;
        private System.Windows.Forms.Button RequestConsiderationButtonSaveClose;
        private System.Windows.Forms.Button RequestConsiderationButtonSave;
        private System.Windows.Forms.BindingSource receivingRequestsContentInjReplacementFixationInjBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingRequestIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingContentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button RequestConsiderationButtonDeсide;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RequestConsiderationBuy;
        private System.Windows.Forms.RadioButton RequestConsiderationTransfer;
        private TOOLACCOUNTINGDataSetTableAdapters.PurchaseRequestsContentTableAdapter purchaseRequestsContentTableAdapter;
        private TOOLACCOUNTINGDataSetTableAdapters.PurchaseRequestsTableAdapter purchaseRequestsTableAdapter;
        private System.Windows.Forms.BindingSource purchaseRequestsBindingSource;
        private System.Windows.Forms.BindingSource receivingRequestsContentBindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentTableAdapter receivingRequestsContentTableAdapter;
        private TOOLACCOUNTINGDataSetTableAdapters.WorkshopsTableAdapter workshopsTableAdapter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox RequestConsiderationQuantity;
        private System.Windows.Forms.BindingSource receivingRequestsContentInjDataTable2BindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.DataTable2TableAdapter dataTable2TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn availableQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingContentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn analogNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn1;
        private TOOLACCOUNTINGDataSetTableAdapters.BalancesInjTableAdapter balancesInjTableAdapter;
        private System.Windows.Forms.Button RequestConsiderationButtonReplace;
        private TOOLACCOUNTINGDataSetTableAdapters.ReplacementFixationTableAdapter replacementFixationTableAdapter;
    }
}