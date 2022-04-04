#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Migrations.Context;
using Migrations.Entities;
using ProductCRM.Models;

namespace ProductCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplyController : ControllerBase
    {
        private readonly CRMDbContext _context;

        public SupplyController(CRMDbContext context)
        {
            _context = context;
        }

        // GET: api/Supply
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSupplies()
        {
            return await _context.Supplies.ToListAsync();
        }

        // GET: api/Supply/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Supply>> GetSupply(int id)
        {
            var supply = await _context.Supplies.FindAsync(id);

            if (supply == null)
            {
                return NotFound();
            }

            return supply;
        }
        
        [HttpGet("SuppliersStatsInPeriod/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<SupplierSupplyAmount>>> GetSupplierStatsInPeriod(DateTime startDate, DateTime endDate)
        {
            var supplyStats = await _context.Supplies
                .GroupBy(s => s.SupplierName)
                .Select(g => new SupplierSupplyAmount() {SupplierName = g.Key, SupplyAmount = g.Count()})
                .ToListAsync();
            
            if (supplyStats.IsNullOrEmpty())
            {
                return NotFound();
            }

            return supplyStats;
        }
        
        [HttpGet("SuppliesFromSupplierInPeriod/{supplierName}/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSuppliesFromSupplierInPeriod(string supplierName,DateTime startDate, DateTime endDate)
        {
            var supplies =  await _context.Supplies.Where(s=>s.Date > startDate 
                                                             && s.Date < endDate 
                                                             && s.SupplierName == "Supplier").ToListAsync();
            
            if (supplies.IsNullOrEmpty())
            {
                return NotFound();
            }

            return supplies;
        }
        
        [HttpGet("SuppliesInPeriod/{startDate}/{endDate}")]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSuppliesInPeriod(DateTime startDate, DateTime endDate)
        {
            var supplies =  await _context.Supplies.Where(s=>s.Date > startDate && s.Date < endDate).ToListAsync();
            
            if (supplies.IsNullOrEmpty())
            {
                return NotFound();
            }

            return supplies;
        }
        
        //[Route("SuppliesByMonth/{monthNumber}")]
        [HttpGet("SuppliesByMonth/{monthNumber}")]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSuppliesByMonth(int monthNumber)
        {
            var supplies =  await _context.Supplies.Where(s=>s.Date.Month == monthNumber).ToListAsync();
            
            if (supplies.IsNullOrEmpty())
            {
                return NotFound();
            }

            return supplies;
        }
        
        //[Route("SuppliesInLastHalfYear")]
        [HttpGet("SuppliesInLastHalfYear")]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSuppliesInLastHalfYear()
        {
            var supplies =  await _context.Supplies
                .Where(s=>s.Date > DateTime.Now.AddMonths(-6))
                .ToListAsync();
            
            if (supplies.IsNullOrEmpty())
            {
                return NotFound();
            }

            return supplies;
        }
        
        //[Route("SuppliesByYear/{yearNumber}")]
        [HttpGet("SuppliesByYear/{yearNumber}")]
        public async Task<ActionResult<IEnumerable<Supply>>> GetSuppliesByYear(int yearNumber)
        {
            var supplies =  await _context.Supplies.Where(s=>s.Date.Year == yearNumber).ToListAsync();
            
            if (supplies.IsNullOrEmpty())
            {
                return NotFound();
            }

            return supplies;
        }

        
        /// <summary>
        /// ProductInWarehouse - optional
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupply(int id, Supply supply)
        {
            if (id != supply.SupplyId)
            {
                return BadRequest();
            }

            _context.Entry(supply).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplyExists(id))
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
        /// ProductInWarehouse - optional
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Supply>> PostSupply(Supply supply)
        {
            _context.Supplies.Add(supply);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupply", new { id = supply.SupplyId }, supply);
        }

        // DELETE: api/Supply/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupply(int id)
        {
            var supply = await _context.Supplies.FindAsync(id);
            if (supply == null)
            {
                return NotFound();
            }

            _context.Supplies.Remove(supply);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupplyExists(int id)
        {
            return _context.Supplies.Any(e => e.SupplyId == id);
        }
    }
}
