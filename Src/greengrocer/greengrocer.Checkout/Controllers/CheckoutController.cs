using greengrocer.Checkout.Interfaces;
using greengrocer.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace greengrocer.Checkout.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        readonly IOrderService _orderService;
        readonly IPaymentService _paymentService;

        public CheckoutController(IOrderService orderService, IPaymentService paymentService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
        }

        // GET api/checkout
        [HttpGet]
        public ActionResult Get()
        {
            throw new NotImplementedException();
        }

        // GET api/checkout/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            Order obj = _orderService.FindOrder(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        // POST api/checkout
        [HttpPost]
        public ActionResult<Order> Post(Order order)
        {
            if (order.Cart == null || order.Client == null)
            {
                return BadRequest(); // or 422
            }

            order.Cart.DeleteEmptyItem();

            _orderService.CreateOrder(order);

            _paymentService.PayOrder();

            _orderService.UpdateOrder(order);

            return CreatedAtAction("Get", new { id = order.Id }, order);
        }

        // PUT api/checkout/5
        [HttpPut("{id}")]
        public ActionResult Put(int id)
        {
            throw new NotImplementedException();
        }

        // DELETE api/checkout/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
