using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentStoreManagementSystemWebApp.BLL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        CustomerManager myCustomerManager = new CustomerManager();
        [HttpGet]
        public ActionResult SaveCustomer()
        {
            ViewBag.customerId = myCustomerManager.GetNewCustomerId();
            ViewBag.customerSalesNo = myCustomerManager.GetSalesNo();
            return View();
        }
        [HttpPost]
        public ActionResult SaveCustomer(Customer customer)
        {
            ViewBag.message = myCustomerManager.SaveCustomer(customer);
            ViewBag.customerId = myCustomerManager.GetNewCustomerId();
            ViewBag.customerSalesNo = myCustomerManager.GetSalesNo();
            return View();
        }
        [HttpGet]
        public ActionResult ViewCustomerByDate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ViewCustomerByDate(DateTime date1, DateTime date2)
        {
            ViewBag.list = myCustomerManager.GetCustomerByDate(date1, date2);
            return View();
        }
	}
}