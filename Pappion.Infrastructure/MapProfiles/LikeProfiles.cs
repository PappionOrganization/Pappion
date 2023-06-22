using AutoMapper;
using Pappion.Application.Dto.Like;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.MapProfiles
{
    public class LikeProfiles : Profile
    {
        public LikeProfiles()
        {
            CreateMap<Like, LikeReadDto>();
        }
    }
}
