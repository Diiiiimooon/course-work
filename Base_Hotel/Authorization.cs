using System;
using System.Data;
using System.IO;
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
            try
            {
                using (StreamReader sr = new StreamReader("policy_password.txt"))
                {
                    string[] str = sr.ReadToEnd().Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < str.Length; i++)
                    {
                        string[] strNew = str[i].Split(':');
                        if (strNew[0] == "Минимальная длина пароля")
                            Policy_password.MinimumLength = Convert.ToUInt32(strNew[1]);
                        if (strNew[0] == "Максимальная длина пароля")
                            Policy_password.MaximumLength = Convert.ToUInt32(strNew[1]);
                        if (strNew[0] == "Верхний регистр")
                            Policy_password.RequiresUppercase = Convert.ToBoolean(strNew[1]);
                        if (strNew[0] == "Нижний регистр")
                            Policy_password.RequiresLowercase = Convert.ToBoolean(strNew[1]);
                        if (strNew[0] == "Наличие цифр")
                            Policy_password.RequiresNumber = Convert.ToBoolean(strNew[1]);
                        if (strNew[0] == "Наличие одного из спец.символов (!@#)")
                            Policy_password.RequiresSpecialCharacter = Convert.ToBoolean(strNew[1]);
                        if (strNew[0] == "Продолжительность действия пароля в днях")
                            Policy_password.PasswordExpirationDays = Convert.ToUInt32(strNew[1]);
                    }
                }
            }
            catch (Exception)
            {
                Policy_password.MinimumLength = 8;
                Policy_password.MaximumLength = 15;
                Policy_password.RequiresUppercase = true;
                Policy_password.RequiresLowercase = true;
                Policy_password.RequiresNumber = true;
                Policy_password.RequiresSpecialCharacter = false;
                Policy_password.PasswordExpirationDays = 90;
                using (StreamWriter streamWriter = new StreamWriter("policy_password.txt", false))
                {
                    streamWriter.WriteLine($"Минимальная длина пароля: 8");
                    streamWriter.WriteLine($"Максимальная длина пароля: 15");
                    streamWriter.WriteLine($"Верхний регистр: True");
                    streamWriter.WriteLine($"Нижний регистр: True");
                    streamWriter.WriteLine($"Наличие цифр: True");
                    streamWriter.WriteLine($"Наличие одного из спец.символов (!@#): False");
                    streamWriter.WriteLine($"Продолжительность действия пароля в днях: 90");
                }
            }
        }

        Hotel hotel = new Hotel();
        static public int secretKey = 3; // Ключ для шифрования
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
