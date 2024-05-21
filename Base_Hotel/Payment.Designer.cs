namespace Base_Hotel
{
    partial class Payment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payment));
            this.chCash = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.one = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.helper = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.Label();
            this.four = new System.Windows.Forms.TextBox();
            this.two = new System.Windows.Forms.TextBox();
            this.delete = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.clear = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.data_payment = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.search2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.reset = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.search1 = new System.Windows.Forms.TextBox();
            this.reportWord = new System.Windows.Forms.Button();
            this.reportExcel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_payment)).BeginInit();
            this.SuspendLayout();
            // 
            // chCash
            // 
            this.chCash.AutoSize = true;
            this.chCash.Location = new System.Drawing.Point(841, 141);
            this.chCash.Margin = new System.Windows.Forms.Padding(4);
            this.chCash.Name = "chCash";
            this.chCash.Size = new System.Drawing.Size(18, 17);
            this.chCash.TabIndex = 309;
            this.chCash.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Gold;
            this.label12.Location = new System.Drawing.Point(567, 62);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(242, 26);
            this.label12.TabIndex = 308;
            this.label12.Text = "Квитанция об оплате";
            // 
            // one
            // 
            this.one.Location = new System.Drawing.Point(841, 62);
            this.one.Margin = new System.Windows.Forms.Padding(4);
            this.one.Name = "one";
            this.one.Size = new System.Drawing.Size(215, 22);
            this.one.TabIndex = 307;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.Gold;
            this.label7.Location = new System.Drawing.Point(596, 237);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(433, 35);
            this.label7.TabIndex = 299;
            this.label7.Text = "Действия с данными об оплате\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(567, 177);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 26);
            this.label2.TabIndex = 297;
            this.label2.Text = "Администратор";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Gold;
            this.label3.Location = new System.Drawing.Point(567, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 26);
            this.label3.TabIndex = 295;
            this.label3.Text = "Сумма к оплате";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Gold;
            this.label4.Location = new System.Drawing.Point(567, 137);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(221, 26);
            this.label4.TabIndex = 296;
            this.label4.Text = "Наличный расчет?";
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.info.ForeColor = System.Drawing.Color.Gold;
            this.info.Location = new System.Drawing.Point(684, 9);
            this.info.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(257, 35);
            this.info.TabIndex = 289;
            this.info.Text = "Данные об оплате";
            // 
            // helper
            // 
            this.helper.AutoSize = true;
            this.helper.BackColor = System.Drawing.Color.Transparent;
            this.helper.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helper.ForeColor = System.Drawing.Color.Gold;
            this.helper.Location = new System.Drawing.Point(669, 445);
            this.helper.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.helper.Name = "helper";
            this.helper.Size = new System.Drawing.Size(308, 44);
            this.helper.TabIndex = 288;
            this.helper.Text = "Для удаления и изменения записи\r\nдостаточно ввести идентификатор ";
            this.helper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // error
            // 
            this.error.AutoSize = true;
            this.error.BackColor = System.Drawing.Color.Transparent;
            this.error.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.error.ForeColor = System.Drawing.Color.Gold;
            this.error.Location = new System.Drawing.Point(690, 489);
            this.error.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.error.Name = "error";
            this.error.Size = new System.Drawing.Size(255, 52);
            this.error.TabIndex = 284;
            this.error.Text = "Некорректно введены\r\nданные";
            this.error.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.error.Visible = false;
            // 
            // four
            // 
            this.four.Location = new System.Drawing.Point(841, 177);
            this.four.Margin = new System.Windows.Forms.Padding(4);
            this.four.Name = "four";
            this.four.Size = new System.Drawing.Size(215, 22);
            this.four.TabIndex = 281;
            // 
            // two
            // 
            this.two.Location = new System.Drawing.Point(841, 97);
            this.two.Margin = new System.Windows.Forms.Padding(4);
            this.two.Name = "two";
            this.two.Size = new System.Drawing.Size(215, 22);
            this.two.TabIndex = 279;
            // 
            // delete
            // 
            this.delete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("delete.BackgroundImage")));
            this.delete.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.delete.ForeColor = System.Drawing.Color.Gold;
            this.delete.Location = new System.Drawing.Point(636, 366);
            this.delete.Margin = new System.Windows.Forms.Padding(4);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(175, 75);
            this.delete.TabIndex = 287;
            this.delete.Text = "Удалить";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // edit
            // 
            this.edit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("edit.BackgroundImage")));
            this.edit.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.edit.ForeColor = System.Drawing.Color.Gold;
            this.edit.Location = new System.Drawing.Point(818, 366);
            this.edit.Margin = new System.Windows.Forms.Padding(4);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(175, 75);
            this.edit.TabIndex = 286;
            this.edit.Text = "Изменить";
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // clear
            // 
            this.clear.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.clear.ForeColor = System.Drawing.Color.Gold;
            this.clear.Image = ((System.Drawing.Image)(resources.GetObject("clear.Image")));
            this.clear.Location = new System.Drawing.Point(636, 286);
            this.clear.Margin = new System.Windows.Forms.Padding(4);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(175, 75);
            this.clear.TabIndex = 285;
            this.clear.Text = "Очистить данные ввода";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // add
            // 
            this.add.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("add.BackgroundImage")));
            this.add.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.add.ForeColor = System.Drawing.Color.Gold;
            this.add.Location = new System.Drawing.Point(818, 286);
            this.add.Margin = new System.Windows.Forms.Padding(4);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(175, 75);
            this.add.TabIndex = 283;
            this.add.Text = "Добавить";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // data_payment
            // 
            this.data_payment.AllowUserToAddRows = false;
            this.data_payment.AllowUserToDeleteRows = false;
            this.data_payment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_payment.Location = new System.Drawing.Point(2, 2);
            this.data_payment.Name = "data_payment";
            this.data_payment.RowHeadersWidth = 51;
            this.data_payment.RowTemplate.Height = 24;
            this.data_payment.Size = new System.Drawing.Size(558, 737);
            this.data_payment.TabIndex = 310;
            this.data_payment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.data_payment_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(816, 598);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 26);
            this.label1.TabIndex = 316;
            this.label1.Text = "-";
            // 
            // search2
            // 
            this.search2.Location = new System.Drawing.Point(852, 603);
            this.search2.Margin = new System.Windows.Forms.Padding(4);
            this.search2.Name = "search2";
            this.search2.Size = new System.Drawing.Size(96, 22);
            this.search2.TabIndex = 315;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(632, 559);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(396, 26);
            this.label5.TabIndex = 314;
            this.label5.Text = "Поиск суммы к оплате в диапазоне";
            // 
            // reset
            // 
            this.reset.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reset.BackgroundImage")));
            this.reset.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.reset.ForeColor = System.Drawing.Color.Gold;
            this.reset.Location = new System.Drawing.Point(841, 635);
            this.reset.Margin = new System.Windows.Forms.Padding(4);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(175, 75);
            this.reset.TabIndex = 313;
            this.reset.Text = "Сбросить";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // searchButton
            // 
            this.searchButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("searchButton.BackgroundImage")));
            this.searchButton.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            this.searchButton.ForeColor = System.Drawing.Color.Gold;
            this.searchButton.Location = new System.Drawing.Point(637, 635);
            this.searchButton.Margin = new System.Windows.Forms.Padding(4);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(175, 75);
            this.searchButton.TabIndex = 312;
            this.searchButton.Text = "Найти";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // search1
            // 
            this.search1.Location = new System.Drawing.Point(701, 603);
            this.search1.Margin = new System.Windows.Forms.Padding(4);
            this.search1.Name = "search1";
            this.search1.Size = new System.Drawing.Size(96, 22);
            this.search1.TabIndex = 311;
            // 
            // reportWord
            // 
            this.reportWord.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reportWord.BackgroundImage")));
            this.reportWord.ForeColor = System.Drawing.Color.Gold;
            this.reportWord.Location = new System.Drawing.Point(1099, 155);
            this.reportWord.Margin = new System.Windows.Forms.Padding(4);
            this.reportWord.Name = "reportWord";
            this.reportWord.Size = new System.Drawing.Size(175, 75);
            this.reportWord.TabIndex = 350;
            this.reportWord.Text = "Отчёт по записям в таблице в Word";
            this.reportWord.UseVisualStyleBackColor = true;
            this.reportWord.Click += new System.EventHandler(this.reportWord_Click);
            // 
            // reportExcel
            // 
            this.reportExcel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reportExcel.BackgroundImage")));
            this.reportExcel.ForeColor = System.Drawing.Color.Gold;
            this.reportExcel.Location = new System.Drawing.Point(1099, 62);
            this.reportExcel.Margin = new System.Windows.Forms.Padding(4);
            this.reportExcel.Name = "reportExcel";
            this.reportExcel.Size = new System.Drawing.Size(175, 75);
            this.reportExcel.TabIndex = 349;
            this.reportExcel.Text = "Отчёт по записям в таблице в Excel";
            this.reportExcel.UseVisualStyleBackColor = true;
            this.reportExcel.Click += new System.EventHandler(this.reportExcel_Click);
            // 
            // Payment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Base_Hotel.Properties.Resources._2023_12_08_115327;
            this.ClientSize = new System.Drawing.Size(1287, 740);
            this.Controls.Add(this.reportWord);
            this.Controls.Add(this.reportExcel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.search2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.search1);
            this.Controls.Add(this.data_payment);
            this.Controls.Add(this.chCash);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.one);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.info);
            this.Controls.Add(this.helper);
            this.Controls.Add(this.delete);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.error);
            this.Controls.Add(this.add);
            this.Controls.Add(this.four);
            this.Controls.Add(this.two);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Payment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)(this.data_payment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chCash;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox one;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.Label helper;
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Label error;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox four;
        private System.Windows.Forms.TextBox two;
        private System.Windows.Forms.DataGridView data_payment;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox search2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button reset;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.TextBox search1;
        private System.Windows.Forms.Button reportWord;
        private System.Windows.Forms.Button reportExcel;
    }
}