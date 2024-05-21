using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Base_Hotel;
using System.Data;
using System.Net.Sockets;

namespace UnitTest
{
    [TestClass]
    public class UnitTest2
    {

        public bool CheckLoginAndPassword(string login, string password)
        {
            // Закрываем подключение к базе данных
            Hotel.npgsql.Close();
            // Устанавливаем подключение к базе данных
            Hotel.npgsql.Open();

            // Получаем все записи пользователей
            DataTable dataTable = Hotel.GetData("SELECT * FROM hotel_base.users");

            // Перебираем записи пользователей
            foreach (DataRow row in dataTable.Rows)
            {
                // Проверяем, совпадает ли логин с указанным
                if (row["login"].ToString() == login)
                {
                    // Проверяем, совпадает ли пароль с указанным
                    if (Authorization.Crypt(row["Password"].ToString(), Authorization.secretKey) == password)
                    {
                        // Пользователь найден
                        return true;
                    }
                }
            }
            // Пользователь не найден
            return false;
        }



        [TestMethod]
        public void TestAuthorization()
        {
            Assert.AreEqual(true, CheckLoginAndPassword("admin", "admin"));
            Assert.AreEqual(true, CheckLoginAndPassword("user", "userboss"));
            Assert.AreEqual(true, CheckLoginAndPassword("voron", "voron"));
        }
        [TestMethod]
        [ExpectedException((typeof(AssertFailedException)))]
        public void TestNotAuthorization()
        {
            Assert.AreEqual(true, CheckLoginAndPassword("admin", "admin1"));
            Assert.AreEqual(true, CheckLoginAndPassword("admi", "voron"));
            Assert.AreEqual(true, CheckLoginAndPassword("1234321", "chchc"));
        }
    }
}
