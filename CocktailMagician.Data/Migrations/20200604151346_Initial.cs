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
                    { new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), "157b009a-6453-4192-a1c6-00756023ee0a", "Crawler", "CRAWLER" },
                    { new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"), "0d786dea-2971-45dd-aa02-fdea7a821705", "Magician", "MEMBER" },
                    { new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"), "547ee81c-87ce-47c3-bdd3-496539849ba1", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), 0, "c72ef7e9-ee18-4144-a254-99d97329ec6b", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "crawler@abv.bg", false, false, false, null, null, "crawler@abv.bg", "CRAWLER@ABV.BG", "AQAAAAEAACcQAAAAEB7n08Y71WKmsf7YBPGkpWHEZ1ObvsaHpMy97cAhKTrTpWOFvTuxrsxDX6pg5W+yZQ==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "CRAWLER@ABV.BG", null },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), 0, "6d869a00-23e5-45ef-b250-02e224d280c0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@abv.bg", false, false, false, null, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEHYccdndSa+mSeAGpIVLJRGXNlLyhyh9F6ZoT8vT71/lIpYCI26j6IootSUCyqIy4A==", null, false, "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU", false, "admin@abv.bg", null },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), 0, "c49e44e5-8035-4897-9bb1-8f9d647222aa", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "magician@abv.bg", false, false, false, null, null, "magician@abv.bg", "MAGICIAN@ABV.BG", "AQAAAAEAACcQAAAAEDkY8FPFOC3NWaZE7T2jThDu3xjAIgmuQrk5Jt9EDxDtMmnzHp5u4rn2FkDQHHuZGA==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "MAGICIAN@ABV.BG", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("7df44e43-e34b-4586-b372-d4ee663fb932"), 4.2000000000000002, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7624), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("9287d34b-5a82-4e39-9c9c-0eedf612c4c3"), 4.5, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7638), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("8199d20f-6471-4193-b295-22474fe7767c"), 7.2999999999999998, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7652), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("5a42d478-b16a-4bba-804e-9c8e7772c777"), 7.2000000000000002, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7666), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("65c75483-40b2-4824-9146-aa77b407c23e"), 16.0, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7711), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("75ce22b0-9d40-49f8-95c2-452a29c3978a"), 12.699999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7695), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("4d671d7b-3bfd-4eb6-ae6d-92c5ecb6e0df"), 4.0999999999999996, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7609), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("1cffe84d-c1bf-4745-a16e-1843d8c956db"), 12.699999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7730), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("a174e709-a551-453a-8a32-57281fa7dda9"), 2.5, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7762), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("959b3b2a-0c4a-428c-9c93-684f62db6407"), 7.4000000000000004, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7679), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("697f5a4f-3750-4fa1-a244-b5314958e248"), 3.8999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7591), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("b0e0a249-f4c1-4e2b-8bbc-60299fc0c62f"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(6379), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("4143576d-7edf-42bd-ad90-d9a3c3404034"), 3.7999999999999998, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7557), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("d3376e3b-aef7-4ba7-ad55-808df9fafed7"), 3.7999999999999998, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7572), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("6337db6b-76fd-4a93-b2ee-5b748b44f820"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7269), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("d69a3521-2f3d-4994-8383-fe7215a9cc25"), 3.5, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7253), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("52bb52bc-1ae9-45df-8d9a-9c2f5595debe"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7235), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("a0c2e4ce-53bd-4748-80d2-af68fb1760ee"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7174), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("927665f3-3df5-44a3-8fe0-c4a24183f1f8"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7387), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("e783b889-a17d-4cb5-9f91-717740866a56"), 16.0, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7328), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("add4c64a-c166-4da9-8f8b-8e80d3ba0567"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7458), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("d0e854a0-abcb-4790-b65a-f134aa0279e9"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7484), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("f91d769b-9e27-417b-b319-826438819a2d"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7499), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("be1ef7fe-061d-4af8-8d3d-9feec983fd59"), 3.5, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7514), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("b7d922f1-8c85-4938-930c-10641e54296b"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7528), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("afdaf39a-1caf-475d-9c00-bbdcee11b842"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7542), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("d2a261d6-3e3f-471d-af78-6504bf1f11b3"), 3.3999999999999999, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7415), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("a85e9e4b-fae6-467d-ad56-579134a4aa82"), 3.5, new DateTime(2020, 6, 4, 15, 13, 44, 849, DateTimeKind.Utc).AddTicks(7292), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("f4ebe7ed-56f1-4cdc-9d28-030ab34470e3"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5447), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("2ad0face-d859-49c4-9061-2d21db01994f"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5459), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("240dbb71-be9a-4776-a058-765b10af358d"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5455), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("269c4119-bd6a-4245-a336-71e5d7e0cbd1"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5451), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("9f374d4f-8bc5-4c86-b84c-1cd8dd4d350b"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5443), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("39ad8010-bd30-465f-bf0e-b952a5faa06a"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5434), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("4ea292b5-57af-436c-89e4-1677b93e45cb"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5429), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("add52282-4c1a-4a6a-a36e-d2eb4414704f"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5415), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("9b5f7777-2914-4ff3-8529-94ed62caa723"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(4718), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("fdc3a4ea-d518-4919-8402-22186a774220"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5378), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("14562ffd-94fa-4761-b76f-840f333fd7b7"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5399), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("b3c210e8-13c1-4076-94c7-2518413e66a2"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5403), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("c2842c3c-44fe-499d-b047-fe93305cf169"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5407), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("c5d3ceb6-1bab-4c9f-b627-c9db0630240d"), new DateTime(2020, 6, 4, 15, 13, 44, 850, DateTimeKind.Utc).AddTicks(5437), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("f1670d66-aa66-4590-b45e-48b845c19f2d"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6404), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("0600d70b-9c59-40c4-9857-4ed59bc78cf4"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6408), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("041c1824-39bf-4abb-b10e-d4a840ed21d1"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6411), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("ff5c0d08-3ce1-4cdd-94bf-b2543e109ab6"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6415), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("a04f5ebd-0b5f-4905-8300-553fd4f98a7e"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6438), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("5f457965-fc39-4150-b2b4-684e1d021924"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6427), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("56a7d7c5-c3ad-447c-a4c1-f1cb1bb2fc81"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6430), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("a0de5ab7-627a-4a62-b26a-c0110da3c70d"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6434), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("add46ac6-fc3d-4ef1-9630-3bacc7bec24e"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6441), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("7a8a3381-572c-48c9-96c7-55ca00f407e3"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6423), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("5b0de642-0280-4def-a46b-e771082c2bc8"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6400), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("86517447-9819-48c5-a59c-5cc39cb0bbe0"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6391), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("c8d34126-7813-4b80-8e53-c5be81200e24"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6387), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("ca22d769-e539-44a1-9271-97fe3b5f16ea"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6379), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("21e94d82-7422-4a8a-8c31-29c88d3d4412"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6375), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("260e28c8-54bf-44f3-9315-6c8733062045"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6371), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("3319ca71-9603-4078-8285-a2f962b6ec18"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6368), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("e5db2f44-40a1-4fce-a068-6c21a33e93b2"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6364), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("ee416424-6209-4994-89a1-7562f3f55f23"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6358), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("b92c4cc7-ea95-49f1-a004-3b0fe2a9af6b"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6354), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("e64710d7-c54f-4826-bd93-72362282d36d"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6350), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("dca49ecd-82ae-4d01-a9be-d91855ef36bc"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6325), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("06b2ac9b-5a9a-4c5e-b4fa-e7d239851823"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6312), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("bbbf1ae1-e4d3-47db-bb96-9331ed7e7b78"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6307), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("cfd7c20d-81b2-457c-9a24-361d43605d8c"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6288), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("947ed9d4-664a-4d4b-a9ba-53c645ba5480"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(5590), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("d63e5ff7-8ce0-4aaf-a1a6-610a291570c1"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6395), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("43b52e1d-1c99-412c-b314-86f591219788"), new DateTime(2020, 6, 4, 15, 13, 44, 846, DateTimeKind.Utc).AddTicks(6316), null, null, false, false, null, "Whiskey", 0, 0 }
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
                    { new Guid("70335403-a9c3-41e7-990d-8b16ac9715e4"), "304 BRUNSWICK ST", 0, "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("2ad0face-d859-49c4-9061-2d21db01994f"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8825), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, 0, 0, null },
                    { new Guid("21a90954-3f53-4f7a-98cc-dc230b0ff341"), "Storgata 27 Oslo", 0, "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("240dbb71-be9a-4776-a058-765b10af358d"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8710), null, false, null, "Himkok", "+47 22 42 22 02", 0, 0, 0, null },
                    { new Guid("c0cb2365-8979-468d-a502-b76e9d6cd969"), "Av. �lvaro Obreg�n 106 Cuauht�moc", 0, "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("269c4119-bd6a-4245-a336-71e5d7e0cbd1"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8399), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, 0, 0, null },
                    { new Guid("eb1c02d7-bee6-4e36-a626-ecbcf0cfe1eb"), "500 Arguello Street Redwood City", 0, "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("f4ebe7ed-56f1-4cdc-9d28-030ab34470e3"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8341), null, false, null, "High Five", "(844) 464-4445", 0, 0, 0, null },
                    { new Guid("5103799c-597c-4a3f-a98c-5e7e64c5aa36"), "52 Rue de Saintonge Paris", 0, "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("9f374d4f-8bc5-4c86-b84c-1cd8dd4d350b"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8619), null, false, null, "Candelaria", "+34 910 00 61", 0, 0, 0, null },
                    { new Guid("d1c4b0b7-a0b3-4491-8004-b4be2140f0c8"), "60 Rue Charlot Paris", 0, "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("9f374d4f-8bc5-4c86-b84c-1cd8dd4d350b"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8221), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, 0, 0, null },
                    { new Guid("934f958b-94a4-458d-8421-2811cc485358"), "579 Fuxing Zhong Lu", 0, "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("c5d3ceb6-1bab-4c9f-b627-c9db0630240d"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8166), null, false, null, "Speak Low", "6416 0133", 0, 0, 0, null },
                    { new Guid("a898baf0-1ddb-4cf0-8ddc-071acb97d9eb"), "Praxitelous 30 Athens", 0, "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("39ad8010-bd30-465f-bf0e-b952a5faa06a"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8032), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, 0, 0, null },
                    { new Guid("079a4808-97e3-4fe5-889d-d1060e993ea3"), "Paceville Main Staircase St Julian's", 0, "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("4ea292b5-57af-436c-89e4-1677b93e45cb"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7889), null, false, null, "Native", "+356 2138 0635", 0, 0, 0, null },
                    { new Guid("a693b421-76cb-4556-aa93-b5a5cb7623f3"), "Calle Echegaray 21 28014 Madrid", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("add52282-4c1a-4a6a-a36e-d2eb4414704f"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7781), null, false, null, "Salmon Guru", "+34 910 00 61", 0, 0, 0, null },
                    { new Guid("bd644f24-8c8f-436c-80ce-aa261e03521d"), "37 Aberdeen Street Central", 0, "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("c2842c3c-44fe-499d-b047-fe93305cf169"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7698), null, false, null, "The Old Man", "85227031899", 0, 0, 0, null },
                    { new Guid("3d7185e1-9788-4f5f-a2fb-58a981385691"), "7 Ann Siang Hill", 0, "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("b3c210e8-13c1-4076-94c7-2518413e66a2"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8866), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, 0, 0, null },
                    { new Guid("2fbc92aa-20bd-4b6a-a6b2-fe049b17c6ed"), "Parkview Square", 0, "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("b3c210e8-13c1-4076-94c7-2518413e66a2"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8446), null, false, null, "Atlas", "+65 6396 4466", 0, 0, 0, null },
                    { new Guid("430e97ab-a379-4c4f-90a7-84b8f673e450"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", 0, "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("14562ffd-94fa-4761-b76f-840f333fd7b7"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7555), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, 0, 0, null },
                    { new Guid("461f4818-eb22-45f9-a073-ef7ca8f68807"), "2727 Indian Creek Dr. Miami Beach", 0, "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("fdc3a4ea-d518-4919-8402-22186a774220"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8567), null, false, null, "Broken Shaker", "305-531-2727", 0, 0, 0, null },
                    { new Guid("7b66f0d0-aea7-4401-8db5-21a14dab699f"), "79-81 MacDougal St New York", 0, "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("fdc3a4ea-d518-4919-8402-22186a774220"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8486), null, false, null, "Dante", "01 55 5264 4122", 0, 0, 0, null },
                    { new Guid("48854c34-a8f4-47bf-a252-4c3a9c852585"), "134 Eldridge Street New York", 0, "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("fdc3a4ea-d518-4919-8402-22186a774220"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8072), null, false, null, "Attaboy", "+36 1 792 2222", 0, 0, 0, null },
                    { new Guid("aae03569-daad-49e2-bd9e-62f90dc58b7d"), "", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("fdc3a4ea-d518-4919-8402-22186a774220"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7985), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, 0, 0, null },
                    { new Guid("2481c582-3edd-435f-9ab7-3f8ef3608c95"), "531 Hudson St New York", 0, "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("fdc3a4ea-d518-4919-8402-22186a774220"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7823), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("1a144650-11f0-4d34-81fe-773cf5343387"), "1170 BROADWAY & 28TH STREET NEW YORK", 0, "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("fdc3a4ea-d518-4919-8402-22186a774220"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7472), null, false, null, "The NoMad", "(347) 472-5660", 0, 0, 0, null },
                    { new Guid("f4a937f5-ece2-4739-809b-550103292172"), "Point Square North Dock Dublin", 0, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("9b5f7777-2914-4ff3-8529-94ed62caa723"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8753), null, false, null, "The Gibson", "+353 1 681 5000", 0, 0, 0, null },
                    { new Guid("4a4d5593-05ab-4051-a150-ac47bd8acfef"), "61�63. Meaden, London", 0, "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("9b5f7777-2914-4ff3-8529-94ed62caa723"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8526), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("3c181bf3-cb4c-4d6c-bef7-3fe3d7faba79"), "8-9 Hoxton Square London", 0, "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("9b5f7777-2914-4ff3-8529-94ed62caa723"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8273), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, 0, 0, null },
                    { new Guid("5d3ecc02-3f3f-4a0a-86e5-c25a38a865de"), "Soho, London", 0, "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("9b5f7777-2914-4ff3-8529-94ed62caa723"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(8109), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, 0, 0, null },
                    { new Guid("6f63ed06-23dd-4242-913a-c06b7d32e070"), "20 Upper Ground South Bank London SE1 9PD", 0, "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("9b5f7777-2914-4ff3-8529-94ed62caa723"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7936), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("a084732a-fe06-4394-9fdc-767237a12f67"), "The Connaught Carlos Place Mayfair London", 0, "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("9b5f7777-2914-4ff3-8529-94ed62caa723"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7638), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, 0, 0, null },
                    { new Guid("60c9912e-db6f-4074-a540-fea54f92f405"), "1 Cuscaden Road 249715", 0, "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("b3c210e8-13c1-4076-94c7-2518413e66a2"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(7598), null, false, null, "Manhattan", "+65 6725 3377", 0, 0, 0, null },
                    { new Guid("8a187555-18d3-4fe2-802d-716678048a89"), "The Savoy Strand London WC2R 0EZ", 0, "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("9b5f7777-2914-4ff3-8529-94ed62caa723"), new DateTime(2020, 6, 4, 15, 13, 44, 852, DateTimeKind.Utc).AddTicks(6190), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, 0, 0, null }
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
