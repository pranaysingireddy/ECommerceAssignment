using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Objects
{
    public class Product
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        //public int SupplierID { get; set; }
        //public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public decimal Discount { get; set; }
    }
}
