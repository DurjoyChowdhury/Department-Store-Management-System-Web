using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentStoreManagementSystemWebApp.BLL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.Controllers
{
    public class RefundController : Controller
    {
        //
        // GET: /Refund/
        RefundManager myRefundManager = new RefundManager();
        AddProductManager myAddProductManager = new AddProductManager();
        [HttpGet]
        public ActionResult SaveRefund()
        {
            List<Refund> refunds = new List<Refund>()
            {
                new Refund{Id = 1,Type = "Refund"},
                new Refund{Id = 2,Type = "Damage"}
            };
            ViewBag.listnew = refunds;
            return View();
        }
        [HttpPost]
        public ActionResult SaveRefund(AddProduct addProduct, string myList)
        {
            List<Refund> refunds = new List<Refund>()
            {
                new Refund{Id = 1, Type = "Refund"},
                new Refund{Id = 2, Type = "Damage"}
            };

            ViewBag.listnew = refunds;
            ViewBag.message = myRefundManager.SaveRefund(addProduct, myList);
            return View();
        }
        public JsonResult GetData(int num)
        {
            List<AddProduct> listData = myAddProductManager.GetAddProduct(num);
            return Json(listData);
        }
        [HttpGet]
        public ActionResult ViewRefundByDate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewRefundByDate(DateTime Date1, DateTime Date2)
        {
            ViewBag.List = myRefundManager.SearchByDate(Date1, Date2);
            return View();
        }
	}
}