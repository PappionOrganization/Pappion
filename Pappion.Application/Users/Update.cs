using MediatR;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Users
{
    public record UpdateUserCommand(User user) : ICommand<Unit>;
    public class UpdateUserHandler : ICommandHandler<UpdateUserCommand, Unit>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public UpdateUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Update(request.user);
            _genericRepository.Save();
            return Unit.Value;
        }
    }
}
