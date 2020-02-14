using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BLL
{
    public interface IPaymentSeriveRepository
    {
        bool ChargePayment(string creditCardNumber, decimal amount);
    }
}
