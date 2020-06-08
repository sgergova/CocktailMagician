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
                    Rating = table.Column<int>(nullable: false),
                    RatingSum = table.Column<int>(nullable: false),
                    RatedCount = table.Column<int>(nullable: false),
                    AverageRating = table.Column<int>(nullable: false),
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
                    RatingSum = table.Column<int>(nullable: false),
                    RatedCount = table.Column<int>(nullable: false),
                    AverageRating = table.Column<int>(nullable: false),
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
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CocktailId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailComments", x => new { x.CocktailId, x.UserId, x.Id });
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
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    CocktailId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailRatings", x => new { x.CocktailId, x.UserId, x.Id });
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
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BarId = table.Column<Guid>(nullable: false),
                    Comments = table.Column<string>(maxLength: 500, nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarComments", x => new { x.UserId, x.BarId, x.Id });
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
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    BarId = table.Column<Guid>(nullable: false),
                    Rating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarRatings", x => new { x.BarId, x.UserId, x.Id });
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
                    { new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), "d2c96ae6-8142-419b-bf85-3e5e43f1cf2a", "Crawler", "CRAWLER" },
                    { new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"), "5ad186c2-7196-4a14-963a-5d3aff6703fc", "Magician", "MEMBER" },
                    { new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"), "0b73b8c5-5597-4009-9176-5b22ca6ba506", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), 0, "a10162e8-56d0-4f4e-8758-85a62905f9cf", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "crawler@abv.bg", false, false, false, null, null, "crawler@abv.bg", "CRAWLER@ABV.BG", "AQAAAAEAACcQAAAAEF9ZUvnZKtMJXKd5BZpoxzFOAJdTdh0KNDqhMJ7LqGwTyOd1/059dzZsFwKNOUc3zQ==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "CRAWLER@ABV.BG", null },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), 0, "bdbb8bd4-2881-413e-b1ce-3f920f769632", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@abv.bg", false, false, false, null, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEEp9hzBqOc7Q1Wn6N9OH+hkOB6YzenjD5XVRgMrHUk13jLj+HAnd8zAFm5TCVXx7pw==", null, false, "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU", false, "admin@abv.bg", null },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), 0, "cee5efb3-e2b9-45ef-bf4a-41982ae3eab9", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "magician@abv.bg", false, false, false, null, null, "magician@abv.bg", "MAGICIAN@ABV.BG", "AQAAAAEAACcQAAAAEHd7UEAkSI5obrn+bjoFG9qoMvJY3kdEuO7BqBSBYMTiRe6Kd1METWaaScIoFtzmTg==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "MAGICIAN@ABV.BG", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "AverageRating", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "RatedCount", "Rating", "RatingSum", "UserId" },
                values: new object[,]
                {
                    { new Guid("500df330-695c-48ee-b0dc-7da1208279fa"), 4.2000000000000002, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6246), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0, 0, 0, null },
                    { new Guid("57a2b7f2-1949-4ef6-887f-d81f978fd606"), 4.5, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6261), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0, 0, 0, null },
                    { new Guid("be759122-dae8-4169-b465-a99cc5ff38a6"), 7.2999999999999998, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6280), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0, 0, 0, null },
                    { new Guid("024c7baa-5de5-4771-a280-e0038f873baf"), 7.2000000000000002, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6310), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0, 0, 0, null },
                    { new Guid("9f17f944-7c7b-442a-ac51-6a04ff918309"), 16.0, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6359), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0, 0, 0, null },
                    { new Guid("75f8508e-13e4-49ac-8815-37e381aecd20"), 12.699999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6345), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0, 0, 0, null },
                    { new Guid("38f8a989-f820-4adf-bc36-5fa3ba27f160"), 4.0999999999999996, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6231), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0, 0, 0, null },
                    { new Guid("9d289742-9972-4cc7-8721-9c0be86dee81"), 12.699999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6374), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0, 0, 0, null },
                    { new Guid("705e6854-c59a-4235-91fb-a3b290c210db"), 2.5, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6387), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0, 0, 0, null },
                    { new Guid("188c7df9-a9b5-4c62-905e-36e137eaa2a7"), 7.4000000000000004, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6326), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0, 0, 0, null },
                    { new Guid("9ec874b7-b618-4940-b646-6ca5e1b1a755"), 3.8999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6216), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0, 0, 0, null },
                    { new Guid("8aa26548-c926-4809-8232-e97881f8a673"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(5157), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0, 0, 0, null },
                    { new Guid("c451ea27-bbff-4d53-a3b6-bfcb2b6a9cfb"), 3.7999999999999998, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6177), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0, 0, 0, null },
                    { new Guid("d581f7ce-bf79-4535-ab36-7165a7518764"), 3.7999999999999998, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6198), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0, 0, 0, null },
                    { new Guid("5d2fba5f-8461-4319-bb95-391d567330d5"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(5980), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0, 0, 0, null },
                    { new Guid("5af605c8-6be6-46fe-8e34-a4a571f092d4"), 3.5, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(5963), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0, 0, 0, null },
                    { new Guid("4f3c1b07-9249-44d9-96a5-55d6eb792934"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(5943), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0, 0, 0, null },
                    { new Guid("60a63421-6123-4d16-967b-1bf6a4bb6dd3"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(5902), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0, 0, 0, null },
                    { new Guid("65defa14-d083-4a1b-8dae-0968662b3050"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6038), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0, 0, 0, null },
                    { new Guid("a8258728-7345-4bbc-a19c-4a34438be744"), 16.0, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6021), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0, 0, 0, null },
                    { new Guid("18a0e7e9-9863-4d34-b89d-f81f59e8ad40"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6087), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0, 0, 0, null },
                    { new Guid("2d9cc6ea-46b4-409d-b02e-c09d8ec9f9a9"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6103), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0, 0, 0, null },
                    { new Guid("5520e11e-69c2-44ea-ba7c-b96819178744"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6118), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0, 0, 0, null },
                    { new Guid("cfcbd425-f59e-437a-b812-954e8d98c151"), 3.5, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6133), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0, 0, 0, null },
                    { new Guid("87571fbe-5603-4e3b-afb8-9a446f3aa67c"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6148), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0, 0, 0, null },
                    { new Guid("1630bcd3-a72f-498a-8b47-d58b43ef1294"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6163), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0, 0, 0, null },
                    { new Guid("289cb579-c7f8-454e-b6b0-4d356e811850"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6063), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0, 0, 0, null },
                    { new Guid("996db727-ea01-408e-b38a-06542679d106"), 3.5, 0, new DateTime(2020, 6, 8, 12, 47, 56, 664, DateTimeKind.Utc).AddTicks(6003), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0, 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("3b8936f5-9ab8-4800-b01c-f2ec84536df5"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4265), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("90f5ad59-7bfb-4524-9464-4e64959e49c8"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4281), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("d4b7fdf7-2723-4972-99fe-5bca09fd81b6"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4276), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("0aaff6e2-4009-47af-8ce6-978c15919b05"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4269), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("abbbd2d8-91a5-4f19-b180-05584251474f"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4261), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("cc2a0c85-9683-463f-91bb-071bdc6c1e9a"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4251), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("ab40f716-5890-4ded-89d9-d2f8f6d4029c"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4247), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("4ff65eb3-afa5-43d3-a8f4-5ce26209fc5e"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4243), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("2a60378b-c14a-4bc6-9407-341a22bd8c26"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(3278), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("ea10a43a-550f-4a93-83bc-5b611508bd21"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4194), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("adbc00db-e894-4599-9b9b-74375243dff9"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4215), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("79589f3e-f9f8-470b-8562-65ed6d3635c8"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4220), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("2539b348-65c2-4bd3-878f-d7750184c918"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4234), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("8d70d625-1b08-4992-8581-279901179233"), new DateTime(2020, 6, 8, 12, 47, 56, 665, DateTimeKind.Utc).AddTicks(4255), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("82dde651-d0dc-4c3b-859e-49b5f7c9b9a6"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6351), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("61b04be8-7a61-4910-af75-b472602e5f46"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6355), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("5b642d0a-d771-4659-b1f6-f6f3311b347b"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6362), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("e3ac37c4-cada-4c37-8934-91911682b91b"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6366), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("25e6bf85-f100-4f82-8794-ef6b53782a74"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6385), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("09ce9932-4df9-4060-83e1-98fbf155649a"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6374), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("32b3bd34-0108-4a0e-a6fe-fb18d2ac9d71"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6378), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("a8f175d6-f722-4f5f-af7b-1f1537cbf48a"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6381), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("ea7b0206-0b7c-4900-9a69-e30903e57c98"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6389), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("8e06362a-2d1a-4eee-9402-18e9bd90b2d6"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6370), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("621a995f-77e0-4ed1-a21d-00dad79c4a86"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6348), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("c460a882-345a-4620-9dec-d3215096aa8b"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6339), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("8e233257-ded8-4018-b914-04d21465d444"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6335), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("4b06cbf8-5ac8-4c55-8bf4-385aad07994a"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6332), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("d38b9ba8-c78f-4768-b628-928ce6e44ca6"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6328), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("a31025c6-d932-4f07-8a5b-17ad408ff1e7"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6319), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("c7cd2072-945d-458a-a346-6920479036c8"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6316), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("583d89c3-568a-470d-bb3a-dbbcf59a9cee"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6312), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("9ef12e21-0ab9-4b2a-bad1-7012daaed5d9"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6307), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("fc5ddb6a-9326-4788-b302-72577d0f3669"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6304), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("4659f55b-2474-4f63-9de6-3442df3e78d0"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6300), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("eadf3366-5099-4eca-9170-7191ed30daeb"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6296), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("56f16498-5785-4d8d-a834-c3e88d2f164c"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6260), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("cf96b7fc-f7e9-4427-bd96-39c264996a0a"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6256), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("dcaaa3a2-432c-45f8-95b8-dc095b9005dc"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6237), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("39b0a291-2661-4a3a-b6d4-36b286a91d3b"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(5574), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("55d42576-8429-4141-973b-e96bccd121f6"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6342), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("eceaa623-3e00-40ee-b9b9-e7a6c2549594"), new DateTime(2020, 6, 8, 12, 47, 56, 661, DateTimeKind.Utc).AddTicks(6287), null, null, false, false, null, "Whiskey", 0, 0 }
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
                columns: new[] { "Id", "Address", "AverageRating", "BarImageURL", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Phone", "RatedCount", "Rating", "RatingSum", "UserId" },
                values: new object[,]
                {
                    { new Guid("19629a84-4619-49d4-b20d-0980f67a3deb"), "304 BRUNSWICK ST", 0, "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("90f5ad59-7bfb-4524-9464-4e64959e49c8"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(1159), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, 0, 0, null },
                    { new Guid("39e28c5c-ebb5-4039-89b8-686e7b6535a1"), "Storgata 27 Oslo", 0, "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("d4b7fdf7-2723-4972-99fe-5bca09fd81b6"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(1114), null, false, null, "Himkok", "+47 22 42 22 02", 0, 0, 0, null },
                    { new Guid("e3ac8a57-f1fc-4b3f-860c-fa73bc8377b2"), "Av. �lvaro Obreg�n 106 Cuauht�moc", 0, "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("0aaff6e2-4009-47af-8ce6-978c15919b05"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(978), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, 0, 0, null },
                    { new Guid("dca1025d-302e-4b0e-83a4-d1d8c80c3f71"), "500 Arguello Street Redwood City", 0, "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("3b8936f5-9ab8-4800-b01c-f2ec84536df5"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(953), null, false, null, "High Five", "(844) 464-4445", 0, 0, 0, null },
                    { new Guid("75b857e0-77d7-42b0-8e83-3a352c458bf1"), "52 Rue de Saintonge Paris", 0, "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("abbbd2d8-91a5-4f19-b180-05584251474f"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(1090), null, false, null, "Candelaria", "+34 910 00 61", 0, 0, 0, null },
                    { new Guid("aa9a9c95-c6a0-4557-b2a9-7a0d8b727bfa"), "60 Rue Charlot Paris", 0, "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("abbbd2d8-91a5-4f19-b180-05584251474f"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(906), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, 0, 0, null },
                    { new Guid("7aaca603-16fd-466b-8422-d4efa02f07d3"), "579 Fuxing Zhong Lu", 0, "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("8d70d625-1b08-4992-8581-279901179233"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(884), null, false, null, "Speak Low", "6416 0133", 0, 0, 0, null },
                    { new Guid("5fd192a8-08c4-4424-bada-c46cc4d51ff8"), "Praxitelous 30 Athens", 0, "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("cc2a0c85-9683-463f-91bb-071bdc6c1e9a"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(824), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, 0, 0, null },
                    { new Guid("f2ab02e2-4c98-4684-b24b-01652dab20a2"), "Paceville Main Staircase St Julian's", 0, "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("ab40f716-5890-4ded-89d9-d2f8f6d4029c"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(762), null, false, null, "Native", "+356 2138 0635", 0, 0, 0, null },
                    { new Guid("a5e2a66a-1f11-42e6-96d0-fca3d3c4dcf7"), "Calle Echegaray 21 28014 Madrid", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("4ff65eb3-afa5-43d3-a8f4-5ce26209fc5e"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(723), null, false, null, "Salmon Guru", "+34 910 00 61", 0, 0, 0, null },
                    { new Guid("93ec94ff-d336-4462-9cfa-31254d0a96d6"), "37 Aberdeen Street Central", 0, "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("2539b348-65c2-4bd3-878f-d7750184c918"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(692), null, false, null, "The Old Man", "85227031899", 0, 0, 0, null },
                    { new Guid("5741910a-cde1-4e1a-a051-9bae8d875635"), "7 Ann Siang Hill", 0, "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("79589f3e-f9f8-470b-8562-65ed6d3635c8"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(1179), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, 0, 0, null },
                    { new Guid("905473f1-4941-43c2-9bf1-7d38dacfc128"), "Parkview Square", 0, "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("79589f3e-f9f8-470b-8562-65ed6d3635c8"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(996), null, false, null, "Atlas", "+65 6396 4466", 0, 0, 0, null },
                    { new Guid("b9286589-562c-4069-b53c-d9ed60b1695f"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", 0, "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("adbc00db-e894-4599-9b9b-74375243dff9"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(609), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, 0, 0, null },
                    { new Guid("05eba84f-1618-4023-8730-98de1042f41f"), "2727 Indian Creek Dr. Miami Beach", 0, "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("ea10a43a-550f-4a93-83bc-5b611508bd21"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(1067), null, false, null, "Broken Shaker", "305-531-2727", 0, 0, 0, null },
                    { new Guid("a57da88b-07f3-4b03-af24-6e7a0dad1f86"), "79-81 MacDougal St New York", 0, "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("ea10a43a-550f-4a93-83bc-5b611508bd21"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(1012), null, false, null, "Dante", "01 55 5264 4122", 0, 0, 0, null },
                    { new Guid("3f18b2ea-d751-47b9-a320-82af0c6dcf65"), "134 Eldridge Street New York", 0, "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("ea10a43a-550f-4a93-83bc-5b611508bd21"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(842), null, false, null, "Attaboy", "+36 1 792 2222", 0, 0, 0, null },
                    { new Guid("f649693c-b5fe-4783-91b6-e53853cb8031"), "", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("ea10a43a-550f-4a93-83bc-5b611508bd21"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(802), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, 0, 0, null },
                    { new Guid("4d80bc89-3b4c-4132-82bb-940fd44e1adc"), "531 Hudson St New York", 0, "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("ea10a43a-550f-4a93-83bc-5b611508bd21"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(742), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("27244f80-badb-4232-b8a2-5aa6a8bb14a6"), "1170 BROADWAY & 28TH STREET NEW YORK", 0, "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("ea10a43a-550f-4a93-83bc-5b611508bd21"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(567), null, false, null, "The NoMad", "(347) 472-5660", 0, 0, 0, null },
                    { new Guid("36a9b3b2-ca05-46bb-bff8-1a39002508c1"), "Point Square North Dock Dublin", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("2a60378b-c14a-4bc6-9407-341a22bd8c26"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(1131), null, false, null, "The Gibson", "+353 1 681 5000", 0, 0, 0, null },
                    { new Guid("b5a172be-8d02-45a7-a9cf-1dbd1b77dae9"), "61�63. Meaden, London", 0, "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("2a60378b-c14a-4bc6-9407-341a22bd8c26"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(1039), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("58afce7f-a12e-443f-a70a-1f1c83ad872f"), "8-9 Hoxton Square London", 0, "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("2a60378b-c14a-4bc6-9407-341a22bd8c26"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(922), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, 0, 0, null },
                    { new Guid("64027021-d48f-4a75-9605-9af6b1f4afc5"), "Soho, London", 0, "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("2a60378b-c14a-4bc6-9407-341a22bd8c26"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(857), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, 0, 0, null },
                    { new Guid("7e11b82f-fb6e-49ce-8014-bd975b56f1b5"), "20 Upper Ground South Bank London SE1 9PD", 0, "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("2a60378b-c14a-4bc6-9407-341a22bd8c26"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(782), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("6ae13feb-9dff-4450-8b6c-0099057d490b"), "The Connaught Carlos Place Mayfair London", 0, "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("2a60378b-c14a-4bc6-9407-341a22bd8c26"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(666), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("de623ea7-71e6-4ff2-ac6f-8df4bec4fdf1"), "1 Cuscaden Road 249715", 0, "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("79589f3e-f9f8-470b-8562-65ed6d3635c8"), new DateTime(2020, 6, 8, 12, 47, 56, 667, DateTimeKind.Utc).AddTicks(647), null, false, null, "Manhattan", "+65 6725 3377", 0, 0, 0, null },
                    { new Guid("2197619b-6d35-4b0e-8852-f05d51e00b4f"), "The Savoy Strand London WC2R 0EZ", 0, "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("2a60378b-c14a-4bc6-9407-341a22bd8c26"), new DateTime(2020, 6, 8, 12, 47, 56, 666, DateTimeKind.Utc).AddTicks(9741), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, 0, 0, null }
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
