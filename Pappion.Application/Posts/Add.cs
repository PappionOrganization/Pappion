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
    public record AddPostCommand(Post post) : IRequest;
    public class AddPostHandler : IRequestHandler<AddPostCommand>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public AddPostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        async Task IRequestHandler<AddPostCommand>.Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.Add(request.post);
            _genericRepository.Save();
        }
    }
}
