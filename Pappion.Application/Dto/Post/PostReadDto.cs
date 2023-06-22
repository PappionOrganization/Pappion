using Pappion.Domain.Entities;

namespace Pappion.Application.Dto.Post
{
    public class PostReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Tags { get; set; }
        public Guid AuthorId { get; set; }
    }
}
