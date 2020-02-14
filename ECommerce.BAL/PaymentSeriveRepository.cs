using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BLL
{
    public class PaymentSeriveRepository : IPaymentSeriveRepository
    {
       public bool ChargePayment(string creditCardNumber, decimal amount)
        {

            //Service implementation
            return true;
        }
    }
}
