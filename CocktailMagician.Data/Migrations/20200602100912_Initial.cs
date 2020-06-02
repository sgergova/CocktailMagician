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
                    { new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), "90d1283a-aaee-4bf7-b1cb-6e126906d299", "Crawler", "CRAWLER" },
                    { new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"), "1d54fd7a-607c-4f75-869b-aa166b63bf69", "Magician", "MEMBER" },
                    { new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"), "43705388-9de0-48b7-a653-29070b894862", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), 0, "380f9f4e-66ac-4048-8793-e2ba0e7e8c2f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "crawler@abv.bg", false, false, false, null, null, "crawler@abv.bg", "CRAWLER@ABV.BG", "AQAAAAEAACcQAAAAEA3ysm2jG0lmy0F1u7AD6tpHc0IbElF8pkGYjP1zdi36rBuEXhnZ9ASz4kTkDq/wkw==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "CRAWLER@ABV.BG", null },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), 0, "c07d237c-56c5-4459-bac7-73304b5afeef", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@abv.bg", false, false, false, null, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEDQH57bEP7lElssbzamBmymBlAJth/XZV1H/JyiGhGrElUX0U/y5BQ4mcaeMVHfVdA==", null, false, "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU", false, "admin@abv.bg", null },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), 0, "95604fb3-2f7a-4910-a5fd-8bc2f78852a7", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "magician@abv.bg", false, false, false, null, null, "magician@abv.bg", "MAGICIAN@ABV.BG", "AQAAAAEAACcQAAAAENneszuObdah8WO7sLERUBODEjAfATdclzGIew08bzrQcXpGo8OQouvaSeaDTali6A==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "MAGICIAN@ABV.BG", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("92a4c3c7-c499-43c2-bdec-b062b592a42b"), 4.2000000000000002, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6636), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("70945f52-2334-4af5-8fec-9a88ff82bf8f"), 4.5, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6674), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("e13ab61c-067a-466b-8948-f7f516bcccbc"), 7.2999999999999998, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6702), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("de278d80-1a4e-473f-a2f9-1a989f28ece8"), 7.2000000000000002, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6729), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("25828379-2861-4390-b9d2-817de8802264"), 16.0, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6808), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("4263a662-43a7-40e2-af53-c8c2c4140f96"), 12.699999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6782), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("cebb5a44-845f-4de4-be03-9ae46efa6f3a"), 4.0999999999999996, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6579), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("ba4430c5-fcff-4a35-b6ae-e28f0573939f"), 12.699999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6851), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("669f27a6-fbc9-4ce6-9754-a4a486a0af69"), 2.5, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6900), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("7bf8e482-2391-4788-bf3c-9bc1229a4579"), 7.4000000000000004, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6757), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("ab15cc3a-922b-44ef-b186-dc3151f0b66d"), 3.8999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6505), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("13a4106f-4b81-4b20-b6df-2db6ccdc42b2"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(4447), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("2aeebac1-10cd-4d74-8750-a55d4bb4199c"), 3.7999999999999998, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6447), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("e889e7a4-81df-4672-85d8-21d9f954402b"), 3.7999999999999998, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6471), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("1aee6437-07ce-426b-a7ec-35064a3de9c0"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6019), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("ae7683a5-5156-4629-9db1-2306c732b6ae"), 3.5, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(5994), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("ab1c510d-201a-4aef-b72b-f62dd2c85541"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(5966), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("c9930d1a-4fc5-44ad-bf5e-9ae0288907ad"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(5877), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("bc0ae567-d03f-4dab-879d-c1da00b98749"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6109), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("68b7f54f-80db-4971-b3ad-55ad1f8131c5"), 16.0, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6084), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("f9b5b0c9-085c-4cad-975c-8b067234f9ce"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6217), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("2ca1e393-2991-48e2-9651-f40445fbeb6c"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6286), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("65b7641b-58a7-4936-a884-b322b9ea15b9"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6336), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("26e12457-7e0f-41f2-aa4c-99fb9ed71698"), 3.5, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6364), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("db8d68e1-ab43-404c-8f73-2ceb53885cd0"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6389), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("61f4ed22-aa70-46fc-affb-d30b127bc1b1"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6415), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("5b3ad3ca-fb71-46d9-b2b8-f9cc03fd9db4"), 3.3999999999999999, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6173), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("071200ec-248f-4b84-a7d8-46705357095b"), 3.5, new DateTime(2020, 6, 2, 10, 9, 10, 928, DateTimeKind.Utc).AddTicks(6056), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("767e624a-39bb-41a0-b8b1-073b84b3898c"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6950), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("4b706943-1990-4a65-84c8-4e0aa5e98159"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6962), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("6e7f715e-b125-43c1-9bc8-0cd12133b939"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6958), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("d863d2c7-6e7b-42e1-ac9b-b0608df4dd17"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6954), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("82113657-35b2-4cea-bc1e-8d1c6dfb46a2"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6947), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("b57c06f4-b52e-4cab-81c3-76b82863809e"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6936), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("3629d4d1-cc0e-4f3b-b8d0-8671c1e0807b"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6931), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("0f5c000c-803e-4574-8e2e-a90116c1fbd0"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6913), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("e1a14726-8079-45d3-91df-f74d74b187b3"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(5874), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("3f3ef73f-bad6-4acf-a880-366b91e34ff8"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6854), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("0868b356-3bdc-4bcc-a1da-bda6fc74a642"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6871), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("de599ce4-cccf-4cff-99ec-26ec18fe6ea0"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("f3d5b2fa-c787-408a-9ace-f65ec7b344a5"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6879), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("319027e9-f9c8-4b72-8045-9a1747e6d322"), new DateTime(2020, 6, 2, 10, 9, 10, 929, DateTimeKind.Utc).AddTicks(6940), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("046de991-bc8f-4cb0-892e-592b707f196d"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3382), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("eb5c4eb2-bc4a-4977-aca6-bad4fe8ac2b6"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3385), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("04228896-19da-42a4-9c63-9146de20d232"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3389), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("de415bf9-a173-45c9-b127-eb949d3c2fce"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3392), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("0029134d-b7c1-4aca-9183-13c5896ff229"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3414), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("f72aac33-44d9-417f-b3e9-669f1682ae08"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3403), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("5e3697d6-0aa3-4b6b-9128-68d3aa7224cd"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3407), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("b56f1f4c-c83e-4de8-9648-f898792a25a6"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3411), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("00003a2f-9523-4fe4-9982-e21a1416af20"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3417), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("a612a417-7f18-48b4-85ed-f4b8163563f0"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3400), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("35015229-2349-4dfb-b632-016da76332f9"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3378), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("f2b104eb-d5ec-486d-852f-155fc4eba40e"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3368), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("d2935f64-cd93-4aea-9fd0-8a29744e70bb"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3365), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("4015d42c-e59e-4369-94a3-c01c97092449"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3355), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("080be858-f3cd-46a1-880e-90e8eb842f96"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3337), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("f03cbe09-9ef9-4bf3-a21b-fa4330b35598"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3334), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("c73f1c6e-28a1-4693-8d77-b421cc765865"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3330), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("f7192fb9-f75c-4550-a7d9-cc56debd8de2"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3326), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("387e75ff-41b3-481a-92f7-bfae8e16be06"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3320), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("65d9ac96-bd64-45ad-989d-9ab8e3823712"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3316), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("f1c1a2b9-9e99-417e-92e1-c4b20000e463"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3312), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("8d1d74c6-0a23-4879-a6ec-07eccc25020f"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3288), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("7fc6f3ae-5f7e-4d23-b643-199f6a9d1859"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3276), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("2f1e7bc6-3d27-4e8a-bbb7-aa1fed512ebe"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3272), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("1ed82320-6b6e-44ad-b40a-8fa5ecbda7d1"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3257), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("a41700c9-754a-48d7-8626-5a987626a10a"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(2341), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("27f450ac-4d37-4cbb-842f-6b20cf890165"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3372), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("bd42e801-6222-4680-95af-38b147b69842"), new DateTime(2020, 6, 2, 10, 9, 10, 925, DateTimeKind.Utc).AddTicks(3280), null, null, false, false, null, "Whiskey", 0, 0 }
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
                    { new Guid("9134fe5f-99a3-429c-bf92-af57051bdfc2"), "304 BRUNSWICK ST", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("4b706943-1990-4a65-84c8-4e0aa5e98159"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8765), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, null },
                    { new Guid("ed39d39b-c9fb-4551-8518-d8bc33640989"), "Storgata 27 Oslo", "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("6e7f715e-b125-43c1-9bc8-0cd12133b939"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8717), null, false, null, "Himkok", "+47 22 42 22 02", 0, null },
                    { new Guid("e065caa9-1f26-4e23-b473-7e13ece79584"), "Av. �lvaro Obreg�n 106 Cuauht�moc", "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("d863d2c7-6e7b-42e1-ac9b-b0608df4dd17"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8581), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, null },
                    { new Guid("c6bf9f49-d000-4ccd-9cd4-e2b94121c7d8"), "500 Arguello Street Redwood City", "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("767e624a-39bb-41a0-b8b1-073b84b3898c"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8554), null, false, null, "High Five", "(844) 464-4445", 0, null },
                    { new Guid("af05b3be-64cd-4ecb-bb9e-c7a4880037fa"), "52 Rue de Saintonge Paris", "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("82113657-35b2-4cea-bc1e-8d1c6dfb46a2"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8684), null, false, null, "Candelaria", "+34 910 00 61", 0, null },
                    { new Guid("12852b95-4684-4c6a-b98f-1d592bcad779"), "60 Rue Charlot Paris", "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("82113657-35b2-4cea-bc1e-8d1c6dfb46a2"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8501), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, null },
                    { new Guid("99529729-dfe6-42c7-bc14-55821fb839e5"), "579 Fuxing Zhong Lu", "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("319027e9-f9c8-4b72-8045-9a1747e6d322"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8478), null, false, null, "Speak Low", "6416 0133", 0, null },
                    { new Guid("db551b2b-5c91-477e-b53b-d19eaae2409d"), "Praxitelous 30 Athens", "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("b57c06f4-b52e-4cab-81c3-76b82863809e"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8403), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, null },
                    { new Guid("a8f0f45f-b6e1-4974-9281-e3bd51636d92"), "Paceville Main Staircase St Julian's", "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("3629d4d1-cc0e-4f3b-b8d0-8671c1e0807b"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8337), null, false, null, "Native", "+356 2138 0635", 0, null },
                    { new Guid("a2a42bdd-68f1-44ae-9d36-3d23cfac566e"), "Calle Echegaray 21 28014 Madrid", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("0f5c000c-803e-4574-8e2e-a90116c1fbd0"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8285), null, false, null, "Salmon Guru", "+34 910 00 61", 0, null },
                    { new Guid("9d4ba1a7-f746-4db1-bfce-c9d89fcfa537"), "37 Aberdeen Street Central", "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("f3d5b2fa-c787-408a-9ace-f65ec7b344a5"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8259), null, false, null, "The Old Man", "85227031899", 0, null },
                    { new Guid("0d08ea5b-8a75-4218-93db-0c19e1450868"), "7 Ann Siang Hill", "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("de599ce4-cccf-4cff-99ec-26ec18fe6ea0"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8787), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, null },
                    { new Guid("ba23039b-8b9a-4110-8a5e-5de116fe5e25"), "Parkview Square", "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("de599ce4-cccf-4cff-99ec-26ec18fe6ea0"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8601), null, false, null, "Atlas", "+65 6396 4466", 0, null },
                    { new Guid("1fb6fe3c-4c09-45fc-ae9e-de3663ec77a8"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("0868b356-3bdc-4bcc-a1da-bda6fc74a642"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8195), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, null },
                    { new Guid("36ccc5ad-7803-467a-8852-0ff447c2ddb6"), "2727 Indian Creek Dr. Miami Beach", "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("3f3ef73f-bad6-4acf-a880-366b91e34ff8"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8660), null, false, null, "Broken Shaker", "305-531-2727", 0, null },
                    { new Guid("fa7f3784-9467-4d22-928e-09f0a955ec90"), "79-81 MacDougal St New York", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("3f3ef73f-bad6-4acf-a880-366b91e34ff8"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8621), null, false, null, "Dante", "01 55 5264 4122", 0, null },
                    { new Guid("7ee714dc-ea36-439f-a51f-0c440a512382"), "134 Eldridge Street New York", "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("3f3ef73f-bad6-4acf-a880-366b91e34ff8"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8438), null, false, null, "Attaboy", "+36 1 792 2222", 0, null },
                    { new Guid("c5fc684e-7f9a-4b6b-bf7a-a0e17d211e78"), "", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("3f3ef73f-bad6-4acf-a880-366b91e34ff8"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8379), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("ad4d5a27-2b76-4d55-bace-c0e1d2953ccd"), "531 Hudson St New York", "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("3f3ef73f-bad6-4acf-a880-366b91e34ff8"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8303), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("2f56118a-2dea-4e60-ba5d-00eca10b24e2"), "1170 BROADWAY & 28TH STREET NEW YORK", "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("3f3ef73f-bad6-4acf-a880-366b91e34ff8"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8150), null, false, null, "The NoMad", "(347) 472-5660", 0, null },
                    { new Guid("055ff528-0491-4bb7-a452-714f4fc01cf3"), "Point Square North Dock Dublin", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("e1a14726-8079-45d3-91df-f74d74b187b3"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8734), null, false, null, "The Gibson", "+353 1 681 5000", 0, null },
                    { new Guid("090417db-c8f0-4801-9638-d7b471ad1c92"), "61�63. Meaden, London", "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("e1a14726-8079-45d3-91df-f74d74b187b3"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8641), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("b69474be-9179-47cc-b480-3d75667eda02"), "8-9 Hoxton Square London", "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("e1a14726-8079-45d3-91df-f74d74b187b3"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8525), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, null },
                    { new Guid("899c2c70-f5d4-4b28-9c58-667a34ab8767"), "Soho, London", "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("e1a14726-8079-45d3-91df-f74d74b187b3"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8454), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, null },
                    { new Guid("a31cca53-c3de-433e-a3da-a793c4895e2d"), "20 Upper Ground South Bank London SE1 9PD", "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("e1a14726-8079-45d3-91df-f74d74b187b3"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8362), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("afc6d89b-e32e-4886-b435-028356563d05"), "The Connaught Carlos Place Mayfair London", "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("e1a14726-8079-45d3-91df-f74d74b187b3"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8232), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("17e03795-e88c-4a59-b3f0-7f46d3e40bf4"), "1 Cuscaden Road 249715", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("de599ce4-cccf-4cff-99ec-26ec18fe6ea0"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(8215), null, false, null, "Manhattan", "+65 6725 3377", 0, null },
                    { new Guid("eecd02ee-ba09-40d8-80ae-a6b248ea851a"), "The Savoy Strand London WC2R 0EZ", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("e1a14726-8079-45d3-91df-f74d74b187b3"), new DateTime(2020, 6, 2, 10, 9, 10, 931, DateTimeKind.Utc).AddTicks(7075), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, null }
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
