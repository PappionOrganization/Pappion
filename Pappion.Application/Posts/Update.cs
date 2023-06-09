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
    public record UpdatePostCommand(Post post) : IRequest;
    public class UpdatePostHandler : IRequestHandler<UpdatePostCommand>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public UpdatePostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        async Task IRequestHandler<UpdatePostCommand>.Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Update(request.post);
            _genericRepository.Save();
        }
    }
}
