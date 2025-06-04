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
            this.receivingRequestsContentInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentInjTableAdapter();
            this.replacementFixationInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.ReplacementFixationInjTableAdapter();
            this.RequestConsiderationButtonDelete = new System.Windows.Forms.Button();
            this.RequestConsiderationButtonAlter = new System.Windows.Forms.Button();
            this.RequestConsiderationButtonCreate = new System.Windows.Forms.Button();
            this.RequestConsiderationButtonClose = new System.Windows.Forms.Button();
            this.RequestConsiderationButtonSaveClose = new System.Windows.Forms.Button();
            this.RequestConsiderationButtonSave = new System.Windows.Forms.Button();
            this.receivingRequestsContentInjReplacementFixationInjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.receivingRequestsContentInjReplacementFixationInjBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.receivingContentIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.analogNomenclatureNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.RequestConsiderationContentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RequestConsiderationFixationTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjReplacementFixationInjBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjReplacementFixationInjBindingSource1)).BeginInit();
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
            this.RequestConsiderationContentTable.Size = new System.Drawing.Size(884, 234);
            this.RequestConsiderationContentTable.TabIndex = 0;
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
            this.nomenclatureNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.nomenclatureNumberDataGridViewTextBoxColumn.DataPropertyName = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn.HeaderText = "Номенклатурный номер";
            this.nomenclatureNumberDataGridViewTextBoxColumn.Name = "nomenclatureNumberDataGridViewTextBoxColumn";
            this.nomenclatureNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.nomenclatureNumberDataGridViewTextBoxColumn.Width = 196;
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
            this.label1.Location = new System.Drawing.Point(12, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(353, 24);
            this.label1.TabIndex = 38;
            this.label1.Text = "Зафиксированные замены на аналоги";
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
            this.analogNomenclatureNumberDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn1});
            this.RequestConsiderationFixationTable.DataSource = this.receivingRequestsContentInjReplacementFixationInjBindingSource1;
            this.RequestConsiderationFixationTable.Location = new System.Drawing.Point(12, 310);
            this.RequestConsiderationFixationTable.MultiSelect = false;
            this.RequestConsiderationFixationTable.Name = "RequestConsiderationFixationTable";
            this.RequestConsiderationFixationTable.ReadOnly = true;
            this.RequestConsiderationFixationTable.RowHeadersVisible = false;
            this.RequestConsiderationFixationTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RequestConsiderationFixationTable.Size = new System.Drawing.Size(694, 234);
            this.RequestConsiderationFixationTable.TabIndex = 37;
            this.RequestConsiderationFixationTable.CurrentCellChanged += new System.EventHandler(this.RequestConsiderationFixationTable_CurrentCellChanged);
            // 
            // receivingRequestsContentInjTableAdapter
            // 
            this.receivingRequestsContentInjTableAdapter.ClearBeforeFill = true;
            // 
            // replacementFixationInjTableAdapter
            // 
            this.replacementFixationInjTableAdapter.ClearBeforeFill = true;
            // 
            // RequestConsiderationButtonDelete
            // 
            this.RequestConsiderationButtonDelete.Enabled = false;
            this.RequestConsiderationButtonDelete.Location = new System.Drawing.Point(714, 410);
            this.RequestConsiderationButtonDelete.Name = "RequestConsiderationButtonDelete";
            this.RequestConsiderationButtonDelete.Size = new System.Drawing.Size(182, 44);
            this.RequestConsiderationButtonDelete.TabIndex = 41;
            this.RequestConsiderationButtonDelete.Text = "Удалить";
            this.RequestConsiderationButtonDelete.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonDelete.Click += new System.EventHandler(this.RequestConsiderationButtonDelete_Click);
            // 
            // RequestConsiderationButtonAlter
            // 
            this.RequestConsiderationButtonAlter.Enabled = false;
            this.RequestConsiderationButtonAlter.Location = new System.Drawing.Point(714, 360);
            this.RequestConsiderationButtonAlter.Name = "RequestConsiderationButtonAlter";
            this.RequestConsiderationButtonAlter.Size = new System.Drawing.Size(182, 44);
            this.RequestConsiderationButtonAlter.TabIndex = 40;
            this.RequestConsiderationButtonAlter.Text = "Изменить";
            this.RequestConsiderationButtonAlter.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonAlter.Click += new System.EventHandler(this.RequestConsiderationButtonAlter_Click);
            // 
            // RequestConsiderationButtonCreate
            // 
            this.RequestConsiderationButtonCreate.Location = new System.Drawing.Point(714, 310);
            this.RequestConsiderationButtonCreate.Name = "RequestConsiderationButtonCreate";
            this.RequestConsiderationButtonCreate.Size = new System.Drawing.Size(182, 44);
            this.RequestConsiderationButtonCreate.TabIndex = 39;
            this.RequestConsiderationButtonCreate.Text = "Создать";
            this.RequestConsiderationButtonCreate.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonCreate.Click += new System.EventHandler(this.RequestConsiderationButtonCreate_Click);
            // 
            // RequestConsiderationButtonClose
            // 
            this.RequestConsiderationButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestConsiderationButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RequestConsiderationButtonClose.Location = new System.Drawing.Point(793, 560);
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
            this.RequestConsiderationButtonSaveClose.Location = new System.Drawing.Point(559, 560);
            this.RequestConsiderationButtonSaveClose.Name = "RequestConsiderationButtonSaveClose";
            this.RequestConsiderationButtonSaveClose.Size = new System.Drawing.Size(228, 31);
            this.RequestConsiderationButtonSaveClose.TabIndex = 43;
            this.RequestConsiderationButtonSaveClose.Text = "Сохранить и закрыть";
            this.RequestConsiderationButtonSaveClose.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonSaveClose.Click += new System.EventHandler(this.RequestConsiderationButtonSaveClose_Click);
            // 
            // RequestConsiderationButtonSave
            // 
            this.RequestConsiderationButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RequestConsiderationButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RequestConsiderationButtonSave.Location = new System.Drawing.Point(421, 560);
            this.RequestConsiderationButtonSave.Name = "RequestConsiderationButtonSave";
            this.RequestConsiderationButtonSave.Size = new System.Drawing.Size(132, 31);
            this.RequestConsiderationButtonSave.TabIndex = 42;
            this.RequestConsiderationButtonSave.Text = "Сохранить";
            this.RequestConsiderationButtonSave.UseVisualStyleBackColor = true;
            this.RequestConsiderationButtonSave.Click += new System.EventHandler(this.RequestConsiderationButtonSave_Click);
            // 
            // receivingRequestsContentInjReplacementFixationInjBindingSource
            // 
            this.receivingRequestsContentInjReplacementFixationInjBindingSource.DataMember = "ReceivingRequestsContentInj_ReplacementFixationInj";
            this.receivingRequestsContentInjReplacementFixationInjBindingSource.DataSource = this.receivingRequestsContentInjBindingSource;
            // 
            // receivingRequestsContentInjReplacementFixationInjBindingSource1
            // 
            this.receivingRequestsContentInjReplacementFixationInjBindingSource1.DataMember = "ReceivingRequestsContentInj_ReplacementFixationInj";
            this.receivingRequestsContentInjReplacementFixationInjBindingSource1.DataSource = this.receivingRequestsContentInjBindingSource;
            // 
            // receivingContentIDDataGridViewTextBoxColumn1
            // 
            this.receivingContentIDDataGridViewTextBoxColumn1.DataPropertyName = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn1.HeaderText = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn1.Name = "receivingContentIDDataGridViewTextBoxColumn1";
            this.receivingContentIDDataGridViewTextBoxColumn1.ReadOnly = true;
            this.receivingContentIDDataGridViewTextBoxColumn1.Visible = false;
            // 
            // analogNomenclatureNumberDataGridViewTextBoxColumn
            // 
            this.analogNomenclatureNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.analogNomenclatureNumberDataGridViewTextBoxColumn.DataPropertyName = "AnalogNomenclatureNumber";
            this.analogNomenclatureNumberDataGridViewTextBoxColumn.HeaderText = "Номенклатурный номер аналога";
            this.analogNomenclatureNumberDataGridViewTextBoxColumn.Name = "analogNomenclatureNumberDataGridViewTextBoxColumn";
            this.analogNomenclatureNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // quantityDataGridViewTextBoxColumn1
            // 
            this.quantityDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.quantityDataGridViewTextBoxColumn1.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn1.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn1.Name = "quantityDataGridViewTextBoxColumn1";
            this.quantityDataGridViewTextBoxColumn1.ReadOnly = true;
            this.quantityDataGridViewTextBoxColumn1.Width = 125;
            // 
            // RequestConsideration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 606);
            this.Controls.Add(this.RequestConsiderationButtonClose);
            this.Controls.Add(this.RequestConsiderationButtonSaveClose);
            this.Controls.Add(this.RequestConsiderationButtonSave);
            this.Controls.Add(this.RequestConsiderationButtonDelete);
            this.Controls.Add(this.RequestConsiderationButtonAlter);
            this.Controls.Add(this.RequestConsiderationButtonCreate);
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
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjReplacementFixationInjBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentInjReplacementFixationInjBindingSource1)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingRequestIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingContentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button RequestConsiderationButtonDelete;
        private System.Windows.Forms.Button RequestConsiderationButtonAlter;
        private System.Windows.Forms.Button RequestConsiderationButtonCreate;
        private System.Windows.Forms.Button RequestConsiderationButtonClose;
        private System.Windows.Forms.Button RequestConsiderationButtonSaveClose;
        private System.Windows.Forms.Button RequestConsiderationButtonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingContentIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn analogNomenclatureNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource receivingRequestsContentInjReplacementFixationInjBindingSource1;
        private System.Windows.Forms.BindingSource receivingRequestsContentInjReplacementFixationInjBindingSource;
    }
}