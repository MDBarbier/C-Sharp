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
                    Id = 1,
                    Name = "Skyrim",
                    Price = 19.99M,
                    Genre = "RPG"
                },
                new GameModel
                {
                    Id = 2,
                    Name = "Life is strange",
                    Price = 9.99M,
                    Genre = "Point and click"
                },
                new GameModel
                {
                    Id = 3,
                    Name = "Total War Warhammer",
                    Price = 7.99M,
                    Genre = "Strategy"
                    
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

        [Route("games/new")]
        [HttpPost]
        public ActionResult AddComment(GameModel game)
        {
            // Create an ID for this comment
            game.Id = _games.Count + 1;
            _games.Add(game);
            return Content("Success :)");
        }

    }
}
