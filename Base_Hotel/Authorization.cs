using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Base_Hotel
{
    public partial class Authorization : Form
    {
        public Authorization()
        {
            InitializeComponent();
            Hotel.npgsql.Open();
        }

        Hotel hotel = new Hotel();
        static internal int secretKey = 3; // Ключ для шифрования
        private void auto_check_Click(object sender, EventArgs e)
        {
            DataTable dataTable = Hotel.GetData("SELECT *from hotel_base.users"); // Получение всех записей пользователей
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                if (dataTable.Rows[i]["login"].ToString() == login.Text)
                {
                    if (Crypt(dataTable.Rows[i]["password"].ToString(), secretKey) == password.Text)
                    {
                        Hide();
                        hotel.CurrentUser = new User(dataTable.Rows[i]["Surname"].ToString(), dataTable.Rows[i]["Name"].ToString(), dataTable.Rows[i]["Patronymic"].ToString(),
                            dataTable.Rows[i]["login"].ToString(), Convert.ToBoolean(dataTable.Rows[i]["chGuests"]), Convert.ToBoolean(dataTable.Rows[i]["chNumbers"]),
                            Convert.ToBoolean(dataTable.Rows[i]["chGuests_Numbers"]), Convert.ToBoolean(dataTable.Rows[i]["chPayment"]), Convert.ToBoolean(dataTable.Rows[i]["chTimeOfResidence"]), Convert.ToBoolean(dataTable.Rows[i]["chUsers"]), dataTable.Rows[i]["acGuests"].ToString(),
                            dataTable.Rows[i]["acNumbers"].ToString(), dataTable.Rows[i]["acGuests_Numbers"].ToString(), dataTable.Rows[i]["acPayment"].ToString(), dataTable.Rows[i]["acTimeOfResidence"].ToString(), dataTable.Rows[i]["acUsers"].ToString());
                        hotel.ShowDialog(); // Проверка логина и пароля пользователя, создание объекта User, открытие формы работы с БД
                    }
                    else
                        info.Visible = true;
                }
                else
                    info.Visible = true;
            }
        }
        public static string Crypt(string str, int secretKey) // Шифрование пароля
        {
            var ch = str.ToArray();
            string newStr = "";
            foreach (var c in ch)
                newStr += TopSecret(c, secretKey);
            return newStr;
        }
        public static char TopSecret(char character, int secretKey) // Шифрование посимвольно
        {
            character = (char)(character ^ secretKey);
            return character;
        }

        private void login_TextChanged(object sender, EventArgs e)
        {
            info.Visible = false;
        }

        private void password_TextChanged(object sender, EventArgs e)
        {
            info.Visible = false;
        }

        private void exit_Click(object sender, EventArgs e)
        {

            Application.Exit(); // Выход из программы
        }
    }
}
