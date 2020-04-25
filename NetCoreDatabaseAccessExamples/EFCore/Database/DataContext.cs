using EFCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace EFCore.Database
{
    class DataContext : DbContext
    {
        public DbSet<Game> games { get; set; }
        public DbSet<Dlc> dlcs { get; set; }
        public DbSet<List> lists { get; set; }

        private string _username;
        private string _password;
        private string _dbname;
        private string _hostname;

        public DataContext(string username, string password, string dbname, string hostname)
        {
            _username = username;
            _dbname = dbname;
            _hostname = hostname;
            _password = password;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql($"Host={_hostname};Database={_dbname};Username={_username};Password={_password}");
    }
}
