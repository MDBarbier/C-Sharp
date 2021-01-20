using Dapper;
using DapperDemo.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.ProductMaster
{
    public class ProductRepository : IProductRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public ProductRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Create(Product product)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO Product (Name, Description)" +
                "VALUES (@Name, @Description);", product);
        }
    }
}
