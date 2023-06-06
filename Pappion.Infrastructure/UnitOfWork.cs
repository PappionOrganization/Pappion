using Pappion.Infrastructure.Interfaces;
using Pappion.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PappionDbContext _context;

        public UnitOfWork(PappionDbContext context)
        {
            _context = context;
            Post = new PostRepository(_context);
        }
        public IUserRepository User { get; private set; }

        public IPostRepository Post { get; private set; }

        public IPartyRepository Party { get; private set; }

        public IFavorRepository Favor { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
