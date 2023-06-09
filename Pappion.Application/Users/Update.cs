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
    public record UpdateUserCommand(User user) : IRequest;
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public UpdateUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        async Task IRequestHandler<UpdateUserCommand>.Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Update(request.user);
            _genericRepository.Save();
        }
    }
}
