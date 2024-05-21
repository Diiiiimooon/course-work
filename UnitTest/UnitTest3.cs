using Base_Hotel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Npgsql;
using System.Data;

namespace UnitTest
{
    [TestClass]
    public class UnitTest3
    {
        static int receipt;
        static Random rnd = new Random();
        [ClassInitialize]
        public static void ReceiptDB(TestContext context)
        {
            rnd = new Random();
            Hotel.npgsql.Close();
            Hotel.npgsql.Open();
            receipt = rnd.Next(109, 1000);
        }
        [TestMethod]
        public void TestMethod1Add()
        {
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"INSERT INTO hotel_base.payment (\"Admin\", \"Receipt\") VALUES (@p1, @p2)", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", "Иванов");
            npgsqlC.Parameters.AddWithValue("p2", receipt);
            npgsqlC.ExecuteNonQuery();
            DataTable dataTable = Hotel.GetData($"SELECT (\"Admin\") FROM hotel_base.payment WHERE \"Receipt\" = '{receipt}'");
            Assert.AreEqual("Иванов", dataTable.Rows[0]["Admin"].ToString());
        }
        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void TestMethod2NotAdd()
        {
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"INSERT INTO payment (\"Admin\", \"Receipt\") VALUES (@p1, @p2)", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", "Иванов");
            npgsqlC.Parameters.AddWithValue("p2", receipt);
            npgsqlC.ExecuteNonQuery();
        }
        [TestMethod]
        public void TestMethod5Delete()
        {
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"DELETE FROM hotel_base.payment WHERE \"Receipt\" = @p1", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", receipt);
            npgsqlC.ExecuteNonQuery();
            DataTable dataTable = Hotel.GetData($"SELECT (\"Admin\") FROM hotel_base.payment WHERE \"Receipt\" = '{receipt}'");
            Assert.AreEqual(0, dataTable.Rows.Count);
        }
        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void TestMethod6NotDelete()
        {
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"DELETE FROM \"Payment\" WHERE \"Receipt\" = @p1", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", receipt);
            npgsqlC.ExecuteNonQuery();
        }
        [TestMethod]
        public void TestMethod3Edit()
        {
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"UPDATE hotel_base.payment SET \"Admin\" = @p1 WHERE \"Receipt\" = @p2", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", "Васин");
            npgsqlC.Parameters.AddWithValue("p2", receipt);
            npgsqlC.ExecuteNonQuery();
            DataTable dataTable = Hotel.GetData($"SELECT (\"Admin\") FROM hotel_base.payment WHERE \"Receipt\" = '{receipt}'");
            Assert.AreEqual("Васин", dataTable.Rows[0]["Admin"].ToString());
        }

        [TestMethod]
        [ExpectedException((typeof(PostgresException)))]
        public void TestMethod4NotEdit()
        {
            NpgsqlCommand npgsqlC = new NpgsqlCommand($"UPDATE hotel_base.payment SET \"Adminn\" = @p1 WHERE \"Receipt\" = @p2", Hotel.npgsql);
            npgsqlC.Parameters.AddWithValue("p1", "Васин");
            npgsqlC.Parameters.AddWithValue("p2", receipt);
            npgsqlC.ExecuteNonQuery();
        }
    }
}
