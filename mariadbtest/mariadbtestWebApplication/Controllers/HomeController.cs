using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mariadbtestWebApplication.Models;
using MySql.Data.MySqlClient;

namespace mariadbtestWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //This row uses setup in the Startup.cs file
            FamilyContext fc = HttpContext.RequestServices.GetService(typeof(FamilyContext)) as FamilyContext;

            //Get a list of data
            var family = fc.GetFamily();

            //Pass list to the view as Model
            return View(family);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
