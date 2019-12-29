using ISAD251_DatabaseApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Components
{
    public class CategoryMenu: ViewComponent
    {
        private readonly ISAD251_JHarrisonContext _context;

        public CategoryMenu(ISAD251_JHarrisonContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _context.CafeProducts.Select(t => t.ProductType).Distinct().ToList();
            return View(categories);
        }
    }
}
