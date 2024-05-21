namespace Base_Hotel
{
    partial class Hotel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hotel));
            this.guests = new System.Windows.Forms.Button();
            this.users = new System.Windows.Forms.Button();
            this.timeofresidence = new System.Windows.Forms.Button();
            this.numbers = new System.Windows.Forms.Button();
            this.payment = new System.Windows.Forms.Button();
            this.closeDATA = new System.Windows.Forms.Button();
            this.welcome = new System.Windows.Forms.Label();
            this.open_list_form = new System.Windows.Forms.Button();
            this.list_form = new System.Windows.Forms.Label();
            this.back_menu = new System.Windows.Forms.Button();
            this.back_authorization = new System.Windows.Forms.Button();
            this.info_pic = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.info_pic)).BeginInit();
            this.SuspendLayout();
            // 
            // guests
            // 
            this.guests.BackColor = System.Drawing.Color.Transparent;
            this.guests.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guests.BackgroundImage")));
            this.guests.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guests.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.guests.ForeColor = System.Drawing.Color.Gold;
            this.guests.Image = ((System.Drawing.Image)(resources.GetObject("guests.Image")));
            this.guests.Location = new System.Drawing.Point(393, 81);
            this.guests.Name = "guests";
            this.guests.Size = new System.Drawing.Size(200, 65);
            this.guests.TabIndex = 0;
            this.guests.Text = "Гости";
            this.guests.UseVisualStyleBackColor = false;
            this.guests.Visible = false;
            this.guests.Click += new System.EventHandler(this.guests_Click);
            // 
            // users
            // 
            this.users.BackColor = System.Drawing.Color.Transparent;
            this.users.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("users.BackgroundImage")));
            this.users.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.users.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.users.ForeColor = System.Drawing.Color.Gold;
            this.users.Image = ((System.Drawing.Image)(resources.GetObject("users.Image")));
            this.users.Location = new System.Drawing.Point(393, 415);
            this.users.Name = "users";
            this.users.Size = new System.Drawing.Size(200, 65);
            this.users.TabIndex = 1;
            this.users.Text = "Пользователи";
            this.users.UseVisualStyleBackColor = false;
            this.users.Visible = false;
            this.users.Click += new System.EventHandler(this.users_Click);
            // 
            // timeofresidence
            // 
            this.timeofresidence.BackColor = System.Drawing.Color.Transparent;
            this.timeofresidence.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("timeofresidence.BackgroundImage")));
            this.timeofresidence.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timeofresidence.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.timeofresidence.ForeColor = System.Drawing.Color.Gold;
            this.timeofresidence.Image = ((System.Drawing.Image)(resources.GetObject("timeofresidence.Image")));
            this.timeofresidence.Location = new System.Drawing.Point(393, 331);
            this.timeofresidence.Name = "timeofresidence";
            this.timeofresidence.Size = new System.Drawing.Size(200, 65);
            this.timeofresidence.TabIndex = 2;
            this.timeofresidence.Text = "Проживание";
            this.timeofresidence.UseVisualStyleBackColor = false;
            this.timeofresidence.Visible = false;
            this.timeofresidence.Click += new System.EventHandler(this.timeofresidence_Click);
            // 
            // numbers
            // 
            this.numbers.BackColor = System.Drawing.Color.Transparent;
            this.numbers.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("numbers.BackgroundImage")));
            this.numbers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.numbers.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.numbers.ForeColor = System.Drawing.Color.Gold;
            this.numbers.Image = ((System.Drawing.Image)(resources.GetObject("numbers.Image")));
            this.numbers.Location = new System.Drawing.Point(393, 165);
            this.numbers.Name = "numbers";
            this.numbers.Size = new System.Drawing.Size(200, 65);
            this.numbers.TabIndex = 3;
            this.numbers.Text = "Гостиничные номера";
            this.numbers.UseVisualStyleBackColor = false;
            this.numbers.Visible = false;
            this.numbers.Click += new System.EventHandler(this.numbers_Click);
            // 
            // payment
            // 
            this.payment.BackColor = System.Drawing.Color.Transparent;
            this.payment.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("payment.BackgroundImage")));
            this.payment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.payment.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.payment.ForeColor = System.Drawing.Color.Gold;
            this.payment.Image = ((System.Drawing.Image)(resources.GetObject("payment.Image")));
            this.payment.Location = new System.Drawing.Point(393, 248);
            this.payment.Name = "payment";
            this.payment.Size = new System.Drawing.Size(200, 65);
            this.payment.TabIndex = 4;
            this.payment.Text = "Оплата";
            this.payment.UseVisualStyleBackColor = false;
            this.payment.Visible = false;
            this.payment.Click += new System.EventHandler(this.payment_Click);
            // 
            // closeDATA
            // 
            this.closeDATA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeDATA.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeDATA.ForeColor = System.Drawing.Color.Gold;
            this.closeDATA.Image = ((System.Drawing.Image)(resources.GetObject("closeDATA.Image")));
            this.closeDATA.Location = new System.Drawing.Point(625, 231);
            this.closeDATA.Name = "closeDATA";
            this.closeDATA.Size = new System.Drawing.Size(215, 120);
            this.closeDATA.TabIndex = 5;
            this.closeDATA.Text = "Закрытие\r\nбазы данных";
            this.closeDATA.UseVisualStyleBackColor = true;
            this.closeDATA.Click += new System.EventHandler(this.closeDATA_Click);
            // 
            // welcome
            // 
            this.welcome.BackColor = System.Drawing.Color.Transparent;
            this.welcome.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome.ForeColor = System.Drawing.Color.Gold;
            this.welcome.Location = new System.Drawing.Point(-1, 1);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(986, 62);
            this.welcome.TabIndex = 6;
            this.welcome.Text = "ДОБРО ПОЖАЛОВАТЬ ";
            this.welcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // open_list_form
            // 
            this.open_list_form.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.open_list_form.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.open_list_form.ForeColor = System.Drawing.Color.Gold;
            this.open_list_form.Image = ((System.Drawing.Image)(resources.GetObject("open_list_form.Image")));
            this.open_list_form.Location = new System.Drawing.Point(145, 231);
            this.open_list_form.Name = "open_list_form";
            this.open_list_form.Size = new System.Drawing.Size(215, 120);
            this.open_list_form.TabIndex = 7;
            this.open_list_form.Text = "Список форм";
            this.open_list_form.UseVisualStyleBackColor = true;
            this.open_list_form.Click += new System.EventHandler(this.open_list_form_Click);
            // 
            // list_form
            // 
            this.list_form.BackColor = System.Drawing.Color.Transparent;
            this.list_form.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_form.ForeColor = System.Drawing.Color.Gold;
            this.list_form.Location = new System.Drawing.Point(2, 15);
            this.list_form.Name = "list_form";
            this.list_form.Size = new System.Drawing.Size(983, 62);
            this.list_form.TabIndex = 8;
            this.list_form.Text = "СПИСОК ФОРМ";
            this.list_form.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.list_form.Visible = false;
            // 
            // back_menu
            // 
            this.back_menu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_menu.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.back_menu.ForeColor = System.Drawing.Color.Gold;
            this.back_menu.Image = ((System.Drawing.Image)(resources.GetObject("back_menu.Image")));
            this.back_menu.Location = new System.Drawing.Point(739, 434);
            this.back_menu.Name = "back_menu";
            this.back_menu.Size = new System.Drawing.Size(235, 109);
            this.back_menu.TabIndex = 9;
            this.back_menu.Text = "Возвращение в приветственное окно";
            this.back_menu.UseVisualStyleBackColor = true;
            this.back_menu.Visible = false;
            this.back_menu.Click += new System.EventHandler(this.back_menu_Click);
            // 
            // back_authorization
            // 
            this.back_authorization.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.back_authorization.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.back_authorization.ForeColor = System.Drawing.Color.Gold;
            this.back_authorization.Image = ((System.Drawing.Image)(resources.GetObject("back_authorization.Image")));
            this.back_authorization.Location = new System.Drawing.Point(386, 231);
            this.back_authorization.Name = "back_authorization";
            this.back_authorization.Size = new System.Drawing.Size(215, 120);
            this.back_authorization.TabIndex = 10;
            this.back_authorization.Text = "Вернуться\r\nк\r\nавторизации";
            this.back_authorization.UseVisualStyleBackColor = true;
            this.back_authorization.Click += new System.EventHandler(this.back_authorization_Click);
            // 
            // info_pic
            // 
            this.info_pic.BackColor = System.Drawing.Color.Transparent;
            this.info_pic.BackgroundImage = global::Base_Hotel.Properties.Resources._1;
            this.info_pic.InitialImage = null;
            this.info_pic.Location = new System.Drawing.Point(450, 377);
            this.info_pic.Name = "info_pic";
            this.info_pic.Size = new System.Drawing.Size(105, 95);
            this.info_pic.TabIndex = 11;
            this.info_pic.TabStop = false;
            this.info_pic.Click += new System.EventHandler(this.info_pic_Click);
            // 
            // Hotel
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackgroundImage = global::Base_Hotel.Properties.Resources._2023_12_08_115327;
            this.ClientSize = new System.Drawing.Size(986, 568);
            this.Controls.Add(this.info_pic);
            this.Controls.Add(this.back_authorization);
            this.Controls.Add(this.back_menu);
            this.Controls.Add(this.list_form);
            this.Controls.Add(this.open_list_form);
            this.Controls.Add(this.welcome);
            this.Controls.Add(this.closeDATA);
            this.Controls.Add(this.payment);
            this.Controls.Add(this.numbers);
            this.Controls.Add(this.timeofresidence);
            this.Controls.Add(this.users);
            this.Controls.Add(this.guests);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Hotel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hotel";
            this.Load += new System.EventHandler(this.Hotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.info_pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button guests;
        private System.Windows.Forms.Button users;
        private System.Windows.Forms.Button timeofresidence;
        private System.Windows.Forms.Button numbers;
        private System.Windows.Forms.Button payment;
        private System.Windows.Forms.Button closeDATA;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.Button open_list_form;
        private System.Windows.Forms.Label list_form;
        private System.Windows.Forms.Button back_menu;
        private System.Windows.Forms.Button back_authorization;
        private System.Windows.Forms.PictureBox info_pic;
    }
}