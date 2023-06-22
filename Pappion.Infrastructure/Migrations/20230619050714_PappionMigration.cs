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
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP(6)"),
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    Tags = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    Tags = table.Column<string>(type: "longtext", nullable: true)
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
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Location", "Password", "PhoneNumber", "PhoneNumber2", "Role", "Tags" },
                values: new object[,]
                {
                    { new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), "killing.monsters@gmail.com", "Ґеральт", "з Рівії", null, "hQ4L4WihClWmc67eeo+rrg==;ZZuBEySWFApfVAiU7q1lzdTkZM6FT1Eelk7fDqMt15s=", "+38000000000", null, "User", null },
                    { new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), "not.exist@gmail.com", "Тайлер", "Дьорден", null, "bvqpoB95ofKetOpvVsgMVg==;eycGGKHWj+UeoO2lg1xLhsA/AJUwdocpDfPc64KUPfU=", "+38000000000", null, "User", null },
                    { new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), "bossofthegym@gmail.com", "Біллі", "Герінґтон", null, "u21WoXN0y/VYMXEtMd1+dQ==;hmcnnLJVik/QkrW+LTfdRuFt7zWJ7ioj6AkTh3Z4X6M=", "+38000000000", null, "User", null },
                    { new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "harrypotter@gmail.com", "Гаррі", "Поттер", null, "DG9R0aljenPyGhceYRejqg==;XH0joMmZRCv+NDwsx7BsKzo6cwWBmraxHdQJnVlkMJo=", "+38000000000", null, "User", null },
                    { new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), "tatakae@gmail.com", "Еран", "Єґа", null, "36x7Phcr5lftPC71fQ1kdw==;fbZmxHiL44aPOhIrP1762073rP3TndVMsbMqhLXCcco=", "+38000000000", null, "User", null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("1f02174e-57ac-491e-9214-c8d4df42f884"), null, null, null, new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), "Біллі це дуже файний пацан! Стоп...", new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a") },
                    { new Guid("4ce01b9d-0094-4eea-98f1-dff4c6cf216d"), null, null, null, new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Гаррі це дуже файний пацан! Стоп...", new Guid("c9ea8cb0-e656-4438-95da-9c4059725978") },
                    { new Guid("7893311b-2ead-4c23-884e-535a04bae88f"), null, null, null, new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), "Еран це дуже файний пацан! Стоп...", new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43") },
                    { new Guid("e4f595b5-5b1e-4850-af0b-4fdfaf6a447b"), null, null, null, new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), "Ґеральт це дуже файний пацан! Стоп...", new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc") },
                    { new Guid("ec26777b-4bbd-4c5a-8a1f-c00c9e043822"), null, null, null, new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), "Тайлер це дуже файний пацан! Стоп...", new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4") }
                });

            migrationBuilder.InsertData(
                table: "Favors",
                columns: new[] { "Id", "AuthorId", "Description", "Price", "Tags", "Title" },
                values: new object[,]
                {
                    { new Guid("3127b0e9-8f03-405c-bf71-08e17249be40"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Отримайте розкішну косметичну процедуру, яка підкреслить вашу природну красу і зробить вашу шкіру сяючою.", 80.0m, null, "Косметична процедура" },
                    { new Guid("6f469cff-838e-49ae-ac35-3722550210b8"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Розкішний манікюр і педикюр, який зробить ваші нігті і ніжки неймовірно чудовими і доглянутими.", 45.8m, null, "Ретельна манікюр і педикюр" },
                    { new Guid("a1059469-9acf-4fa3-b6f5-ce437042e3b7"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Найкращі майстри масажу готові показати всі свої вміння на вашій задубілій спині.", 50.5m, null, "Масаж" },
                    { new Guid("d5089a61-3f8a-43f4-999b-e902e474aebc"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Досвідчений тренер допоможе вам досягнути ваших фітнес-цілей, розробивши індивідуальну тренувальну програму для вас.", 70.2m, null, "Персональний тренер" },
                    { new Guid("ebf3a38f-dbc0-4a39-8a23-021f1bf0677a"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Розслабтеся і зосередьтеся на своєму тілі та розумі під час особистого сеансу йоги з досвідченим інструктором.", 55.3m, null, "Сеанс йоги" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("52659c69-1597-46b5-811e-150a9b7956a2"), null, null, "f4026c7b-4153-4fd2-96cb-7e6a3bd0f49e.png", null, new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a") },
                    { new Guid("6c8f6df0-1f0d-4859-9e55-b2235d1a7f46"), null, null, "94e023f3-a1bd-4e3a-b79a-3efa582258b8.png", null, new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4") },
                    { new Guid("b0177e9f-cd51-499a-9cd3-e223a6a4a61a"), null, null, "43fd2c3b-f056-4298-b0e0-6f96fb61932d.png", null, new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc") },
                    { new Guid("b94db1fc-a591-4316-a999-3a82934e73fc"), null, null, "da96f905-a21e-4b79-bf59-b782c08e2f61.png", null, new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43") },
                    { new Guid("d0f99ed2-8f07-4471-a837-5c0ab310dfc8"), null, null, "06e2aeb0-6d00-46df-bb33-5f20b5eafde9.png", null, new Guid("c9ea8cb0-e656-4438-95da-9c4059725978") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("16b9fec8-9da2-4dcc-bac9-f8d333c06d9e"), null, null, null, null, new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc") },
                    { new Guid("2546f21a-5725-47e2-bc96-a082afeb53aa"), null, null, null, null, new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4") },
                    { new Guid("7f962245-b5d3-4e78-a3c0-b84cbf840733"), null, null, null, null, new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43") },
                    { new Guid("9bd58f4b-ea29-443f-968a-0c4c513b79f4"), null, null, null, null, new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a") },
                    { new Guid("d34dcb18-ff8c-4b63-b7ba-576a29834fdc"), null, null, null, null, new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978") }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "AuthorId", "Date", "Description", "Tags", "Title" },
                values: new object[,]
                {
                    { new Guid("8bb35c25-d015-41b5-981c-cd1da5c71734"), new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2701), "Шукаю людей, які так само захоплені гуртом 'Rammstein' і хотіли б піти на їхній концерт. Разом буде набагато веселіше! Хто бажає долучитися?", null, "Концерт Rammstein" },
                    { new Guid("92c82bdf-7f59-44fb-85f8-0bd0d2c4968c"), new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2691), "Хтось цікавиться проведенням вечірки вдома з настільними іграми? Я маю гарну колекцію ігор і шукаю компанію для веселого проведення вечора. Приєднуйтесь!", null, "Вечірка вдома з настільними іграми" },
                    { new Guid("d8c03f32-1eda-40a2-9377-7b107539a43d"), new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2657), "Приходьте до мене сьогодні в джакузі, тут весело. Про оплату потім.", null, "Джакузі з скінхедом" },
                    { new Guid("da63af63-542f-41ad-8276-223af79cdad9"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2671), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", null, "Вечірня прогулянка по місту" },
                    { new Guid("efb9e3fc-7131-4b45-b25a-d7709bcbde2a"), new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2681), "Хто хоче приєднатися до мене для вечірньої прогулянки по красивому місту? Разом ми зможемо насолодитися видами, побалакати і провести час весело. Приходьте!", null, "Вечірня прогулянка по місту" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "AuthorId", "CreatedDate", "Description", "Location", "Tags", "Title" },
                values: new object[,]
                {
                    { new Guid("01c01814-a35f-46c5-8521-08015228158a"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2446), "Карпати інфо шахраї! Я забронювала собі номер в одній з камер Азкабану, але дементори мене туди не впустили. Це жах!", null, null, "Увага!" },
                    { new Guid("45855f35-5c0f-4b4b-b36c-8c99cb647f11"), new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2586), "Наша зимова подорож до Карпат принесла нам незабутні враження від катання на лижах. Добре обладнані гірськолижні курорти та різноманітні траси задовольнять навіть найвибагливіших любителів лижного спорту. Насолоджуйтесь зимовими пригодами у Карпатах!", null, null, "Зимові пригоди у Карпатах" },
                    { new Guid("99736e16-8173-477e-90b8-d3b467ee8460"), new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2532), "Нещодавно повернулися з унікальної подорожі до Карпат і просто захоплюємося цим мальовничим куточком природи. Гірські ландшафти та заповідні ліси залишили незабутні враження в нашій пам'яті. Рекомендуємо всім любителям пригод відвідати цю частину України!", null, null, "Незабутні враження від Карпат" },
                    { new Guid("e523f001-beba-4f8e-8534-f164cb2c543d"), new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2543), "Під час нашої поїздки в Карпати ми не лише насолоджувалися природою, але й смакували справжні кулінарні шедеври. Місцеві страви, такі як вершкові гриби та банош, просто вражають своїм неповторним смаком. Рекомендуємо спробувати!", null, null, "Смаколики Карпатської кухні" },
                    { new Guid("f113ca39-4d84-48d5-a489-c02db46670b3"), new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), new DateTime(2023, 6, 19, 8, 7, 14, 326, DateTimeKind.Local).AddTicks(2575), "Під час наших пішохідних прогулянок по Карпатах ми були просто зачаровані мальовничими пейзажами, які відкривалися перед нами. Гірські потоки, зелені луки та красиві гори - все це створює незабутню атмосферу та надихає на нові відкриття. Рекомендуємо це місце для всіх любителів активного відпочинку та красивої природи!", null, null, "Неймовірні пейзажі Карпат" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "FavorId", "PartyId", "PostId", "SenderId", "Text", "UserId" },
                values: new object[,]
                {
                    { new Guid("07cef633-7245-4107-81c1-27c6611ed0b1"), null, null, new Guid("45855f35-5c0f-4b4b-b36c-8c99cb647f11"), new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), "Зимові пригоди у Карпатах це дуже корисна публікація!", null },
                    { new Guid("0898139f-fa1a-475e-b19e-54a362dd4bd0"), null, new Guid("d8c03f32-1eda-40a2-9377-7b107539a43d"), null, new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Джакузі з скінхедом це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("1725dd4e-3d4d-4cc2-93ac-6d101536ae5d"), new Guid("6f469cff-838e-49ae-ac35-3722550210b8"), null, null, new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), "Ретельна манікюр і педикюр це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("19110e71-fd10-49b0-aa97-2cbd503ac32d"), null, null, new Guid("99736e16-8173-477e-90b8-d3b467ee8460"), new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), "Незабутні враження від Карпат це дуже корисна публікація!", null },
                    { new Guid("1afe714a-7cfb-4c54-bd6f-62b114c89c6f"), new Guid("d5089a61-3f8a-43f4-999b-e902e474aebc"), null, null, new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), "Персональний тренер це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("31786d76-9b59-4e7d-bdb5-5a9379cd9107"), null, new Guid("8bb35c25-d015-41b5-981c-cd1da5c71734"), null, new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), "Концерт Rammstein це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("38578da6-85db-4c93-90fe-963b9d0b4117"), null, new Guid("da63af63-542f-41ad-8276-223af79cdad9"), null, new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("4f54d4af-99e4-497b-a01b-2b39c9777f88"), new Guid("3127b0e9-8f03-405c-bf71-08e17249be40"), null, null, new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), "Косметична процедура це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("75572980-d4e4-4f06-9ffb-a37779a75fac"), null, null, new Guid("e523f001-beba-4f8e-8534-f164cb2c543d"), new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), "Смаколики Карпатської кухні це дуже корисна публікація!", null },
                    { new Guid("89b5d50b-1281-4875-a49b-c3fdb39ccfd8"), null, null, new Guid("01c01814-a35f-46c5-8521-08015228158a"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Увага! це дуже корисна публікація!", null },
                    { new Guid("d1b0bec8-0843-45a7-951c-771f5dc994a8"), null, null, new Guid("f113ca39-4d84-48d5-a489-c02db46670b3"), new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), "Неймовірні пейзажі Карпат це дуже корисна публікація!", null },
                    { new Guid("d3be419e-2fcb-48c4-b1c1-c1075d26741d"), new Guid("a1059469-9acf-4fa3-b6f5-ce437042e3b7"), null, null, new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), "Масаж це дуже крута послуга! Раджу всім спробувати!", null },
                    { new Guid("d9eba05e-bb8d-4c19-880f-efac9a73867b"), null, new Guid("efb9e3fc-7131-4b45-b25a-d7709bcbde2a"), null, new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), "Вечірня прогулянка по місту це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("ef842430-0294-4f40-a61e-306f0f66469a"), null, new Guid("92c82bdf-7f59-44fb-85f8-0bd0d2c4968c"), null, new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), "Вечірка вдома з настільними іграми це звучить дуже цікаво! Я обов'язково прийду!", null },
                    { new Guid("f0d6f08b-a733-4b11-9225-a2d657b727a0"), new Guid("ebf3a38f-dbc0-4a39-8a23-021f1bf0677a"), null, null, new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), "Сеанс йоги це дуже крута послуга! Раджу всім спробувати!", null }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "FavorId", "PartyId", "Path", "PostId", "UserId" },
                values: new object[,]
                {
                    { new Guid("12ad28d0-7a1c-41cd-875f-266e72110337"), null, null, "14348b12-e3bb-46ef-9ecd-91e0de3304a9.png", new Guid("e523f001-beba-4f8e-8534-f164cb2c543d"), null },
                    { new Guid("15d17603-83b9-4482-b4c2-1fb3311de276"), null, new Guid("d8c03f32-1eda-40a2-9377-7b107539a43d"), "157b02ad-ddd1-4424-a476-65c649e32f40.png", null, null },
                    { new Guid("18479017-89e1-4d73-8524-5038d69e8dcf"), null, new Guid("efb9e3fc-7131-4b45-b25a-d7709bcbde2a"), "9bc3b45c-6503-40f4-8208-09b74cae9d08.png", null, null },
                    { new Guid("19137bbf-3387-412d-ac33-e68a78f4fff2"), null, null, "5275fffe-7c2f-4626-9253-df5ea1b23e84.png", new Guid("45855f35-5c0f-4b4b-b36c-8c99cb647f11"), null },
                    { new Guid("22130ecf-7c16-4384-8f47-185a19706596"), null, new Guid("92c82bdf-7f59-44fb-85f8-0bd0d2c4968c"), "5bfbad97-d3c0-48db-aa08-fe60ceacc6f7.png", null, null },
                    { new Guid("2d07d0f9-1d16-4a20-8d67-05dda9d9684a"), null, null, "554f7b1c-a264-4c51-b371-0904b17f2f08.png", new Guid("f113ca39-4d84-48d5-a489-c02db46670b3"), null },
                    { new Guid("375fe58d-f9ac-4bb6-9416-f3a33e9d0ab7"), null, new Guid("da63af63-542f-41ad-8276-223af79cdad9"), "ae8cb79f-4f90-4cca-b70e-95f9b2b05267.png", null, null },
                    { new Guid("3c987f0c-2d59-4482-9001-d2192dbf1672"), null, new Guid("8bb35c25-d015-41b5-981c-cd1da5c71734"), "defab249-2c4b-4818-bf73-ee7422d5be9b.png", null, null },
                    { new Guid("4a2d35df-8105-4753-be0e-c0cc4d3344b6"), null, null, "1e1e0fc2-5ed1-4837-b6af-8d3ee67740ab.png", new Guid("99736e16-8173-477e-90b8-d3b467ee8460"), null },
                    { new Guid("508b8fc3-a20a-49c3-b938-3f387f44f7d6"), null, null, "dcc359ce-db8d-48e5-93ff-a6be972428af.png", new Guid("01c01814-a35f-46c5-8521-08015228158a"), null },
                    { new Guid("5b063914-76a1-4d6b-8663-bc352fcee751"), new Guid("d5089a61-3f8a-43f4-999b-e902e474aebc"), null, "0ee49abf-b94e-4a8b-b37a-d04808ebe320.png", null, null },
                    { new Guid("658ffa8a-443d-470b-ad8a-8e6641040f99"), new Guid("3127b0e9-8f03-405c-bf71-08e17249be40"), null, "52d1e54d-e44b-44ed-884e-90b5d5413e2f.png", null, null },
                    { new Guid("74201d6d-46bb-4429-8711-d14cdfde32b6"), new Guid("a1059469-9acf-4fa3-b6f5-ce437042e3b7"), null, "280a87bc-a9d1-4497-a73b-71ba7c4324e2.png", null, null },
                    { new Guid("795b699f-fdf2-4d69-8110-ba7da9e6eaba"), new Guid("ebf3a38f-dbc0-4a39-8a23-021f1bf0677a"), null, "c0e25481-1a6c-4e08-9302-3620e61f06ef.png", null, null },
                    { new Guid("a4b6501d-4ede-4398-b7dc-0af8b552eed2"), new Guid("6f469cff-838e-49ae-ac35-3722550210b8"), null, "2a46de4d-e988-4438-b322-b597710eda22.png", null, null }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("2a164e34-9bd9-4f29-9d6e-2bd29649e0ff"), null, null, null, new Guid("01c01814-a35f-46c5-8521-08015228158a"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), null },
                    { new Guid("36d26682-1246-4002-a6b8-df40dd086710"), new Guid("4ce01b9d-0094-4eea-98f1-dff4c6cf216d"), null, null, null, new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), null },
                    { new Guid("3bc75891-9541-442f-a0b5-639f0928c0e5"), null, null, new Guid("efb9e3fc-7131-4b45-b25a-d7709bcbde2a"), null, new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), null },
                    { new Guid("5573c391-545e-4f5b-81b2-9e7d0c270de4"), null, null, new Guid("8bb35c25-d015-41b5-981c-cd1da5c71734"), null, new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), null },
                    { new Guid("84ed742d-0345-4379-8281-44ae7f2872bc"), null, null, null, new Guid("f113ca39-4d84-48d5-a489-c02db46670b3"), new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), null },
                    { new Guid("8ebc3248-99b6-4f79-8aed-1b1d958c8e77"), null, null, new Guid("d8c03f32-1eda-40a2-9377-7b107539a43d"), null, new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), null },
                    { new Guid("9390ec61-457f-40e4-80e0-bc5dded2ce2f"), null, new Guid("ebf3a38f-dbc0-4a39-8a23-021f1bf0677a"), null, null, new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), null },
                    { new Guid("9bba682e-2f9d-446a-bc5e-723c02624a9b"), null, new Guid("a1059469-9acf-4fa3-b6f5-ce437042e3b7"), null, null, new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), null },
                    { new Guid("a0de6405-0e8c-44f8-8fbf-0b7a3efe1f4b"), null, new Guid("3127b0e9-8f03-405c-bf71-08e17249be40"), null, null, new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), null },
                    { new Guid("aa44a4d0-6652-4cd5-98ae-38b97df964e0"), null, null, new Guid("da63af63-542f-41ad-8276-223af79cdad9"), null, new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), null },
                    { new Guid("b463a8b0-12cb-406d-966c-b36fb3108dcf"), null, null, null, new Guid("99736e16-8173-477e-90b8-d3b467ee8460"), new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), null },
                    { new Guid("b4b93cd3-5fec-448d-9978-1bcd3ab7f07c"), null, null, null, new Guid("e523f001-beba-4f8e-8534-f164cb2c543d"), new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), null },
                    { new Guid("c88b4a03-670c-4348-98b6-32e9abbfd5e0"), null, null, null, new Guid("45855f35-5c0f-4b4b-b36c-8c99cb647f11"), new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), null },
                    { new Guid("ccf29cdd-84f7-425e-838c-f535452cf79c"), null, new Guid("6f469cff-838e-49ae-ac35-3722550210b8"), null, null, new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), null },
                    { new Guid("f1745e0c-f987-4547-ba02-295f9851e217"), null, null, new Guid("92c82bdf-7f59-44fb-85f8-0bd0d2c4968c"), null, new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4"), null },
                    { new Guid("f5d43b30-9a46-4815-b9cd-8492c67b4b57"), null, new Guid("d5089a61-3f8a-43f4-999b-e902e474aebc"), null, null, new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), null }
                });

            migrationBuilder.InsertData(
                table: "PartyUsers",
                columns: new[] { "PartyId", "UserId" },
                values: new object[,]
                {
                    { new Guid("8bb35c25-d015-41b5-981c-cd1da5c71734"), new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a") },
                    { new Guid("92c82bdf-7f59-44fb-85f8-0bd0d2c4968c"), new Guid("5120e53f-7ca5-4867-af64-174e0d5f95a4") },
                    { new Guid("d8c03f32-1eda-40a2-9377-7b107539a43d"), new Guid("c9ea8cb0-e656-4438-95da-9c4059725978") },
                    { new Guid("da63af63-542f-41ad-8276-223af79cdad9"), new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43") },
                    { new Guid("efb9e3fc-7131-4b45-b25a-d7709bcbde2a"), new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc") }
                });

            migrationBuilder.InsertData(
                table: "Likes",
                columns: new[] { "Id", "CommentId", "FavorId", "PartyId", "PostId", "SenderId", "UserId" },
                values: new object[,]
                {
                    { new Guid("05efa2dd-7eb1-495d-af6e-83ad13b04808"), new Guid("0898139f-fa1a-475e-b19e-54a362dd4bd0"), null, null, null, new Guid("c9f9a6a6-f124-4e44-b0ea-cad967e9ce43"), null },
                    { new Guid("1d246b47-40d4-40ff-9656-df60670f412a"), new Guid("19110e71-fd10-49b0-aa97-2cbd503ac32d"), null, null, null, new Guid("a082b00f-266b-4f9c-ac6d-281d72fac35a"), null },
                    { new Guid("b9c8c0a5-8727-4a27-89f8-f15782f41728"), new Guid("d3be419e-2fcb-48c4-b1c1-c1075d26741d"), null, null, null, new Guid("009e8ec4-0789-4b4d-a7f7-f37e2a0540fc"), null },
                    { new Guid("fd634a56-3243-4d42-b3be-2c22f05106bc"), new Guid("89b5d50b-1281-4875-a49b-c3fdb39ccfd8"), null, null, null, new Guid("c9ea8cb0-e656-4438-95da-9c4059725978"), null }
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
                name: "IX_PartyUsers_UserId",
                table: "PartyUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "PartyUsers");

            migrationBuilder.DropTable(
                name: "Comments");

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
