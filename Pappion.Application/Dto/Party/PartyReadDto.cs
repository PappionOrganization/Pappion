using Pappion.Domain.Entities;

namespace Pappion.Application.Dto.Party
{
    public class PartyReadDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public DateTime Date { get; set; }
        public Guid AuthorId { get; set; }
        public ICollection<Guid>? ImagesId { get; set; }
        public string? Tags { get; set; }
    }
}
