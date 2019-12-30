using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISAD251_DatabaseApp.Models;
using ISAD251_DatabaseApp.Data.Interfaces;
using ISAD251_DatabaseApp.Data.Models;

namespace ISAD251_DatabaseApp.Controllers
{
    public class CafeCustomersController : Controller
    {
        private readonly ISAD251_JHarrisonContext _context;
        private readonly ICustomerRepository _customerRepository;

        public CafeCustomersController(ISAD251_JHarrisonContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }

        public ActionResult Checkout()
        {
            return View();
        }

        //After form is submitted
        [HttpPost]
        public ActionResult Checkout(CafeCustomers customer)
        {
            //Validation of input fields
            if (customer.CustFirstName == null || customer.CustSurName == null)
            {
                ModelState.AddModelError("", "Please fill out all of the fields.");
            }
            if (ModelState.IsValid)
            {
                customer = _customerRepository.CreateCustomer(customer);
            }
            return RedirectToAction("CheckoutOrder", "CafeOrders", new { @customerId = customer.CustId });
        }

        // GET: CafeCustomers
        public async Task<IActionResult> Index()
        {
            return View(await _context.CafeCustomers.ToListAsync());
        }

        // GET: CafeCustomers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeCustomers = await _context.CafeCustomers
                .FirstOrDefaultAsync(m => m.CustId == id);
            if (cafeCustomers == null)
            {
                return NotFound();
            }

            return View(cafeCustomers);
        }

        // GET: CafeCustomers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CafeCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustId,CustFirstName,CustSurName")] CafeCustomers cafeCustomers)
        {
            var LastEmployee = _context.CafeCustomers.OrderByDescending(c => c.CustId).FirstOrDefault();

            if (LastEmployee == null)
            {
                cafeCustomers.CustId = 1;
            }
            else
            {
                cafeCustomers.CustId = LastEmployee.CustId + 1;
            }

            if (ModelState.IsValid)
            {
                _context.Add(cafeCustomers);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cafeCustomers);
        }

        // GET: CafeCustomers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeCustomers = await _context.CafeCustomers.FindAsync(id);
            if (cafeCustomers == null)
            {
                return NotFound();
            }
            return View(cafeCustomers);
        }

        // POST: CafeCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustId,CustFirstName,CustSurName")] CafeCustomers cafeCustomers)
        {
            if (id != cafeCustomers.CustId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafeCustomers);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeCustomersExists(cafeCustomers.CustId))
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
            return View(cafeCustomers);
        }

        // GET: CafeCustomers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeCustomers = await _context.CafeCustomers
                .FirstOrDefaultAsync(m => m.CustId == id);
            if (cafeCustomers == null)
            {
                return NotFound();
            }

            return View(cafeCustomers);
        }

        // POST: CafeCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafeCustomers = await _context.CafeCustomers.FindAsync(id);
            _context.CafeCustomers.Remove(cafeCustomers);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeCustomersExists(int id)
        {
            return _context.CafeCustomers.Any(e => e.CustId == id);
        }
    }
}
