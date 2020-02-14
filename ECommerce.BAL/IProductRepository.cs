using ECommerce.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BLL
{
    public interface IProductRepository
    {
        bool CheckInventory(string productId, int qty);
        Product GetProductfromDb(string productId);
    }
}
