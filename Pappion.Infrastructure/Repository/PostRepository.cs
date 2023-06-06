using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.Repository
{
    internal class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly PappionDbContext _context;

        public PostRepository(PappionDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
