using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Domain
{
    public class CartItem : Generic
    {
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public int Unit { get; set; }
        public decimal Total => Unit * Price;
    }
}
