using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentStoreManagementSystemWebApp.Models
{
    public class SaleProduct
    {
        public int Id { get; set; }
        public int SalesNo { get; set; }
        public int ProductCode { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public int Discount { get; set; }
        public int Vat { get; set; }
        public string ProductName { get; set; }
        public string ProductWeight { get; set; }
        
    }
}