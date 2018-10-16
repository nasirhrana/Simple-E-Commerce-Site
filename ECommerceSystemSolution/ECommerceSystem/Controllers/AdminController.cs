using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ECommerceSystem.Manager;
using ECommerceSystem.Models;
using ECommerceSystem.ViewModel;

namespace ECommerceSystem.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/
        private AdminManager adminManager=new AdminManager();

        public ActionResult Index()
        {

            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
            return View();
        }
        [HttpGet]
        public ActionResult CreateUser()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
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
        [HttpGet]
        public ActionResult CreateProduct()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
            ViewBag.ProductCode = adminManager.GetAllProductCode();
            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product, HttpPostedFileBase UploadFile)
        {
            ViewBag.ProductCode = adminManager.GetAllProductCode();
            if (UploadFile != null)
            {
                if (UploadFile.ContentType == "image/jpeg" || UploadFile.ContentType == "image/png" || UploadFile.ContentType == "image/gif")
                {
                    var productId = product.ProductId;
                    string imageUrl = "";
                    var imageType = UploadFile.ContentType;
                    if (imageType == "image/jpeg")
                    {
                        imageUrl = productId + ".Jpg";
                    }
                    if (imageType == "image/png")
                    {
                        imageUrl = productId + ".png";
                    }
                    if (imageType == "image/gif")
                    {
                        imageUrl = productId + ".gif";
                    }

                    UploadFile.SaveAs(Server.MapPath("/") + "/UploadFile/" + imageUrl);
                    product.UploadFile = imageUrl;
                }
                else
                {
                    return View();
                }


                try
                {
                    if (ModelState.IsValid)
                    {
                        ViewBag.Message = adminManager.SaveProduct(product);
                    }


                }
                catch (Exception exception)
                {
                    ViewBag.Message = exception.Message;
                }
            }
            return View();
        }

        public ActionResult GetProductNameByProductTypeId(int productTypeId)
        {
            var productList = adminManager.GetProductNameByProductTypeId(productTypeId);
            return Json(productList.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetAllOrder()
        {
            if (Session["Id"] == null)
            {
                return RedirectToAction("Login", "Home");
                ;
            }
            List<SalesRecord> salesList = adminManager.GetAllSalesRecord();
            ViewBag.TotalOrder = salesList.Count;
            return View(salesList);
        }
        
	}
}