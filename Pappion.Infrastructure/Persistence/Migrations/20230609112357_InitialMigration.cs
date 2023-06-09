using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Pappion.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    FirstName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
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
                    Title = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
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
                    Title = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
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
                    Title = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false)
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
                    { new Guid("0d041849-6db3-4121-823e-292792be1160"), "9b99c996-2e80-45c8-a915-393d79d8408a.png" },
                    { new Guid("a9f631fc-cccd-4a1a-85ef-d8e3a1080c94"), "a22e6b90-2f26-4355-a03f-6612ff03453d.png" },
                    { new Guid("b66f9c9c-566c-42ce-8eb5-8b115160ff65"), "e0086126-583f-4897-a034-d9f5ad887c38.png" },
                    { new Guid("bb4de83a-6bb0-48ed-a93f-cf1153b905b4"), "cf4d95ea-ef96-4836-b536-a4cfa6f763c7.png" },
                    { new Guid("feadd9cc-1f41-4913-8b07-0df9d81a51b9"), "c654d531-dac8-419a-87f7-07dd234118fc.png" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("35166f95-0fba-49eb-a8fd-18c5fa0f67db"), "User" },
                    { new Guid("898fe428-53b7-4f5d-ab90-569056306b81"), "Resident" },
                    { new Guid("fb2864bc-9d83-47b0-8320-56c9d197a714"), "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("25d50f0e-0b34-482e-b186-234aaae45a04"), "Сноуборд" },
                    { new Guid("38a2b74c-e813-468e-be79-b84aa5122536"), "Кемпінг" },
                    { new Guid("61207f9b-99f9-46fb-a165-c163f667c05b"), "Настільні ігри" },
                    { new Guid("af3ae483-929a-4c10-93b9-efb1886156ab"), "Велосипед" },
                    { new Guid("d8cce667-ab65-4536-a65f-30163239fdc4"), "Лижі" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "ImageId", "LastName", "Location", "Password", "Rating", "RoleId" },
                values: new object[,]
                {
                    { new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8"), "bossofthegym@gmail.com", "Біллі", new Guid("0d041849-6db3-4121-823e-292792be1160"), "Герінґтон", null, "password", 2.5m, new Guid("fb2864bc-9d83-47b0-8320-56c9d197a714") },
                    { new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620"), "harrypotter@gmail.com", "Гаррі", new Guid("a9f631fc-cccd-4a1a-85ef-d8e3a1080c94"), "Поттер", null, "password", 3.5m, new Guid("35166f95-0fba-49eb-a8fd-18c5fa0f67db") },
                    { new Guid("7c183954-3105-4c15-85c8-25d802f80444"), "tatakae@gmail.com", "Еран", new Guid("b66f9c9c-566c-42ce-8eb5-8b115160ff65"), "Єґа", null, "password", 1.5m, new Guid("898fe428-53b7-4f5d-ab90-569056306b81") },
                    { new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01"), "killing.monsters@gmail.com", "Ґеральт", new Guid("bb4de83a-6bb0-48ed-a93f-cf1153b905b4"), "з Рівії", null, "password", 4.5m, new Guid("fb2864bc-9d83-47b0-8320-56c9d197a714") },
                    { new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70"), "not.exist@gmail.com", "Тайлер", new Guid("feadd9cc-1f41-4913-8b07-0df9d81a51b9"), "Дьорден", null, "password", 5.0m, new Guid("898fe428-53b7-4f5d-ab90-569056306b81") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("2dcd3d38-2051-4f1d-999f-caa713a06dc5"), null, null, null, new Guid("7c183954-3105-4c15-85c8-25d802f80444"), "Еран це дуже файний пацан! Стоп...", new Guid("7c183954-3105-4c15-85c8-25d802f80444") },
                    { new Guid("5f748a4c-d184-416e-bede-e15681d1fcbf"), null, null, null, new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01"), "Ґеральт це дуже файний пацан! Стоп...", new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01") },
                    { new Guid("604a0989-395f-43f3-accf-51de92b6969b"), null, null, null, new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8"), "Біллі це дуже файний пацан! Стоп...", new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8") },
                    { new Guid("c13b1312-537d-46d2-9708-41fe5e224fb3"), null, null, null, new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70"), "Тайлер це дуже файний пацан! Стоп...", new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70") },
                    { new Guid("f1f5404f-d8fb-4857-8f3c-5d7a44d41239"), null, null, null, new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620"), "Гаррі це дуже файний пацан! Стоп...", new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("31a39ff1-2f1d-4639-a3fb-bdb3c3238871"), null, null, null, null, new Guid("7c183954-3105-4c15-85c8-25d802f80444"), new Guid("7c183954-3105-4c15-85c8-25d802f80444") },
                    { new Guid("52a314d3-4c6c-4751-8687-39d3cddb4ad4"), null, null, null, null, new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620"), new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620") },
                    { new Guid("6ccf79ef-fc3d-4c59-b57e-f0fd4b9591b5"), null, null, null, null, new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70"), new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70") },
                    { new Guid("773ed362-bb73-4270-a7ff-6c1e79e8216a"), null, null, null, null, new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8"), new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8") },
                    { new Guid("a08e114e-5b36-4aeb-9a5a-f52f5794010c"), null, null, null, null, new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01"), new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01") }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("15d225f5-a1a4-44c5-a95b-7c253e49aebd"), new Guid("7c183954-3105-4c15-85c8-25d802f80444"), new DateTime(2023, 6, 9, 14, 23, 57, 574, DateTimeKind.Local).AddTicks(6989), "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!", null, "Незабутні враження від Карпат" },
                    { new Guid("4e4bfb8e-18ae-4b63-96b4-dfe7ba49b422"), new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01"), new DateTime(2023, 6, 9, 14, 23, 57, 574, DateTimeKind.Local).AddTicks(6996), "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!", null, "Смаколики Карпатської кухні" },
                    { new Guid("6ffeae74-bee4-4363-8dda-0c35a56cc196"), new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620"), new DateTime(2023, 6, 9, 14, 23, 57, 574, DateTimeKind.Local).AddTicks(6931), "Карпати інфо шахраї! Я забронювала собі номер в одній з камер Азкабану, але дементори мене туди не впустили. Це жах!", null, "Увага!" },
                    { new Guid("7324a2dd-c7e6-4733-8546-729480427ee1"), new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8"), new DateTime(2023, 6, 9, 14, 23, 57, 574, DateTimeKind.Local).AddTicks(7010), "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!", null, "Зимові пригоди у Карпатах" },
                    { new Guid("d8f90b51-d740-414b-a5e9-8e53be29b038"), new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70"), new DateTime(2023, 6, 9, 14, 23, 57, 574, DateTimeKind.Local).AddTicks(7003), "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!", null, "Неймовірні пейзажі Карпат" }
                });

            migrationBuilder.InsertData(
                table: "UserTags",
                columns: new[] { "TagId", "UserId" },
                values: new object[,]
                {
                    { new Guid("38a2b74c-e813-468e-be79-b84aa5122536"), new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8") },
                    { new Guid("d8cce667-ab65-4536-a65f-30163239fdc4"), new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620") },
                    { new Guid("25d50f0e-0b34-482e-b186-234aaae45a04"), new Guid("7c183954-3105-4c15-85c8-25d802f80444") },
                    { new Guid("61207f9b-99f9-46fb-a165-c163f667c05b"), new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01") },
                    { new Guid("af3ae483-929a-4c10-93b9-efb1886156ab"), new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("20e3aa12-ab7b-4268-a192-7cfbd016d66b"), null, null, new Guid("d8f90b51-d740-414b-a5e9-8e53be29b038"), new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70"), "Неймовірні пейзажі Карпат це дуже корисна публікація!", null },
                    { new Guid("44614829-36e3-4513-a18c-6e2f84e7b0c9"), null, null, new Guid("7324a2dd-c7e6-4733-8546-729480427ee1"), new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8"), "Зимові пригоди у Карпатах це дуже корисна публікація!", null },
                    { new Guid("6136b1d6-f67e-4d70-8990-136d4b77de16"), null, null, new Guid("6ffeae74-bee4-4363-8dda-0c35a56cc196"), new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620"), "Увага! це дуже корисна публікація!", null },
                    { new Guid("667e0e5c-302f-4ca0-a045-291caafcc157"), null, null, new Guid("15d225f5-a1a4-44c5-a95b-7c253e49aebd"), new Guid("7c183954-3105-4c15-85c8-25d802f80444"), "Незабутні враження від Карпат це дуже корисна публікація!", null },
                    { new Guid("980f7b4d-5442-4e16-a0d7-fc4a21aa88b2"), null, null, new Guid("4e4bfb8e-18ae-4b63-96b4-dfe7ba49b422"), new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01"), "Смаколики Карпатської кухні це дуже корисна публікація!", null }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0511df8d-f798-4fdc-aab4-a838680292bc"), new Guid("2dcd3d38-2051-4f1d-999f-caa713a06dc5"), null, null, null, new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70"), null },
                    { new Guid("161eb5bb-f637-4430-ae56-88a6a2df2ee7"), null, null, null, new Guid("15d225f5-a1a4-44c5-a95b-7c253e49aebd"), new Guid("7c183954-3105-4c15-85c8-25d802f80444"), null },
                    { new Guid("2e500fc7-dd0f-4bfe-bf15-abda50ea00ad"), null, null, null, new Guid("7324a2dd-c7e6-4733-8546-729480427ee1"), new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8"), null },
                    { new Guid("6adc7af6-11e2-4207-92c3-b226eb0d6a87"), null, null, null, new Guid("4e4bfb8e-18ae-4b63-96b4-dfe7ba49b422"), new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01"), null },
                    { new Guid("c3afe540-9a3d-4c8d-a22e-1b325c69a4b9"), null, null, null, new Guid("6ffeae74-bee4-4363-8dda-0c35a56cc196"), new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620"), null },
                    { new Guid("c63bfa73-b7da-4855-9144-589d878ec4a7"), new Guid("f1f5404f-d8fb-4857-8f3c-5d7a44d41239"), null, null, null, new Guid("7c183954-3105-4c15-85c8-25d802f80444"), null },
                    { new Guid("e0d230ff-ce58-49f0-aa08-90fd92abdf79"), null, null, null, new Guid("d8f90b51-d740-414b-a5e9-8e53be29b038"), new Guid("d6f15473-3d1a-49a8-9bcb-ce3cf40e0c70"), null }
                });

            migrationBuilder.InsertData(
                table: "PostImages",
                columns: new[] { "ImageId", "PostId" },
                values: new object[,]
                {
                    { new Guid("b66f9c9c-566c-42ce-8eb5-8b115160ff65"), new Guid("15d225f5-a1a4-44c5-a95b-7c253e49aebd") },
                    { new Guid("bb4de83a-6bb0-48ed-a93f-cf1153b905b4"), new Guid("4e4bfb8e-18ae-4b63-96b4-dfe7ba49b422") },
                    { new Guid("a9f631fc-cccd-4a1a-85ef-d8e3a1080c94"), new Guid("6ffeae74-bee4-4363-8dda-0c35a56cc196") },
                    { new Guid("0d041849-6db3-4121-823e-292792be1160"), new Guid("7324a2dd-c7e6-4733-8546-729480427ee1") },
                    { new Guid("feadd9cc-1f41-4913-8b07-0df9d81a51b9"), new Guid("d8f90b51-d740-414b-a5e9-8e53be29b038") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("15d225f5-a1a4-44c5-a95b-7c253e49aebd"), new Guid("25d50f0e-0b34-482e-b186-234aaae45a04") },
                    { new Guid("4e4bfb8e-18ae-4b63-96b4-dfe7ba49b422"), new Guid("61207f9b-99f9-46fb-a165-c163f667c05b") },
                    { new Guid("6ffeae74-bee4-4363-8dda-0c35a56cc196"), new Guid("d8cce667-ab65-4536-a65f-30163239fdc4") },
                    { new Guid("7324a2dd-c7e6-4733-8546-729480427ee1"), new Guid("38a2b74c-e813-468e-be79-b84aa5122536") },
                    { new Guid("d8f90b51-d740-414b-a5e9-8e53be29b038"), new Guid("af3ae483-929a-4c10-93b9-efb1886156ab") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("289ba152-e654-49d6-9564-b10b5b439e2a"), new Guid("6136b1d6-f67e-4d70-8990-136d4b77de16"), null, null, null, new Guid("51ab773e-e705-4a23-8dbe-aa4d07a71620"), null },
                    { new Guid("e6b7eb6c-ee77-41d1-9a21-17c2deeec3fa"), new Guid("980f7b4d-5442-4e16-a0d7-fc4a21aa88b2"), null, null, null, new Guid("4a0f7ec6-33d1-4a8c-b4e5-76c325bc5aa8"), null },
                    { new Guid("ef19127d-557a-44b6-9048-44850540e380"), new Guid("667e0e5c-302f-4ca0-a045-291caafcc157"), null, null, null, new Guid("9ab9e09c-476f-4bb4-885d-fc8ac029cc01"), null }
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
