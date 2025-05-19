namespace Система_учёта_и_приобретения_инструмента
{
    partial class SupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupForm));
            this.SupFormClose = new System.Windows.Forms.Button();
            this.SupFormSaveClose = new System.Windows.Forms.Button();
            this.SupFormSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SupFormINN = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SupFormName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SupFormAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SupFormContacts = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SupFormNotes = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SupFormClose
            // 
            this.SupFormClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SupFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupFormClose.Location = new System.Drawing.Point(569, 264);
            this.SupFormClose.MaximumSize = new System.Drawing.Size(103, 31);
            this.SupFormClose.MinimumSize = new System.Drawing.Size(103, 31);
            this.SupFormClose.Name = "SupFormClose";
            this.SupFormClose.Size = new System.Drawing.Size(103, 31);
            this.SupFormClose.TabIndex = 8;
            this.SupFormClose.Text = "Закрыть";
            this.SupFormClose.UseVisualStyleBackColor = true;
            this.SupFormClose.Click += new System.EventHandler(this.SupFormClose_Click);
            // 
            // SupFormSaveClose
            // 
            this.SupFormSaveClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SupFormSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupFormSaveClose.Location = new System.Drawing.Point(335, 264);
            this.SupFormSaveClose.Name = "SupFormSaveClose";
            this.SupFormSaveClose.Size = new System.Drawing.Size(228, 31);
            this.SupFormSaveClose.TabIndex = 7;
            this.SupFormSaveClose.Text = "Сохранить и закрыть";
            this.SupFormSaveClose.UseVisualStyleBackColor = true;
            this.SupFormSaveClose.Click += new System.EventHandler(this.SupFormSaveClose_Click);
            // 
            // SupFormSave
            // 
            this.SupFormSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SupFormSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupFormSave.Location = new System.Drawing.Point(197, 264);
            this.SupFormSave.Name = "SupFormSave";
            this.SupFormSave.Size = new System.Drawing.Size(132, 31);
            this.SupFormSave.TabIndex = 6;
            this.SupFormSave.Text = "Сохранить";
            this.SupFormSave.UseVisualStyleBackColor = true;
            this.SupFormSave.Click += new System.EventHandler(this.SupFormSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 28;
            this.label2.Text = "ИНН *";
            // 
            // SupFormINN
            // 
            this.SupFormINN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupFormINN.Location = new System.Drawing.Point(191, 12);
            this.SupFormINN.Name = "SupFormINN";
            this.SupFormINN.Size = new System.Drawing.Size(475, 26);
            this.SupFormINN.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Наименование *";
            // 
            // SupFormName
            // 
            this.SupFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupFormName.Location = new System.Drawing.Point(191, 44);
            this.SupFormName.Name = "SupFormName";
            this.SupFormName.Size = new System.Drawing.Size(475, 26);
            this.SupFormName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(173, 20);
            this.label3.TabIndex = 38;
            this.label3.Text = "Юридический адрес *";
            // 
            // SupFormAddress
            // 
            this.SupFormAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupFormAddress.Location = new System.Drawing.Point(191, 76);
            this.SupFormAddress.Name = "SupFormAddress";
            this.SupFormAddress.Size = new System.Drawing.Size(475, 26);
            this.SupFormAddress.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 20);
            this.label4.TabIndex = 40;
            this.label4.Text = "Контакты *";
            // 
            // SupFormContacts
            // 
            this.SupFormContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupFormContacts.Location = new System.Drawing.Point(191, 108);
            this.SupFormContacts.Multiline = true;
            this.SupFormContacts.Name = "SupFormContacts";
            this.SupFormContacts.Size = new System.Drawing.Size(475, 52);
            this.SupFormContacts.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 20);
            this.label5.TabIndex = 42;
            this.label5.Text = "Примечание";
            // 
            // SupFormNotes
            // 
            this.SupFormNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupFormNotes.Location = new System.Drawing.Point(191, 166);
            this.SupFormNotes.Multiline = true;
            this.SupFormNotes.Name = "SupFormNotes";
            this.SupFormNotes.Size = new System.Drawing.Size(475, 78);
            this.SupFormNotes.TabIndex = 5;
            // 
            // SupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 309);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SupFormNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SupFormContacts);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SupFormAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SupFormName);
            this.Controls.Add(this.SupFormClose);
            this.Controls.Add(this.SupFormSaveClose);
            this.Controls.Add(this.SupFormSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SupFormINN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(695, 348);
            this.MinimumSize = new System.Drawing.Size(695, 348);
            this.Name = "SupForm";
            this.Text = "Форма поставщика – Информационная система учета и приобретения инструмента";
            this.Load += new System.EventHandler(this.SupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SupFormClose;
        private System.Windows.Forms.Button SupFormSaveClose;
        private System.Windows.Forms.Button SupFormSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox SupFormINN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SupFormName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SupFormAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SupFormContacts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SupFormNotes;
    }
}