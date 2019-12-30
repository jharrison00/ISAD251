using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISAD251_DatabaseApp.Models
{
    public partial class CafeCustomers
    {
        public CafeCustomers()
        {
            CafeOrders = new HashSet<CafeOrders>();
        }
        
        public int CustId { get; set; }
        
        [Required(ErrorMessage = "Please enter your first name")]
        [StringLength(20)]
        public string CustFirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name")]
        [StringLength(20)]
        public string CustSurName { get; set; }

        public ICollection<CafeOrders> CafeOrders { get; set; }

    }
}
