using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using Pappion.Application.Interfaces;
using FluentValidation;

namespace Pappion.Application.Favors
{
    public record GetFavorQuery(Guid Id) : IQuery<Favor>;

    public class GetFavorByIdQueryValidator : AbstractValidator<GetFavorQuery>
    {
        public GetFavorByIdQueryValidator()
        {
            RuleFor(query => query.Id).NotEmpty();
        }
    }
    public class GetFavorHandler : IQueryHandler<GetFavorQuery, Favor>
    {
        private readonly IGenericRepository<Favor> _genericRepository;

        public GetFavorHandler(IGenericRepository<Favor> genericRepository)
        {
            _genericRepository = genericRepository;
        }
        public async Task<Favor> Handle(GetFavorQuery request, CancellationToken cancellationToken)
        {
            return await _genericRepository.GetByIdAsync(request.Id);
        }
    }
}
