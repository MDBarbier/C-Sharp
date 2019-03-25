using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace mariadbtest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Family> myFamily = new List<Family>();

            Console.WriteLine("Attempting to connect to MariaDb...");

            using (MySqlConnection dc = new MySqlConnection("server=localhost;port=3306;database=test_db;user=root;password=spectrum;"))
            {
                dc.Open();
                Console.WriteLine("Connected to MariaDb, version info: " + dc.ServerVersion);

                MySqlCommand command = new MySqlCommand("SELECT * FROM test_table", dc);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        myFamily.Add(new Family() {
                            Id = (int)reader["id"],
                            Name = reader["name"].ToString()
                        });
                    }                    
                }
            }

            foreach (var familyMember in myFamily)
            {
                Console.WriteLine(familyMember.Name);
            }

            Console.WriteLine(">>>Finished execution.");
            Console.ReadLine();
        }
    }

    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
