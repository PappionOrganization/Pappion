using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using AutoMapper;
using Pappion.Application.Dto.Post;
using FluentValidation;
using Pappion.Application.Common.Exceptions;
using Pappion.Domain.Constants;
using System.Data;

namespace Pappion.Application.Posts
{
    public record UnlikePostCommand(Guid postId) : ICommand<Unit>;
    public class UnlikePostCommandValidator : AbstractValidator<LikePostCommand>
    {
        public UnlikePostCommandValidator()
        {
            RuleFor(command => command.postId).NotEmpty();
        }
    }
    public class UnlikePostHandler : ICommandHandler<UnlikePostCommand, Unit>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IUserContext _userContext;

        public UnlikePostHandler(IGenericRepository<Like> likeRepository, IUserContext userContext)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(UnlikePostCommand request, CancellationToken cancellationToken)
        {
            var existLike = _likeRepository
                .Filter(l => l.SenderId.Equals(_userContext.Id))
                .Where(l => l.PostId.Equals(request.postId))
                .FirstOrDefault();
            if (existLike is null)
            {
                throw new EntityNotFoundException(nameof(existLike), $"Cannot found like sended by user '{_userContext.Id}'");
            }
            await _likeRepository.RemoveAsync(existLike.Id);
            await _likeRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
