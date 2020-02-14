using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Objects
{
    public class OrderDetails
    {
        public string OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
    }
}
