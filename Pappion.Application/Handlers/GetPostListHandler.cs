using MediatR;
using Pappion.Application.Queries;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Interfaces;

namespace Pappion.Application.Handlers
{
    public class GetPostListHandler : IRequestHandler<GetPostListQuery, IEnumerable<Post>>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public GetPostListHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public Task<IEnumerable<Post>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_genericRepository.GetAll());
        }
    }
}
