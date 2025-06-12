namespace Система_учёта_и_приобретения_инструмента
{
    partial class PurchaseRequest
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseRequest));
            this.label39 = new System.Windows.Forms.Label();
            this.tOOLACCOUNTINGDataSet = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet();
            this.PurchaseRequestNumber = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.PurchaseRequestButtonClose = new System.Windows.Forms.Button();
            this.PurchaseRequestButtonSaveClose = new System.Windows.Forms.Button();
            this.PurchaseRequestButtonSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.PurchaseRequestButtonRemove = new System.Windows.Forms.Button();
            this.PurchaseRequestButtonAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.PurchaseRequestDate = new System.Windows.Forms.TextBox();
            this.PurchaseRequestsContentTable = new System.Windows.Forms.DataGridView();
            this.purchaseRequestsContentInjBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purchaseRequestsContentInjTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.PurchaseRequestsContentInjTableAdapter();
            this.purchaseContentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.purchaseRequestIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivingContentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isPurchaseDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.donorWorkshopIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomenclatureNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requiredQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseRequestsContentTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseRequestsContentInjBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label39.Location = new System.Drawing.Point(13, 131);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(350, 24);
            this.label39.TabIndex = 61;
            this.label39.Text = "Инструменты из заявок на получение";
            // 
            // tOOLACCOUNTINGDataSet
            // 
            this.tOOLACCOUNTINGDataSet.DataSetName = "TOOLACCOUNTINGDataSet";
            this.tOOLACCOUNTINGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PurchaseRequestNumber
            // 
            this.PurchaseRequestNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PurchaseRequestNumber.Location = new System.Drawing.Point(78, 12);
            this.PurchaseRequestNumber.Name = "PurchaseRequestNumber";
            this.PurchaseRequestNumber.ReadOnly = true;
            this.PurchaseRequestNumber.Size = new System.Drawing.Size(253, 29);
            this.PurchaseRequestNumber.TabIndex = 55;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label38.Location = new System.Drawing.Point(335, 21);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(48, 20);
            this.label38.TabIndex = 56;
            this.label38.Text = "Дата";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label32.Location = new System.Drawing.Point(13, 21);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(59, 20);
            this.label32.TabIndex = 54;
            this.label32.Text = "Номер";
            // 
            // PurchaseRequestButtonClose
            // 
            this.PurchaseRequestButtonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PurchaseRequestButtonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PurchaseRequestButtonClose.Location = new System.Drawing.Point(769, 408);
            this.PurchaseRequestButtonClose.MaximumSize = new System.Drawing.Size(103, 31);
            this.PurchaseRequestButtonClose.MinimumSize = new System.Drawing.Size(103, 31);
            this.PurchaseRequestButtonClose.Name = "PurchaseRequestButtonClose";
            this.PurchaseRequestButtonClose.Size = new System.Drawing.Size(103, 31);
            this.PurchaseRequestButtonClose.TabIndex = 67;
            this.PurchaseRequestButtonClose.Text = "Закрыть";
            this.PurchaseRequestButtonClose.UseVisualStyleBackColor = true;
            // 
            // PurchaseRequestButtonSaveClose
            // 
            this.PurchaseRequestButtonSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PurchaseRequestButtonSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PurchaseRequestButtonSaveClose.Location = new System.Drawing.Point(535, 408);
            this.PurchaseRequestButtonSaveClose.Name = "PurchaseRequestButtonSaveClose";
            this.PurchaseRequestButtonSaveClose.Size = new System.Drawing.Size(228, 31);
            this.PurchaseRequestButtonSaveClose.TabIndex = 66;
            this.PurchaseRequestButtonSaveClose.Text = "Сохранить и закрыть";
            this.PurchaseRequestButtonSaveClose.UseVisualStyleBackColor = true;
            this.PurchaseRequestButtonSaveClose.Visible = false;
            // 
            // PurchaseRequestButtonSave
            // 
            this.PurchaseRequestButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PurchaseRequestButtonSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PurchaseRequestButtonSave.Location = new System.Drawing.Point(397, 408);
            this.PurchaseRequestButtonSave.Name = "PurchaseRequestButtonSave";
            this.PurchaseRequestButtonSave.Size = new System.Drawing.Size(132, 31);
            this.PurchaseRequestButtonSave.TabIndex = 65;
            this.PurchaseRequestButtonSave.Text = "Сохранить";
            this.PurchaseRequestButtonSave.UseVisualStyleBackColor = true;
            this.PurchaseRequestButtonSave.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 31);
            this.label1.TabIndex = 68;
            this.label1.Text = "Выберите инструменты,";
            // 
            // PurchaseRequestButtonRemove
            // 
            this.PurchaseRequestButtonRemove.Enabled = false;
            this.PurchaseRequestButtonRemove.Location = new System.Drawing.Point(690, 207);
            this.PurchaseRequestButtonRemove.Name = "PurchaseRequestButtonRemove";
            this.PurchaseRequestButtonRemove.Size = new System.Drawing.Size(182, 44);
            this.PurchaseRequestButtonRemove.TabIndex = 70;
            this.PurchaseRequestButtonRemove.Text = "Убрать";
            this.PurchaseRequestButtonRemove.UseVisualStyleBackColor = true;
            this.PurchaseRequestButtonRemove.Click += new System.EventHandler(this.PurchaseRequestButtonRemove_Click);
            // 
            // PurchaseRequestButtonAdd
            // 
            this.PurchaseRequestButtonAdd.Enabled = false;
            this.PurchaseRequestButtonAdd.Location = new System.Drawing.Point(690, 157);
            this.PurchaseRequestButtonAdd.Name = "PurchaseRequestButtonAdd";
            this.PurchaseRequestButtonAdd.Size = new System.Drawing.Size(182, 44);
            this.PurchaseRequestButtonAdd.TabIndex = 69;
            this.PurchaseRequestButtonAdd.Text = "Добавить";
            this.PurchaseRequestButtonAdd.UseVisualStyleBackColor = true;
            this.PurchaseRequestButtonAdd.Click += new System.EventHandler(this.PurchaseRequestButtonAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(706, 31);
            this.label2.TabIndex = 71;
            this.label2.Text = "которые необходимо внести в заявку на приобретение";
            // 
            // PurchaseRequestDate
            // 
            this.PurchaseRequestDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PurchaseRequestDate.Location = new System.Drawing.Point(389, 12);
            this.PurchaseRequestDate.Name = "PurchaseRequestDate";
            this.PurchaseRequestDate.ReadOnly = true;
            this.PurchaseRequestDate.Size = new System.Drawing.Size(253, 29);
            this.PurchaseRequestDate.TabIndex = 57;
            // 
            // PurchaseRequestsContentTable
            // 
            this.PurchaseRequestsContentTable.AllowUserToAddRows = false;
            this.PurchaseRequestsContentTable.AllowUserToDeleteRows = false;
            this.PurchaseRequestsContentTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PurchaseRequestsContentTable.AutoGenerateColumns = false;
            this.PurchaseRequestsContentTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.PurchaseRequestsContentTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PurchaseRequestsContentTable.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.purchaseContentIDDataGridViewTextBoxColumn,
            this.purchaseRequestIDDataGridViewTextBoxColumn,
            this.receivingContentIDDataGridViewTextBoxColumn,
            this.isPurchaseDataGridViewCheckBoxColumn,
            this.donorWorkshopIDDataGridViewTextBoxColumn,
            this.nomenclatureNumberDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.requiredQuantityDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn});
            this.PurchaseRequestsContentTable.DataSource = this.purchaseRequestsContentInjBindingSource;
            this.PurchaseRequestsContentTable.Location = new System.Drawing.Point(17, 157);
            this.PurchaseRequestsContentTable.MultiSelect = false;
            this.PurchaseRequestsContentTable.Name = "PurchaseRequestsContentTable";
            this.PurchaseRequestsContentTable.ReadOnly = true;
            this.PurchaseRequestsContentTable.RowHeadersVisible = false;
            this.PurchaseRequestsContentTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PurchaseRequestsContentTable.Size = new System.Drawing.Size(667, 245);
            this.PurchaseRequestsContentTable.TabIndex = 72;
            this.PurchaseRequestsContentTable.CurrentCellChanged += new System.EventHandler(this.PurchaseRequestsContentTable_CurrentCellChanged);
            // 
            // purchaseRequestsContentInjBindingSource
            // 
            this.purchaseRequestsContentInjBindingSource.DataMember = "PurchaseRequestsContentInj";
            this.purchaseRequestsContentInjBindingSource.DataSource = this.tOOLACCOUNTINGDataSet;
            // 
            // purchaseRequestsContentInjTableAdapter
            // 
            this.purchaseRequestsContentInjTableAdapter.ClearBeforeFill = true;
            // 
            // purchaseContentIDDataGridViewTextBoxColumn
            // 
            this.purchaseContentIDDataGridViewTextBoxColumn.DataPropertyName = "PurchaseContentID";
            this.purchaseContentIDDataGridViewTextBoxColumn.HeaderText = "PurchaseContentID";
            this.purchaseContentIDDataGridViewTextBoxColumn.Name = "purchaseContentIDDataGridViewTextBoxColumn";
            this.purchaseContentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseContentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // purchaseRequestIDDataGridViewTextBoxColumn
            // 
            this.purchaseRequestIDDataGridViewTextBoxColumn.DataPropertyName = "PurchaseRequestID";
            this.purchaseRequestIDDataGridViewTextBoxColumn.HeaderText = "PurchaseRequestID";
            this.purchaseRequestIDDataGridViewTextBoxColumn.Name = "purchaseRequestIDDataGridViewTextBoxColumn";
            this.purchaseRequestIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.purchaseRequestIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // receivingContentIDDataGridViewTextBoxColumn
            // 
            this.receivingContentIDDataGridViewTextBoxColumn.DataPropertyName = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn.HeaderText = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn.Name = "receivingContentIDDataGridViewTextBoxColumn";
            this.receivingContentIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.receivingContentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // isPurchaseDataGridViewCheckBoxColumn
            // 
            this.isPurchaseDataGridViewCheckBoxColumn.DataPropertyName = "IsPurchase";
            this.isPurchaseDataGridViewCheckBoxColumn.HeaderText = "IsPurchase";
            this.isPurchaseDataGridViewCheckBoxColumn.Name = "isPurchaseDataGridViewCheckBoxColumn";
            this.isPurchaseDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isPurchaseDataGridViewCheckBoxColumn.Visible = false;
            // 
            // donorWorkshopIDDataGridViewTextBoxColumn
            // 
            this.donorWorkshopIDDataGridViewTextBoxColumn.DataPropertyName = "DonorWorkshopID";
            this.donorWorkshopIDDataGridViewTextBoxColumn.HeaderText = "DonorWorkshopID";
            this.donorWorkshopIDDataGridViewTextBoxColumn.Name = "donorWorkshopIDDataGridViewTextBoxColumn";
            this.donorWorkshopIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.donorWorkshopIDDataGridViewTextBoxColumn.Visible = false;
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
            // requiredQuantityDataGridViewTextBoxColumn
            // 
            this.requiredQuantityDataGridViewTextBoxColumn.DataPropertyName = "RequiredQuantity";
            this.requiredQuantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.requiredQuantityDataGridViewTextBoxColumn.Name = "requiredQuantityDataGridViewTextBoxColumn";
            this.requiredQuantityDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Статус";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // PurchaseRequest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 451);
            this.Controls.Add(this.PurchaseRequestsContentTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PurchaseRequestButtonRemove);
            this.Controls.Add(this.PurchaseRequestButtonAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PurchaseRequestButtonClose);
            this.Controls.Add(this.PurchaseRequestButtonSaveClose);
            this.Controls.Add(this.PurchaseRequestButtonSave);
            this.Controls.Add(this.label39);
            this.Controls.Add(this.PurchaseRequestDate);
            this.Controls.Add(this.PurchaseRequestNumber);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label32);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(900, 490);
            this.MinimumSize = new System.Drawing.Size(900, 490);
            this.Name = "PurchaseRequest";
            this.Text = "Форма заявки на приобретение – Информационная система учета и приобретения инстру" +
    "мента";
            this.Load += new System.EventHandler(this.PurchaseRequest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PurchaseRequestsContentTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purchaseRequestsContentInjBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.TextBox PurchaseRequestNumber;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button PurchaseRequestButtonClose;
        private System.Windows.Forms.Button PurchaseRequestButtonSaveClose;
        private System.Windows.Forms.Button PurchaseRequestButtonSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PurchaseRequestButtonRemove;
        private System.Windows.Forms.Button PurchaseRequestButtonAdd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox PurchaseRequestDate;
        private TOOLACCOUNTINGDataSet tOOLACCOUNTINGDataSet;
        private System.Windows.Forms.DataGridView PurchaseRequestsContentTable;
        private System.Windows.Forms.BindingSource purchaseRequestsContentInjBindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.PurchaseRequestsContentInjTableAdapter purchaseRequestsContentInjTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseContentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn purchaseRequestIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingContentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isPurchaseDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn donorWorkshopIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requiredQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
    }
}