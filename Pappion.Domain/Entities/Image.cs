namespace Pappion.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = string.Empty;

        public Guid? UserId { get; set; }
        public User User { get; set; }

        public Guid? PartyId { get; set; }
        public Party Party { get; set; }

        public Guid? FavorId { get; set; }
        public Favor Favor { get; set; }

        public Guid? PostId { get; set; }
        public Post Post { get; set; }
    }
}
