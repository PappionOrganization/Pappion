using AutoMapper;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Dto;
using System.Diagnostics;

namespace Pappion.Infrastructure.MapProfiles
{
    public class PostProfiles : Profile
    {
        public PostProfiles()
        {
            CreateMap<Post, PostReadDto>();
            CreateMap<PostReadDto, Post>();
            CreateMap<PostAddDto, Post>();
        }
    }
}
