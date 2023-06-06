namespace Pappion.Domain.Entities
{
    public class FavorTags
    {
        public Favor Favor { get; set; }
        public Guid FavorId { get; set; }

        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}