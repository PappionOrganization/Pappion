using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces;

namespace Pappion.Infrastructure.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PappionDbContext _context;
        private readonly DbSet<TEntity> _table;

        public GenericRepository(PappionDbContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity) => await _table.AddAsync(entity);

        public Task AddRangeAsync(IEnumerable<TEntity> entities) => _table.AddRangeAsync(entities);

        public IQueryable<TEntity> Filter(Expression<Func<TEntity, bool>> predicate) => _table.Where(predicate);

        public Task<List<TEntity>> GetAllAsync() => _table.ToListAsync();

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            var entity = await _table.FindAsync(id);

            return entity ?? throw new EntityNotFoundException(nameof(TEntity), id);
        }

        public async Task RemoveAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            _table.Remove(entity);
        }

        public Task UpdateAsync(TEntity entity)
        {
            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;

            return Task.CompletedTask;
        }

        public Task<int> SaveChangesAsync() => _context.SaveChangesAsync();

        public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) => _table.AnyAsync(predicate);
    }
}
