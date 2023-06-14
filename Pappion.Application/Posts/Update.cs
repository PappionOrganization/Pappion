using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Posts
{
    public record UpdatePostCommand(Post Post) : ICommand<Unit>;
    public class UpdatePostHandler : ICommandHandler<UpdatePostCommand, Unit>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public UpdatePostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.UpdateAsync(request.Post);
            await _genericRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
