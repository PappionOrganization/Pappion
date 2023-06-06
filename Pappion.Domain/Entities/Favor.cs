namespace Pappion.Domain.Entities
{
    public class Favor
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Like> Likes { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<FavorTags> FavorTags { get; set; }
        public ICollection<FavorImages> FavorImages { get; set; }
    }
}
