using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Application.Dto.Comments
{
    public class CommentReadDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Text { get; set; } = string.Empty;
        public decimal Grade { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid SenderId { get; set; }
    }
}
