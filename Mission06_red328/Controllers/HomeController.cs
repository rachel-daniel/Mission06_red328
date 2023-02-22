using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission06_red328.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission06_red328.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext movieContext { get; set; }

        // Constructor
        public HomeController(MovieContext someName)
        {
            movieContext = someName; // get the information from our context file into the controller
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = movieContext.Categories.ToList();
            
            return View(new AddMovie());
        }

        // Create a new movie
        [HttpPost]
        public IActionResult MovieForm(AddMovie am)
        {
            if (ModelState.IsValid)
            {
                // make an entry in the database
                movieContext.Add(am);
                movieContext.SaveChanges();

                return View("Confirmation", am);
            }
            else
            {
                ViewBag.Categories = movieContext.Categories.ToList(); // create category class
                return View(am);
            }
        }
        
        public IActionResult DisplayMovies()
        {
            var movies = movieContext.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.CategoryID)
                .ToList();

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var movieResponse = movieContext.Movies.Single(x => x.MovieId == movieid);

            return View("MovieForm", movieResponse);
        }

        [HttpPost]
        public IActionResult Edit (AddMovie am)
        {
            movieContext.Update(am);
            movieContext.SaveChanges();

            return RedirectToAction("DisplayMovies");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movieResponse = movieContext.Movies.Single(x => x.MovieId == movieid);

            return View(movieResponse);
        }

        [HttpPost]
        public IActionResult Delete(AddMovie am)
        {
            movieContext.Movies.Remove(am);
            movieContext.SaveChanges();

            return RedirectToAction("DisplayMovies");
        }
    }
}
