namespace Pappion.Domain
{
    public class PartyTags
    {
        public Party Party { get; set; }
        public Guid PartyId { get; set; }

        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}
