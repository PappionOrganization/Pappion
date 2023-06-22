using AutoMapper;
using Pappion.Application.Dto.User;
using Pappion.Application.Users;
using Pappion.Domain.Entities;

namespace Pappion.Infrastructure.MapProfiles
{
    public class UserProfiles : Profile
    {
        public UserProfiles()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserReadDto, User>();
            CreateMap<RegisterCommand, User>();
        }
    }
}
