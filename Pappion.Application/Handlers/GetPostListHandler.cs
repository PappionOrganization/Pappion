using MediatR;
using Pappion.Application.Queries;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;

namespace Pappion.Application.Handlers
{
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