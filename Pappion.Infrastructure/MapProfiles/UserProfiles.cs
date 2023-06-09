using AutoMapper;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Dto;

namespace Pappion.Infrastructure.MapProfiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<UserAddDto, User>();
        }
    }
}
