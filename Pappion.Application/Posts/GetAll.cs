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
    public record GetPostListQuery() : IRequest<List<Post>>;
    public class GetPostListHandler : IRequestHandler<GetPostListQuery, List<Post>>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public GetPostListHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<List<Post>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetAll();
        }
    }
}
