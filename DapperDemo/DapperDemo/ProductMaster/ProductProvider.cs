using Dapper;
using DapperDemo.Database;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.ProductMaster
{
    public class ProductProvider : IProductProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public ProductProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Product>> Get()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryAsync<Product>("SELECT rowid AS Id, Name, Description FROM Product;");
        }
    }
}
