using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using DepartmentStoreManagementSystemWebApp.Models;
using HospitalManagementSystemWebApp.Getway;

namespace DepartmentStoreManagementSystemWebApp.DAL
{
    public class AddProductGetway:CommonGateway
    {
        public int SaveAddProduct(AddProduct addProduct)
        {
            string query = "INSERT INTO AddProduct VALUES('"+addProduct.Code+"','"+addProduct.Name+"','"+addProduct.PurchaseProduct+"','"+addProduct.SaleProduct+"','"+addProduct.Brand+"','"+addProduct.Vat+"','"+addProduct.Discount+"','"+addProduct.Quantity+"','"+addProduct.Date+"','"+addProduct.Weight+"','"+addProduct.Supplier+"','"+addProduct.ReceivedBy+"')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;

        }

        public int GetNewCode()
        {
            string query = "SELECT * FROM AddProduct";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            AddProduct myProduct = new AddProduct();
            while (Reader.Read())
            {
                myProduct.Code = Convert.ToInt32(Reader["Code"]);
            }
            Connection.Close();
            Reader.Close();

            return myProduct.Code;
        }

        public List<AddProduct> GetAddProduct(int code)
        {
            string query = "SELECT * FROM AddProduct WHERE Code = '" + code + "'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AddProduct> addList = new List<AddProduct>();
            while (Reader.Read())
            {
                AddProduct add = new AddProduct();
                add.Name = Reader["Name"].ToString();
                add.PurchaseProduct = Convert.ToInt32(Reader["PurchaseProduct"]);
                add.SaleProduct = Convert.ToInt32(Reader["SaleProduct"]);
                add.Brand = Reader["Brand"].ToString();
                add.Vat = Convert.ToInt32(Reader["Vat"]);
                add.Discount = Convert.ToInt32(Reader["Discount"]);
                add.Quantity = Convert.ToInt32(Reader["Quantity"]);
                add.Date = Convert.ToDateTime(Reader["Date"]);
                add.Weight = (Reader["Weight"]).ToString();
                add.Supplier = Reader["Supplier"].ToString();
                add.ReceivedBy = Reader["ReceivedBy"].ToString();
                addList.Add(add);
            }
            Connection.Close();
            Reader.Close();
            return addList;
        }
        public int UpdateSalesMan(AddProduct logIn)
        {
            string query = "UPDATE AddProduct SET Name ='" + logIn.Name + "' ,PurchaseProduct ='" + logIn.PurchaseProduct + "', SaleProduct= '" + logIn.SaleProduct + "', Brand ='" + logIn.Brand + "', Vat= '" + logIn.Vat + "',Discount ='" + logIn.Discount + "',Quantity = '" + logIn.Quantity + "',Weight ='" + logIn.Weight + "',Supplier ='" + logIn.Supplier + "',Receivedby = '"+logIn.ReceivedBy+"' WHERE Code ='" + logIn.Code + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public int DeleteProduct(AddProduct name)
        {
            string query = "DELETE FROM AddProduct WHERE Name = '" + name.Name + "' AND Weight = '"+name.Weight+"'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public List<AddProduct> GetAddProductByBrand(string code)
        {
            string query = "SELECT * FROM AddProduct WHERE Code = '" + code + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AddProduct> addList = new List<AddProduct>();
            while (Reader.Read())
            {
                AddProduct add = new AddProduct();
                add.Name = Reader["Name"].ToString();
                add.Weight = Reader["Weight"].ToString();
                add.Quantity = Convert.ToInt32(Reader["Quantity"]);
                
                addList.Add(add);
            }
            Connection.Close();
            Reader.Close();
            return addList;
        }
        public List<AddProduct> GetWeightByName(string code)
        {
            string query = "SELECT * FROM AddProduct WHERE Name = '" + code + "'";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AddProduct> addList = new List<AddProduct>();
            while (Reader.Read())
            {
                AddProduct add = new AddProduct();
                add.Weight = Reader["Weight"].ToString();

                addList.Add(add);
            }
            Connection.Close();
            Reader.Close();
            return addList;
        }
        public List<AddProduct> GetProduct()
        {
            string query = "SELECT * FROM AddProduct ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<AddProduct> addList = new List<AddProduct>();
            while (Reader.Read())
            {
                AddProduct add = new AddProduct();
                add.Code = Convert.ToInt32(Reader["Code"]);
                add.Name = Reader["Name"].ToString();
                add.PurchaseProduct = Convert.ToInt32(Reader["PurchaseProduct"]);
                add.SaleProduct = Convert.ToInt32(Reader["SaleProduct"]);
                add.Brand = Reader["Brand"].ToString();
                add.Vat = Convert.ToInt32(Reader["Vat"]);
                add.Discount = Convert.ToInt32(Reader["Discount"]);
                add.Quantity = Convert.ToInt32(Reader["Quantity"]);
                add.Date = Convert.ToDateTime(Reader["Date"]);
                add.Weight = (Reader["Weight"]).ToString();
                add.Supplier = Reader["Supplier"].ToString();
                add.ReceivedBy = Reader["ReceivedBy"].ToString();
                addList.Add(add);
            }
            Connection.Close();
            Reader.Close();
            return addList;
        }

        public List<AddProduct> GetProductByBrandView(string brand)
        {
            string query = "SELECT * FROM AddProduct WHERE Brand = '" + brand + "'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            List<AddProduct> addProducts = new List<AddProduct>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                AddProduct addp = new AddProduct();
                addp.Name = Reader["Name"].ToString();
                addp.Code = Convert.ToInt32(Reader["Code"]);
                addp.PurchaseProduct = Convert.ToInt32(Reader["PurchaseProduct"]);
                addp.SaleProduct = Convert.ToInt32(Reader["SaleProduct"]);
                addp.Discount = Convert.ToInt32(Reader["Discount"]);
                addp.Vat = Convert.ToInt32(Reader["Vat"]);
                addp.Quantity = Convert.ToInt32(Reader["Quantity"]);
                addp.Supplier = Reader["Supplier"].ToString();
                addp.ReceivedBy = Reader["Receivedby"].ToString();
                addProducts.Add(addp);
            }
            Connection.Close();
            Reader.Close();
            return addProducts;
        }

        public int StockIn(AddProduct addProductnew, int quantity)
        {
            String query2 = "SELECT * FROM AddProduct WHERE Code ='" + addProductnew.Code + "'";
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
            int value2 = value + quantity;

            string query = "UPDATE AddProduct SET Quantity='" + value2 + "' WHERE Code ='" + addProductnew.Code + "' ";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
    }
}