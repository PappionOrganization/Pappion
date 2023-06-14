using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Posts
{
    public record GetPostListQuery : IQuery<List<Post>>;

    public class GetPostListHandler : IQueryHandler<GetPostListQuery, List<Post>>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public GetPostListHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<List<Post>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetAllAsync();
        }
    }
}
