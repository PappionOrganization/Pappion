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

namespace Pappion.Application.Favors
{
    public record GetFavorLikesQuery(Guid Id) : IQuery<List<LikeReadDto>>;

    public class GetFavorLikesHandler : IQueryHandler<GetFavorLikesQuery, List<LikeReadDto>>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IMapper _mapper;

        public GetFavorLikesHandler(IGenericRepository<Like> likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<List<LikeReadDto>> Handle(GetFavorLikesQuery request, CancellationToken cancellationToken)
        {
            var favorLikes = _likeRepository.Filter(l => l.FavorId.Equals(request.Id));
            return _mapper.Map<List<LikeReadDto>>(favorLikes);
        }
    }
}
