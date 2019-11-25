using System;
using System.Collections.Generic;

namespace Practical8_API.Models
{
    public partial class Orders
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public Customers Customer { get; set; }
    }
}
