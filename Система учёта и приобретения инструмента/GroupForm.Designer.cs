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
            this.GroupFormSpanInfo = new System.Windows.Forms.Label();
            this.GroupFormClose = new System.Windows.Forms.Button();
            this.GroupFormSaveClose = new System.Windows.Forms.Button();
            this.GroupFormSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.GroupFormSpan = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.GroupFormRange = new System.Windows.Forms.NumericUpDown();
            this.GroupFormName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.GroupFormSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupFormRange)).BeginInit();
            this.SuspendLayout();
            // 
            // GroupFormSpanInfo
            // 
            this.GroupFormSpanInfo.AutoSize = true;
            this.GroupFormSpanInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormSpanInfo.Location = new System.Drawing.Point(140, 86);
            this.GroupFormSpanInfo.Name = "GroupFormSpanInfo";
            this.GroupFormSpanInfo.Size = new System.Drawing.Size(262, 20);
            this.GroupFormSpanInfo.TabIndex = 26;
            this.GroupFormSpanInfo.Text = "Введите диапазон для проверки";
            // 
            // GroupFormClose
            // 
            this.GroupFormClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormClose.Location = new System.Drawing.Point(512, 126);
            this.GroupFormClose.MaximumSize = new System.Drawing.Size(103, 31);
            this.GroupFormClose.MinimumSize = new System.Drawing.Size(103, 31);
            this.GroupFormClose.Name = "GroupFormClose";
            this.GroupFormClose.Size = new System.Drawing.Size(103, 31);
            this.GroupFormClose.TabIndex = 25;
            this.GroupFormClose.Text = "Закрыть";
            this.GroupFormClose.UseVisualStyleBackColor = true;
            // 
            // GroupFormSaveClose
            // 
            this.GroupFormSaveClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormSaveClose.Location = new System.Drawing.Point(278, 126);
            this.GroupFormSaveClose.Name = "GroupFormSaveClose";
            this.GroupFormSaveClose.Size = new System.Drawing.Size(228, 31);
            this.GroupFormSaveClose.TabIndex = 24;
            this.GroupFormSaveClose.Text = "Сохранить и закрыть";
            this.GroupFormSaveClose.UseVisualStyleBackColor = true;
            // 
            // GroupFormSave
            // 
            this.GroupFormSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormSave.Location = new System.Drawing.Point(140, 126);
            this.GroupFormSave.Name = "GroupFormSave";
            this.GroupFormSave.Size = new System.Drawing.Size(132, 31);
            this.GroupFormSave.TabIndex = 23;
            this.GroupFormSave.Text = "Сохранить";
            this.GroupFormSave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Диапазон";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 18;
            this.label2.Text = "Наименование";
            // 
            // GroupFormSpan
            // 
            this.GroupFormSpan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormSpan.Location = new System.Drawing.Point(140, 57);
            this.GroupFormSpan.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.GroupFormSpan.Name = "GroupFormSpan";
            this.GroupFormSpan.Size = new System.Drawing.Size(475, 26);
            this.GroupFormSpan.TabIndex = 21;
            this.GroupFormSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(140, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(262, 20);
            this.label3.TabIndex = 27;
            this.label3.Text = "Введите диапазон для проверки";
            // 
            // GroupFormRange
            // 
            this.GroupFormRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormRange.Location = new System.Drawing.Point(140, 57);
            this.GroupFormRange.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.GroupFormRange.Name = "GroupFormRange";
            this.GroupFormRange.Size = new System.Drawing.Size(475, 26);
            this.GroupFormRange.TabIndex = 22;
            this.GroupFormRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // GroupFormName
            // 
            this.GroupFormName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GroupFormName.Location = new System.Drawing.Point(140, 12);
            this.GroupFormName.Name = "GroupFormName";
            this.GroupFormName.Size = new System.Drawing.Size(475, 26);
            this.GroupFormName.TabIndex = 20;
            // 
            // GroupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 171);
            this.Controls.Add(this.GroupFormSpanInfo);
            this.Controls.Add(this.GroupFormClose);
            this.Controls.Add(this.GroupFormSaveClose);
            this.Controls.Add(this.GroupFormSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GroupFormSpan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.GroupFormRange);
            this.Controls.Add(this.GroupFormName);
            this.Name = "GroupForm";
            this.Text = "Форма группы – Информационная система учета и приобретения инструмента";
            ((System.ComponentModel.ISupportInitialize)(this.GroupFormSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroupFormRange)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GroupFormSpanInfo;
        private System.Windows.Forms.Button GroupFormClose;
        private System.Windows.Forms.Button GroupFormSaveClose;
        private System.Windows.Forms.Button GroupFormSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown GroupFormSpan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown GroupFormRange;
        private System.Windows.Forms.TextBox GroupFormName;
    }
}