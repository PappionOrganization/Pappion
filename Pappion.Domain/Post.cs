﻿namespace Pappion.Domain
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public string? Location { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }

        public ICollection<PostTags> PostTags { get; set; }
        public ICollection<PostImages> PostImages { get; set; }
    }
}
