using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<List<T>> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate);
        Task Add(T entity);
        Task AddRange(IEnumerable<T> entities);
        Task Update(T entity);
        Task Remove(Guid id);
        int Save();

    }
}
