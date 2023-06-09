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
    public record AddUserCommand(User user) : IRequest;
    public class AddUserHandler : IRequestHandler<AddUserCommand>
    {
        private readonly IGenericRepository<User> _genericRepository;

        public AddUserHandler(IGenericRepository<User> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        async Task IRequestHandler<AddUserCommand>.Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Add(request.user);
            _genericRepository.Save();
        }
    }
}
