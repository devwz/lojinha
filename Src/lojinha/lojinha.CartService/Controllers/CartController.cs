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
        public ActionResult<Cart> Post(CartItem obj)
        {
            Cart cart = new Cart();

            string cartKey = GetOrCreateCartCookie();

            if (cartKey != null)
            {
                cart = _cartService.GetOrCreateCart(cartKey);

                _cartService.AddCartItem(cart, obj);

                cart = _cartService.GetOrCreateCart(cartKey);

                return CreatedAtAction("Get", new { cartKey = cart.CartKey }, cart);
            }

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

            if (cart.CartKey == null)
            {
                return NotFound();
            }

            // delete here

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
                Expires = DateTime.Today.AddYears(1)
            };

            Response.Cookies.Append(Constants.BASKET_COOKIENAME, cartKey, cookieOptions);

            return cartKey;
        }
    }
}
