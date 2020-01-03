using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISAD251_DatabaseApp.Models;

namespace ISAD251_DatabaseApp.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ISAD251_JHarrisonContext _context;

        public CustomerController(ISAD251_JHarrisonContext context)
        {
            _context = context;
        }

        // GET: api/Customer
        [HttpGet]
        public IEnumerable<CafeCustomers> GetCafeCustomers()
        {
            return _context.CafeCustomers;
        }

        // GET: api/Customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCafeCustomers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cafeCustomers = await _context.CafeCustomers.FindAsync(id);

            if (cafeCustomers == null)
            {
                return NotFound();
            }

            return Ok(cafeCustomers);
        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCafeCustomers([FromRoute] int id, [FromBody] CafeCustomers cafeCustomers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cafeCustomers.CustId)
            {
                return BadRequest();
            }

            _context.Entry(cafeCustomers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeCustomersExists(id))
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

        // POST: api/Customer
        [HttpPost]
        public async Task<IActionResult> PostCafeCustomers([FromBody] CafeCustomers cafeCustomers)
        {
            //Gets last customers ID and adds by 1
            CafeCustomers lastCustomer = _context.CafeCustomers.LastOrDefault(c => c.CustId == c.CustId);

            if (lastCustomer != null)
            {
                cafeCustomers.CustId = lastCustomer.CustId + 1;
            }
            else
            {
                cafeCustomers.CustId = 1;
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CafeCustomers.Add(cafeCustomers);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CafeCustomersExists(cafeCustomers.CustId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCafeCustomers", new { id = cafeCustomers.CustId }, cafeCustomers);
        }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafeCustomers([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cafeCustomers = await _context.CafeCustomers.FindAsync(id);
            if (cafeCustomers == null)
            {
                return NotFound();
            }

            _context.CafeCustomers.Remove(cafeCustomers);
            await _context.SaveChangesAsync();

            return Ok(cafeCustomers);
        }

        private bool CafeCustomersExists(int id)
        {
            return _context.CafeCustomers.Any(e => e.CustId == id);
        }
    }
}