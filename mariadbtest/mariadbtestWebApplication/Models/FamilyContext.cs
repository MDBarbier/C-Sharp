using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mariadbtestWebApplication.Models
{
    public class FamilyContext
    {
        //Property to hold connection string
        public string ConnectionString { get; set; }

        //Constructor
        public FamilyContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        //Method to acquire a new connection - to be called from "using" statement to ensure lifecycle management
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        //Method to get data
        public List<Family> GetFamily()
        {
            List<Family> list = new List<Family>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                //MySqlCommand cmd = new MySqlCommand("select * from test_table", conn);
                MySqlCommand cmd = new MySqlCommand("select * from testtable1", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Family()
                        {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString()                            
                        });
                    }
                }
            }
            return list;
        }
    }
}
