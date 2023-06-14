using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Posts
{
    public record RemovePostCommand(Guid Id) : ICommand<Unit>;
    public class RemovePostHandler : ICommandHandler<RemovePostCommand, Unit>
    {
        private readonly IGenericRepository<Post> _genericRepository;

        public RemovePostHandler(IGenericRepository<Post> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.RemoveAsync(request.Id);
            await _genericRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
