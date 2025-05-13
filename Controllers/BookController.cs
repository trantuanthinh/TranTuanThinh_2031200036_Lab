using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TranTuanThinh_2031200036_Lab.DataContext;

namespace TranTuanThinh_2031200036_Lab.Controllers
{
    public class BookController(AppDataContext context, ILogger<BookController> logger) : Controller
    {
        private readonly AppDataContext _context = context;
        private readonly ILogger<BookController> _logger = logger;

        public IActionResult Index()
        {
            return View();
        }

        [Route("Book/Detail/{id}")]
        public IActionResult Detail(int id)
        {
            var book = _context
                .Books.Include(item => item.Author)
                .Include(item => item.Category)
                .FirstOrDefault(item => item.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [Route("Book/ViewAsPdf/{id}")]
        public IActionResult ViewAsPdf(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound("Book not found.");
            }

            if (string.IsNullOrEmpty(book.PDF))
            {
                return NotFound("PDF path is missing for this book.");
            }

            string pdfPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "PDF",
                book.PDF
            );
            Console.Write(pdfPath);
            if (!System.IO.File.Exists(pdfPath))
            {
                return NotFound("PDF file not found on the server.");
            }

            ViewBag.PdfUrl = "/PDF/" + book.PDF;
            ViewBag.BookTitle = book.Title;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}
