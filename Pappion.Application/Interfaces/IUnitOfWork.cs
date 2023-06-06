using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        IPostRepository Post { get; }
        IPartyRepository Party { get; }
        IFavorRepository Favor { get; }
        int Save();
    }
}
