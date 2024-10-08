﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private DataContext _dataContext;

        public ProductsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IAsyncEnumerable<Product> GetProducts()
        {
            return _dataContext.Products.AsAsyncEnumerable();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(long id, [FromServices] ILogger<ProductsController> logger)
        {
            logger.LogDebug("GetProduct action invoked");
            Product? p =  await _dataContext.Products.FindAsync(id);
            if (p == null)
            {
                return NotFound();
            }

            return Ok(p);
        }

        [HttpPost]
        public async Task<IActionResult> SaveProduct(ProductBindingTarget target)
        {
           
                Product p = target.ToProduct();
                await _dataContext.Products.AddAsync(p);
                await _dataContext.SaveChangesAsync();
                return Ok(p);
            
        }

        [HttpPut]
        public async Task UpdateProduct(Product product)
        {
            _dataContext.Products.Update(product);
            await _dataContext.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task DeleteProduct(long id)
        {
            _dataContext.Products.Remove(new Product { ProductId = id });
            await _dataContext.SaveChangesAsync();
        }

        [HttpGet("redirect")]
        public IActionResult Redirect()
        {
            //return RedirectToAction(nameof(GetProduct),new { Id = 1 });

            return RedirectToRoute(new { controller = "Products", Action="GetProduct", Id = 5 });
        }
    }
}
