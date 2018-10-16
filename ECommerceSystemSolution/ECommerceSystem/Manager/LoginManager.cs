using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ECommerceSystem.Gateway;
using ECommerceSystem.Models;

namespace ECommerceSystem.Manager
{
    public class LoginManager
    {
        private LoginGateway aLoginGateway=new LoginGateway();

        public List<User> CheckAccount(LoginModel aLoginModel)
        {
            return aLoginGateway.CheckAccount(aLoginModel);
        }
    }
}