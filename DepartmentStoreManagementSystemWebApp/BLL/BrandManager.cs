using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.DAL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.BLL
{
    public class BrandManager
    {
        BrandGetway myGetway = new BrandGetway();
        public string SaveBrand(Brand brand)
        {
            int rowAffect = myGetway.SaveBrand(brand);
            if (rowAffect > 0)
            {
                return "Save Done";
            }
            else
            {
                return "Save Error";
            }
        }

        public List<Brand> GetAllBrand()
        {
            return myGetway.GetAllBrand();
        }
    }
}