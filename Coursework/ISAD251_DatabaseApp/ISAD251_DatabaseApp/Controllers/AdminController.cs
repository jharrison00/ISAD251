using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISAD251_DatabaseApp.Models;
using ISAD251_DatabaseApp.Models.Interfaces;
using ISAD251_DatabaseApp.Data.Models;
using ISAD251_DatabaseApp.Data.Interfaces;

namespace ISAD251_DatabaseApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISAD251_JHarrisonContext _context;

        public AdminController(ISAD251_JHarrisonContext context)
        {
            _context = context;
        }

        public ViewResult Index()
        {
            var adminViewModel = new AdminViewModel
            {
                Customers = _context.CafeCustomers,
                Orders = _context.CafeOrders,
                Products = _context.CafeProducts
            };

            return View(adminViewModel);
        }
        // GET: CafeOrders
        public async Task<IActionResult> Order()
        {
            var iSAD251_JHarrisonContext = _context.CafeOrders.Include(c => c.Cust);
            return View(await iSAD251_JHarrisonContext.ToListAsync());
        }

        // GET: CafeCustomers
        public async Task<IActionResult> Customer()
        {
            return View(await _context.CafeCustomers.ToListAsync());
        }


        public async Task<IActionResult> Product()
        {
            return View(await _context.CafeProducts.ToListAsync());
        }

    }
}