using CatalogAPI.Context;
using CatalogAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly CatalogAPIContext _context;
        public ProductsController(CatalogAPIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            if(products == null) return NotFound();
            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if(product == null) return NotFound();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (product == null) return BadRequest();
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product)
        {
            if(id != product.Id) return BadRequest();

            _context.Entry(product).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return Ok(product);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();

            _context.Remove(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }
    }
}
