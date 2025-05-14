namespace Система_учёта_и_приобретения_инструмента
{
    partial class LoginForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.ExitLF = new System.Windows.Forms.Button();
            this.LoginLFINJ = new System.Windows.Forms.Button();
            this.UsersLF = new System.Windows.Forms.TextBox();
            this.LoginLFKLAD = new System.Windows.Forms.Button();
            this.LoginFormLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExitLF
            // 
            this.ExitLF.Location = new System.Drawing.Point(50, 400);
            this.ExitLF.Name = "ExitLF";
            this.ExitLF.Size = new System.Drawing.Size(300, 50);
            this.ExitLF.TabIndex = 2;
            this.ExitLF.Text = "Выйти";
            this.ExitLF.UseVisualStyleBackColor = true;
            this.ExitLF.Click += new System.EventHandler(this.ExitLF_Click);
            // 
            // LoginLFINJ
            // 
            this.LoginLFINJ.Location = new System.Drawing.Point(203, 344);
            this.LoginLFINJ.Name = "LoginLFINJ";
            this.LoginLFINJ.Size = new System.Drawing.Size(147, 50);
            this.LoginLFINJ.TabIndex = 1;
            this.LoginLFINJ.Text = "Инженер по инструменту отдела подготовки производства";
            this.LoginLFINJ.UseVisualStyleBackColor = true;
            this.LoginLFINJ.Click += new System.EventHandler(this.LoginLFINJ_Click);
            // 
            // UsersLF
            // 
            this.UsersLF.Location = new System.Drawing.Point(50, 318);
            this.UsersLF.Name = "UsersLF";
            this.UsersLF.ReadOnly = true;
            this.UsersLF.Size = new System.Drawing.Size(300, 20);
            this.UsersLF.TabIndex = 4;
            this.UsersLF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginLFKLAD
            // 
            this.LoginLFKLAD.Location = new System.Drawing.Point(50, 344);
            this.LoginLFKLAD.Name = "LoginLFKLAD";
            this.LoginLFKLAD.Size = new System.Drawing.Size(147, 50);
            this.LoginLFKLAD.TabIndex = 0;
            this.LoginLFKLAD.Text = "Кладовщик ЦИС, БИХ цеха";
            this.LoginLFKLAD.UseVisualStyleBackColor = true;
            this.LoginLFKLAD.Click += new System.EventHandler(this.LoginLFKLAD_Click);
            // 
            // LoginFormLable
            // 
            this.LoginFormLable.AutoSize = true;
            this.LoginFormLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginFormLable.Location = new System.Drawing.Point(60, 159);
            this.LoginFormLable.MaximumSize = new System.Drawing.Size(300, 0);
            this.LoginFormLable.Name = "LoginFormLable";
            this.LoginFormLable.Size = new System.Drawing.Size(279, 75);
            this.LoginFormLable.TabIndex = 2;
            this.LoginFormLable.Text = "Информационная система учета и приобретения инструмента";
            this.LoginFormLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(137, 281);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Войти как:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Система_учёта_и_приобретения_инструмента.Properties.Resources.DiplomLogo;
            this.pictureBox1.Location = new System.Drawing.Point(60, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(279, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginFormLable);
            this.Controls.Add(this.UsersLF);
            this.Controls.Add(this.LoginLFKLAD);
            this.Controls.Add(this.LoginLFINJ);
            this.Controls.Add(this.ExitLF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(400, 500);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информационная система учета и приобретения инструмента – Авторизация";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ExitLF;
        private System.Windows.Forms.Button LoginLFINJ;
        private System.Windows.Forms.TextBox UsersLF;
        private System.Windows.Forms.Button LoginLFKLAD;
        private System.Windows.Forms.Label LoginFormLable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

