using AutoMapper;
using Pappion.Application.Dto.Like;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Parties
{
    public record GetPartyLikesQuery(Guid Id) : IQuery<List<LikeReadDto>>;

    public class GetPartyLikesHandler : IQueryHandler<GetPartyLikesQuery, List<LikeReadDto>>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IMapper _mapper;

        public GetPartyLikesHandler(IGenericRepository<Like> likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<List<LikeReadDto>> Handle(GetPartyLikesQuery request, CancellationToken cancellationToken)
        {
            var partyLikes = _likeRepository.Filter(l => l.PartyId.Equals(request.Id)).ToList();
            return _mapper.Map<List<LikeReadDto>>(partyLikes);
        }
    }
}
