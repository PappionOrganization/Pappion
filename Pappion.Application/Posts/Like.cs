using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Posts
{
    public record LikePostCommand(Like Like) : ICommand<Unit>;
    public class LikePostHandler : ICommandHandler<LikePostCommand, Unit>
    {
        private readonly IGenericRepository<Like> _genericRepository;

        public LikePostHandler(IGenericRepository<Like> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<Unit> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            await _genericRepository.AddAsync(request.Like);
            await _genericRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
