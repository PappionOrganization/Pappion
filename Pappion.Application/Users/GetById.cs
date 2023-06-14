using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Users
{
    public record GetUserQuery(Guid id) : IQuery<User>;
    public class GetUserHandler : IQueryHandler<GetUserQuery, User>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public GetUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetById(request.id);
        }
    }
}
