using Npgsql;
using System;
using System.IO;
using System.Windows.Forms;

namespace Base_Hotel
{
    public partial class Users : Form
    {
        string login = ""; // Переменная для обновления ключевого поля
        public Users()
        {
            InitializeComponent();
            data_users.DataSource = Hotel.UsersTable; // Данные в грид вью при заходе
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
        private void add_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            try
            {
                NpgsqlCommand npgsqlC = new NpgsqlCommand($"INSERT INTO hotel_base.users (\"Surname\", \"Name\", \"Patronymic\", login, password, \"chGuests\", \"chNumbers\", \"chGuests_Numbers\", \"chPayment\", \"chTimeOfResidence\", \"chUsers\", \"acGuests\", \"acNumbers\", \"acGuests_Numbers\", \"acPayment\", \"acTimeOfResidence\", \"acUsers\") VALUES " +
                    $"(@p1, @p2, @p3, @p4, '{Authorization.Crypt(fifth.Text, Authorization.secretKey)}', {chGuests.Checked}," + $"{chNumbers.Checked}, {chGuests_Numbers.Checked}, {chPayment.Checked}, {chTimeOfResidence.Checked}, {chUsers.Checked}, '{acGuests.SelectedItem}', '{acNumbers.SelectedItem}', '{acGuests_Numbers.SelectedItem}', '{acPayment.SelectedItem}', '{acTimeOfResidence.SelectedItem}', '{acUsers.SelectedItem}')", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", first.Text);
                npgsqlC.Parameters.AddWithValue("p2", second.Text);
                npgsqlC.Parameters.AddWithValue("p3", third.Text);
                npgsqlC.Parameters.AddWithValue("p4", fourth.Text);
                npgsqlC.ExecuteNonQuery(); // Добавление записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.Write($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} добавил запись в таблицу Users в {DateTime.Now}: \"Name\", \"Surname\", \"Patronymic\", login, password, \"chClient\", \"chCount\", \"chSeller\", \"chGoods\", \"chGoodsInvoice\", \"chAccounts\", \"chInvoice\", \"accessClient\", \"accessCount\", \"accessSeller\", \"accessGoods\", \"accessGoodsInvoice\", \"accessAccounts\", \"accessInvoice\" - '{first.Text}', '{second.Text}', '{third.Text}', '{fourth.Text}', '{Authorization.Crypt(fifth.Text, Authorization.secretKey)}', {chGuests.Checked}, {chNumbers.Checked}," +
                 $"{chGuests_Numbers.Checked}, {chPayment.Checked}, {chTimeOfResidence.Checked}, {chUsers.Checked}, '{acGuests.SelectedItem}', '{acNumbers.SelectedItem}', '{acGuests_Numbers.SelectedItem}', '{acPayment.SelectedItem}', '{acTimeOfResidence.SelectedItem}', '{acUsers.SelectedItem}'\n");
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_users.DataSource = Hotel.GetData("SELECT * from hotel_base.users"); // Обновление данных в грид вью
        }
        private void clear_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            Hotel.ClearF(this); // Очистка текстбоксов 
        }
        
