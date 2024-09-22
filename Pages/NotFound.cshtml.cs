using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Models;

namespace WebApp.Pages
{
    public class NotFoundModel : PageModel
    {
        private DataContext context;

        public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();
        public NotFoundModel(DataContext ctx)
        {
            context = ctx;
        }
        public void OnGetAsync(long id = 1)
        {
            Products = context.Products;
        }
    }
}
