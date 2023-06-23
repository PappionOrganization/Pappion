using FluentValidation;
using MediatR;
using Pappion.Application.Common.Exceptions;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Parties
{
    public record UnsubscribePartyCommand(Guid partyId) : ICommand<Unit>;
    public class UnsubscribePartyCommandValidator : AbstractValidator<UnsubscribePartyCommand>
    {
        public UnsubscribePartyCommandValidator()
        {
            RuleFor(command => command.partyId).NotEmpty();
        }
    }
    public class UnsubscribePartyHandler : ICommandHandler<UnsubscribePartyCommand, Unit>
    {
        private readonly IGenericRepository<Party> _partyRepository;
        private readonly IUserContext _userContext;

        public UnsubscribePartyHandler(IGenericRepository<Party> partyRepository, IUserContext userContext)
        {
            _partyRepository = partyRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(UnsubscribePartyCommand request, CancellationToken cancellationToken)
        {
            if (!await _partyRepository.ExistsAsync(p => p.Id.Equals(request.partyId)))
            {
                throw new EntityNotFoundException(nameof(Party), $"Party '{request.partyId}' not found");
            }
            var party = await _partyRepository.GetByIdAsync(request.partyId);
            if (party.PartyUsers is null)
            {
                party.PartyUsers = new List<PartyUsers>();
            }
            if (!party.PartyUsers.Any(pu => pu.UserId.Equals(_userContext.Id) && pu.PartyId.Equals(request.partyId)))
            {
                throw new EntityAlreadyExistsException(nameof(party), $"Party '{party.Id}' is not " +
                    $"subscribed by user '{_userContext.Id}'");
            }
            var partyUsers = new PartyUsers { PartyId= request.partyId, UserId = _userContext.Id };
            party.PartyUsers.Remove(partyUsers);
            await _partyRepository.UpdateAsync(party);
            await _partyRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
