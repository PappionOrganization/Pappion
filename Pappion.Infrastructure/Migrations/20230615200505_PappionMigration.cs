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
                    PhoneNumber = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber2 = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Rating = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    Location = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Role = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavorTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Images_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Favors_FavorId",
                        column: x => x.FavorId,
                        principalTable: "Favors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Parties_PartyId",
                        column: x => x.PartyId,
                        principalTable: "Parties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0985c99a-dbf7-42a6-8bf8-a6ae829a7d2a"), "Кемпінг" },
                    { new Guid("5a7a19b9-87a4-4c1e-a604-03ab852bf147"), "Сноуборд" },
                    { new Guid("9c95410e-3a37-427b-a687-3d7336ee8c18"), "Лижі" },
                    { new Guid("c9824fd9-7476-400e-8d62-cead541be3a9"), "Велосипед" },
                    { new Guid("eafbb60f-16cc-4e51-b625-c56cd0f5ea59"), "Настільні ігри" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Location", "Password", "PhoneNumber", "PhoneNumber2", "Rating", "Role" },
                values: new object[,]
                {
                    { new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), "not.exist@gmail.com", "Тайлер", "Дьорден", null, "cl/umUCNr24kZBVQk2jIdw==;13tEiTYLasM3iiQRch7DYUdrkQRbqLHVlKhg6a2KLZU=", "+38000000000", null, 5.0m, "User" },
                    { new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), "bossofthegym@gmail.com", "Біллі", "Герінґтон", null, "6XyouMDmiN5Gf3ygwVcsiw==;Tg/DFvUrAkjjc2zEjHFlyWccvkMqiFX0EYIQnqYcIU8=", "+38000000000", null, 2.5m, "User" },
                    { new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "harrypotter@gmail.com", "Гаррі", "Поттер", null, "eOQBuFXEVR27F+fO1rZTAw==;CIvUnVDJw74O/B7v3I73uXTHI7LDnEwsH7HtY6DNR70=", "+38000000000", null, 3.5m, "User" },
                    { new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), "tatakae@gmail.com", "Еран", "Єґа", null, "am/YEcqL6W1DvvwgF6ZLkw==;km2KMQcUJMwGs26yc79P1ATfSzcGlY+lYwEI5TApmM4=", "+38000000000", null, 1.5m, "User" },
                    { new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), "killing.monsters@gmail.com", "Ґеральт", "з Рівії", null, "B5V3oF3Bie6ujqA0qwimxg==;hsNLW7wpAHcXVR3AfVSxmNHoyzsKmbEPCYFQwNx+wFw=", "+38000000000", null, 4.5m, "User" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("03ff2a44-0a24-4744-a0f8-f30f637aed6f"), null, null, null, new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), "Біллі це дуже файний пацан! Стоп...", new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72") },
                    { new Guid("396f1e63-67d8-4fb2-b3de-b7077200ca6c"), null, null, null, new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), "Тайлер це дуже файний пацан! Стоп...", new Guid("1c1c6050-82fa-476a-a521-ceebf3634018") },
                    { new Guid("8b8bd0c0-607f-4ef6-805c-640fff4b56f5"), null, null, null, new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), "Ґеральт це дуже файний пацан! Стоп...", new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a") },
                    { new Guid("ba4de82d-e3ae-4394-a85f-659ac42cb1f2"), null, null, null, new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), "Еран це дуже файний пацан! Стоп...", new Guid("444917de-1df8-494e-b019-628fd1c6b38a") },
                    { new Guid("c7657e6a-9a5b-4681-a3c0-7cf05290c5ec"), null, null, null, new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Гаррі це дуже файний пацан! Стоп...", new Guid("407af047-9858-4321-afe0-69f3ca138a11") }
                });

            migrationBuilder.InsertData(
                table: "Favors",
                columns: new[] { "Id", "AuthorId", "Description", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("0e7bb511-a43e-4bf0-bd38-15a1339969d5"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Розкішний манікюр і педикюр, який зробить ваші нігті і ніжки неймовірно чудовими і доглянутими.", 45.8m, 0m, "Ретельна манікюр і педикюр" },
                    { new Guid("1963f4cd-aa31-458f-94be-acf6aac585b5"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Отримайте розкішну косметичну процедуру, яка підкреслить вашу природну красу і зробить вашу шкіру сяючою.", 80.0m, 0m, "Косметична процедура" },
                    { new Guid("8b5d81cb-57a2-4fe9-98e1-2e571462eca8"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Розслабтеся і зосередьтеся на своєму тілі та розумі під час особистого сеансу йоги з досвідченим інструктором.", 55.3m, 0m, "Сеанс йоги" },
                    { new Guid("cea5d752-261b-4e45-baca-52323384d270"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Досвідчений тренер допоможе вам досягнути ваших фітнес-цілей, розробивши індивідуальну тренувальну програму для вас.", 70.2m, 0m, "Персональний тренер" },
                    { new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Найкращі майстри масажу готові показати всі свої вміння на вашій задубілій спині.", 50.5m, 0m, "Масаж" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("19e0903b-3fb0-4b3d-b92c-1350e2d15f6a"), null, null, "81b47757-e9ed-4364-9296-61b53253bd72.png", null, new Guid("407af047-9858-4321-afe0-69f3ca138a11") },
                    { new Guid("859e8faa-9014-411b-8f6d-fb0a9c6fff1f"), null, null, "35969ee3-ac41-4134-9b5f-d42aa1e93711.png", null, new Guid("407af047-9858-4321-afe0-69f3ca138a11") },
                    { new Guid("913da50c-58bd-4dd3-bb1d-c17ddfd64969"), null, null, "38d7a129-11cc-49e4-ac1a-5baabab86a3c.png", null, new Guid("407af047-9858-4321-afe0-69f3ca138a11") },
                    { new Guid("d1fc3f32-ca7f-4c63-9c8b-5ded75932e4c"), null, null, "de82377d-b67b-4f00-82b6-a123138406bf.png", null, new Guid("407af047-9858-4321-afe0-69f3ca138a11") },
                    { new Guid("e64ad630-980b-4b12-a956-a6ddeb98667b"), null, null, "44cd1230-d495-498e-b2c5-60be7f924345.png", null, new Guid("407af047-9858-4321-afe0-69f3ca138a11") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0d923871-0f13-488b-b8d0-283bdc5b2f10"), null, null, null, null, new Guid("407af047-9858-4321-afe0-69f3ca138a11"), new Guid("407af047-9858-4321-afe0-69f3ca138a11") },
                    { new Guid("350b9eaf-7b43-49e8-b9fc-44f960409200"), null, null, null, null, new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72") },
                    { new Guid("43cea248-a8e7-49a2-8e76-c2b3dd9ea11e"), null, null, null, null, new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a") },
                    { new Guid("742a81af-8afe-41df-939b-e098a83f7eb7"), null, null, null, null, new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), new Guid("444917de-1df8-494e-b019-628fd1c6b38a") },
                    { new Guid("af9cad7c-6c90-451a-9e49-7f0b5bf3658b"), null, null, null, null, new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), new Guid("1c1c6050-82fa-476a-a521-ceebf3634018") }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "AuthorId", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("17fd6637-0753-4585-8390-975f162c5dbe"), new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6595), "Шукаю людей, які так само захоплені гуртом 'Rammstein' і хотіли б піти на їхній концерт. Разом буде набагато веселіше! Хто бажає долучитися?", "Концерт Rammstein" },
                    { new Guid("3c149159-5346-445e-8d69-762c93385bc7"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6582), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("6d1a6530-9ffc-4b9b-9fec-6078048aa189"), new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6586), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6575), "Приходьте до мене сьогодні в джакузі, тут весело. Про оплату потім.", "Джакузі з скінхедом" },
                    { new Guid("cf15822a-28de-44cb-afb6-6c2119e330f5"), new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6591), "Хтось цікавиться проведенням вечірки вдома з настільними іграми? Я маю гарну колекцію ігор і шукаю компанію для веселого проведення вечора. Приєднуйтесь!", "Вечірка вдома з настільними іграми" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("1ba7c717-adf8-4d71-82ba-9e0484c48be8"), new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6547), "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!", null, "Зимові пригоди у Карпатах" },
                    { new Guid("3b51d66c-87e9-4134-b036-11fa29157996"), new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6542), "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!", null, "Неймовірні пейзажі Карпат" },
                    { new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6459), "Карпати інфо шахраї! Я забронювала собі номер в одній з камер Азкабану, але дементори мене туди не впустили. Це жах!", null, "Увага!" },
                    { new Guid("6e225a76-229f-4612-8520-7ce18e230152"), new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6510), "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!", null, "Незабутні враження від Карпат" },
                    { new Guid("ac480306-36a8-4fdc-be3d-0779a3402df0"), new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), new DateTime(2023, 6, 15, 23, 5, 5, 158, DateTimeKind.Local).AddTicks(6515), "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!", null, "Смаколики Карпатської кухні" }
                });

            migrationBuilder.InsertData(
                table: "UserTags",
                columns: new[] { "TagId", "UserId" },
                values: new object[,]
                {
                    { new Guid("c9824fd9-7476-400e-8d62-cead541be3a9"), new Guid("1c1c6050-82fa-476a-a521-ceebf3634018") },
                    { new Guid("0985c99a-dbf7-42a6-8bf8-a6ae829a7d2a"), new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72") },
                    { new Guid("9c95410e-3a37-427b-a687-3d7336ee8c18"), new Guid("407af047-9858-4321-afe0-69f3ca138a11") },
                    { new Guid("5a7a19b9-87a4-4c1e-a604-03ab852bf147"), new Guid("444917de-1df8-494e-b019-628fd1c6b38a") },
                    { new Guid("eafbb60f-16cc-4e51-b625-c56cd0f5ea59"), new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("18475644-c2e7-4960-b4e1-48ec9d85747d"), null, new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), null, new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Джакузі з скінхедом це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("18e4f4fe-a713-48e6-8d58-b44f94e75f89"), new Guid("cea5d752-261b-4e45-baca-52323384d270"), null, null, new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), "Персональний тренер це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("1c745497-5249-4d3f-a424-bea2d48408e3"), null, new Guid("cf15822a-28de-44cb-afb6-6c2119e330f5"), null, new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), "Вечірка вдома з настільними іграми це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("2a92c894-480e-49b8-a0b7-3b48e35fb7d2"), null, null, new Guid("6e225a76-229f-4612-8520-7ce18e230152"), new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), "Незабутні враження від Карпат це дуже корисна публікація!", null },
                    { new Guid("49da613b-723b-4537-bbb6-977830a33296"), new Guid("0e7bb511-a43e-4bf0-bd38-15a1339969d5"), null, null, new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), "Ретельна манікюр і педикюр це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("4aaba06e-dde7-41bc-8107-232daf8bfcd8"), null, null, new Guid("3b51d66c-87e9-4134-b036-11fa29157996"), new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), "Неймовірні пейзажі Карпат це дуже корисна публікація!", null },
                    { new Guid("60562eab-858a-4fca-b76b-783706350a75"), null, null, new Guid("1ba7c717-adf8-4d71-82ba-9e0484c48be8"), new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), "Зимові пригоди у Карпатах це дуже корисна публікація!", null },
                    { new Guid("722ce8a5-5b8c-4c69-948d-236fea99f653"), new Guid("1963f4cd-aa31-458f-94be-acf6aac585b5"), null, null, new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), "Косметична процедура це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("7da1acf6-391c-4bf0-a15f-5ba2a214a0e2"), new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), null, null, new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Масаж це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("805fb50d-d882-4bca-b194-3395a284b87a"), null, null, new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), "Увага! це дуже корисна публікація!", null },
                    { new Guid("879132e9-c0ed-4c05-a800-fe1fc2fd0408"), null, new Guid("6d1a6530-9ffc-4b9b-9fec-6078048aa189"), null, new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("ac2091c6-08ce-499e-b432-c847426a066d"), null, null, new Guid("ac480306-36a8-4fdc-be3d-0779a3402df0"), new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), "Смаколики Карпатської кухні це дуже корисна публікація!", null },
                    { new Guid("b2781706-f750-480e-b4b8-cb5affc8c513"), null, new Guid("3c149159-5346-445e-8d69-762c93385bc7"), null, new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("b38b6d87-e5f1-4fc2-95e6-ddf4c03e05eb"), null, new Guid("17fd6637-0753-4585-8390-975f162c5dbe"), null, new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), "Концерт Rammstein це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("fff995e6-03f3-4e6d-87d4-58da896bfc48"), new Guid("8b5d81cb-57a2-4fe9-98e1-2e571462eca8"), null, null, new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), "Сеанс йоги це дуже крута послуга! Раджу всім спробувати!", null }
                });

            migrationBuilder.InsertData(
                table: "FavorTags",
                columns: new[] { "FavorId", "TagId" },
                values: new object[,]
                {
                    { new Guid("0e7bb511-a43e-4bf0-bd38-15a1339969d5"), new Guid("c9824fd9-7476-400e-8d62-cead541be3a9") },
                    { new Guid("1963f4cd-aa31-458f-94be-acf6aac585b5"), new Guid("5a7a19b9-87a4-4c1e-a604-03ab852bf147") },
                    { new Guid("8b5d81cb-57a2-4fe9-98e1-2e571462eca8"), new Guid("0985c99a-dbf7-42a6-8bf8-a6ae829a7d2a") },
                    { new Guid("cea5d752-261b-4e45-baca-52323384d270"), new Guid("eafbb60f-16cc-4e51-b625-c56cd0f5ea59") },
                    { new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), new Guid("9c95410e-3a37-427b-a687-3d7336ee8c18") }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0ea74556-2684-4a20-8888-56a420ad5a73"), null, new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), "90ce85ee-a33d-47d0-829f-2572f9689f60.png", null, null },
                    { new Guid("28876f7f-58dd-43c8-957f-de5d8471aaca"), new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), null, "66ddd21b-95e4-4ccf-935c-75d4aca0c328.png", null, null },
                    { new Guid("28affac7-484b-43cc-96cf-afc84560133b"), new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), null, "d6db18bd-7b02-481e-bcf0-5f0f0339a89c.png", null, null },
                    { new Guid("39072ba9-1140-4e2c-af00-a5a20ab5c520"), new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), null, "cd9f6048-c38a-444b-a691-6abbc742b7f3.png", null, null },
                    { new Guid("3a0e9f79-00ae-442a-94de-0004e92c4bf8"), null, null, "f6759806-151b-4748-b0d9-d9996ea40d74.png", new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), null },
                    { new Guid("40f878f6-7bff-4d73-8fed-324fe2a7091f"), null, new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), "da015a1e-a1e7-4559-92a3-911f73ab4aea.png", null, null },
                    { new Guid("5a701a3c-c7e1-423a-b800-cf40c3afdc6c"), null, new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), "6c002e1e-936b-4059-a740-f669f8af30c3.png", null, null },
                    { new Guid("5bcc8229-eef7-4927-8968-8324952c72c0"), null, new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), "a6542cd9-2ee8-41f6-b0f4-94b0dfc3131b.png", null, null },
                    { new Guid("67aade48-f24a-4f86-bf19-b1c1ac28e1dd"), null, null, "f6681ca5-f747-44bd-b5c4-876a85f83c37.png", new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), null },
                    { new Guid("7680f199-d4e5-4711-bb5f-edfd14f0c634"), new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), null, "dee4a127-ee97-496b-a23a-6e12d2aade8c.png", null, null },
                    { new Guid("89debb75-7c8d-48e8-8121-96e748c3a361"), null, null, "e61cbbe3-d6e4-4544-a6c3-3238274bfc5b.png", new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), null },
                    { new Guid("92d85b9b-8176-49f7-9aaa-09112eef99b4"), null, new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), "efccdc7f-a337-45de-a978-05d70614a610.png", null, null },
                    { new Guid("9f2b8259-60c7-40f5-baee-7fbbd5b9121e"), null, null, "26a0e876-faac-43d6-ba41-72a0c5de7d56.png", new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), null },
                    { new Guid("bd323d8f-5eac-4fff-960c-406fbfba45e0"), null, null, "db8c3760-bb2b-4527-a439-003e10305083.png", new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), null },
                    { new Guid("d5c27058-3b09-4a67-a004-e0d8719e1be0"), new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), null, "c181c974-2e89-4cf6-bf52-95e4aa83d4ec.png", null, null }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("00ac9347-2658-4197-8a9f-69b88f4240eb"), null, null, new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), null, new Guid("407af047-9858-4321-afe0-69f3ca138a11"), null },
                    { new Guid("14756768-ebc1-4307-b38a-4dcd79ec9d2c"), null, null, new Guid("17fd6637-0753-4585-8390-975f162c5dbe"), null, new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), null },
                    { new Guid("1e10a7d9-4908-44db-830d-c6e0b4a736bb"), null, new Guid("0e7bb511-a43e-4bf0-bd38-15a1339969d5"), null, null, new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), null },
                    { new Guid("3ae378b9-506d-48a3-9d43-c17ea0bb8381"), null, null, new Guid("cf15822a-28de-44cb-afb6-6c2119e330f5"), null, new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), null },
                    { new Guid("3dbdc355-d651-4432-ac36-edf954bd4c98"), new Guid("c7657e6a-9a5b-4681-a3c0-7cf05290c5ec"), null, null, null, new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), null },
                    { new Guid("3f98b2b7-a897-45df-a38e-d378f608c8cc"), null, new Guid("f1aca8c1-ebb0-4c4d-9078-0f27ebe599ad"), null, null, new Guid("407af047-9858-4321-afe0-69f3ca138a11"), null },
                    { new Guid("5cb12d12-7f92-414c-b686-6b497e101f3e"), null, null, null, new Guid("1ba7c717-adf8-4d71-82ba-9e0484c48be8"), new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), null },
                    { new Guid("6b784199-1318-4920-8451-d625cbdaab19"), null, null, new Guid("6d1a6530-9ffc-4b9b-9fec-6078048aa189"), null, new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), null },
                    { new Guid("740080b3-0f62-41c1-a11a-b88fee402bad"), null, new Guid("1963f4cd-aa31-458f-94be-acf6aac585b5"), null, null, new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), null },
                    { new Guid("7820d809-7123-4d8b-942a-29eb111f30c9"), null, null, new Guid("3c149159-5346-445e-8d69-762c93385bc7"), null, new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), null },
                    { new Guid("853b1336-680f-49b6-a4f6-43ce3467dab4"), null, null, null, new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), new Guid("407af047-9858-4321-afe0-69f3ca138a11"), null },
                    { new Guid("928a8d95-feca-40d0-8692-824eadae49be"), null, new Guid("cea5d752-261b-4e45-baca-52323384d270"), null, null, new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), null },
                    { new Guid("9857260b-791c-464c-82bf-f6cf4b5c8e57"), null, new Guid("8b5d81cb-57a2-4fe9-98e1-2e571462eca8"), null, null, new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), null },
                    { new Guid("b0401432-25a5-43c5-aca7-c7d17628b0eb"), null, null, null, new Guid("ac480306-36a8-4fdc-be3d-0779a3402df0"), new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), null },
                    { new Guid("b567687d-e407-403b-97ab-22140eadc7c3"), null, null, null, new Guid("3b51d66c-87e9-4134-b036-11fa29157996"), new Guid("1c1c6050-82fa-476a-a521-ceebf3634018"), null },
                    { new Guid("b702cabf-688b-4647-b3c9-3b7db6d0c787"), null, null, null, new Guid("6e225a76-229f-4612-8520-7ce18e230152"), new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), null }
                });

            migrationBuilder.InsertData(
                table: "PartyTags",
                columns: new[] { "PartyId", "TagId" },
                values: new object[,]
                {
                    { new Guid("17fd6637-0753-4585-8390-975f162c5dbe"), new Guid("0985c99a-dbf7-42a6-8bf8-a6ae829a7d2a") },
                    { new Guid("3c149159-5346-445e-8d69-762c93385bc7"), new Guid("5a7a19b9-87a4-4c1e-a604-03ab852bf147") },
                    { new Guid("6d1a6530-9ffc-4b9b-9fec-6078048aa189"), new Guid("eafbb60f-16cc-4e51-b625-c56cd0f5ea59") },
                    { new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), new Guid("9c95410e-3a37-427b-a687-3d7336ee8c18") },
                    { new Guid("cf15822a-28de-44cb-afb6-6c2119e330f5"), new Guid("c9824fd9-7476-400e-8d62-cead541be3a9") }
                });

            migrationBuilder.InsertData(
                table: "PartyUsers",
                columns: new[] { "PartyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("17fd6637-0753-4585-8390-975f162c5dbe"), new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72") },
                    { new Guid("3c149159-5346-445e-8d69-762c93385bc7"), new Guid("444917de-1df8-494e-b019-628fd1c6b38a") },
                    { new Guid("6d1a6530-9ffc-4b9b-9fec-6078048aa189"), new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a") },
                    { new Guid("8dda8f2f-9812-4a1f-8abb-d6d95776158f"), new Guid("407af047-9858-4321-afe0-69f3ca138a11") },
                    { new Guid("cf15822a-28de-44cb-afb6-6c2119e330f5"), new Guid("1c1c6050-82fa-476a-a521-ceebf3634018") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("1ba7c717-adf8-4d71-82ba-9e0484c48be8"), new Guid("0985c99a-dbf7-42a6-8bf8-a6ae829a7d2a") },
                    { new Guid("3b51d66c-87e9-4134-b036-11fa29157996"), new Guid("c9824fd9-7476-400e-8d62-cead541be3a9") },
                    { new Guid("50260eee-ed09-467f-bb89-2171c9de3022"), new Guid("9c95410e-3a37-427b-a687-3d7336ee8c18") },
                    { new Guid("6e225a76-229f-4612-8520-7ce18e230152"), new Guid("5a7a19b9-87a4-4c1e-a604-03ab852bf147") },
                    { new Guid("ac480306-36a8-4fdc-be3d-0779a3402df0"), new Guid("eafbb60f-16cc-4e51-b625-c56cd0f5ea59") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1366fb8c-928c-4e57-ae55-778b1ad1071f"), new Guid("2a92c894-480e-49b8-a0b7-3b48e35fb7d2"), null, null, null, new Guid("282d2df4-bcdc-4f5a-99b4-f83b995d5f72"), null },
                    { new Guid("61edeb00-00ce-463b-9cc3-5b096f74906e"), new Guid("805fb50d-d882-4bca-b194-3395a284b87a"), null, null, null, new Guid("407af047-9858-4321-afe0-69f3ca138a11"), null },
                    { new Guid("929bdd93-ede3-4d52-8a9b-5b66e9691cfb"), new Guid("18475644-c2e7-4960-b4e1-48ec9d85747d"), null, null, null, new Guid("444917de-1df8-494e-b019-628fd1c6b38a"), null },
                    { new Guid("cab95d4c-7aed-4bac-bc32-1560fe8a562a"), new Guid("7da1acf6-391c-4bf0-a15f-5ba2a214a0e2"), null, null, null, new Guid("900c4c4a-18a7-4b6a-b490-515214e69b9a"), null }
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
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTags_TagId",
                table: "PostTags",
                column: "TagId");

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
        }
    }
}
