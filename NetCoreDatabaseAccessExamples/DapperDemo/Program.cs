using Dapper;
using DapperDemo.Model;
using Npgsql;
using System;

namespace DapperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string password; string username; string dbname; string hostname;

            Console.WriteLine("Starting the .NET Core Dapper test app");
            GetDbCredentials(out password, out username, out dbname, out hostname);

            string connString = $"Host={hostname};Database={dbname};Username={username};Password={password}";

            //We use Npgsql to set up the connection as Dapper is not concerned with db implemenation
            using (var connection = new NpgsqlConnection(connString))
            {
                //This is also npgsql
                connection.Open();

                //The .Query method is Dapper. You can use strong typing as demonstrated below.
                var rowsReturned = connection.Query<Game>("Select * from games;");

                foreach (var game in rowsReturned)
                {
                    Console.WriteLine("Game name: " + game.name);
                }

                //Insert code is also Dapper
                string sql = "INSERT INTO game (name, genre, price, platform) Values ('Total War Warhammer 2', 'Grand Strategy', 39.99, 'PC');";
                int affectedRows = connection.Execute(sql);                
                Console.WriteLine($"There were {affectedRows} rows inserted");
            }

            Console.WriteLine("End of program execution");
        }

        private static void GetDbCredentials(out string password, out string username, out string dbname, out string hostname)
        {
            Console.WriteLine("Enter hostname for db server: ");
            hostname = Console.ReadLine();
            Console.WriteLine("Enter dbname for db server: ");
            dbname = Console.ReadLine();
            Console.WriteLine("Enter username for db server: ");
            username = Console.ReadLine();
            Console.WriteLine("Enter password for db server: ");
            password = Console.ReadLine();
        }
    }
}