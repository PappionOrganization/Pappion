using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using AutoMapper;
using Pappion.Application.Dto.Party;
using FluentValidation;
using Pappion.Application.Common.Exceptions;
using Pappion.Domain.Constants;
using System.Data;

namespace Pappion.Application.Parties
{
    public record UnlikePartyCommand(Guid partyId) : ICommand<Unit>;
    public class UnlikePartyCommandValidator : AbstractValidator<LikePartyCommand>
    {
        public UnlikePartyCommandValidator()
        {
            RuleFor(command => command.partyId).NotEmpty();
        }
    }
    public class UnlikePartyHandler : ICommandHandler<UnlikePartyCommand, Unit>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IUserContext _userContext;

        public UnlikePartyHandler(IGenericRepository<Like> likeRepository, IUserContext userContext)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(UnlikePartyCommand request, CancellationToken cancellationToken)
        {
            var existLike = _likeRepository
                .Filter(l => l.SenderId.Equals(_userContext.Id))
                .Where(l => l.PartyId.Equals(request.partyId))
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
