using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.DAL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.BLL
{
    public class SalesPersonManager
    {
        SalesPersonGetway myGetway = new SalesPersonGetway();

        public string Save(LogIn logIn)
        {
            int rowAffect = myGetway.Save(logIn);
            if (rowAffect > 0)
            {
                return "Save Done";
            }
            else
            {
                return "Error";
            }
        }

        public List<LogIn> GetAllName()
        {
            return myGetway.GetAllName();
        }

        public List<LogIn> GetAllSalesName(string name)
        {
            return myGetway.GetAllSalesName(name);
        }

        public string UpdateSalesMan(LogIn logIn)
        {
            int rowAffect = myGetway.UpdateSalesMan(logIn);
            if (rowAffect>0)
            {
                return "update Done";
            }
            else
            {
                return "Update Failed";
            }
        }

        public LogIn DeleteSalesman(string name)
        {
            
                myGetway.DeleteSalesman(name);
            return null;
        }

        public List<LogIn> GetAllSalesNameForDelete()
        {
            return myGetway.GetAllSalesNameForDelete();
        }
    }
}