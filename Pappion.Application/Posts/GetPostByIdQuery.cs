using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using FluentValidation;

namespace Pappion.Application.Posts
{
    public record GetPostQuery(Guid Id) : IQuery<Post>;

    public class GetPostByIdQueryValidator : AbstractValidator<GetPostQuery>
    {
        public GetPostByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
    public class GetPostHandler : IQueryHandler<GetPostQuery, Post>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public GetPostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Post> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(request.Id);
        }
    }
}
