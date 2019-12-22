using System;
using System.Collections.Generic;

namespace ISAD251_DatabaseApp.Models
{
    public partial class CafeProducts
    {
        public CafeProducts()
        {
            CafeOrderDetails = new HashSet<CafeOrderDetails>();
        }

        public int ProductId { get; set; }
        public string ProductType { get; set; }
        public decimal? ProductPrice { get; set; }
        public string ProductName { get; set; }
        public int? ProductCalories { get; set; }
        public string ProductDetails { get; set; }

        public ICollection<CafeOrderDetails> CafeOrderDetails { get; set; }
    }
}
