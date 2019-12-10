using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.DAL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.BLL
{
    public class SupplierManager
    {
        SupplierGetway myGetway = new SupplierGetway();

        public string Save(Supplier supplier)
        {
            int rowA = myGetway.Save(supplier);
            if (rowA > 0)
            {
                return "Save Done";
            }
            else
            {
                return "Save Error";
            }
        }
        public List<Supplier> GetAllSupplier()
        {
            return myGetway.GetAllSupplier();
        }
    }
}