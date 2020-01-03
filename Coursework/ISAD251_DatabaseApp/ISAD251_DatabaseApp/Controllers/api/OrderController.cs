using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISAD251_DatabaseApp.Models;

namespace ISAD251_DatabaseApp.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ISAD251_JHarrisonContext _context;

        public OrderController(ISAD251_JHarrisonContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<CafeOrders> GetCafeOrders()
        {
            return _context.CafeOrders;
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCafeOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cafeOrders = await _context.CafeOrders.FindAsync(id);

            if (cafeOrders == null)
            {
                return NotFound();
            }

            return Ok(cafeOrders);
        }

        // PUT: api/Orders/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCafeOrders([FromRoute] int id, [FromBody] CafeOrders cafeOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cafeOrders.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(cafeOrders).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeOrdersExists(id))
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

        // POST: api/Orders
        [HttpPost]
        public async Task<IActionResult> PostCafeOrders([FromBody] CafeOrders cafeOrders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CafeOrders.Add(cafeOrders);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CafeOrdersExists(cafeOrders.OrderId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCafeOrders", new { id = cafeOrders.OrderId }, cafeOrders);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafeOrders([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cafeOrders = await _context.CafeOrders.FindAsync(id);
            if (cafeOrders == null)
            {
                return NotFound();
            }

            _context.CafeOrders.Remove(cafeOrders);
            await _context.SaveChangesAsync();

            return Ok(cafeOrders);
        }

        private bool CafeOrdersExists(int id)
        {
            return _context.CafeOrders.Any(e => e.OrderId == id);
        }
    }
}