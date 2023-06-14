using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Users
{
    public record RemoveUserCommand(Guid id) : ICommand<Unit>;
    public class RemoveUserHandler : ICommandHandler<RemoveUserCommand, Unit>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public RemoveUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Remove(request.id);
            _genericRepository.Save();
            return Unit.Value;
        }
    }

}
