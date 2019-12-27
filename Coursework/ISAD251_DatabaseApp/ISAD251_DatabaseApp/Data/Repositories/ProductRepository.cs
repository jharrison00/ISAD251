using ISAD251_DatabaseApp.Models;
using ISAD251_DatabaseApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISAD251_JHarrisonContext _DbContext;

        public ProductRepository(ISAD251_JHarrisonContext DbContext)
        {
            _DbContext = DbContext;
        }

        public IEnumerable<CafeProducts> Products => _DbContext.CafeProducts.Include(c => c.ProductType);

        public CafeProducts GetProductById(int productID) => _DbContext.CafeProducts.FirstOrDefault(p => p.ProductId == productID);
    }
}
