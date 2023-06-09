using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Pappion.Domain.Entities;
using System.Data;

namespace Pappion.Infrastructure
{
    public class Seed
    {
        
        public static void SeedData(ModelBuilder modelBuilder)
        {
            List<Image> images = new List<Image> 
            {
                new Image
                {
                    Id = Guid.NewGuid(),
                    Path = $"{Guid.NewGuid()}.png"
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Path = $"{Guid.NewGuid()}.png"
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Path = $"{Guid.NewGuid()}.png"
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Path = $"{Guid.NewGuid()}.png"
                },
                new Image
                {
                    Id = Guid.NewGuid(),
                    Path = $"{Guid.NewGuid()}.png"
                }
            };
            List<Tag> tags = new List<Tag>
        {
            new Tag{Id = Guid.NewGuid(), Name = "Лижі"},
            new Tag{Id = Guid.NewGuid(), Name = "Сноуборд"},
            new Tag{Id = Guid.NewGuid(), Name = "Настільні ігри"},
            new Tag{Id = Guid.NewGuid(), Name = "Велосипед"},
            new Tag{Id = Guid.NewGuid(), Name = "Кемпінг"}
        };
            List<Role> roles = new()
        {
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "User"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Resident"
                },
                new Role
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin"
                }
            };
            List<User> users = new()
        {
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Гаррі",
                    LastName = "Поттер",
                    Email= "harrypotter@gmail.com",
                    Password = "password",
                    Rating = 3.5M,
                    RoleId = roles[0].Id,
                    ImageId = images[0].Id
                },
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Еран",
                    LastName = "Єґа",
                    Email= "tatakae@gmail.com",
                    Password = "password",
                    Rating = 1.5M,
                    RoleId = roles[1].Id,
                    ImageId = images[1].Id
                },
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Ґеральт",
                    LastName = "з Рівії",
                    Email= "killing.monsters@gmail.com",
                    Password = "password",
                    Rating = 4.5M,
                    RoleId = roles[2].Id,
                    ImageId = images[2].Id
                },
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Тайлер",
                    LastName = "Дьорден",
                    Email= "not.exist@gmail.com",
                    Password = "password",
                    Rating = 5.0M,
                    RoleId = roles[1].Id,
                    ImageId = images[3].Id
                },
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Біллі",
                    LastName = "Герінґтон",
                    Email= "bossofthegym@gmail.com",
                    Password = "password",
                    Rating = 2.5M,
                    RoleId = roles[2].Id,
                    ImageId = images[4].Id
                },

            };
            List<UserTags> userTags = new();
            List<PostTags> postTags = new();
            List<PostImages> postImages = new();
            List<Post> posts = new()
        {
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Увага!",
                    Description = "Карпати інфо шахраї! Я забронювала собі номер в одній " +
                    "з камер Азкабану, але дементори мене туди не впустили. Це жах!",
                    AuthorId = users[0].Id

                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Незабутні враження від Карпат",
                    Description = "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!",
                    AuthorId = users[1].Id
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Смаколики Карпатської кухні",
                    Description = "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!",
                    AuthorId = users[2].Id
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Неймовірні пейзажі Карпат",
                    Description = "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!",
                    AuthorId = users[3].Id
                },
                new Post
                {
                    Id = Guid.NewGuid(),
                    Title = "Зимові пригоди у Карпатах",
                    Description = "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!",
                    AuthorId = users[4].Id
                },
            };
            List<Like> likes = new();
            List<Comment> comments = new();

            for (int i = 0; i < 5; i++)
            {
                comments.AddRange(new List<Comment>
                {
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        SenderId = users[i].Id,
                        Text = $"{posts[i].Title} це дуже корисна публікація!",
                        PostId = posts[i].Id
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        SenderId = users[i].Id,
                        Text = $"{users[i].FirstName} це дуже файний пацан! Стоп...",
                        UserId = users[i].Id
                    }
                });
                likes.AddRange(new List<Like>
                {
                    new Like
                    {
                        Id = Guid.NewGuid(),
                        SenderId = users[i].Id,
                        PostId = posts[i].Id
                    },
                    new Like
                    {
                        Id = Guid.NewGuid(),
                        SenderId = users[i].Id,
                        UserId = users[i].Id
                    },
                    new Like
                    {
                        Id = Guid.NewGuid(),
                        SenderId = users[i].Id,
                        CommentId = comments[i].Id
                    }
                });
                userTags.Add(new UserTags
                {
                    UserId = users[i].Id,
                    TagId = tags[i].Id
                });
                
                postTags.Add(new PostTags
                {
                    PostId = posts[i].Id,
                    TagId = tags[i].Id
                });
                postImages.Add(new PostImages
                {
                    PostId = posts[i].Id,
                    ImageId = images[i].Id
                });
            }
            modelBuilder.Entity<Image>()
               .HasData(images);
            modelBuilder.Entity<Role>()
               .HasData(roles);
            modelBuilder.Entity<User>()
                .HasData(users);
            modelBuilder.Entity<Post>()
                .HasData(posts);
            modelBuilder.Entity<Like>()
                .HasData(likes);
            modelBuilder.Entity<Comment>()
               .HasData(comments);
            modelBuilder.Entity<Tag>()
               .HasData(tags);
            modelBuilder.Entity<PostTags>()
                .HasData(postTags);
            modelBuilder.Entity<UserTags>()
                .HasData(userTags);
            modelBuilder.Entity<PostImages>()
                .HasData(postImages);

        }

    }
}
