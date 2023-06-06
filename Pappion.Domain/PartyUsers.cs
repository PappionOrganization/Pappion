namespace Pappion.Domain
{
    public class PartyUsers
    {
        public Party Party { get; set; }
        public Guid PartyId { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}