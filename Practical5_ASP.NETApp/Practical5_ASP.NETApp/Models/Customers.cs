using System;
using System.Collections.Generic;

namespace Practical5_ASP.NETApp.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }

        public ICollection<Orders> Orders { get; set; }
    }
}
