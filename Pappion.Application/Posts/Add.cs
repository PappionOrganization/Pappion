using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Posts
{
    public record AddPostCommand(Post Post) : ICommand<Unit>;

    public class AddPostHandler : ICommandHandler<AddPostCommand, Unit>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public AddPostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.AddAsync(request.Post);
            await _genericRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
