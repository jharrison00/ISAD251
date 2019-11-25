using System;
using System.Collections.Generic;

namespace Practical8_API.Models
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
