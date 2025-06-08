namespace Система_учёта_и_приобретения_инструмента
{
    partial class GroupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GroupForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupFormName = new System.Windows.Forms.TextBox();
            this.GroupFormRange = new System.Windows.Forms.MaskedTextBox();
            this.GroupFormRangeInfo = new System.Windows.Forms.Label();
            this.GroupFormClose = new System.Windows.Forms.Button();
            this.GroupFormSaveClose = new System.Windows.Forms.Button();
            this.GroupFormSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Диапазон *";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Наименование *";
            // 
            // GroupFormName
            // 
            this.GroupFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormName.Location = new System.Drawing.Point(153, 18);
            this.GroupFormName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupFormName.Name = "GroupFormName";
            this.GroupFormName.Size = new System.Drawing.Size(534, 26);
            this.GroupFormName.TabIndex = 20;
            // 
            // GroupFormRange
            // 
            this.GroupFormRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormRange.Location = new System.Drawing.Point(153, 54);
            this.GroupFormRange.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GroupFormRange.Mask = "0000";
            this.GroupFormRange.Name = "GroupFormRange";
            this.GroupFormRange.Size = new System.Drawing.Size(534, 26);
            this.GroupFormRange.TabIndex = 28;
            this.GroupFormRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.GroupFormRange.TextChanged += new System.EventHandler(this.GroupFormRange_TextChanged);
            // 
            // GroupFormRangeInfo
            // 
            this.GroupFormRangeInfo.AutoSize = true;
            this.GroupFormRangeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormRangeInfo.Location = new System.Drawing.Point(232, 132);
            this.GroupFormRangeInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.GroupFormRangeInfo.Name = "GroupFormRangeInfo";
            this.GroupFormRangeInfo.Size = new System.Drawing.Size(0, 20);
            this.GroupFormRangeInfo.TabIndex = 26;
            // 
            // GroupFormClose
            // 
            this.GroupFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormClose.Location = new System.Drawing.Point(584, 129);
            this.GroupFormClose.Name = "GroupFormClose";
            this.GroupFormClose.Size = new System.Drawing.Size(103, 31);
            this.GroupFormClose.TabIndex = 31;
            this.GroupFormClose.Text = "Закрыть";
            this.GroupFormClose.UseVisualStyleBackColor = true;
            this.GroupFormClose.Click += new System.EventHandler(this.GroupFormClose_Click);
            // 
            // GroupFormSaveClose
            // 
            this.GroupFormSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormSaveClose.Location = new System.Drawing.Point(350, 129);
            this.GroupFormSaveClose.Name = "GroupFormSaveClose";
            this.GroupFormSaveClose.Size = new System.Drawing.Size(228, 31);
            this.GroupFormSaveClose.TabIndex = 30;
            this.GroupFormSaveClose.Text = "Сохранить и закрыть";
            this.GroupFormSaveClose.UseVisualStyleBackColor = true;
            this.GroupFormSaveClose.Click += new System.EventHandler(this.GroupFormSaveClose_Click);
            // 
            // GroupFormSave
            // 
            this.GroupFormSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormSave.Location = new System.Drawing.Point(212, 129);
            this.GroupFormSave.Name = "GroupFormSave";
            this.GroupFormSave.Size = new System.Drawing.Size(132, 31);
            this.GroupFormSave.TabIndex = 29;
            this.GroupFormSave.Text = "Сохранить";
            this.GroupFormSave.UseVisualStyleBackColor = true;
            this.GroupFormSave.Click += new System.EventHandler(this.GroupFormSave_Click);
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 172);
            this.Controls.Add(this.GroupFormClose);
            this.Controls.Add(this.GroupFormSaveClose);
            this.Controls.Add(this.GroupFormSave);
            this.Controls.Add(this.GroupFormRange);
            this.Controls.Add(this.GroupFormRangeInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GroupFormName);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(714, 211);
            this.MinimumSize = new System.Drawing.Size(714, 211);
            this.Name = "GroupForm";
            this.Text = "Форма группы – Информационная система учета и приобретения инструмента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GroupForm_FormClosing);
            this.Load += new System.EventHandler(this.GroupForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox GroupFormName;
        private System.Windows.Forms.MaskedTextBox GroupFormRange;
        private System.Windows.Forms.Label GroupFormRangeInfo;
        private System.Windows.Forms.Button GroupFormClose;
        private System.Windows.Forms.Button GroupFormSaveClose;
        private System.Windows.Forms.Button GroupFormSave;
    }
}