using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ISAD251_DatabaseApp.Models
{
    public partial class CafeProducts
    {
        public CafeProducts()
        {
            CafeOrderDetails = new HashSet<CafeOrderDetails>();
        }

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Please enter the product type")]
        public string ProductType { get; set; }
        [Required(ErrorMessage = "Please enter the product price")]
        public decimal? ProductPrice { get; set; }
        [StringLength(20)]
        [Required(ErrorMessage = "Please enter the product name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Please enter the product calories")]
        public int? ProductCalories { get; set; }
        [Required(ErrorMessage = "Please enter the product details")]
        public string ProductDetails { get; set; }
        [JsonIgnore]
        [StringLength(100)]
        [Required(ErrorMessage = "Please enter the url of the image")]
        public string ProductImage { get; set; }
        [JsonIgnore]
        public ICollection<CafeOrderDetails> CafeOrderDetails { get; set; }
    }
}
