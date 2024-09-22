using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages
{
    public class EditorModel : PageModel
    {
        private DataContext _context;
        

        public Product? Product { get; set; }

        public EditorModel (DataContext context)
        {
            _context = context;
            
        }

        public async Task OnGetAsync(long id)
        {
            Product = await _context.Products.FindAsync(id);
        }

        public async Task<IActionResult> OnPostAsync(long id, decimal price)
        {
            Console.Write($"Updating {id} with price {price}");

            Product? p = await _context.Products.FindAsync(id);
            if(p != null)
            {
                p.Price = price;
            }
            await _context.SaveChangesAsync();
            return RedirectToPage();
        }
       

       
    }
}
