using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.DAL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.BLL
{
    public class LogInManager
    {
        logInGetway myGetway = new logInGetway();

        public List<LogIn> GetAllLogIn(string name)
        {
            return myGetway.GetAllLogIn(name);
        }

        public string GetType(string name)
        {
            return myGetway.GetType(name);
        }

        public List<LogIn> GetAllLogIn()
        {
            return myGetway.GetAllLogIn();
        }
    }
}