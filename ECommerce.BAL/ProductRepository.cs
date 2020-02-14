using ECommerce.DAL;
using ECommerce.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BLL
{
    public class ProductRepository : IProductRepository
    {
        private IProductDAL _productDal;

        public ProductRepository(IProductDAL productDal)
        {
            _productDal = productDal;
        }

        public bool CheckInventory(string productId, int qty)
        {
            var productIdDb = _productDal.GetProductById(productId);

            if (productIdDb != null)
            {
                return productIdDb.UnitsInStock >= qty;
            }

            return false;   
        }
        public Product GetProductfromDb (string productId)
        {
           return _productDal.GetProductById(productId);
        }
    }
}
