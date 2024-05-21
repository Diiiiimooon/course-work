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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();

            dataForReport = Hotel.GetData("SELECT * from hotel_base.payment"); // Обновление данных
            data_payment.DataSource = Hotel.PaymentTable; // Данные в грид вью при заходе
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

        private void data_payment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = data_payment.Rows[e.RowIndex];
                one.Text = row.Cells["Receipt"].Value.ToString();
                two.Text = row.Cells["Sum"].Value.ToString();
                chCash.Checked = (bool)row.Cells["Cash"].Value;
                four.Text = row.Cells["Admin"].Value.ToString();
                // Получение данных в текст боксы
            }
            catch (Exception)
            {

            }
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
                NpgsqlCommand npgsqlC = new NpgsqlCommand($"INSERT INTO hotel_base.payment (\"Receipt\", \"Sum\", \"Cash\", \"Admin\") VALUES " +
                    $"(@p1, @p2, '{chCash.Checked}', @p3)", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
                npgsqlC.Parameters.AddWithValue("p2", Convert.ToDouble(two.Text));
                npgsqlC.Parameters.AddWithValue("p3", four.Text);
                npgsqlC.ExecuteNonQuery(); // Добавление записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} добавил запись в таблицу Оплата в {DateTime.Now}: \"Receipt\", \"Sum\", \"Cash\", \"Admin\" - '{one.Text}', '{two.Text}','{chCash.Checked}', '{four.Text}'"); // Логирование
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_payment.DataSource = Hotel.GetData("SELECT * from hotel_base.payment"); // Обновление данных в грид вью 
        }

        private void delete_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"DELETE FROM hotel_base.payment WHERE \"Receipt\" = @p1", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", Convert.ToInt32(one.Text));
            npgsqlC.ExecuteNonQuery(); // Удаление записи
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} удалил запись в таблице Оплата в {DateTime.Now}: \"Receipt\", \"Sum\", \"Cash\", \"Admin\" - '{one.Text}', '{two.Text}', '{chCash.Checked}', '{four.Text}'"); // Логирование)
            data_payment.DataSource = Hotel.GetData("SELECT * from hotel_base.payment"); // Обновление данных в грид вью
        }

        private void edit_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            try
            {

                NpgsqlCommand npgsqlC = new NpgsqlCommand($"UPDATE hotel_base.payment SET  \"Sum\" = @p1, \"Cash\" = '{chCash.Checked}',\"Admin\" = @p2 WHERE \"Receipt\" = @p3", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", Convert.ToDouble(two.Text));
                npgsqlC.Parameters.AddWithValue("p2", four.Text);
                npgsqlC.Parameters.AddWithValue("p3", Convert.ToInt32(one.Text));
                npgsqlC.ExecuteNonQuery(); // Изменение записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.WriteLine($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} изменил запись в таблице Оплата в {DateTime.Now}: \"Receipt\", \"Sum\", \"Cash\", \"Admin\" - '{one.Text}', '{two.Text}', '{chCash.Checked}', '{four.Text}'"); // Логирование)
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_payment.DataSource = Hotel.GetData("SELECT * from hotel_base.payment"); // Обновление данных в грид вью 
        }


        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (search1.Text != "" && search2.Text != "")
                    data_payment.DataSource = Hotel.GetData($"select * from hotel_base.payment WHERE \"Sum\" BETWEEN @p1 AND @p2", new NpgsqlParameter("p1", Convert.ToDouble(search1.Text)), new NpgsqlParameter("p2", Convert.ToDouble(search2.Text)));
                if (search1.Text != "" && search2.Text == "")
                    data_payment.DataSource = Hotel.GetData($"select * from hotel_base.payment WHERE \"Sum\" >= @p1", new NpgsqlParameter("p1", Convert.ToDouble(search1.Text)));
                if (search1.Text == "" && search2.Text != "")
                    data_payment.DataSource = Hotel.GetData($"select * from hotel_base.payment WHERE \"Sum\" <= @p1", new NpgsqlParameter("p1", Convert.ToDouble(search2.Text))); // Нахождение записей с оплатой в диапазоне
            }
            catch (Exception)
            {

            }
        }
        private void reset_Click(object sender, EventArgs e)
        {
            data_payment.DataSource = Hotel.PaymentTable;
        }

        private void reportExcel_Click(object sender, EventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            var ws = wb.Worksheets.Add(dataForReport, "Payment");
            ws.Columns().AdjustToContents();
            wb.SaveAs("reportPayment.xlsx"); // Отчёт в формате xlsx
        }

        private void reportWord_Click(object sender, EventArgs e)
        {
            string filename = "PaymentWD.docx";
            Application app = new Application();
            Document doc = app.Documents.Add(Visible: true);
            for (int i = 0; i < data_payment.Rows.Count; i++)
            {
                Section contract = doc.Sections.Add(Start: 0);
                Range contractIDRange = contract.Range;
                contractIDRange.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                contractIDRange.Font.ColorIndex = WdColorIndex.wdBlack;
                contractIDRange.Font.Size = 16;
                contractIDRange.Font.Bold = 1;
                contractIDRange.Font.Name = "Times New Roman";
                contractIDRange.Text = $"Идентификатор {Convert.ToString(data_payment.Rows[i].Cells["Receipt"].Value)}\n";
                Section box2 = doc.Sections.Add(Start: 0);
                Range box2Range = box2.Range;
                box2Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                box2Range.Font.ColorIndex = WdColorIndex.wdBlack;
                box2Range.Font.Size = 14;
                box2Range.Font.Bold = 0;
                box2Range.Font.Name = "Times New Roman";
                box2Range.Text = $"Квитанция об оплате: {Convert.ToString(data_payment.Rows[i].Cells["Receipt"].Value)}\nКоличество комнат: {Convert.ToString(data_payment.Rows[i].Cells["Sum"].Value)}\nЭтаж: {Convert.ToString(data_payment.Rows[i].Cells["Cash"].Value)}\nКоличество мест: {Convert.ToString(data_payment.Rows[i].Cells["Admin"].Value)}";
            }
            string path = Directory.GetCurrentDirectory() + @"" + filename;
            doc.SaveAs2(path);
            doc.Close();// Отчёт в формате word
        }
    }
}
