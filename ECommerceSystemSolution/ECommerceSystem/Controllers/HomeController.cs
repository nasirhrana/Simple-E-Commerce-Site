using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceSystem.Manager;
using ECommerceSystem.Models;

namespace ECommerceSystem.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private LoginManager aLoginManager=new LoginManager();

        public ActionResult Home()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["Id"] != null)
            {
                Session["Id"] = null;
                ;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel aLoginModel)
        {
            List<User> status = aLoginManager.CheckAccount(aLoginModel);
            if (status.Count() > 0)
            {
                var name = status[0].UserName;
                Session["Id"] = status[0].UserId;
                Session["user"] = name;
                Session["status"] = true;
                Session["UserType"] = status[0].UserTypeId;
                if (status[0].UserTypeId == 1)
                {
                    return RedirectToAction("Index", "Supplier");
                }
                if (status[0].UserTypeId == 2)
                {
                    return RedirectToAction("Home", "Customer");
                }
                else
                {
                    return RedirectToAction("Index", "Admin");
                }

            }
            return View();
        }

        public ActionResult LogOut()
        {
            Session["Id"] = null;
            return RedirectToAction("Login", "Home");

        }
	}
}