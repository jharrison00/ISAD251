using System;
using System.Collections.Generic;

namespace Practical5_ASP.NETApp.Models
{
    public partial class ProductsAudit
    {
        public int AuditId { get; set; }
        public int ProductId { get; set; }
        public string ProductDetails { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
