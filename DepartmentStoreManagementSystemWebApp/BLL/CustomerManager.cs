using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.DAL;
using DepartmentStoreManagementSystemWebApp.Models;

namespace DepartmentStoreManagementSystemWebApp.BLL
{
    public class CustomerManager
    {
        CustomerGetway myGetway = new CustomerGetway();

        public string SaveCustomer(Customer customer)
        {
            int rowAffect = myGetway.SaveCustomer(customer);
            if (rowAffect>0)
            {
                return "Save Done";
            }
            else
            {
                return "Save Error";
            }
        }

        public int GetNewCustomerId()
        {
            return myGetway.GetNewCustomerId();
        }

        public int GetSalesNo()
        {
            
            if (myGetway.GetSalesNo() > 0)
            {
                return myGetway.GetSalesNo();
            }
            else
            {
                return myGetway.GetSalesNo2();
            }
        }

        public List<Customer> GetCustomerByDate(DateTime date1, DateTime dat2)
        {
            return myGetway.GetCustomerByDate(date1, dat2);
        }

        public Customer GetCustomerForPaymment()
        {
            return myGetway.GetCustomerForPaymment();
        }

        public float ReturnTaka(int give)
        {
            Customer customer = myGetway.GetCustomerForPaymment();
            return give - customer.Amount;
        }
    }
}