using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Objects
{
    public class OrderViewModel
    {
        public int Quantity { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public PaymentCard CardDetails { get; set; }
    }
}
