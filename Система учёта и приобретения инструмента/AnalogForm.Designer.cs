namespace Система_учёта_и_приобретения_инструмента
{
    partial class AnalogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalogForm));
            this.AnalogFormClose = new System.Windows.Forms.Button();
            this.AnalogFormSaveClose = new System.Windows.Forms.Button();
            this.AnalogFormSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AnalogFormOrigiinalName = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AnalogFormOrigiinalNumber = new System.Windows.Forms.MaskedTextBox();
            this.AnalogFormAnalogNumber = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AnalogFormAnalogName = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // AnalogFormClose
            // 
            this.AnalogFormClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalogFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnalogFormClose.Location = new System.Drawing.Point(581, 277);
            this.AnalogFormClose.MaximumSize = new System.Drawing.Size(103, 31);
            this.AnalogFormClose.MinimumSize = new System.Drawing.Size(103, 31);
            this.AnalogFormClose.Name = "AnalogFormClose";
            this.AnalogFormClose.Size = new System.Drawing.Size(103, 31);
            this.AnalogFormClose.TabIndex = 7;
            this.AnalogFormClose.Text = "Закрыть";
            this.AnalogFormClose.UseVisualStyleBackColor = true;
            this.AnalogFormClose.Click += new System.EventHandler(this.AnalogFormClose_Click);
            // 
            // AnalogFormSaveClose
            // 
            this.AnalogFormSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalogFormSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnalogFormSaveClose.Location = new System.Drawing.Point(347, 277);
            this.AnalogFormSaveClose.Name = "AnalogFormSaveClose";
            this.AnalogFormSaveClose.Size = new System.Drawing.Size(228, 31);
            this.AnalogFormSaveClose.TabIndex = 6;
            this.AnalogFormSaveClose.Text = "Сохранить и закрыть";
            this.AnalogFormSaveClose.UseVisualStyleBackColor = true;
            this.AnalogFormSaveClose.Click += new System.EventHandler(this.AnalogFormSaveClose_Click);
            // 
            // AnalogFormSave
            // 
            this.AnalogFormSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AnalogFormSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AnalogFormSave.Location = new System.Drawing.Point(209, 277);
            this.AnalogFormSave.Name = "AnalogFormSave";
            this.AnalogFormSave.Size = new System.Drawing.Size(132, 31);
            this.AnalogFormSave.TabIndex = 5;
            this.AnalogFormSave.Text = "Сохранить";
            this.AnalogFormSave.UseVisualStyleBackColor = true;
            this.AnalogFormSave.Click += new System.EventHandler(this.AnalogFormSave_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(325, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Основной инструмент *";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(316, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Аналоговый инструмент *";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Полное наименование";
            // 
            // AnalogFormOrigiinalName
            // 
            this.AnalogFormOrigiinalName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AnalogFormOrigiinalName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.AnalogFormOrigiinalName.FormattingEnabled = true;
            this.AnalogFormOrigiinalName.Location = new System.Drawing.Point(210, 41);
            this.AnalogFormOrigiinalName.Name = "AnalogFormOrigiinalName";
            this.AnalogFormOrigiinalName.Size = new System.Drawing.Size(471, 28);
            this.AnalogFormOrigiinalName.TabIndex = 1;
            this.AnalogFormOrigiinalName.Leave += new System.EventHandler(this.AnalogFormOrigiinalName_Leave);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(191, 20);
            this.label4.TabIndex = 39;
            this.label4.Text = "Номенклатурный номер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(400, 72);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "или";
            // 
            // AnalogFormOrigiinalNumber
            // 
            this.AnalogFormOrigiinalNumber.Enabled = false;
            this.AnalogFormOrigiinalNumber.Location = new System.Drawing.Point(210, 95);
            this.AnalogFormOrigiinalNumber.Mask = "000000000";
            this.AnalogFormOrigiinalNumber.Name = "AnalogFormOrigiinalNumber";
            this.AnalogFormOrigiinalNumber.Size = new System.Drawing.Size(471, 26);
            this.AnalogFormOrigiinalNumber.TabIndex = 3;
            this.AnalogFormOrigiinalNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AnalogFormOrigiinalNumber.TextChanged += new System.EventHandler(this.AnalogFormOrigiinalNumber_TextChanged);
            // 
            // AnalogFormAnalogNumber
            // 
            this.AnalogFormAnalogNumber.Enabled = false;
            this.AnalogFormAnalogNumber.Location = new System.Drawing.Point(210, 234);
            this.AnalogFormAnalogNumber.Mask = "000000000";
            this.AnalogFormAnalogNumber.Name = "AnalogFormAnalogNumber";
            this.AnalogFormAnalogNumber.Size = new System.Drawing.Size(471, 26);
            this.AnalogFormAnalogNumber.TabIndex = 4;
            this.AnalogFormAnalogNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AnalogFormAnalogNumber.TextChanged += new System.EventHandler(this.AnalogFormAnalogNumber_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(400, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "или";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "Номенклатурный номер";
            // 
            // AnalogFormAnalogName
            // 
            this.AnalogFormAnalogName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.AnalogFormAnalogName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.AnalogFormAnalogName.FormattingEnabled = true;
            this.AnalogFormAnalogName.Location = new System.Drawing.Point(210, 180);
            this.AnalogFormAnalogName.Name = "AnalogFormAnalogName";
            this.AnalogFormAnalogName.Size = new System.Drawing.Size(471, 28);
            this.AnalogFormAnalogName.TabIndex = 2;
            this.AnalogFormAnalogName.Leave += new System.EventHandler(this.AnalogFormAnalogName_Leave);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(181, 20);
            this.label8.TabIndex = 44;
            this.label8.Text = "Полное наименование";
            // 
            // AnalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 331);
            this.Controls.Add(this.AnalogFormAnalogNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AnalogFormAnalogName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AnalogFormOrigiinalNumber);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AnalogFormOrigiinalName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AnalogFormClose);
            this.Controls.Add(this.AnalogFormSaveClose);
            this.Controls.Add(this.AnalogFormSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(709, 370);
            this.MinimumSize = new System.Drawing.Size(709, 370);
            this.Name = "AnalogForm";
            this.Text = "Форма аналога – Информационная система учета и приобретения инструмента";
            this.Load += new System.EventHandler(this.AnalogForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button AnalogFormClose;
        private System.Windows.Forms.Button AnalogFormSaveClose;
        private System.Windows.Forms.Button AnalogFormSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox AnalogFormOrigiinalName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox AnalogFormOrigiinalNumber;
        private System.Windows.Forms.MaskedTextBox AnalogFormAnalogNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox AnalogFormAnalogName;
        private System.Windows.Forms.Label label8;
    }
}