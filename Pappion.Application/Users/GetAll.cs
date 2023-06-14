using MediatR;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Users
{
    public record GetUserListQuery() : IQuery<List<User>>;
    public class GetUserListHandler : IQueryHandler<GetUserListQuery, List<User>>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public GetUserListHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetAll();
        }
    }
}
