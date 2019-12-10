using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.Models;
using HospitalManagementSystemWebApp.Getway;

namespace DepartmentStoreManagementSystemWebApp.DAL
{
    public class SupplierGetway:CommonGateway
    {
        public int Save(Supplier brand)
        {
            string query = "INSERT INTO Supplier VALUES('"+brand.Name+"','"+brand.Address+"','"+brand.Phone+"')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public List<Supplier> GetAllSupplier()
        {
            string query = "SELECT * FROM Supplier";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Supplier> myList = new List<Supplier>();
            while (Reader.Read())
            {
                Supplier myLogIn = new Supplier();
                myLogIn.Name = Reader["Name"].ToString();
                myLogIn.Address = Reader["Address"].ToString();
                myLogIn.Phone = Reader["Phone"].ToString();

                myList.Add(myLogIn);

            }
            Connection.Close();
            Reader.Close();
            return myList;
        }
        
    }
}