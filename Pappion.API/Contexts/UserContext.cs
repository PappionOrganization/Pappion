using Pappion.Application.Interfaces.Contexts;

namespace Pappion.API.Contexts
{
    public class UserContext : IUserContext
    {
        public Guid Id { get; }

        public UserContext(Guid id)
        {
            Id = id;
        }
    }
}
