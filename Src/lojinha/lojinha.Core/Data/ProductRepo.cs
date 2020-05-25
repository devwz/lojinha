using Dapper;
using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace lojinha.Core.Data
{
    public class ProductRepo : GenericRepo<Product>
    {
        public ProductRepo(ApplicationDbContext context)
            : base(context)
        {

        }

        public override object Add(Product obj)
        {
            string command = "Add_Product";
            return obj.Id = context.SqlConnection.ExecuteScalar<Int32>(
                command,
                new { obj.Bio, obj.ImgUrl, obj.Price, obj.Title },
                commandType: CommandType.StoredProcedure);
        }

        public override IEnumerable<Product> All()
        {
            string command = "SELECT * FROM [ProductCatalog.Product]";
            return context.SqlConnection.Query<Product>(command);
        }

        public override void Delete(object id)
        {
            string command = "Delete_Product";
            context.SqlConnection.Execute(command, new { Id = id }, commandType: CommandType.StoredProcedure);
        }

        public override Product Find(object id)
        {
            string command = "SELECT * FROM [ProductCatalog.Product] Where Id = @Id";
            return context.SqlConnection.Query<Product>(command, new { Id = id }).FirstOrDefault();
        }

        public override void Update(Product obj)
        {
            string command = "Update_Product";
            context.SqlConnection.Execute(
                command,
                new { obj.Id, obj.Bio, obj.Enabled, obj.ImgUrl, obj.Price, obj.Title },
                commandType: CommandType.StoredProcedure);
        }
    }
}
