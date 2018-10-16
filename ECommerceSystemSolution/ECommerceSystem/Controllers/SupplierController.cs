using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceSystem.Manager;
using ECommerceSystem.Models;

namespace ECommerceSystem.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/
        private SupplierManager aManager=new SupplierManager();
        public ActionResult Index()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
            return View();
        }
        public ActionResult GetAllOrder()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
            List<SalesRecord> salesList = aManager.GetAllSalesRecord();
            ViewBag.TotalOrder = salesList.Count;
            return View(salesList);
        }
	}
}