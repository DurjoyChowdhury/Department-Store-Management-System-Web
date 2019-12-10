using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.Models;
using HospitalManagementSystemWebApp.Getway;

namespace DepartmentStoreManagementSystemWebApp.DAL
{
    public class BrandGetway:CommonGateway
    {
        public int SaveBrand(Brand brand)
        {
            string query = "INSERT INTO Brand VALUES('"+brand.Name+"','"+brand.Type+"')";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<Brand> GetAllBrand()
        {
            string query = "SELECT * FROM Brand";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<Brand> myList = new List<Brand>();
            while (Reader.Read())
            {
                Brand myLogIn = new Brand();
                myLogIn.Name = Reader["Name"].ToString();
                myLogIn.Type = Reader["Type"].ToString();
                myList.Add(myLogIn);

            }
            Connection.Close();
            Reader.Close();
            return myList;
        }
    }
}