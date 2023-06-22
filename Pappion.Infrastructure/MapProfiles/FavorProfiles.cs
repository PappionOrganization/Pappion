using AutoMapper;
using Pappion.Application.Dto.Favor;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.MapProfiles
{
    public class FavorProfiles : Profile
    {
        public FavorProfiles() 
        {
            CreateMap<Favor, FavorReadDto>();
        }
    }
}
