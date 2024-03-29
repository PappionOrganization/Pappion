﻿namespace Pappion.Domain.Entities
{
    public class Party
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Tags { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<PartyUsers> PartyUsers { get; set; }
        public ICollection<Image> Images { get; set; }

    }
}
