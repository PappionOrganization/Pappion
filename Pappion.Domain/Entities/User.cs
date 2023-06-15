using Pappion.Domain.Constants;

namespace Pappion.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? PhoneNumber2 { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Location { get; set; }
        public UserRoles Role { get; set; }
        public ICollection<Image> Images { get; set; }
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
