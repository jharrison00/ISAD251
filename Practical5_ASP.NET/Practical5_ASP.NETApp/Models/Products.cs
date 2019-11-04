using System;
using System.Collections.Generic;

namespace Practical5_ASP.NETApp.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int ProductId { get; set; }
        public string ProductDetails { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int? Reordering { get; set; }
        public int? MinimumStock { get; set; }

        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
