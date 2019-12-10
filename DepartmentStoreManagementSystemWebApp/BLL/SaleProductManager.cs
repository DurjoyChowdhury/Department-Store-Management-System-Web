using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.DAL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.BLL
{
    public class SaleProductManager
    {
        SaleProductGetway mySaleProductGetway = new SaleProductGetway();

        public int GetSalesNo()
        {
            if (mySaleProductGetway.GetSalesNo()>0)
            {
                return mySaleProductGetway.GetSalesNo();
            }
            else
            {
                return mySaleProductGetway.GetSalesNo2();
            }
            
        }

        public List<SaleProduct> GetproductByCode(int code, int code2)
        {
            return mySaleProductGetway.GetproductByCode(code, code2);
        }

        public string Save(SaleProduct saleProduct)
        {
            int row = mySaleProductGetway.Save(saleProduct);
            int row2 = mySaleProductGetway.Update(saleProduct);
            if (row>0)
            {
                return "Added";
            }
            else
            {
                return "error";
            }
        }

        public List<SaleProduct> GetProductBySalesNo(int salesNo)
        {
            return mySaleProductGetway.GetProductBySalesNo(salesNo);
        }

        public List<SaleProduct> GetTotal(int salesNo)
        {
            return mySaleProductGetway.GetTotal(salesNo);
        }

        public List<SaleProduct> GetProductByCustomerName(string name)
        {
            return mySaleProductGetway.GetProductByCustomerName(name);
        }

        public string SaveReturn(Payment payment)
        {
            int row = mySaleProductGetway.SavePayment(payment);
            if (row>0)
            {
                return "Save Done";
            }
            else
            {
                return "Save Error";
            }
        }

        public Payment GetPayment()
        {
            return mySaleProductGetway.GetPayment();
        }
    }
}