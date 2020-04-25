using EFCore.Database;
using EFCore.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace EFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string password; string username; string dbname; string hostname;

            Console.WriteLine("Starting the .NET Core Ef Core test app");

            GetDbCredentials(out password, out username, out dbname, out hostname);

            DataContext dc = new DataContext(username, password, dbname, hostname);

            //Querying tables can be done with Linq
            var games = dc.games.ToList();
            var dlcs = dc.dlcs.ToList();
            var lists = dc.lists.Where(a => !string.IsNullOrEmpty(a.contents_json)).ToList();            
            EnumerateRecordsToConsole(games, dlcs, lists);

            //Inserting a record can be done by Adding a instance of the model class
            var addedRecord = dc.games.Add(new Game() { name = "Total War Warhammer 2", genre = "Grand Strategy", platform = "PC", price = 30.99m });
            
            //Save changes to commit insert
            dc.SaveChanges();

            Console.WriteLine($"Game with name {addedRecord.Entity.name} was added");

            Console.WriteLine("Execution finished");            
        }

        private static void EnumerateRecordsToConsole(List<Game> games, List<Dlc> dlcs, List<List> lists)
        {
            Console.WriteLine("\nEnumerate games:");
            foreach (var game in games)
            {
                Console.WriteLine($"Game name: {game.name}");
            }

            Console.WriteLine("\nEnumerate dlcs:");
            foreach (var dlc in dlcs)
            {
                Console.WriteLine($"DLC name: {dlc.name}");
            }

            Console.WriteLine("\nEnumerate lists:");
            foreach (var list in lists)
            {
                Console.WriteLine($"list name: {list.name}");
            }
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
