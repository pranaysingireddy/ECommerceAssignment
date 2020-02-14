using ECommerce.BLL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Tests
{
    [TestFixture]
    public class PaymentServiceRepositoryTests
    {
        private IPaymentSeriveRepository _paymentServiceRepository;

        [SetUp]
        public void InIt()
        {
            _paymentServiceRepository = new PaymentSeriveRepository();
        }

        [Test]
        [TestCase("12345634355",1234,ExpectedResult =true)]
        public bool ChargePaymentTestCase(string creditCardNumber, decimal amount)
        {
            return _paymentServiceRepository.ChargePayment(creditCardNumber, amount);
        }

    }
}
