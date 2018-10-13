using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceSystem.Gateway;
using ECommerceSystem.Models;

namespace ECommerceSystem.Manager
{
    public class AdminManager
    {
        private AdminGateway adminGateway=new AdminGateway();

        public List<UserType> GetAllUserType()
        {
            return adminGateway.GetAllUserType();
        }

        public string SaveUser(User user)
        {
            int msg = adminGateway.SaveUser(user);
            if (msg>0)
            {
                return "User has been saved successfully";
            }
            else
            {
                return "Failed to save User";
            }
        }
    }
}