using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbManager
{
    public class Manager
    {
        private string connectionString = @"Server=VLADO-PC\SQLEXPRESS;Database=TestDb; Integrated Security=True;";
        public List<Test> GetAllTests()
        {
            List<Test> tests = new List<Test>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Tests", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Test test = new Test();

                    test.Id = reader.GetInt32(0);
                    test.TestName = reader.GetString(1);
                    test.IsPassed = reader.GetBoolean(2);
                    tests.Add(test);
                }
                con.Close();
            }
            return tests;
        }
    }
}
