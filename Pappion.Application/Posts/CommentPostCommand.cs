using FluentValidation;
using MediatR;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Posts
{
    public record CommentPostCommand(Guid postId, string Text, decimal Grade) : ICommand<Unit>;
    public class CommentPostCommandValidator : AbstractValidator<CommentPostCommand>
    {
        public CommentPostCommandValidator()
        {
            RuleFor(command => command.postId).NotEmpty();
        }
    }
    public class CommentPostHandler : ICommandHandler<CommentPostCommand, Unit>
    {
        private readonly IGenericRepository<Comment> _сommentRepository;
        private readonly IUserContext _userContext;
        private readonly IGenericRepository<Post> _postRepository;

        public CommentPostHandler(IGenericRepository<Comment> сommentRepository, IUserContext userContext, IGenericRepository<Post> postRepository)
        {
            _сommentRepository = сommentRepository;
            _userContext = userContext;
            _postRepository = postRepository;
        }

        public async Task<Unit> Handle(CommentPostCommand request, CancellationToken cancellationToken)
        {
            if (!await _postRepository.ExistsAsync(p => p.Id.Equals(request.postId)))
            {
                throw new EntityNotFoundException(nameof(Post), $"Post '{request.postId}' not found");
            }
            var Comment = new Comment { PostId = request.postId, SenderId = _userContext.Id, Text = request.Text, Grade = request.Grade};

            await _сommentRepository.AddAsync(Comment);
            await _сommentRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
