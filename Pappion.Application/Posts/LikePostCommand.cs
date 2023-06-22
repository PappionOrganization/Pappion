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
        private readonly IGenericRepository<Post> _postRepository;

        public LikePostHandler(IGenericRepository<Like> likeRepository, IUserContext userContext, IGenericRepository<Post> postRepository)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(LikePostCommand request, CancellationToken cancellationToken)
        {
            if (!await _postRepository.ExistsAsync(p => p.Id.Equals(request.postId)))
            {
                throw new EntityNotFoundException(nameof(Post), $"Post '{request.postId}' not found");
            }
            var like = new Like { PostId = request.postId, SenderId = _userContext.Id };
            if (_likeRepository.ExistsAsync(l => l.SenderId.Equals(like.SenderId) && l.PostId.Equals(like.PostId)).Result)
            {
                throw new EntityAlreadyExistsException(nameof(like), $"Like is already " +
                    $"sent by user '{_userContext.Id}'");
            }
            
            await _likeRepository.AddAsync(like);
            await _likeRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
