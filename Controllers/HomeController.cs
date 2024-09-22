using Microsoft.AspNetCore.Mvc;
using WebApp.Filters;
using WebApp.Models;

namespace WebApp.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        private DataContext _context;

        public HomeController(DataContext context) => _context = context;

        [ChangeArg]
        public IActionResult Index(string message1, string message2 = "None")
        {
          
                return View("Message",
                   $"{message1} - {message2}");

        }

        [RequireHttps]
        public IActionResult Secure()
        {

            return View("Message",
               "This is the Secure action on the Home controller");

        }

        public IActionResult List()
        {
            return View(_context.Products);
        }

        public IActionResult Common()
        {
            return View();
        }

        public IActionResult Html()
        {
            return View((object)"This is a <h3><i>string</i></h3>");
        }
    }
}
