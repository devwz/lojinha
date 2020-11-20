using market.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace market.CartService.Interfaces
{
    public interface ICartService
    {
        Cart GetOrCreateCart(string cartKey);
        Cart CreateCart(string cartKey);
        void UpdateCart(Cart cart);
        void Delete(string cartKey);
        void Delete(int cartId, Item item);
    }
}
