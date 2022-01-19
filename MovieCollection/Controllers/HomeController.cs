using Microsoft.AspNetCore.Mvc;
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
        private readonly ILogger<HomeController> _logger;
        private NewMovieContext _blahContext { get; set; }

        public HomeController(ILogger<HomeController> logger, NewMovieContext someName)
        {
            _logger = logger;
            _blahContext = someName;
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
            return View();
        }

        [HttpPost]
        public IActionResult MovieForm(ApplicationResponse ar)
        {
            _blahContext.Add(ar);
            _blahContext.SaveChanges();
            return View("Confirmation", ar);
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
