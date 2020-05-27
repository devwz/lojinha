using lojinha.CartService.Data;
using lojinha.Core.Data;
using lojinha.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace lojinha.CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        readonly CartRepo repo;

        public CartController(CartRepo repo)
        {
            this.repo = repo;
        }

        // GET api/cart
        [HttpGet]
        public ActionResult<Cart> Get()
        {
            return GetCart();
        }

        // GET api/cart/count
        [HttpGet("count")]
        public int GetCartItemCount()
        {
            return GetCart().Item.Sum(item => item.Unid);
        }
        
        Cart GetCart()
        {
            // login here

            string cartKey = GetCartIdFromCookie();

            if (cartKey == null)
            {
                return new Cart();
            }

            return GetOrCreateCart(cartKey);
        }

        string GetCartIdFromCookie()
        {
            if (Request.Cookies.ContainsKey("lojinha"))
            {
                return Request.Cookies["lojinha"];
            }

            return null;
        }

        // Service
        Cart GetOrCreateCart(string cartKey)
        {
            Cart cart = repo.Find(cartKey);

            if (cart == null)
            {
                return CreateCart(cartKey);
            }

            return cart;
        }

        // Service
        Cart CreateCart(string cartKey)
        {
            Cart cart = new Cart()
            {
                CartKey = cartKey
            };

            repo.Add(cart);

            return cart;
        }

        // GET api/cart/5
        [HttpGet("{id}")]
        public ActionResult<Cart> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/cart
        [HttpPost]
        public ActionResult<Cart> Post(CartItem obj)
        {
            if (obj.Unid == 0)
            {
                return NoContent();
            }

            string cartKey = GetOrCreateCartCookie();
            Cart cart = GetOrCreateCart(cartKey);

            cart.Add(obj.Id, obj.Unid);
            repo.Update(cart);

            cart = GetOrCreateCart(cartKey);

            return CreatedAtAction("Get", new { cartKey = cart.CartKey }, cart);
        }

        string GetOrCreateCartCookie()
        {
            string cartKey;

            if (Request.Cookies.ContainsKey("lojinha"))
            {
                cartKey = Request.Cookies["lojinha"];

                if (cartKey != null)
                {
                    return cartKey;
                }
            }

            cartKey = Guid.NewGuid().ToString().ToUpper();

            Response.Cookies.Append("lojinha", cartKey);

            return cartKey;
        }

        // PUT api/cart/5
        [HttpPut("{id}")]
        public ActionResult<Cart> Put(int id, Cart obj)
        {
            throw new NotImplementedException();
        }

        // DELETE api/cart/5
        [HttpDelete("{id}")]
        public ActionResult<Cart> Delete(int id)
        {
            Cart cart = GetCart();

            if (cart.CartKey == null)
            {
                return NotFound();
            }

            // delete here

            return NoContent();
        }
    }
}
