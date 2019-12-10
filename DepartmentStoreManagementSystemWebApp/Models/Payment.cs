using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentStoreManagementSystemWebApp.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public double Total { get; set; }
        public double Give { get; set; }
        public double Return { get; set; }
    }
}