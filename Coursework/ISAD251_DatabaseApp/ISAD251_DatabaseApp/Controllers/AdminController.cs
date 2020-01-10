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
using System.Net.Http;
using System.Text;

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

        // GET: CafeCustomers
        public async Task<IActionResult> Product()
        {
            return View(await _context.CafeProducts.ToListAsync());
        }

        // GET: Admin/CreateCustomer
        public ActionResult CreateCustomer()
        {
            return View();
        }

        // GET: Admin/EditCustomer/5
        public async Task<IActionResult> EditCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _context.CafeCustomers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: Admin/DeleteCustomer/5
        public async Task<IActionResult> DeleteCustomer(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var customer = await _context.CafeCustomers
                .FirstOrDefaultAsync(m => m.CustId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: Admin/CreateProduct
        public ActionResult CreateProduct()
        {
            return View();
        }

        // GET: Admin/EditProduct/5
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.CafeProducts.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Admin/DeleteProduct/5
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.CafeProducts
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Admin/CreateCustomer
        [HttpPost]
        public IActionResult CreateCustomer(CafeCustomers customer)
        {
            if (ModelState.IsValid)
            {
                AlertCreateCustomer(customer);
            }
            return View();
        }

        // POST: Admin/EditCustomer/5
        [HttpPost]
        public IActionResult EditCustomer(int id, [Bind("CustId,CustFirstName,CustSurName")] CafeCustomers customer)
        {
            if (id != customer.CustId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                AlertEditCustomer(id,customer);
            }
            return View(customer);
        }

        // POST: Admin/DeleteCustomer/5
        [HttpPost]
        public IActionResult DeleteCustomer(int id)
        {
            if (ModelState.IsValid)
            {
                string UriRoute = "customer";
                AlertDelete(id,UriRoute);
            }          
            return View();
        }

        // POST: Admin/CreateProduct
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CafeProducts product)
        {
            if (ModelState.IsValid)
            {
                CafeProducts lastProduct = _context.CafeProducts.LastOrDefault(c => c.ProductId == c.ProductId);

                if (lastProduct != null)
                {
                    product.ProductId = lastProduct.ProductId + 1;
                }
                else
                {
                    product.ProductId = 1;
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                ViewBag.Success = true;
                return View();
            }
            return View();
        }

        // POST: Admin/EditProduct/5
        [HttpPost]
        public async Task<IActionResult> EditProduct(int id, [Bind("ProductId,ProductType,ProductPrice,ProductName,ProductCalories,ProductDetails,ProductImage")] CafeProducts cafeProducts)
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
                ViewBag.Success = true;
                return View();
            }
            return View(cafeProducts);
        }

        // POST: Admin/DeleteProduct/5
        [HttpPost]
        public IActionResult DeleteProduct(int id)
        {
            if (ModelState.IsValid)
            {
                string UriRoute = "product";
                AlertDelete(id, UriRoute);
            }
            return View();
        }

        // POST: api/customer/
        private void AlertCreateCustomer(CafeCustomers customer)
        {
            string URI = "http://web.socem.plymouth.ac.uk/ISAD251/jharrison12/api/customer";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent("{\"custFirstName\":\"" + customer.CustFirstName.ToString() +
                    "\",\"custSurName\":\"" + customer.CustSurName.ToString() + "\"}", Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync(URI, content).Result;
                if (response.IsSuccessStatusCode == true)
                    ViewBag.Success = true;
            }
        }

        // PUT: api/Customer/5
        private void AlertEditCustomer(int? id, CafeCustomers customer)
        {
            string URI = "http://web.socem.plymouth.ac.uk/ISAD251/jharrison12/api/customer/" + id.ToString();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpContent content = new StringContent("{\"custID\":\"" + customer.CustId.ToString() +
                    "\",\"custFirstName\":\"" + customer.CustFirstName.ToString() +
                    "\",\"custSurName\":\"" + customer.CustSurName.ToString() + "\"}", Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PutAsync(URI, content).Result;
                if (response.IsSuccessStatusCode == true)
                    ViewBag.Success = true;
            }
        }

        // DELETE: api/customer/5
        private void AlertDelete(int id,string route)
        {
            string URI = "http://web.socem.plymouth.ac.uk/ISAD251/jharrison12/api/" + route +"/"+ id.ToString();

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new
                    System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.DeleteAsync(URI).Result;
                if (response.IsSuccessStatusCode == true)
                    ViewBag.Success = true;
                else
                    ViewBag.Success = false;
            }
        }

        private bool CafeProductsExists(int id)
        {
            return _context.CafeProducts.Any(e => e.ProductId == id);
        }
    }
}
