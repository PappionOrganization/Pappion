using AutoMapper;
using Pappion.Application.Dto.Post;
using Pappion.Domain.Entities;

namespace Pappion.Infrastructure.MapProfiles
{
    public class ImageProfiles : Profile
    {
        public ImageProfiles()
        {
            CreateMap<Guid, Image>();

        }
    }
}
