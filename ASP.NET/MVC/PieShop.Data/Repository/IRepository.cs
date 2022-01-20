using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace PieShop.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        T Add(T entity);
        void Remove(T entity);
        T Update(T entity);
    }
}
