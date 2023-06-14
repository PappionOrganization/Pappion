using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Posts
{
    public record GetPostQuery(Guid id) : IQuery<Post>;
    public class GetPostHandler : IQueryHandler<GetPostQuery, Post>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public GetPostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Post> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetById(request.id);
        }
    }
}
