using Newtonsoft.Json;
using System;
using System.Collections.Generic;



namespace ISAD251_DatabaseApp.Models
{
    public partial class CafeOrders
    {
        public CafeOrders()
        {
            CafeOrderDetails = new HashSet<CafeOrderDetails>();
        }

        public int OrderId { get; set; }   
        public int CustId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal? OrderTotalPrice { get; set; }
        [JsonIgnore]
        public CafeCustomers Cust { get; set; }
        [JsonIgnore]
        public ICollection<CafeOrderDetails> CafeOrderDetails { get; set; }
    }
}
