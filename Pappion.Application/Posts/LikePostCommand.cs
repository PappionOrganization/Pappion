using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using AutoMapper;
using Pappion.Application.Dto.Post;
using FluentValidation;
using Pappion.Application.Common.Exceptions;

namespace Pappion.Application.Posts
{
    public record LikePostCommand(Guid postId) : ICommand<Unit>;
    public class LikePostCommandValidator : AbstractValidator<LikePostCommand>
    {
        public LikePostCommandValidator()
        {
            RuleFor(command => command.postId).NotEmpty();
        }
    }
    public class LikePostHandler : ICommandHandler<LikePostCommand, Unit>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IUserContext _userContext;

        public LikePostHandler(IGenericRepository<Like> likeRepository, IUserContext userContext)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            var like = new Like { PostId = request.postId, SenderId = _userContext.Id };

            if (_likeRepository
                .Filter(l => l.SenderId.Equals(like.SenderId))
                .Where(l => l.PostId.Equals(like.PostId)) != null)
            {
                throw new EntityAlreadyExistsException(nameof(like), $"Like is already " +
                    $"sended by user '{_userContext.Id}'");
            }
            
            await _likeRepository.AddAsync(like);
            await _likeRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
