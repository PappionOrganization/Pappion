namespace Pappion.Application.Dto.Post
{
    public class PostAddDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? Location { get; set; }
        public Guid AuthorId { get; set; }
    }
}
