namespace Pappion.Domain
{
    public class PartyImages
    {
        public Party Party { get; set; }
        public Guid PartyId { get; set; }

        public Image Image { get; set; }
        public Guid ImageId { get; set; }
    }
}