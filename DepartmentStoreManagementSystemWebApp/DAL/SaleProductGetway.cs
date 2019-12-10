using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.Models;
using HospitalManagementSystemWebApp.Getway;

namespace DepartmentStoreManagementSystemWebApp.DAL
{
    public class SaleProductGetway:CommonGateway
    {
        public int GetSalesNo()
        {
           
          
                string query = "SELECT * From Customer WHERE Amount IS NULL";
                Command = new SqlCommand(query,Connection);
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

        public List<SaleProduct> GetproductByCode(int code ,int code2)
        {
            string query = "SELECT * FROM AddProduct WHERE Code ='" + code2 + "'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            List<SaleProduct> saleProducts = new List<SaleProduct>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                SaleProduct sale = new SaleProduct();
               decimal price = Convert.ToDecimal(Reader["SaleProduct"]);
                sale.Discount = Convert.ToInt32(Reader["Discount"]);
                sale.Vat = Convert.ToInt32(Reader["Vat"]);
                sale.ProductName = Reader["Name"].ToString();
                sale.ProductWeight = Reader["Weight"].ToString();
                if (sale.Discount>0 && sale.Vat>0)
                {
                    decimal vatPrice = (price * sale.Vat) / 100;
                    decimal discountPrice = (price * sale.Discount) / 100;
                    decimal perProduct = price + vatPrice - discountPrice;
                    sale.ProductPrice = perProduct * code;

                }
                else if (sale.Discount > 0 && sale.Vat < 0)
                {
                    decimal discountPrice = (price * sale.Discount) / 100;
                    decimal perProduct = price - discountPrice;
                    sale.ProductPrice = perProduct * code;

                }
                else if (sale.Discount < 0 && sale.Vat > 0)
                {
                    decimal vatPrice = (price * sale.Vat) / 100;
                   
                    decimal perProduct = price + vatPrice ;
                    sale.ProductPrice = perProduct * code;
                }
                else
                {
                    sale.ProductPrice = price * code;
                }
                saleProducts.Add(sale);
            }
            Connection.Close();
            Reader.Close();
            return saleProducts;
        }
        public int Save(SaleProduct saleProduct)
        {

            string query = "INSERT INTO SaleProductNew VALUES('" + saleProduct.SalesNo + "','" + saleProduct.ProductCode + "','" + saleProduct.Quantity + "','" + saleProduct.ProductPrice + "','" + saleProduct.Discount + "','" + saleProduct.Vat + "','" + saleProduct.ProductName + "','" + saleProduct.ProductWeight + "')";

            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public int Update(SaleProduct saleProduct)
        {

            String query2 = "SELECT * FROM AddProduct WHERE Code ='" + saleProduct.ProductCode + "'";
            Command = new SqlCommand(query2, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            AddProduct addProduct = new AddProduct();
            while (Reader.Read())
            {
                addProduct.Quantity = Convert.ToInt32(Reader["Quantity"]);
            }
            Connection.Close();
            Reader.Close();
            int value = addProduct.Quantity;
            int value2 = value - saleProduct.Quantity;


            string query = "UPDATE AddProduct SET Quantity='" + value2 + "' WHERE Code ='" + saleProduct.ProductCode + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<SaleProduct> GetProductBySalesNo(int salesNo)
        {

            string query = "SELECT * FROM SaleProductNew WHERE SalesNo ='"+salesNo+"'";
                Command = new SqlCommand(query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
                List<SaleProduct> myList = new List<SaleProduct>();
                while (Reader.Read())
                {
                    SaleProduct myLogIn = new SaleProduct();
                    myLogIn.SalesNo = Convert.ToInt32(Reader["SalesNo"]);
                    myLogIn.ProductCode = Convert.ToInt32(Reader["ProductCode"]);
                    myLogIn.Quantity = Convert.ToInt32(Reader["Quantity"]);
                    myLogIn.ProductPrice = Convert.ToDecimal(Reader["ProductPrice"]);
                    myLogIn.Discount = Convert.ToInt32(Reader["Discount"]);
                    myLogIn.Vat = Convert.ToInt32(Reader["Vat"]);
                    myLogIn.ProductName = Reader["ProductName"].ToString();
                    myLogIn.ProductWeight = Reader["ProductWeight"].ToString();

                    myList.Add(myLogIn);

                }
                Connection.Close();
                Reader.Close();
                return myList;
            
        }
        public List<SaleProduct> GetTotal(int salesNo)
        {

            string query = "SELECT * FROM SaleProductNew WHERE SalesNo ='" + salesNo + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
          List<SaleProduct> list = new List<SaleProduct>();
            SaleProduct myLogIn = new SaleProduct();
            while (Reader.Read())
            {
                decimal value = Convert.ToDecimal(Reader["ProductPrice"]);
                myLogIn.ProductPrice = myLogIn.ProductPrice + value;
            }
            Connection.Close();
            Reader.Close();
            list.Add(myLogIn);
           
            string query2 = "UPDATE Customer SET Amount='" + myLogIn.ProductPrice + "' WHERE SalesNo ='" + salesNo + "' ";
            Command= new SqlCommand(query2,Connection);
            Connection.Open();
            int row = Command.ExecuteNonQuery();
            Connection.Close();
            return list;


        }

        public List<SaleProduct> GetProductByCustomerName(string name)
        {
            string query = "SELECT * FROM Customer WHere Name='" + name + "'";
            Command= new SqlCommand(query,Connection);
            Connection.Open();
            Customer customer = new Customer();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                customer.SalesNo = Convert.ToInt32(Reader["SalesNo"]);
            }

            Connection.Close();
            Reader.Close();
            string query2 = "SELECT * FROM SaleProductNew Where SalesNo = '" + customer.SalesNo + "'";
            Command = new SqlCommand(query2,Connection);
            Connection.Open();
            List<SaleProduct> saleProducts = new List<SaleProduct>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                SaleProduct sale = new SaleProduct();
                sale.ProductPrice = Convert.ToDecimal(Reader["ProductPrice"]);
                sale.ProductName = Reader["ProductName"].ToString();
                saleProducts.Add(sale);
            }
            Connection.Close();
            Reader.Close();
            return saleProducts;
        }

        public int SavePayment(Payment payment)
        {
            string query = "INSERT INTO Payment VALUES('"+payment.CustomerName+"','"+payment.Phone+"','"+payment.Total+"','"+payment.Give+"','"+payment.Return+"')";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            int row = Command.ExecuteNonQuery();
            Connection.Close();
            return row;
        }

        public Payment GetPayment()
        {
            string query = "SELECT * FROM Payment";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Payment payment = new Payment();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                payment.CustomerName = Reader["CustomerName"].ToString();
                payment.Phone = Reader["Phone"].ToString();
                payment.Total = Convert.ToDouble(Reader["Total"]);
                payment.Give = Convert.ToDouble(Reader["Give"]);
                payment.Return = Convert.ToDouble(Reader["Return"]);
            }
            Connection.Close();
            Reader.Close();
            return payment;
        }
    }
}