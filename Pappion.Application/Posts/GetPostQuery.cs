using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Posts
{
    public record GetPostsQuery : IQuery<List<Post>>;

    public class GetPostsHandler : IQueryHandler<GetPostsQuery, List<Post>>
    {
        private readonly IGenericRepository<Post> _postRepository;

        public GetPostsHandler(IGenericRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<List<Post>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            return await _postRepository.GetAllAsync();
        }
    }
}
