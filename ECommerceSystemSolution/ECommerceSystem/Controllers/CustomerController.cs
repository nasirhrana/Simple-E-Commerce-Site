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

        public ActionResult Home()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
            return View();
        }
        public ActionResult Index()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
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
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
            Product product = aCustomerManager.GetProductByProductId(id);
            SalesRecord record=new SalesRecord();
            record.ProductId = product.ProductId;
            record.CustomerId = 2;
            if (ModelState.IsValid)
            {
                Session["msg"] = aCustomerManager.SendOrder(record);
            }
             

            return RedirectToAction("Index");
        }
	}
}