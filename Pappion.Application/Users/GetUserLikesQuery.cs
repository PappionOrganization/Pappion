using AutoMapper;
using Pappion.Application.Dto.Like;
using Pappion.Application.Interfaces;
using Pappion.Application.Interfaces.Messaging;
using Pappion.Domain.Entities;

namespace Pappion.Application.Users
{
    public record GetUserLikesQuery(Guid Id) : IQuery<List<LikeReadDto>>;

    public class GetUserLikesHandler : IQueryHandler<GetUserLikesQuery, List<LikeReadDto>>
    {
        private readonly IGenericRepository<Like> _likeRepository;
        private readonly IMapper _mapper;

        public GetUserLikesHandler(IGenericRepository<Like> likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;
        }
        public async Task<List<LikeReadDto>> Handle(GetUserLikesQuery request, CancellationToken cancellationToken)
        {
            var userLikes = _likeRepository.Filter(l => l.UserId.Equals(request.Id)).ToList();
            return _mapper.Map<List<LikeReadDto>>(userLikes);
        }
    }
}
