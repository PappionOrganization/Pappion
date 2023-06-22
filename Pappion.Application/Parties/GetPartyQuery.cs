using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Parties
{
    public record GetPartiesQuery : IQuery<List<Party>>;

    public class GetPartiesHandler : IQueryHandler<GetPartiesQuery, List<Party>>
    {
        private readonly IGenericRepository<Party> _partyRepository;

        public GetPartiesHandler(IGenericRepository<Party> partyRepository)
        {
            _partyRepository = partyRepository;
        }
        public async Task<List<Party>> Handle(GetPartiesQuery request, CancellationToken cancellationToken)
        {
            return await _partyRepository.GetAllAsync();
        }
    }
}
