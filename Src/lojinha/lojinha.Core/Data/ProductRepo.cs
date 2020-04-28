using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace lojinha.Core.Data
{
    public class ProductRepo : GenericRepo<Product>
    {
        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            
        }

        public override object Add(Product obj)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Product> All()
        {
            throw new NotImplementedException();
        }

        public override void Delete(object id)
        {
            throw new NotImplementedException();
        }

        public override Product Find(object id)
        {
            throw new NotImplementedException();
        }

        public override void Update(Product obj)
        {
            throw new NotImplementedException();
        }
    }
}
