using System;
using System.Collections.Generic;
using System.Text;

namespace lojinha.Core.Data.Interfaces
{
    public interface IGenericRepo<T>
    {
        object Add(T obj);
        IEnumerable<T> All();
        void Delete(object id);
        T Find(object id);
        void Update(T obj);
    }
}
