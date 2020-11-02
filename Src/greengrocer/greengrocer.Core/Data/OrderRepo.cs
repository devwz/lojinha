using Dapper;
using greengrocer.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace greengrocer.Core.Data
{
    public class OrderRepo : GenericRepo<Order>
    {
        public OrderRepo(ApplicationDbContext context)
            : base(context)
        {

        }

        public override object Add(Order obj)
        {
            string command = "Add_Order";
            return obj.Id = context.SqlConnection.ExecuteScalar<Int32>(
                command,
                new
                {
                    obj.OrderKey,
                    obj.Client.Name,
                    obj.Client.Surname,
                    obj.Client.Email,
                    obj.Client.Address.AddressLine,
                    obj.Client.Address.StateProvince,
                    obj.Client.Address.CountryRegion,
                    obj.Client.Address.PostalCode,
                    Condition = "Ok"
                },
                commandType: CommandType.StoredProcedure);
        }

        public override IEnumerable<Order> All()
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override Order Find(object id)
        {
            Dictionary<Int32, Order> keyValuePair = new Dictionary<int, Order>();

            string command = "SELECT * FROM All_Order O " +
                "LEFT JOIN All_ProductOrder P ON P.Order_Id = O.Id " +
                "JOIN All_Client C ON C.Id = O.Client_Id " +
                "JOIN All_Address A ON A.Client_Id = C.Id " +
                "WHERE O.Id = @Id";

            return context.SqlConnection.Query<Order, Item, Client, Address, Order>(
                command,
                param: new { Id = id },
                map: (order, item, client, address) =>
                {
                    if (!keyValuePair.TryGetValue(order.Id, out Order obj))
                    {
                        obj = order;
                        obj.Client = client;
                        obj.Client.Address = address;

                        obj.Cart = new Cart
                        {
                            ItemCollection = new List<Item>()
                        };
                        keyValuePair.Add(obj.Id, obj);
                    }

                    if (item != null)
                    {
                        obj.Cart.Add(item);
                    }

                    return obj;
                },
                splitOn: "Id")
                .Distinct()
                .FirstOrDefault();
        }

        public override void Update(Order obj)
        {
            object[] productOrder = new object[obj.Cart.ItemCollection.Count()];

            for (int i = 0; i < obj.Cart.ItemCollection.Count(); i++)
            {
                productOrder[i] = new
                {
                    Order_Id = obj.Id,
                    obj.Cart.ItemCollection[i].Id,
                    obj.Cart.ItemCollection[i].Title,
                    obj.Cart.ItemCollection[i].Price,
                    obj.Cart.ItemCollection[i].Unid
                };
            }

            string command = "Update_Order";
            context.SqlConnection.Execute(
                command,
                productOrder,
                commandType: CommandType.StoredProcedure);
        }
    }
}
