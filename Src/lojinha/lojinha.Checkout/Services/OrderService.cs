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
            order.OrderKey = Guid.NewGuid().ToString().ToUpper();

            _repo.Add(order);
        }

        public Order FindOrder(object id)
        {
            return _repo.Find(id);
        }

        public void UpdateOrder(Order order)
        {
            _repo.Update(order);
        }
    }
}
