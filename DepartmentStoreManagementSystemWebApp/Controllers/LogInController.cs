using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DepartmentStoreManagementSystemWebApp.BLL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.Controllers
{
    public class LogInController : Controller
    {
        //
        LogInManager myLogInManager = new LogInManager();
        // GET: /LogIn/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LogIn logIn)
        {
            if (logIn.Name != null && logIn.Password != null)
            {
                List<LogIn> log = myLogInManager.GetAllLogIn(logIn.Name);
                if (log != null)
                {
                    foreach (LogIn l in log)
                    {

                        if (l.Type == "Admin")
                        {
                            if (l.Name == logIn.Name && l.Password == logIn.Password)
                            {
                                Session["user"] = new LogIn() { Name = logIn.Name };
                                return RedirectToAction("AdminHome", "Admin");
                            }
                            else
                            {
                                ViewBag.message = "Your Name or Password Is Wrong";
                                return View();
                            }
                        }
                        else if (l.Type == "Salesman")
                        {
                            if (l.Name == logIn.Name && l.Password == logIn.Password)
                            {
                                Session["user"] = new LogIn() { Name = logIn.Name };
                                return RedirectToAction("SalesPersonHome", "SelsPersonPanel");
                            }
                            else
                            {
                                ViewBag.message = "Your Name or Password Is Wrong";
                                return View();
                            }

                        }
                        else
                        {
                            ViewBag.message = "Your Name or Password Is Wrong";
                            return View();
                        }

                    }
                }
                else
                {
                    ViewBag.message = "Your Name or Password Is Wrong";
                    return View();
                }

               
                   

            }

            else
            {
                ViewBag.message = "Enter Your User Name && Password";
                return View();
            }

            return View();

        }
        
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LogIn");
        }
	}
}