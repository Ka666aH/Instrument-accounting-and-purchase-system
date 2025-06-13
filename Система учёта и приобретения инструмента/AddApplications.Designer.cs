namespace Система_учёта_и_приобретения_инструмента
{
    partial class AddApplications
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddApplications));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ApplicationType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ApplicationDate = new System.Windows.Forms.TextBox();
            this.Workshop = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Reason = new System.Windows.Forms.ComboBox();
            this.OtherReasonText = new System.Windows.Forms.Label();
            this.OtherReason = new System.Windows.Forms.TextBox();
            this.WorkshopFormClose = new System.Windows.Forms.Button();
            this.WorkshopFormSaveClose = new System.Windows.Forms.Button();
            this.WorkshopFormSave = new System.Windows.Forms.Button();
            this.ApplicationsCompound = new System.Windows.Forms.DataGridView();
            this.receivingRequestsContentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tOOLACCOUNTINGDataSet = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSet();
            this.receivingRequestsContentTableAdapter = new Система_учёта_и_приобретения_инструмента.TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentTableAdapter();
            this.label7 = new System.Windows.Forms.Label();
            this.receivingContentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receivingRequestIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomenclatureNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationsCompound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(249, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заявка на получение № ";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(436, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(118, 29);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(322, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "От:";
            // 
            // ApplicationType
            // 
            this.ApplicationType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationType.CausesValidation = false;
            this.ApplicationType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplicationType.FormattingEnabled = true;
            this.ApplicationType.Items.AddRange(new object[] {
            "Плановая",
            "Внеплановая"});
            this.ApplicationType.Location = new System.Drawing.Point(59, 85);
            this.ApplicationType.Name = "ApplicationType";
            this.ApplicationType.Size = new System.Drawing.Size(184, 28);
            this.ApplicationType.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Цех *";
            // 
            // ApplicationDate
            // 
            this.ApplicationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ApplicationDate.Location = new System.Drawing.Point(359, 44);
            this.ApplicationDate.Name = "ApplicationDate";
            this.ApplicationDate.ReadOnly = true;
            this.ApplicationDate.Size = new System.Drawing.Size(118, 29);
            this.ApplicationDate.TabIndex = 1;
            // 
            // Workshop
            // 
            this.Workshop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Workshop.CausesValidation = false;
            this.Workshop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Workshop.FormattingEnabled = true;
            this.Workshop.Location = new System.Drawing.Point(59, 116);
            this.Workshop.Name = "Workshop";
            this.Workshop.Size = new System.Drawing.Size(184, 28);
            this.Workshop.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "Тип *";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(59, 148);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(184, 26);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(28, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "К *";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(249, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Причина *";
            // 
            // Reason
            // 
            this.Reason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Reason.CausesValidation = false;
            this.Reason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Reason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Reason.FormattingEnabled = true;
            this.Reason.Items.AddRange(new object[] {
            "Увеличение объемов производства",
            "Передача инструмента в другой цех",
            "Ввод нового оборудования",
            "Преждевременный выход инструмента из строя",
            "Другое"});
            this.Reason.Location = new System.Drawing.Point(330, 85);
            this.Reason.Name = "Reason";
            this.Reason.Size = new System.Drawing.Size(442, 28);
            this.Reason.TabIndex = 3;
            this.Reason.SelectedIndexChanged += new System.EventHandler(this.Reason_SelectedIndexChanged);
            // 
            // OtherReasonText
            // 
            this.OtherReasonText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OtherReasonText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OtherReasonText.Location = new System.Drawing.Point(249, 119);
            this.OtherReasonText.Name = "OtherReasonText";
            this.OtherReasonText.Size = new System.Drawing.Size(79, 52);
            this.OtherReasonText.TabIndex = 0;
            this.OtherReasonText.Text = "Другая причина:";
            this.OtherReasonText.Visible = false;
            // 
            // OtherReason
            // 
            this.OtherReason.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OtherReason.Location = new System.Drawing.Point(330, 119);
            this.OtherReason.Multiline = true;
            this.OtherReason.Name = "OtherReason";
            this.OtherReason.Size = new System.Drawing.Size(442, 55);
            this.OtherReason.TabIndex = 6;
            this.OtherReason.Visible = false;
            // 
            // WorkshopFormClose
            // 
            this.WorkshopFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopFormClose.Location = new System.Drawing.Point(670, 522);
            this.WorkshopFormClose.MaximumSize = new System.Drawing.Size(103, 31);
            this.WorkshopFormClose.MinimumSize = new System.Drawing.Size(103, 31);
            this.WorkshopFormClose.Name = "WorkshopFormClose";
            this.WorkshopFormClose.Size = new System.Drawing.Size(103, 31);
            this.WorkshopFormClose.TabIndex = 37;
            this.WorkshopFormClose.Text = "Закрыть";
            this.WorkshopFormClose.UseVisualStyleBackColor = true;
            this.WorkshopFormClose.Click += new System.EventHandler(this.CloseNewApplication_Click);
            // 
            // WorkshopFormSaveClose
            // 
            this.WorkshopFormSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopFormSaveClose.Location = new System.Drawing.Point(436, 522);
            this.WorkshopFormSaveClose.Name = "WorkshopFormSaveClose";
            this.WorkshopFormSaveClose.Size = new System.Drawing.Size(228, 31);
            this.WorkshopFormSaveClose.TabIndex = 36;
            this.WorkshopFormSaveClose.Text = "Сохранить и закрыть";
            this.WorkshopFormSaveClose.UseVisualStyleBackColor = true;
            this.WorkshopFormSaveClose.Click += new System.EventHandler(this.WorkshopFormSaveClose_Click);
            // 
            // WorkshopFormSave
            // 
            this.WorkshopFormSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopFormSave.Location = new System.Drawing.Point(298, 522);
            this.WorkshopFormSave.Name = "WorkshopFormSave";
            this.WorkshopFormSave.Size = new System.Drawing.Size(132, 31);
            this.WorkshopFormSave.TabIndex = 35;
            this.WorkshopFormSave.Text = "Сохранить";
            this.WorkshopFormSave.UseVisualStyleBackColor = true;
            this.WorkshopFormSave.Click += new System.EventHandler(this.WorkshopFormSave_Click);
            // 
            // ApplicationsCompound
            // 
            this.ApplicationsCompound.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationsCompound.AutoGenerateColumns = false;
            this.ApplicationsCompound.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ApplicationsCompound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ApplicationsCompound.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.receivingContentIDDataGridViewTextBoxColumn,
            this.receivingRequestIDDataGridViewTextBoxColumn,
            this.nomenclatureNumberDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn});
            this.ApplicationsCompound.DataSource = this.receivingRequestsContentBindingSource;
            this.ApplicationsCompound.Location = new System.Drawing.Point(12, 209);
            this.ApplicationsCompound.MultiSelect = false;
            this.ApplicationsCompound.Name = "ApplicationsCompound";
            this.ApplicationsCompound.RowHeadersVisible = false;
            this.ApplicationsCompound.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ApplicationsCompound.Size = new System.Drawing.Size(760, 307);
            this.ApplicationsCompound.TabIndex = 2;
            this.ApplicationsCompound.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.ApplicationsCompound_CellValidated);
            this.ApplicationsCompound.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.ApplicationsCompound_EditingControlShowing_1);
            this.ApplicationsCompound.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.ApplicationsCompound_RowValidating);
            // 
            // receivingRequestsContentBindingSource
            // 
            this.receivingRequestsContentBindingSource.DataMember = "ReceivingRequestsContent";
            this.receivingRequestsContentBindingSource.DataSource = this.tOOLACCOUNTINGDataSet;
            // 
            // tOOLACCOUNTINGDataSet
            // 
            this.tOOLACCOUNTINGDataSet.DataSetName = "TOOLACCOUNTINGDataSet";
            this.tOOLACCOUNTINGDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // receivingRequestsContentTableAdapter
            // 
            this.receivingRequestsContentTableAdapter.ClearBeforeFill = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 186);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Содержимое заявки:";
            this.label7.Visible = false;
            // 
            // receivingContentIDDataGridViewTextBoxColumn
            // 
            this.receivingContentIDDataGridViewTextBoxColumn.DataPropertyName = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn.HeaderText = "ReceivingContentID";
            this.receivingContentIDDataGridViewTextBoxColumn.Name = "receivingContentIDDataGridViewTextBoxColumn";
            this.receivingContentIDDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // receivingRequestIDDataGridViewTextBoxColumn
            // 
            this.receivingRequestIDDataGridViewTextBoxColumn.DataPropertyName = "ReceivingRequestID";
            this.receivingRequestIDDataGridViewTextBoxColumn.HeaderText = "ReceivingRequestID";
            this.receivingRequestIDDataGridViewTextBoxColumn.Name = "receivingRequestIDDataGridViewTextBoxColumn";
            // 
            // nomenclatureNumberDataGridViewTextBoxColumn
            // 
            this.nomenclatureNumberDataGridViewTextBoxColumn.DataPropertyName = "NomenclatureNumber";
            this.nomenclatureNumberDataGridViewTextBoxColumn.HeaderText = "Номенклатурный номер";
            this.nomenclatureNumberDataGridViewTextBoxColumn.Name = "nomenclatureNumberDataGridViewTextBoxColumn";
            this.nomenclatureNumberDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "Полное наименование";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            this.fullNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Количество";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // AddApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.WorkshopFormClose);
            this.Controls.Add(this.WorkshopFormSaveClose);
            this.Controls.Add(this.WorkshopFormSave);
            this.Controls.Add(this.OtherReason);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.Reason);
            this.Controls.Add(this.Workshop);
            this.Controls.Add(this.ApplicationType);
            this.Controls.Add(this.ApplicationsCompound);
            this.Controls.Add(this.ApplicationDate);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.OtherReasonText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AddApplications";
            this.Text = "Создание заявки";
            this.Load += new System.EventHandler(this.AddApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ApplicationsCompound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.receivingRequestsContentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tOOLACCOUNTINGDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ApplicationType;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ApplicationDate;
        private System.Windows.Forms.ComboBox Workshop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Reason;
        private System.Windows.Forms.Label OtherReasonText;
        private System.Windows.Forms.TextBox OtherReason;
        private TOOLACCOUNTINGDataSet tOOLACCOUNTINGDataSet;
        private System.Windows.Forms.Button WorkshopFormClose;
        private System.Windows.Forms.Button WorkshopFormSaveClose;
        private System.Windows.Forms.Button WorkshopFormSave;
        private System.Windows.Forms.BindingSource receivingRequestsContentBindingSource;
        private TOOLACCOUNTINGDataSetTableAdapters.ReceivingRequestsContentTableAdapter receivingRequestsContentTableAdapter;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.DataGridView ApplicationsCompound;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingContentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn receivingRequestIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomenclatureNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
    }
}