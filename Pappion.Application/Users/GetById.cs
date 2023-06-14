﻿using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Users
{
    public record GetUserQuery(Guid Id) : IQuery<User>;
    public class GetUserHandler : IQueryHandler<GetUserQuery, User>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public GetUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<User> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(request.Id);
        }
    }
}
