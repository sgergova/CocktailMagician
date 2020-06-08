using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Init : Migration
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
                    { new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), "4b32ed9b-39f4-49a6-94a5-70296bf56899", "Crawler", "CRAWLER" },
                    { new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"), "1e5a2467-872e-45ed-9c75-8848107a05b3", "Magician", "MEMBER" },
                    { new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"), "46f095a4-df01-4d75-89fb-5677e4896f45", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), 0, "ce61b138-81c9-4bcf-9591-9295e18ce2bb", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "crawler@abv.bg", false, false, false, null, null, "crawler@abv.bg", "CRAWLER@ABV.BG", "AQAAAAEAACcQAAAAECiP1enXVpt14nwMYlNeQcYTwas46011431Ofx2nkOK6uMG9ssYKLQxK1V/FK3XeOw==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "CRAWLER@ABV.BG", null },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), 0, "ea6e6acc-5b59-4552-b853-ade149d9c00b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@abv.bg", false, false, false, null, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEFNbuvyRXvmBYLgIJateOLASMV5+gCDp0li4F6VA8Dmivzdb9u1ZxdXO9bywwGwoJw==", null, false, "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU", false, "admin@abv.bg", null },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), 0, "43dc7993-88bd-4b06-ac71-3f5e42fe3785", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "magician@abv.bg", false, false, false, null, null, "magician@abv.bg", "MAGICIAN@ABV.BG", "AQAAAAEAACcQAAAAEEiQ4X8C/17ukWxmSPCao0oIaTiJxmFX3Nm0/Op+AFZYcjnGRwDIMZlPeYoNC760pQ==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "MAGICIAN@ABV.BG", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "AverageRating", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "RatedCount", "Rating", "RatingSum", "UserId" },
                values: new object[,]
                {
                    { new Guid("7cb2648c-d06c-4177-93e3-217bb0194ef3"), 4.2000000000000002, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7177), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0, 0, 0, null },
                    { new Guid("0367fbb4-f987-4a84-9f6d-140f1fde4ddf"), 4.5, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7187), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0, 0, 0, null },
                    { new Guid("778fccaa-8d87-49ef-8dba-595a396aade5"), 7.2999999999999998, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7195), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0, 0, 0, null },
                    { new Guid("8adb268f-afea-4b78-85d2-0ff45fc91058"), 7.2000000000000002, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7202), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0, 0, 0, null },
                    { new Guid("6f162b79-c94e-4d46-a6c2-94d0a5dde95a"), 16.0, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7225), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0, 0, 0, null },
                    { new Guid("e2481aec-b381-47f0-9fdf-96494a09a0bc"), 12.699999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7217), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0, 0, 0, null },
                    { new Guid("37f31516-0417-4e24-8efa-a958a3eb443c"), 4.0999999999999996, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7166), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0, 0, 0, null },
                    { new Guid("2993883a-a658-4d1c-80da-0d5044df3358"), 12.699999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7233), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0, 0, 0, null },
                    { new Guid("e5043362-f178-4a1b-b656-68aa26fe9e59"), 2.5, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7243), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0, 0, 0, null },
                    { new Guid("1c8be09d-0f20-4587-9b01-f48737e15a1a"), 7.4000000000000004, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7209), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0, 0, 0, null },
                    { new Guid("8d4b2220-f5ba-4c59-ab53-03ba28f460a1"), 3.8999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7158), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0, 0, 0, null },
                    { new Guid("5b3a4063-841e-40ba-bd82-b8644552cd23"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(6368), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0, 0, 0, null },
                    { new Guid("8fcbb8d5-0b20-46c8-8ccc-3274efd18297"), 3.7999999999999998, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7141), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0, 0, 0, null },
                    { new Guid("f7da5438-78e5-408f-b714-8beef2bd7f47"), 3.7999999999999998, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7149), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0, 0, 0, null },
                    { new Guid("c703d03b-d7c8-4a22-a198-2719e3940f11"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(6987), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0, 0, 0, null },
                    { new Guid("0a91d64f-a9b5-46a3-9f7a-310c25d4b7a5"), 3.5, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(6978), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0, 0, 0, null },
                    { new Guid("1a54c321-cbec-4299-a85f-f204974c565f"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(6955), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0, 0, 0, null },
                    { new Guid("dfa2aad4-be94-4c95-8b12-59c72adce1cd"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(6935), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0, 0, 0, null },
                    { new Guid("0c710d21-6b96-4c68-ac83-f96d6f107143"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7017), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0, 0, 0, null },
                    { new Guid("b7eb7b42-9ba6-4269-b477-af8b7bbff138"), 16.0, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7007), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0, 0, 0, null },
                    { new Guid("803bb333-15d4-4217-822c-688ab2c87180"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7036), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0, 0, 0, null },
                    { new Guid("0a3d6bc6-7a65-4e8f-b886-8a9bf66f9d7d"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7044), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0, 0, 0, null },
                    { new Guid("d047b9ec-d8a3-4255-9892-955c769d5309"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7055), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0, 0, 0, null },
                    { new Guid("b9a9b220-936b-4aa4-ad7a-e72d897587c6"), 3.5, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7063), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0, 0, 0, null },
                    { new Guid("3578449a-dd3e-4e82-9e55-8a827cc191b9"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7070), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0, 0, 0, null },
                    { new Guid("dc91fa42-d790-4ee4-9640-b0d68e3f34d8"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7078), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0, 0, 0, null },
                    { new Guid("407fe4d5-8a90-43dc-b47d-aa8c16364c3a"), 3.3999999999999999, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(7025), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0, 0, 0, null },
                    { new Guid("ead1da48-0e2f-4438-9c1f-3b06ee640e52"), 3.5, 0, new DateTime(2020, 6, 8, 13, 6, 40, 977, DateTimeKind.Utc).AddTicks(6998), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0, 0, 0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("4fb62a8a-f96d-4f40-bd82-f72292b18b4f"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2857), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("59aa7bf2-fbb1-497d-b604-075db46e9ccc"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2866), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("9a6fc756-2531-4a87-93a2-4f1aa16376dc"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("282f998d-0005-46a1-8e9e-87896ae34d9b"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2860), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("c5123312-1d39-4a5a-a78a-c98738bd3c4c"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2854), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("567e03f1-2aae-46db-8250-b3eca0f9a570"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2847), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("5068a265-8110-4893-80c7-1269c096c81d"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2836), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("227326fa-e7d1-4c5a-9086-f82818906d27"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2833), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("4826135b-8cab-463d-9ffa-0d1602a75b43"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2298), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("0f3eba9a-94d0-475a-964a-7da7c12ed480"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2811), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("696d6ca8-766c-494f-8e3a-cfe8c67fa90b"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2822), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("f5cd6a0e-1efe-4a42-8294-e8841aa01a0e"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2825), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("44c9581c-852c-4fcd-88e0-73ac6f3dea9b"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2828), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("30aa697e-4686-40ef-a42f-11782e78c1a3"), new DateTime(2020, 6, 8, 13, 6, 40, 978, DateTimeKind.Utc).AddTicks(2850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("dd08201e-baae-4e68-8765-a09dd230ae48"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7048), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("78f30cbf-94ce-40c9-a815-22ffa8fc0398"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7050), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("dcddb4bb-bb5f-4a5d-9724-e51bf5b0561f"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7053), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("8591f686-0ee1-4a6d-b1e4-687de675219a"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7056), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("7ab95825-529c-464c-beb9-392df63c8913"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7072), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("651ebe68-c491-41fc-96aa-f3ade6378992"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7064), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("4dff77b1-57e1-454a-96cb-de51725263db"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7067), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("4e354a65-83f0-44ed-a5d1-6a48dd5e49b1"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7070), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("216589ff-e7e2-4e05-a7bf-f37b21ac80be"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7119), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("edb4b011-ad9b-4ec5-9ed5-a4e9ccc2e3a4"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7059), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("836112dc-77be-4fce-a225-e1a40a7394b6"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7045), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("ce8ec823-b802-4504-903b-29c1c96d45fd"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7038), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("3f624d7e-b90a-47f7-a6d8-891f807d511c"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7033), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("bf1c77ba-68fc-43f2-aeb7-502721d36326"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7029), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("ff9bdb78-933e-431e-92ed-df6ddd001990"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7027), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("21add775-0423-4200-921c-a35c55c18878"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7024), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("2061dc8b-44ef-4a4b-aeb9-b696110863f1"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7021), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("cff1a6ad-0d33-477f-b67c-aecf141080a0"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7018), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("8117a55e-bc70-488f-9321-4d11d80edd33"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7014), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("00de9810-19d7-487a-85a7-baabe067f2ab"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7011), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("cda1c7ae-8ce8-455d-ae75-184a99fc565d"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7000), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("61de23a4-4d65-4366-ae23-5ca95173dbf2"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(6997), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("179b3102-45aa-48d5-85e8-342f4b487194"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(6988), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("39134996-6faa-45d7-9941-0b239aa06b60"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(6985), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("fd9ff24b-578a-41ee-b6c6-3a13019ed143"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(6973), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("6d156596-3436-44c7-963b-c92ed1abb567"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(6455), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("7f059a80-fca8-499f-afc5-86ea04de4087"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(7041), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("fc1626a1-bb6d-43ab-8bac-eb424754b3fd"), new DateTime(2020, 6, 8, 13, 6, 40, 975, DateTimeKind.Utc).AddTicks(6991), null, null, false, false, null, "Whiskey", 0, 0 }
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
                    { new Guid("da9a044f-d801-4a24-914d-236138c58127"), "304 BRUNSWICK ST", 0, "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("59aa7bf2-fbb1-497d-b604-075db46e9ccc"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5357), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, 0, 0, null },
                    { new Guid("c593007e-56ee-4e4f-b70c-c49c8dfd6b69"), "Storgata 27 Oslo", 0, "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("9a6fc756-2531-4a87-93a2-4f1aa16376dc"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5326), null, false, null, "Himkok", "+47 22 42 22 02", 0, 0, 0, null },
                    { new Guid("2fdab833-3576-4806-9c09-54a4bc24617f"), "Av. �lvaro Obreg�n 106 Cuauht�moc", 0, "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("282f998d-0005-46a1-8e9e-87896ae34d9b"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5247), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, 0, 0, null },
                    { new Guid("bc6b5c02-9f72-4332-b1cd-1e45ca2b8dab"), "500 Arguello Street Redwood City", 0, "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("4fb62a8a-f96d-4f40-bd82-f72292b18b4f"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5232), null, false, null, "High Five", "(844) 464-4445", 0, 0, 0, null },
                    { new Guid("12d6ef70-7eaf-498a-9c70-f73c5e4ca192"), "52 Rue de Saintonge Paris", 0, "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("c5123312-1d39-4a5a-a78a-c98738bd3c4c"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5309), null, false, null, "Candelaria", "+34 910 00 61", 0, 0, 0, null },
                    { new Guid("d8ae8db0-4b8e-4e08-a459-28fc52728168"), "60 Rue Charlot Paris", 0, "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("c5123312-1d39-4a5a-a78a-c98738bd3c4c"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5102), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, 0, 0, null },
                    { new Guid("bb463e5a-909a-47c3-b720-1e08447bbfb1"), "579 Fuxing Zhong Lu", 0, "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("30aa697e-4686-40ef-a42f-11782e78c1a3"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5088), null, false, null, "Speak Low", "6416 0133", 0, 0, 0, null },
                    { new Guid("66abf3fd-322d-4430-b789-639c8b6363d5"), "Praxitelous 30 Athens", 0, "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("567e03f1-2aae-46db-8250-b3eca0f9a570"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5054), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, 0, 0, null },
                    { new Guid("53c00b8d-18da-4ea6-afb7-19a4b42863ad"), "Paceville Main Staircase St Julian's", 0, "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("5068a265-8110-4893-80c7-1269c096c81d"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5016), null, false, null, "Native", "+356 2138 0635", 0, 0, 0, null },
                    { new Guid("236e21e4-d86f-4109-8b96-51b3a324b0e2"), "Calle Echegaray 21 28014 Madrid", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("227326fa-e7d1-4c5a-9086-f82818906d27"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(4992), null, false, null, "Salmon Guru", "+34 910 00 61", 0, 0, 0, null },
                    { new Guid("ad3b5fa5-8a08-437c-874f-99d52640a5c6"), "37 Aberdeen Street Central", 0, "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("44c9581c-852c-4fcd-88e0-73ac6f3dea9b"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(4979), null, false, null, "The Old Man", "85227031899", 0, 0, 0, null },
                    { new Guid("17a52d90-2e0c-4351-9016-c192666b9882"), "7 Ann Siang Hill", 0, "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("f5cd6a0e-1efe-4a42-8294-e8841aa01a0e"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5369), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, 0, 0, null },
                    { new Guid("7276e2c5-8bcb-412b-a8ea-0ec185a03e0f"), "Parkview Square", 0, "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("f5cd6a0e-1efe-4a42-8294-e8841aa01a0e"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5259), null, false, null, "Atlas", "+65 6396 4466", 0, 0, 0, null },
                    { new Guid("dd4a541f-b157-4047-9aca-1a9ded67e44e"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", 0, "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("696d6ca8-766c-494f-8e3a-cfe8c67fa90b"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(4935), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, 0, 0, null },
                    { new Guid("954eebe7-6c93-4b52-b00a-bc70f049d48e"), "2727 Indian Creek Dr. Miami Beach", 0, "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("0f3eba9a-94d0-475a-964a-7da7c12ed480"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5294), null, false, null, "Broken Shaker", "305-531-2727", 0, 0, 0, null },
                    { new Guid("b0983e63-aced-4865-9de3-55bd829a7c67"), "79-81 MacDougal St New York", 0, "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("0f3eba9a-94d0-475a-964a-7da7c12ed480"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5272), null, false, null, "Dante", "01 55 5264 4122", 0, 0, 0, null },
                    { new Guid("825164c8-15d7-4552-9521-a8cc5ce85706"), "134 Eldridge Street New York", 0, "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("0f3eba9a-94d0-475a-964a-7da7c12ed480"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5064), null, false, null, "Attaboy", "+36 1 792 2222", 0, 0, 0, null },
                    { new Guid("3faf1132-f08d-4dc3-8636-7c0e27d494c4"), "", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("0f3eba9a-94d0-475a-964a-7da7c12ed480"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5040), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, 0, 0, null },
                    { new Guid("d2b10895-02a6-4b25-996d-88c1ffd47c93"), "531 Hudson St New York", 0, "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("0f3eba9a-94d0-475a-964a-7da7c12ed480"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5003), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("eac7866b-f68a-4b92-8249-a710fb4442ac"), "1170 BROADWAY & 28TH STREET NEW YORK", 0, "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("0f3eba9a-94d0-475a-964a-7da7c12ed480"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(4913), null, false, null, "The NoMad", "(347) 472-5660", 0, 0, 0, null },
                    { new Guid("1537e490-dabb-41aa-83b1-9a574edfe5a0"), "Point Square North Dock Dublin", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("4826135b-8cab-463d-9ffa-0d1602a75b43"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5338), null, false, null, "The Gibson", "+353 1 681 5000", 0, 0, 0, null },
                    { new Guid("67335329-4360-487e-a269-780c0ee3f222"), "61�63. Meaden, London", 0, "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("4826135b-8cab-463d-9ffa-0d1602a75b43"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5282), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("9d30bca2-8565-4c85-b91f-1863484ac7f6"), "8-9 Hoxton Square London", 0, "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("4826135b-8cab-463d-9ffa-0d1602a75b43"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5115), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, 0, 0, null },
                    { new Guid("1f985f6b-787a-4dfc-a81d-ad90c82f3cf2"), "Soho, London", 0, "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("4826135b-8cab-463d-9ffa-0d1602a75b43"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5074), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, 0, 0, null },
                    { new Guid("aebee544-7955-44c1-94ed-e549b1d09ade"), "20 Upper Ground South Bank London SE1 9PD", 0, "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("4826135b-8cab-463d-9ffa-0d1602a75b43"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(5029), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("72a47ecd-76d3-42de-bc34-16c36c997384"), "The Connaught Carlos Place Mayfair London", 0, "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("4826135b-8cab-463d-9ffa-0d1602a75b43"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(4962), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("25dc1bfa-8818-42bb-af09-0b61071f5451"), "1 Cuscaden Road 249715", 0, "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("f5cd6a0e-1efe-4a42-8294-e8841aa01a0e"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(4946), null, false, null, "Manhattan", "+65 6725 3377", 0, 0, 0, null },
                    { new Guid("264dcc21-471b-4257-add1-63cd28e23f24"), "The Savoy Strand London WC2R 0EZ", 0, "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("4826135b-8cab-463d-9ffa-0d1602a75b43"), new DateTime(2020, 6, 8, 13, 6, 40, 979, DateTimeKind.Utc).AddTicks(4286), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, 0, 0, null }
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
