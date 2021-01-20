using AutoFixture;
using DapperDemo.ProductMaster;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductProvider productProvider;
        private readonly IProductRepository productRepository;

        public async Task<IActionResult> Index()
        {
            Fixture fixture = new Fixture();
            var example = fixture.Create<Product>();
            await productRepository.Create(example);

            var data = await productProvider.Get();

            return View(data.ToList());
        }

        public ProductController(IProductProvider productProvider,
            IProductRepository productRepository)
        {
            this.productProvider = productProvider;
            this.productRepository = productRepository;
        }

        //// GET: api/<ProductController>
        //[HttpGet]
        //public async Task<IEnumerable<Product>> Get()
        //{
        //    return await productProvider.Get();
        //}


        //// POST api/<ProductController>
        //[HttpPost]
        //public async Task Post([FromBody] Product product)
        //{
        //    await productRepository.Create(product);
        //}
    }
}
