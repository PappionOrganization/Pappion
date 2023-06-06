using Pappion.Domain;
namespace Pappion.Domain
{
    public class FavorImages
    {
        public Favor Favor { get; set; }
        public Guid FavorId { get; set; }

        public Image Image { get; set; }
        public Guid ImageId { get; set; }
    }
}