﻿using Microsoft.EntityFrameworkCore;
using Pappion.Domain.Entities;

namespace Pappion.Infrastructure
{
    public class PappionDbContext : DbContext
    {
        public PappionDbContext(DbContextOptions<PappionDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Favor> Favors { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PartyUsers> PartyUsers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Id).HasDefaultValueSql("(uuid())");
                entity.Property(u => u.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                entity.Property(u => u.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.LastName).IsRequired().HasMaxLength(100);
                entity.Property(u => u.Role).IsRequired().HasConversion<string>().HasMaxLength(20);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.PhoneNumber).IsRequired().HasMaxLength(15);
                entity.Property(u => u.PhoneNumber2).IsRequired(false).HasMaxLength(15);
                entity.Property(u => u.Location).HasMaxLength(100);
                entity.Property(u => u.Password).IsRequired().HasMaxLength(100);
            });

            modelBuilder.Entity<Party>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Id).HasDefaultValueSql("(uuid())");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                entity.Property(p => p.Date).IsRequired();
                entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).IsRequired().HasMaxLength(2000);

                entity.HasOne(p => p.Author)
                .WithMany(a => a.Parties)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.Property(p => p.Id).HasDefaultValueSql("(uuid())");
                entity.Property(p => p.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                entity.Property(p => p.Title).IsRequired().HasMaxLength(100);
                entity.Property(p => p.Description).IsRequired();
                entity.Property(p => p.Location).HasMaxLength(100);

                entity.HasOne(p => p.Author)
                .WithMany(a => a.Posts)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Favor>(entity =>
            {
                entity.HasKey(f => f.Id);
                entity.Property(f => f.Id).HasDefaultValueSql("(uuid())");
                entity.Property(f => f.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
                entity.Property(f => f.Title).IsRequired().HasMaxLength(100);
                entity.Property(f => f.Description).IsRequired();
                entity.Property(f => f.Price).IsRequired();

                entity.HasOne(f => f.Author)
                .WithMany(a => a.Favors)
                .HasForeignKey(f => f.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.HasKey(l => l.Id);
                entity.Property(l => l.Id).HasDefaultValueSql("(uuid())");
                entity.Property(l => l.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.HasOne(l => l.Sender)
                .WithMany(s => s.LikesSent)
                .HasForeignKey(l => l.SenderId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(l => l.Party)
               .WithMany(p => p.Likes)
               .HasForeignKey(l => l.PartyId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(l => l.Post)
               .WithMany(p => p.Likes)
               .HasForeignKey(l => l.PostId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(l => l.Favor)
               .WithMany(f => f.Likes)
               .HasForeignKey(l => l.FavorId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(l => l.Comment)
               .WithMany(c => c.Likes)
               .HasForeignKey(l => l.CommentId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(l => l.User)
               .WithMany(u => u.Likes)
               .HasForeignKey(l => l.UserId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Id).HasDefaultValueSql("(uuid())");
                entity.Property(c => c.Text).IsRequired();
                entity.Property(c => c.Grade).HasDefaultValue(0);
                entity.Property(c => c.CreatedDate).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");

                entity.HasOne(c => c.Sender)
                .WithMany(s => s.CommentsSent)
                .HasForeignKey(c => c.SenderId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Party)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.PartyId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Post)
               .WithMany(p => p.Comments)
               .HasForeignKey(c => c.PostId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.Favor)
               .WithMany(f => f.Comments)
               .HasForeignKey(c => c.FavorId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(c => c.User)
               .WithMany(u => u.Comments)
               .HasForeignKey(c => c.UserId)
               .IsRequired(false)
               .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasKey(im => im.Id);
                entity.Property(im => im.Id).HasDefaultValueSql("(uuid())");
                entity.Property(im => im.Path).IsRequired();

                entity.HasOne(im => im.Post)
                .WithMany(p => p.Images)
                .HasForeignKey(im => im.PostId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(im => im.Favor)
                .WithMany(f => f.Images)
                .HasForeignKey(im => im.FavorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(im => im.User)
                .WithOne(u => u.Image)
                .HasForeignKey<Image>(im => im.UserId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(im => im.Party)
                .WithMany(p => p.Images)
                .HasForeignKey(im => im.PartyId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<PartyUsers>(entity =>
            {
                entity.HasKey(pu => new { pu.PartyId, pu.UserId });

                entity.HasOne(pu => pu.Party)
                .WithMany(p => p.PartyUsers)
                .HasForeignKey(pu => pu.PartyId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(pu => pu.User)
                .WithMany(u => u.PartyUsers)
                .HasForeignKey(pu => pu.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            Seed.SeedData(modelBuilder);
        }
    }
}
