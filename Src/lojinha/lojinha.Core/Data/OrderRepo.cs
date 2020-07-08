using Dapper;
using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace lojinha.Core.Data
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
                new {
                    obj.Client.Login,
                    obj.Client.Address.AddressLine,
                    obj.Client.Address.StateProvince,
                    obj.Client.Address.CountryRegion,
                    obj.Client.Address.PostalCode,
                    Method = "Credit Card"
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
            throw new NotImplementedException();
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
