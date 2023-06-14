using MediatR;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Users
{
    public record AddUserCommand(User user) : ICommand<Unit>;
    public class AddUserHandler : ICommandHandler<AddUserCommand, Unit>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public AddUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Add(request.user);
            _genericRepository.Save();
            return Unit.Value;
        }
    }
}
