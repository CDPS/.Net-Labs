using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PieShop.Data.Repository
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        private readonly List<T> _list;

        public InMemoryRepository()
        {
            _list = new List<T>();
        }

        public T Add(T entity)
        {
            _list.Add(entity);
            return entity;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _list.Where(expression.Compile());
        }

        public IEnumerable<T> GetAll()
        {
            return _list;
        }

        public void Remove(T entity)
        {
            _list.Remove(entity);
        }

        public T Update(T entity)
        {
            return entity;
        }
    }
}
