using Microsoft.EntityFrameworkCore;
using Pappion.Domain;

namespace Pappion.Infrastructure
{
    public class PappionDbContext : DbContext
    {
        public PappionDbContext(DbContextOptions<PappionDbContext> options) : base(options) { }
            
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Favor> Favors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<PartyTags> PartyTags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<UserTags> UserTags { get; set; }
        public DbSet<FavorTags> FavorTags { get; set; }

        public DbSet<PartyUsers> PartyUsers { get; set; }
        public DbSet<FavorImages> FavorImages { get; set; }
        public DbSet<PartyImages> PartyImages { get; set; }
        public DbSet<PostImages> PostImages { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).HasDefaultValueSql("(uuid())");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).HasDefaultValueSql("(uuid())");
                entity.Property(u => u .CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                entity.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.LastName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Location).HasMaxLength(100);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(15);


                entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(u => u.Image)
                .WithMany(ie => ie.Users)
                .HasForeignKey(u => u.ImageId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasDefaultValueSql("(uuid())");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                entity.Property(p => p.Date).IsRequired();
                entity.Property(p => p.Title).IsRequired().HasMaxLength(30);
                entity.Property(p => p.Description).IsRequired().HasMaxLength(2000);

                entity.HasOne(p => p.Author)
                .WithMany(a => a.Parties)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id).HasDefaultValueSql("(uuid())");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                entity.Property(p => p.Title).IsRequired().HasMaxLength(30);
                entity.Property(p => p.Description).IsRequired();
                entity.Property(p => p.Location).HasMaxLength(100);

                entity.HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Favor>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id).HasDefaultValueSql("(uuid())");
                entity.Property(f => f.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                entity.Property(f => f.Title).IsRequired().HasMaxLength(30);
                entity.Property(f => f.Description).IsRequired();
                entity.Property(f => f.Price).IsRequired();
                entity.Property(f => f.Rating).IsRequired();

                entity.HasOne(f => f.Author)
                .WithMany(a => a.Favors)
                .HasForeignKey(f => f.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Id).HasDefaultValueSql("(uuid())");
                entity.Property(l => l.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.HasOne(l => l.Sender)
                .WithMany(s => s.LikesSended)
                .HasForeignKey(l => l.SenderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(l => l.Party)
               .WithMany(p => p.Likes)
               .HasForeignKey(l => l.PartyId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(l => l.Post)
               .WithMany(p => p.Likes)
               .HasForeignKey(l => l.PostId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(l => l.Favor)
               .WithMany(f => f.Likes)
               .HasForeignKey(l => l.FavorId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(l => l.Comment)
               .WithMany(c => c.Likes)
               .HasForeignKey(l => l.CommentId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(l => l.User)
               .WithMany(u => u.Likes)
               .HasForeignKey(l => l.UserId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id).HasDefaultValueSql("(uuid())");
                entity.Property(c => c.Text).IsRequired();
                entity.Property(c => c.Grade).HasDefaultValue(0);
                entity.Property(c => c.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.HasOne(c => c.Sender)
                .WithMany(s => s.CommentsSended)
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.Party)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.PartyId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.Post)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.PostId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.Favor)
               .WithMany(f => f.Comments)
               .HasForeignKey(c => c.FavorId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Id).HasDefaultValueSql("(uuid())");
                entity.Property(a => a.Phone).IsRequired();

                entity.HasOne(p => p.User)
                .WithMany(u => u.PhoneNumbers)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasDefaultValueSql("(uuid())");
                entity.Property(t => t.Name).IsRequired();
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(im => im.Id);
                entity.Property(im => im.Id).HasDefaultValueSql("(uuid())");
                entity.Property(im => im.Path).IsRequired();
            });

            modelBuilder.Entity<FavorTags>(entity =>
            {
                entity.HasKey(ft => new { ft.FavorId, ft.TagId });

                entity.HasOne(ft => ft.Favor)
                .WithMany(f => f.FavorTags)
                .HasForeignKey(ft => ft.FavorId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(ft => ft.Tag)
                .WithMany(t => t.FavorTags)
                .HasForeignKey(ft => ft.TagId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PartyTags>(entity =>
            {
                entity.HasKey(pt => new { pt.PartyId, pt.TagId });

                entity.HasOne(pt => pt.Party)
                .WithMany(p => p.PartyTags)
                .HasForeignKey(pt => pt.PartyId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(pt => pt.Tag)
                .WithMany(t => t.PartyTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PostTags>(entity =>
            {
                entity.HasKey(pt => new {pt.PostId, pt.TagId});

                entity.HasOne(pt => pt.Post)
                .WithMany(p => p.PostTags)
                .HasForeignKey(pt => pt.PostId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<UserTags>(entity =>
            {
                entity.HasKey(ut => new { ut.UserId, ut.TagId });

                entity.HasOne(ut => ut.User)
                .WithMany(u => u.UserTags)
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(ut => ut.Tag)
                .WithMany(t => t.UserTags)
                .HasForeignKey(ut => ut.TagId)
                .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<PartyUsers>(entity =>
            {
                entity.HasKey(pu => new { pu.PartyId, pu.UserId });

                entity.HasOne(pu => pu.Party)
                .WithMany(p => p.PartyUsers)
                .HasForeignKey(pu => pu.PartyId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(pu => pu.User)
                .WithMany(u => u.PartyUsers)
                .HasForeignKey(pu => pu.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<FavorImages>(entity =>
            {
                entity.HasKey(fi => new { fi.FavorId, fi.ImageId });

                entity.HasOne(fi => fi.Favor)
                .WithMany(f => f.FavorImages)
                .HasForeignKey(fi => fi.FavorId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(fi => fi.Image)
                .WithMany(im => im.FavorImages)
                .HasForeignKey(fi => fi.ImageId)
                .OnDelete(DeleteBehavior.NoAction);
                

            });

            modelBuilder.Entity<PartyImages>(entity =>
            {
                entity.HasKey(pi => new {pi.PartyId, pi.ImageId});

                entity.HasOne(pi => pi.Party)
                .WithMany(p => p.PartyImages)
                .HasForeignKey(pi => pi.PartyId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(pi => pi.Image)
                .WithMany(im => im.PartyImages)
                .HasForeignKey(pi => pi.ImageId)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<PostImages>(entity =>
            {
                entity.HasKey(pi => new {pi.PostId, pi.ImageId});

                entity.HasOne(pi => pi.Post)
                .WithMany(p => p.PostImages)
                .HasForeignKey(pi => pi.PostId)
                .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(pi => pi.Image)
                .WithMany(im => im.PostImages)
                .HasForeignKey(pi => pi.ImageId)
                .OnDelete(DeleteBehavior.NoAction);
            });
        }   
    }
}
