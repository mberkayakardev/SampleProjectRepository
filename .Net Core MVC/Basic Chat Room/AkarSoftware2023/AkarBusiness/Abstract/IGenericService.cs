using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace AkarBusiness.Abstract
{
    public interface IGenericService <T>
    {
        void Add(T item);
        void Update(T item);
        bool ForceDelete(T item);
        bool SafeDelete(T item);
        List<T> GetEnum(Expression<Func<T, bool>> where = null, Expression<Func<T, object>>[] include = null);
        T Get(Expression<Func<T, bool>> where = null, Expression<Func<T, object>>[] include = null);
    }
}
