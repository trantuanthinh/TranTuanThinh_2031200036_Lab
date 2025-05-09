using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TranTuanThinh_2031200036_Lab.Models;

namespace TranTuanThinh_2031200036_Lab.Controllers
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
            var carousels = new List<Carousel>
            {
                new Carousel
                {
                    CarouselId = 1,
                    ImageUrl = "/avatar.jpg",
                    Title = "Welcome to Our Library",
                    Description = "Explore thousands of books and resources.",
                    LinkUrl = "/books",
                    Order = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                },
                new Carousel
                {
                    CarouselId = 2,
                    ImageUrl = "/avatar.jpg",
                    Title = "Author of the Month",
                    Description = "Read works by our featured author.",
                    LinkUrl = "/authors",
                    Order = 2,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                },
                new Carousel
                {
                    CarouselId = 3,
                    ImageUrl = "/avatar.jpg",
                    Title = "New Arrivals",
                    Description = "Check out the latest books in our collection.",
                    LinkUrl = "/new",
                    Order = 3,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                },
            };
            ViewData["Carousel"] = carousels;
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
