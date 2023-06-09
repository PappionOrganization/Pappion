using MediatR;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Posts
{
    public record RemovePostCommand(Guid id) : IRequest;
    public class RemovePostHandler : IRequestHandler<RemovePostCommand>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public RemovePostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        async Task IRequestHandler<RemovePostCommand>.Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Remove(request.id);
            _genericRepository.Save();
        }
    }

}
