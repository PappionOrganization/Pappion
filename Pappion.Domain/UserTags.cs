namespace Pappion.Domain
{
    public class UserTags
    {
        public User User { get; set; }
        public Guid UserId { get; set; }

        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}