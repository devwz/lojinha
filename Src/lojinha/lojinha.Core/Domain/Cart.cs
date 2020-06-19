using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Cart : Generic
    {
        public string CartKey { get; set; }
        public List<CartItem> CartItem { get; set; } = new List<CartItem>();

        public void Add(int id, string imgUrl, decimal price, string title, int unit = 1)
        {
            if (!CartItem.AsReadOnly().Any(i => i.Id == id))
            {
                CartItem.Add(new CartItem()
                {
                    Id = id,
                    ImgUrl = imgUrl,
                    Price = price,
                    Title = title,
                    Unit = unit
                });
                return;
            }

            CartItem item = CartItem.AsReadOnly().FirstOrDefault(i => i.Id == id);
            item.Unit = unit;
        }
    }
}
