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
    public class ProductInWarehouseController : ControllerBase
    {
        private readonly CRMDbContext _context;

        public ProductInWarehouseController(CRMDbContext context)
        {
            _context = context;
        }

        // GET: api/ProductInWarehouse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInWarehouse>>> GetProductInWarehouses()
        {
            return await _context.ProductInWarehouses.ToListAsync();
        }

        // GET: api/ProductInWarehouse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInWarehouse>> GetProductInWarehouse(int id)
        {
            var productInWarehouse = await _context.ProductInWarehouses.FindAsync(id);

            if (productInWarehouse == null)
            {
                return NotFound();
            }

            return productInWarehouse;
        }

        // PUT: api/ProductInWarehouse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductInWarehouse(int id, ProductInWarehouse productInWarehouse)
        {
            if (id != productInWarehouse.ProductInWarehouseId)
            {
                return BadRequest();
            }

            _context.Entry(productInWarehouse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInWarehouseExists(id))
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

        // POST: api/ProductInWarehouse
        [HttpPost]
        public async Task<ActionResult<ProductInWarehouse>> PostProductInWarehouse(ProductInWarehouse productInWarehouse)
        {
            _context.ProductInWarehouses.Add(productInWarehouse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductInWarehouse", new { id = productInWarehouse.ProductInWarehouseId }, productInWarehouse);
        }

        // DELETE: api/ProductInWarehouse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductInWarehouse(int id)
        {
            var productInWarehouse = await _context.ProductInWarehouses.FindAsync(id);
            if (productInWarehouse == null)
            {
                return NotFound();
            }

            _context.ProductInWarehouses.Remove(productInWarehouse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductInWarehouseExists(int id)
        {
            return _context.ProductInWarehouses.Any(e => e.ProductInWarehouseId == id);
        }
    }
}
