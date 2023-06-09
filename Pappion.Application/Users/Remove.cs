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
    public record RemoveUserCommand(Guid id) : IRequest;
    public class RemoveUserHandler : IRequestHandler<RemoveUserCommand>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public RemoveUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        async Task IRequestHandler<RemoveUserCommand>.Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Remove(request.id);
            _genericRepository.Save();
        }
    }

}
