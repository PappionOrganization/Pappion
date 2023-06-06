namespace Pappion.Domain.Entities
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Path { get; set; } = string.Empty;

        //1:n
        public ICollection<User> Users { get; set; }
        public ICollection<PartyImages> PartyImages { get; set; }
        public ICollection<PostImages> PostImages { get; set; }
        public ICollection<FavorImages> FavorImages { get; set; }
    }
}
