using ECommerce.BLL;
using ECommerce.DAL;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
namespace ECommerce.Tests
{
    [TestFixture]
    public class ProductRepositoryTests
    {
        private IProductRepository _productRepository;
        private Mock<IProductDAL> _productDALMock;

        [SetUp]
        public void InIt()
        {
            _productDALMock = new Mock<IProductDAL>();

            _productDALMock.Setup(repo => repo.GetProductById(It.IsAny<string>())).Returns(new ECommerce.Objects.Product() { ProductID="1",UnitsInStock=20});

            _productRepository = new ProductRepository(_productDALMock.Object);
        }

        [Test]
        [TestCase("1", 1, ExpectedResult = true)]
        public bool ValidTestCase(string productId, int quantity)
        {
            return _productRepository.CheckInventory(productId, quantity);
        }



        [Test]
        [TestCase("1", 25, ExpectedResult = false)]
        public bool NegativeTestCase(string productId, int quantity)
        {
            _productDALMock.Setup(repo => repo.GetProductById(It.IsAny<string>())).Returns(new ECommerce.Objects.Product() { ProductID = "1", UnitsInStock = 5 });
            return _productRepository.CheckInventory(productId, quantity);
        }
    }
}
