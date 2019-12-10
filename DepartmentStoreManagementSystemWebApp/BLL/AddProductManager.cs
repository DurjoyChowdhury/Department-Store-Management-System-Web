using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.DAL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.BLL
{
    public class AddProductManager
    {
        AddProductGetway myGetway = new AddProductGetway();
        public string SaveAddProduct(AddProduct addProduct)
        {
            int rowA = myGetway.SaveAddProduct(addProduct);
            if (rowA > 0)
            {
                return "Save Done";
            }
            else
            {
                return "Save Error";
            }
        }

        public int GetNewCode()
        {
            int num =myGetway.GetNewCode() + 1;
            return num;

        }

        public List<AddProduct> GetAddProduct(int code)
        {
            return myGetway.GetAddProduct(code);
        }

        public string UpdateSalesMan(AddProduct logIn)
        {
            int rowA = myGetway.UpdateSalesMan(logIn);
            if (rowA > 0)
            {
                return "Upadate Done";
            }
            else
            {
                return "Update Error";
            }
        }

        public string DeleteProduct(AddProduct name)
        {
            int rowA = myGetway.DeleteProduct(name);
            if (rowA > 0)
            {
                return "Delete Done";
            }
            else
            {
                return "Delete Error";
            }
        }

        public List<AddProduct> GetAddProductByBrand(string code)
        {
            return myGetway.GetAddProductByBrand(code);
        }

        public List<AddProduct> GetWeightByName(string code)
        {
            return myGetway.GetWeightByName(code);
        }

        public List<AddProduct> GetProduct()
        {
            return myGetway.GetProduct();
        }

        public List<AddProduct> GetProductByBrandView(string brand)
        {
            return myGetway.GetProductByBrandView(brand);
        }

        public string StockIn(AddProduct addProductnew, int quantity)
        {
            int row = myGetway.StockIn(addProductnew,quantity);
            if (row>0)
            {
                return "Stock In Done";
            }
            else
            {
                return "Stock In Error";
            }
        }
    }
}