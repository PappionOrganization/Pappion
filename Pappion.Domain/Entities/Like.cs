namespace Pappion.Domain.Entities
{
    public class Like
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime CreatedDate { get; set; }
        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public Guid? UserId { get; set; } = null;
        public User User { get; set; }
        public Guid? PartyId { get; set; } = null;
        public Party Party { get; set; }
        public Guid? PostId { get; set; } = null;
        public Post Post { get; set; }
        public Guid? FavorId { get; set; } = null;
        public Favor Favor { get; set; }
        public Guid? CommentId { get; set; } = null;
        public Comment Comment { get; set; }
    }
}
