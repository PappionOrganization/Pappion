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

namespace Pappion.Application.Posts
{
    public record GetPostLikesQuery(Guid Id) : IQuery<List<LikeReadDto>>;

    public class GetPostLikesHandler : IQueryHandler<GetPostLikesQuery, List<LikeReadDto>>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IMapper _mapper;

        public GetPostLikesHandler(IGenericRepository<Like> likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<List<LikeReadDto>> Handle(GetPostLikesQuery request, CancellationToken cancellationToken)
        {
            var postLikes = _likeRepository.Filter(l => l.PostId.Equals(request.Id)).ToList();
            return _mapper.Map<List<LikeReadDto>>(postLikes);
        }
    }
}
