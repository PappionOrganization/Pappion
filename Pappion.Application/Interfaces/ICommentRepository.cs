using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Interfaces
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
    }
}
