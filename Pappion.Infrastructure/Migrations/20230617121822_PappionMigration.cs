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
                    { new Guid("3c2de118-e173-4e12-95cf-a2cef626a5a3"), "Велосипед" },
                    { new Guid("69697103-7de2-473d-9495-3c676a0141b7"), "Лижі" },
                    { new Guid("7ffd387f-61d9-4f23-a59a-dee2de132f44"), "Кемпінг" },
                    { new Guid("9f26a73f-0f3f-48a7-9161-8e29d5f7bb83"), "Настільні ігри" },
                    { new Guid("f26eb314-0b87-4ce1-9412-ddcedc964690"), "Сноуборд" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Location", "Password", "PhoneNumber", "PhoneNumber2", "Rating", "Role" },
                values: new object[,]
                {
                    { new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "harrypotter@gmail.com", "Гаррі", "Поттер", null, "y/BtxI0F4gdteZLfYdo9Jg==;ZCu1HY1iTTvsj3vrbgfyHsFqUrD/0zQSdxejVeB21tw=", "+38000000000", null, 3.5m, "User" },
                    { new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), "bossofthegym@gmail.com", "Біллі", "Герінґтон", null, "NkwocNZ3l262B3mX11lU9A==;efgCj+yQTM6XRXQc6OejSok3ZIp2Omqsl7UbLXQ5MnY=", "+38000000000", null, 2.5m, "User" },
                    { new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), "not.exist@gmail.com", "Тайлер", "Дьорден", null, "40YydzmEnQ1hzN2prE+icQ==;i66kZFJOvbBjvNjhmR3y82SGcjajE/0Qw05l98pllhw=", "+38000000000", null, 5.0m, "User" },
                    { new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), "killing.monsters@gmail.com", "Ґеральт", "з Рівії", null, "mxaAM8+/czroHE/v+yS+wA==;zqBsuZCqXGNUth7OYpJZfdwJStKu/38Vu7PINF+zSQw=", "+38000000000", null, 4.5m, "User" },
                    { new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), "tatakae@gmail.com", "Еран", "Єґа", null, "Wfs4VBfI8TzIgiWCaBIj6g==;5kz7OgSy5HS1gjC5e+Wu8sjDtMK9kddJQEbL8wwBSgw=", "+38000000000", null, 1.5m, "User" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("1de08753-6df9-423f-92e4-6d408bd2d2d4"), null, null, null, new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Гаррі це дуже файний пацан! Стоп...", new Guid("08f211e7-af5f-403c-897e-a31527b721d8") },
                    { new Guid("3a1996e2-13ff-4405-a55d-9dea8ac10a42"), null, null, null, new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), "Ґеральт це дуже файний пацан! Стоп...", new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9") },
                    { new Guid("7c9c96c7-6fbe-49ef-8cc2-eb4aebb775f6"), null, null, null, new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), "Еран це дуже файний пацан! Стоп...", new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444") },
                    { new Guid("d5a0f0de-2fd6-4c86-8f75-53fef9156b14"), null, null, null, new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), "Біллі це дуже файний пацан! Стоп...", new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100") },
                    { new Guid("d5e705bd-d499-45c0-96bf-e76627285ddb"), null, null, null, new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), "Тайлер це дуже файний пацан! Стоп...", new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc") }
                });

            migrationBuilder.InsertData(
                table: "Favors",
                columns: new[] { "Id", "AuthorId", "Description", "Price", "Rating", "Title" },
                values: new object[,]
                {
                    { new Guid("73e9162f-7a5a-411c-89b2-e7008b8676cd"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Отримайте розкішну косметичну процедуру, яка підкреслить вашу природну красу і зробить вашу шкіру сяючою.", 80.0m, 0m, "Косметична процедура" },
                    { new Guid("85aea96e-38f7-4540-99fd-4f4f3b06598d"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Розслабтеся і зосередьтеся на своєму тілі та розумі під час особистого сеансу йоги з досвідченим інструктором.", 55.3m, 0m, "Сеанс йоги" },
                    { new Guid("d796954d-a19b-4220-a307-158a188bf965"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Найкращі майстри масажу готові показати всі свої вміння на вашій задубілій спині.", 50.5m, 0m, "Масаж" },
                    { new Guid("e5cc3341-235a-484d-898d-281774cb1594"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Розкішний манікюр і педикюр, який зробить ваші нігті і ніжки неймовірно чудовими і доглянутими.", 45.8m, 0m, "Ретельна манікюр і педикюр" },
                    { new Guid("f3170037-57b9-4386-9eb8-1b0d141bb2cb"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Досвідчений тренер допоможе вам досягнути ваших фітнес-цілей, розробивши індивідуальну тренувальну програму для вас.", 70.2m, 0m, "Персональний тренер" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("73a9dca2-92d1-4074-b1b5-0a1abf3c2e5b"), null, null, "c7a48821-6f90-44ad-a67a-f8e54aa9da83.png", null, new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9") },
                    { new Guid("7808aa28-0ec5-4063-82c1-c40c3b18829e"), null, null, "d6181258-35b6-4564-bd87-94122639bd2c.png", null, new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc") },
                    { new Guid("7fa50b78-5533-4d73-8a52-e3cc722e6189"), null, null, "8d08fcb9-8216-480a-ac50-7704224c1aba.png", null, new Guid("08f211e7-af5f-403c-897e-a31527b721d8") },
                    { new Guid("d067af25-99d0-4c5d-b4e3-5c9b82c2623e"), null, null, "68ae3d64-3328-4805-9d98-86714f6257c9.png", null, new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444") },
                    { new Guid("e72ae2f7-05f4-4136-b048-a17682c483ef"), null, null, "76446e29-7895-48b5-88a8-6aa0053cb950.png", null, new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("1365ff6f-ff97-4cb4-90c2-d865e78cc546"), null, null, null, null, new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9") },
                    { new Guid("6eebe024-52e1-4326-982a-d05a8e22ab80"), null, null, null, null, new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444") },
                    { new Guid("7655b805-4b09-4e2a-a2b4-061f336e42af"), null, null, null, null, new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc") },
                    { new Guid("caabf843-87bb-47fb-ad93-500ad4d3cf7e"), null, null, null, null, new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8") },
                    { new Guid("cb87a4a0-d567-4a58-a6e5-a6217e850998"), null, null, null, null, new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100") }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "AuthorId", "Date", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("102ac689-dfc0-42af-abd9-10d0e5eddf63"), new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8719), "Хтось цікавиться проведенням вечірки вдома з настільними іграми? Я маю гарну колекцію ігор і шукаю компанію для веселого проведення вечора. Приєднуйтесь!", "Вечірка вдома з настільними іграми" },
                    { new Guid("4677f772-2acd-40c3-94a3-b03ee2fe655c"), new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8714), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("57c8ba50-a84d-40dd-802b-bb9f884e7614"), new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8723), "Шукаю людей, які так само захоплені гуртом 'Rammstein' і хотіли б піти на їхній концерт. Разом буде набагато веселіше! Хто бажає долучитися?", "Концерт Rammstein" },
                    { new Guid("5bb25d2b-4500-44b8-8e19-93124dfbff74"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8710), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", "Вечірня прогулянка по місту" },
                    { new Guid("6e573647-25ec-4298-b2e9-4c5eec746ac5"), new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8704), "Приходьте до мене сьогодні в джакузі, тут весело. Про оплату потім.", "Джакузі з скінхедом" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Location", "Title" },
                values: new object[,]
                {
                    { new Guid("0dc85af5-6ba7-4329-b2c2-94abbe4033ae"), new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8664), "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!", null, "Смаколики Карпатської кухні" },
                    { new Guid("27a58803-71a1-4081-a10c-e153189ece77"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8611), "Карпати інфо шахраї! Я забронювала собі номер в одній з камер Азкабану, але дементори мене туди не впустили. Це жах!", null, "Увага!" },
                    { new Guid("6913590a-af0b-4b67-8cb9-b34474f4424a"), new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8669), "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!", null, "Неймовірні пейзажі Карпат" },
                    { new Guid("dfdfa042-14bf-42bc-8008-3e86bbb1ed7a"), new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8674), "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!", null, "Зимові пригоди у Карпатах" },
                    { new Guid("f76853c2-07e6-4f71-ba63-666b64dd31a1"), new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), new DateTime(2023, 6, 17, 15, 18, 22, 614, DateTimeKind.Local).AddTicks(8657), "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!", null, "Незабутні враження від Карпат" }
                });

            migrationBuilder.InsertData(
                table: "UserTags",
                columns: new[] { "TagId", "UserId" },
                values: new object[,]
                {
                    { new Guid("69697103-7de2-473d-9495-3c676a0141b7"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8") },
                    { new Guid("7ffd387f-61d9-4f23-a59a-dee2de132f44"), new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100") },
                    { new Guid("3c2de118-e173-4e12-95cf-a2cef626a5a3"), new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc") },
                    { new Guid("9f26a73f-0f3f-48a7-9161-8e29d5f7bb83"), new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9") },
                    { new Guid("f26eb314-0b87-4ce1-9412-ddcedc964690"), new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444") }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("1d96f30a-d8a7-42b2-9094-011d0ae3bb52"), new Guid("85aea96e-38f7-4540-99fd-4f4f3b06598d"), null, null, new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), "Сеанс йоги це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("2c24b4ba-64f9-4748-b3f2-645bccf53b31"), null, null, new Guid("f76853c2-07e6-4f71-ba63-666b64dd31a1"), new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), "Незабутні враження від Карпат це дуже корисна публікація!", null },
                    { new Guid("2d922c9d-2dd5-4fef-b537-260212653853"), new Guid("f3170037-57b9-4386-9eb8-1b0d141bb2cb"), null, null, new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), "Персональний тренер це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("3540e2e7-2041-4645-bdee-60478ca53160"), new Guid("e5cc3341-235a-484d-898d-281774cb1594"), null, null, new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), "Ретельна манікюр і педикюр це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("591360dc-b2b1-491f-8ff3-8d1c44513700"), null, null, new Guid("27a58803-71a1-4081-a10c-e153189ece77"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Увага! це дуже корисна публікація!", null },
                    { new Guid("68780820-207d-427b-88dc-df867d072ad6"), null, new Guid("5bb25d2b-4500-44b8-8e19-93124dfbff74"), null, new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("7264b02b-80b0-4328-bc75-c3b13d711643"), new Guid("d796954d-a19b-4220-a307-158a188bf965"), null, null, new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Масаж це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("9eff24db-46fa-43e7-b9ae-97a133e8becc"), null, null, new Guid("dfdfa042-14bf-42bc-8008-3e86bbb1ed7a"), new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), "Зимові пригоди у Карпатах це дуже корисна публікація!", null },
                    { new Guid("a85a6004-c550-4ec6-b4b1-3014ba5979a3"), null, new Guid("4677f772-2acd-40c3-94a3-b03ee2fe655c"), null, new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("a9d856ff-0992-4a6e-9c91-ef7a68e4766d"), null, new Guid("6e573647-25ec-4298-b2e9-4c5eec746ac5"), null, new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), "Джакузі з скінхедом це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("b66ef0cf-a24b-4ac0-970b-b4214e18f18b"), new Guid("73e9162f-7a5a-411c-89b2-e7008b8676cd"), null, null, new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), "Косметична процедура це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("b7c090fd-0c94-48ad-a171-d367ef125b9b"), null, null, new Guid("6913590a-af0b-4b67-8cb9-b34474f4424a"), new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), "Неймовірні пейзажі Карпат це дуже корисна публікація!", null },
                    { new Guid("b89c0acd-8edb-4fab-9025-d39a8cf683c9"), null, new Guid("57c8ba50-a84d-40dd-802b-bb9f884e7614"), null, new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), "Концерт Rammstein це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("ca3f8f60-d9a4-44eb-91c8-6a1eb37fe8c9"), null, new Guid("102ac689-dfc0-42af-abd9-10d0e5eddf63"), null, new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), "Вечірка вдома з настільними іграми це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("efeab792-a8e9-4304-ae4b-d2de8058aad4"), null, null, new Guid("0dc85af5-6ba7-4329-b2c2-94abbe4033ae"), new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), "Смаколики Карпатської кухні це дуже корисна публікація!", null }
                });

            migrationBuilder.InsertData(
                table: "FavorTags",
                columns: new[] { "FavorId", "TagId" },
                values: new object[,]
                {
                    { new Guid("73e9162f-7a5a-411c-89b2-e7008b8676cd"), new Guid("f26eb314-0b87-4ce1-9412-ddcedc964690") },
                    { new Guid("85aea96e-38f7-4540-99fd-4f4f3b06598d"), new Guid("7ffd387f-61d9-4f23-a59a-dee2de132f44") },
                    { new Guid("d796954d-a19b-4220-a307-158a188bf965"), new Guid("69697103-7de2-473d-9495-3c676a0141b7") },
                    { new Guid("e5cc3341-235a-484d-898d-281774cb1594"), new Guid("3c2de118-e173-4e12-95cf-a2cef626a5a3") },
                    { new Guid("f3170037-57b9-4386-9eb8-1b0d141bb2cb"), new Guid("9f26a73f-0f3f-48a7-9161-8e29d5f7bb83") }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0169eac2-f30d-4494-a1d8-5603a59217c9"), null, null, "73aabeec-7310-429a-a060-258893d97a33.png", new Guid("dfdfa042-14bf-42bc-8008-3e86bbb1ed7a"), null },
                    { new Guid("06d3b8ec-0a4d-4852-9cfa-bc2b8dbd38a3"), null, new Guid("57c8ba50-a84d-40dd-802b-bb9f884e7614"), "ff9187ea-bdbf-4fd7-bea7-b09d21ce3f85.png", null, null },
                    { new Guid("2e146f8f-d4ea-4528-8739-fd8df0e3740f"), new Guid("85aea96e-38f7-4540-99fd-4f4f3b06598d"), null, "8d149e33-b52f-4d2d-b9d4-dfaee86f0ef8.png", null, null },
                    { new Guid("47b94a9b-317a-41d3-9e43-e9ab3a3d0309"), null, new Guid("102ac689-dfc0-42af-abd9-10d0e5eddf63"), "834d313f-2243-47bf-832d-ec03a523b397.png", null, null },
                    { new Guid("636a4c42-5c97-4bc7-ac3e-39770bdc4771"), new Guid("e5cc3341-235a-484d-898d-281774cb1594"), null, "8778283c-e253-48d3-bd2b-04d32b0195d1.png", null, null },
                    { new Guid("721d49e5-4b05-42c4-9806-4afc07701b53"), null, null, "10fa44c6-09ed-45a4-a31a-ea2d9a6b7164.png", new Guid("27a58803-71a1-4081-a10c-e153189ece77"), null },
                    { new Guid("8872d1a5-a5af-4c0f-bbcb-8b93e1116c7c"), null, null, "9470cd9b-e6b8-4f5f-a06f-20653395313d.png", new Guid("f76853c2-07e6-4f71-ba63-666b64dd31a1"), null },
                    { new Guid("94a8de4c-0194-4a34-a863-2e8dbc821d1a"), null, null, "bab337a8-8651-461a-b88d-1d048a9cea02.png", new Guid("6913590a-af0b-4b67-8cb9-b34474f4424a"), null },
                    { new Guid("99736258-0b9b-4c02-b2c3-62c7c018b645"), new Guid("73e9162f-7a5a-411c-89b2-e7008b8676cd"), null, "ced60315-da9c-4b11-bc34-4afede464cc7.png", null, null },
                    { new Guid("bba50028-019c-4b3d-90ee-d034532f9863"), null, new Guid("6e573647-25ec-4298-b2e9-4c5eec746ac5"), "0a41cad7-68a9-4399-b5fa-4ab469c46885.png", null, null },
                    { new Guid("c74eb49e-ee7a-4b29-b0db-43f9a70120f3"), null, new Guid("4677f772-2acd-40c3-94a3-b03ee2fe655c"), "a22d6751-84f5-4a3a-ac67-8869c97f9f90.png", null, null },
                    { new Guid("d45b8813-9cbc-4d45-af5e-52fcd42f962f"), null, null, "b1d92c49-26bc-41e8-8026-af01f5c4b52c.png", new Guid("0dc85af5-6ba7-4329-b2c2-94abbe4033ae"), null },
                    { new Guid("d56b1300-86d0-4473-b36e-8018c9eb61fb"), new Guid("f3170037-57b9-4386-9eb8-1b0d141bb2cb"), null, "497245a8-4f2d-4f0b-a063-87c7a431f181.png", null, null },
                    { new Guid("e28e2864-58d9-4a25-802e-a616602d9858"), new Guid("d796954d-a19b-4220-a307-158a188bf965"), null, "a86ef337-79dc-4bc6-93a4-ce1324f86c21.png", null, null },
                    { new Guid("f928a8af-0402-466e-8ca1-e8ebdc855204"), null, new Guid("5bb25d2b-4500-44b8-8e19-93124dfbff74"), "0a5b1904-b171-492e-ac66-bf8cb5873249.png", null, null }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("091f8836-108d-4a9e-b5ff-7244cca33b66"), null, null, null, new Guid("6913590a-af0b-4b67-8cb9-b34474f4424a"), new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), null },
                    { new Guid("23dff11c-f8f4-4834-8874-e9f541d7a766"), null, null, new Guid("102ac689-dfc0-42af-abd9-10d0e5eddf63"), null, new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), null },
                    { new Guid("2eb25930-3545-4f85-b348-2cdd248c41c8"), null, new Guid("85aea96e-38f7-4540-99fd-4f4f3b06598d"), null, null, new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), null },
                    { new Guid("434d3605-5be8-4d1d-a557-74a6c69ae862"), null, new Guid("73e9162f-7a5a-411c-89b2-e7008b8676cd"), null, null, new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), null },
                    { new Guid("55adb7ea-fe19-43db-bfe9-a22060920d90"), null, new Guid("e5cc3341-235a-484d-898d-281774cb1594"), null, null, new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), null },
                    { new Guid("5b92d726-a4a5-400b-b519-e49e71309ea4"), null, null, new Guid("5bb25d2b-4500-44b8-8e19-93124dfbff74"), null, new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), null },
                    { new Guid("76287490-b98b-4920-af9e-beb0d7bd998d"), null, null, new Guid("4677f772-2acd-40c3-94a3-b03ee2fe655c"), null, new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), null },
                    { new Guid("7d444e6c-43a6-4f35-8c56-9fa40445e141"), null, new Guid("d796954d-a19b-4220-a307-158a188bf965"), null, null, new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), null },
                    { new Guid("8bb15ff4-fd46-48da-ba1e-529da2c9b7a5"), new Guid("1de08753-6df9-423f-92e4-6d408bd2d2d4"), null, null, null, new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc"), null },
                    { new Guid("d3ae4913-4f9c-4768-bbdb-d96be402bf27"), null, null, new Guid("6e573647-25ec-4298-b2e9-4c5eec746ac5"), null, new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), null },
                    { new Guid("d3f1fa69-e189-4f6a-b685-f1bdd30b159d"), null, null, null, new Guid("27a58803-71a1-4081-a10c-e153189ece77"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), null },
                    { new Guid("e3da1ac1-93e1-4aa4-b35b-55f58afa113d"), null, new Guid("f3170037-57b9-4386-9eb8-1b0d141bb2cb"), null, null, new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), null },
                    { new Guid("e510e1f5-d34d-48a3-a832-be986d11fd4f"), null, null, null, new Guid("f76853c2-07e6-4f71-ba63-666b64dd31a1"), new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), null },
                    { new Guid("ed5b80e8-436c-476f-bbfd-7589396fa2b5"), null, null, new Guid("57c8ba50-a84d-40dd-802b-bb9f884e7614"), null, new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), null },
                    { new Guid("f0e281c3-d5c0-49ef-8cf9-dfbb8a5a9327"), null, null, null, new Guid("0dc85af5-6ba7-4329-b2c2-94abbe4033ae"), new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), null },
                    { new Guid("f4d67d7a-d0c5-4c83-9d39-bae50f102647"), null, null, null, new Guid("dfdfa042-14bf-42bc-8008-3e86bbb1ed7a"), new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), null }
                });

            migrationBuilder.InsertData(
                table: "PartyTags",
                columns: new[] { "PartyId", "TagId" },
                values: new object[,]
                {
                    { new Guid("102ac689-dfc0-42af-abd9-10d0e5eddf63"), new Guid("3c2de118-e173-4e12-95cf-a2cef626a5a3") },
                    { new Guid("4677f772-2acd-40c3-94a3-b03ee2fe655c"), new Guid("9f26a73f-0f3f-48a7-9161-8e29d5f7bb83") },
                    { new Guid("57c8ba50-a84d-40dd-802b-bb9f884e7614"), new Guid("7ffd387f-61d9-4f23-a59a-dee2de132f44") },
                    { new Guid("5bb25d2b-4500-44b8-8e19-93124dfbff74"), new Guid("f26eb314-0b87-4ce1-9412-ddcedc964690") },
                    { new Guid("6e573647-25ec-4298-b2e9-4c5eec746ac5"), new Guid("69697103-7de2-473d-9495-3c676a0141b7") }
                });

            migrationBuilder.InsertData(
                table: "PartyUsers",
                columns: new[] { "PartyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("102ac689-dfc0-42af-abd9-10d0e5eddf63"), new Guid("49bb2916-c46c-440e-8e3f-97464b9dc3dc") },
                    { new Guid("4677f772-2acd-40c3-94a3-b03ee2fe655c"), new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9") },
                    { new Guid("57c8ba50-a84d-40dd-802b-bb9f884e7614"), new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100") },
                    { new Guid("5bb25d2b-4500-44b8-8e19-93124dfbff74"), new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444") },
                    { new Guid("6e573647-25ec-4298-b2e9-4c5eec746ac5"), new Guid("08f211e7-af5f-403c-897e-a31527b721d8") }
                });

            migrationBuilder.InsertData(
                table: "PostTags",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("0dc85af5-6ba7-4329-b2c2-94abbe4033ae"), new Guid("9f26a73f-0f3f-48a7-9161-8e29d5f7bb83") },
                    { new Guid("27a58803-71a1-4081-a10c-e153189ece77"), new Guid("69697103-7de2-473d-9495-3c676a0141b7") },
                    { new Guid("6913590a-af0b-4b67-8cb9-b34474f4424a"), new Guid("3c2de118-e173-4e12-95cf-a2cef626a5a3") },
                    { new Guid("dfdfa042-14bf-42bc-8008-3e86bbb1ed7a"), new Guid("7ffd387f-61d9-4f23-a59a-dee2de132f44") },
                    { new Guid("f76853c2-07e6-4f71-ba63-666b64dd31a1"), new Guid("f26eb314-0b87-4ce1-9412-ddcedc964690") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("477fa423-953c-42e1-96b5-7f555b1ade51"), new Guid("2c24b4ba-64f9-4748-b3f2-645bccf53b31"), null, null, null, new Guid("0e53e2b4-d5cf-4e46-b7ec-23fa48d68100"), null },
                    { new Guid("4e28d5c0-332a-4944-a65f-3693453cd6e7"), new Guid("a9d856ff-0992-4a6e-9c91-ef7a68e4766d"), null, null, null, new Guid("afcf9313-21da-4da1-b6aa-c65a2bfa7444"), null },
                    { new Guid("c6333530-1266-4883-a81a-c5226acb2cec"), new Guid("591360dc-b2b1-491f-8ff3-8d1c44513700"), null, null, null, new Guid("08f211e7-af5f-403c-897e-a31527b721d8"), null },
                    { new Guid("f263f775-eaf2-416e-8e40-f1d45df322f2"), new Guid("7264b02b-80b0-4328-bc75-c3b13d711643"), null, null, null, new Guid("890d6887-20ae-4ab9-b358-2c57bb35f5f9"), null }
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
