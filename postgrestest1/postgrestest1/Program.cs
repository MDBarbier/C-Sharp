using Npgsql;
using System;

namespace postgrestest1
{
    class Program
    {
        static void Main(string[] args)
        {
            string instruction = string.Empty;

            Console.WriteLine("What would you like to do, select or insert?");

            instruction = Console.ReadLine();

            switch (instruction)
            {
                case "select":
                    ReadData();
                    break;

                case "insert":

                    Console.WriteLine("Enter name to insert: ");
                    string nameToInsert = Console.ReadLine();
                    Console.WriteLine("Enter age to insert: ");
                    string ageToInsert = Console.ReadLine();
                    InsertNewRow(nameToInsert, ageToInsert);
                    ReadData();
                    break;
                default:
                    break;
            }


            Console.WriteLine("Execution finished");
            Console.ReadLine();
        }

        private static void ReadData()
        {
           
            var connString = "Host=localhost;Username=robot1;Password=spectrum;Database=testdb";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                // Retrieve all rows
                using (var cmd = new NpgsqlCommand("SELECT * FROM test_table", conn))
                using (var reader = cmd.ExecuteReader())
                    while (reader.Read())
                        Console.WriteLine($"D-list Celebrity name: {reader.GetString(1)}, age:{reader.GetInt32(2).ToString()}");

            
            }
        }

        private static void InsertNewRow(string name, string age)
        {

            var connString = "Host=localhost;Username=robot1;Password=spectrum;Database=testdb";

            using (var conn = new NpgsqlConnection(connString))
            {
                conn.Open();

                bool result = int.TryParse(age, out int parsedAge);

                if (!result)
                    throw new ArgumentException("The value passed in for age was not a valid number");

                // Insert some data
                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO test_table (name, age) VALUES (@p, @p2)";
                    cmd.Parameters.AddWithValue("p", name);
                    cmd.Parameters.AddWithValue("p2", parsedAge);
                    cmd.ExecuteNonQuery();
                }
            }
            
        }
    }
}
