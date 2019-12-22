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
    public class CafeProductsController : Controller
    {
        private readonly ISAD251_JHarrisonContext _context;

        public CafeProductsController(ISAD251_JHarrisonContext context)
        {
            _context = context;
        }

        // GET: CafeProducts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CafeProducts.ToListAsync());
        }

        // GET: CafeProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeProducts = await _context.CafeProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (cafeProducts == null)
            {
                return NotFound();
            }

            return View(cafeProducts);
        }

        // GET: CafeProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CafeProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductType,ProductPrice,ProductName,ProductCalories,ProductDetails")] CafeProducts cafeProducts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafeProducts);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cafeProducts);
        }

        // GET: CafeProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeProducts = await _context.CafeProducts.FindAsync(id);
            if (cafeProducts == null)
            {
                return NotFound();
            }
            return View(cafeProducts);
        }

        // POST: CafeProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductType,ProductPrice,ProductName,ProductCalories,ProductDetails")] CafeProducts cafeProducts)
        {
            if (id != cafeProducts.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafeProducts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeProductsExists(cafeProducts.ProductId))
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
            return View(cafeProducts);
        }

        // GET: CafeProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeProducts = await _context.CafeProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (cafeProducts == null)
            {
                return NotFound();
            }

            return View(cafeProducts);
        }

        // POST: CafeProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafeProducts = await _context.CafeProducts.FindAsync(id);
            _context.CafeProducts.Remove(cafeProducts);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeProductsExists(int id)
        {
            return _context.CafeProducts.Any(e => e.ProductId == id);
        }
    }
}
