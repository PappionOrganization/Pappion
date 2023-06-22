using FluentValidation;
using MediatR;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Users
{
    public record CommentUserCommand(Guid userId, string Text, decimal Grade) : ICommand<Unit>;
    public class CommentUserCommandValidator : AbstractValidator<CommentUserCommand>
    {
        public CommentUserCommandValidator()
        {
            RuleFor(command => command.userId).NotEmpty();
        }
    }
    public class CommentUserHandler : ICommandHandler<CommentUserCommand, Unit>
    {
        private readonly IGenericRepository<Comment> _сommentRepository;
        private readonly IUserContext _userContext;
        private readonly IGenericRepository<User> _userRepository;

        public CommentUserHandler(IGenericRepository<Comment> сommentRepository, IUserContext userContext, IGenericRepository<User> userRepository)
        {
            _сommentRepository = сommentRepository;
            _userContext = userContext;
            _userRepository = userRepository;
        }

        public async Task<Unit> Handle(CommentUserCommand request, CancellationToken cancellationToken)
        {
            if (!await _userRepository.ExistsAsync(p => p.Id.Equals(request.userId)))
            {
                throw new EntityNotFoundException(nameof(User), $"User '{request.userId}' not found");
            }
            var Comment = new Comment { UserId = request.userId, SenderId = _userContext.Id, Text = request.Text, Grade = request.Grade};

            await _сommentRepository.AddAsync(Comment);
            await _сommentRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
