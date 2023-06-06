namespace Pappion.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Location { get; set; }

        public Guid RoleId { get; set; }
        public Role Role { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
        public ICollection<PhoneNumber> PhoneNumbers { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Like> LikesSended { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Comment> CommentsSended { get; set; }
        public ICollection<Party> Parties { get; set; }
        public ICollection<Favor> Favors { get; set; }
        public ICollection<Post> Posts { get; set; }

        public ICollection<UserTags> UserTags { get; set; }
        public ICollection<PartyUsers> PartyUsers { get; set; }
    }
}
