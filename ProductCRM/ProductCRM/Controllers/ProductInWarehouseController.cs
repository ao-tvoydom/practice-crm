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
using ProductCRM.Helpers;
using ProductCRM.Models;

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
        
        /// <summary>
        /// Get product sale trend and total sum in 15 days period based on previous 15 days
        /// </summary>
        [HttpGet("ProductSaleTrendInWarehouse/{productInWarehouseId}")]
        public async Task<ActionResult<ProductSaleTrend>> GetProductSaleTrendInWarehouse(int productInWarehouseId)
        {
            const int AnalysisPeriod = 15;
            const int PredictionPeriod = 15;

            var data = await _context.Shipments
                .Where(s => s.ShipmentStartDate > DateTime.Now.AddDays(-AnalysisPeriod))
                .Select(s => s.ShipmentContents.Where(sc => sc.ProductInWarehouseId == productInWarehouseId))
                .SelectMany(x => x)
                .GroupBy(sc => sc.Shipment.ShipmentStartDate)
                .Select(g => new {Date = g.Key, SaleSum = g.Sum(s => s.Amount)})
                .ToListAsync();

            var startDate = data.First().Date;

            var analysisData = new Dictionary<decimal, decimal>();

            for (int i = 0; i < 15; i++)
            {

                var test1 = data.Select(g => g.Date);
                if (data.Select(g => g.Date).Contains(startDate.AddDays(i)))
                {
                    
                    analysisData.Add(i,data.Single(g => g.Date == startDate.AddDays(i)).SaleSum);
                }
                else
                {
                    analysisData.Add(i, 0);
                }

            }

            var trend = new Trendline(
                analysisData.Select(a => a.Value).ToArray(),
                analysisData.Select(a => a.Key).ToArray());
            
            
            var predictionData = new Dictionary<decimal, decimal>();
            
            int sum = 0;
            
            for (int i = AnalysisPeriod; i < AnalysisPeriod + PredictionPeriod; i++)
            {

                predictionData.Add(i, trend.GetYValue(i));
                predictionData[i] = Math.Ceiling(predictionData[i]);
                sum += (int)predictionData[i];

            }

            var result = new ProductSaleTrend()
            {
                TotalToBuy = sum,
                Trend = predictionData.ToDictionary(
                    k=> (int)k.Key, 
                    k=> (int)k.Value )
            };
            
            return result;
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
