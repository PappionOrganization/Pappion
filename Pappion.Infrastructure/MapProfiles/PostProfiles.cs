using AutoMapper;
using Pappion.Application.Dto.Post;
using Pappion.Domain.Entities;

namespace Pappion.Infrastructure.MapProfiles
{
    public class PostProfiles : Profile
    {
        public PostProfiles()
        {
            CreateMap<Post, PostReadDto>();
            CreateMap<PostReadDto, Post>();

        }
    }
}
