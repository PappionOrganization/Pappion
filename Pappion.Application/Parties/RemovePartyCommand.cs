using MediatR;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Contexts;
using Pappion.Application.Common.Exceptions;
using Pappion.Domain.Constants;
using System.Data;

namespace Pappion.Application.Parties
{
    public record RemovePartyCommand(Guid Id) : ICommand<Unit>;
    public class RemovePartyHandler : ICommandHandler<RemovePartyCommand, Unit>
    {
        private readonly IGenericRepository<Party> _partyRepository;
        private readonly IUserContext _userContext;

        public RemovePartyHandler(IGenericRepository<Party> genericRepository, IUserContext userContext)
        {
            _partyRepository = genericRepository;
            _userContext = userContext;
        }

        public async Task<Unit> Handle(RemovePartyCommand request, CancellationToken cancellationToken)
        {
            if (!CheckPermission(request.Id))
            {
                throw new AccessDeniedExeption(_userContext.Id);
            }
            await _partyRepository.RemoveAsync(p => p.Id.Equals(request.Id));
            await _partyRepository.SaveChangesAsync();
            return Unit.Value;
        }

        private bool CheckPermission(Guid partyId)
        {
            if(_partyRepository.GetByIdAsync(partyId).Result.AuthorId.Equals(_userContext.Id)) 
            {
                return true;
            }
            return false;
        }
    }
}
