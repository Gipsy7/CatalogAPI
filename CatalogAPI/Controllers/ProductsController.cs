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
            try
            {
                var products = await _context.Products.AsNoTracking().Take(20).ToListAsync();
                if (products == null) return NotFound("Produto não encontrado...");
                return Ok(products);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int}", Name = "GetProduct")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound("Produto não encontrado...");
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                if (product == null) return BadRequest("Dados inválidos");
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                return new CreatedAtRouteResult("GetProduct", new { id = product.Id }, product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
           
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> PutProduct(int id, Product product)
        {
            try
            {
                if (id != product.Id) return BadRequest("Dados inválidos");

                _context.Entry(product).State = EntityState.Modified;

                await _context.SaveChangesAsync();

                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
            
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product == null) return NotFound("Produto não encontrado...");

                _context.Remove(product);
                await _context.SaveChangesAsync();
                return Ok(product);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um problema ao tratar a sua solicitação.");
            }
            
        }
    }
}
