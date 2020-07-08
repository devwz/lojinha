using lojinha.Checkout.Interfaces;
using lojinha.Core.Data;
using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lojinha.Checkout.Services
{
    public class OrderService : IOrderService
    {
        readonly OrderRepo _repo;

        public OrderService(OrderRepo repo)
        {
            _repo = repo;
        }

        public void CreateOrder(Order order)
        {
            _repo.Add(order);
        }

        public void UpdateOrder(Order order)
        {
            _repo.Update(order);
        }
    }
}
