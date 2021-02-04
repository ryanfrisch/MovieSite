using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieSite.Models;

namespace MovieSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult My_Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Enter_Movies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Enter_Movies(Movie movieEntered)
        {
            if (ModelState.IsValid)
            {
                TempStorage.AddMovie(movieEntered);
            }
            return View();
        }
        public IActionResult List_Movies()
        {
            return View(TempStorage.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
