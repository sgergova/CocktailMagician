using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    UserPhoto = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    IsAlcoholic = table.Column<bool>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    AlcoholPercentage = table.Column<double>(nullable: false),
                    IsAlcoholic = table.Column<bool>(nullable: false),
                    ImageURL = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cocktails_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    CountryId = table.Column<Guid>(nullable: false),
                    BarImageURL = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bars_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CocktailComments",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CocktailId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailComments", x => new { x.CocktailId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CocktailComments_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailIngredients",
                columns: table => new
                {
                    CocktailId = table.Column<Guid>(nullable: false),
                    IngredientId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailIngredients", x => new { x.CocktailId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_CocktailIngredients_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailRatings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CocktailId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Vote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailRatings", x => new { x.CocktailId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CocktailRatings_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarCocktails",
                columns: table => new
                {
                    BarId = table.Column<Guid>(nullable: false),
                    CocktailId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    IsListed = table.Column<bool>(nullable: false),
                    ListedOn = table.Column<DateTime>(nullable: false),
                    UnlistedOn = table.Column<DateTime>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCocktails", x => new { x.BarId, x.CocktailId });
                    table.ForeignKey(
                        name: "FK_BarCocktails_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarCocktails_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarComments",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    BarId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarComments", x => new { x.UserId, x.BarId });
                    table.ForeignKey(
                        name: "FK_BarComments_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarRatings",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    BarId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Vote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarRatings", x => new { x.BarId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BarRatings_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), "dba55978-5a25-481d-b2be-106c5b897433", "Crawler", "CRAWLER" },
                    { new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"), "4d5a9033-bef0-4816-9b7f-4325cac87a7d", "Magician", "MEMBER" },
                    { new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"), "a97f2974-6b07-4d73-bff4-58ccc26fbbab", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), 0, "849c2a06-16a6-431e-9a6f-a3d39e3fcf25", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "crawler@abv.bg", false, false, false, null, null, "crawler@abv.bg", "CRAWLER@ABV.BG", "AQAAAAEAACcQAAAAEHmYjfUHrxDuZKX93SUcpv63/z4lNPo+XDcDrrESEY2ldIMsShfXjTRqCyaPXNDPaQ==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "CRAWLER@ABV.BG", null },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), 0, "eb61d079-77c5-4f9e-a485-52e89ee672b8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@abv.bg", false, false, false, null, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAELawshbDMdWI4Skb19GQRAbqEvWGiKZDKdCQMHCg1Am5d/svytgPxQDiNJbGEfGjZQ==", null, false, "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU", false, "admin@abv.bg", null },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), 0, "4a0d4d6f-c644-41b9-a554-6155785d0c3b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "magician@abv.bg", false, false, false, null, null, "magician@abv.bg", "MAGICIAN@ABV.BG", "AQAAAAEAACcQAAAAEFDq8ZUIW7h1IXnH5hE6MXQ/NBNgCk0Y5bhplY2OPaXr6qjLT/h/zH3Iww/PB9ComA==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "MAGICIAN@ABV.BG", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("3c031127-8084-495f-aa15-2bfcac898cbc"), 4.2000000000000002, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1097), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("dcf814b5-72c6-4fe7-a7b1-760c39526147"), 4.5, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1107), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("f9ade958-7277-445e-b752-1adbd40b4f1f"), 7.2999999999999998, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1115), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("3fbfef8b-3e38-4b6b-a552-b914e88de573"), 7.2000000000000002, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1122), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("9c461de5-ab52-4562-8e30-3962f3ce0a2e"), 16.0, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1143), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("d7139ea9-cf34-4706-8ae2-ae3418cb1e9c"), 12.699999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1136), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("36ebe104-3a23-4002-bf01-1005a3013bd8"), 4.0999999999999996, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1090), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("c97f4bdf-1acc-4e3c-8bdc-d73b137e1717"), 12.699999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1150), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("2ade5bea-a60f-486c-acb0-ad2a4ee4d6e7"), 2.5, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1157), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("454bdcb6-4fb0-453e-b839-3c6569833f8b"), 7.4000000000000004, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1130), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("464996f2-701e-4e46-a818-5a6290e8a9ed"), 3.8999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1083), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("aad1c368-1e1e-4912-a4a7-df0a4c55347b"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(94), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("9e566f40-22b9-4cf9-98a7-dd3e6b73725f"), 3.7999999999999998, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1068), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("04b8f5e7-e649-482a-9710-506693273f3d"), 3.7999999999999998, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1075), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("0c98af79-ca7c-4269-bc45-a4c384e59cc7"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(921), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("a6f24190-a4ce-4276-83dd-bb6ea0eaef7e"), 3.5, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(906), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("225e9058-ae57-4090-acea-177d37d280b9"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(898), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("8b79be59-2675-4ec8-8dd8-e52922f9496f"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(878), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("0b0afe70-6a16-415c-b63c-4c821118b3cf"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(949), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("49a0ff9d-0c0c-4e93-8798-743e7d843719"), 16.0, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(941), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("77a2c947-c2f3-4068-9177-6796b62f408d"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1024), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("ae86bad2-3826-400e-baed-cb9aaa01d51f"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1032), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("7a5af139-5c2d-4f05-a074-98a52d1b7e58"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1039), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("bb6b5906-3ec3-4631-af52-716e208d70b2"), 3.5, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1049), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("9740e120-e81f-4de0-937e-aa106f5f4b28"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1055), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("1b430fbe-03c3-419d-8cf3-1fe3b7256eb0"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(1061), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("4b3a8d4a-ad0b-4a28-927c-0cac0dd13306"), 3.3999999999999999, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(955), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("8bc3308a-7d9e-424f-9dda-f44a7103131c"), 3.5, new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(932), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("e6e3531b-c809-4d7e-a21e-1207aebaf06a"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6251), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("374baf20-1e0e-4327-9d99-4b6982d81061"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6260), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("ccd112fa-4f31-44cf-ab08-349ff8665333"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6257), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("9814b9a8-763f-4140-95d2-8237098c3bda"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6254), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("0db244dc-cb09-420f-ba1f-2f1f76760431"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6249), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("7ddf2274-6258-40c6-b32c-73dee7a398f0"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6208), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("8b07d64c-7912-47ea-9d9f-bac1ec92140f"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6205), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("b5ae4b8b-9f00-4f5c-af63-697c8f995799"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6202), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("354a12e8-ab6b-4039-884d-2e52059a96ca"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(5674), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("41a762b0-9c9b-40f5-9c16-c5b47d77bf3d"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6180), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("c6dcead4-9412-4e96-91b2-6aad69377293"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6192), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("41f6a2db-ab03-40c2-8212-ceeb21c4a676"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6195), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("a7517f5a-31d6-4f19-a303-cfe3c9c91eea"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6197), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("e962c1a1-77b1-4538-8f72-0b465b18c197"), new DateTime(2020, 5, 28, 15, 49, 9, 788, DateTimeKind.Utc).AddTicks(6244), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("1c6fd1d7-d92f-4709-b720-16372450d6bf"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1216), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("48e707ce-b3d4-4c23-b635-dbb0e7571193"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1219), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("59ef049f-a5ed-444e-9da5-3d64facca329"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1222), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("459516dd-cea5-414e-b143-efafc8b481cc"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1225), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("19ea32d5-6eb0-432e-92c4-4191cbae10bb"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1241), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("ddb1ee38-535f-4ac5-bf93-fa0e13dec155"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1230), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("58db28a5-4879-4588-83a1-8687def514e0"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1235), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("da2dd001-ef6f-40fc-85fe-9c9162b536ba"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1238), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("b05aacca-acc1-425f-9627-916819746815"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1244), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("dfb35580-88bb-43eb-98b2-c49bc2cb9785"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1227), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("31c7775e-6854-47be-b194-0ff39369fae8"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1213), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("b68bd42e-9f32-4ab5-99f2-c6eaa5946ce4"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1204), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("7b6b8a81-762e-4f05-a0c9-1dad8e514e64"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1201), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("56c9677d-9630-4583-8ea7-954e3600c81e"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1199), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("12fa4d40-7dfb-4685-bb6f-fb461ca782e9"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1169), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("d003db0e-299d-4e12-a435-00bc3b8f81e5"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1166), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("cafadd3e-962d-45fd-b20f-cd1dde30f32e"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1163), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("b733e0b5-2de7-4210-acdd-7f32567164f6"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1160), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("feb6198f-1b3b-4b58-ab64-8390a576c34a"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1157), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("05085644-745f-4d41-a764-4250d04ef305"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1148), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("498ae61d-d2cd-4a52-b3e8-e2e11553659f"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1145), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("c1d928b6-d2d0-4193-98cc-1eee5381be2e"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1143), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("e49bccfc-e77d-4c92-bf5a-e03739c00953"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1135), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("80e2cbfc-b6d1-41d9-ba94-a3ea5949fc6f"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1132), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("16e7ed3a-415f-45c7-9c1b-c78b3ffe28a1"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1117), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("eb9b13c2-c0bf-4116-a2ce-01272b5eb540"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(617), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("197e1baf-ac93-4f5f-ba24-df2c328ddbe2"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1209), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("26a4c168-690e-440c-adbb-ea4b07336697"), new DateTime(2020, 5, 28, 15, 49, 9, 787, DateTimeKind.Utc).AddTicks(1137), null, null, false, false, null, "Whiskey", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb") },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9") },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7") }
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "BarImageURL", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Phone", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("87ee2783-58fe-4bf0-bdf9-bb3de527e442"), "304 BRUNSWICK ST", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("374baf20-1e0e-4327-9d99-4b6982d81061"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7462), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, null },
                    { new Guid("e1ce5c87-213d-4a39-9e4e-bedc140243e3"), "Storgata 27 Oslo", "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("ccd112fa-4f31-44cf-ab08-349ff8665333"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7437), null, false, null, "Himkok", "+47 22 42 22 02", 0, null },
                    { new Guid("8b2acc29-4fbe-43ca-b6d7-c7af485c0d10"), "Av. �lvaro Obreg�n 106 Cuauht�moc", "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("9814b9a8-763f-4140-95d2-8237098c3bda"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7370), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, null },
                    { new Guid("28212ad1-6d9b-4d3f-bd49-ce6d8ebbc4d6"), "500 Arguello Street Redwood City", "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("e6e3531b-c809-4d7e-a21e-1207aebaf06a"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7353), null, false, null, "High Five", "(844) 464-4445", 0, null },
                    { new Guid("58a758fe-1aca-43c0-b304-a447db749e1c"), "52 Rue de Saintonge Paris", "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("0db244dc-cb09-420f-ba1f-2f1f76760431"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7422), null, false, null, "Candelaria", "+34 910 00 61", 0, null },
                    { new Guid("55a01d56-ab20-4459-9720-cb63ddb43c78"), "60 Rue Charlot Paris", "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("0db244dc-cb09-420f-ba1f-2f1f76760431"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7328), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, null },
                    { new Guid("76980cdd-e41c-43ab-ba12-9c4b780c883b"), "579 Fuxing Zhong Lu", "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("e962c1a1-77b1-4538-8f72-0b465b18c197"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7314), null, false, null, "Speak Low", "6416 0133", 0, null },
                    { new Guid("59261126-6ba1-4900-a9ce-7569d84fcc0e"), "Praxitelous 30 Athens", "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("7ddf2274-6258-40c6-b32c-73dee7a398f0"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7248), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, null },
                    { new Guid("f0c67587-568a-42c3-9aaf-1497ee695ccf"), "Paceville Main Staircase St Julian's", "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("8b07d64c-7912-47ea-9d9f-bac1ec92140f"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7212), null, false, null, "Native", "+356 2138 0635", 0, null },
                    { new Guid("01a9dad6-ad69-46fd-b9d1-3b2fbdcc6a9b"), "Calle Echegaray 21 28014 Madrid", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("b5ae4b8b-9f00-4f5c-af63-697c8f995799"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7184), null, false, null, "Salmon Guru", "+34 910 00 61", 0, null },
                    { new Guid("a55003ec-d7f0-4e86-a5f4-8e47c4fc60f8"), "37 Aberdeen Street Central", "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("a7517f5a-31d6-4f19-a303-cfe3c9c91eea"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7173), null, false, null, "The Old Man", "85227031899", 0, null },
                    { new Guid("43034b05-4e43-4943-8dea-acc456df3938"), "7 Ann Siang Hill", "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("41f6a2db-ab03-40c2-8212-ceeb21c4a676"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7474), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, null },
                    { new Guid("67d5af66-98dd-4869-9c25-8e36d956f7b0"), "Parkview Square", "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("41f6a2db-ab03-40c2-8212-ceeb21c4a676"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7383), null, false, null, "Atlas", "+65 6396 4466", 0, null },
                    { new Guid("4c3fc6d8-4500-4abd-b7ba-2636988584c3"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("c6dcead4-9412-4e96-91b2-6aad69377293"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7139), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, null },
                    { new Guid("4a3d467d-2334-45d5-9714-b23c0be75e5b"), "2727 Indian Creek Dr. Miami Beach", "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("41a762b0-9c9b-40f5-9c16-c5b47d77bf3d"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7410), null, false, null, "Broken Shaker", "305-531-2727", 0, null },
                    { new Guid("b48b0bf8-f07b-4236-8d3c-d1383c355543"), "79-81 MacDougal St New York", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("41a762b0-9c9b-40f5-9c16-c5b47d77bf3d"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7392), null, false, null, "Dante", "01 55 5264 4122", 0, null },
                    { new Guid("c847a559-a690-4158-8cc9-fa890d2884e5"), "134 Eldridge Street New York", "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("41a762b0-9c9b-40f5-9c16-c5b47d77bf3d"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7258), null, false, null, "Attaboy", "+36 1 792 2222", 0, null },
                    { new Guid("8b6513eb-9d04-4946-ad0a-99b5cc7ca3d8"), "", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("41a762b0-9c9b-40f5-9c16-c5b47d77bf3d"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7235), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("7af034e3-e45e-44fe-929c-78d3e767d3ce"), "531 Hudson St New York", "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("41a762b0-9c9b-40f5-9c16-c5b47d77bf3d"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7198), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("bdc5da42-5854-490c-b0e9-6dbe9516c42c"), "1170 BROADWAY & 28TH STREET NEW YORK", "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("41a762b0-9c9b-40f5-9c16-c5b47d77bf3d"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7111), null, false, null, "The NoMad", "(347) 472-5660", 0, null },
                    { new Guid("a53d758d-87eb-4475-822e-30afe9a78e41"), "Point Square North Dock Dublin", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("354a12e8-ab6b-4039-884d-2e52059a96ca"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7446), null, false, null, "The Gibson", "+353 1 681 5000", 0, null },
                    { new Guid("4bd62086-1140-4c8b-93c9-27dd8cfc6cbe"), "61�63. Meaden, London", "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("354a12e8-ab6b-4039-884d-2e52059a96ca"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7400), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("1a248474-e649-47af-a4f7-54c1b0e99a5e"), "8-9 Hoxton Square London", "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("354a12e8-ab6b-4039-884d-2e52059a96ca"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7338), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, null },
                    { new Guid("0f43a7fa-15c0-4e13-b087-f5c0d5b7660f"), "Soho, London", "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("354a12e8-ab6b-4039-884d-2e52059a96ca"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7267), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, null },
                    { new Guid("a7883cd7-2d80-4310-b20e-e89822735248"), "20 Upper Ground South Bank London SE1 9PD", "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("354a12e8-ab6b-4039-884d-2e52059a96ca"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7222), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("0928bcb0-5a8f-436f-9acc-0a38eb15594f"), "The Connaught Carlos Place Mayfair London", "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("354a12e8-ab6b-4039-884d-2e52059a96ca"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7161), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("9b37a800-74a0-4d56-b406-d1e03bbb2c72"), "1 Cuscaden Road 249715", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("41f6a2db-ab03-40c2-8212-ceeb21c4a676"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(7150), null, false, null, "Manhattan", "+65 6725 3377", 0, null },
                    { new Guid("af371237-3825-4072-a900-75e3eddc9846"), "The Savoy Strand London WC2R 0EZ", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("354a12e8-ab6b-4039-884d-2e52059a96ca"), new DateTime(2020, 5, 28, 15, 49, 9, 789, DateTimeKind.Utc).AddTicks(6479), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BarCocktails_CocktailId",
                table: "BarCocktails",
                column: "CocktailId");

            migrationBuilder.CreateIndex(
                name: "IX_BarComments_BarId",
                table: "BarComments",
                column: "BarId");

            migrationBuilder.CreateIndex(
                name: "IX_BarRatings_UserId",
                table: "BarRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Bars_CountryId",
                table: "Bars",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bars_UserId",
                table: "Bars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailComments_UserId",
                table: "CocktailComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailIngredients_IngredientId",
                table: "CocktailIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailRatings_UserId",
                table: "CocktailRatings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_UserId",
                table: "Cocktails",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BarCocktails");

            migrationBuilder.DropTable(
                name: "BarComments");

            migrationBuilder.DropTable(
                name: "BarRatings");

            migrationBuilder.DropTable(
                name: "CocktailComments");

            migrationBuilder.DropTable(
                name: "CocktailIngredients");

            migrationBuilder.DropTable(
                name: "CocktailRatings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
