using AutoMapper;
using Pappion.Application.Dto.Party;
using Pappion.Domain.Entities;

namespace Pappion.Infrastructure.MapProfiles
{
    public class PartyProfiles : Profile
    {
        public PartyProfiles()
        {
            CreateMap<Party, PartyReadDto>();
            CreateMap<PartyUsers, Guid>();
        }
    }
}
