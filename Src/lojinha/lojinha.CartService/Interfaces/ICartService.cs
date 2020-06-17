using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lojinha.CartService.Interfaces
{
    public interface ICartService
    {
        Cart GetOrCreateCart(string cartKey);
        Cart CreateCart(string cartKey);
        void AddCartItem(Cart cart, CartItem cartItem);
    }
}
