using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using ClosedXML.Excel;
using Microsoft.Office.Interop.Word;
using System.IO;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Microsoft.Office.Interop.Word.Document;
using Section = Microsoft.Office.Interop.Word.Section;

namespace Base_Hotel
{
    public partial class Guests : Form
    {
        System.Data.DataTable dataForReport; // Объект с данными для отчёта
        public Guests()
        {
            InitializeComponent();
            dataForReport = Hotel.GetData("SELECT hotel_base.payment.*, hotel_base.guests.\"Surname\",\"Pasport\",\"IdNumber\" FROM hotel_base.guests, hotel_base.payment WHERE hotel_base.guests.\"Receipt\" = hotel_base.payment.\"Receipt\""); // Обновление данных
            data_guests.DataSource = Hotel.GuestsTable; // Данные в грид вью при заходе
            if (Hotel.currentUser.AcGuests == "0") // Установка в соответствии с правами пользователя
            {
                add.Enabled = false;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcGuests == "1")
            {
                add.Enabled = false;
                edit.Enabled = true;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcGuests == "2")
            {
                add.Enabled = true;
                edit.Enabled = true;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcGuests == "3")
            {
                add.Enabled = true;
                edit.Enabled = true;
                delete.Enabled = true;
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            try
            {

                NpgsqlCommand npgsqlC = new NpgsqlCommand($"INSERT INTO hotel_base.guests (\"IdGuest\",\"Surname\", \"Name\", \"Patronomyc\",\"Date\", \"City\", \"Pasport\", \"PasportDate\", \"Region\", \"IdNumber\", \"Receipt\") VALUES (@p1, @p2, @p3, @p4, @p5,@p6, @p7,@p8,@p9,@p10,@p11)", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
                npgsqlC.Parameters.AddWithValue("p2", two.Text);
                npgsqlC.Parameters.AddWithValue("p3", three.Text);
                npgsqlC.Parameters.AddWithValue("p4", four.Text);
                npgsqlC.Parameters.AddWithValue("p5", Convert.ToDateTime(five.Text));
                npgsqlC.Parameters.AddWithValue("p6", six.Text);
                npgsqlC.Parameters.AddWithValue("p7", Convert.ToInt32(seven.Text));
                npgsqlC.Parameters.AddWithValue("p8", Convert.ToDateTime(eight.Text));
                npgsqlC.Parameters.AddWithValue("p9", nine.Text);
                npgsqlC.Parameters.AddWithValue("p10", Convert.ToInt32(ten.Text));
                npgsqlC.Parameters.AddWithValue("p11", Convert.ToInt32(eleven.Text));
                npgsqlC.ExecuteNonQuery(); // Добавление записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} добавил запись в таблицу Гости в {DateTime.Now}: \"IdGuest\", \"Surname\", \"Name\", \"Patronomyc\",\"Date\", \"City\", \"Pasport\", \"PasportDate\", \"Region\", \"IdNumber\", \"Receipt\" - '{one.Text}', '{two.Text}', '{three.Text}', '{four.Text}', '{five.Text}', '{six.Text}', '{seven.Text}', '{eight.Text}', '{nine.Text}', '{ten.Text}', '{eleven.Text}'"); // Логирование)
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_guests.DataSource = Hotel.GetData("SELECT * from hotel_base.guests"); // Обновление данных в грид вью 

        }

        private void clear_Click(object sender, EventArgs e)
        {
            error.Visible = false; // Очистка текстбоксов
            Hotel.ClearF(this);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"DELETE FROM hotel_base.guests WHERE \"IdGuest\" = @p1", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
            npgsqlC.ExecuteNonQuery(); // Удаление записи
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} удалил запись в таблице Гости в {DateTime.Now}: \"IdGuest\", \"Surname\", \"Name\", \"Patronomyc\",\"Date\", \"City\", \"Pasport\", \"PasportDate\", \"Region\", \"IdNumber\", \"Receipt\" - '{one.Text}', '{two.Text}', '{three.Text}', '{four.Text}', '{five.Text}', '{six.Text}', '{seven.Text}', '{eight.Text}', '{nine.Text}', '{ten.Text}', '{eleven.Text}'"); // Логирование)
            data_guests.DataSource = Hotel.GetData("SELECT * from hotel_base.guests"); // Обновление данных в грид вью 

        }

        private void edit_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            try
            {

                NpgsqlCommand npgsqlC = new NpgsqlCommand($"UPDATE hotel_base.guests SET \"Surname\" = @p1, \"Name\" = @p2, \"Patronomyc\" = @p3, \"Date\" = @p4, \"City\" = @p5, \"Pasport\" = @p6, \"PasportDate\" = @p7, \"Region\" = @p8, \"IdNumber\" = @p9, \"Receipt\" = @p10 WHERE \"IdGuest\" = @p11", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", two.Text);
                npgsqlC.Parameters.AddWithValue("p2", three.Text);
                npgsqlC.Parameters.AddWithValue("p3", four.Text);
                npgsqlC.Parameters.AddWithValue("p4", Convert.ToDateTime(five.Text));
                npgsqlC.Parameters.AddWithValue("p5", six.Text);
                npgsqlC.Parameters.AddWithValue("p6", Convert.ToInt32(seven.Text));
                npgsqlC.Parameters.AddWithValue("p7", Convert.ToDateTime(eight.Text));
                npgsqlC.Parameters.AddWithValue("p8", nine.Text);
                npgsqlC.Parameters.AddWithValue("p9", Convert.ToInt32(ten.Text));
                npgsqlC.Parameters.AddWithValue("p10", Convert.ToInt32(eleven.Text));
                npgsqlC.Parameters.AddWithValue("p11", Convert.ToInt32(one.Text));
                npgsqlC.ExecuteNonQuery(); // Изменение записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} изменил запись в таблице Гости в {DateTime.Now}: \"Surname\", \"Name\", \"Patronomyc\",\"Date\", \"City\", \"Pasport\", \"PasportDate\", \"Region\", \"IdNumber\", \"Receipt\" - '{two.Text}', '{three.Text}', '{four.Text}', '{five.Text}', '{six.Text}', '{seven.Text}', '{eight.Text}', '{nine.Text}', '{ten.Text}', '{eleven.Text}'"); // Логирование)
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_guests.DataSource = Hotel.GetData("SELECT * from hotel_base.guests"); // Обновление данных в грид вью 
        }
        
        private void data_guests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = data_guests.Rows[e.RowIndex];
                one.Text = row.Cells["IdGuest"].Value.ToString();
                two.Text = row.Cells["Surname"].Value.ToString();
                three.Text = row.Cells["Name"].Value.ToString();
                four.Text = row.Cells["Patronomyc"].Value.ToString();
                five.Text = row.Cells["Date"].Value.ToString();
                six.Text = row.Cells["City"].Value.ToString();
                seven.Text = row.Cells["Pasport"].Value.ToString();
                eight.Text = row.Cells["PasportDate"].Value.ToString();
                nine.Text = row.Cells["Region"].Value.ToString();
                ten.Text = row.Cells["IdNumber"].Value.ToString();
                eleven.Text = row.Cells["Receipt"].Value.ToString();// Получение данных в текст боксы
            }
            catch (Exception)
            {

            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                data_guests.DataSource = Hotel.GetData($"select * from hotel_base.guests WHERE \"Receipt\" = @p1", new NpgsqlParameter("p1", Convert.ToInt32(search.Text))); 
                dataForReport = Hotel.GetData($"SELECT hotel_base.payment.*, hotel_base.guests.\"Surname\",\"Pasport\",\"IdNumber\" FROM hotel_base.guests, hotel_base.payment WHERE hotel_base.guests.\"Receipt\" = @p1 and  hotel_base.guests.\"Receipt\" = hotel_base.payment.\"Receipt\"", new NpgsqlParameter("p1", Convert.ToInt32(search.Text)));
            }
            catch (Exception)
            {

            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            data_guests.DataSource = Hotel.GuestsTable; // Обновление данных в грид вью 
            dataForReport = Hotel.GetData("SELECT hotel_base.payment.*, hotel_base.guests.\"Surname\",\"Pasport\",\"IdNumber\" FROM hotel_base.guests, hotel_base.payment WHERE hotel_base.guests.\"Receipt\" = hotel_base.payment.\"Receipt\""); // Обновление данных

        }

        private void reportExcel_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dataForReport, "Guests");
            ws.Columns().AdjustToContents();
            wb.SaveAs("reportGuests.xlsx"); // Отчёт в формате xlsx
        }

