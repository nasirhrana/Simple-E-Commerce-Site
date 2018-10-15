using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerceSystem.Models
{
    public class SalesRecord
    {
        public int SalesRecordId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}