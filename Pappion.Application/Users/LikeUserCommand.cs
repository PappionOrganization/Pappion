using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using AutoMapper;
using Pappion.Application.Dto.User;
using FluentValidation;
using Pappion.Application.Common.Exceptions;

namespace Pappion.Application.Users
{
    public record LikeUserCommand(Guid userId) : ICommand<Unit>;
    public class LikeUserCommandValidator : AbstractValidator<LikeUserCommand>
    {
        public LikeUserCommandValidator()
        {
            RuleFor(command => command.userId).NotEmpty();
        }
    }
    public class LikeUserHandler : ICommandHandler<LikeUserCommand, Unit>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IUserContext _userContext;

        public LikeUserHandler(IGenericRepository<Like> likeRepository, IUserContext userContext)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(LikeUserCommand request, CancellationToken cancellationToken)
        {
            var like = new Like { UserId = request.userId, SenderId = _userContext.Id };

            if (_likeRepository.ExistsAsync(l => l.SenderId.Equals(like.SenderId) && l.UserId.Equals(like.UserId)).Result)
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
