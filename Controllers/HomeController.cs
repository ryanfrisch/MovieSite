using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieSite.Models;
using MovieSite.Models.ViewModels;

namespace MovieSite.Controllers
{
    public class HomeController : Controller
    {
        private MovieSiteContext context { get; set; }

        private readonly ILogger<HomeController> _logger;

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieSiteContext con)
        {
            _logger = logger;
            context = con;
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
            //Makes sure form was valid before storing it to our temp storage, that way invalid forms aren't accepted.
            if (ModelState.IsValid)
            {
                context.Movies.Add(movieEntered);
                context.SaveChanges();
                return View("Confirmation");
            }
            else
            {
                return View();
            }
            
        }
        public IActionResult List_Movies()
        {
            return View(new MovieListViewModel
            {
                movies = context.Movies
            });
        }

        [HttpPost]
        public IActionResult PassMovieToEdit(MovieListViewModel model)
        {
            Movie movieToEdit = context.Movies.Find(model.MovieId);

            return View("Edit_Movie", movieToEdit);
        }

        [HttpPost]
        public IActionResult Edit_Movie(Movie movieToEdit)
        {

            context.Movies.Where(m => m.MovieId == movieToEdit.MovieId).FirstOrDefault().Category = movieToEdit.Category;
            context.Movies.Where(m => m.MovieId == movieToEdit.MovieId).FirstOrDefault().Title = movieToEdit.Title;
            context.Movies.Where(m => m.MovieId == movieToEdit.MovieId).FirstOrDefault().Director = movieToEdit.Director;
            context.Movies.Where(m => m.MovieId == movieToEdit.MovieId).FirstOrDefault().Year = movieToEdit.Year;
            context.Movies.Where(m => m.MovieId == movieToEdit.MovieId).FirstOrDefault().Rating = movieToEdit.Rating;
            context.Movies.Where(m => m.MovieId == movieToEdit.MovieId).FirstOrDefault().Edited = movieToEdit.Edited;
            context.Movies.Where(m => m.MovieId == movieToEdit.MovieId).FirstOrDefault().Lent_To = movieToEdit.Lent_To;
            context.Movies.Where(m => m.MovieId == movieToEdit.MovieId).FirstOrDefault().Notes = movieToEdit.Notes;

            context.SaveChanges();

            return View("List_Movies", new MovieListViewModel
            {
                movies = context.Movies
            });
        }

        [HttpPost]
        public IActionResult Delete_Movie(MovieListViewModel model)
        {
            context.Movies.Remove(context.Movies.Find(model.MovieId));

            context.SaveChanges();

            return View("List_Movies", new MovieListViewModel
            {
                movies = context.Movies
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
