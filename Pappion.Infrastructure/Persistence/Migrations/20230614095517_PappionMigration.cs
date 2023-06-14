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
                    Password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
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
                    { new Guid("2cdfb1ff-d24c-4e11-8c4a-136f713dee30"), "User" },
                    { new Guid("56f475b6-430a-4201-8e08-9f2ee83887e0"), "Resident" },
                    { new Guid("a7a0853a-f622-4a64-b1d4-5a1acbbf40c1"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("40f77412-864f-4293-8bf0-8f5c0c02530c"), "Настільні ігри" },
                    { new Guid("73c4768a-ec00-4dd8-a205-3c5d19633809"), "Велосипед" },
                    { new Guid("7da5fee9-3459-4967-a4fc-5216dc8800a7"), "Сноуборд" },
                    { new Guid("822d5ea4-b116-4cc6-a4ec-5d873cc01ff4"), "Лижі" },
                    { new Guid("b86de954-ec7c-4b93-90e7-00478e51e689"), "Кемпінг" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Location", "Password", "Rating", "RoleId" },
                values: new object[,]
                {
                    { new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), "killing.monsters@gmail.com", "Ґеральт", "з Рівії", null, "TaT8QFxQRAVtbjboHzaq6g==;Ew+XiDem9296NGADXzbhAiLnJr8WSDmylGAAwXVF6PI=", 4.5m, new Guid("a7a0853a-f622-4a64-b1d4-5a1acbbf40c1") },
                    { new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), "bossofthegym@gmail.com", "Біллі", "Герінґтон", null, "y7fqJb1fyaJ5szjYAhjb2Q==;lWAa8BxyRJQoU/sV25k7fZVV+WjiZPep/7EpKoIJJ48=", 2.5m, new Guid("56f475b6-430a-4201-8e08-9f2ee83887e0") },
                    { new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), "tatakae@gmail.com", "Еран", "Єґа", null, "20Xx32GA1tgFTjFBdWvfFA==;UlqtoowWR8jSyDTEAW/7n75IkHJmcqD/ZOiXrE+X9b4=", 1.5m, new Guid("56f475b6-430a-4201-8e08-9f2ee83887e0") },
                    { new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), "not.exist@gmail.com", "Тайлер", "Дьорден", null, "TP0+oWCNMzWs/Vj7ufYwWA==;C6GEnXFQH8iIKo37QyGr8nIRSx1waw8r9uOqL6Z79wE=", 5.0m, new Guid("56f475b6-430a-4201-8e08-9f2ee83887e0") },
                    { new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "harrypotter@gmail.com", "Гаррі", "Поттер", null, "Hd3UAjkimPC7AdBLqZ5TXw==;3Rl6CPUezOhm1VVzceuOoXi7ANkEu0oYYn+ynVt6hIc=", 3.5m, new Guid("2cdfb1ff-d24c-4e11-8c4a-136f713dee30") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("4f43c652-7b99-44d8-a420-79966cdcbf76"), null, null, null, new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), "Ґеральт це дуже файний пацан! Стоп...", new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877") },
                    { new Guid("5de59748-2bba-452a-a2c0-a6cf0461a1ed"), null, null, null, new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), "Тайлер це дуже файний пацан! Стоп...", new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41") },
                    { new Guid("63452f27-9195-4dfb-9ee2-8ab37d4f7105"), null, null, null, new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), "Біллі це дуже файний пацан! Стоп...", new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b") },
                    { new Guid("82b61da4-aebf-4071-a77b-16dd3b4b926f"), null, null, null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Гаррі це дуже файний пацан! Стоп...", new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") },
                    { new Guid("95ac2d53-580e-431e-bbeb-ca5638deaf65"), null, null, null, new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), "Еран це дуже файний пацан! Стоп...", new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2") }
                });

            migrationBuilder.InsertData(
                table: "Favors",
                columns: new[] { "Id", "AuthorId", "Description", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Найкращі майстри масажу готові показати всі свої вміння на вашій задубілій спині.", 50.5m, 0m, "Масаж" },
                    { new Guid("50d1fe9d-0328-4edc-a3c8-44a017a01f5b"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Розкішний манікюр і педикюр, який зробить ваші нігті і ніжки неймовірно чудовими і доглянутими.", 45.8m, 0m, "Ретельна манікюр і педикюр" },
                    { new Guid("ae0d69b4-e15a-441d-bd9e-2ee7be0629e7"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Розслабтеся і зосередьтеся на своєму тілі та розумі під час особистого сеансу йоги з досвідченим інструктором.", 55.3m, 0m, "Сеанс йоги" },
                    { new Guid("e2d9525b-28c0-4827-8b90-ce4aec19db99"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Досвідчений тренер допоможе вам досягнути ваших фітнес-цілей, розробивши індивідуальну тренувальну програму для вас.", 70.2m, 0m, "Персональний тренер" },
                    { new Guid("fbd8b343-ecd3-4695-b163-e7e12b7bbd0c"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Отримайте розкішну косметичну процедуру, яка підкреслить вашу природну красу і зробить вашу шкіру сяючою.", 80.0m, 0m, "Косметична процедура" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("23fa92c2-50e0-4e1a-883c-96d2da0e712a"), null, null, "946f9cb2-d7df-4b33-8c3d-faba1e938992.png", null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") },
                    { new Guid("375210f4-e71f-4763-8006-c6f29b742ac5"), null, null, "b98fe946-5d13-4781-b389-2c3e8da333e0.png", null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") },
                    { new Guid("3e0a97c0-341e-4354-a111-631b9878e07f"), null, null, "cb7373e8-7616-49bb-a94c-13aa892ed8ee.png", null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") },
                    { new Guid("89d440f1-948e-4b2f-860a-88737fb0b1fd"), null, null, "d36f2242-3dfe-4491-a494-55d6fffec9a8.png", null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") },
                    { new Guid("d8915b42-be50-42b5-b9cc-5925f32137ee"), null, null, "62f3c309-4212-49c9-8466-38fb2a8096f9.png", null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0a122ed0-d13f-4c3b-a5c1-c168076c01a2"), null, null, null, null, new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41") },
                    { new Guid("0e0d19e1-d658-45a3-b1bb-3f291d46de1a"), null, null, null, null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") },
                    { new Guid("97e94ab5-2f9e-4b7a-9044-771a24d0385a"), null, null, null, null, new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b") },
                    { new Guid("f113c401-a90e-4454-9ba3-082c046b2c7e"), null, null, null, null, new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877") },
                    { new Guid("f13adedf-1195-42cb-997b-064d43628589"), null, null, null, null, new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2") }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "AuthorId", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(829), "Приходьте до мене сьогодні в джакузі, тут весело. Про оплату потім.", "Джакузі з скінхедом" },
                    { new Guid("b0c0c9ba-1b00-474c-8a76-13e4e348f75e"), new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(878), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("b2dacf23-fdf2-4ae9-ba6f-824d35d8fcb0"), new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(885), "Хтось цікавиться проведенням вечірки вдома з настільними іграми? Я маю гарну колекцію ігор і шукаю компанію для веселого проведення вечора. Приєднуйтесь!", "Вечірка вдома з настільними іграми" },
                    { new Guid("e0d94930-0578-405d-a218-6cda688bd778"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(835), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("f106260f-1c90-49a1-944d-59e2a0f49be2"), new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(891), "Шукаю людей, які так само захоплені гуртом 'Rammstein' і хотіли б піти на їхній концерт. Разом буде набагато веселіше! Хто бажає долучитися?", "Концерт Rammstein" }
                });

            migrationBuilder.InsertData(
                table: "PhoneNumbers",
                columns: new[] { "Id", "Phone", "UserId" },
                values: new object[,]
                {
                    { new Guid("26a4ad95-86e6-49cd-bc27-c8f45581684e"), "+380988234901", new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2") },
                    { new Guid("744ad1f4-18c9-4799-adf5-37dc7ff7bb4d"), "+380508672351", new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41") },
                    { new Guid("af7a75a2-9104-4af3-8f05-0dd38a18b519"), "+380687654587", new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") },
                    { new Guid("dba9b0aa-306b-47b4-a283-ca99b5a4b87a"), "+380955647834", new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b") },
                    { new Guid("e223801f-e551-493b-9a57-7de74aadd8cd"), "+380660981292", new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("5b438114-8c0f-4595-8f47-3f53f572ac34"), new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(791), "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!", null, "Зимові пригоди у Карпатах" },
                    { new Guid("b089e754-41f3-4881-8fcb-848e4437a9b3"), new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(745), "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!", null, "Смаколики Карпатської кухні" },
                    { new Guid("b0bf0a6c-b8c0-48a3-ba82-17ed13cf72f2"), new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(740), "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!", null, "Незабутні враження від Карпат" },
                    { new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(693), "Карпати інфо шахраї! Я забронювала собі номер в одній з камер Азкабану, але дементори мене туди не впустили. Це жах!", null, "Увага!" },
                    { new Guid("f35e555e-44b3-48ab-8d2e-98f86145e693"), new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), new DateTime(2023, 6, 14, 12, 55, 17, 126, DateTimeKind.Local).AddTicks(750), "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!", null, "Неймовірні пейзажі Карпат" }
                });

            migrationBuilder.InsertData(
                table: "UserTags",
                columns: new[] { "TagId", "UserId" },
                values: new object[,]
                {
                    { new Guid("40f77412-864f-4293-8bf0-8f5c0c02530c"), new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877") },
                    { new Guid("b86de954-ec7c-4b93-90e7-00478e51e689"), new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b") },
                    { new Guid("7da5fee9-3459-4967-a4fc-5216dc8800a7"), new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2") },
                    { new Guid("73c4768a-ec00-4dd8-a205-3c5d19633809"), new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41") },
                    { new Guid("822d5ea4-b116-4cc6-a4ec-5d873cc01ff4"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("044977bb-198d-4f0c-b843-fc99a667c8e5"), null, null, new Guid("f35e555e-44b3-48ab-8d2e-98f86145e693"), new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), "Неймовірні пейзажі Карпат це дуже корисна публікація!", null },
                    { new Guid("0dd1206a-f55b-4dcd-91c3-fa81f17a1d03"), null, new Guid("b2dacf23-fdf2-4ae9-ba6f-824d35d8fcb0"), null, new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), "Вечірка вдома з настільними іграми це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("472960bb-9eb0-49b1-9e0d-36d372099715"), new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), null, null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Масаж це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("4b1ae366-9a07-4bed-b2b6-dcbd78bc7043"), null, null, new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Увага! це дуже корисна публікація!", null },
                    { new Guid("71fb923f-fe80-4413-a270-1cd018ada140"), new Guid("ae0d69b4-e15a-441d-bd9e-2ee7be0629e7"), null, null, new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), "Сеанс йоги це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("7a79dd25-8dd6-46b3-bc1a-af21ce713d7f"), null, new Guid("b0c0c9ba-1b00-474c-8a76-13e4e348f75e"), null, new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("81fc31f1-54c1-4eab-ab45-897442d33740"), null, new Guid("f106260f-1c90-49a1-944d-59e2a0f49be2"), null, new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), "Концерт Rammstein це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("83c74cfa-73b0-4fd2-88b1-75650002776b"), new Guid("e2d9525b-28c0-4827-8b90-ce4aec19db99"), null, null, new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), "Персональний тренер це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("89c3866d-4b3b-458d-8629-f3650bd2314a"), null, null, new Guid("b089e754-41f3-4881-8fcb-848e4437a9b3"), new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), "Смаколики Карпатської кухні це дуже корисна публікація!", null },
                    { new Guid("8c8e7794-d783-4732-9fa1-bbfa3969a00e"), null, new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), "Джакузі з скінхедом це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("a28c9278-42c7-4114-b7ee-11c52b03ccd0"), null, new Guid("e0d94930-0578-405d-a218-6cda688bd778"), null, new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("b987045d-b639-4542-afcd-eda7a4933edd"), null, null, new Guid("b0bf0a6c-b8c0-48a3-ba82-17ed13cf72f2"), new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), "Незабутні враження від Карпат це дуже корисна публікація!", null },
                    { new Guid("ca6bd045-571c-489b-a5cb-8beefbecebdd"), new Guid("fbd8b343-ecd3-4695-b163-e7e12b7bbd0c"), null, null, new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), "Косметична процедура це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("da6d4955-29fc-4a19-8940-993e5b5ff713"), new Guid("50d1fe9d-0328-4edc-a3c8-44a017a01f5b"), null, null, new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), "Ретельна манікюр і педикюр це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("fe5a904b-e12a-4506-adbd-299150d13071"), null, null, new Guid("5b438114-8c0f-4595-8f47-3f53f572ac34"), new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), "Зимові пригоди у Карпатах це дуже корисна публікація!", null }
                });

            migrationBuilder.InsertData(
                table: "FavorTags",
                columns: new[] { "FavorId", "TagId" },
                values: new object[,]
                {
                    { new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), new Guid("822d5ea4-b116-4cc6-a4ec-5d873cc01ff4") },
                    { new Guid("50d1fe9d-0328-4edc-a3c8-44a017a01f5b"), new Guid("73c4768a-ec00-4dd8-a205-3c5d19633809") },
                    { new Guid("ae0d69b4-e15a-441d-bd9e-2ee7be0629e7"), new Guid("b86de954-ec7c-4b93-90e7-00478e51e689") },
                    { new Guid("e2d9525b-28c0-4827-8b90-ce4aec19db99"), new Guid("40f77412-864f-4293-8bf0-8f5c0c02530c") },
                    { new Guid("fbd8b343-ecd3-4695-b163-e7e12b7bbd0c"), new Guid("7da5fee9-3459-4967-a4fc-5216dc8800a7") }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("05b9ac19-0308-4379-aa03-917bb76cfb10"), null, new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), "ab384644-ec9e-4bf0-8e76-6446204d77df.png", null, null },
                    { new Guid("0d3bce39-d309-4696-a2ff-120fd78d7d6a"), null, null, "9733c761-8212-4973-ad62-bd9d267cb662.png", new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), null },
                    { new Guid("217ed1f7-82d8-44fd-a255-45920e60ada7"), null, null, "8e7f6dc0-6bef-4e01-a275-0839f0741dd5.png", new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), null },
                    { new Guid("23682aa4-9b25-4f21-98ed-21a142579b37"), new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), null, "14ad304b-7b47-4e9c-9949-7d024d67d9f9.png", null, null },
                    { new Guid("2423c911-c161-4606-a759-bc2ca36e4597"), null, null, "1b03b35a-990c-48c5-a77e-d00c32570a52.png", new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), null },
                    { new Guid("38b7d1d4-283e-4213-8c04-62cb30818ef1"), null, new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), "18472e33-1eb3-4b09-8892-041a22d61d89.png", null, null },
                    { new Guid("4227df7d-f2c1-4395-b294-1a5361d7075d"), new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), null, "8d1ddf68-3f20-4bbd-a4df-6c52df020c7a.png", null, null },
                    { new Guid("689647e6-7171-4996-ab31-b9acf83b038d"), null, null, "34847184-0642-4c25-ae81-c8305b484d7b.png", new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), null },
                    { new Guid("8381cb66-fbbe-4e81-a3f6-ba5d6cee30c4"), null, new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), "e8010730-41f2-4526-9bbd-dae1eae2c99c.png", null, null },
                    { new Guid("86e6a3d7-eb55-4a86-b38c-a059faeb56a8"), new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), null, "1d56447d-b0f0-4de7-9b58-81690054f72a.png", null, null },
                    { new Guid("a4573548-fb4f-4e09-8ed0-ecd511cb33bb"), new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), null, "6fb427d4-aaae-491e-8860-7e471c1e71ef.png", null, null },
                    { new Guid("a53a77c9-8e45-482c-b7cd-f0b89cded87a"), null, new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), "a9b35e70-01a3-4221-88cc-224751ea1b83.png", null, null },
                    { new Guid("a9c35a63-bff3-4665-8981-4bbd70d088ef"), new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), null, "335044a3-65c1-4e2f-9406-f3541ea9cf01.png", null, null },
                    { new Guid("b76ab3c6-2442-493c-8a0b-4d0b3edde5cf"), null, null, "980e451f-c97c-4807-af5f-fa12df9104ac.png", new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), null },
                    { new Guid("f80fbc0e-8942-483d-b21e-9ad386d2d334"), null, new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), "ad78917a-6513-4940-a97f-153b55504448.png", null, null }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("050cf4ad-b16a-449c-a073-076a798cf551"), null, null, null, new Guid("b089e754-41f3-4881-8fcb-848e4437a9b3"), new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), null },
                    { new Guid("0a45e5cf-05b7-4857-9fdd-925e5f4a5370"), null, null, null, new Guid("5b438114-8c0f-4595-8f47-3f53f572ac34"), new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), null },
                    { new Guid("0f837b72-b780-4478-a7b7-845c609f11c8"), null, null, new Guid("b0c0c9ba-1b00-474c-8a76-13e4e348f75e"), null, new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), null },
                    { new Guid("19426836-ffa9-47ef-90f7-2fc7571181c4"), null, new Guid("fbd8b343-ecd3-4695-b163-e7e12b7bbd0c"), null, null, new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), null },
                    { new Guid("243ebb3a-ba07-4de2-b763-67aef7c14708"), null, null, null, new Guid("b0bf0a6c-b8c0-48a3-ba82-17ed13cf72f2"), new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), null },
                    { new Guid("3dbcff47-2ad2-4fe3-a121-eb2dd4d6c87d"), null, new Guid("50d1fe9d-0328-4edc-a3c8-44a017a01f5b"), null, null, new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), null },
                    { new Guid("44233740-a3e0-4096-87b8-fcd43d9e28c0"), new Guid("82b61da4-aebf-4071-a77b-16dd3b4b926f"), null, null, null, new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), null },
                    { new Guid("48a4efb2-b5a4-4742-a10e-cc927030f86d"), null, null, new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), null },
                    { new Guid("6b5dc170-6aa0-4ee1-a9c0-a41c1f483956"), null, new Guid("3d27f1ff-c1fb-468d-94e1-636e7987888f"), null, null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), null },
                    { new Guid("7d66d831-aa37-4218-8f20-337c28588dc9"), null, null, new Guid("e0d94930-0578-405d-a218-6cda688bd778"), null, new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), null },
                    { new Guid("7d6fa6d5-934e-4488-9312-338408fbfd7b"), null, new Guid("ae0d69b4-e15a-441d-bd9e-2ee7be0629e7"), null, null, new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), null },
                    { new Guid("b6b07f21-ef96-4899-8372-305e8a0575e6"), null, null, null, new Guid("f35e555e-44b3-48ab-8d2e-98f86145e693"), new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), null },
                    { new Guid("d009ea65-5761-4fdd-824c-2b909bcc46f1"), null, null, new Guid("b2dacf23-fdf2-4ae9-ba6f-824d35d8fcb0"), null, new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41"), null },
                    { new Guid("e7fddd00-3709-4401-ad8e-c2a25c59bd77"), null, null, null, new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), null },
                    { new Guid("ea0538dc-0b3c-47df-ab77-09639ff7f400"), null, new Guid("e2d9525b-28c0-4827-8b90-ce4aec19db99"), null, null, new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), null },
                    { new Guid("f1b80986-0a09-424b-9919-fc7a87315574"), null, null, new Guid("f106260f-1c90-49a1-944d-59e2a0f49be2"), null, new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), null }
                });

            migrationBuilder.InsertData(
                table: "PartyTags",
                columns: new[] { "PartyId", "TagId" },
                values: new object[,]
                {
                    { new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), new Guid("822d5ea4-b116-4cc6-a4ec-5d873cc01ff4") },
                    { new Guid("b0c0c9ba-1b00-474c-8a76-13e4e348f75e"), new Guid("40f77412-864f-4293-8bf0-8f5c0c02530c") },
                    { new Guid("b2dacf23-fdf2-4ae9-ba6f-824d35d8fcb0"), new Guid("73c4768a-ec00-4dd8-a205-3c5d19633809") },
                    { new Guid("e0d94930-0578-405d-a218-6cda688bd778"), new Guid("7da5fee9-3459-4967-a4fc-5216dc8800a7") },
                    { new Guid("f106260f-1c90-49a1-944d-59e2a0f49be2"), new Guid("b86de954-ec7c-4b93-90e7-00478e51e689") }
                });

            migrationBuilder.InsertData(
                table: "PartyUsers",
                columns: new[] { "PartyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6cc33e2e-9ad2-4653-ba57-26ab95848ac9"), new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6") },
                    { new Guid("b0c0c9ba-1b00-474c-8a76-13e4e348f75e"), new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877") },
                    { new Guid("b2dacf23-fdf2-4ae9-ba6f-824d35d8fcb0"), new Guid("91db9dc2-b2d4-47cf-9263-3769ca00aa41") },
                    { new Guid("e0d94930-0578-405d-a218-6cda688bd778"), new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2") },
                    { new Guid("f106260f-1c90-49a1-944d-59e2a0f49be2"), new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("5b438114-8c0f-4595-8f47-3f53f572ac34"), new Guid("b86de954-ec7c-4b93-90e7-00478e51e689") },
                    { new Guid("b089e754-41f3-4881-8fcb-848e4437a9b3"), new Guid("40f77412-864f-4293-8bf0-8f5c0c02530c") },
                    { new Guid("b0bf0a6c-b8c0-48a3-ba82-17ed13cf72f2"), new Guid("7da5fee9-3459-4967-a4fc-5216dc8800a7") },
                    { new Guid("ec91538e-6957-4b50-aa06-ef8c2b6d5083"), new Guid("822d5ea4-b116-4cc6-a4ec-5d873cc01ff4") },
                    { new Guid("f35e555e-44b3-48ab-8d2e-98f86145e693"), new Guid("73c4768a-ec00-4dd8-a205-3c5d19633809") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("6978ba43-0bb8-4c0e-a9a4-ca05f4f2bdf6"), new Guid("8c8e7794-d783-4732-9fa1-bbfa3969a00e"), null, null, null, new Guid("7a78a5ba-77f6-4c8b-99d3-772a39caa3d2"), null },
                    { new Guid("6bba2562-8513-4108-95d7-e69aa28ec0d9"), new Guid("4b1ae366-9a07-4bed-b2b6-dcbd78bc7043"), null, null, null, new Guid("d2732cc0-4f0a-4cf8-b24f-62657dbafed6"), null },
                    { new Guid("d44d5dec-8359-472b-ad3d-1a85fde114ba"), new Guid("b987045d-b639-4542-afcd-eda7a4933edd"), null, null, null, new Guid("72a6edf3-2ff5-474f-9b45-3d1fa55cf16b"), null },
                    { new Guid("d8cdb1e3-e5c3-4a07-9620-392723332c0e"), new Guid("472960bb-9eb0-49b1-9e0d-36d372099715"), null, null, null, new Guid("3af4fbdf-59e1-42f9-8898-ff7dfd783877"), null }
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
