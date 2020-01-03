using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ISAD251_DatabaseApp.Models;

namespace ISAD251_DatabaseApp.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISAD251_JHarrisonContext _context;

        public ProductController(ISAD251_JHarrisonContext context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<CafeProducts> GetCafeProducts()
        {
            return _context.CafeProducts;
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCafeProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cafeProducts = await _context.CafeProducts.FindAsync(id);

            if (cafeProducts == null)
            {
                return NotFound();
            }

            return Ok(cafeProducts);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCafeProducts([FromRoute] int id, [FromBody] CafeProducts cafeProducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cafeProducts.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(cafeProducts).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CafeProductsExists(id))
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

        // POST: api/Product
        [HttpPost]
        public async Task<IActionResult> PostCafeProducts([FromBody] CafeProducts cafeProducts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.CafeProducts.Add(cafeProducts);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CafeProductsExists(cafeProducts.ProductId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCafeProducts", new { id = cafeProducts.ProductId }, cafeProducts);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCafeProducts([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cafeProducts = await _context.CafeProducts.FindAsync(id);
            if (cafeProducts == null)
            {
                return NotFound();
            }

            _context.CafeProducts.Remove(cafeProducts);
            await _context.SaveChangesAsync();

            return Ok(cafeProducts);
        }

        private bool CafeProductsExists(int id)
        {
            return _context.CafeProducts.Any(e => e.ProductId == id);
        }
    }
}