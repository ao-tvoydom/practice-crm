#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Migrations.Entities;

namespace ProductCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CRMDbContext _context;

        public ProductController(CRMDbContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        /// <summary>
        /// Update a specific product by unique id |
        /// categoryIdArray - Optional
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;
            
            if (product.CategoryIdArray is not null)
            {

                if (product.CategoryIdArray.Except(_context.Categories.Select(c => c.CategoryId)).Any())
                {
                    return BadRequest("Specified category id does not exist");
                }
                
                
                foreach (var category in _context.ProductCategories.Where(c=> c.ProductId == product.ProductId))
                {
                    _context.ProductCategories.Remove(category);
                }
                
                foreach (var categoryId in product.CategoryIdArray)
                {
                    _context.ProductCategories.Add(new ProductCategory()
                          {CategoryId = categoryId, ProductId = product.ProductId});
                }
                  
            }
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Add new product |
        /// categoryIdArray - Optional
        /// </summary>
        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct( Product product)
        {
            
            
            _context.Products.Add(product);

            await _context.SaveChangesAsync();
            
            if (product.CategoryIdArray is not null)
            {
                if (product.CategoryIdArray.Except(_context.Categories.Select(c => c.CategoryId)).Any())
                {
                    return BadRequest("Specified category id does not exist");
                }
                
                foreach (var categoryId in product.CategoryIdArray)
                {
                    _context.ProductCategories.Add(new ProductCategory()
                        {CategoryId = categoryId, ProductId = product.ProductId});
                }
            }
            
            await _context.SaveChangesAsync();
            
            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
