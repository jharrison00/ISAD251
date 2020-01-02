using ISAD251_DatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Data.Models
{
    public class AdminViewModel
    {
        public IEnumerable<CafeOrders> Orders { get; set; }
        public IEnumerable<CafeCustomers> Customers { get; set; }
        public IEnumerable<CafeProducts> Products { get; set; }
    }
}
