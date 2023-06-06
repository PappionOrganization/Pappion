namespace Pappion.Domain.Entities
{
    public class PartyTags
    {
        public Party Party { get; set; }
        public Guid PartyId { get; set; }

        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}
