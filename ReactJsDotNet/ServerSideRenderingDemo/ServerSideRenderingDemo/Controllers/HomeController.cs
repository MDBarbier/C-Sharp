using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServerSideRenderingDemo.Models;

namespace ServerSideRenderingDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            IList<Model> model = new List<Model>
            {
                new Model
                {

                Id = 1,
                Name = "Matt Barbier",
                Age = 36
                },
                new Model
                {

                Id = 2,
                Name = "Heather Barbier",
                Age = 37
                }
            };
            return View(model);
        }
       
    }
}
