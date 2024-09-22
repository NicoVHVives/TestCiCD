using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SecondController : Controller
    {
        private DataContext _context;

        public SecondController(DataContext context) => _context = context;

        public IActionResult Index()
        {
            return View("Common");
        }

    }
}
