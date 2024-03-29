﻿using Microsoft.EntityFrameworkCore;
using Pappion.Domain.Constants;
using Pappion.Domain.Entities;
using Pappion.Infrastructure.Auth;

namespace Pappion.Infrastructure
{
    public class Seed
    {
        private static PasswordService passwordService = new PasswordService();

        

        public static void SeedData(ModelBuilder modelBuilder)
        {
            List<Image> images = new();
            List<User> users = new()
        {
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Гаррі",
                    LastName = "Поттер",
                    Email= "harrypotter@gmail.com",
                    Password = passwordService.Hash("password"),
                    PhoneNumber = "+38000000000",
                    Role = UserRoles.User
                },
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Еран",
                    LastName = "Єґа",
                    Email= "tatakae@gmail.com",
                    PhoneNumber = "+38000000000",
                    Password = passwordService.Hash("password"),
                    Role = UserRoles.User
                },
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Ґеральт",
                    LastName = "з Рівії",
                    Email= "killing.monsters@gmail.com",
                    PhoneNumber = "+38000000000",
                    Password = passwordService.Hash("password"),
                    Role = UserRoles.User
                },
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Тайлер",
                    LastName = "Дьорден",
                    Email= "not.exist@gmail.com",
                    PhoneNumber = "+38000000000",
                    Password = passwordService.Hash("password"),
                    Role = UserRoles.User
                },
                new User{
                    Id = Guid.NewGuid(),
                    FirstName = "Біллі",
                    LastName = "Герінґтон",
                    Email= "bossofthegym@gmail.com",
                    PhoneNumber = "+38000000000",
                    Password = passwordService.Hash("password"),
                    Role = UserRoles.User
                },

            };
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
            List<Favor> favors = new List<Favor>
            
            {
                new Favor
                {
                    Id = Guid.NewGuid(),
                    Title = "Масаж",
                    Description = "Найкращі майстри масажу готові показати всі свої вміння на вашій задубілій спині.",
                    Price = 50.5M,
                    AuthorId = users[0].Id
                    
                },
                new Favor
                {
                    Id = Guid.NewGuid(),
                    Title = "Косметична процедура",
                    Description = "Отримайте розкішну косметичну процедуру, яка підкреслить вашу природну красу і зробить вашу шкіру сяючою.",
                    Price = 80.0M,
                    AuthorId = users[0].Id
                },
                new Favor
                {
                    Id = Guid.NewGuid(),
                    Title = "Персональний тренер",
                    Description = "Досвідчений тренер допоможе вам досягнути ваших фітнес-цілей, розробивши індивідуальну тренувальну програму для вас.",
                    Price = 70.2M,
                    AuthorId = users[0].Id
                },
                new Favor
                {
                    Id = Guid.NewGuid(),
                    Title = "Ретельна манікюр і педикюр",
                    Description = "Розкішний манікюр і педикюр, який зробить ваші нігті і ніжки неймовірно чудовими і доглянутими.",
                    Price = 45.8M,
                    AuthorId = users[0].Id
                },
                new Favor
                {
                    Id = Guid.NewGuid(),
                    Title = "Сеанс йоги",
                    Description = "Розслабтеся і зосередьтеся на своєму тілі та розумі під час особистого сеансу йоги з досвідченим інструктором.",
                    Price = 55.3M,
                    AuthorId = users[0 ].Id
                },
            };
            List<Party> parties = new List<Party>
            {
                new Party
                {
                    Id = Guid.NewGuid(),
                    Title = "Джакузі з скінхедом",
                    Description = "Приходьте до мене сьогодні в джакузі, тут весело. Про оплату потім.",
                    AuthorId = users[4].Id,
                    Date= DateTime.Now
                },
                new Party
                {
                    Id = Guid.NewGuid(),
                    Title = "Вечірня прогулянка по місту",
                    Description = "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!",
                    AuthorId = users[0].Id,
                    Date = DateTime.Now
                },
                new Party
                {
                    Id = Guid.NewGuid(),
                    Title = "Вечірня прогулянка по місту",
                    Description = "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!",
                    AuthorId = users[1].Id,
                    Date = DateTime.Now
                },
                new Party
                {
                    Id = Guid.NewGuid(),
                    Title = "Вечірка вдома з настільними іграми",
                    Description = "Хтось цікавиться проведенням вечірки вдома з настільними іграми? Я маю гарну колекцію ігор і шукаю компанію для веселого проведення вечора. Приєднуйтесь!",
                    AuthorId = users[2].Id,
                    Date = DateTime.Now
                },
                new Party
                {
                    Id = Guid.NewGuid(),
                    Title = "Концерт Rammstein",
                    Description = "Шукаю людей, які так само захоплені гуртом 'Rammstein' і хотіли б піти на їхній концерт. Разом буде набагато веселіше! Хто бажає долучитися?",
                    AuthorId = users[3].Id,
                    Date = DateTime.Now
                }

            };
            List<PartyUsers> partyUsers = new();
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
                        Text = $"{parties[i].Title} це звучить дуже цікаво! Я обов'язково прийду!",
                        PartyId = parties[i].Id
                    },
                    new Comment
                    {
                        Id = Guid.NewGuid(),
                        SenderId = users[i].Id,
                        Text = $"{favors[i].Title} це дуже крута послуга! Раджу всім спробувати!",
                        FavorId = favors[i].Id
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
                        FavorId = favors[i].Id
                    },
                    new Like
                    {
                        Id = Guid.NewGuid(),
                        SenderId = users[i].Id,
                        PartyId = parties[i].Id
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

                images.AddRange(new List<Image>
                {
                    new Image
                    {
                        Id = Guid.NewGuid(),
                        Path = $"{Guid.NewGuid()}.png",
                        UserId = users[i].Id
                    },
                    new Image
                    {
                        Id = Guid.NewGuid(),
                        Path = $"{Guid.NewGuid()}.png",
                        PostId = posts[i].Id
                    },
                    new Image
                    {
                        Id = Guid.NewGuid(),
                        Path = $"{Guid.NewGuid()}.png",
                        PartyId = parties[i].Id   
                    },
                    new Image
                    {
                        Id = Guid.NewGuid(),
                        Path = $"{Guid.NewGuid()}.png",
                        FavorId = favors[i].Id
                    },
                });
    
                partyUsers.Add(new PartyUsers
                {
                    PartyId = parties[i].Id,
                    UserId = users[i].Id
                });
            }
            modelBuilder.Entity<Image>()
               .HasData(images);
            modelBuilder.Entity<User>()
                .HasData(users);
            modelBuilder.Entity<Post>()
                .HasData(posts);
            modelBuilder.Entity<Favor>()
                .HasData(favors);
            modelBuilder.Entity<Party>()
                .HasData(parties);
            modelBuilder.Entity<Like>()
                .HasData(likes);
            modelBuilder.Entity<Comment>()
               .HasData(comments);
            modelBuilder.Entity<PartyUsers>()
                .HasData(partyUsers);

        }

    }
}
