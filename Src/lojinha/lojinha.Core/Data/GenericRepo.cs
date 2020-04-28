using lojinha.Core.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Data
{
    public abstract class GenericRepo<T> : IGenericRepo<T>
    {
        protected ApplicationDbContext context;

        public GenericRepo(ApplicationDbContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public abstract object Add(T obj);
        public abstract IEnumerable<T> All();
        public abstract void Delete(object id);
        public abstract T Find(object id);
        public abstract void Update(T obj);
    }
}
