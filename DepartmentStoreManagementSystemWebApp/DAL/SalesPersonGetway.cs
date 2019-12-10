using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.Models;
using HospitalManagementSystemWebApp.Getway;

namespace DepartmentStoreManagementSystemWebApp.DAL
{
    public class SalesPersonGetway:CommonGateway
    {
        public int Save(LogIn logIn)
        {
           
            string query = "INSERT INTO LogIn VALUES('"+logIn.Name+"','"+logIn.PresentAddress+"','"+logIn.PermanentAddress+"','"+logIn.Email+"','"+logIn.DateOfBirth+"','"+logIn.NID+"','"+logIn.Phone+"','"+logIn.Password+"','"+logIn.Type+"','"+logIn.Date+"')";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public List<LogIn> GetAllName()
        {
            string query = "SELECT * FROM LogIn";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<LogIn> myList = new List<LogIn>();
            while (Reader.Read())
            {
                LogIn myLogIn = new LogIn();
                myLogIn.Name = Reader["Name"].ToString();
                myList.Add(myLogIn);

            }
            Connection.Close();
            Reader.Close();
            return myList;
        }

        public List<LogIn> GetAllSalesName(string name)
        {
            string query = "SELECT * FROM LogIn WHERE Name = '"+name+"'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<LogIn> muList = new List<LogIn>();
            while (Reader.Read())
            {
                LogIn logIn = new LogIn();
                logIn.Name = Reader["Name"].ToString();
                logIn.PresentAddress = Reader["PresentAddress"].ToString();
                logIn.PermanentAddress = Reader["PermanentAddress"].ToString();
                logIn.Email = Reader["Email"].ToString();
                logIn.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]).Date;
                logIn.NID = Convert.ToInt32(Reader["NID"]);
                logIn.Phone = Reader["Phone"].ToString();
                logIn.Password = Reader["Password"].ToString();
                muList.Add(logIn);
               
            }
            Connection.Close();
            Reader.Close();
            return muList;

        }

        public int UpdateSalesMan(LogIn logIn)
        {

            string query = "UPDATE LogIn SET PresentAddress ='" + logIn.PresentAddress + "' ,PermanentAddress='" + logIn.PermanentAddress + "', Email= '" + logIn.Email + "', NID ='" + logIn.NID + "', Phone= '" + logIn.Phone + "' WHERE Name ='" + logIn.Name + "' ";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }

        public int DeleteSalesman(string name)
        {
            string query = "DELETE FROM LogIn WHERE Name = '"+name+"'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            int rowAffect = Command.ExecuteNonQuery();
            Connection.Close();
            return rowAffect;
        }
        public List<LogIn> GetAllSalesNameForDelete()
        {
            string query = "SELECT * FROM LogIn";
            Command = new SqlCommand(query, Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            List<LogIn> muList = new List<LogIn>();
            while (Reader.Read())
            {
                LogIn logIn = new LogIn();
                logIn.Name = Reader["Name"].ToString();
                logIn.PresentAddress = Reader["PresentAddress"].ToString();
                logIn.PermanentAddress = Reader["PermanentAddress"].ToString();
                logIn.Email = Reader["Email"].ToString();
                logIn.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]).Date;
                logIn.NID = Convert.ToInt32(Reader["NID"]);
                logIn.Phone = Reader["Phone"].ToString();
                logIn.Password = Reader["Password"].ToString();
                muList.Add(logIn);

            }
            Connection.Close();
            Reader.Close();
            return muList;

        }
    }
}