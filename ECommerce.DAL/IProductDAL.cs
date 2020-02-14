using ECommerce.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.DAL
{
    public interface IProductDAL
    {
         List<Product> GetAllProducts();

         Product GetProductById(string id);

        //This is just for re-poplating the local flat file
        void RessedProduct();

    }
}
