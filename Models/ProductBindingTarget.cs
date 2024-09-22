using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ProductBindingTarget
    {
        [Required]
        public string Name { get; set; } = String.Empty;
        [Range(1,1000)]
        public decimal Price { get; set; }
        [Range(1, long.MaxValue)]
        public long CategoryId { get; set; }
        [Range(1, long.MaxValue)]
        public long Supplierid { get; set; }    

        public Product ToProduct() => new Product { Name = this.Name, Price = this.Price, CategoryId = this.CategoryId, SupplierId = this.Supplierid };
    }
}
