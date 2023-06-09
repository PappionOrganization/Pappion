using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.Dto.Like
{
    public class SetLikeDto
    {
        public Guid SenderId { get; set; }
        public Guid? UserId { get; set; } = null;
        public Guid? PartyId { get; set; } = null;
        public Guid? PostId { get; set; } = null;
        public Guid? FavorId { get; set; } = null;
        public Guid? CommentId { get; set; } = null;
    }
}
