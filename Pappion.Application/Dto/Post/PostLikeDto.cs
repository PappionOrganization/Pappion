using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Dto.Post
{
    public class PostLikeDto
    {
        public DateTime CreatedDate { get; set; }
        public Guid SenderId { get; set; }
        public Guid PostId { get; set; } 
    }
}
