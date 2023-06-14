using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;

namespace Pappion.Application.Users
{
    public record GetCurrentUserInfoQuery : IQuery<User> { }
    public class GetCurrentUserInfoQueryHandler : IQueryHandler<GetCurrentUserInfoQuery, User>
    {
        private readonly IUserContext _userContext;
        private readonly IGenericRepository<User> _genericRepository;

        public GetCurrentUserInfoQueryHandler(IUserContext userContext, IGenericRepository<User> genericRepository)
        {
            _userContext = userContext;
            _genericRepository = genericRepository;
        }

        public async Task<User> Handle(GetCurrentUserInfoQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(_userContext.Id);
        }
    }
}
