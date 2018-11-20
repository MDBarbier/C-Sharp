using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo2.Models;

namespace Demo2.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IList<GameModel> _games;

        static HomeController()
        {
            _games = new List<GameModel>
            {
                new GameModel
                {
                    Name = "Skyrim",
                    Price = 19.99M,
                    Genre = "RPG",
                    Rating = 9
                },
                new GameModel
                {
                    Name = "Life is strange",
                    Price = 9.99M,
                    Genre = "Point and click",
                    Rating = 8
                },
                new GameModel
                {
                    Name = "Total War Warhammer",
                    Price = 7.99M,
                    Genre = "Strategy",
                    Rating = 9
                }
            };

        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("games")]
        [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Comments()
        {
            return Json(_games);
        }
    }
}
