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
    public class ShipmentContentController : ControllerBase
    {
        private readonly CRMDbContext _context;

        public ShipmentContentController(CRMDbContext context)
        {
            _context = context;
        }

        // GET: api/ShipmentContent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentContent>>> GetShipmentContents()
        {
            return await _context.ShipmentContents.ToListAsync();
        }

        // GET: api/ShipmentContent/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ShipmentContent>> GetShipmentContent(int id)
        {
            var shipmentContent = await _context.ShipmentContents.FindAsync(id);

            if (shipmentContent == null)
            {
                return NotFound();
            }

            return shipmentContent;
        }

        // PUT: api/ShipmentContent/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutShipmentContent(int id, ShipmentContent shipmentContent)
        {
            if (id != shipmentContent.ShipmentContentId)
            {
                return BadRequest();
            }

            _context.Entry(shipmentContent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShipmentContentExists(id))
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

        // POST: api/ShipmentContent
        [HttpPost]
        public async Task<ActionResult<ShipmentContent>> PostShipmentContent(ShipmentContent shipmentContent)
        {
            _context.ShipmentContents.Add(shipmentContent);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetShipmentContent", new { id = shipmentContent.ShipmentContentId }, shipmentContent);
        }

        // DELETE: api/ShipmentContent/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipmentContent(int id)
        {
            var shipmentContent = await _context.ShipmentContents.FindAsync(id);
            if (shipmentContent == null)
            {
                return NotFound();
            }

            _context.ShipmentContents.Remove(shipmentContent);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ShipmentContentExists(int id)
        {
            return _context.ShipmentContents.Any(e => e.ShipmentContentId == id);
        }
    }
}
