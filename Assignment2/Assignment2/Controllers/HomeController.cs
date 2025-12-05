using Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index1()
        {
            var books = new List<Book>
            {
               // URL:  Home / Index1
                new Book {id =1, Title="Principles of OOP", Author="Mofiz Mia"},
                new Book {id =2, Title="Fundamentals of physics", Author="Hero Alam"},
                new Book {id =3, Title="Calculas", Author="Ananta Jolil"}
            };
            return View(books);
        }

        public IActionResult Index()
        {
            return View();
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
