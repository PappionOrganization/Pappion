using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using FluentValidation;

namespace Pappion.Application.Parties
{
    public record GetPartyQuery(Guid Id) : IQuery<Party>;

    public class GetPartyByIdQueryValidator : AbstractValidator<GetPartyQuery>
    {
        public GetPartyByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
    public class GetPartyHandler : IQueryHandler<GetPartyQuery, Party>
    {
        private readonly IGenericRepository<Party> _genericRepository;

        public GetPartyHandler(IGenericRepository<Party> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Party> Handle(GetPartyQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(request.Id);
        }
    }
}
