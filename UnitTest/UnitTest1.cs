using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Sockets;
using Npgsql;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodConnection()
        {
            NpgsqlConnection npgsql = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgres;Password=1234;Database=hotel_base");
            npgsql.Open();
        }
        [TestMethod]
        [ExpectedException((typeof(SocketException)))]
        public void TestMethodNotConnection1()
        {
            NpgsqlConnection npgsql = new NpgsqlConnection("Server=localhos;Port=5432;User ID=postgres;Password=1234;Database=hotel_base");
            npgsql.Open();
        }
        [TestMethod]
        [ExpectedException((typeof(NpgsqlException)))]
        public void TestMethodNotConnection2()
        {
            NpgsqlConnection npgsql = new NpgsqlConnection("Server=localhost;Port=5433;User ID=postgres;Password=1234;Database=hotel_base");
            npgsql.Open();
        }
        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void TestMethodNotConnection3()
        {
            NpgsqlConnection npgsql = new NpgsqlConnection("Server=localhost;Port=5432;User ID=postgre;Password=1234;Database=hotel_base");
            npgsql.Open();
        }
    }
}
