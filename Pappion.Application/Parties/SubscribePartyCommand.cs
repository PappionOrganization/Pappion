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

namespace Pappion.Application.Posts
{
    public record SubscribePartyCommand(Guid partyId) : ICommand<Unit>;
    public class SubscribePartyCommandValidator : AbstractValidator<SubscribePartyCommand>
    {
        public SubscribePartyCommandValidator()
        {
            RuleFor(command => command.partyId).NotEmpty();
        }
    }
    public class SubscribePartyHandler : ICommandHandler<SubscribePartyCommand, Unit>
    {
        private readonly IGenericRepository<Party> _partyRepository;
        private readonly IUserContext _userContext;

        public SubscribePartyHandler(IGenericRepository<Party> partyRepository, IUserContext userContext)
        {
            _partyRepository = partyRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(SubscribePartyCommand request, CancellationToken cancellationToken)
        {
            if (!await _partyRepository.ExistsAsync(p => p.Id.Equals(request.partyId)))
            {
                throw new EntityNotFoundException(nameof(Party), $"Party '{request.partyId}' not found");
            }
            
            var party = await _partyRepository.GetByIdAsync(request.partyId);
            if(party.PartyUsers is null)
            {
                party.PartyUsers = new List<PartyUsers>();
            }
            if (party.PartyUsers.Any(pu => pu.UserId.Equals(_userContext.Id) && pu.PartyId.Equals(request.partyId)))
            {
                throw new EntityAlreadyExistsException(nameof(party), $"Party '{party.Id}' is already " +
                    $"subscribed by user '{_userContext.Id}'");
            }
            party.PartyUsers.Add(new PartyUsers { UserId = _userContext.Id, PartyId = request.partyId });
            await _partyRepository.UpdateAsync(party);
            await _partyRepository.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
