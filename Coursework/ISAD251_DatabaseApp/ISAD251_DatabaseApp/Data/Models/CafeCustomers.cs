using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ISAD251_DatabaseApp.Models
{
    public partial class CafeCustomers
    {
        public CafeCustomers()
        {
            CafeOrders = new HashSet<CafeOrders>();
        }
        
        public int CustId { get; set; }
        

        [StringLength(20)]
        [Required(ErrorMessage = "Please enter your first name")]
        public string CustFirstName { get; set; }
        [JsonIgnore]
        [StringLength(20)]
        [Required(ErrorMessage = "Please enter your last name")]
        public string CustSurName { get; set; }
        [JsonIgnore]
        public ICollection<CafeOrders> CafeOrders { get; set; }

    }
}
