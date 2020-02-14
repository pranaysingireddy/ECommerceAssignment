using ECommerce.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ECommerce.DAL
{
    public class ProductDAL : IProductDAL
    {

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProductById(string id)
        {
            //Getting data from flat file instead of connecting to db
            var strData = File.ReadAllText("C:\\Users\\prana\\source\\repos\\ECommerce\\ECommerce.DAL\\ProductList.txt");
            var allProducts = JsonConvert.DeserializeObject<List<Product>>(strData);

            return allProducts.Where(p => p.ProductID == id).FirstOrDefault();

            //If we are using any ORM 
            //return dbCotex.Products.Where(p => p.ProductID == id).FirstOrDefault();

        }


        public void RessedProduct()
        {

        }
    }
}
