using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ECommerce.Objects;

namespace ECommerce.BLL
{
    public class OrderRepository : IOrderRepository
    {
        private List<string> errors;
        private IProductRepository _productRepository;
        private IPaymentSeriveRepository _paymentSeriveRepository;
        private IEmailRepository _emailRepository;

        public OrderRepository(IProductRepository productRepository, IPaymentSeriveRepository paymentSeriveRepository, IEmailRepository emailRepository)
        {
            errors = new List<string>();
            _productRepository = productRepository;
           _paymentSeriveRepository = paymentSeriveRepository;
            _emailRepository = emailRepository;
        }

        public Dictionary<bool, List<string>> Process(OrderViewModel order)
        {
            if (_productRepository.CheckInventory(order.Product.ProductID, order.Quantity))
            {
                var prodInDb = _productRepository.GetProductfromDb(order.Product.ProductID);
                var totalPrice = order.Quantity * prodInDb.UnitPrice * (1 - prodInDb.Discount);
                if (_paymentSeriveRepository.ChargePayment(order.CardDetails.CardNum, totalPrice))
                {
                    //ToDO
                    //Update Procucts table with the updated quantity in stock
                    //Insert into OrderTable, OrderDetails Table

                    
                    _emailRepository.SendEmail("pranays53@gmail.com", "Order status", "Order placed Successfully");
                }
                else
                {
                    errors.Add("Payment Declined");
                }

            }
            else
            {
                errors.Add("Out of stock");
            }

            bool isSucess = !errors.Any();

            return new Dictionary<bool, List<string>> { { isSucess, errors } };
        }
    }
}
