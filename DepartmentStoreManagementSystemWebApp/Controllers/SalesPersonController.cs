using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentStoreManagementSystemWebApp.BLL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.Controllers
{
    public class SalesPersonController : Controller
    {
        SalesPersonManager myManager = new SalesPersonManager();
        //
        // GET: /SalesPerson/
        [HttpGet]
        public ActionResult SaveSalesPerson()
        {
            List<TypePerson> typePersons = new List<TypePerson>()
            {
                new TypePerson{Id=1,Name = "Admin"},
                new TypePerson{Id = 2,Name = "Salesman"}
            };
            ViewBag.list = typePersons;
            return View();
        }
        [HttpPost]
        public ActionResult SaveSalesPerson(LogIn logIn)
        {
            ViewBag.message = myManager.Save(logIn);
            List<TypePerson> typePersons = new List<TypePerson>()
            {
                new TypePerson{Id=1,Name = "Admin"},
                new TypePerson{Id = 2,Name = "Salesman"}
            };
            ViewBag.list = typePersons;
            return View();
        }
        [HttpGet]
        public ActionResult UpdateSalesPerson()
        {
            ViewBag.ListAllName = myManager.GetAllName();
            return View();
        }

        [HttpPost]
        public ActionResult UpdateSalesPerson(LogIn logIn)
        {
            ViewBag.ListAllName = myManager.GetAllName();
            ViewBag.message = myManager.UpdateSalesMan(logIn);
            return View();
        }
        public JsonResult GetAllName(string nameSales)
        {
            List<LogIn> teacher = myManager.GetAllSalesName(nameSales);
            return Json(teacher);
        }
        [HttpGet]
        public ActionResult DeleteSalesman()
        {
            ViewBag.List = myManager.GetAllSalesNameForDelete();
            return View();
        }

        [HttpPost]
        public ActionResult DeleteSalesman(string name)
        {
            ViewBag.List = myManager.GetAllSalesNameForDelete();
            myManager.DeleteSalesman(name);
           
            return View();
        }

	}
}