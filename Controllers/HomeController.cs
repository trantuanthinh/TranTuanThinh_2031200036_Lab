using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranTuanThinh_2031200036_Lab.DataContext;
using TranTuanThinh_2031200036_Lab.Models;

namespace TranTuanThinh_2031200036_Lab.Controllers
{
    public class HomeController(AppDataContext context, ILogger<HomeController> logger) : Controller
    {
        private readonly AppDataContext _context = context;
        private readonly ILogger<HomeController> _logger = logger;

        public IActionResult Index()
        {
            var carousels = new List<Carousel>
            {
                new Carousel
                {
                    Id = 1,
                    ImageUrl = "/avatar17.jpg",
                    Title = "Welcome to Our Library",
                    Description = "Explore thousands of books and resources.",
                    LinkUrl = "/books",
                    Order = 1,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                },
                new Carousel
                {
                    Id = 2,
                    ImageUrl = "/avatar17.jpg",
                    Title = "Author of the Month",
                    Description = "Read works by our featured author.",
                    LinkUrl = "/authors",
                    Order = 2,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                },
                new Carousel
                {
                    Id = 3,
                    ImageUrl = "/avatar17.jpg",
                    Title = "New Arrivals",
                    Description = "Check out the latest books in our collection.",
                    LinkUrl = "/new",
                    Order = 3,
                    IsActive = true,
                    CreatedDate = DateTime.Now,
                },
            };
            ViewData["Carousel"] = carousels;

            // ViewData["Carousel"] = _context.Carousels.ToList();
            var categories = _context.Categories.ToList();
            var menu = new Dictionary<string, Tuple<string, string>>
            {
                { "Home", Tuple.Create("Home", "Index") },
                { "Admin", Tuple.Create("Home", "Index") },
            };

            foreach (var category in categories)
            {
                menu.Add(category.Name, Tuple.Create("Book", "Index"));
            }
            ViewData["Menu"] = menu;

            var books = _context.Books.Include(item => item.Author).ToList();
            ViewData["Books"] = books;
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
