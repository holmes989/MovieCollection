using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MovieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MovieCollection.Controllers
{
    public class HomeController : Controller
    {
        private NewMovieContext MoContext { get; set; }

        public HomeController(NewMovieContext someName)
        {
            MoContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts ()
        {
            return View();
        }

        [HttpGet]
        public IActionResult MovieForm ()
        {
            ViewBag.Categories = MoContext.Categories.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            if (ModelState.IsValid)
            {
                MoContext.Add(ar);
                MoContext.SaveChanges();

                return View("Confirmation", ar);
            }
            else
            {
                ViewBag.Categories = MoContext.Categories.ToList();

                return View(ar);
            }
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var applications = MoContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = MoContext.Categories.ToList();

            var application = MoContext.Responses.Single(x => x.MovieId == movieid);

            return View("MovieForm", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse ar)
        {
            MoContext.Update(ar);
            MoContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            ViewBag.Categories = MoContext.Categories.ToList();

            var application = MoContext.Responses.Single(x => x.MovieId == movieid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse ar)
        {
            MoContext.Responses.Remove(ar);
            MoContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
