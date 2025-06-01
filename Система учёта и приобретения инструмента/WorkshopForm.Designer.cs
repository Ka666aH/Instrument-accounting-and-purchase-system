namespace Система_учёта_и_приобретения_инструмента
{
    partial class WorkshopForm
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
            this.WorkshopName = new System.Windows.Forms.MaskedTextBox();
            this.GroupFormRangeInfo = new System.Windows.Forms.Label();
            this.WorkshopFormClose = new System.Windows.Forms.Button();
            this.WorkshopFormSaveClose = new System.Windows.Forms.Button();
            this.WorkshopFormSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.WorkshopNumber = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // WorkshopName
            // 
            this.WorkshopName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopName.Location = new System.Drawing.Point(153, 58);
            this.WorkshopName.Name = "WorkshopName";
            this.WorkshopName.Size = new System.Drawing.Size(475, 26);
            this.WorkshopName.TabIndex = 36;
            this.WorkshopName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GroupFormRangeInfo
            // 
            this.GroupFormRangeInfo.AutoSize = true;
            this.GroupFormRangeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormRangeInfo.Location = new System.Drawing.Point(153, 87);
            this.GroupFormRangeInfo.Name = "GroupFormRangeInfo";
            this.GroupFormRangeInfo.Size = new System.Drawing.Size(0, 20);
            this.GroupFormRangeInfo.TabIndex = 35;
            // 
            // WorkshopFormClose
            // 
            this.WorkshopFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopFormClose.Location = new System.Drawing.Point(525, 127);
            this.WorkshopFormClose.MaximumSize = new System.Drawing.Size(103, 31);
            this.WorkshopFormClose.MinimumSize = new System.Drawing.Size(103, 31);
            this.WorkshopFormClose.Name = "WorkshopFormClose";
            this.WorkshopFormClose.Size = new System.Drawing.Size(103, 31);
            this.WorkshopFormClose.TabIndex = 34;
            this.WorkshopFormClose.Text = "Закрыть";
            this.WorkshopFormClose.UseVisualStyleBackColor = true;
            this.WorkshopFormClose.Click += new System.EventHandler(this.WorkshopFormClose_Click);
            // 
            // WorkshopFormSaveClose
            // 
            this.WorkshopFormSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopFormSaveClose.Location = new System.Drawing.Point(291, 127);
            this.WorkshopFormSaveClose.Name = "WorkshopFormSaveClose";
            this.WorkshopFormSaveClose.Size = new System.Drawing.Size(228, 31);
            this.WorkshopFormSaveClose.TabIndex = 33;
            this.WorkshopFormSaveClose.Text = "Сохранить и закрыть";
            this.WorkshopFormSaveClose.UseVisualStyleBackColor = true;
            this.WorkshopFormSaveClose.Click += new System.EventHandler(this.WorkshopFormSaveClose_Click);
            // 
            // WorkshopFormSave
            // 
            this.WorkshopFormSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopFormSave.Location = new System.Drawing.Point(153, 127);
            this.WorkshopFormSave.Name = "WorkshopFormSave";
            this.WorkshopFormSave.Size = new System.Drawing.Size(132, 31);
            this.WorkshopFormSave.TabIndex = 32;
            this.WorkshopFormSave.Text = "Сохранить";
            this.WorkshopFormSave.UseVisualStyleBackColor = true;
            this.WorkshopFormSave.Click += new System.EventHandler(this.WorkshopFormSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(10, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 20);
            this.label1.TabIndex = 30;
            this.label1.Text = "Наименование *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Номер цеха *";
            // 
            // WorkshopNumber
            // 
            this.WorkshopNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.WorkshopNumber.Location = new System.Drawing.Point(153, 13);
            this.WorkshopNumber.Name = "WorkshopNumber";
            this.WorkshopNumber.Size = new System.Drawing.Size(475, 26);
            this.WorkshopNumber.TabIndex = 31;
            this.WorkshopNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WorkshopNumber_KeyPress);
            // 
            // WorkshopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 171);
            this.Controls.Add(this.WorkshopName);
            this.Controls.Add(this.GroupFormRangeInfo);
            this.Controls.Add(this.WorkshopFormClose);
            this.Controls.Add(this.WorkshopFormSaveClose);
            this.Controls.Add(this.WorkshopFormSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.WorkshopNumber);
            this.MaximumSize = new System.Drawing.Size(655, 210);
            this.MinimumSize = new System.Drawing.Size(655, 210);
            this.Name = "WorkshopForm";
            this.Text = "WorkshopForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkshopForm_FormClosing);
            this.Load += new System.EventHandler(this.WorkshopForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox WorkshopName;
        private System.Windows.Forms.Label GroupFormRangeInfo;
        private System.Windows.Forms.Button WorkshopFormClose;
        private System.Windows.Forms.Button WorkshopFormSaveClose;
        private System.Windows.Forms.Button WorkshopFormSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WorkshopNumber;
    }
}