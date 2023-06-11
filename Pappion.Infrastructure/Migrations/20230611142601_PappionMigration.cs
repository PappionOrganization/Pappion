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
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, defaultValueSql: "(uuid())", collation: "ascii_general_ci"),
                    Path = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                })
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
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
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
                name: "FavorImages",
                columns: table => new
                {
                    FavorId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavorImages", x => new { x.FavorId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_FavorImages_Favors_FavorId",
                        column: x => x.FavorId,
                        principalTable: "Favors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavorImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
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
                name: "PartyImages",
                columns: table => new
                {
                    PartyId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PartyImages", x => new { x.PartyId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_PartyImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PartyImages_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
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
                name: "PostImages",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    ImageId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostImages", x => new { x.PostId, x.ImageId });
                    table.ForeignKey(
                        name: "FK_PostImages_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PostImages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
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
                table: "Images",
                columns: new[] { "Id", "Path" },
                values: new object[,]
                {
                    { new Guid("19203269-ec8e-45d9-ab4f-d1502ad94eec"), "9b76e9e5-e4c3-43b1-aa45-4e652ec699eb.png" },
                    { new Guid("572f1c26-363b-4121-afa9-9e296e5ad045"), "b7888fb1-1207-414c-a6cc-093501e728b6.png" },
                    { new Guid("64fdb42b-9d88-462b-ba09-1995df146ab3"), "4e0be48c-2382-4170-b967-c0947f134f65.png" },
                    { new Guid("82c8d3a6-5d22-473c-bd3b-6ecede003a15"), "ffafab99-2456-4f46-bd48-623dbed40b5f.png" },
                    { new Guid("99b34ba2-01eb-49ba-b145-9756ddd154a8"), "bcca28a6-139b-4577-91e1-31817de792df.png" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0e158ba4-e2c0-470a-bf68-150f29c3a375"), "Admin" },
                    { new Guid("4756fc6a-427e-48b5-a2c1-e63bc7274c6c"), "User" },
                    { new Guid("e577f21a-3707-4ed6-8268-eaee433a16fa"), "Resident" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0aea94ab-1131-4933-8e6c-beafb1cff31e"), "Сноуборд" },
                    { new Guid("16951066-201b-4332-8e4a-4160eeb8fe32"), "Настільні ігри" },
                    { new Guid("666a06b6-6fb1-41b0-8515-a2af75ef8e29"), "Лижі" },
                    { new Guid("9f0f8ceb-b8f9-495f-b207-17bb9fcfe66e"), "Кемпінг" },
                    { new Guid("b1b6cc19-25b4-4ab8-b9cc-e69bdfb93b2e"), "Велосипед" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImageId", "LastName", "Location", "Password", "Rating", "RoleId" },
                values: new object[,]
                {
                    { new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), "bossofthegym@gmail.com", "Біллі", new Guid("82c8d3a6-5d22-473c-bd3b-6ecede003a15"), "Герінґтон", null, "password", 2.5m, new Guid("e577f21a-3707-4ed6-8268-eaee433a16fa") },
                    { new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), "not.exist@gmail.com", "Тайлер", new Guid("64fdb42b-9d88-462b-ba09-1995df146ab3"), "Дьорден", null, "password", 5.0m, new Guid("e577f21a-3707-4ed6-8268-eaee433a16fa") },
                    { new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), "tatakae@gmail.com", "Еран", new Guid("19203269-ec8e-45d9-ab4f-d1502ad94eec"), "Єґа", null, "password", 1.5m, new Guid("e577f21a-3707-4ed6-8268-eaee433a16fa") },
                    { new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "harrypotter@gmail.com", "Гаррі", new Guid("572f1c26-363b-4121-afa9-9e296e5ad045"), "Поттер", null, "password", 3.5m, new Guid("4756fc6a-427e-48b5-a2c1-e63bc7274c6c") },
                    { new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), "killing.monsters@gmail.com", "Ґеральт", new Guid("99b34ba2-01eb-49ba-b145-9756ddd154a8"), "з Рівії", null, "password", 4.5m, new Guid("0e158ba4-e2c0-470a-bf68-150f29c3a375") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("6490fcb9-326f-46d7-b7d3-7bbd618e6a9f"), null, null, null, new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), "Біллі це дуже файний пацан! Стоп...", new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb") },
                    { new Guid("79d15b0b-fc5a-4bc5-8238-afc94f8ea69d"), null, null, null, new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), "Еран це дуже файний пацан! Стоп...", new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583") },
                    { new Guid("91483077-0460-4681-a6ba-34ed0986f021"), null, null, null, new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), "Ґеральт це дуже файний пацан! Стоп...", new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe") },
                    { new Guid("9ba61268-e4b4-4e3d-bc34-9eac4996181d"), null, null, null, new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), "Тайлер це дуже файний пацан! Стоп...", new Guid("69b372be-b113-427b-abc8-5b6c4e13638a") },
                    { new Guid("e37e3028-64d0-4e6a-9aea-f27c6323ad07"), null, null, null, new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Гаррі це дуже файний пацан! Стоп...", new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37") }
                });

            migrationBuilder.InsertData(
                table: "Favors",
                columns: new[] { "Id", "AuthorId", "Description", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("0b2cd57e-70ff-4f71-9447-c3adf8c6ad2a"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Найкращі майстри масажу готові показати всі свої вміння на вашій задубілій спині.", 50.5m, 0m, "Масаж" },
                    { new Guid("9b557f2d-7c09-4979-a298-164dd7eba446"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Розслабтеся і зосередьтеся на своєму тілі та розумі під час особистого сеансу йоги з досвідченим інструктором.", 55.3m, 0m, "Сеанс йоги" },
                    { new Guid("a58a3fef-b347-449f-846a-67ce30b6df88"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Досвідчений тренер допоможе вам досягнути ваших фітнес-цілей, розробивши індивідуальну тренувальну програму для вас.", 70.2m, 0m, "Персональний тренер" },
                    { new Guid("e7f6c4d4-2072-4e91-b2e3-9060877b2592"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Розкішний манікюр і педикюр, який зробить ваші нігті і ніжки неймовірно чудовими і доглянутими.", 45.8m, 0m, "Ретельна манікюр і педикюр" },
                    { new Guid("fb42d12f-59c9-45aa-827b-c6303e3f8977"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Отримайте розкішну косметичну процедуру, яка підкреслить вашу природну красу і зробить вашу шкіру сяючою.", 80.0m, 0m, "Косметична процедура" }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("3285d348-2cdf-41d7-97d4-1e8105443283"), null, null, null, null, new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583") },
                    { new Guid("6a460216-86cf-4eb0-99c5-dc7fd07c3663"), null, null, null, null, new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb") },
                    { new Guid("930e5a4a-dae9-43bc-81bd-402249bf8095"), null, null, null, null, new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe") },
                    { new Guid("aed5d499-c53b-400e-871e-84e6130a9e2c"), null, null, null, null, new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37") },
                    { new Guid("f1fca45e-8aaf-4ec6-9b87-0370e3986298"), null, null, null, null, new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), new Guid("69b372be-b113-427b-abc8-5b6c4e13638a") }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "AuthorId", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("34f016ae-83a9-48cd-8f95-72ac4c588f3f"), new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5495), "Шукаю людей, які так само захоплені гуртом 'Rammstein' і хотіли б піти на їхній концерт. Разом буде набагато веселіше! Хто бажає долучитися?", "Концерт Rammstein" },
                    { new Guid("92455345-381b-4771-bd6b-41898d1a1426"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5463), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("9649603d-fb17-44d3-bcd5-9813142cdb38"), new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5475), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("c34b45b1-e87b-42e0-afb5-6df24d2a5a4a"), new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5485), "Хтось цікавиться проведенням вечірки вдома з настільними іграми? Я маю гарну колекцію ігор і шукаю компанію для веселого проведення вечора. Приєднуйтесь!", "Вечірка вдома з настільними іграми" },
                    { new Guid("e57a640b-ede4-441b-8b9f-39a2e0a0467e"), new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5422), "Приходьте до мене сьогодні в джакузі, тут весело. Про оплату потім.", "Джакузі з скінхедом" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Phone", "UserId" },
                values: new object[,]
                {
                    { new Guid("09545dc9-64fc-4e62-b782-26e9a998708d"), "+380988234901", new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583") },
                    { new Guid("1ea036dc-9cf8-41af-9dad-35c1fb44dc1f"), "+380660981292", new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe") },
                    { new Guid("4208516f-22cb-4e6a-94ef-0ae3e9712aec"), "+380955647834", new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb") },
                    { new Guid("a66a7bd6-c60b-42bd-b67c-63004b5225f8"), "+380508672351", new Guid("69b372be-b113-427b-abc8-5b6c4e13638a") },
                    { new Guid("be063f47-08c2-4e73-ac21-3195afd9b48f"), "+380687654587", new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("05424771-6fcb-4e54-b77c-aa1cc0aa8fdb"), new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5340), "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!", null, "Неймовірні пейзажі Карпат" },
                    { new Guid("0af98481-bfc9-4888-a717-93d62b1f1f6f"), new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5355), "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!", null, "Зимові пригоди у Карпатах" },
                    { new Guid("14a808c3-3141-4d8a-b444-c6b522a9c2f2"), new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5317), "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!", null, "Незабутні враження від Карпат" },
                    { new Guid("9b19e35e-de58-4e36-a280-cebeeb7e753d"), new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5329), "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!", null, "Смаколики Карпатської кухні" },
                    { new Guid("a0e33d5d-7a7f-43a3-b29b-e11f4b966a7a"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), new DateTime(2023, 6, 11, 17, 26, 0, 577, DateTimeKind.Local).AddTicks(5234), "Карпати інфо шахраї! Я забронювала собі номер в одній з камер Азкабану, але дементори мене туди не впустили. Це жах!", null, "Увага!" }
                });

            migrationBuilder.InsertData(
                table: "UserTags",
                columns: new[] { "TagId", "UserId" },
                values: new object[,]
                {
                    { new Guid("9f0f8ceb-b8f9-495f-b207-17bb9fcfe66e"), new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb") },
                    { new Guid("b1b6cc19-25b4-4ab8-b9cc-e69bdfb93b2e"), new Guid("69b372be-b113-427b-abc8-5b6c4e13638a") },
                    { new Guid("0aea94ab-1131-4933-8e6c-beafb1cff31e"), new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583") },
                    { new Guid("666a06b6-6fb1-41b0-8515-a2af75ef8e29"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37") },
                    { new Guid("16951066-201b-4332-8e4a-4160eeb8fe32"), new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("16a56a9b-09ab-4674-aaa1-aa58e28e722c"), null, null, new Guid("05424771-6fcb-4e54-b77c-aa1cc0aa8fdb"), new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), "Неймовірні пейзажі Карпат це дуже корисна публікація!", null },
                    { new Guid("18809a9b-2e6e-4508-a185-2cc898c12236"), new Guid("fb42d12f-59c9-45aa-827b-c6303e3f8977"), null, null, new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), "Косметична процедура це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("34db0745-f06d-4061-b1f2-d02d9eccfdac"), new Guid("e7f6c4d4-2072-4e91-b2e3-9060877b2592"), null, null, new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), "Ретельна манікюр і педикюр це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("4c07a54f-8c7b-42a3-b36b-cec405362cfd"), null, new Guid("c34b45b1-e87b-42e0-afb5-6df24d2a5a4a"), null, new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), "Вечірка вдома з настільними іграми це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("6d02e87a-990a-4d55-a7b0-8983dc8e18a1"), null, new Guid("9649603d-fb17-44d3-bcd5-9813142cdb38"), null, new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("75727d13-0ddc-4eb3-9bf2-58a168703285"), null, null, new Guid("a0e33d5d-7a7f-43a3-b29b-e11f4b966a7a"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Увага! це дуже корисна публікація!", null },
                    { new Guid("8c63d208-d821-403e-ad9d-dc5b5e055b09"), null, null, new Guid("9b19e35e-de58-4e36-a280-cebeeb7e753d"), new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), "Смаколики Карпатської кухні це дуже корисна публікація!", null },
                    { new Guid("91c3f674-8924-44bd-ad42-a2363d9e4220"), new Guid("0b2cd57e-70ff-4f71-9447-c3adf8c6ad2a"), null, null, new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Масаж це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("a2f30716-5e23-441c-8a82-6e42a497e75a"), null, new Guid("92455345-381b-4771-bd6b-41898d1a1426"), null, new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("a5dde38c-f13a-43d4-aad5-b4ac5f6d87cb"), null, null, new Guid("14a808c3-3141-4d8a-b444-c6b522a9c2f2"), new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), "Незабутні враження від Карпат це дуже корисна публікація!", null },
                    { new Guid("b865d68a-df02-4e94-9bef-f5eb397eca82"), new Guid("9b557f2d-7c09-4979-a298-164dd7eba446"), null, null, new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), "Сеанс йоги це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("bb73ed0a-1715-4884-8f6b-601143ab45f1"), null, null, new Guid("0af98481-bfc9-4888-a717-93d62b1f1f6f"), new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), "Зимові пригоди у Карпатах це дуже корисна публікація!", null },
                    { new Guid("bfa99bc5-bdad-452e-995b-270816a78503"), null, new Guid("34f016ae-83a9-48cd-8f95-72ac4c588f3f"), null, new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), "Концерт Rammstein це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("c9bb68df-124c-4cd9-bbcd-fee6d7998c10"), new Guid("a58a3fef-b347-449f-846a-67ce30b6df88"), null, null, new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), "Персональний тренер це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("fed98627-4e5a-4499-80d6-096c2550856e"), null, new Guid("e57a640b-ede4-441b-8b9f-39a2e0a0467e"), null, new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), "Джакузі з скінхедом це звучить дуже цікаво! Я обов'язково прийду!", null }
                });

            migrationBuilder.InsertData(
                table: "FavorImages",
                columns: new[] { "FavorId", "ImageId" },
                values: new object[,]
                {
                    { new Guid("0b2cd57e-70ff-4f71-9447-c3adf8c6ad2a"), new Guid("572f1c26-363b-4121-afa9-9e296e5ad045") },
                    { new Guid("9b557f2d-7c09-4979-a298-164dd7eba446"), new Guid("82c8d3a6-5d22-473c-bd3b-6ecede003a15") },
                    { new Guid("a58a3fef-b347-449f-846a-67ce30b6df88"), new Guid("99b34ba2-01eb-49ba-b145-9756ddd154a8") },
                    { new Guid("e7f6c4d4-2072-4e91-b2e3-9060877b2592"), new Guid("64fdb42b-9d88-462b-ba09-1995df146ab3") },
                    { new Guid("fb42d12f-59c9-45aa-827b-c6303e3f8977"), new Guid("19203269-ec8e-45d9-ab4f-d1502ad94eec") }
                });

            migrationBuilder.InsertData(
                table: "FavorTags",
                columns: new[] { "FavorId", "TagId" },
                values: new object[,]
                {
                    { new Guid("0b2cd57e-70ff-4f71-9447-c3adf8c6ad2a"), new Guid("666a06b6-6fb1-41b0-8515-a2af75ef8e29") },
                    { new Guid("9b557f2d-7c09-4979-a298-164dd7eba446"), new Guid("9f0f8ceb-b8f9-495f-b207-17bb9fcfe66e") },
                    { new Guid("a58a3fef-b347-449f-846a-67ce30b6df88"), new Guid("16951066-201b-4332-8e4a-4160eeb8fe32") },
                    { new Guid("e7f6c4d4-2072-4e91-b2e3-9060877b2592"), new Guid("b1b6cc19-25b4-4ab8-b9cc-e69bdfb93b2e") },
                    { new Guid("fb42d12f-59c9-45aa-827b-c6303e3f8977"), new Guid("0aea94ab-1131-4933-8e6c-beafb1cff31e") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0244f0f2-6b54-4178-aa0a-6f3f4544e570"), null, null, null, new Guid("a0e33d5d-7a7f-43a3-b29b-e11f4b966a7a"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), null },
                    { new Guid("03334407-327e-4cde-97a7-d018d27093dc"), null, new Guid("e7f6c4d4-2072-4e91-b2e3-9060877b2592"), null, null, new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), null },
                    { new Guid("0bb869f0-f52c-4e9f-a238-d98b54835f64"), null, null, new Guid("92455345-381b-4771-bd6b-41898d1a1426"), null, new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), null },
                    { new Guid("196f05f8-be96-43f9-a39e-8cb607daa87c"), new Guid("e37e3028-64d0-4e6a-9aea-f27c6323ad07"), null, null, null, new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), null },
                    { new Guid("2ebe3325-05f1-49f4-a756-7ea7b7944517"), null, null, null, new Guid("0af98481-bfc9-4888-a717-93d62b1f1f6f"), new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), null },
                    { new Guid("3f08f39a-7133-4831-93d0-07ed9d7a859a"), null, null, null, new Guid("05424771-6fcb-4e54-b77c-aa1cc0aa8fdb"), new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), null },
                    { new Guid("46bb5db6-bfce-49d9-aef1-ce67ca818914"), null, null, new Guid("9649603d-fb17-44d3-bcd5-9813142cdb38"), null, new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), null },
                    { new Guid("4e060140-4b37-44c4-b9ba-b6eaffea934d"), null, null, new Guid("34f016ae-83a9-48cd-8f95-72ac4c588f3f"), null, new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), null },
                    { new Guid("689a1fba-07e6-4844-98e5-4fed6c6ae5f7"), null, null, null, new Guid("14a808c3-3141-4d8a-b444-c6b522a9c2f2"), new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), null },
                    { new Guid("6d041ca5-a6eb-471d-890e-2527ba413f05"), null, new Guid("fb42d12f-59c9-45aa-827b-c6303e3f8977"), null, null, new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), null },
                    { new Guid("83ac855b-df9e-4d5b-8600-cd723d5c6102"), null, new Guid("0b2cd57e-70ff-4f71-9447-c3adf8c6ad2a"), null, null, new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), null },
                    { new Guid("874ee5d1-7a10-4b02-9101-5c22afce048e"), null, null, null, new Guid("9b19e35e-de58-4e36-a280-cebeeb7e753d"), new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), null },
                    { new Guid("92efe2fe-f957-462a-baa9-f4790dcc5db6"), null, new Guid("a58a3fef-b347-449f-846a-67ce30b6df88"), null, null, new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), null },
                    { new Guid("9ec545bb-2b12-40c0-a6db-90a89b9e8811"), null, new Guid("9b557f2d-7c09-4979-a298-164dd7eba446"), null, null, new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), null },
                    { new Guid("f9c954cc-e81c-4a6c-988b-bc3c2e7a3a94"), null, null, new Guid("e57a640b-ede4-441b-8b9f-39a2e0a0467e"), null, new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), null },
                    { new Guid("f9e08a7d-53df-4db1-848d-590d5b210815"), null, null, new Guid("c34b45b1-e87b-42e0-afb5-6df24d2a5a4a"), null, new Guid("69b372be-b113-427b-abc8-5b6c4e13638a"), null }
                });

            migrationBuilder.InsertData(
                table: "PartyImages",
                columns: new[] { "ImageId", "PartyId" },
                values: new object[,]
                {
                    { new Guid("82c8d3a6-5d22-473c-bd3b-6ecede003a15"), new Guid("34f016ae-83a9-48cd-8f95-72ac4c588f3f") },
                    { new Guid("19203269-ec8e-45d9-ab4f-d1502ad94eec"), new Guid("92455345-381b-4771-bd6b-41898d1a1426") },
                    { new Guid("99b34ba2-01eb-49ba-b145-9756ddd154a8"), new Guid("9649603d-fb17-44d3-bcd5-9813142cdb38") },
                    { new Guid("64fdb42b-9d88-462b-ba09-1995df146ab3"), new Guid("c34b45b1-e87b-42e0-afb5-6df24d2a5a4a") },
                    { new Guid("572f1c26-363b-4121-afa9-9e296e5ad045"), new Guid("e57a640b-ede4-441b-8b9f-39a2e0a0467e") }
                });

            migrationBuilder.InsertData(
                table: "PartyTags",
                columns: new[] { "PartyId", "TagId" },
                values: new object[,]
                {
                    { new Guid("34f016ae-83a9-48cd-8f95-72ac4c588f3f"), new Guid("9f0f8ceb-b8f9-495f-b207-17bb9fcfe66e") },
                    { new Guid("92455345-381b-4771-bd6b-41898d1a1426"), new Guid("0aea94ab-1131-4933-8e6c-beafb1cff31e") },
                    { new Guid("9649603d-fb17-44d3-bcd5-9813142cdb38"), new Guid("16951066-201b-4332-8e4a-4160eeb8fe32") },
                    { new Guid("c34b45b1-e87b-42e0-afb5-6df24d2a5a4a"), new Guid("b1b6cc19-25b4-4ab8-b9cc-e69bdfb93b2e") },
                    { new Guid("e57a640b-ede4-441b-8b9f-39a2e0a0467e"), new Guid("666a06b6-6fb1-41b0-8515-a2af75ef8e29") }
                });

            migrationBuilder.InsertData(
                table: "PartyUsers",
                columns: new[] { "PartyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("34f016ae-83a9-48cd-8f95-72ac4c588f3f"), new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb") },
                    { new Guid("92455345-381b-4771-bd6b-41898d1a1426"), new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583") },
                    { new Guid("9649603d-fb17-44d3-bcd5-9813142cdb38"), new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe") },
                    { new Guid("c34b45b1-e87b-42e0-afb5-6df24d2a5a4a"), new Guid("69b372be-b113-427b-abc8-5b6c4e13638a") },
                    { new Guid("e57a640b-ede4-441b-8b9f-39a2e0a0467e"), new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37") }
                });

            migrationBuilder.InsertData(
                table: "PostImages",
                columns: new[] { "ImageId", "PostId" },
                values: new object[,]
                {
                    { new Guid("64fdb42b-9d88-462b-ba09-1995df146ab3"), new Guid("05424771-6fcb-4e54-b77c-aa1cc0aa8fdb") },
                    { new Guid("82c8d3a6-5d22-473c-bd3b-6ecede003a15"), new Guid("0af98481-bfc9-4888-a717-93d62b1f1f6f") },
                    { new Guid("19203269-ec8e-45d9-ab4f-d1502ad94eec"), new Guid("14a808c3-3141-4d8a-b444-c6b522a9c2f2") },
                    { new Guid("99b34ba2-01eb-49ba-b145-9756ddd154a8"), new Guid("9b19e35e-de58-4e36-a280-cebeeb7e753d") },
                    { new Guid("572f1c26-363b-4121-afa9-9e296e5ad045"), new Guid("a0e33d5d-7a7f-43a3-b29b-e11f4b966a7a") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("05424771-6fcb-4e54-b77c-aa1cc0aa8fdb"), new Guid("b1b6cc19-25b4-4ab8-b9cc-e69bdfb93b2e") },
                    { new Guid("0af98481-bfc9-4888-a717-93d62b1f1f6f"), new Guid("9f0f8ceb-b8f9-495f-b207-17bb9fcfe66e") },
                    { new Guid("14a808c3-3141-4d8a-b444-c6b522a9c2f2"), new Guid("0aea94ab-1131-4933-8e6c-beafb1cff31e") },
                    { new Guid("9b19e35e-de58-4e36-a280-cebeeb7e753d"), new Guid("16951066-201b-4332-8e4a-4160eeb8fe32") },
                    { new Guid("a0e33d5d-7a7f-43a3-b29b-e11f4b966a7a"), new Guid("666a06b6-6fb1-41b0-8515-a2af75ef8e29") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1292a6d3-4cc0-4068-a19f-7838c9be7f7d"), new Guid("a5dde38c-f13a-43d4-aad5-b4ac5f6d87cb"), null, null, null, new Guid("441fd4ce-a4ba-4503-b671-ae1aba9097bb"), null },
                    { new Guid("6ef37c22-f75e-411d-b5d7-a22f8c091e6d"), new Guid("75727d13-0ddc-4eb3-9bf2-58a168703285"), null, null, null, new Guid("da4c8bc8-5851-4985-a6d1-97e6bfec4b37"), null },
                    { new Guid("7d2fb88c-bb31-4dae-b99e-8c3b02dd6ebc"), new Guid("91c3f674-8924-44bd-ad42-a2363d9e4220"), null, null, null, new Guid("ed7048fa-29ca-43a1-a9d1-b35da6f256fe"), null },
                    { new Guid("c0034afa-b8e1-4b2d-a432-c2818507c6a7"), new Guid("fed98627-4e5a-4499-80d6-096c2550856e"), null, null, null, new Guid("b24d55b7-101e-4a8f-abb1-ac37c1a11583"), null }
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
                name: "IX_FavorImages_ImageId",
                table: "FavorImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Favors_AuthorId",
                table: "Favors",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_FavorTags_TagId",
                table: "FavorTags",
                column: "TagId");

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
                name: "IX_PartyImages_ImageId",
                table: "PartyImages",
                column: "ImageId");

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
                name: "IX_PostImages_ImageId",
                table: "PostImages",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ImageId",
                table: "Users",
                column: "ImageId");

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
                name: "FavorImages");

            migrationBuilder.DropTable(
                name: "FavorTags");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "PartyImages");

            migrationBuilder.DropTable(
                name: "PartyTags");

            migrationBuilder.DropTable(
                name: "PartyUsers");

            migrationBuilder.DropTable(
                name: "PhoneNumbers");

            migrationBuilder.DropTable(
                name: "PostImages");

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
                name: "Images");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
