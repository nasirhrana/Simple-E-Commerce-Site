using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceSystem.Manager;
using ECommerceSystem.Models;

namespace ECommerceSystem.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        private AdminManager adminManager=new AdminManager();
        private CustomerManager aCustomerManager=new CustomerManager();
        public ActionResult Index()
        {
            ViewBag.ProductCode = adminManager.GetAllProductCode();
            return View();
        }

        public ActionResult GetProductByProductTypeId(int productTypeId)
        {
            var productList = aCustomerManager.GetProductListByProductTypeId(productTypeId);
            return Json(productList.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SellOrder(int id)
        {
            Product product = aCustomerManager.GetProductByProductTypeId(id);

            return null;
        }
	}
}