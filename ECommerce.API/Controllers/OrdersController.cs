using ECommerce.BLL;
using ECommerce.DAL;
using ECommerce.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECommerce.API.Controllers
{
    public class OrdersController : ApiController
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private IPaymentSeriveRepository _paymentSeriveRepository;
        private IProductDAL _productDal;
        private IEmailRepository _emailRepository;
        public OrdersController()
        {
            _productDal = new ProductDAL();
            _productRepository = new ProductRepository(_productDal);
            _paymentSeriveRepository = new PaymentSeriveRepository();
            _emailRepository = new EmailRepository();
            _orderRepository = new OrderRepository(_productRepository, _paymentSeriveRepository, _emailRepository);
        }


        [HttpGet]
        public IHttpActionResult ProcessOrder(OrderViewModel order)
        {
        
            try
            {
                if (_orderRepository.Process(order).Keys.FirstOrDefault())
                {
                    return Ok("Order Processed");
                }
                else
                {
                    return SendBadRequest(_orderRepository.Process(order).Values.FirstOrDefault());
                }
            }
            catch (Exception ex)
            {
                return SendBadRequest();
            }

        }


        protected IHttpActionResult SendBadRequest(List<string> errors = null)
        {
            if (errors.Any())
            {
                foreach (var error in errors.Distinct())
                {
                    ModelState.AddModelError("Errors", error);
                }
            }
            else
            {
                ModelState.AddModelError("Exception", "Something went wrong");
            }

            return BadRequest(ModelState);
        }
    }
}
