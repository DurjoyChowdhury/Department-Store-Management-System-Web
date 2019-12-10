using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DepartmentStoreManagementSystemWebApp.Models
{
    public class AddProduct
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public int PurchaseProduct { get; set; }
        public int SaleProduct { get; set; }
        public string Brand { get; set; }
        public int Vat { get; set; }
        public int Discount { get; set; }
        public int Quantity { get; set; }
        public DateTime  Date { get; set; }
        public string Weight { get; set; }
        public string Supplier { get; set; }
        public string ReceivedBy { get; set; }
    }
}