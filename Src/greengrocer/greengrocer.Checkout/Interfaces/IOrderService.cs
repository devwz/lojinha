using greengrocer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace greengrocer.Checkout.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(Order order);
        Order FindOrder(object id);
        void UpdateOrder(Order order);
    }
}
