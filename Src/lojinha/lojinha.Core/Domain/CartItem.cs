using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Domain
{
    public class CartItem : Generic
    {
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
