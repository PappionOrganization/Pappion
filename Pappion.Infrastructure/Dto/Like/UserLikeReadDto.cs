using Pappion.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Infrastructure.Dto.Like
{
    public class UserLikeReadDto
    {
        public Guid SenderId { get; set; }
        public Guid? UserId { get; set; } = null;
    }
}
