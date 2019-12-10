using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.Models;
using HospitalManagementSystemWebApp.Getway;

namespace DepartmentStoreManagementSystemWebApp.DAL
{
    public class RefundGetway:CommonGateway
    {
        public int SaveRefund(AddProduct addProduct, string type)
        {
            string query = "INSERT INTO RefundProduct VALUES('" + addProduct.Code + "','" + addProduct.Name + "','" + addProduct.Brand + "','" + addProduct.Weight + "','" + addProduct.Quantity + "','" + addProduct.Date + "','" + type + "')";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
           int rowAffect= Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public int UpdateProduct(AddProduct logIn)
        {
            String query2 = "SELECT * FROM AddProduct WHERE Code ='"+logIn.Code+"'";
            Command = new SqlCommand(query2,Connection);
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
            int value2 = value + logIn.Quantity;


            string query = "UPDATE AddProduct SET Quantity='"+value2+"' WHERE Code ='" + logIn.Code + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<Refund> SearchByDate(DateTime time,DateTime time2)
        {
            string query = "SELECT * from RefundProduct Where Date between '" + time + "' And '"+time2+"' ";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            List<Refund> reList = new List<Refund>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                Refund refund = new Refund();
                refund.Code = Convert.ToInt32(Reader["Code"]);
                refund.Name = Reader["Name"].ToString();
                refund.Brand = Reader["Brand"].ToString();
                refund.Weight = Reader["Weight"].ToString();
                refund.Quentity = Convert.ToInt32(Reader["Quantity"]);
                refund.Type = Reader["Type"].ToString();
                reList.Add(refund);
            }
            Connection.Close();
            Reader.Close();
            return reList;
        }
    }
}