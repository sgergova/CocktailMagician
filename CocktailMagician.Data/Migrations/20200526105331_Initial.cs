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
                name: "UserPhotos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserCover = table.Column<byte[]>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPhotos_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "CocktailStars",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    CocktailId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Vote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailStars", x => new { x.CocktailId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CocktailStars_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktailStars_AspNetUsers_UserId",
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
                name: "BarStars",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    BarId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: false),
                    Vote = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarStars", x => new { x.BarId, x.UserId });
                    table.ForeignKey(
                        name: "FK_BarStars_Bars_BarId",
                        column: x => x.BarId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarStars_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("3ad2539a-6324-4c53-ac8e-646cc7bf9546"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1013), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("261777f0-eecb-48d8-b589-eedb099a5bbf"), 16.0, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1886), null, "", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("78c5ab39-17cb-4c8d-a2cf-79448f96297a"), 12.699999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1879), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("1033e3d1-3c00-488b-b702-6f758184a02f"), 16.0, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1868), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("cac754b8-79c7-4260-8876-08fde3f4271c"), 12.699999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1828), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("9bdd8c29-f376-4ae2-a5fc-62c008f34bf1"), 7.4000000000000004, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1821), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("72941297-c098-4e9c-952f-d9ba20c29605"), 7.2000000000000002, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1815), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("3b428790-b2d9-4c93-8639-fa8315f96c86"), 7.2999999999999998, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1808), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("f9ea85dd-0756-471a-9b9c-49a4da7c8540"), 4.5, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1801), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("7a678521-f662-49d4-aa5d-f740080c0a73"), 4.2000000000000002, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1794), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("ce7d249c-0aa0-4716-8cd8-f5220200c7b7"), 4.0999999999999996, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1787), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("933b97a0-8c11-4433-aca6-3d1cd22839b7"), 3.7999999999999998, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1767), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("4b1d2709-4721-4efd-8477-6187f6649b04"), 3.7999999999999998, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1759), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("888b4912-a392-4ca7-907a-47f8cd333b83"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1752), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("616005f7-82b1-4493-a96f-d16ff251ffd6"), 3.8999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1776), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("c00a3a15-0770-4c75-ace7-1d1bf5abed89"), 3.5, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1739), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("43da6832-212a-498d-a59f-1df4839004a2"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1626), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("74ee437b-98c3-4714-a5b4-dcb4f14b1ed2"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1653), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("6e6c7e78-69e5-4007-917c-3cbd14cd412c"), 3.5, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1662), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("0e6e473c-f96b-428e-ba03-b899d7724cb4"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1745), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("44fc9d17-ba91-48a5-b5b8-e29f7161b060"), 3.5, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1679), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null },
                    { new Guid("24d462d2-3a4d-4e05-a090-1946c0a9c0bb"), 16.0, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1688), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("7af7add8-1252-4235-a6b0-ab54cbfb91c5"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1669), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("69f95d43-bca4-45e0-bea7-670208d86e83"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1705), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("3a0eff67-9574-4c7a-b412-80ff338feff7"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1713), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("e22ba595-656f-4342-962c-ed6f6fae7386"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1724), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("b5bc1c12-205a-48ec-8832-99e0f3827e1d"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1732), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("9e96d72c-2c93-481d-9dc6-a44d9ddfab4e"), 3.3999999999999999, new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(1697), null, "https://www.wickiwackiwoo.com/barracuda-cocktail-recipe/", false, false, null, "Barracuda", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("74d6e14c-ecfe-4125-91d1-0a1ddc0c3fe9"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7496), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" },
                    { new Guid("401a769f-7f8e-4f89-8008-71d27c1c2584"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7514), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("f26a722f-c5e5-4204-806b-4bf03dce219c"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7511), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("f8d7cd87-fa11-4a63-b631-ba6e65ef20d6"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7508), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico City" },
                    { new Guid("86f253e7-d84f-44bd-b565-cf70250d9849"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7504), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("20b4baa1-b931-4ca3-815e-2e925c254f96"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7501), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("6429072f-beba-4fa1-91ed-dc51cb01b4b6"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7493), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("5e08eb5f-b4fd-4527-b69a-a163bd95ca5d"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7490), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("1716c96b-6635-4aa4-9d8d-3a9296f73772"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7480), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("f4197526-50dd-4906-8df1-6a215a79864f"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7475), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("fb2e20b2-ab38-4fea-b9fb-2a1bbfd9fe61"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7472), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("ea45f20f-f653-4318-8f5b-0c365c47f03a"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7468), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("0a35f397-98e7-46bd-bfa9-7918a83289c7"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(7454), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("0154eadb-9ce4-405a-aa3f-76934bc31b39"), new DateTime(2020, 5, 26, 5, 41, 19, 17, DateTimeKind.Utc).AddTicks(6894), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("506354b3-dee8-48d7-8ae1-bade984dbe7b"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1327), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("fd20302e-6791-4680-a28f-f63e750c810d"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1330), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("e809e6a6-0481-46cd-9f6c-569cd623aa65"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1334), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("318ca90f-4b49-45a7-8fb8-6ec0dcac35cc"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1337), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("2f3cb341-b3e7-41b6-b39b-9fa2f3340175"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1340), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("1c266135-3ca0-4cc3-a1cc-6e4ffee51d51"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1352), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("f65137f0-39f4-4a02-9271-a150421cea85"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1347), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("b498f89c-f90d-4c63-ad86-08f80c38bb10"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1323), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("f4c300b4-0847-43f3-947b-1523dc3ca2fe"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1355), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("06a0747e-6dab-4ba5-8bfa-3bc8ec95de23"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1359), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("6bab563d-a189-4aa9-b552-92e9eb15baf1"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1362), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("767e9892-21dc-4c23-b8ae-a7f3ac45c21b"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1344), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("d451b46a-5173-46bc-856b-307758dd6d52"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1318), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("f11fb001-2a57-4bf0-a346-caa4fad7099a"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1308), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("c0179736-6540-4742-a71d-3a0daa2d969e"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1311), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("14d9ca18-68d3-4fd2-984e-4dcbe85fe157"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1365), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("609d3e84-bbcf-4823-980e-66453feb8ed2"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1305), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("2f141266-bbd2-460c-bcbb-c389634bab05"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1300), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("4fdc63d0-da59-4233-b81f-4160ff65ed1e"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1297), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("17aa3dc4-3df9-4ac5-aef0-bb1c4ac3ba73"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1293), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("b65a8b90-72ad-4a32-bb08-8d55a6957d2d"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1279), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("b594939d-7dc5-4c71-91d4-4249ac553bfc"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1274), null, null, false, false, null, "Whiskey", 0, 0 },
                    { new Guid("f661d1d4-eb82-4c58-8df2-6dc0931881d8"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1270), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("67af6c7f-7f60-40d6-b71c-5f9ead9696fe"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1267), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("32198ff2-5058-458a-af02-c602440877f7"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1256), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("3740979d-0d6c-4652-b4fd-81bc9b116132"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(676), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("0056bf57-ec5d-42a0-802a-c6817db02ab9"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1315), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("9027c71a-5a82-43cb-b0dd-d2473ac7ab2e"), new DateTime(2020, 5, 26, 5, 41, 19, 15, DateTimeKind.Utc).AddTicks(1368), null, null, false, false, null, "Grapefruit juice", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "BarImageURL", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Phone", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("7a1f0f57-d1b2-4c8a-8fd2-380ebec30c2d"), null, "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("0154eadb-9ce4-405a-aa3f-76934bc31b39"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(8489), null, false, null, "American Bar", null, 0, null },
                    { new Guid("adb665bb-ccd0-40a1-99dc-fc461addadb0"), null, "https://www.perdiem.world/wp-content/uploads/2017/07/20140120_EA_09_0086.jpg", new Guid("f8d7cd87-fa11-4a63-b631-ba6e65ef20d6"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9422), null, false, null, "Licorer�a Limantour", null, 0, null },
                    { new Guid("e1ccddfc-dcde-417b-aaae-6775174d21e5"), null, "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("86f253e7-d84f-44bd-b565-cf70250d9849"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9408), null, false, null, "High Five", null, 0, null },
                    { new Guid("7bf8b462-0a6c-4c36-8329-0518b7293066"), null, "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("20b4baa1-b931-4ca3-815e-2e925c254f96"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9472), null, false, null, "Candelaria", null, 0, null },
                    { new Guid("e56b3e64-0cfe-4947-9af2-c9ef0c7be7df"), null, "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("20b4baa1-b931-4ca3-815e-2e925c254f96"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9381), null, false, null, "Little Red Door", null, 0, null },
                    { new Guid("6777dd48-a551-44d0-845f-49a4cb723713"), null, "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("74d6e14c-ecfe-4125-91d1-0a1ddc0c3fe9"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9368), null, false, null, "Speak Low", null, 0, null },
                    { new Guid("906f2543-b014-40c8-aa9a-78348bc3a1db"), null, "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("6429072f-beba-4fa1-91ed-dc51cb01b4b6"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9338), null, false, null, "The Clumsies", null, 0, null },
                    { new Guid("36026893-b691-4954-b8ce-ca0c6ee6d86c"), null, "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("5e08eb5f-b4fd-4527-b69a-a163bd95ca5d"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9307), null, false, null, "Native", null, 0, null },
                    { new Guid("4cf704e9-0d74-4713-86d9-d95f3337d79d"), null, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("1716c96b-6635-4aa4-9d8d-3a9296f73772"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9278), null, false, null, "Salmon Guru", null, 0, null },
                    { new Guid("ffe90ef9-dbea-4c03-8c0c-b2a907c806f5"), null, "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("f4197526-50dd-4906-8df1-6a215a79864f"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9262), null, false, null, "The Old Man", null, 0, null },
                    { new Guid("adbb6301-6fe6-4f0b-811b-fcfc3098f117"), null, "https://thevanderlust.com/img/op/er/operation_dagger_3_jpg_1508193462.jpg$i$min$822$530$cc$$.jpeg", new Guid("fb2e20b2-ab38-4fea-b9fb-2a1bbfd9fe61"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9550), null, false, null, "Operation Dagger", null, 0, null },
                    { new Guid("3894194d-96fb-4c2e-84ec-7f5b45920106"), null, "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("fb2e20b2-ab38-4fea-b9fb-2a1bbfd9fe61"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9431), null, false, null, "Atlas", null, 0, null },
                    { new Guid("2ab4449a-3732-4e92-a0fe-cafb12c4d2a0"), null, "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("fb2e20b2-ab38-4fea-b9fb-2a1bbfd9fe61"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9147), null, false, null, "Manhattan", null, 0, null },
                    { new Guid("e55809a4-f20e-4503-b768-90fe4acaee22"), null, "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("ea45f20f-f653-4318-8f5b-0c365c47f03a"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9135), null, false, null, "Drink Kong", null, 0, null },
                    { new Guid("702e68ae-1eb2-494a-ba48-070ed6e7aa42"), null, "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("0a35f397-98e7-46bd-bfa9-7918a83289c7"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9458), null, false, null, "Broken Shaker", null, 0, null },
                    { new Guid("fc5d6ff9-3d8a-4ae5-94e0-32cd6331d9df"), null, "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("0a35f397-98e7-46bd-bfa9-7918a83289c7"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9442), null, false, null, "Dante", null, 0, null },
                    { new Guid("692eb380-6aad-4866-8c0e-e36636e4c1c0"), null, "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("0a35f397-98e7-46bd-bfa9-7918a83289c7"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9347), null, false, null, "Attaboy", null, 0, null },
                    { new Guid("7bd9397a-56e9-4a61-8aeb-72212eee4c5f"), null, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("0a35f397-98e7-46bd-bfa9-7918a83289c7"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9326), null, false, null, "The Dead Rabbit", null, 0, null },
                    { new Guid("50a7d728-9f58-4dca-a2c5-95a622d9d6f3"), null, "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("0a35f397-98e7-46bd-bfa9-7918a83289c7"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9289), null, false, null, "Katana Kitten", null, 0, null },
                    { new Guid("f26052d6-073f-40f9-a21c-819dc92bf557"), null, "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("0a35f397-98e7-46bd-bfa9-7918a83289c7"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9114), null, false, null, "The NoMad", null, 0, null },
                    { new Guid("b5a9c2ac-5e39-44da-85f2-bcebb3943cb4"), null, "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("0154eadb-9ce4-405a-aa3f-76934bc31b39"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9525), null, false, null, "The Gibson", null, 0, null },
                    { new Guid("e764b5c2-dd1d-4304-9a17-61b036ef9cb1"), null, "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("0154eadb-9ce4-405a-aa3f-76934bc31b39"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9449), null, false, null, "Oriole", null, 0, null },
                    { new Guid("adee5f8f-8788-45f4-845a-a4ff681b94f5"), null, "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("0154eadb-9ce4-405a-aa3f-76934bc31b39"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9393), null, false, null, "Happiness Forgets", null, 0, null },
                    { new Guid("4ae94f06-7667-47a8-8425-633e515d525b"), null, "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("0154eadb-9ce4-405a-aa3f-76934bc31b39"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9355), null, false, null, "Bar Termini", null, 0, null },
                    { new Guid("479e795b-847c-4617-89a6-aff7484e0365"), null, "https://www.google.com/imgres?imgurl=http%3A%2F%2Fbensheridan.tech%2Fbars%2F_images%2Fdandelyan.jpg&imgrefurl=http%3A%2F%2Fbensheridan.tech%2Fbars%2F&tbnid=YW57kwbvtlmrSM&vet=12ahUKEwjj9IaHq7rpAhXM2-AKHccTBVYQMygEegUIARDXAQ..i&docid=5sqRZTba_Je84M&w=630&h=472&q=dandelyan%20bar&ved=2ahUKEwjj9IaHq7rpAhXM2-AKHccTBVYQMygEegUIARDXAQ", new Guid("0154eadb-9ce4-405a-aa3f-76934bc31b39"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9317), null, false, null, "Dandelyan", null, 0, null },
                    { new Guid("59e850e3-ff12-4318-831b-87bd1722a2f9"), null, "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("0154eadb-9ce4-405a-aa3f-76934bc31b39"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9157), null, false, null, "Connaught Bar", null, 0, null },
                    { new Guid("241e25fa-4604-4079-91cc-2326e62767d9"), null, "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("f26a722f-c5e5-4204-806b-4bf03dce219c"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9516), null, false, null, "Himkok", null, 0, null },
                    { new Guid("36b37d81-9c46-4bd1-8fbe-3ef1cb4a608f"), null, "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("401a769f-7f8e-4f89-8008-71d27c1c2584"), new DateTime(2020, 5, 26, 5, 41, 19, 18, DateTimeKind.Utc).AddTicks(9540), null, false, null, "Black Pearl", null, 0, null }
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
                name: "IX_Bars_CountryId",
                table: "Bars",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Bars_UserId",
                table: "Bars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BarStars_UserId",
                table: "BarStars",
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
                name: "IX_Cocktails_UserId",
                table: "Cocktails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailStars_UserId",
                table: "CocktailStars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPhotos_UserId",
                table: "UserPhotos",
                column: "UserId",
                unique: true);
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
                name: "BarStars");

            migrationBuilder.DropTable(
                name: "CocktailComments");

            migrationBuilder.DropTable(
                name: "CocktailIngredients");

            migrationBuilder.DropTable(
                name: "CocktailStars");

            migrationBuilder.DropTable(
                name: "UserPhotos");

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
