using AutoMapper;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Dto.Like;
namespace Pappion.Infrastructure.MapProfiles
{
    public class LikeProfiles : Profile
    {
        public LikeProfiles()
        {
            CreateMap<Like, UserLikeReadDto>();
        }
    }
}
