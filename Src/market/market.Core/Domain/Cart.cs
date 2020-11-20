using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace market.Core.Domain
{
    public class Cart : Generic
    {
        public string CartKey { get; set; }
        public List<Item> ItemCollection { get; set; } = new List<Item>();

        public void Add(Item item)
        {
            if (!ItemCollection.AsReadOnly().Any(i => i.Id == item.Id))
            {
                ItemCollection.Add(item);
                return;
            }

            Item cartItem = ItemCollection.AsReadOnly().FirstOrDefault(i => i.Id == item.Id);
            cartItem.Unid = item.Unid;
        }

        public void DeleteEmptyItem()
        {
            ItemCollection.RemoveAll(i => i.Unid == 0);
        }
    }
}
