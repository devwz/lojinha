using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lojinha.Checkout.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        void UpdateOrder(Order order);
    }
}
