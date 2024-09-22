using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using WebApp.Validation;

namespace WebApp.Models
{
    [PhraseAndPrice(Phrase ="Small", Price ="100")]
    public class Product
    {
        
        public long ProductId { get; set; }
        [Required(ErrorMessage ="Please enter a value")]
        public string Name { get; set; } = string.Empty;

        //[BindNever]
        [Range(1,999999,ErrorMessage ="Please enter a positive price")]
        [Column(TypeName ="decimal(8,2)")]
       // [DisplayFormat(DataFormatString ="{0:c2}",ApplyFormatInEditMode =true)]
        public decimal Price { get; set; }

        
        [PrimaryKey(ContextType =typeof(DataContext), DataType = typeof(Category))]
        public long CategoryId { get; set; }
        
        public Category? Category { get; set; }

        [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Supplier))]
        public long SupplierId {  get; set; }

        public Supplier? Supplier { get; set; }


    }
}
