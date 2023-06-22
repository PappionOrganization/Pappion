using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using AutoMapper;
using Pappion.Application.Dto.Party;
using FluentValidation;
using Pappion.Application.Common.Exceptions;

namespace Pappion.Application.Parties
{
    public record LikePartyCommand(Guid partyId) : ICommand<Unit>;
    public class LikePartyCommandValidator : AbstractValidator<LikePartyCommand>
    {
        public LikePartyCommandValidator()
        {
            RuleFor(command => command.partyId).NotEmpty();
        }
    }
    public class LikePartyHandler : ICommandHandler<LikePartyCommand, Unit>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IUserContext _userContext;

        public LikePartyHandler(IGenericRepository<Like> likeRepository, IUserContext userContext)
        {
            _likeRepository = likeRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(LikePartyCommand request, CancellationToken cancellationToken)
        {
            var like = new Like { PartyId = request.partyId, SenderId = _userContext.Id };

            if (_likeRepository.ExistsAsync(l => l.SenderId.Equals(like.SenderId) && l.PartyId.Equals(like.PartyId)).Result)
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
