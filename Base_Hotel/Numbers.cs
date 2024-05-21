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
    public partial class Numbers : Form
    {
        public Numbers()
        {
            InitializeComponent();
            dataForReport = Hotel.GetData("SELECT * from hotel_base.numbers"); // Обновление данных
            data_numbers.DataSource = Hotel.NumbersTable; // Данные в грид вью при заходе
            if (Hotel.currentUser.AcUsers == "0") // Установка в соответствии с правами пользователя
            {
                add.Enabled = false;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcUsers == "1")
            {
                add.Enabled = false;
                edit.Enabled = true;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcUsers == "2")
            {
                add.Enabled = true;
                edit.Enabled = true;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcUsers == "3")
            {
                add.Enabled = true;
                edit.Enabled = true;
                delete.Enabled = true;
            }

        }
        System.Data.DataTable dataForReport; // Объект с данными для отчёта



        private void clear_Click(object sender, EventArgs e)
        {

            error.Visible = false; // Очистка текстбоксов
            Hotel.ClearF(this);
        }

        private void delete_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"DELETE FROM hotel_base.numbers WHERE \"IdNumber\" = @p1", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
            npgsqlC.ExecuteNonQuery(); // Удаление записи
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} удалил запись из таблицы Гостиничные номера в {DateTime.Now}: \"IdNumber\", \"Category\", \"CountRoom\", \"Floor\",\"CountPlaces\", \"TV\", \"Fridge\", \"Balcony\", \"Reservation\", \"Record\" - '{one.Text}', '{two.Text}', '{three.Text}', '{four.Text}', '{five.Text}','{chTV.Checked}', '{chFridge.Checked}', '{chBalcony.Checked}', '{ten.Text}', '{eleven.Text}'"); // Логирование)
            data_numbers.DataSource = Hotel.GetData("SELECT * from hotel_base.numbers"); // Обновление данных в грид вью
        }

        private void edit_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            try
            {
                NpgsqlCommand npgsqlC = new NpgsqlCommand();
                npgsqlC.Connection = Hotel.npgsql;
                string com1 = $"UPDATE hotel_base.numbers SET \"Category\" = @p2, \"CountRoom\" = @p3, \"Floor\" = @p4, \"CountPlaces\" = @p5, " +
                    $"\"TV\" = '{chTV.Checked}', \"Fridge\" = '{chFridge.Checked}', \"Balcony\" = '{chBalcony.Checked}', \"Photo\" = pg_read_binary_file(@p8), \"Reservation\" = @p6, \"Record\" = @p7 WHERE \"IdNumber\" = @p1";
                string com2 = $"UPDATE hotel_base.numbers SET \"Category\" = @p2, \"CountRoom\" = @p3, \"Floor\" = @p4, \"CountPlaces\" = @p5, " +
                    $"\"TV\" = '{chTV.Checked}', \"Fridge\" = '{chFridge.Checked}', \"Balcony\" = '{chBalcony.Checked}', \"Reservation\" = @p6, \"Record\" = @p7 WHERE \"IdNumber\" = @p1";
                if (path.Text != "")
                {
                    npgsqlC.CommandText = com1;
                    npgsqlC.Parameters.AddWithValue("p8", path.Text);
                }
                if (path.Text == "")
                {
                    npgsqlC.CommandText = com2;
                }
                npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
                npgsqlC.Parameters.AddWithValue("p2", two.Text);
                npgsqlC.Parameters.AddWithValue("p3", Convert.ToInt32(three.Text));
                npgsqlC.Parameters.AddWithValue("p4", Convert.ToInt32(four.Text));
                npgsqlC.Parameters.AddWithValue("p5", Convert.ToInt32(five.Text));
                npgsqlC.Parameters.AddWithValue("p6", Convert.ToInt32(ten.Text));
                npgsqlC.Parameters.AddWithValue("p7", Convert.ToInt32(eleven.Text));
                npgsqlC.ExecuteNonQuery(); // Изменение записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} изменил запись в таблице Гостиничные номера в {DateTime.Now}:  \"IdNumber\", \"Category\", \"CountRoom\", \"Floor\",\"CountPlaces\", \"TV\", \"Fridge\", \"Balcony\", \"Reservation\", \"Record\" - '{one.Text}', '{two.Text}', '{three.Text}', '{four.Text}', '{five.Text}','{chTV.Checked}', '{chFridge.Checked}', '{chBalcony.Checked}', '{ten.Text}', '{eleven.Text}'"); // Логирование)
            }
            
            
            catch (Exception)
            {
                error.Visible = true;
            }
            data_numbers.DataSource = Hotel.GetData("SELECT * from hotel_base.numbers"); // Обновление данных в грид вью 
        }

        private void add_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            try
            {
                NpgsqlCommand npgsqlC = new NpgsqlCommand($"INSERT INTO hotel_base.numbers (\"IdNumber\", \"Category\", \"CountRoom\", \"Floor\",\"CountPlaces\", \"TV\", \"Fridge\", \"Balcony\",\"Photo\" ,\"Reservation\", \"Record\") VALUES " +
                    $"(@p1, @p2, @p3, @p4, @p5, '{chTV.Checked}','{chFridge.Checked}', '{chBalcony.Checked}', pg_read_binary_file(@p8),@p6, @p7)", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
                npgsqlC.Parameters.AddWithValue("p2", two.Text);
                npgsqlC.Parameters.AddWithValue("p3", Convert.ToInt32(three.Text));
                npgsqlC.Parameters.AddWithValue("p4", Convert.ToInt32(four.Text));
                npgsqlC.Parameters.AddWithValue("p5", Convert.ToInt32(five.Text));
                npgsqlC.Parameters.AddWithValue("p6", Convert.ToInt32(ten.Text));
                npgsqlC.Parameters.AddWithValue("p7", Convert.ToInt32(eleven.Text));
                npgsqlC.Parameters.AddWithValue("@p8", path.Text);
                npgsqlC.ExecuteNonQuery(); // Добавление записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} добавил запись в таблицу Гостиничные номера в {DateTime.Now}:  \"IdNumber\", \"Category\", \"CountRoom\", \"Floor\",\"CountPlaces\", \"TV\", \"Fridge\", \"Balcony\", \"Reservation\", \"Record\" - '{one.Text}', '{two.Text}', '{three.Text}', '{four.Text}', '{five.Text}','{chTV.Checked}', '{chFridge.Checked}', '{chBalcony.Checked}', '{ten.Text}', '{eleven.Text}'"); // Логирование)
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_numbers.DataSource = Hotel.GetData("SELECT * from hotel_base.numbers"); // Обновление данных в грид вью 

        }


        private void data_numbers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = data_numbers.Rows[e.RowIndex];
                one.Text = row.Cells["IdNumber"].Value.ToString();
                two.Text = row.Cells["Category"].Value.ToString();
                three.Text = row.Cells["CountRoom"].Value.ToString();
                four.Text = row.Cells["Floor"].Value.ToString();
                five.Text = row.Cells["CountPlaces"].Value.ToString();
                chTV.Checked = (bool)row.Cells["TV"].Value;
                chFridge.Checked = (bool)row.Cells["Fridge"].Value;
                chBalcony.Checked = (bool)row.Cells["Balcony"].Value;
                ten.Text = row.Cells["Reservation"].Value.ToString();
                eleven.Text = row.Cells["Record"].Value.ToString();
                photo_number.Image = (System.Drawing.Bitmap)new System.Drawing.ImageConverter().ConvertFrom(row.Cells["Photo"].Value); // Получение данных в текст боксы

                // Получение данных в текст боксы
            }
            catch (Exception)
            {

            }
        }


        private void searchButton_Click(object sender, EventArgs e)
        {

            try
            {
                data_numbers.DataSource = Hotel.GetData($"select * from hotel_base.numbers WHERE \"Category\" = @p1", new NpgsqlParameter("p1", search.Text)); // Поиск записи по фамилии
            }
            catch (Exception)
            {
                
            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            data_numbers.DataSource = Hotel.NumbersTable;
        }

        private void reportExcel_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dataForReport, "Numbers");
            ws.Columns().AdjustToContents();
            wb.SaveAs("reportNumbers.xlsx"); // Отчёт в формате xlsx
        }

        private void reportWord_Click(object sender, EventArgs e)
        {
            string filename = "NumbersWD.docx";
            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            for (int i = 0; i < data_numbers.Rows.Count; i++)
            {
                Section contract = doc.Sections.Add(Start: 0);
                Range contractIDRange = contract.Range;
                contractIDRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                contractIDRange.Font.ColorIndex = WdColorIndex.wdBlack;
                contractIDRange.Font.Size = 16;
                contractIDRange.Font.Bold = 1;
                contractIDRange.Font.Name = "Arial";
                contractIDRange.Text = $"\"Идентификатор {Convert.ToString(data_numbers.Rows[i].Cells["IdNumber"].Value)}\n";
                Section box2 = doc.Sections.Add(Start: 0);
                Range box2Range = box2.Range;
                box2Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                box2Range.Font.ColorIndex = WdColorIndex.wdBlack;
                box2Range.Font.Size = 14;
                box2Range.Font.Bold = 0;
                box2Range.Font.Name = "Arial";
                box2Range.Text = $"Категория номера: {Convert.ToString(data_numbers.Rows[i].Cells["Category"].Value)}\nКоличество комнат: {Convert.ToString(data_numbers.Rows[i].Cells["CountRoom"].Value)}\nЭтаж: {Convert.ToString(data_numbers.Rows[i].Cells["Floor"].Value)}\nКоличество мест: {Convert.ToString(data_numbers.Rows[i].Cells["CountPlaces"].Value)}\n" +
                    $"Телевизор: {Convert.ToString(data_numbers.Rows[i].Cells["TV"].Value)}\nХолодильник: {Convert.ToString(data_numbers.Rows[i].Cells["Fridge"].Value)}\nБалкон: {Convert.ToString(data_numbers.Rows[i].Cells["Balcony"].Value)}\nБронь: {Convert.ToString(data_numbers.Rows[i].Cells["Reservation"].Value)}\nЗапись о проживании: { Convert.ToString(data_numbers.Rows[i].Cells["Record"].Value)}\n";
            }
            string path = Directory.GetCurrentDirectory() + @"" + filename;
            doc.SaveAs2(path);
            doc.Close();// Отчёт в формате word
        }
    }
}
