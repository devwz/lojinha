using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Cart : Generic
    {
        public List<CartItem> Item { get; set; }

        public void Add(int id, decimal price, int amount = 1)
        {
            if (!Item.AsReadOnly().Any(i => i.Id == id))
            {
                Item.Add(new CartItem()
                {
                    Id = id,
                    Price = price,
                    Amount = amount
                });
                return;
            }

            CartItem item = Item.AsReadOnly().FirstOrDefault(i => i.Id == id);
            item.Amount += amount;
        }
    }
}
