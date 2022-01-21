using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Camp.Data.Repository.BaseRepository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression);
        Task<T> Add(T entity);
        Task Remove(T entity);
        Task<T> Update(T entity);
        Task<bool> SaveChanges();
    }
}
