using PieShop.Data.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PieShop.Data.Repository
{
    public class SQLServerRepository<T> : IRepository<T> where T : class
    {
        protected readonly PieShopDbContext _context;
        public SQLServerRepository(PieShopDbContext context)
        {
            _context = context;
        }

        public virtual T Add(T entity)
        {
            var result = _context.Set<T>().Add(entity).Entity;
            _context.SaveChanges();
            return result;
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().Where(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            var result = _context.Set<T>().Update(entity).Entity;
            _context.SaveChanges();
            return result;
        }
    }
}
