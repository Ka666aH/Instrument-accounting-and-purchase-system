namespace Система_учёта_и_приобретения_инструмента
{
    partial class ImportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ImportFormFilePath = new System.Windows.Forms.TextBox();
            this.ImportFormSelectFileButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ImportFormSheet = new System.Windows.Forms.ComboBox();
            this.ImportFormTable = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ImportFormCloseButton = new System.Windows.Forms.Button();
            this.ImportFormImportButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Из файла";
            // 
            // ImportFormFilePath
            // 
            this.ImportFormFilePath.Location = new System.Drawing.Point(112, 8);
            this.ImportFormFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImportFormFilePath.Name = "ImportFormFilePath";
            this.ImportFormFilePath.ReadOnly = true;
            this.ImportFormFilePath.Size = new System.Drawing.Size(456, 26);
            this.ImportFormFilePath.TabIndex = 2;
            this.ImportFormFilePath.TextChanged += new System.EventHandler(this.ImportFormFilePath_TextChanged);
            // 
            // ImportFormSelectFileButton
            // 
            this.ImportFormSelectFileButton.Location = new System.Drawing.Point(579, 5);
            this.ImportFormSelectFileButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImportFormSelectFileButton.Name = "ImportFormSelectFileButton";
            this.ImportFormSelectFileButton.Size = new System.Drawing.Size(166, 35);
            this.ImportFormSelectFileButton.TabIndex = 1;
            this.ImportFormSelectFileButton.Text = "Выбрать файл";
            this.ImportFormSelectFileButton.UseVisualStyleBackColor = true;
            this.ImportFormSelectFileButton.Click += new System.EventHandler(this.ImportFormSelectFileButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "С листа";
            // 
            // ImportFormSheet
            // 
            this.ImportFormSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImportFormSheet.Enabled = false;
            this.ImportFormSheet.FormattingEnabled = true;
            this.ImportFormSheet.Location = new System.Drawing.Point(112, 48);
            this.ImportFormSheet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImportFormSheet.Name = "ImportFormSheet";
            this.ImportFormSheet.Size = new System.Drawing.Size(456, 28);
            this.ImportFormSheet.TabIndex = 3;
            this.ImportFormSheet.SelectedIndexChanged += new System.EventHandler(this.ImportFormSheet_SelectedIndexChanged);
            // 
            // ImportFormTable
            // 
            this.ImportFormTable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ImportFormTable.FormattingEnabled = true;
            this.ImportFormTable.Location = new System.Drawing.Point(112, 89);
            this.ImportFormTable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImportFormTable.Name = "ImportFormTable";
            this.ImportFormTable.Size = new System.Drawing.Size(456, 28);
            this.ImportFormTable.TabIndex = 4;
            this.ImportFormTable.SelectedIndexChanged += new System.EventHandler(this.ImportFormTable_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 95);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "В таблицу";
            // 
            // ImportFormCloseButton
            // 
            this.ImportFormCloseButton.Location = new System.Drawing.Point(579, 149);
            this.ImportFormCloseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImportFormCloseButton.Name = "ImportFormCloseButton";
            this.ImportFormCloseButton.Size = new System.Drawing.Size(166, 35);
            this.ImportFormCloseButton.TabIndex = 6;
            this.ImportFormCloseButton.Text = "Закрыть";
            this.ImportFormCloseButton.UseVisualStyleBackColor = true;
            this.ImportFormCloseButton.Click += new System.EventHandler(this.ImportFormClose_Click);
            // 
            // ImportFormImportButton
            // 
            this.ImportFormImportButton.Enabled = false;
            this.ImportFormImportButton.Location = new System.Drawing.Point(306, 151);
            this.ImportFormImportButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImportFormImportButton.Name = "ImportFormImportButton";
            this.ImportFormImportButton.Size = new System.Drawing.Size(264, 35);
            this.ImportFormImportButton.TabIndex = 5;
            this.ImportFormImportButton.Text = "Импортировать";
            this.ImportFormImportButton.UseVisualStyleBackColor = true;
            this.ImportFormImportButton.Click += new System.EventHandler(this.ImportFormImport_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 203);
            this.Controls.Add(this.ImportFormImportButton);
            this.Controls.Add(this.ImportFormCloseButton);
            this.Controls.Add(this.ImportFormTable);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ImportFormSheet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ImportFormSelectFileButton);
            this.Controls.Add(this.ImportFormFilePath);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(772, 242);
            this.MinimumSize = new System.Drawing.Size(772, 242);
            this.Name = "ImportForm";
            this.Text = "Импорт – Информационная система учета и приобретения инструмента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ImportForm_FormClosing);
            this.Load += new System.EventHandler(this.ImportForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ImportFormFilePath;
        private System.Windows.Forms.Button ImportFormSelectFileButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ImportFormSheet;
        private System.Windows.Forms.ComboBox ImportFormTable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ImportFormCloseButton;
        private System.Windows.Forms.Button ImportFormImportButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}