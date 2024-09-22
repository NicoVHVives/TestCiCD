using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class CubedController : Controller
    {

        [TempData]
        public string? Value { get; set; }

        [TempData]
        public string? Result { get; set; }

        private DataContext _context;

        public CubedController(DataContext context)
        {
            _context = context;
        }   


        public IActionResult Index()
        {
            return View("Cubed");
        }

        public IActionResult Cube(double num)
        {
            Value = num.ToString();
            Result  = Math.Pow(num, 3).ToString();
            return RedirectToAction(nameof(Index));
        }
    }
}
