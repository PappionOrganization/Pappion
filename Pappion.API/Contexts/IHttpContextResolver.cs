using Pappion.Application.Interfaces.Contexts;

namespace Pappion.API.Contexts
{
    public interface IHttpContextResolver
    {
        IUserContext? ResolveUserContext();
    }
}
