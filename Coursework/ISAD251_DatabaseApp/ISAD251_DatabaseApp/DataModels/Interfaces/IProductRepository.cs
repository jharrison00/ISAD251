using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Models.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<CafeProducts> Products { get; }

        CafeProducts GetProductById(int ProductID);
    }
}
