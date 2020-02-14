using ECommerce.Objects;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.BLL
{
   public interface IOrderRepository
    {
        Dictionary<bool, List<string>> Process(OrderViewModel order);
    }
}
