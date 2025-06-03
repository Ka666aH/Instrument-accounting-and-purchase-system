namespace Система_учёта_и_приобретения_инструмента
{
    partial class StorageForm
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
            this.StorageName = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.StorageNumber = new System.Windows.Forms.TextBox();
            this.WorkshopNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.StorageFormClose = new System.Windows.Forms.Button();
            this.StorageFormSaveClose = new System.Windows.Forms.Button();
            this.StorageFormSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StorageName
            // 
            this.StorageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StorageName.Location = new System.Drawing.Point(153, 59);
            this.StorageName.Name = "StorageName";
            this.StorageName.Size = new System.Drawing.Size(475, 26);
            this.StorageName.TabIndex = 40;
            this.StorageName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "Наименование *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 37;
            this.label2.Text = "Номер склада *";
            // 
            // StorageNumber
            // 
            this.StorageNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StorageNumber.Location = new System.Drawing.Point(153, 14);
            this.StorageNumber.Name = "StorageNumber";
            this.StorageNumber.Size = new System.Drawing.Size(163, 26);
            this.StorageNumber.TabIndex = 39;
            this.StorageNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.StorageNumber_KeyPress);
            // 
            // WorkshopNumber
            // 
            this.WorkshopNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopNumber.Location = new System.Drawing.Point(465, 12);
            this.WorkshopNumber.Name = "WorkshopNumber";
            this.WorkshopNumber.Size = new System.Drawing.Size(163, 26);
            this.WorkshopNumber.TabIndex = 39;
            this.WorkshopNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WorkshopNumber_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(339, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 37;
            this.label3.Text = "Номер цеха *";
            // 
            // StorageFormClose
            // 
            this.StorageFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StorageFormClose.Location = new System.Drawing.Point(525, 127);
            this.StorageFormClose.MaximumSize = new System.Drawing.Size(103, 31);
            this.StorageFormClose.MinimumSize = new System.Drawing.Size(103, 31);
            this.StorageFormClose.Name = "StorageFormClose";
            this.StorageFormClose.Size = new System.Drawing.Size(103, 31);
            this.StorageFormClose.TabIndex = 43;
            this.StorageFormClose.Text = "Закрыть";
            this.StorageFormClose.UseVisualStyleBackColor = true;
            this.StorageFormClose.Click += new System.EventHandler(this.StorageFormClose_Click);
            // 
            // StorageFormSaveClose
            // 
            this.StorageFormSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StorageFormSaveClose.Location = new System.Drawing.Point(291, 127);
            this.StorageFormSaveClose.Name = "StorageFormSaveClose";
            this.StorageFormSaveClose.Size = new System.Drawing.Size(228, 31);
            this.StorageFormSaveClose.TabIndex = 42;
            this.StorageFormSaveClose.Text = "Сохранить и закрыть";
            this.StorageFormSaveClose.UseVisualStyleBackColor = true;
            this.StorageFormSaveClose.Click += new System.EventHandler(this.StorageFormSaveClose_Click);
            // 
            // StorageFormSave
            // 
            this.StorageFormSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StorageFormSave.Location = new System.Drawing.Point(153, 127);
            this.StorageFormSave.Name = "StorageFormSave";
            this.StorageFormSave.Size = new System.Drawing.Size(132, 31);
            this.StorageFormSave.TabIndex = 41;
            this.StorageFormSave.Text = "Сохранить";
            this.StorageFormSave.UseVisualStyleBackColor = true;
            this.StorageFormSave.Click += new System.EventHandler(this.StorageFormSave_Click);
            // 
            // StorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 171);
            this.Controls.Add(this.StorageFormClose);
            this.Controls.Add(this.StorageFormSaveClose);
            this.Controls.Add(this.StorageFormSave);
            this.Controls.Add(this.StorageName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WorkshopNumber);
            this.Controls.Add(this.StorageNumber);
            this.MaximumSize = new System.Drawing.Size(655, 210);
            this.MinimumSize = new System.Drawing.Size(655, 210);
            this.Name = "StorageForm";
            this.Text = "StorageForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StorageForm_FormClosing);
            this.Load += new System.EventHandler(this.StorageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox StorageName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StorageNumber;
        private System.Windows.Forms.TextBox WorkshopNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button StorageFormClose;
        private System.Windows.Forms.Button StorageFormSaveClose;
        private System.Windows.Forms.Button StorageFormSave;
    }
}