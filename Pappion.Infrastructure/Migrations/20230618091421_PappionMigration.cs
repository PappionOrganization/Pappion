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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTags_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PartyUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    { new Guid("34ef5701-2bcd-4337-b1b8-fbb06e781b16"), "Велосипед" },
                    { new Guid("9b8ed1e5-4b48-4e70-a29d-f9cc65f388e1"), "Сноуборд" },
                    { new Guid("b024c3d5-a1ab-4630-900f-79afbf709cb3"), "Лижі" },
                    { new Guid("d01427cf-e4ca-4d0d-95ba-906c0f80e767"), "Настільні ігри" },
                    { new Guid("d34108aa-ca9b-4574-82f4-8294723be0d7"), "Кемпінг" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Location", "Password", "PhoneNumber", "PhoneNumber2", "Rating", "Role" },
                values: new object[,]
                {
                    { new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), "killing.monsters@gmail.com", "Ґеральт", "з Рівії", null, "AnJvYXLCFviKopQBQDKbfQ==;cr6btLx8eFNP88Mfe1DcaS5V5a8/MX5ab/hJweSWKk4=", "+38000000000", null, 4.5m, "User" },
                    { new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), "tatakae@gmail.com", "Еран", "Єґа", null, "tEoHiwdHo6BQ+Ied6f5NxQ==;TgmmgiTVYfBXdsDkHsXsBt/A5XthSOkO5RJKUtKJONk=", "+38000000000", null, 1.5m, "User" },
                    { new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "harrypotter@gmail.com", "Гаррі", "Поттер", null, "tXm0TjNIlr5po0NIviID2Q==;jNCDzquD8OyceNy/uwcRtc1d5+V4Z84/ecnbkip7Uhk=", "+38000000000", null, 3.5m, "User" },
                    { new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), "bossofthegym@gmail.com", "Біллі", "Герінґтон", null, "leK67VXLpIsafT+E0jkjIQ==;OQK/5Lv6P4ZIENr3QmDdknUiDpn9Lo+4OWA2WCypcvQ=", "+38000000000", null, 2.5m, "User" },
                    { new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), "not.exist@gmail.com", "Тайлер", "Дьорден", null, "RQXOvYMwUKS37hagysdqPQ==;tKW68EMW1O2re2CfRAZQyDBj8t0JfgYJ1B69oCvhCys=", "+38000000000", null, 5.0m, "User" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("0732b92a-3744-4a67-b351-7930fdb5b113"), null, null, null, new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Гаррі це дуже файний пацан! Стоп...", new Guid("a6e85327-e4ec-4736-85d1-d44814863562") },
                    { new Guid("16739b73-11aa-4340-ba76-6dc08b996beb"), null, null, null, new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), "Біллі це дуже файний пацан! Стоп...", new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4") },
                    { new Guid("78af6db4-8728-4d34-b821-29799c4f7eb4"), null, null, null, new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), "Тайлер це дуже файний пацан! Стоп...", new Guid("da32bf83-8fdb-4405-bc80-be732443e858") },
                    { new Guid("b6d9021c-4823-48ae-9eb1-4623bfbf9617"), null, null, null, new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), "Еран це дуже файний пацан! Стоп...", new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788") },
                    { new Guid("ded91049-12e1-404a-80d3-c39381d2e686"), null, null, null, new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), "Ґеральт це дуже файний пацан! Стоп...", new Guid("03138389-2fd2-47af-a9a1-db59c518972b") }
                });

            migrationBuilder.InsertData(
                table: "Favors",
                columns: new[] { "Id", "AuthorId", "Description", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("1eb82f43-27fd-4ec2-851d-fb67e7de5c25"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Розкішний манікюр і педикюр, який зробить ваші нігті і ніжки неймовірно чудовими і доглянутими.", 45.8m, 0m, "Ретельна манікюр і педикюр" },
                    { new Guid("5af39064-8cd5-405b-8963-9922b9e67dd5"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Розслабтеся і зосередьтеся на своєму тілі та розумі під час особистого сеансу йоги з досвідченим інструктором.", 55.3m, 0m, "Сеанс йоги" },
                    { new Guid("c24e030f-ecad-42a2-88eb-fdf055915c85"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Отримайте розкішну косметичну процедуру, яка підкреслить вашу природну красу і зробить вашу шкіру сяючою.", 80.0m, 0m, "Косметична процедура" },
                    { new Guid("e0446b0e-5fc2-4073-aad5-d69d9fa3fee4"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Досвідчений тренер допоможе вам досягнути ваших фітнес-цілей, розробивши індивідуальну тренувальну програму для вас.", 70.2m, 0m, "Персональний тренер" },
                    { new Guid("ea733c0b-31a2-4ba0-919d-2f0195f653b2"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Найкращі майстри масажу готові показати всі свої вміння на вашій задубілій спині.", 50.5m, 0m, "Масаж" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("029c70f0-26c2-40a4-9ce6-ea191d415b1d"), null, null, "f5aa04fb-3728-458a-ba5a-7f325cccce19.png", null, new Guid("a6e85327-e4ec-4736-85d1-d44814863562") },
                    { new Guid("5842a663-fb06-416d-a389-93e4b0184881"), null, null, "d190d264-ec8c-45de-a25d-41fdb516c106.png", null, new Guid("03138389-2fd2-47af-a9a1-db59c518972b") },
                    { new Guid("6ff4b04e-086b-4357-9d6e-f31b8e597ec1"), null, null, "82328f74-0204-4c72-be30-404840c540b7.png", null, new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4") },
                    { new Guid("73bc9113-9216-49c2-b440-673fad71e3e4"), null, null, "bf484494-5347-4635-a364-212e196cd062.png", null, new Guid("da32bf83-8fdb-4405-bc80-be732443e858") },
                    { new Guid("fee7346f-4688-47b3-a99e-7901b8fa6095"), null, null, "0d9de09f-1761-45cf-a853-512702ef62da.png", null, new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2ad52621-7874-4099-8ded-6f0e4da30616"), null, null, null, null, new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), new Guid("da32bf83-8fdb-4405-bc80-be732443e858") },
                    { new Guid("6c3c3405-5d08-4846-8ff2-4df75ac545b6"), null, null, null, null, new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), new Guid("03138389-2fd2-47af-a9a1-db59c518972b") },
                    { new Guid("e0b667fd-ed0d-4b03-a7d6-d972044d73e8"), null, null, null, null, new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4") },
                    { new Guid("ed7b6f1e-bdf4-4abf-898f-8e578fd3340e"), null, null, null, null, new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562") },
                    { new Guid("f70e1399-bde9-417a-b3b3-7309670ad9b6"), null, null, null, null, new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788") }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "AuthorId", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("73fa45fc-5820-4aaf-90dc-12e8114c0daa"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7647), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("c49f9cca-08b0-44d4-be6b-20903a9ce3e8"), new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7660), "Шукаю людей, які так само захоплені гуртом 'Rammstein' і хотіли б піти на їхній концерт. Разом буде набагато веселіше! Хто бажає долучитися?", "Концерт Rammstein" },
                    { new Guid("f6787cb8-98db-478a-a41e-ff3eab4c8567"), new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7651), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("f78c1d06-cef3-41c3-93b5-8c1a1f3507d4"), new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7655), "Хтось цікавиться проведенням вечірки вдома з настільними іграми? Я маю гарну колекцію ігор і шукаю компанію для веселого проведення вечора. Приєднуйтесь!", "Вечірка вдома з настільними іграми" },
                    { new Guid("fc4b8cda-e695-4f24-9331-e409e4b7f82e"), new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7640), "Приходьте до мене сьогодні в джакузі, тут весело. Про оплату потім.", "Джакузі з скінхедом" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("14669a78-c727-4213-a339-c10d92eb35ad"), new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7608), "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!", null, "Зимові пригоди у Карпатах" },
                    { new Guid("4e3de5fd-37ec-4f34-b3b2-78b751979d2b"), new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7595), "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!", null, "Смаколики Карпатської кухні" },
                    { new Guid("6a994f3e-ac89-432a-b0df-67904955f210"), new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7603), "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!", null, "Неймовірні пейзажі Карпат" },
                    { new Guid("abf7a0b8-aa0a-4f4b-956b-8ba602989450"), new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7590), "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!", null, "Незабутні враження від Карпат" },
                    { new Guid("b6af4aa5-dbbc-4d47-93d1-2baabb526b31"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), new DateTime(2023, 6, 18, 12, 14, 21, 211, DateTimeKind.Local).AddTicks(7542), "Карпати інфо шахраї! Я забронювала собі номер в одній з камер Азкабану, але дементори мене туди не впустили. Це жах!", null, "Увага!" }
                });

            migrationBuilder.InsertData(
                table: "UserTags",
                columns: new[] { "TagId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d01427cf-e4ca-4d0d-95ba-906c0f80e767"), new Guid("03138389-2fd2-47af-a9a1-db59c518972b") },
                    { new Guid("9b8ed1e5-4b48-4e70-a29d-f9cc65f388e1"), new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788") },
                    { new Guid("b024c3d5-a1ab-4630-900f-79afbf709cb3"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562") },
                    { new Guid("d34108aa-ca9b-4574-82f4-8294723be0d7"), new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4") },
                    { new Guid("34ef5701-2bcd-4337-b1b8-fbb06e781b16"), new Guid("da32bf83-8fdb-4405-bc80-be732443e858") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("1786ff5c-d1a3-42e3-b065-66ccb8973b08"), new Guid("c24e030f-ecad-42a2-88eb-fdf055915c85"), null, null, new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), "Косметична процедура це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("1f2a6b57-7eb3-4fb3-852b-fc0cf0d0a1e6"), null, new Guid("c49f9cca-08b0-44d4-be6b-20903a9ce3e8"), null, new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), "Концерт Rammstein це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("54bbef9b-5943-491d-b13c-cbd33454e809"), new Guid("5af39064-8cd5-405b-8963-9922b9e67dd5"), null, null, new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), "Сеанс йоги це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("5a47a32e-a024-4c84-b307-18e419f901c8"), null, null, new Guid("6a994f3e-ac89-432a-b0df-67904955f210"), new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), "Неймовірні пейзажі Карпат це дуже корисна публікація!", null },
                    { new Guid("71c1669f-e4d0-4f5b-92fa-a06e0f0fcb75"), null, new Guid("f6787cb8-98db-478a-a41e-ff3eab4c8567"), null, new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("749afb89-be73-4df3-bd81-f6dde0649635"), null, null, new Guid("14669a78-c727-4213-a339-c10d92eb35ad"), new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), "Зимові пригоди у Карпатах це дуже корисна публікація!", null },
                    { new Guid("9fc01311-b059-450e-ba20-4172083b5172"), null, new Guid("fc4b8cda-e695-4f24-9331-e409e4b7f82e"), null, new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Джакузі з скінхедом це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("a3dc469c-957e-4b0a-a090-b755ef5a142a"), null, new Guid("73fa45fc-5820-4aaf-90dc-12e8114c0daa"), null, new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("a7f51f5e-0486-4f37-b8cb-3a929ef75e3a"), new Guid("e0446b0e-5fc2-4073-aad5-d69d9fa3fee4"), null, null, new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), "Персональний тренер це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("a8942268-9c5e-43c1-a3a2-2f8852d8de9d"), new Guid("ea733c0b-31a2-4ba0-919d-2f0195f653b2"), null, null, new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Масаж це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("a93192b3-5ed2-41fc-b9f0-3f37c9f3b284"), null, null, new Guid("abf7a0b8-aa0a-4f4b-956b-8ba602989450"), new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), "Незабутні враження від Карпат це дуже корисна публікація!", null },
                    { new Guid("ab325bcb-9f32-4af8-a27b-af4a09e97e9d"), new Guid("1eb82f43-27fd-4ec2-851d-fb67e7de5c25"), null, null, new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), "Ретельна манікюр і педикюр це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("b1ad9e41-d3f6-4e4d-85cc-5718e06af9d0"), null, null, new Guid("4e3de5fd-37ec-4f34-b3b2-78b751979d2b"), new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), "Смаколики Карпатської кухні це дуже корисна публікація!", null },
                    { new Guid("d6b6b1e1-365f-43e3-8663-acc00a5582ee"), null, null, new Guid("b6af4aa5-dbbc-4d47-93d1-2baabb526b31"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), "Увага! це дуже корисна публікація!", null },
                    { new Guid("e09ae5ed-5bc6-4125-a70e-76bd2ff7bed0"), null, new Guid("f78c1d06-cef3-41c3-93b5-8c1a1f3507d4"), null, new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), "Вечірка вдома з настільними іграми це звучить дуже цікаво! Я обов'язково прийду!", null }
                });

            migrationBuilder.InsertData(
                table: "FavorTags",
                columns: new[] { "FavorId", "TagId" },
                values: new object[,]
                {
                    { new Guid("1eb82f43-27fd-4ec2-851d-fb67e7de5c25"), new Guid("34ef5701-2bcd-4337-b1b8-fbb06e781b16") },
                    { new Guid("5af39064-8cd5-405b-8963-9922b9e67dd5"), new Guid("d34108aa-ca9b-4574-82f4-8294723be0d7") },
                    { new Guid("c24e030f-ecad-42a2-88eb-fdf055915c85"), new Guid("9b8ed1e5-4b48-4e70-a29d-f9cc65f388e1") },
                    { new Guid("e0446b0e-5fc2-4073-aad5-d69d9fa3fee4"), new Guid("d01427cf-e4ca-4d0d-95ba-906c0f80e767") },
                    { new Guid("ea733c0b-31a2-4ba0-919d-2f0195f653b2"), new Guid("b024c3d5-a1ab-4630-900f-79afbf709cb3") }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0894268f-8f91-48ee-9a62-b65b418e686f"), null, null, "48fa117c-5e78-4023-83a3-505ef2a95c63.png", new Guid("abf7a0b8-aa0a-4f4b-956b-8ba602989450"), null },
                    { new Guid("0da85c61-1b60-4b85-82e5-5ccd1057211a"), null, new Guid("fc4b8cda-e695-4f24-9331-e409e4b7f82e"), "22c92514-31a7-4339-9017-d4bff80d820e.png", null, null },
                    { new Guid("1758b1cf-788b-471a-9b62-f59766b79650"), null, new Guid("73fa45fc-5820-4aaf-90dc-12e8114c0daa"), "c462665c-cd13-4627-9bed-a8ad0c879868.png", null, null },
                    { new Guid("1bb12964-bddd-4ec7-87f4-3d31c91f6805"), null, new Guid("f6787cb8-98db-478a-a41e-ff3eab4c8567"), "58a81253-338b-4037-89dc-2fcf3a501e0c.png", null, null },
                    { new Guid("36dc2d84-66a7-4a14-8938-b7e51de01b10"), new Guid("1eb82f43-27fd-4ec2-851d-fb67e7de5c25"), null, "ff877f69-031f-4890-9eef-d4cc7d22043e.png", null, null },
                    { new Guid("57a0674f-5e3e-4c37-a773-7218f0f316c5"), new Guid("5af39064-8cd5-405b-8963-9922b9e67dd5"), null, "1396e3e1-c31f-4812-9313-05a1d4dd8d50.png", null, null },
                    { new Guid("66257386-ce38-4000-bf72-97a2aaec3071"), new Guid("ea733c0b-31a2-4ba0-919d-2f0195f653b2"), null, "0b2faaeb-0bf4-4570-a812-8e6294e40534.png", null, null },
                    { new Guid("8d182e87-028f-4a2d-91f5-5f7bfb78ff69"), new Guid("c24e030f-ecad-42a2-88eb-fdf055915c85"), null, "567b171b-8d02-47b7-bfd4-29cdb07ab6cd.png", null, null },
                    { new Guid("a498c434-0abd-4c93-abe3-70e75e054592"), null, null, "0c1b87bd-9b75-499d-9896-6ec47560c873.png", new Guid("b6af4aa5-dbbc-4d47-93d1-2baabb526b31"), null },
                    { new Guid("aebe9fdc-138f-43d8-a2ff-e8caf566d9dd"), null, new Guid("f78c1d06-cef3-41c3-93b5-8c1a1f3507d4"), "5464f998-0081-46ff-a7ad-3561bcd48f58.png", null, null },
                    { new Guid("cc9d5634-0f34-4ffe-aa12-630c273aef89"), null, null, "23eb78de-bb77-40a9-9955-df1d99737798.png", new Guid("6a994f3e-ac89-432a-b0df-67904955f210"), null },
                    { new Guid("d169992a-96aa-4143-af80-9f91f140900b"), null, null, "27593490-8d6a-48b5-8457-42ba6f33d8a4.png", new Guid("14669a78-c727-4213-a339-c10d92eb35ad"), null },
                    { new Guid("e5e7f7d2-cedb-44aa-aa42-f4d9bc4b8cae"), new Guid("e0446b0e-5fc2-4073-aad5-d69d9fa3fee4"), null, "8b1b7e4d-8e2c-4494-abd7-ed888a971591.png", null, null },
                    { new Guid("f0b9f98d-1e02-4342-89e6-1c2aafe36ffb"), null, new Guid("c49f9cca-08b0-44d4-be6b-20903a9ce3e8"), "98cb879d-8a04-4b4f-867f-50e6952d40a5.png", null, null },
                    { new Guid("fbe0a462-f674-43d1-86f3-3fdd5a38443f"), null, null, "e59f8ff4-1d68-4ade-977a-fe4ea49254a5.png", new Guid("4e3de5fd-37ec-4f34-b3b2-78b751979d2b"), null }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("11518523-0cef-4c62-ad09-a61f528b3d0f"), null, new Guid("c24e030f-ecad-42a2-88eb-fdf055915c85"), null, null, new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), null },
                    { new Guid("328d22bd-0bf4-4960-a5bd-eddbbb356f13"), new Guid("0732b92a-3744-4a67-b351-7930fdb5b113"), null, null, null, new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), null },
                    { new Guid("46864050-bfdf-4a6d-998a-6447a8abd2e2"), null, null, new Guid("f6787cb8-98db-478a-a41e-ff3eab4c8567"), null, new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), null },
                    { new Guid("4cdf6e4a-543c-43eb-b143-cfca8b62bc51"), null, null, new Guid("fc4b8cda-e695-4f24-9331-e409e4b7f82e"), null, new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), null },
                    { new Guid("553d3617-ede1-4bec-bf67-8e3647b05e5a"), null, null, null, new Guid("b6af4aa5-dbbc-4d47-93d1-2baabb526b31"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), null },
                    { new Guid("616c3587-e136-45cf-b33e-0b5dea170fde"), null, new Guid("1eb82f43-27fd-4ec2-851d-fb67e7de5c25"), null, null, new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), null },
                    { new Guid("797d8145-5f93-482e-b470-410122ce25a7"), null, null, null, new Guid("abf7a0b8-aa0a-4f4b-956b-8ba602989450"), new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), null },
                    { new Guid("833f32f5-b457-4b69-8aad-e8b13a54e261"), null, new Guid("e0446b0e-5fc2-4073-aad5-d69d9fa3fee4"), null, null, new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), null },
                    { new Guid("880467df-b8da-4cf0-a5fd-0267ee2ee0c4"), null, null, null, new Guid("14669a78-c727-4213-a339-c10d92eb35ad"), new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), null },
                    { new Guid("88319270-69a5-40a7-aeb0-6af41384e203"), null, null, null, new Guid("4e3de5fd-37ec-4f34-b3b2-78b751979d2b"), new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), null },
                    { new Guid("b7ba6de5-9690-4a4f-b604-a5cb25ff4c5e"), null, new Guid("ea733c0b-31a2-4ba0-919d-2f0195f653b2"), null, null, new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), null },
                    { new Guid("c4cdcc14-71ac-4922-9d28-a758954f89fc"), null, new Guid("5af39064-8cd5-405b-8963-9922b9e67dd5"), null, null, new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), null },
                    { new Guid("d896f60c-957b-45d6-9f09-2873e9716630"), null, null, new Guid("73fa45fc-5820-4aaf-90dc-12e8114c0daa"), null, new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), null },
                    { new Guid("d99d8266-d0e2-48b3-9774-fd7874d3e922"), null, null, new Guid("c49f9cca-08b0-44d4-be6b-20903a9ce3e8"), null, new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), null },
                    { new Guid("f07bb104-0706-4d61-80a1-cbcb90d4558c"), null, null, null, new Guid("6a994f3e-ac89-432a-b0df-67904955f210"), new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), null },
                    { new Guid("f50b2d6e-f8c2-4ede-aafe-99f7b15dec2f"), null, null, new Guid("f78c1d06-cef3-41c3-93b5-8c1a1f3507d4"), null, new Guid("da32bf83-8fdb-4405-bc80-be732443e858"), null }
                });

            migrationBuilder.InsertData(
                table: "PartyTags",
                columns: new[] { "PartyId", "TagId" },
                values: new object[,]
                {
                    { new Guid("73fa45fc-5820-4aaf-90dc-12e8114c0daa"), new Guid("9b8ed1e5-4b48-4e70-a29d-f9cc65f388e1") },
                    { new Guid("c49f9cca-08b0-44d4-be6b-20903a9ce3e8"), new Guid("d34108aa-ca9b-4574-82f4-8294723be0d7") },
                    { new Guid("f6787cb8-98db-478a-a41e-ff3eab4c8567"), new Guid("d01427cf-e4ca-4d0d-95ba-906c0f80e767") },
                    { new Guid("f78c1d06-cef3-41c3-93b5-8c1a1f3507d4"), new Guid("34ef5701-2bcd-4337-b1b8-fbb06e781b16") },
                    { new Guid("fc4b8cda-e695-4f24-9331-e409e4b7f82e"), new Guid("b024c3d5-a1ab-4630-900f-79afbf709cb3") }
                });

            migrationBuilder.InsertData(
                table: "PartyUsers",
                columns: new[] { "PartyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("73fa45fc-5820-4aaf-90dc-12e8114c0daa"), new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788") },
                    { new Guid("c49f9cca-08b0-44d4-be6b-20903a9ce3e8"), new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4") },
                    { new Guid("f6787cb8-98db-478a-a41e-ff3eab4c8567"), new Guid("03138389-2fd2-47af-a9a1-db59c518972b") },
                    { new Guid("f78c1d06-cef3-41c3-93b5-8c1a1f3507d4"), new Guid("da32bf83-8fdb-4405-bc80-be732443e858") },
                    { new Guid("fc4b8cda-e695-4f24-9331-e409e4b7f82e"), new Guid("a6e85327-e4ec-4736-85d1-d44814863562") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("14669a78-c727-4213-a339-c10d92eb35ad"), new Guid("d34108aa-ca9b-4574-82f4-8294723be0d7") },
                    { new Guid("4e3de5fd-37ec-4f34-b3b2-78b751979d2b"), new Guid("d01427cf-e4ca-4d0d-95ba-906c0f80e767") },
                    { new Guid("6a994f3e-ac89-432a-b0df-67904955f210"), new Guid("34ef5701-2bcd-4337-b1b8-fbb06e781b16") },
                    { new Guid("abf7a0b8-aa0a-4f4b-956b-8ba602989450"), new Guid("9b8ed1e5-4b48-4e70-a29d-f9cc65f388e1") },
                    { new Guid("b6af4aa5-dbbc-4d47-93d1-2baabb526b31"), new Guid("b024c3d5-a1ab-4630-900f-79afbf709cb3") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("39735138-947b-4bc6-a438-f8366106b33f"), new Guid("a93192b3-5ed2-41fc-b9f0-3f37c9f3b284"), null, null, null, new Guid("c80587d6-356d-4b63-a1d1-02ea9c6d97f4"), null },
                    { new Guid("4fb33ccd-5f12-4e2d-a86e-ac6caabc65fe"), new Guid("a8942268-9c5e-43c1-a3a2-2f8852d8de9d"), null, null, null, new Guid("03138389-2fd2-47af-a9a1-db59c518972b"), null },
                    { new Guid("b8402999-e4d1-4171-ba05-c0e7687aaddd"), new Guid("9fc01311-b059-450e-ba20-4172083b5172"), null, null, null, new Guid("8dd930b8-9985-4297-9286-2c6cfb93e788"), null },
                    { new Guid("d60d3828-e35d-4d56-ac48-e2e43108db1a"), new Guid("d6b6b1e1-365f-43e3-8663-acc00a5582ee"), null, null, null, new Guid("a6e85327-e4ec-4736-85d1-d44814863562"), null }
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
                column: "UserId",
                unique: true);

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
