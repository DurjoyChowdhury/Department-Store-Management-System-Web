using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentStoreManagementSystemWebApp.BLL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.Controllers
{
    public class SaleController : Controller
    {
        SaleProductManager mySaleProductManager = new SaleProductManager();
        CustomerManager myCustomerManager = new CustomerManager();
        
        [HttpGet]
        public ActionResult SaleProduct()
        {
            ViewBag.saleno = mySaleProductManager.GetSalesNo();
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(SaleProduct saleProduct)
        {
            ViewBag.message = mySaleProductManager.Save(saleProduct);
            ViewBag.saleno = mySaleProductManager.GetSalesNo();
            ViewBag.list = mySaleProductManager.GetProductBySalesNo(saleProduct.SalesNo);
            return View();
        }
        public JsonResult GetData(int num, int num2)
        {
            List<SaleProduct> listData = mySaleProductManager.GetproductByCode(num, num2);
            return Json(listData);

        }
        public JsonResult GetTotal(int num)
        {
            List<SaleProduct> value = mySaleProductManager.GetTotal(num);
            return Json(value);

        }

        [HttpGet]
        public ActionResult Payment()
        {
            Customer customer = myCustomerManager.GetCustomerForPaymment();
            ViewBag.name = customer.Name;
            ViewBag.phone = customer.Phone;
            ViewBag.amount = customer.Amount;
            ViewBag.list = mySaleProductManager.GetProductByCustomerName(customer.Name);

            return View();
           
   
        }
        [HttpPost]
        public ActionResult Payment( Payment payment)
        {
            Customer customer = myCustomerManager.GetCustomerForPaymment();
            ViewBag.name = customer.Name;
            ViewBag.phone = customer.Phone;
            ViewBag.amount = customer.Amount;
            ViewBag.list = mySaleProductManager.GetProductByCustomerName(customer.Name);
            ViewBag.message = mySaleProductManager.SaveReturn(payment);
            return View();

        }
        public JsonResult GetReturn(int code)
        {
            float value = myCustomerManager.ReturnTaka(code);
            return Json(value);

        }
        public ActionResult Print()
        {
            Customer customer = myCustomerManager.GetCustomerForPaymment();
            Payment payment = mySaleProductManager.GetPayment();
            ViewBag.name = payment.CustomerName;
            ViewBag.phone = payment.Phone;
            ViewBag.total = payment.Total;
            ViewBag.give = payment.Give;
            ViewBag.ret = payment.Return;
           
             ViewBag.list   = mySaleProductManager.GetProductByCustomerName(customer.Name);

            return View();


        }
	}
}