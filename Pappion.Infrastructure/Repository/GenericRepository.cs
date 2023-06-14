using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Pappion.Application.Interfaces;

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
        public async Task Add(T entity)
        {
            _table.Add(entity);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            _table.AddRange(entities);
        }

        public IEnumerable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _table.Where(predicate).ToList();
        }

        public Task<List<T>> GetAll()
        {
            return _table.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetWhere(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task Remove(Guid id)
        {
            _table.Remove(_table.Find(id));
        }

        public async Task Update(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public Task<bool> Exists(Expression<Func<T, bool>> predicate)
        {
            return Task.FromResult(_table.Any(predicate.Compile()));
        }
    }
}
