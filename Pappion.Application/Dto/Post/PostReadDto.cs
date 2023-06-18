using Pappion.Domain.Entities;

namespace Pappion.Application.Dto.Post
{
    public class PostReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string? Location { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Guid>? ImagesId { get; set; }
    }
}
