using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISAD251_DatabaseApp.Models;
using ISAD251_DatabaseApp.Data.Models;
using ISAD251_DatabaseApp.Data.Interfaces;

namespace ISAD251_DatabaseApp.Controllers
{
    public class CafeOrdersController : Controller
    {
        private readonly ISAD251_JHarrisonContext _context;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderRepository _orderRepository;

        public CafeOrdersController(ISAD251_JHarrisonContext context, ShoppingCart shoppingCart,IOrderRepository orderRepository)
        {
            _context = context;
            _shoppingCart = shoppingCart;
            _orderRepository = orderRepository;
        }

        public ActionResult CheckoutConfirmation(CafeOrders order,int customerId)
        {
            //Gets shopping cart items
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            //Validation of data
            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty - please add items to confirm order.");
            }
            _orderRepository.CreateOrder(order, customerId);
            _shoppingCart.ClearCart();
            return View();
        }


        // GET: CafeOrders
        public async Task<IActionResult> Index()
        {
            var iSAD251_JHarrisonContext = _context.CafeOrders.Include(c => c.Cust);
            return View(await iSAD251_JHarrisonContext.ToListAsync());
        }

        // GET: CafeOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeOrders = await _context.CafeOrders
                .Include(c => c.Cust)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (cafeOrders == null)
            {
                return NotFound();
            }

            return View(cafeOrders);
        }

        // GET: CafeOrders/Create
        public IActionResult Create()
        {
            ViewData["CustId"] = new SelectList(_context.CafeCustomers, "CustId", "CustId");
            return View();
        }

        // POST: CafeOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustId,OrderDate,OrderTotalPrice")] CafeOrders cafeOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafeOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustId"] = new SelectList(_context.CafeCustomers, "CustId", "CustId", cafeOrders.CustId);
            return View(cafeOrders);
        }

        // GET: CafeOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeOrders = await _context.CafeOrders.FindAsync(id);
            if (cafeOrders == null)
            {
                return NotFound();
            }
            ViewData["CustId"] = new SelectList(_context.CafeCustomers, "CustId", "CustId", cafeOrders.CustId);
            return View(cafeOrders);
        }

        // POST: CafeOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustId,OrderDate,OrderTotalPrice")] CafeOrders cafeOrders)
        {
            if (id != cafeOrders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafeOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeOrdersExists(cafeOrders.OrderId))
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
            ViewData["CustId"] = new SelectList(_context.CafeCustomers, "CustId", "CustId", cafeOrders.CustId);
            return View(cafeOrders);
        }

        // GET: CafeOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeOrders = await _context.CafeOrders
                .Include(c => c.Cust)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (cafeOrders == null)
            {
                return NotFound();
            }

            return View(cafeOrders);
        }

        // POST: CafeOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafeOrders = await _context.CafeOrders.FindAsync(id);
            _context.CafeOrders.Remove(cafeOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeOrdersExists(int id)
        {
            return _context.CafeOrders.Any(e => e.OrderId == id);
        }
    }
}
