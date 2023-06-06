namespace Pappion.Domain.Entities
{
    public class PostTags
    {
        public Post Post { get; set; }
        public Guid PostId { get; set; }

        public Tag Tag { get; set; }
        public Guid TagId { get; set; }
    }
}