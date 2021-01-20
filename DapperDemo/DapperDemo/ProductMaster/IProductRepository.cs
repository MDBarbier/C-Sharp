using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.ProductMaster
{
    public interface IProductRepository
    {
        Task Create(Product product);
    }
}
