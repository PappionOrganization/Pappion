using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Pappion.Application.Common.Exceptions;
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

        public async Task AddAsync(T entity) => await _table.AddAsync(entity);

        public Task AddRangeAsync(IEnumerable<T> entities) => _table.AddRangeAsync(entities);

        public IQueryable<T> Filter(Expression<Func<T, bool>> predicate) => _table.Where(predicate);

        public Task<List<T>> GetAllAsync() => _table.ToListAsync();

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _table.FindAsync(id);

            return entity ?? throw new EntityNotFoundException(nameof(T), id);
        }

        public async Task RemoveAsync(Guid id)
        {
            _table.Remove(await GetByIdAsync(id));
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _table.RemoveRange(entities);
        }

        public Task UpdateAsync(T entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate) => _table.AnyAsync(predicate);
    }
}
