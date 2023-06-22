using AutoMapper;
using Pappion.Application.Dto.Comments;
using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.MapProfiles
{
    public class CommentProfiles : Profile
    {
        public CommentProfiles()
        {
            CreateMap<Comment, CommentReadDto>();
        }
    }
}
