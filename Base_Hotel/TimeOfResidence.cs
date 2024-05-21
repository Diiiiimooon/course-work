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
    public partial class TimeOfResidence : Form
    {
        public TimeOfResidence()
        {
            InitializeComponent();
            dataForReport = Hotel.GetData("SELECT * from hotel_base.timeofresidence"); // Обновление данных
            data_timeofresidence.DataSource = Hotel.TimeofresidenceTable; // Данные в грид вью при заходе
            if (Hotel.currentUser.AcTimeOfResidence == "0") // Установка в соответствии с правами пользователя
            {
                add.Enabled = false;
                edit.Enabled = false;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcTimeOfResidence == "1")
            {
                add.Enabled = false;
                edit.Enabled = true;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcTimeOfResidence == "2")
            {
                add.Enabled = true;
                edit.Enabled = true;
                delete.Enabled = false;
            }
            if (Hotel.currentUser.AcTimeOfResidence == "3")
            {
                add.Enabled = true;
                edit.Enabled = true;
                delete.Enabled = true;
            }
        }
        System.Data.DataTable dataForReport; // Объект с данными для отчёта
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void clear_Click(object sender, EventArgs e)
        {

            error.Visible = false; // Очистка текстбоксов
            Hotel.ClearF(this);
        }

        private void add_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            try
            {
                NpgsqlCommand npgsqlC = new NpgsqlCommand($"INSERT INTO hotel_base.timeofresidence (\"Record\", \"Registration\", \"Arrival\", \"Departure\") VALUES " +
                    $"(@p1, @p2, @p3,@p4)", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
                npgsqlC.Parameters.AddWithValue("p2", Convert.ToDateTime(two.Text));
                npgsqlC.Parameters.AddWithValue("p3", Convert.ToDateTime(three.Text));
                npgsqlC.Parameters.AddWithValue("p4", Convert.ToDateTime(four.Text));
                npgsqlC.ExecuteNonQuery(); // Добавление записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} добавил запись в таблицу Проживание в {DateTime.Now}: \"Record\", \"Registration\", \"Arrival\", \"Departure\" - '{one.Text}', '{two.Text}','{three.Text}', '{four.Text}'"); // Логирование
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_timeofresidence.DataSource = Hotel.GetData("SELECT * from hotel_base.timeofresidence"); // Обновление данных в грид вью 
        }

        private void delete_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"DELETE FROM hotel_base.timeofresidence WHERE \"Record\" = @p1", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
            npgsqlC.ExecuteNonQuery(); // Удаление записи
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} удалил запись в таблице Проживание в {DateTime.Now}: \"Record\", \"Registration\", \"Arrival\", \"Departure\" - '{one.Text}', '{two.Text}', '{three.Text}', '{four.Text}'"); // Логирование)
            data_timeofresidence.DataSource = Hotel.GetData("SELECT * from hotel_base.timeofresidence"); // Обновление данных в грид вью
        }

        private void edit_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            try
            {

                NpgsqlCommand npgsqlC = new NpgsqlCommand($"UPDATE hotel_base.timeofresidence SET  \"Registration\" = @p2, \"Arrival\" = @p3,\"Departure\" = @p4 WHERE \"Record\" = @p1", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
                npgsqlC.Parameters.AddWithValue("p2", Convert.ToDateTime(two.Text));
                npgsqlC.Parameters.AddWithValue("p3", Convert.ToDateTime(three.Text));
                npgsqlC.Parameters.AddWithValue("p4", Convert.ToDateTime(four.Text));
                npgsqlC.ExecuteNonQuery(); // Изменение записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} изменил запись в таблице Проживание в {DateTime.Now}: \"Record\", \"Registration\", \"Arrival\", \"Departure\" - '{one.Text}', '{two.Text}', '{three.Text}', '{four.Text}'");// Логирование)
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_timeofresidence.DataSource = Hotel.GetData("SELECT * from hotel_base.timeofresidence"); // Обновление данных в грид вью
        }

        private void data_timeofresidence_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = data_timeofresidence.Rows[e.RowIndex];
                one.Text = row.Cells["Record"].Value.ToString();
                two.Text = row.Cells["Registration"].Value.ToString();
                three.Text = row.Cells["Arrival"].Value.ToString();
                four.Text = row.Cells["Departure"].Value.ToString();
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
                if (search1.Text != "" && search2.Text != "")
                    data_timeofresidence.DataSource = Hotel.GetData($"select * from hotel_base.timeofresidence WHERE \"Arrival\" BETWEEN @p1 AND @p2", new NpgsqlParameter("p1", Convert.ToDateTime(search1.Text)), new NpgsqlParameter("p2", Convert.ToDateTime(search2.Text)));
                if (search1.Text != "" && search2.Text == "")
                    data_timeofresidence.DataSource = Hotel.GetData($"select * from hotel_base.timeofresidence WHERE \"Arrival\" >= @p1", new NpgsqlParameter("p1", Convert.ToDateTime(search1.Text)));
                if (search1.Text == "" && search2.Text != "")
                    data_timeofresidence.DataSource = Hotel.GetData($"select * from hotel_base.timeofresidence WHERE \"Arrival\" <= @p1", new NpgsqlParameter("p1", Convert.ToDateTime(search2.Text))); // Нахождение записей с ценой в диапазоне
                if (search3.Text != "" && search4.Text != "")
                    data_timeofresidence.DataSource = Hotel.GetData($"select * from hotel_base.timeofresidence WHERE \"Departure\" BETWEEN @p1 AND @p2", new NpgsqlParameter("p1", Convert.ToDateTime(search3.Text)), new NpgsqlParameter("p2", Convert.ToDateTime(search4.Text)));
                if (search3.Text != "" && search4.Text == "")
                    data_timeofresidence.DataSource = Hotel.GetData($"select * from hotel_base.timeofresidence WHERE \"Departure\" >= @p1", new NpgsqlParameter("p1", Convert.ToDateTime(search3.Text)));
                if (search3.Text == "" && search4.Text != "")
                    data_timeofresidence.DataSource = Hotel.GetData($"select * from hotel_base.timeofresidence WHERE \"Departure\" <= @p1", new NpgsqlParameter("p1", Convert.ToDateTime(search4.Text))); // Нахождение записей с ценой в диапазоне
            }
            catch (Exception)
            {

            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            data_timeofresidence.DataSource = Hotel.TimeofresidenceTable;
        }

        private void reportExcel_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dataForReport, "Timeofresidence");
            ws.Columns().AdjustToContents();
            wb.SaveAs("reportTimeOfResidence.xlsx"); // Отчёт в формате xlsx
        }

        private void reportWord_Click(object sender, EventArgs e)
        {
            string filename = "TimeOfResidenceWD.docx";
            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            for (int i = 0; i < data_timeofresidence.Rows.Count; i++)
            {
                Section contract = doc.Sections.Add(Start: 0);
                Range contractIDRange = contract.Range;
                contractIDRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                contractIDRange.Font.ColorIndex = WdColorIndex.wdBlack;
                contractIDRange.Font.Size = 16;
                contractIDRange.Font.Bold = 1;
                contractIDRange.Font.Name = "Times New Roman";
                contractIDRange.Text = $"Идентификатор {Convert.ToString(data_timeofresidence.Rows[i].Cells["Record"].Value)}\n";
                Section box2 = doc.Sections.Add(Start: 0);
                Range box2Range = box2.Range;
                box2Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                box2Range.Font.ColorIndex = WdColorIndex.wdBlack;
                box2Range.Font.Size = 14;
                box2Range.Font.Bold = 0;
                box2Range.Font.Name = "Times New Roman";
                box2Range.Text = $"Номер записи: {Convert.ToString(data_timeofresidence.Rows[i].Cells["Record"].Value)}\nРегистрация: {Convert.ToString(data_timeofresidence.Rows[i].Cells["Registration"].Value)}\nКогда прибыл: {Convert.ToString(data_timeofresidence.Rows[i].Cells["Arrival"].Value)}\nКогда убыл: {Convert.ToString(data_timeofresidence.Rows[i].Cells["Departure"].Value)}";
             }
            string path = Directory.GetCurrentDirectory() + @"" + filename;
            doc.SaveAs2(path);
            doc.Close();// Отчёт в формате word
        }
    }
    
}
