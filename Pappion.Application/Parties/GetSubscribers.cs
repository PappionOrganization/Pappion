using AutoMapper;
using Pappion.Application.Dto.Like;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Application.Interfaces;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pappion.Application.Interfaces.Contexts;

namespace Pappion.Application.Parties
{
    public record GetPartySubscribersQuery(Guid Id) : IQuery<List<Guid>>;

    public class GetPartySubscribersHandler : IQueryHandler<GetPartySubscribersQuery, List<Guid>>
    {
        private readonly IGenericRepository<PartyUsers> _partyUsersRepository;

        public GetPartySubscribersHandler(IGenericRepository<PartyUsers> partyRepository, IMapper mapper, IUserContext userContext)
        {
            _partyUsersRepository = partyRepository;
        }
        public async Task<List<Guid>> Handle(GetPartySubscribersQuery request, CancellationToken cancellationToken)
        {
            var partySubscribers = _partyUsersRepository.Filter(pu => pu.PartyId.Equals(request.Id));
            return partySubscribers.Select(ps => ps.UserId).ToList();
        }
    }
}
