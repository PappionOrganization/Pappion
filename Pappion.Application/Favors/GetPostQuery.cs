using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;

namespace Pappion.Application.Favors
{
    public record GetFavorsQuery : IQuery<List<Favor>>;

    public class GetFavorsHandler : IQueryHandler<GetFavorsQuery, List<Favor>>
    {
        private readonly IGenericRepository<Favor> _favorRepository;

        public GetFavorsHandler(IGenericRepository<Favor> favorRepository)
        {
            _favorRepository = favorRepository;
        }
        public async Task<List<Favor>> Handle(GetFavorsQuery request, CancellationToken cancellationToken)
        {
            return await _favorRepository.GetAllAsync();
        }
    }
}
