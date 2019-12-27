using System;
using System.Collections.Generic;

namespace ISAD251_DatabaseApp.Models
{
    public partial class CafeCustomers
    {
        public CafeCustomers()
        {
            CafeOrders = new HashSet<CafeOrders>();
        }

        public int CustId { get; set; }
        public string CustFirstName { get; set; }
        public string CustSurName { get; set; }

        public ICollection<CafeOrders> CafeOrders { get; set; }

        public static implicit operator int(CafeCustomers v)
        {
            throw new NotImplementedException();
        }
    }
}
