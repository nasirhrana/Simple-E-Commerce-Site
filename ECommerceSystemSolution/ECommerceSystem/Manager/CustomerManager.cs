using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceSystem.Gateway;
using ECommerceSystem.Models;

namespace ECommerceSystem.Manager
{
    public class CustomerManager
    {
        private CustomerGateway aGateway=new CustomerGateway();
        public List<Product> GetProductListByProductTypeId(int productTypeId)
        {
            return aGateway.GetProductListByProductTypeId(productTypeId);
        }
        public Product GetProductByProductTypeId(int productTypeId)
        {
            return aGateway.GetProductByProductTypeId(productTypeId);
        }
    }
}