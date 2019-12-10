using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentStoreManagementSystemWebApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int SalesNo { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public float Amount { get; set; }

    }
}