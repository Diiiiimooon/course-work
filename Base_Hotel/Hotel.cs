using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using System.IO;
using System.Text;

namespace Base_Hotel
{
    public partial class Hotel : Form
    {
        static internal User currentUser; // Текущий пользователь
        static public NpgsqlConnection npgsql = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=1234;Database=hotel_base"); // Соединение с БД
        static NpgsqlCommand npgsqlC = new NpgsqlCommand(); // Команда для SQL
        static DataTable guestsTable, numbersTable, guests_numbersTable, paymentTable, timeofresidenceTable, usersTable; // Таблицы БД

        public Hotel()
        {
            InitializeComponent();
        }

        internal User CurrentUser { get => currentUser; set => currentUser = value; }
        static internal DataTable GuestsTable { get => guestsTable; set => guestsTable = value; }
        internal static DataTable NumbersTable { get => numbersTable; set => numbersTable = value; }
        internal static DataTable Guests_numbersTable { get => guests_numbersTable; set => guests_numbersTable = value; }
        internal static DataTable PaymentTable { get => paymentTable; set => paymentTable = value; }
        internal static DataTable TimeofresidenceTable { get => timeofresidenceTable; set => timeofresidenceTable = value; }
        internal static DataTable UsersTable { get => usersTable; set => usersTable = value; }


        public static DataTable GetData(string sql)
        {
            npgsqlC.Connection = npgsql; // Подключение команды к БД
            DataTable dataTable = new DataTable();
            npgsqlC.CommandText = sql;
            NpgsqlDataReader npgsqlDataReader = npgsqlC.ExecuteReader(); // Выполнение запроса на получение данных
            dataTable.Load(npgsqlDataReader); // Загрузка данных 
            return dataTable;
        }
        public static DataTable GetData(string sql, NpgsqlParameter npgsqlParameter) // Получение данных с одним параметром
        {
            npgsqlC.Connection = npgsql;
            DataTable dataTable = new DataTable();
            npgsqlC.CommandText = sql;
            npgsqlC.Parameters.Add(npgsqlParameter);
            NpgsqlDataReader npgsqlDataReader = npgsqlC.ExecuteReader();
            dataTable.Load(npgsqlDataReader);
            npgsqlC = new NpgsqlCommand();
            return dataTable;
        }

        

        public static DataTable GetData(string sql, NpgsqlParameter npgsqlParameter, NpgsqlParameter npgsqlParameter2) // Получение данных с двумя параметрами
        {
            npgsqlC.Connection = npgsql;
            DataTable dataTable = new DataTable();
            npgsqlC.CommandText = sql;
            npgsqlC.Parameters.Add(npgsqlParameter);
            npgsqlC.Parameters.Add(npgsqlParameter2);
            NpgsqlDataReader npgsqlDataReader = npgsqlC.ExecuteReader();
            dataTable.Load(npgsqlDataReader);
            npgsqlC = new NpgsqlCommand();
            return dataTable;
        }
        public static DataTable GetData(string sql, NpgsqlParameter npgsqlParameter, NpgsqlParameter npgsqlParameter2,NpgsqlParameter npgsqlParameter3) // Получение данных с двумя параметрами
        {
            npgsqlC.Connection = npgsql;
            DataTable dataTable = new DataTable();
            npgsqlC.CommandText = sql;
            npgsqlC.Parameters.Add(npgsqlParameter);
            npgsqlC.Parameters.Add(npgsqlParameter2);
            npgsqlC.Parameters.Add(npgsqlParameter3);
            NpgsqlDataReader npgsqlDataReader = npgsqlC.ExecuteReader();
            dataTable.Load(npgsqlDataReader);
            npgsqlC = new NpgsqlCommand();
            return dataTable;
        }
        public static DataTable GetData(string sql, NpgsqlParameter npgsqlParameter, NpgsqlParameter npgsqlParameter2, NpgsqlParameter npgsqlParameter3, NpgsqlParameter npgsqlParameter4) // Получение данных с двумя параметрами
        {
            npgsqlC.Connection = npgsql;
            DataTable dataTable = new DataTable();
            npgsqlC.CommandText = sql;
            npgsqlC.Parameters.Add(npgsqlParameter);
            npgsqlC.Parameters.Add(npgsqlParameter2);
            npgsqlC.Parameters.Add(npgsqlParameter3);
            npgsqlC.Parameters.Add(npgsqlParameter4);
            NpgsqlDataReader npgsqlDataReader = npgsqlC.ExecuteReader();
            dataTable.Load(npgsqlDataReader);
            npgsqlC = new NpgsqlCommand();
            return dataTable;
        }

        private void open_list_form_Click(object sender, EventArgs e)
        {
            ShowForm(true);
            ShowMenu(false);
        }
        private void back_menu_Click(object sender, EventArgs e)
        {
            ShowMenu(true);
            ShowForm(false);
        }

