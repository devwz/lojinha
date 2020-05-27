using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lojinha.Core.Domain
{
    public class Cart : Generic
    {
        public string CartKey { get; set; }
        public List<CartItem> Item = new List<CartItem>();

        public void Add(int id, int unid = 1)
        {
            if (!Item.AsReadOnly().Any(i => i.Id == id))
            {
                Item.Add(new CartItem()
                {
                    Id = id,
                    Unid = unid
                });
                return;
            }

            CartItem item = Item.AsReadOnly().FirstOrDefault(i => i.Id == id);
            item.Unid = unid;
        }
    }
}
