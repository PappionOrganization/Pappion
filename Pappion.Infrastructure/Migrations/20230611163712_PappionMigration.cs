using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pappion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PappionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    FirstName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Favors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favors_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parties_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PhoneNumbers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Phone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneNumbers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Title = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AuthorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserTags",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TagId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTags", x => new { x.UserId, x.TagId });
                    table.ForeignKey(
                        name: "FK_UserTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserTags_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FavorTags",
                columns: table => new
                {
                    FavorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TagId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavorTags", x => new { x.FavorId, x.TagId });
                    table.ForeignKey(
                        name: "FK_FavorTags_Favors_FavorId",
                        column: x => x.FavorId,
                        principalTable: "Favors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavorTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartyTags",
                columns: table => new
                {
                    PartyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TagId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyTags", x => new { x.PartyId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PartyTags_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartyTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PartyUsers",
                columns: table => new
                {
                    PartyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyUsers", x => new { x.PartyId, x.UserId });
                    table.ForeignKey(
                        name: "FK_PartyUsers_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartyUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Text = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Grade = table.Column<decimal>(type: "decimal(65,30)", nullable: false, defaultValue: 0m),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    SenderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PartyId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PostId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FavorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Favors_FavorId",
                        column: x => x.FavorId,
                        principalTable: "Favors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PartyId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FavorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PostId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Favors_FavorId",
                        column: x => x.FavorId,
                        principalTable: "Favors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostTags",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TagId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTags", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTags_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    SenderId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PartyId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    PostId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    FavorId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci"),
                    CommentId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_Favors_FavorId",
                        column: x => x.FavorId,
                        principalTable: "Favors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("240cf5d2-f6aa-402f-bceb-8cbd572aeaab"), "Resident" },
                    { new Guid("3ff06725-fc1b-4f21-813f-aecbbcf94ab5"), "User" },
                    { new Guid("dc4832f8-2fe9-4307-bbe5-83fed639e4e2"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("2520cdf3-3932-4ed9-ba8c-f9d9149f8465"), "Велосипед" },
                    { new Guid("3b821ecd-de88-47c0-b365-3485847b6250"), "Сноуборд" },
                    { new Guid("4c6665dd-994d-49d7-abe5-b77b35f4be8d"), "Лижі" },
                    { new Guid("8d162146-4b15-48fe-bbe0-05e2e0966394"), "Настільні ігри" },
                    { new Guid("edd728e1-76d4-4c01-8f34-5e9ec75a6a95"), "Кемпінг" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Location", "Password", "Rating", "RoleId" },
                values: new object[,]
                {
                    { new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), "tatakae@gmail.com", "Еран", "Єґа", null, "password", 1.5m, new Guid("240cf5d2-f6aa-402f-bceb-8cbd572aeaab") },
                    { new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "harrypotter@gmail.com", "Гаррі", "Поттер", null, "password", 3.5m, new Guid("3ff06725-fc1b-4f21-813f-aecbbcf94ab5") },
                    { new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), "bossofthegym@gmail.com", "Біллі", "Герінґтон", null, "password", 2.5m, new Guid("240cf5d2-f6aa-402f-bceb-8cbd572aeaab") },
                    { new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), "killing.monsters@gmail.com", "Ґеральт", "з Рівії", null, "password", 4.5m, new Guid("dc4832f8-2fe9-4307-bbe5-83fed639e4e2") },
                    { new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), "not.exist@gmail.com", "Тайлер", "Дьорден", null, "password", 5.0m, new Guid("240cf5d2-f6aa-402f-bceb-8cbd572aeaab") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("0053cb1a-25f4-4afb-a255-d212bbfcc83c"), null, null, null, new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), "Біллі це дуже файний пацан! Стоп...", new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256") },
                    { new Guid("66a051b9-f45f-47a2-bfab-3d5b97d2122f"), null, null, null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Гаррі це дуже файний пацан! Стоп...", new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("823acf67-be09-4f5a-b63d-baa567e71978"), null, null, null, new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), "Ґеральт це дуже файний пацан! Стоп...", new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd") },
                    { new Guid("b3f0c151-946c-4469-b37c-e1e7178eba7e"), null, null, null, new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), "Тайлер це дуже файний пацан! Стоп...", new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f") },
                    { new Guid("f5ecf94f-2ff1-4510-ab79-51d5997506f4"), null, null, null, new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), "Еран це дуже файний пацан! Стоп...", new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab") }
                });

            migrationBuilder.InsertData(
                table: "Favors",
                columns: new[] { "Id", "AuthorId", "Description", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("05642f93-ba1c-4667-8508-b5327cf49900"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Отримайте розкішну косметичну процедуру, яка підкреслить вашу природну красу і зробить вашу шкіру сяючою.", 80.0m, 0m, "Косметична процедура" },
                    { new Guid("0d615659-569d-40a8-80d9-6aa6a6148956"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Досвідчений тренер допоможе вам досягнути ваших фітнес-цілей, розробивши індивідуальну тренувальну програму для вас.", 70.2m, 0m, "Персональний тренер" },
                    { new Guid("4a627a97-ea01-4e3d-b405-cafa8eaa46f6"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Розслабтеся і зосередьтеся на своєму тілі та розумі під час особистого сеансу йоги з досвідченим інструктором.", 55.3m, 0m, "Сеанс йоги" },
                    { new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Найкращі майстри масажу готові показати всі свої вміння на вашій задубілій спині.", 50.5m, 0m, "Масаж" },
                    { new Guid("f62048e4-b462-4164-9efb-9420fc35e93f"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Розкішний манікюр і педикюр, який зробить ваші нігті і ніжки неймовірно чудовими і доглянутими.", 45.8m, 0m, "Ретельна манікюр і педикюр" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("7062e329-d94f-46e1-8754-cc3ba2a5efe9"), null, null, "aa9c6552-d0e1-4cc7-8e0f-991d2b6a2695.png", null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("af083edb-a727-4573-af56-aa3119e45551"), null, null, "918b77f1-9887-4001-b172-83583c5e60ef.png", null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("bcfa3fde-65b7-4855-9540-ee9fc38e4fc8"), null, null, "c0d3ea5f-dcc8-4961-913c-a2f063d7a349.png", null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("d6803ec3-981f-4ec5-b6be-f71d09d96fda"), null, null, "bcb8106c-f532-46c5-aa05-579ee7c997c6.png", null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("e6b106c4-0fca-4fd3-821d-62a4a4da59d8"), null, null, "af5d85d9-4404-4e49-a922-53009d6752e0.png", null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a864eed-7eae-41fe-b617-9704c7417360"), null, null, null, null, new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd") },
                    { new Guid("2a2e2af3-e2e8-400c-964a-f8374515ee63"), null, null, null, null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("50d245f2-96f0-4976-b21f-93f845e0e4c9"), null, null, null, null, new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256") },
                    { new Guid("b12afac2-7bca-4702-a55d-aa36fee54ee7"), null, null, null, null, new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab") },
                    { new Guid("ecdf4edd-0600-4ce1-9b17-f0d4de102888"), null, null, null, null, new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f") }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "AuthorId", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("0c063b59-dd86-4e01-8ce7-5d9dcb36838b"), new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(1084), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("1c8ab47f-928e-4604-a37c-f22ec7306b9d"), new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(1120), "Шукаю людей, які так само захоплені гуртом 'Rammstein' і хотіли б піти на їхній концерт. Разом буде набагато веселіше! Хто бажає долучитися?", "Концерт Rammstein" },
                    { new Guid("752f4314-24bd-485d-bf0c-85e3fe303ea4"), new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(1104), "Хтось цікавиться проведенням вечірки вдома з настільними іграми? Я маю гарну колекцію ігор і шукаю компанію для веселого проведення вечора. Приєднуйтесь!", "Вечірка вдома з настільними іграми" },
                    { new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(1023), "Приходьте до мене сьогодні в джакузі, тут весело. Про оплату потім.", "Джакузі з скінхедом" },
                    { new Guid("d1a44c54-d95a-42a3-b6d2-87c63214bd87"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(1070), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Phone", "UserId" },
                values: new object[,]
                {
                    { new Guid("1eca53eb-6141-4e3e-9f88-9a18f98e193e"), "+380687654587", new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("36a287b9-5d74-4289-bb88-64b1323d4558"), "+380955647834", new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256") },
                    { new Guid("64527ab2-d142-42fa-9147-5177bac0b26f"), "+380988234901", new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab") },
                    { new Guid("8040df02-f810-4de8-80a3-d8cb7dd9d0f9"), "+380508672351", new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f") },
                    { new Guid("aa31ebe0-3f58-439b-b38b-24b5fe99da9a"), "+380660981292", new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("3c41c506-80b3-4742-a44d-10e4dc8f9fe4"), new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(675), "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!", null, "Неймовірні пейзажі Карпат" },
                    { new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(527), "Карпати інфо шахраї! Я забронювала собі номер в одній з камер Азкабану, але дементори мене туди не впустили. Це жах!", null, "Увага!" },
                    { new Guid("51e9de90-76be-4f27-8bd4-6b5c2937099a"), new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(641), "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!", null, "Незабутні враження від Карпат" },
                    { new Guid("cf237311-a526-4c1a-8ba8-4c1bb661ba71"), new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(691), "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!", null, "Зимові пригоди у Карпатах" },
                    { new Guid("fd75f018-abbc-45b0-b691-112abc1a2811"), new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), new DateTime(2023, 6, 11, 19, 37, 11, 878, DateTimeKind.Local).AddTicks(658), "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!", null, "Смаколики Карпатської кухні" }
                });

            migrationBuilder.InsertData(
                table: "UserTags",
                columns: new[] { "TagId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3b821ecd-de88-47c0-b365-3485847b6250"), new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab") },
                    { new Guid("4c6665dd-994d-49d7-abe5-b77b35f4be8d"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("edd728e1-76d4-4c01-8f34-5e9ec75a6a95"), new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256") },
                    { new Guid("8d162146-4b15-48fe-bbe0-05e2e0966394"), new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd") },
                    { new Guid("2520cdf3-3932-4ed9-ba8c-f9d9149f8465"), new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("19695b83-fcbd-4619-aeb5-70ec864cf3b7"), null, new Guid("752f4314-24bd-485d-bf0c-85e3fe303ea4"), null, new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), "Вечірка вдома з настільними іграми це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("22f0a6b7-2129-4936-813a-2e24130cbb7d"), null, null, new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Увага! це дуже корисна публікація!", null },
                    { new Guid("30613838-1c70-4f96-9d8c-559e3461c68c"), null, new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Джакузі з скінхедом це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("3814a39f-8332-431e-abc1-73a4a072eb22"), new Guid("05642f93-ba1c-4667-8508-b5327cf49900"), null, null, new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), "Косметична процедура це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("3b9dabc5-b365-4a45-979d-0cee670d140f"), new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), null, null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), "Масаж це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("40316343-3146-4a5e-a6d6-9d3f3765b38a"), null, null, new Guid("51e9de90-76be-4f27-8bd4-6b5c2937099a"), new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), "Незабутні враження від Карпат це дуже корисна публікація!", null },
                    { new Guid("47a48f98-7f80-43c8-99b1-1e8cb9a9ac9d"), null, new Guid("1c8ab47f-928e-4604-a37c-f22ec7306b9d"), null, new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), "Концерт Rammstein це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("58a9cc2f-4c6f-4f99-90c4-5961da061f78"), new Guid("0d615659-569d-40a8-80d9-6aa6a6148956"), null, null, new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), "Персональний тренер це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("5ff882ad-675e-442d-94a7-0fcbbd7ba863"), null, null, new Guid("cf237311-a526-4c1a-8ba8-4c1bb661ba71"), new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), "Зимові пригоди у Карпатах це дуже корисна публікація!", null },
                    { new Guid("65e7e4f9-d294-41a6-949f-c46e4d4d58af"), new Guid("f62048e4-b462-4164-9efb-9420fc35e93f"), null, null, new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), "Ретельна манікюр і педикюр це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("76cd9aef-d6fe-46c5-821b-16d4515b2e2c"), null, new Guid("0c063b59-dd86-4e01-8ce7-5d9dcb36838b"), null, new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("87af1501-ad0d-4572-92ae-e5019def8909"), null, null, new Guid("fd75f018-abbc-45b0-b691-112abc1a2811"), new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), "Смаколики Карпатської кухні це дуже корисна публікація!", null },
                    { new Guid("ad4db20b-673a-4672-8c0a-3b621c2a5d24"), new Guid("4a627a97-ea01-4e3d-b405-cafa8eaa46f6"), null, null, new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), "Сеанс йоги це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("b2528f2b-6aca-41ee-bf90-9a959a1af7b1"), null, new Guid("d1a44c54-d95a-42a3-b6d2-87c63214bd87"), null, new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("ed9217d5-19a5-4d71-a868-3e2e7a2d1fd3"), null, null, new Guid("3c41c506-80b3-4742-a44d-10e4dc8f9fe4"), new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), "Неймовірні пейзажі Карпат це дуже корисна публікація!", null }
                });

            migrationBuilder.InsertData(
                table: "FavorTags",
                columns: new[] { "FavorId", "TagId" },
                values: new object[,]
                {
                    { new Guid("05642f93-ba1c-4667-8508-b5327cf49900"), new Guid("3b821ecd-de88-47c0-b365-3485847b6250") },
                    { new Guid("0d615659-569d-40a8-80d9-6aa6a6148956"), new Guid("8d162146-4b15-48fe-bbe0-05e2e0966394") },
                    { new Guid("4a627a97-ea01-4e3d-b405-cafa8eaa46f6"), new Guid("edd728e1-76d4-4c01-8f34-5e9ec75a6a95") },
                    { new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), new Guid("4c6665dd-994d-49d7-abe5-b77b35f4be8d") },
                    { new Guid("f62048e4-b462-4164-9efb-9420fc35e93f"), new Guid("2520cdf3-3932-4ed9-ba8c-f9d9149f8465") }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("049e6498-a5ec-4a35-9b02-2f92e43d21c4"), null, null, "71456a51-0acc-46bb-b19e-723b3e1327ee.png", new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), null },
                    { new Guid("0a797ff5-7277-4269-99f6-1b63c81e5dd8"), null, new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), "d640729d-72c8-4bee-923e-eb9745305ffd.png", null, null },
                    { new Guid("125a1435-362a-4293-b597-5d0d705c4237"), new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), null, "145b8685-47d8-4b51-b98e-f11f5409a6c8.png", null, null },
                    { new Guid("17952fd9-f8a4-48ef-86cd-748edb17eb5f"), null, new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), "ea431ca5-0617-445b-88f1-3c8f62763e30.png", null, null },
                    { new Guid("1cc07206-18cf-4950-b0aa-32455193e7fa"), null, new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), "d1dc68ca-3720-438a-b86e-0c8d5e462a7e.png", null, null },
                    { new Guid("5d40dc34-3030-4dee-aa77-8b8b207ba1f9"), null, null, "b7ebc8cb-a584-43e2-9aa7-b5585093ee48.png", new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), null },
                    { new Guid("7510a8d7-b442-4433-ad50-ae5ee40a40ee"), null, null, "a91ff5b6-2d0e-4bba-8d67-60d514f89297.png", new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), null },
                    { new Guid("815ce203-f24d-40db-a7b3-8e8eeabf7054"), null, new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), "c5e9e99c-2e64-4e45-a06f-56e9cf5cdcf8.png", null, null },
                    { new Guid("9990da02-bde2-4042-84b0-989b6c453471"), null, new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), "ee886fff-5fc7-42d8-a7e3-762689aa787e.png", null, null },
                    { new Guid("aa2a2896-6f82-4039-84d1-5d191646d92c"), new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), null, "a4c40f2b-9fb8-4a54-bcb7-ee10bb6c37a3.png", null, null },
                    { new Guid("ae3f1217-d5dd-49ef-a3d7-e6f1d156aac2"), new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), null, "fe293152-f926-4c1f-9c79-e330ec798999.png", null, null },
                    { new Guid("c7849dba-1a27-46d4-9835-3a4ed2cb1588"), new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), null, "b13a3395-8cae-4e1f-b3f6-88f30d890aa5.png", null, null },
                    { new Guid("c851260f-2a25-44bc-ab97-a08c0e082292"), null, null, "960b4e12-1817-4476-87ec-5cb25034d1eb.png", new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), null },
                    { new Guid("d09ad1c4-c22d-40eb-8504-92b0a96bd7e4"), null, null, "ecc22aa0-772c-45be-aeda-80ee041280dd.png", new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), null },
                    { new Guid("f7db1ae6-2b4d-412d-b50b-7dea51dbbd6e"), new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), null, "afd6315b-1af7-409c-86bb-30a0c2eaff52.png", null, null }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("05d923aa-a035-45b6-80c9-8bd19ee53bba"), null, null, new Guid("752f4314-24bd-485d-bf0c-85e3fe303ea4"), null, new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), null },
                    { new Guid("33daac7a-3372-4ef9-be4a-b110a11677d0"), new Guid("66a051b9-f45f-47a2-bfab-3d5b97d2122f"), null, null, null, new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), null },
                    { new Guid("37795ed5-9e2b-4ef6-a16b-af21bff4c6ca"), null, null, null, new Guid("fd75f018-abbc-45b0-b691-112abc1a2811"), new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), null },
                    { new Guid("4afde064-99e3-4260-b0a9-04faca20cf3c"), null, null, null, new Guid("3c41c506-80b3-4742-a44d-10e4dc8f9fe4"), new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), null },
                    { new Guid("5861105b-4b92-4caa-b7a1-582048c4e193"), null, null, new Guid("1c8ab47f-928e-4604-a37c-f22ec7306b9d"), null, new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), null },
                    { new Guid("6f156f2d-a208-4406-92f7-7e9e033e6304"), null, new Guid("05642f93-ba1c-4667-8508-b5327cf49900"), null, null, new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), null },
                    { new Guid("91602c7a-60c5-4491-a671-d468e05ca621"), null, new Guid("4a627a97-ea01-4e3d-b405-cafa8eaa46f6"), null, null, new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), null },
                    { new Guid("aa86a620-288a-4751-aed8-559e98130527"), null, new Guid("b8055fc5-a21f-4873-958f-3278de1d5a09"), null, null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), null },
                    { new Guid("b181bb15-3236-4328-b94b-6defb3b8b489"), null, null, new Guid("0c063b59-dd86-4e01-8ce7-5d9dcb36838b"), null, new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), null },
                    { new Guid("c5d1e946-33bc-4c12-b27a-3fd58d437e5a"), null, null, null, new Guid("51e9de90-76be-4f27-8bd4-6b5c2937099a"), new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), null },
                    { new Guid("c679b181-647e-4f02-b697-62c78728f654"), null, null, null, new Guid("cf237311-a526-4c1a-8ba8-4c1bb661ba71"), new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), null },
                    { new Guid("cd72f292-e1e3-4743-9533-6a12455078c6"), null, null, new Guid("d1a44c54-d95a-42a3-b6d2-87c63214bd87"), null, new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), null },
                    { new Guid("de848a80-1588-41e1-952c-551668a64994"), null, new Guid("0d615659-569d-40a8-80d9-6aa6a6148956"), null, null, new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), null },
                    { new Guid("eb677eda-60ea-4315-be1a-327ec60bdebe"), null, new Guid("f62048e4-b462-4164-9efb-9420fc35e93f"), null, null, new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f"), null },
                    { new Guid("f0ec2820-b3f3-4ee5-8493-7f9ca069cccf"), null, null, new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), null },
                    { new Guid("f8521c0e-cd78-42d5-8638-9ada1caaa390"), null, null, null, new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), null }
                });

            migrationBuilder.InsertData(
                table: "PartyTags",
                columns: new[] { "PartyId", "TagId" },
                values: new object[,]
                {
                    { new Guid("0c063b59-dd86-4e01-8ce7-5d9dcb36838b"), new Guid("8d162146-4b15-48fe-bbe0-05e2e0966394") },
                    { new Guid("1c8ab47f-928e-4604-a37c-f22ec7306b9d"), new Guid("edd728e1-76d4-4c01-8f34-5e9ec75a6a95") },
                    { new Guid("752f4314-24bd-485d-bf0c-85e3fe303ea4"), new Guid("2520cdf3-3932-4ed9-ba8c-f9d9149f8465") },
                    { new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), new Guid("4c6665dd-994d-49d7-abe5-b77b35f4be8d") },
                    { new Guid("d1a44c54-d95a-42a3-b6d2-87c63214bd87"), new Guid("3b821ecd-de88-47c0-b365-3485847b6250") }
                });

            migrationBuilder.InsertData(
                table: "PartyUsers",
                columns: new[] { "PartyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0c063b59-dd86-4e01-8ce7-5d9dcb36838b"), new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd") },
                    { new Guid("1c8ab47f-928e-4604-a37c-f22ec7306b9d"), new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256") },
                    { new Guid("752f4314-24bd-485d-bf0c-85e3fe303ea4"), new Guid("f3fb177f-b3f0-4ee3-a6ac-d262c80a888f") },
                    { new Guid("ce5ba483-4819-4e14-a6b8-6384ca3f2bcb"), new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0") },
                    { new Guid("d1a44c54-d95a-42a3-b6d2-87c63214bd87"), new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("3c41c506-80b3-4742-a44d-10e4dc8f9fe4"), new Guid("2520cdf3-3932-4ed9-ba8c-f9d9149f8465") },
                    { new Guid("3fe067b7-9ca6-4f93-bcc2-2560087adfda"), new Guid("4c6665dd-994d-49d7-abe5-b77b35f4be8d") },
                    { new Guid("51e9de90-76be-4f27-8bd4-6b5c2937099a"), new Guid("3b821ecd-de88-47c0-b365-3485847b6250") },
                    { new Guid("cf237311-a526-4c1a-8ba8-4c1bb661ba71"), new Guid("edd728e1-76d4-4c01-8f34-5e9ec75a6a95") },
                    { new Guid("fd75f018-abbc-45b0-b691-112abc1a2811"), new Guid("8d162146-4b15-48fe-bbe0-05e2e0966394") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ff3dcfd-b839-40cd-8fa8-c19696314212"), new Guid("3b9dabc5-b365-4a45-979d-0cee670d140f"), null, null, null, new Guid("e81b937b-e3ad-4446-b7c7-fe8e77ce22fd"), null },
                    { new Guid("4b19c418-f9d1-4191-b7e7-1388591893c8"), new Guid("22f0a6b7-2129-4936-813a-2e24130cbb7d"), null, null, null, new Guid("998a7789-1aee-4dc7-9731-9610c0abd7d0"), null },
                    { new Guid("92e2cc61-739d-40c0-b1a5-9fbba65c5983"), new Guid("40316343-3146-4a5e-a6d6-9d3f3765b38a"), null, null, null, new Guid("a9a3cc65-9d71-48da-b2bb-2ac9adc16256"), null },
                    { new Guid("cd56f88d-5773-4c2c-88fa-9e92bde8d91c"), new Guid("30613838-1c70-4f96-9d8c-559e3461c68c"), null, null, null, new Guid("4ecc155b-f373-4b7c-965b-d6efbb46f2ab"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FavorId",
                table: "Comments",
                column: "FavorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PartyId",
                table: "Comments",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_SenderId",
                table: "Comments",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Favors_AuthorId",
                table: "Favors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_FavorTags_TagId",
                table: "FavorTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_FavorId",
                table: "Images",
                column: "FavorId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PartyId",
                table: "Images",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_PostId",
                table: "Images",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_UserId",
                table: "Images",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_FavorId",
                table: "Likes",
                column: "FavorId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PartyId",
                table: "Likes",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PostId",
                table: "Likes",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_SenderId",
                table: "Likes",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Parties_AuthorId",
                table: "Parties",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyTags_TagId",
                table: "PartyTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_PartyUsers_UserId",
                table: "PartyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_UserId",
                table: "PhoneNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTags_TagId",
                table: "UserTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavorTags");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "PartyTags");

            migrationBuilder.DropTable(
                name: "PartyUsers");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "PostTags");

            migrationBuilder.DropTable(
                name: "UserTags");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Favors");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
