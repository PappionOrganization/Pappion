using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using AutoMapper;
using Pappion.Application.Dto.Favor;
using FluentValidation;
using Pappion.Application.Common.Exceptions;
using Pappion.Domain.Constants;
using System.Data;

namespace Pappion.Application.Favors
{
    public record UnlikeFavorCommand(Guid favorId) : ICommand<Unit>;
    public class UnlikeFavorCommandValidator : AbstractValidator<LikeFavorCommand>
    {
        public UnlikeFavorCommandValidator()
        {
            RuleFor(command => command.favorId).NotEmpty();
        }
    }
    public class UnlikeFavorHandler : ICommandHandler<UnlikeFavorCommand, Unit>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IUserContext _userContext;

        public UnlikeFavorHandler(IGenericRepository<Like> likeRepository, IUserContext userContext)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(UnlikeFavorCommand request, CancellationToken cancellationToken)
        {
            var existLike = _likeRepository
                .Filter(l => l.SenderId.Equals(_userContext.Id))
                .Where(l => l.FavorId.Equals(request.favorId))
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
