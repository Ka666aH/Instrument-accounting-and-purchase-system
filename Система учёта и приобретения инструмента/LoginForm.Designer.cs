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
            this.ExitLF = new System.Windows.Forms.Button();
            this.LoginLFINJ = new System.Windows.Forms.Button();
            this.UsersLF = new System.Windows.Forms.TextBox();
            this.LoginLFKLAD = new System.Windows.Forms.Button();
            this.LoginFormLable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExitLF
            // 
            this.ExitLF.Location = new System.Drawing.Point(52, 273);
            this.ExitLF.Name = "ExitLF";
            this.ExitLF.Size = new System.Drawing.Size(289, 47);
            this.ExitLF.TabIndex = 0;
            this.ExitLF.Text = "Выйти";
            this.ExitLF.UseVisualStyleBackColor = true;
            this.ExitLF.Click += new System.EventHandler(this.ExitLF_Click);
            // 
            // LoginLFINJ
            // 
            this.LoginLFINJ.Location = new System.Drawing.Point(205, 220);
            this.LoginLFINJ.Name = "LoginLFINJ";
            this.LoginLFINJ.Size = new System.Drawing.Size(136, 47);
            this.LoginLFINJ.TabIndex = 0;
            this.LoginLFINJ.Text = "Инженер по инструменту";
            this.LoginLFINJ.UseVisualStyleBackColor = true;
            // 
            // UsersLF
            // 
            this.UsersLF.Location = new System.Drawing.Point(52, 194);
            this.UsersLF.Name = "UsersLF";
            this.UsersLF.ReadOnly = true;
            this.UsersLF.Size = new System.Drawing.Size(289, 20);
            this.UsersLF.TabIndex = 1;
            this.UsersLF.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LoginLFKLAD
            // 
            this.LoginLFKLAD.Location = new System.Drawing.Point(52, 220);
            this.LoginLFKLAD.Name = "LoginLFKLAD";
            this.LoginLFKLAD.Size = new System.Drawing.Size(147, 47);
            this.LoginLFKLAD.TabIndex = 0;
            this.LoginLFKLAD.Text = "Кладовщик ЦИС, БИХ цеха";
            this.LoginLFKLAD.UseVisualStyleBackColor = true;
            this.LoginLFKLAD.Click += new System.EventHandler(this.LoginLFKLAD_Click);
            // 
            // LoginFormLable
            // 
            this.LoginFormLable.AutoSize = true;
            this.LoginFormLable.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginFormLable.Location = new System.Drawing.Point(58, 8);
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
            this.label1.Location = new System.Drawing.Point(139, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Войти как:";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 348);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginFormLable);
            this.Controls.Add(this.UsersLF);
            this.Controls.Add(this.LoginLFKLAD);
            this.Controls.Add(this.LoginLFINJ);
            this.Controls.Add(this.ExitLF);
            this.MaximumSize = new System.Drawing.Size(404, 387);
            this.MinimumSize = new System.Drawing.Size(404, 387);
            this.Name = "LoginForm";
            this.Text = "Авторизация Информационная система учета и приобретения инструмента";
            this.Load += new System.EventHandler(this.LoginForm_Load);
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
    }
}