        private void delete_Click(object sender, EventArgs e)
        {
            error.Visible = false;
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"DELETE FROM hotel_base.users WHERE login = @p1", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", fourth.Text);
            npgsqlC.ExecuteNonQuery(); // Удаление записи
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.Write($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} удалил запись в таблице Users в {DateTime.Now}: \"Name\", \"Surname\", \"Patronymic\", login, password, \"chClient\", \"chCount\", \"chSeller\", \"chGoods\", \"chGoodsInvoice\", \"chAccounts\", \"chInvoice\", \"accessClient\", \"accessCount\", \"accessSeller\", \"accessGoods\", \"accessGoodsInvoice\", \"accessAccounts\", \"accessInvoice\" - '{first.Text}', '{second.Text}', '{third.Text}', '{fourth.Text}', '{Authorization.Crypt(fifth.Text, Authorization.secretKey)}', {chGuests.Checked}, {chNumbers.Checked}," +
             $"{chGuests_Numbers.Checked}, {chPayment.Checked}, {chTimeOfResidence.Checked}, {chUsers.Checked}, '{acGuests.SelectedItem}', '{acNumbers.SelectedItem}', '{acGuests_Numbers.SelectedItem}', '{acPayment.SelectedItem}', '{acTimeOfResidence.SelectedItem}', '{acUsers.SelectedItem}'\n");
            data_users.DataSource = Hotel.GetData("SELECT * from hotel_base.users"); // Обновление данных в грид вью
        }
        private void data_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = data_users.Rows[e.RowIndex];
                first.Text = row.Cells["Surname"].Value.ToString();
                second.Text = row.Cells["Name"].Value.ToString();
                third.Text = row.Cells["Patronymic"].Value.ToString();
                fourth.Text = row.Cells["login"].Value.ToString();
                fifth.Text = row.Cells["password"].Value.ToString();
                chGuests.Checked = (bool)row.Cells["chGuests"].Value;
                chNumbers.Checked = (bool)row.Cells["chNumbers"].Value;
                chGuests_Numbers.Checked = (bool)row.Cells["chGuests_Numbers"].Value;
                chPayment.Checked = (bool)row.Cells["chPayment"].Value;
                chTimeOfResidence.Checked = (bool)row.Cells["chTimeOfResidence"].Value;
                chUsers.Checked = (bool)row.Cells["chUsers"].Value;
                acGuests.SelectedItem = row.Cells["acGuests"].Value;
                acUsers.SelectedItem = row.Cells["acUsers"].Value;
                acNumbers.SelectedItem = row.Cells["acNumbers"].Value;
                acPayment.SelectedItem = row.Cells["acPayment"].Value;
                acTimeOfResidence.SelectedItem = row.Cells["acTimeOfResidence"].Value;
                acGuests_Numbers.SelectedItem = row.Cells["acGuests_Numbers"].Value; // Получение данных в текст боксы
                login = fourth.Text;
            }
            catch (Exception)
            {

            }
        }
        private void edit_Click(object sender, EventArgs e)
        {
            try
            {
                error.Visible = false;
                NpgsqlCommand npgsqlC = new NpgsqlCommand($"UPDATE hotel_base.users SET \"Surname\" = @p1, \"Name\" = @p2, \"Patronymic\" = @p3, \"login\" = @p4, password = '{Authorization.Crypt(fifth.Text, Authorization.secretKey)}', \"chGuests\" = {chGuests.Checked}, \"chNumbers\" = {chNumbers.Checked}, \"chGuests_Numbers\" = {chGuests_Numbers.Checked}, \"chPayment\" = {chPayment.Checked}, \"chTimeOfResidence\" = {chTimeOfResidence.Checked}, \"chUsers\" = {chUsers.Checked}," +
                    $"\"acGuests\" = '{acGuests.SelectedItem}', \"acNumbers\" = '{acNumbers.SelectedItem}', \"acGuests_Numbers\" = '{acGuests_Numbers.SelectedItem}', \"acPayment\" = '{acPayment.SelectedItem}', \"acTimeOfResidence\" = '{acTimeOfResidence.SelectedItem}', \"acUsers\" = '{acUsers.SelectedItem}' WHERE login = @p4", Hotel.npgsql);
                npgsqlC.Parameters.AddWithValue("p1", first.Text);
                npgsqlC.Parameters.AddWithValue("p2", second.Text);
                npgsqlC.Parameters.AddWithValue("p3", third.Text);
                npgsqlC.Parameters.AddWithValue("p4", fourth.Text);
                // npgsqlC.Parameters.AddWithValue("p5", login);
                npgsqlC.ExecuteNonQuery(); // Изменение записи
                using (StreamWriter Log = new StreamWriter("log.txt", true))
                    Log.Write($"Пользователь {Hotel.currentUser.Surname} {Hotel.currentUser.Name} {Hotel.currentUser.Patronymic} изменил запись в таблице Users в {DateTime.Now}: \"Surname\", \"Name\", \"Patronymic\", login, password, \"chGuests\", \"chNumbers\", \"chGuests_Numbers\", \"chPayment\", \"chTimeOfResidence\", \"chUsers\", \"acGuests\", \"acNumbers\", \"acGuests_Numbers\", \"acPayment\", \"acTimeOfResidence\", \"acUsers\" - '{first.Text}', '{second.Text}', '{third.Text}', '{fourth.Text}', '{Authorization.Crypt(fifth.Text, Authorization.secretKey)}', {chGuests.Checked}, {chNumbers.Checked}," +
                 $"{chGuests_Numbers.Checked}, {chPayment.Checked}, {chTimeOfResidence.Checked}, {chUsers.Checked}, '{acGuests.SelectedItem}', '{acNumbers.SelectedItem}', '{acGuests_Numbers.SelectedItem}', '{acPayment.SelectedItem}', '{acTimeOfResidence.SelectedItem}', '{acUsers.SelectedItem}'\n");
            }
            catch (Exception)
            {
                error.Visible = true;
            }
            data_users.DataSource = Hotel.GetData("SELECT * from hotel_base.users"); // Обновление данных в грид вью 
        }

        private void role_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = role.SelectedItem.ToString();
            if (selected == "Управляющий отелем") // Автоматические заполнений текстбоксов и чекбоксов при выборе роли
            {
                for (int i = 0; i < Controls.Count; i++)
                {
                    if (Controls[i] is CheckBox)
                        (Controls[i] as CheckBox).Checked = true;
                }
                acGuests.SelectedItem = "3";
                acNumbers.SelectedItem = "3";
                acGuests_Numbers.SelectedItem = "3";
                acPayment.SelectedItem = "3";
                acTimeOfResidence.SelectedItem = "3";
                acUsers.SelectedItem = "3";
            }
            if (selected == "Администратор")
            {
                chGuests.Checked = true;
                chNumbers.Checked = true;
                chGuests_Numbers.Checked = true;
                chPayment.Checked = true;
                chTimeOfResidence.Checked = true;
                chUsers.Checked = true;
                acGuests.SelectedItem = "2";
                acNumbers.SelectedItem = "2";
                acGuests_Numbers.SelectedItem = "2";
                acPayment.SelectedItem = "2";
                acTimeOfResidence.SelectedItem = "2";
                acUsers.SelectedItem = "0";
            }
            if (selected == "Бухгалтер")
            {
                chGuests.Checked = true;
                chNumbers.Checked = true;
                chGuests_Numbers.Checked = true;
                chPayment.Checked = true;
                chTimeOfResidence.Checked = true;
                chUsers.Checked = false;
                acGuests.SelectedItem = "0";
                acNumbers.SelectedItem = "0";
                acGuests_Numbers.SelectedItem = "0";
                acPayment.SelectedItem = "3";
                acTimeOfResidence.SelectedItem = "1";
                acUsers.SelectedItem = "0";

            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                data_users.DataSource = Hotel.GetData($"select * from hotel_base.users WHERE \"Surname\" = @p1", new NpgsqlParameter("p1", search.Text)); // Поиск записи по фамилии
            }
            catch (Exception)
            {

            }
        }

        private void reset_Click(object sender, EventArgs e)
        {
            data_users.DataSource = Hotel.UsersTable;
        }
    }
}
