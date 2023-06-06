namespace Pappion.Domain
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public ICollection<PartyTags> PartyTags { get; set; }
        public ICollection<PostTags> PostTags { get; set; }
        public ICollection<UserTags> UserTags { get; set; }
        public ICollection<FavorTags> FavorTags { get; set; }
    }
}
