using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TranTuanThinh_2031200036_Lab4.Models;

namespace TranTuanThinh_2031200036_Lab4.Controllers
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
            TempData["Menu"] = new Dictionary<string, Tuple<string, string>>
            {
                { "Home", Tuple.Create("Home", "Index") },
                { "Books", Tuple.Create("Book", "Index") },
                { "Contact", Tuple.Create("Auth", "SignUp") },
            };
            TempData["Books"] = new List<string>
            {
                "C# Basics",
                "Learning ASP.NET",
                "Bootstrap for Beginners",
                "MVC Mastery",
            };
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier,
                }
            );
        }
    }
}
