using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Cart : Generic
    {
        public Cart()
        {
            CartItem = new List<CartItem>();
        }

        public string CartKey { get; set; }
        public List<CartItem> CartItem { get; set; }

        public void Add(int id, int unid = 1)
        {
            if (!CartItem.AsReadOnly().Any(i => i.Id == id))
            {
                CartItem.Add(new CartItem()
                {
                    Id = id,
                    Unid = unid
                });
                return;
            }

            CartItem item = CartItem.AsReadOnly().FirstOrDefault(i => i.Id == id);
            item.Unid = unid;
        }
    }
}
