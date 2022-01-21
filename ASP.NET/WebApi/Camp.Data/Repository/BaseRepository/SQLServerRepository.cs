using Camp.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Camp.Data.Repository.BaseRepository
{
    public class SQLServerRepository<T> : IRepository<T> where T : class
    {
        protected readonly CampDbContext _context;
        public SQLServerRepository(CampDbContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Add(T entity)
        {
            var result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return await Task.Run(() =>
            {
                return _context.Set<T>().Where(expression);
            });
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Task.Run(() =>
            {
                return _context.Set<T>();
            });
        }

        public virtual async Task Remove(T entity)
        {
            await Task.Run(() =>
            {
                _context.Set<T>().Remove(entity);
            });
        }   

        public virtual async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public virtual async Task<T> Update(T entity)
        {
            return await Task.Run(() =>
            {
                var result = _context.Set<T>().Update(entity).Entity;
                return result;
            }); 
        }
    }
}
