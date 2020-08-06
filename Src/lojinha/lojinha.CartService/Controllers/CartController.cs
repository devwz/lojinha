using lojinha.CartService.Data;
using lojinha.CartService.Interfaces;
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
        readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        // GET api/cart
        [HttpGet]
        public ActionResult<Cart> Get()
        {
            return GetCart();
        }

        // GET api/cart/5
        [HttpGet("{id}")]
        public ActionResult<Cart> Get(int id)
        {
            throw new NotImplementedException();
        }

        // POST api/cart
        [HttpPost]
        public ActionResult<Cart> Post(Cart cart)
        {
            throw new NotImplementedException();
        }

        // POST api/cart/item/add
        [HttpPost("item/add")]
        public ActionResult<Cart> Add(Item item)
        {
            Cart cart = new Cart();

            string cartKey = GetOrCreateCartCookie();

            if (cartKey != null)
            {
                cart = _cartService.GetOrCreateCart(cartKey);

                cart.Add(item);

                _cartService.UpdateCart(cart);

                cart = _cartService.GetOrCreateCart(cartKey);

                return CreatedAtAction("Get", new { cartKey = cart.CartKey }, cart);
            }

            return cart;
        }

        // POST api/cart/item/delete
        [HttpPost("item/delete")]
        public ActionResult<Cart> Delete(Item item)
        {
            Cart cart = GetCart();

            if (cart.CartKey == null)
            {
                return NotFound();
            }

            _cartService.Delete(cart.Id, item);

            cart = _cartService.GetOrCreateCart(cart.CartKey);

            return cart;
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

            if (cart.Id != id)
            {
                return NotFound();
            }

            _cartService.Delete(cart.CartKey);

            return NoContent();
        }

        Cart GetCart()
        {
            // login here

            string cartKey = GetCartIdFromCookie();

            if (cartKey == null)
            {
                return new Cart();
            }

            return _cartService.GetOrCreateCart(cartKey);
        }

        string GetCartIdFromCookie()
        {
            if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
            {
                return Request.Cookies[Constants.BASKET_COOKIENAME];
            }

            return null;
        }

        string GetOrCreateCartCookie()
        {
            // login here

            string cartKey;

            if (Request.Cookies.ContainsKey(Constants.BASKET_COOKIENAME))
            {
                cartKey = Request.Cookies[Constants.BASKET_COOKIENAME];

                if (cartKey != null)
                {
                    return cartKey;
                }
            }

            cartKey = Guid.NewGuid().ToString().ToUpper();

            var cookieOptions = new CookieOptions
            {
                IsEssential = true,
                Expires = DateTime.Today.AddMonths(1),
                SameSite = SameSiteMode.Strict
                // Secure = true
            };

            Response.Cookies.Append(Constants.BASKET_COOKIENAME, cartKey, cookieOptions);

            return cartKey;
        }
    }
}
