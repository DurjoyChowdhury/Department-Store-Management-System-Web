using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using DepartmentStoreManagementSystemWebApp.Models;
using HospitalManagementSystemWebApp.Getway;

namespace DepartmentStoreManagementSystemWebApp.DAL
{
    public class CustomerGetway:CommonGateway
    {
        public int SaveCustomer(Customer customer)
        {
            string query ="INSERT INTO Customer (CustomerId,SalesNo,Date,Name,Address,Phone) VALUES('"+customer.CustomerId+"','"+customer.SalesNo+"','"+customer.Date+"','"+customer.Name+"','"+customer.Address+"','"+customer.Phone+"')";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int GetNewCustomerId()
        {
            string query = "SELECT * FROM Customer";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            Customer cu = new Customer();
            while (Reader.Read())
            {
                cu.CustomerId = Convert.ToInt32(Reader["CustomerId"]);
            }
            Connection.Close();
            Reader.Close();
            return cu.CustomerId+1;
        }
        public int GetSalesNo()
        {
            string query = "SELECT * From Customer WHERE Amount IS NULL";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Customer customer = new Customer();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                customer.SalesNo = Convert.ToInt32(Reader["SalesNo"]);
            }
            Connection.Close();
            Reader.Close();
            return customer.SalesNo;
        }
        public int GetSalesNo2()
        {
            string query = "SELECT * From Customer";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Customer customer = new Customer();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                customer.SalesNo = Convert.ToInt32(Reader["SalesNo"]);
            }
            Connection.Close();
            Reader.Close();
            return customer.SalesNo+1;
        }

        public List<Customer> GetCustomerByDate(DateTime date1, DateTime dat2)
        {
            string query = "SELECT * from Customer Where Date between '" + date1 + "' And '" + dat2 + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            List<Customer> reList = new List<Customer>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Customer refund = new Customer();
                refund.CustomerId = Convert.ToInt32(Reader["CustomerId"]);
                refund.Name = Reader["Name"].ToString();
                refund.Address = Reader["Address"].ToString();
                refund.Phone = Reader["Phone"].ToString();
                refund.Amount = Convert.ToInt32(Reader["Amount"]);
                refund.SalesNo = Convert.ToInt32(Reader["SalesNo"]);
                reList.Add(refund);
            }
            Connection.Close();
            Reader.Close();
            return reList;
        }
        public Customer GetCustomerForPaymment( )
        {
            string query = "SELECT * from Customer ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
           
            Customer refund = new Customer();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                
                refund.CustomerId = Convert.ToInt32(Reader["CustomerId"]);
                refund.Name = Reader["Name"].ToString();
                refund.Address = Reader["Address"].ToString();
                refund.Phone = Reader["Phone"].ToString();
                refund.Amount = Convert.ToInt32(Reader["Amount"]);
                refund.SalesNo = Convert.ToInt32(Reader["SalesNo"]);
                
            }
            Connection.Close();
            Reader.Close();
            return refund;
        }
    }
}