        public static void ClearF(Form form) // Очистка текстбоксов и чекбоксов
        {
            for (int i = 0; i < form.Controls.Count; i++)
            {
                if (form.Controls[i] is TextBox)
                    (form.Controls[i] as TextBox).Text = null;
                if (form.Controls[i] is CheckBox)
                {
                    (form.Controls[i] as CheckBox).Checked = false;
                }
            }
        }
        private void Hotel_Load(object sender, EventArgs e)
        {
            if (!currentUser.ChUsers) // Установка доступа к таблицам
                users.Enabled = false;
            if (!currentUser.ChGuests)
                guests.Enabled = false;
            if (!currentUser.ChNumbers)
                numbers.Enabled = false;
            if (!currentUser.ChPayment)
                payment.Enabled = false;
            if (!currentUser.ChTimeOfResidence)
                timeofresidence.Enabled = false;
            using (StreamWriter Log = new StreamWriter("log.txt", true))
            Log.Write($"Пользователь {currentUser.Surname} {currentUser.Name} {currentUser.Patronymic} зашёл в БД в {DateTime.Now}\n");// Логирование
        }

        private void numbers_Click(object sender, EventArgs e)
        {
            numbersTable = GetData("SELECT *from hotel_base.numbers");
            Numbers numbersF = new Numbers();
            numbersF.Show(); // Открытие формы Номера
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.Write($"Пользователь {currentUser.Surname} {currentUser.Name} {currentUser.Patronymic} открыл таблицу Гостиничные номера в {DateTime.Now}\n");

        }

        private void payment_Click(object sender, EventArgs e)
        {
            paymentTable = GetData("SELECT *from hotel_base.payment");
            Payment paymentF = new Payment();
            paymentF.Show(); // Открытие формы Оплата
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.Write($"Пользователь {currentUser.Surname} {currentUser.Name} {currentUser.Patronymic} открыл таблицу Оплата в {DateTime.Now}\n");
        }

        private void timeofresidence_Click(object sender, EventArgs e)
        {
            timeofresidenceTable = GetData("SELECT *from hotel_base.timeofresidence");
            TimeOfResidence timeofresidenceF = new TimeOfResidence();
            timeofresidenceF.Show(); // Открытие формы Время проживания
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.Write($"Пользователь {currentUser.Surname} {currentUser.Name} {currentUser.Patronymic} открыл таблицу Время проживания в {DateTime.Now}\n");
        }

        private void back_authorization_Click(object sender, EventArgs e)
        {
            npgsql.Close();
            Close();
            Authorization authorization = new Authorization();
            authorization.Show();
        }

        private void info_pic_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для работы с БД необходимо из главной кнопочной формы попасть в список форм, нажав одноименную кнопку, после чего открываем одну из представленных форм, которые соответсвуют таблицам"+
                "\n\nПользователь получает различные возможности (добавление, изменение, удаление записей) при работе с БД, в соответствии с установленными для него правами доступа. \n\nДля смены пользователя можно вернуться в окно авторизации", "Справка по работе с приложением", MessageBoxButtons.OK, MessageBoxIcon.Question); // Помощь по программе
        }

        private void guests_Click(object sender, EventArgs e)
        {
            guestsTable = GetData("SELECT *from hotel_base.guests");
            Guests guestsF = new Guests();
            guestsF.Show(); // Открытие формы Гости
            using (StreamWriter Log = new StreamWriter("log.txt", true))
                Log.Write($"Пользователь {currentUser.Surname} {currentUser.Name} {currentUser.Patronymic} открыл таблицу Гости в {DateTime.Now}\n");

        }
        private void users_Click(object sender, EventArgs e)
        {
            usersTable = GetData("SELECT *from hotel_base.users");
            Users usersF = new Users();
            usersF.Show(); // Открытие формы users
            using (StreamWriter Log = new StreamWriter("log.txt", true))            
                Log.Write($"Пользователь {currentUser.Surname} {currentUser.Name} {currentUser.Patronymic} открыл таблицу Пользователи в {DateTime.Now}\n");
        }
        private void closeDATA_Click(object sender, EventArgs e)
        {
            using (StreamWriter Log = new StreamWriter("log.txt", true))
            {
                Log.Write($"Пользователь {currentUser.Surname} {currentUser.Name} {currentUser.Patronymic} вышел из БД в {DateTime.Now}\n");
                Log.Close();
            }
            npgsql.Close();
            Application.Exit(); // Закрытие программы
        }
        private void ShowForm(bool show) // Скрытие/показ форм
        {
            list_form.Visible = show;
            users.Visible = show;
            timeofresidence.Visible = show;
            payment.Visible = show;
            numbers.Visible = show;
            guests.Visible = show;
            back_menu.Visible = show;
        }
        private void ShowMenu(bool show) // Скрытие/показ элементов меню 
        {
            welcome.Visible = show;
            back_authorization.Visible = show;
            open_list_form.Visible = show;
            closeDATA.Visible = show;
            info_pic.Visible = show;
        }
    }
}
