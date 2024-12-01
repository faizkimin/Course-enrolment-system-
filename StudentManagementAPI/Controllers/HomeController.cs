using Microsoft.AspNetCore.Mvc;
using StudentManagementAPI.Models;
using System.Diagnostics;

namespace StudentManagementAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult AboutUs()
        {
            return View(); 
        }

        
        public IActionResult FAQ()
        {
            return View(); 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ViewPage()
        {
            return View(); // This will look for a ViewPage.cshtml file in Views/Home/
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
