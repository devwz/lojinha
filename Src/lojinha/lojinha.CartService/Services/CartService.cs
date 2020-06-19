using lojinha.CartService.Interfaces;
using lojinha.Core.Data;
using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lojinha.CartService.Services
{
    public class CartService : ICartService
    {
        readonly CartRepo _repo;

        public CartService(CartRepo repo)
        {
            _repo = repo;
        }

        public Cart GetOrCreateCart(string cartKey)
        {
            Cart cart = _repo.Find(cartKey);

            if (cart == null)
            {
                return CreateCart(cartKey);
            }

            return cart;
        }

        public Cart CreateCart(string cartKey)
        {
            Cart cart = new Cart()
            {
                CartKey = cartKey,
                CartItem = new List<CartItem>()
            };

            _repo.Add(cart);

            return cart;
        }

        public void AddCartItem(Cart cart, CartItem cartItem)
        {
            cart.Add(cartItem.Id, cartItem.ImgUrl, cartItem.Price, cartItem.Title, cartItem.Unit);

            _repo.Update(cart);
        }
    }
}
