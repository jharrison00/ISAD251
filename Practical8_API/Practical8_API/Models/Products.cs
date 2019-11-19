using System;
using System.Collections.Generic;

namespace Practical8_API.Models
{
    public partial class Products
    {
        public int ProductId { get; set; }
        public string ProductDetails { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public int? Reordering { get; set; }
        public int? MinimumStock { get; set; }
    }
}
