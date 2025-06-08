namespace Система_учёта_и_приобретения_инструмента
{
    partial class NomenForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NomenForm));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.NomenFormOboz = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.NomenFormFullName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.NomenFormUsage = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.NomenFormOstatok = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.NomenFormSave = new System.Windows.Forms.Button();
            this.NomenFormSaveClose = new System.Windows.Forms.Button();
            this.NomenFormClose = new System.Windows.Forms.Button();
            this.NomenFormAddGroup = new System.Windows.Forms.Button();
            this.NomenFormNumber = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.NomenFormGroup = new System.Windows.Forms.TextBox();
            this.NomenFormUnits = new System.Windows.Forms.TextBox();
            this.NomenFormSize = new System.Windows.Forms.TextBox();
            this.NomenFormMaterial = new System.Windows.Forms.TextBox();
            this.NomenFormDocument = new System.Windows.Forms.TextBox();
            this.NomenFormProducer = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.NomenFormOstatok)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Наименование *";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Обозначение";
            // 
            // NomenFormOboz
            // 
            this.NomenFormOboz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormOboz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormOboz.Location = new System.Drawing.Point(270, 114);
            this.NomenFormOboz.Name = "NomenFormOboz";
            this.NomenFormOboz.Size = new System.Drawing.Size(475, 26);
            this.NomenFormOboz.TabIndex = 2;
            this.NomenFormOboz.Leave += new System.EventHandler(this.NomenFormOboz_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Единицы измерения *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(11, 216);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Типоразмеры";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(11, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(205, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Материал режущей части";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(11, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(226, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Нормативная документация";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(11, 360);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "Производитель";
            // 
            // NomenFormFullName
            // 
            this.NomenFormFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormFullName.Location = new System.Drawing.Point(270, 402);
            this.NomenFormFullName.Name = "NomenFormFullName";
            this.NomenFormFullName.ReadOnly = true;
            this.NomenFormFullName.Size = new System.Drawing.Size(475, 26);
            this.NomenFormFullName.TabIndex = 8;
            this.NomenFormFullName.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(11, 408);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Полное наименование";
            // 
            // NomenFormUsage
            // 
            this.NomenFormUsage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormUsage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NomenFormUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormUsage.FormattingEnabled = true;
            this.NomenFormUsage.Items.AddRange(new object[] {
            "",
            "0 – Используется и покупается",
            "1 – Используется и не покупается",
            "2 – Не используется и не покупается"});
            this.NomenFormUsage.Location = new System.Drawing.Point(270, 448);
            this.NomenFormUsage.Name = "NomenFormUsage";
            this.NomenFormUsage.Size = new System.Drawing.Size(475, 28);
            this.NomenFormUsage.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(11, 456);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(203, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Признак использования *";
            // 
            // NomenFormOstatok
            // 
            this.NomenFormOstatok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormOstatok.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormOstatok.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NomenFormOstatok.Location = new System.Drawing.Point(269, 498);
            this.NomenFormOstatok.Name = "NomenFormOstatok";
            this.NomenFormOstatok.Size = new System.Drawing.Size(475, 26);
            this.NomenFormOstatok.TabIndex = 9;
            this.NomenFormOstatok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(11, 504);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(251, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Неснижаемый остаток на ЦИС *";
            // 
            // NomenFormSave
            // 
            this.NomenFormSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormSave.Location = new System.Drawing.Point(269, 537);
            this.NomenFormSave.Name = "NomenFormSave";
            this.NomenFormSave.Size = new System.Drawing.Size(132, 31);
            this.NomenFormSave.TabIndex = 10;
            this.NomenFormSave.Text = "Сохранить";
            this.NomenFormSave.UseVisualStyleBackColor = true;
            this.NomenFormSave.Click += new System.EventHandler(this.NomenFormSave_Click);
            // 
            // NomenFormSaveClose
            // 
            this.NomenFormSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormSaveClose.Location = new System.Drawing.Point(407, 537);
            this.NomenFormSaveClose.Name = "NomenFormSaveClose";
            this.NomenFormSaveClose.Size = new System.Drawing.Size(228, 31);
            this.NomenFormSaveClose.TabIndex = 11;
            this.NomenFormSaveClose.Text = "Сохранить и закрыть";
            this.NomenFormSaveClose.UseVisualStyleBackColor = true;
            this.NomenFormSaveClose.Click += new System.EventHandler(this.NomenFormSaveClose_Click);
            // 
            // NomenFormClose
            // 
            this.NomenFormClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormClose.Location = new System.Drawing.Point(641, 537);
            this.NomenFormClose.Name = "NomenFormClose";
            this.NomenFormClose.Size = new System.Drawing.Size(103, 31);
            this.NomenFormClose.TabIndex = 12;
            this.NomenFormClose.Text = "Закрыть";
            this.NomenFormClose.UseVisualStyleBackColor = true;
            this.NomenFormClose.Click += new System.EventHandler(this.NomenFormClose_Click);
            // 
            // NomenFormAddGroup
            // 
            this.NomenFormAddGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormAddGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormAddGroup.Location = new System.Drawing.Point(717, 16);
            this.NomenFormAddGroup.Name = "NomenFormAddGroup";
            this.NomenFormAddGroup.Size = new System.Drawing.Size(28, 28);
            this.NomenFormAddGroup.TabIndex = 27;
            this.NomenFormAddGroup.Text = "+";
            this.NomenFormAddGroup.UseVisualStyleBackColor = true;
            this.NomenFormAddGroup.Click += new System.EventHandler(this.NomenFormAddGroup_Click);
            // 
            // NomenFormNumber
            // 
            this.NomenFormNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormNumber.Location = new System.Drawing.Point(270, 66);
            this.NomenFormNumber.Name = "NomenFormNumber";
            this.NomenFormNumber.ReadOnly = true;
            this.NomenFormNumber.Size = new System.Drawing.Size(475, 26);
            this.NomenFormNumber.TabIndex = 0;
            this.NomenFormNumber.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(12, 72);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(201, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Номенклатурный номер *";
            // 
            // NomenFormGroup
            // 
            this.NomenFormGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormGroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NomenFormGroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.NomenFormGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormGroup.Location = new System.Drawing.Point(270, 18);
            this.NomenFormGroup.Name = "NomenFormGroup";
            this.NomenFormGroup.Size = new System.Drawing.Size(441, 26);
            this.NomenFormGroup.TabIndex = 1;
            this.NomenFormGroup.Leave += new System.EventHandler(this.NomenFormGroup_Leave);
            // 
            // NomenFormUnits
            // 
            this.NomenFormUnits.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormUnits.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NomenFormUnits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.NomenFormUnits.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormUnits.Location = new System.Drawing.Point(270, 162);
            this.NomenFormUnits.Name = "NomenFormUnits";
            this.NomenFormUnits.Size = new System.Drawing.Size(475, 26);
            this.NomenFormUnits.TabIndex = 3;
            this.NomenFormUnits.Leave += new System.EventHandler(this.NomenFormUnits_Leave);
            // 
            // NomenFormSize
            // 
            this.NomenFormSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NomenFormSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.NomenFormSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormSize.Location = new System.Drawing.Point(270, 210);
            this.NomenFormSize.Name = "NomenFormSize";
            this.NomenFormSize.Size = new System.Drawing.Size(475, 26);
            this.NomenFormSize.TabIndex = 4;
            this.NomenFormSize.Leave += new System.EventHandler(this.NomenFormSize_Leave);
            // 
            // NomenFormMaterial
            // 
            this.NomenFormMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormMaterial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NomenFormMaterial.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.NomenFormMaterial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormMaterial.Location = new System.Drawing.Point(270, 258);
            this.NomenFormMaterial.Name = "NomenFormMaterial";
            this.NomenFormMaterial.Size = new System.Drawing.Size(475, 26);
            this.NomenFormMaterial.TabIndex = 5;
            this.NomenFormMaterial.Leave += new System.EventHandler(this.NomenFormMaterial_Leave);
            // 
            // NomenFormDocument
            // 
            this.NomenFormDocument.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormDocument.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NomenFormDocument.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.NomenFormDocument.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormDocument.Location = new System.Drawing.Point(270, 306);
            this.NomenFormDocument.Name = "NomenFormDocument";
            this.NomenFormDocument.Size = new System.Drawing.Size(475, 26);
            this.NomenFormDocument.TabIndex = 6;
            this.NomenFormDocument.Leave += new System.EventHandler(this.NomenFormDocument_Leave);
            // 
            // NomenFormProducer
            // 
            this.NomenFormProducer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NomenFormProducer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.NomenFormProducer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.NomenFormProducer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NomenFormProducer.Location = new System.Drawing.Point(270, 354);
            this.NomenFormProducer.Name = "NomenFormProducer";
            this.NomenFormProducer.Size = new System.Drawing.Size(475, 26);
            this.NomenFormProducer.TabIndex = 7;
            this.NomenFormProducer.Leave += new System.EventHandler(this.NomenFormProducer_Leave);
            // 
            // NomenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 580);
            this.Controls.Add(this.NomenFormProducer);
            this.Controls.Add(this.NomenFormDocument);
            this.Controls.Add(this.NomenFormMaterial);
            this.Controls.Add(this.NomenFormSize);
            this.Controls.Add(this.NomenFormUnits);
            this.Controls.Add(this.NomenFormGroup);
            this.Controls.Add(this.NomenFormNumber);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.NomenFormAddGroup);
            this.Controls.Add(this.NomenFormClose);
            this.Controls.Add(this.NomenFormSaveClose);
            this.Controls.Add(this.NomenFormSave);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.NomenFormOstatok);
            this.Controls.Add(this.NomenFormUsage);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.NomenFormFullName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NomenFormOboz);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NomenForm";
            this.Text = "Форма номенклатуры – Информационная система учета и приобретения инструмента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NomenForm_FormClosing);
            this.Load += new System.EventHandler(this.NomenForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NomenFormOstatok)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NomenFormOboz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox NomenFormFullName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox NomenFormUsage;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown NomenFormOstatok;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button NomenFormSave;
        private System.Windows.Forms.Button NomenFormSaveClose;
        private System.Windows.Forms.Button NomenFormClose;
        private System.Windows.Forms.Button NomenFormAddGroup;
        private System.Windows.Forms.TextBox NomenFormNumber;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox NomenFormGroup;
        private System.Windows.Forms.TextBox NomenFormUnits;
        private System.Windows.Forms.TextBox NomenFormSize;
        private System.Windows.Forms.TextBox NomenFormMaterial;
        private System.Windows.Forms.TextBox NomenFormDocument;
        private System.Windows.Forms.TextBox NomenFormProducer;
    }
}