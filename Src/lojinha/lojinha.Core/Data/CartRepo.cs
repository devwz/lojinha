using lojinha.Core.Domain;
using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override void Update(Cart obj)
        {
            throw new NotImplementedException();
        }
    }
}
