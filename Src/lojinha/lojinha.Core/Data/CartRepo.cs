using Dapper;
using lojinha.Core.Data.Interfaces;
using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace lojinha.Core.Data
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

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override Cart Find(object id)
        {
            Dictionary<int, Cart> keyValuePair = new Dictionary<int, Cart>();

            string command = "SELECT * FROM All_Cart C LEFT JOIN All_CartItem CI ON C.Id = CI.Cart_Id WHERE C.CartKey = @CartKey";
            return context.SqlConnection.Query<Cart, CartItem, Cart>(
                command,
                param: new { CartKey = id },
                map: (cart, cartItem) =>
                {
                    if (!keyValuePair.TryGetValue(cart.Id, out Cart obj))
                    {
                        obj = cart;
                        obj.CartItem = new List<CartItem>();
                        keyValuePair.Add(obj.Id, obj);
                    }

                    obj.CartItem.Add(cartItem);
                    return obj;
                },
                splitOn: "Id")
                .Distinct()
                .FirstOrDefault();
        }

        public override void Update(Cart obj)
        {
            object[] cartItem = new object[obj.CartItem.Count()];

            for (int i = 0; i < obj.CartItem.Count(); i++)
            {
                cartItem[i] = new {
                    obj.CartItem[i].Id,
                    obj.CartItem[i].ImgUrl,
                    obj.CartItem[i].Price,
                    obj.CartItem[i].Title,
                    obj.CartItem[i].Unit,
                    Cart_Id = obj.Id
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
