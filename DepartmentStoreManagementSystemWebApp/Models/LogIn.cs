using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DepartmentStoreManagementSystemWebApp.Models
{
    public class LogIn
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Email { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public int NID { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
       // [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }


    }
}