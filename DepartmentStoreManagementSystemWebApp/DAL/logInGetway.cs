using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DepartmentStoreManagementSystemWebApp.Models;
using HospitalManagementSystemWebApp.Getway;

namespace DepartmentStoreManagementSystemWebApp.DAL
{
    public class logInGetway: CommonGateway
    {
        public List<LogIn> GetAllLogIn(string name)
        {
            string query = "SELECT * FROM LogIn WHERE Name ='"+name+"'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            List<LogIn> list = new List<LogIn>();
            Reader = Command.ExecuteReader();
            while (Reader.Read())
            {
                LogIn myLogIn = new LogIn();

                myLogIn.ID = Convert.ToInt32(Reader["ID"]);
                myLogIn.Name = Reader["Name"].ToString();
                myLogIn.PresentAddress = Reader["PresentAddress"].ToString();
                myLogIn.PermanentAddress = Reader["PermanentAddress"].ToString();
                myLogIn.Email = Reader["Email"].ToString();
                myLogIn.DateOfBirth = Convert.ToDateTime(Reader["DateOfBirth"]);
                myLogIn.NID = Convert.ToInt32(Reader["NID"]);
                myLogIn.Phone = Reader["Phone"].ToString();
                myLogIn.Password = Reader["Password"].ToString();
                myLogIn.Type = Reader["Type"].ToString();

                list.Add(myLogIn);
             
            }

            Connection.Close();
            Reader.Close();
            return list;

        }

        public string GetType(string name)
        {
            string query ="SELECT * FROM LogIn WHERE Name = '"+name+"'";
            Command = new SqlCommand(query,Connection);
            Connection.Open();
            Reader = Command.ExecuteReader();
            LogIn myIn = new LogIn();

            Reader.Read();
            
           
                myIn.Type = Reader["Type"].ToString();
               
                Connection.Close();
            Reader.Close();
            return myIn.Type;
        }
        public List<LogIn> GetAllLogIn()
        {
            string query = "SELECT * FROM LogIn";
            Command = new SqlCommand(query, Connection);
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

    }
}