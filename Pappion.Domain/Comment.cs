using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pappion.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public decimal Grade { get; set; }
        public DateTime CreatedDate { get; set; }

        public Guid SenderId { get; set; }
        public User Sender { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public Guid? PartyId { get; set; }
        public Party Party { get; set; }
        public Guid? PostId { get; set; }
        public Post Post { get; set; }
        public Guid? FavorId { get; set; }
        public Favor Favor { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
