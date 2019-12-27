using System;
using System.Collections.Generic;

namespace ISAD251_DatabaseApp.Models
{
    public partial class CafeOrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal? ProductOrderPrice { get; set; }

        public CafeOrders Order { get; set; }
        public CafeProducts Product { get; set; }
    }
}
