using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentStoreManagementSystemWebApp.BLL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.Controllers
{
    public class AdminController : Controller
    {
        
        //
        // GET: /Admin/
        [HttpGet]
        public ActionResult AdminHome()
        {
            return View();
        }

       
        
       
	}
}