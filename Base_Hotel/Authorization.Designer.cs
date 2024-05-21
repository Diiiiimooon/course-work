namespace Base_Hotel
{
    partial class Authorization
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
            this.auto_base = new System.Windows.Forms.Label();
            this.autoPass = new System.Windows.Forms.Label();
            this.autoLog = new System.Windows.Forms.Label();
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.auto_check = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // auto_base
            // 
            this.auto_base.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.auto_base.BackColor = System.Drawing.Color.Transparent;
            this.auto_base.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.auto_base.ForeColor = System.Drawing.Color.Gold;
            this.auto_base.Location = new System.Drawing.Point(-3, -4);
            this.auto_base.Name = "auto_base";
            this.auto_base.Size = new System.Drawing.Size(650, 90);
            this.auto_base.TabIndex = 0;
            this.auto_base.Text = "Вход в базу данных ";
            this.auto_base.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autoPass
            // 
            this.autoPass.BackColor = System.Drawing.Color.Transparent;
            this.autoPass.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autoPass.ForeColor = System.Drawing.Color.Gold;
            this.autoPass.Location = new System.Drawing.Point(196, 253);
            this.autoPass.Name = "autoPass";
            this.autoPass.Size = new System.Drawing.Size(157, 78);
            this.autoPass.TabIndex = 1;
            this.autoPass.Text = "Пароль";
            this.autoPass.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // autoLog
            // 
            this.autoLog.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.autoLog.BackColor = System.Drawing.Color.Transparent;
            this.autoLog.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.autoLog.ForeColor = System.Drawing.Color.Gold;
            this.autoLog.Location = new System.Drawing.Point(196, 171);
            this.autoLog.Name = "autoLog";
            this.autoLog.Size = new System.Drawing.Size(157, 78);
            this.autoLog.TabIndex = 2;
            this.autoLog.Text = "Логин";
            this.autoLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // login
            // 
            this.login.BackColor = System.Drawing.SystemColors.Control;
            this.login.Location = new System.Drawing.Point(320, 203);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(123, 22);
            this.login.TabIndex = 3;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(320, 281);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(123, 22);
            this.password.TabIndex = 4;
            // 
            // auto_check
            // 
            this.auto_check.BackColor = System.Drawing.Color.Transparent;
            this.auto_check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.auto_check.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.auto_check.ForeColor = System.Drawing.Color.Gold;
            this.auto_check.Image = global::Base_Hotel.Properties.Resources._2023_12_08_115327;
            this.auto_check.Location = new System.Drawing.Point(202, 354);
            this.auto_check.Name = "auto_check";
            this.auto_check.Size = new System.Drawing.Size(241, 82);
            this.auto_check.TabIndex = 5;
            this.auto_check.Text = "Выполнить авторизацию";
            this.auto_check.UseVisualStyleBackColor = false;
            this.auto_check.Click += new System.EventHandler(this.auto_check_Click);
            // 
            // info
            // 
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info.ForeColor = System.Drawing.Color.Gold;
            this.info.Location = new System.Drawing.Point(-2, 96);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(653, 55);
            this.info.TabIndex = 7;
            this.info.Text = "Для выполнения авторизации необходимо ввести действительный логин и пароль";
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.info.Visible = false;
            // 
            // exit
            // 
            this.exit.BackColor = System.Drawing.Color.Transparent;
            this.exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit.ForeColor = System.Drawing.Color.Gold;
            this.exit.Image = global::Base_Hotel.Properties.Resources._2023_12_08_115327;
            this.exit.Location = new System.Drawing.Point(202, 456);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(241, 82);
            this.exit.TabIndex = 8;
            this.exit.Text = "Выйти";
            this.exit.UseVisualStyleBackColor = false;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Authorization
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Base_Hotel.Properties.Resources._2023_12_08_115327;
            this.ClientSize = new System.Drawing.Size(649, 579);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.info);
            this.Controls.Add(this.auto_check);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.autoLog);
            this.Controls.Add(this.autoPass);
            this.Controls.Add(this.auto_base);
            this.ForeColor = System.Drawing.Color.Bisque;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Authorization";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label auto_base;
        private System.Windows.Forms.Label autoPass;
        private System.Windows.Forms.Label autoLog;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button auto_check;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Button exit;
    }
}

