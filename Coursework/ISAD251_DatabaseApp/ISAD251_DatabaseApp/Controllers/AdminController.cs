﻿using System;
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
using System.Net.Http;
using System.Text;

namespace ISAD251_DatabaseApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ISAD251_JHarrisonContext _context;
        private readonly ICustomerRepository _customerRepository;

        public AdminController(ISAD251_JHarrisonContext context, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
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

        public ActionResult CreateCustomer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCustomer(CafeCustomers customer)
        {
            if (ModelState.IsValid)
            {
                Alert(customer);
                CafeCustomers newCustomer = _context.CafeCustomers.LastOrDefault(c => c.CustId == c.CustId);
                ViewBag.Success = newCustomer;
            }
            return View();
        }

        private void Alert(CafeCustomers customer)
        {

            string URI = "https://localhost:44371/api/customer";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent("{\"custFirstName\":\"" + customer.CustFirstName.ToString() + "\",\"custSurName\":\"" + customer.CustSurName.ToString() + "\"}",Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(URI, content).Result;
            }

        }
    }
}