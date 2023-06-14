using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Posts
{
    public record RemovePostCommand(Guid id) : ICommand<Unit>;
    public class RemovePostHandler : ICommandHandler<RemovePostCommand, Unit>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public RemovePostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Remove(request.id);
            _genericRepository.Save();
            return Unit.Value;
        }
    }

}
