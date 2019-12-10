using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.DAL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.BLL
{
    public class RefundManager
    {
        RefundGetway myRefundGetway = new RefundGetway();

        public string SaveRefund(AddProduct addProduct, string type)
        {
            int rowAffect = myRefundGetway.SaveRefund(addProduct, type);
            if (rowAffect>0)
            {
                if (type == "Refund")
                {
                    int row = myRefundGetway.UpdateProduct(addProduct);
                    if (row >0)
                    {
                        return "Update Done";
                    }
                    else
                    {
                        return "Update Error";
                    }
                }
                else
                {
                    return "ERROR";
                }
            }
            else
            {
                return "Error";
            }
        }

        public List<Refund> SearchByDate(DateTime time, DateTime time2)
        {
            return myRefundGetway.SearchByDate(time, time2);
        }
    }
}