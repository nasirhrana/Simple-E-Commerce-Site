using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceSystem.Manager;
using ECommerceSystem.Models;

namespace ECommerceSystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private AdminManager adminManager=new AdminManager();

        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            ViewBag.UserType = adminManager.GetAllUserType();
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(User user)
        {
            ViewBag.UserType = adminManager.GetAllUserType();
            if (ModelState.IsValid)
            {
                ViewBag.message = adminManager.SaveUser(user);
            }
            return View();
        }
        
	}
}