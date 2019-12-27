using ISAD251_DatabaseApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAD251_DatabaseApp.Data.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public CafeProducts Products { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartID { get; set; }
    }
}
