using Dapper;
using market.Core.Data.Interfaces;
using market.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace market.Core.Data
{
    public class CartRepo : GenericRepo<Cart>
    {
        public CartRepo(ApplicationDbContext context)
            : base(context)
        {

        }

        public override object Add(Cart obj)
        {
            string command = "Add_Cart";
            return obj.Id = context.SqlConnection.ExecuteScalar<Int32>(
                command,
                new { obj.CartKey },
                commandType: CommandType.StoredProcedure);
        }

        public override IEnumerable<Cart> All()
        {
            throw new NotImplementedException();
        }

        public override void Delete(object cartKey)
        {
            string command = "Delete_Cart";
            context.SqlConnection.ExecuteScalar<Int32>(
                command,
                new { CartKey = cartKey },
                commandType: CommandType.StoredProcedure);
        }

        public void Delete(int cartId, Item item)
        {
            string command = "Delete_CartItem";
            context.SqlConnection.ExecuteScalar<Int32>(
                command,
                new { item.Id, Cart_Id = cartId },
                commandType: CommandType.StoredProcedure);
        }

        public override Cart Find(object id)
        {
            Dictionary<Int32, Cart> keyValuePair = new Dictionary<Int32, Cart>();

            string command = "SELECT * FROM All_Cart C " +
                "LEFT JOIN All_CartItem CI ON C.Id = CI.Cart_Id " +
                "WHERE C.CartKey = @CartKey";

            return context.SqlConnection.Query<Cart, Item, Cart>(
                command,
                param: new { CartKey = id },
                map: (cart, item) =>
                {
                    if (!keyValuePair.TryGetValue(cart.Id, out Cart obj))
                    {
                        obj = cart;
                        obj.ItemCollection = new List<Item>();
                        keyValuePair.Add(obj.Id, obj);
                    }

                    if (item != null)
                    {
                        obj.ItemCollection.Add(item);
                    }

                    return obj;
                },
                splitOn: "Id")
                .Distinct()
                .FirstOrDefault();
        }

        public override void Update(Cart obj)
        {
            object[] cartItem = new object[obj.ItemCollection.Count()];

            for (int i = 0; i < obj.ItemCollection.Count(); i++)
            {
                cartItem[i] = new
                {
                    Cart_Id = obj.Id,
                    obj.ItemCollection[i].Id,
                    obj.ItemCollection[i].ImgUrl,
                    obj.ItemCollection[i].Price,
                    obj.ItemCollection[i].Title,
                    obj.ItemCollection[i].Unid
                };
            }

            string command = "Update_Cart";
            context.SqlConnection.Execute(
                command,
                cartItem,
                commandType: CommandType.StoredProcedure);
        }
    }
}
