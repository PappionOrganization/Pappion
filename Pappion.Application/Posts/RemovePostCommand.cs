using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Common.Exceptions;
using Pappion.Domain.Constants;
using System.Data;

namespace Pappion.Application.Posts
{
    public record RemovePostCommand(Guid Id) : ICommand<Unit>;
    public class RemovePostHandler : ICommandHandler<RemovePostCommand, Unit>
    {
        private readonly IGenericRepository<Post> _postRepository;
        private readonly IUserContext _userContext;

        public RemovePostHandler(IGenericRepository<Post> genericRepository, IUserContext userContext)
        {
            _postRepository = genericRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {
            if (!CheckPermission(request.Id))
            {
                throw new AccessDeniedExeption(_userContext.Id);
            }
            await _postRepository.RemoveAsync(request.Id);
            await _postRepository.SaveChangesAsync();
            return Unit.Value;
        }

        private bool CheckPermission(Guid postId)
        {
            if(_postRepository.GetByIdAsync(postId).Result.AuthorId.Equals(_userContext.Id)) 
            {
                return true;
            }
            return false;
        }
    }
}
