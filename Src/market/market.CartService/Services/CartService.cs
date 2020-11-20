using market.CartService.Interfaces;
using market.Core.Data;
using market.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace market.CartService.Services
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
                CartKey = cartKey
            };

            _repo.Add(cart);

            return cart;
        }

        public void UpdateCart(Cart cart)
        {
            _repo.Update(cart);
        }

        public void Delete(string cartKey)
        {
            _repo.Delete(cartKey);
        }

        public void Delete(int cartId, Item item)
        {
            _repo.Delete(cartId, item);
        }
    }
}
