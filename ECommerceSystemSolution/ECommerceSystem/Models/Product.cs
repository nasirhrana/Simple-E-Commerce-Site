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
        [DisplayName("Product Type")]
        public int ProductTypeId { get; set; }
        [Required]
        [DisplayName("Product Name")]
        public int ProductNameId { get; set; }
        [Required]
        [DisplayName("Upoad file")]
        public string UploadFile { get; set; }
        [Required]

        public string Description { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [Range(0.0, Double.MaxValue)]
        public double ProductPrice { get; set; }
    }
}