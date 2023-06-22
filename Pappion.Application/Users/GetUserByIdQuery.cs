using AutoMapper;
using Pappion.Application.Dto.User;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Users
{
    public record GetUserByIdQuery(Guid Id) : IQuery<UserReadDto>;

    public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, UserReadDto>
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IGenericRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserReadDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userRepository.GetByIdAsync(request.Id);
            return _mapper.Map<UserReadDto>(currentUser);
        }
    }
}