        private void reportWord_Click(object sender, EventArgs e)
        {
            string filename = "GuestsWD.docx";
            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            for (int i = 0; i < data_guests.Rows.Count; i++)
            {
                Section contract = doc.Sections.Add(Start: 0);
                Range contractIDRange = contract.Range;
                contractIDRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                contractIDRange.Font.ColorIndex = WdColorIndex.wdBlack;
                contractIDRange.Font.Size = 16;
                contractIDRange.Font.Bold = 1;
                contractIDRange.Font.Name = "Arial";
                contractIDRange.Text = $"Идентификатор {Convert.ToString(data_guests.Rows[i].Cells["IdGuest"].Value)}\n";
                Section box2 = doc.Sections.Add(Start: 0);
                Range box2Range = box2.Range;
                box2Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                box2Range.Font.ColorIndex = WdColorIndex.wdBlack;
                box2Range.Font.Size = 14;
                box2Range.Font.Bold = 0;
                box2Range.Font.Name = "Arial";
                box2Range.Text = $"Фамилия: {Convert.ToString(data_guests.Rows[i].Cells["Surname"].Value)}\nИмя: {Convert.ToString(data_guests.Rows[i].Cells["Name"].Value)}\nОтчество: {Convert.ToString(data_guests.Rows[i].Cells["Patronomyc"].Value)}\nДата рождения: {Convert.ToString(data_guests.Rows[i].Cells["Date"].Value)}\n" +
                    $"Откуда прибыл: {Convert.ToString(data_guests.Rows[i].Cells["City"].Value)}\nНомер паспорта: {Convert.ToString(data_guests.Rows[i].Cells["Pasport"].Value)}\nКогда выдан: {Convert.ToString(data_guests.Rows[i].Cells["PasportDate"].Value)}\nКем выдан: {Convert.ToString(data_guests.Rows[i].Cells["Region"].Value)}\nИдентификатор номера: { Convert.ToString(data_guests.Rows[i].Cells["IdNumber"].Value)}\n Квитанция об оплате: { Convert.ToString(data_guests.Rows[i].Cells["Receipt"].Value)}\n";
            }
            string path = Directory.GetCurrentDirectory() + @"" + filename;
            doc.SaveAs2(path);
            doc.Close();

        }
    }
}
