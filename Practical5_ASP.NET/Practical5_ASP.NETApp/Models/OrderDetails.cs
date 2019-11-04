using System;
using System.Collections.Generic;

namespace Practical5_ASP.NETApp.Models
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? LineTotal { get; set; }

        public Products Product { get; set; }
    }
}
