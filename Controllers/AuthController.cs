using Microsoft.AspNetCore.Mvc;

namespace TranTuanThinh_2031200036_Lab4.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<BookController> _logger;

        public AuthController(ILogger<BookController> logger)
        {
            _logger = logger;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
