using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceSystem.Gateway;
using ECommerceSystem.Models;

namespace ECommerceSystem.Manager
{
    public class SupplierManager
    {
        private SupplierGateway aSupplierGateway=new SupplierGateway();
        public List<SalesRecord> GetAllSalesRecord()
        {
            return aSupplierGateway.GetAllSalesRecord();
        }
    }
}