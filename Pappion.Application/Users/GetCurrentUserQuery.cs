using AutoMapper;
using Pappion.Application.Dto.Like;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pappion.Application.Dto.User;
using Pappion.Application.Interfaces.Contexts;

namespace Pappion.Application.Users
{
    public record GetCurrentUserQuery() : IQuery<UserReadDto>;

    public class GetCurrentUserHandler : IQueryHandler<GetCurrentUserQuery, UserReadDto>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserContext _userContext;

        public GetCurrentUserHandler(IGenericRepository<User> userRepository, IMapper mapper, IUserContext userContext)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userContext = userContext;
        }
        public async Task<UserReadDto> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userRepository.GetByIdAsync(_userContext.Id);
            return _mapper.Map<UserReadDto>(currentUser);
        }
    }
}
