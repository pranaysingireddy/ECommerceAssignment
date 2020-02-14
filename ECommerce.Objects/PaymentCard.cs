using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Objects
{
    public class PaymentCard
    {
        public string ProvideCode { get; set; }
        public string CardNum { get; set; }
        public string ExpDetails { get; set; }
        public string CVV { get; set; }
    }
}
