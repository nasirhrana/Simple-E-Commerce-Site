using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerceSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [DisplayName("Upoad file")]
        public string UploadFile { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [Range(0, 9, ErrorMessage = "Price should be positive")]
        public double ProductPrice { get; set; }
    }
}