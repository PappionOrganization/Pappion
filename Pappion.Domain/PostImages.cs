namespace Pappion.Domain
{
    public class PostImages
    {
        public Post Post { get; set; }
        public Guid PostId { get; set; }

        public Image Image { get; set; }
        public Guid ImageId { get; set; }
    }
}