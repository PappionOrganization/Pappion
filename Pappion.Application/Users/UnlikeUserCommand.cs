using FluentValidation;
using MediatR;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using System.Data;

namespace Pappion.Application.Users
{
    public record UnlikeUserCommand(Guid userId) : ICommand<Unit>;
    public class UnlikeUserCommandValidator : AbstractValidator<LikeUserCommand>
    {
        public UnlikeUserCommandValidator()
        {
            RuleFor(command => command.userId).NotEmpty();
        }
    }
    public class UnlikeUserHandler : ICommandHandler<UnlikeUserCommand, Unit>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IUserContext _userContext;

        public UnlikeUserHandler(IGenericRepository<Like> likeRepository, IUserContext userContext)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(UnlikeUserCommand request, CancellationToken cancellationToken)
        {
            var existLike = _likeRepository
                .Filter(l => l.SenderId.Equals(_userContext.Id))
                .Where(l => l.UserId.Equals(request.userId))
                .FirstOrDefault();
            if (existLike is null)
            {
                throw new EntityNotFoundException(nameof(existLike), $"Cannot found like sended by user '{_userContext.Id}'");
            }
            await _likeRepository.RemoveAsync(l => l.Equals(existLike.Id));
            await _likeRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
