using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISAD251_DatabaseApp.Models;

namespace ISAD251_DatabaseApp.Controllers
{
    public class CafeOrderDetailsController : Controller
    {
        private readonly ISAD251_JHarrisonContext _context;

        public CafeOrderDetailsController(ISAD251_JHarrisonContext context)
        {
            _context = context;
        }

        // GET: CafeOrderDetails
        public async Task<IActionResult> Index()
        {
            var iSAD251_JHarrisonContext = _context.CafeOrderDetails.Include(c => c.Order).Include(c => c.Product);
            return View(await iSAD251_JHarrisonContext.ToListAsync());
        }

        // GET: CafeOrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeOrderDetails = await _context.CafeOrderDetails
                .Include(c => c.Order)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (cafeOrderDetails == null)
            {
                return NotFound();
            }

            return View(cafeOrderDetails);
        }

        // GET: CafeOrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.CafeOrders, "OrderId", "OrderId");
            ViewData["ProductId"] = new SelectList(_context.CafeProducts, "ProductId", "ProductId");
            return View();
        }

        // POST: CafeOrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Quantity,ProductOrderPrice")] CafeOrderDetails cafeOrderDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafeOrderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.CafeOrders, "OrderId", "OrderId", cafeOrderDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.CafeProducts, "ProductId", "ProductId", cafeOrderDetails.ProductId);
            return View(cafeOrderDetails);
        }

        // GET: CafeOrderDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeOrderDetails = await _context.CafeOrderDetails.FindAsync(id);
            if (cafeOrderDetails == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.CafeOrders, "OrderId", "OrderId", cafeOrderDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.CafeProducts, "ProductId", "ProductId", cafeOrderDetails.ProductId);
            return View(cafeOrderDetails);
        }

        // POST: CafeOrderDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,ProductId,Quantity,ProductOrderPrice")] CafeOrderDetails cafeOrderDetails)
        {
            if (id != cafeOrderDetails.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafeOrderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeOrderDetailsExists(cafeOrderDetails.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.CafeOrders, "OrderId", "OrderId", cafeOrderDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.CafeProducts, "ProductId", "ProductId", cafeOrderDetails.ProductId);
            return View(cafeOrderDetails);
        }

        // GET: CafeOrderDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeOrderDetails = await _context.CafeOrderDetails
                .Include(c => c.Order)
                .Include(c => c.Product)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (cafeOrderDetails == null)
            {
                return NotFound();
            }

            return View(cafeOrderDetails);
        }

        // POST: CafeOrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafeOrderDetails = await _context.CafeOrderDetails.FindAsync(id);
            _context.CafeOrderDetails.Remove(cafeOrderDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeOrderDetailsExists(int id)
        {
            return _context.CafeOrderDetails.Any(e => e.OrderId == id);
        }
    }
}
