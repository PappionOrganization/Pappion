using AutoMapper;
using Pappion.Application.Dto.Images;
using Pappion.Domain.Entities;

namespace Pappion.Infrastructure.MapProfiles
{
    public class ImageProfiles : Profile
    {
        public ImageProfiles()
        {
            CreateMap<ImageReadDto, Image>();
        }
    }
}
