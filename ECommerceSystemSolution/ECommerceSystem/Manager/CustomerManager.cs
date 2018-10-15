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
        public Product GetProductByProductId(int productTypeId)
        {
            return aGateway.GetProductByProductId(productTypeId);
        }
        public string SendOrder(SalesRecord record)
        {
            string message = "";
            if (!aGateway.IsSellOrderAlreadyExist(record))
            {
                int msg=aGateway.SendOrder(record);
                if (msg>0)
                {
                    message = "Order has been successfully sent";
                }
                else
                {
                    message = "failed to send order";
                }
            }
            else
            {
                message ="You have sent order already for this product";
            }
            return message;
        }

        
    }
}