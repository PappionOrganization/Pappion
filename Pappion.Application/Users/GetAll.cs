using MediatR;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Users
{
    public record GetUserListQuery() : IRequest<List<User>>;
    public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<User>>
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
