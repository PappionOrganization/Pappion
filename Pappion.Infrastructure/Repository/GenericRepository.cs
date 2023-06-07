using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PappionDbContext _context;
        private readonly DbSet<T> _table;

        public GenericRepository(PappionDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
        public void Add(T entity)
        {
            _table.Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(Guid id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            _table.Remove(_table.Find(id));
        }

        public void Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
