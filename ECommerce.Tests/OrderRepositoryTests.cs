using ECommerce.BLL;
using ECommerce.Objects;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Tests
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        private Mock<IProductRepository> _productRepositoryMock;
        private Mock<IPaymentSeriveRepository> _paymentSeriveRepositoryMock;
        private Mock<IEmailRepository> _emailRepositoryMock;
        private IOrderRepository _orderRepository;


        [SetUp]
        public void InIt()
        {
            _productRepositoryMock = new Mock<IProductRepository>();
            _productRepositoryMock.Setup(repo => repo.CheckInventory(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            _productRepositoryMock.Setup(repo => repo.GetProductfromDb(It.IsAny<string>())).Returns(new Product { ProductID="1",UnitsInStock=35});

            _paymentSeriveRepositoryMock = new Mock<IPaymentSeriveRepository>();
            _paymentSeriveRepositoryMock.Setup(repo => repo.ChargePayment(It.IsAny<string>(), It.IsAny<decimal>())).Returns(true);

            _emailRepositoryMock = new Mock<IEmailRepository>();
            _emailRepositoryMock.Setup(repo => repo.SendEmail(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(true);

        _orderRepository = new OrderRepository(_productRepositoryMock.Object, _paymentSeriveRepositoryMock.Object, _emailRepositoryMock.Object);
        }


        [Test]
        public void PositiveTest()
        {
            OrderViewModel order = new OrderViewModel()
            {
                Quantity = 2,
                Product = new Product
                {
                    ProductID = "1"

                },
                Customer=new Customer
                {
                    CustomerID="1",
                    Email="test@test.com"
                },
                CardDetails=new PaymentCard
                {
                    CardNum="1242562345634"
                }          


            };

            var result = _orderRepository.Process(order);

            Assert.AreEqual(result.Keys.FirstOrDefault(), true);
        }

        [Test]
        public void NotEnoughQuantity()
        {
            OrderViewModel order = new OrderViewModel()
            {
                Quantity = 2,
                Product = new Product
                {
                    ProductID = "1"

                },
                Customer = new Customer
                {
                    CustomerID = "1",
                    Email = "test@test.com"
                },
                CardDetails = new PaymentCard
                {
                    CardNum = "1242562345634"
                }

            };

            _productRepositoryMock.Setup(repo => repo.CheckInventory(It.IsAny<string>(), It.IsAny<int>())).Returns(false);

            var result = _orderRepository.Process(order);

            Assert.AreEqual(result.Keys.FirstOrDefault(), false);
        }

        [Test]
        public void PaymentDeclined()
        {
            OrderViewModel order = new OrderViewModel()
            {
                Quantity = 2,
                Product = new Product
                {
                    ProductID = "1"

                },
                Customer = new Customer
                {
                    CustomerID = "1",
                    Email = "test@test.com"
                },
                CardDetails = new PaymentCard
                {
                    CardNum = "1242562345634"
                }

            };

            _paymentSeriveRepositoryMock.Setup(repo => repo.ChargePayment(It.IsAny<string>(), It.IsAny<decimal>())).Returns(false);

            var result = _orderRepository.Process(order);

            Assert.AreEqual(result.Keys.FirstOrDefault(), false);
        }



    }
}
