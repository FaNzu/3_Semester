using System.Diagnostics;
using DependencyInjection.Models;
using DependencyInjection.Services;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly IDummyService _dummyService; //opretter private field vi kan bruge i controller

        public HomeController(ILogger<HomeController> logger/*, IDummyService dummyService*/) //min instance af logger på dependency injection
        {
            _logger = logger;
            //_dummyService = dummyService; //sætter vores field = instance, så vi ændre field og ikke instance
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