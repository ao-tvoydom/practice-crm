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

namespace ProductCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        private readonly CRMDbContext _context;

        public ShipmentController(CRMDbContext context)
        {
            _context = context;
        }

        // GET: api/Shipment
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipments()
        {
            return await _context.Shipments.ToListAsync();
        }
        
        //[Route("ShipmentsByMonth/{monthNumber}")]
        [HttpGet("ShipmentsByMonth/{monthNumber}")]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipmentsByMonth(int monthNumber)
        {
            var shipments = await _context.Shipments.Where(s=>s.ShipmentEndDate.Month == monthNumber).ToListAsync();

            if (shipments.IsNullOrEmpty())
            {
                return NotFound();
            }

            return shipments;
        }
        
        //[Route("ShipmentsInLastHalfYear")]
        [HttpGet("ShipmentsInLastHalfYear")]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipmentsInLastHalfYear()
        {
            var shipments = await _context.Shipments
                .Where(s=>s.ShipmentEndDate > DateTime.Now.AddMonths(-6))
                .ToListAsync();

            if (shipments.IsNullOrEmpty())
            {
                return NotFound();
            }

            return shipments;
        }
        
        //[Route("ShipmentsByYear/{yearNumber}")]
        [HttpGet("ShipmentsByYear/{yearNumber}")]
        public async Task<ActionResult<IEnumerable<Shipment>>> GetShipmentsByYear(int yearNumber)
        {
            var shipments =  await _context.Shipments.Where(s=>s.ShipmentEndDate.Year == yearNumber).ToListAsync();
            
            if (shipments.IsNullOrEmpty())
            {
                return NotFound();
            }

            return shipments;
        }

        // GET: api/Shipment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipment(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);

            if (shipment == null)
            {
                return NotFound();
            }

            return shipment;
        }

        // PUT: api/Shipment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipment(int id, Shipment shipment)
        {
            if (id != shipment.ShipmentId)
            {
                return BadRequest();
            }

            _context.Entry(shipment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentExists(id))
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

        // POST: api/Shipment
        [HttpPost]
        public async Task<ActionResult<Shipment>> PostShipment(Shipment shipment)
        {
            _context.Shipments.Add(shipment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipment", new { id = shipment.ShipmentId }, shipment);
        }

        // DELETE: api/Shipment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment == null)
            {
                return NotFound();
            }

            _context.Shipments.Remove(shipment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentExists(int id)
        {
            return _context.Shipments.Any(e => e.ShipmentId == id);
        }
    }
}
