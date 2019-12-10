using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentStoreManagementSystemWebApp.Models
{
    public class Refund
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Weight { get; set; }
        public int Quentity { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
    }
}