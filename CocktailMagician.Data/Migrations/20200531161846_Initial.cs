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
                    Rating = table.Column<int>(nullable: false)
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
                    Rating = table.Column<int>(nullable: false)
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
                    { new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), "ebdd28c6-36e3-4f24-9f1e-53aeba151242", "Crawler", "CRAWLER" },
                    { new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"), "88e2a00d-1b15-4a5e-8cd0-98372a80477e", "Magician", "MEMBER" },
                    { new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"), "efbc5a27-9e92-490d-8da4-bfc04775bd03", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), 0, "df825a53-e656-42e7-801d-aa0b9cc911ab", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "crawler@abv.bg", false, false, false, null, null, "crawler@abv.bg", "CRAWLER@ABV.BG", "AQAAAAEAACcQAAAAEKEAMmPLQv/k0UksK7iaLhdV7RVjcCEh9aJaLucmXSylAgQGH/bTm5K7gbuorGnXKQ==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "CRAWLER@ABV.BG", null },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), 0, "d2f66e34-3ee5-487b-bcac-25c7a56a766f", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@abv.bg", false, false, false, null, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEIP62PhjLsCoW8k54hNc/d3Q5r7EmQloj7QDgbQY9+WpYgKtoeaRemTthi1CY4kUYw==", null, false, "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU", false, "admin@abv.bg", null },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), 0, "fc298ade-680e-465e-ac83-4287a1e0efd0", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "magician@abv.bg", false, false, false, null, null, "magician@abv.bg", "MAGICIAN@ABV.BG", "AQAAAAEAACcQAAAAEONwN8bnyzzLGCiCR0kVA21kAEnHNg6CeLkzvEGtOGohgz90j1cSdsV2o+Ju9/IRGg==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "MAGICIAN@ABV.BG", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("3e2873cf-4252-465e-b16c-d1273ea74af2"), 4.2000000000000002, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3886), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("99cf6ab9-9c27-42b0-a783-2dd4ff953692"), 4.5, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3914), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("696b7363-995c-4a72-a404-95da20032f7e"), 7.2999999999999998, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3949), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("78cbc6f6-25e2-45a3-828e-9fdd6954a71a"), 7.2000000000000002, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3975), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("825b665f-9bad-40be-95a0-1864e1f4440a"), 16.0, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(4174), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("64e024eb-4db1-41c2-8fab-c04a0c1992df"), 12.699999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(4031), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("639a1cff-a42d-4f07-b5d1-034bed775be4"), 4.0999999999999996, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3861), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("c76b8758-f4c5-43d3-8ce5-ded5d171be44"), 12.699999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(4207), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("3d002972-f984-456c-b2e8-e4caa38f40f6"), 2.5, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(4232), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("deb687db-2ed6-4342-93e2-094fc3982950"), 7.4000000000000004, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(4002), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("d888990b-56a0-4c6d-a58c-4b6d738cd16b"), 3.8999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3831), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("f3864297-28bb-416b-9f22-411d92eee769"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(1615), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("6522c790-22f6-44d4-a36e-6e2e08879b1a"), 3.7999999999999998, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3765), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("135655c6-eb46-46a1-9969-c986a74cca58"), 3.7999999999999998, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3796), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("5cd823ec-1b06-4c0f-98f0-5dddd777d2cc"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3393), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("b5ec1461-b70f-4cc0-88ae-af8f3c184f52"), 3.5, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3365), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("42468c53-e1de-47a0-bb4d-a88deab0e695"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3334), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("7960b9e5-66bc-4624-8d69-3c94cf878fea"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3269), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("7344adb8-20f1-4271-a0b1-b5b0590e95e6"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3520), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("9ff809b9-459f-41c8-84dc-db2e5ab9b605"), 16.0, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3493), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("14d6bf32-21c1-49fd-abb5-5aa8eef2e4c9"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3582), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("a342878b-5592-4dce-a8ac-40c9b1161a18"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3611), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("51ed752f-df0c-4e41-b0c0-6082cbc49e86"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3642), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("30fac84e-07b0-4fe8-92cd-90af88d9a96a"), 3.5, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3671), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("b112fc8d-649e-4c16-af37-50f7efbba375"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3706), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("0023a43c-31b3-4179-8657-bebddaeae1f2"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3735), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("d3bac7d9-368d-4e78-ae29-1fe995eb99e1"), 3.3999999999999999, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3547), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("d5bf82ff-56ad-4dbd-ae70-c9305d4095c2"), 3.5, new DateTime(2020, 5, 31, 16, 18, 45, 369, DateTimeKind.Utc).AddTicks(3462), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("338500e4-dfc9-4dfc-87df-0014c25ac4bb"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5867), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("373e331e-b815-4f64-bab3-c21dd0c53f99"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5884), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("9b130850-7225-4f44-aaba-818fb5dc3196"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("6c0be35b-0941-46d5-a59f-ab74c33f8b34"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5875), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("c1466909-7b16-4a80-9509-cb2341413cdc"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5863), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("ce739296-6a36-4a62-8768-1aedab63640d"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5854), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("afdc24b2-98fb-429c-b03f-80c2b0b5591e"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5850), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("eb1efa9a-6e37-4dc7-a7c5-b95a50a29736"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5845), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("6a3a5f57-e87f-4f77-9382-dd636d6f26e9"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(4372), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("abbed5f3-5cf0-406e-a15d-5262107efdae"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5768), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("22836e64-a657-4b63-aa2c-16665d3e0fdf"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5790), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("0c0043e7-9b8e-49c2-a0aa-f52afef90fb7"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5827), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("8a490ee2-9e30-4d88-aa00-474cdc75fdfb"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5832), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("f7c438f3-7fac-408b-a2e3-f55b621f75af"), new DateTime(2020, 5, 31, 16, 18, 45, 371, DateTimeKind.Utc).AddTicks(5857), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("d5d8ee75-ed6f-4e2c-b0f9-9332eb542c00"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2159), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("26f7eccb-e390-48da-8ca3-a62fdcbd4b82"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2166), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("aeb00863-b5ad-442c-8369-44fcfa0ffc3a"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2173), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("da0d45e2-3d03-41b6-b748-01ad8f916830"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2180), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("71ce6aaf-d319-41a7-8133-c8348aa4dbe1"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2223), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("ec99f4fd-144f-4014-b808-7df5c0b75e49"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2195), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("52022742-448c-472d-af57-afab87414680"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2208), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("a1d240db-bcb6-4256-8290-32cd66d0f152"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2216), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("b6de13b5-b326-430c-be9a-66459c376413"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2231), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("e7be09c7-4f21-4284-aead-906ad7424aa8"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2187), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("24e5019e-3710-4b85-b006-916563ec39e5"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2152), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("c0229706-03ed-42f2-a148-c2d4cfe03781"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2126), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("4f4e5187-56f3-4ba1-be9c-966ebc682473"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2119), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("d6bc572e-72fb-4742-acdb-6c5f1083f23b"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2112), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("323f7d61-86d8-4c9c-9630-c244ad664ecc"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2104), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("ab7c30ba-07bf-4c9f-89ed-2d2edbf39fb8"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2097), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("d6b2ce33-1776-4f08-b721-fcdcce1ef6c5"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2089), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("32c25d6a-d59d-488c-bd30-9666210c119b"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2082), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("64bcfe77-3087-456b-ae6b-0ccfdf14b728"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2070), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("97bc3e01-dec5-442d-afd5-10d6aa862cb7"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2051), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("186282b1-a9ea-416f-9374-26a858aad933"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2044), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("44f2e852-21ce-49a6-9b90-82f846c8b674"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2037), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("104dd7e3-6aef-4b07-b079-abecbdd2aef1"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2015), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("2f6646f6-0eef-4e41-a19c-cd93ba9ac8dd"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2007), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("e73d38b2-8edb-4749-960a-3aae9053ae6e"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(1977), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("ebbc5f85-6ede-4595-a428-8fbf8fccdd61"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(708), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("6066bf1c-cca2-444c-bcb9-388b5e6a5032"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2141), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("6146eb1a-43c5-45b1-92e6-21a01a01c835"), new DateTime(2020, 5, 31, 16, 18, 45, 362, DateTimeKind.Utc).AddTicks(2022), null, null, false, false, null, "Whiskey", 0, 0 }
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
                    { new Guid("f50ec0f2-df33-4098-82f1-80c387a2cb8d"), "304 BRUNSWICK ST", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("373e331e-b815-4f64-bab3-c21dd0c53f99"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(2264), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, null },
                    { new Guid("1ff81f32-92ca-4887-b724-ec8fa289a6d1"), "Storgata 27 Oslo", "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("9b130850-7225-4f44-aaba-818fb5dc3196"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(2163), null, false, null, "Himkok", "+47 22 42 22 02", 0, null },
                    { new Guid("e28e7ea4-61d9-4b7e-a476-80d3e6b9b48b"), "Av. �lvaro Obreg�n 106 Cuauht�moc", "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("6c0be35b-0941-46d5-a59f-ab74c33f8b34"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1833), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, null },
                    { new Guid("4030faa9-baab-4c8e-91ba-424d4cfefea0"), "500 Arguello Street Redwood City", "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("338500e4-dfc9-4dfc-87df-0014c25ac4bb"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1772), null, false, null, "High Five", "(844) 464-4445", 0, null },
                    { new Guid("3085e214-32ea-42a7-b78b-022cde7fefac"), "52 Rue de Saintonge Paris", "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("c1466909-7b16-4a80-9509-cb2341413cdc"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(2055), null, false, null, "Candelaria", "+34 910 00 61", 0, null },
                    { new Guid("a90743d2-c891-42f5-bc00-082570b55082"), "60 Rue Charlot Paris", "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("c1466909-7b16-4a80-9509-cb2341413cdc"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1669), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, null },
                    { new Guid("7815fd86-51ca-477b-94a7-9ba9405b48aa"), "579 Fuxing Zhong Lu", "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("f7c438f3-7fac-408b-a2e3-f55b621f75af"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1610), null, false, null, "Speak Low", "6416 0133", 0, null },
                    { new Guid("47970d28-9eff-478c-864e-3be457abb8d3"), "Praxitelous 30 Athens", "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("ce739296-6a36-4a62-8768-1aedab63640d"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1458), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, null },
                    { new Guid("e338cf2d-48fb-417e-a7ca-7ad6142d9bcd"), "Paceville Main Staircase St Julian's", "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("afdc24b2-98fb-429c-b03f-80c2b0b5591e"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1305), null, false, null, "Native", "+356 2138 0635", 0, null },
                    { new Guid("9e211841-821f-404d-8dd5-8e6aca2d1362"), "Calle Echegaray 21 28014 Madrid", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("eb1efa9a-6e37-4dc7-a7c5-b95a50a29736"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1205), null, false, null, "Salmon Guru", "+34 910 00 61", 0, null },
                    { new Guid("dfe46d8f-71d7-4594-b924-77a9251506a1"), "37 Aberdeen Street Central", "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("8a490ee2-9e30-4d88-aa00-474cdc75fdfb"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1147), null, false, null, "The Old Man", "85227031899", 0, null },
                    { new Guid("1e996525-1a44-4d34-ac8e-10013e596468"), "7 Ann Siang Hill", "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("0c0043e7-9b8e-49c2-a0aa-f52afef90fb7"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(2303), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, null },
                    { new Guid("62724776-8002-4624-b8e4-a1962a953c4d"), "Parkview Square", "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("0c0043e7-9b8e-49c2-a0aa-f52afef90fb7"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1877), null, false, null, "Atlas", "+65 6396 4466", 0, null },
                    { new Guid("a4f7bcde-c8ab-4e8b-a7c4-0730b4ffcde6"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("22836e64-a657-4b63-aa2c-16665d3e0fdf"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(851), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, null },
                    { new Guid("e9f8c13c-3f20-4937-b52e-65b0a04bd490"), "2727 Indian Creek Dr. Miami Beach", "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("abbed5f3-5cf0-406e-a15d-5262107efdae"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(2007), null, false, null, "Broken Shaker", "305-531-2727", 0, null },
                    { new Guid("c047aca1-5567-43be-a80b-1d715b79ff10"), "79-81 MacDougal St New York", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("abbed5f3-5cf0-406e-a15d-5262107efdae"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1918), null, false, null, "Dante", "01 55 5264 4122", 0, null },
                    { new Guid("174f9c80-e2b3-42c6-a985-065267f6ce4c"), "134 Eldridge Street New York", "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("abbed5f3-5cf0-406e-a15d-5262107efdae"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1499), null, false, null, "Attaboy", "+36 1 792 2222", 0, null },
                    { new Guid("6048d962-f74c-41a9-ba67-c4c9182a772e"), "", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("abbed5f3-5cf0-406e-a15d-5262107efdae"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1402), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("d6c411b2-acbb-4bdc-86b4-6ca62cacc152"), "531 Hudson St New York", "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("abbed5f3-5cf0-406e-a15d-5262107efdae"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1249), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("3f86b2a5-8c73-471c-bde3-379e06378666"), "1170 BROADWAY & 28TH STREET NEW YORK", "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("abbed5f3-5cf0-406e-a15d-5262107efdae"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(772), null, false, null, "The NoMad", "(347) 472-5660", 0, null },
                    { new Guid("8e4cc930-73ba-44f0-96fe-715def26c031"), "Point Square North Dock Dublin", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("6a3a5f57-e87f-4f77-9382-dd636d6f26e9"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(2206), null, false, null, "The Gibson", "+353 1 681 5000", 0, null },
                    { new Guid("a79b38c5-1359-4308-87ff-d42a1811da2f"), "61�63. Meaden, London", "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("6a3a5f57-e87f-4f77-9382-dd636d6f26e9"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1968), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("3ea50f97-2c6b-4ba8-a8ab-fceb4019c7e8"), "8-9 Hoxton Square London", "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("6a3a5f57-e87f-4f77-9382-dd636d6f26e9"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1707), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, null },
                    { new Guid("39858d42-af63-4e1f-98f5-762328e78479"), "Soho, London", "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("6a3a5f57-e87f-4f77-9382-dd636d6f26e9"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1551), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, null },
                    { new Guid("76fcd629-3e66-4c07-a7fb-d6a719db318b"), "20 Upper Ground South Bank London SE1 9PD", "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("6a3a5f57-e87f-4f77-9382-dd636d6f26e9"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(1356), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("58d4b14d-5ea4-412f-bf0e-b59b1b0b241f"), "The Connaught Carlos Place Mayfair London", "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("6a3a5f57-e87f-4f77-9382-dd636d6f26e9"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(951), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("fa56edc0-4760-45e2-b13c-dfb7491c5d24"), "1 Cuscaden Road 249715", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("0c0043e7-9b8e-49c2-a0aa-f52afef90fb7"), new DateTime(2020, 5, 31, 16, 18, 45, 375, DateTimeKind.Utc).AddTicks(904), null, false, null, "Manhattan", "+65 6725 3377", 0, null },
                    { new Guid("6e63e175-dd18-45b1-b44c-7b958d2287c0"), "The Savoy Strand London WC2R 0EZ", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("6a3a5f57-e87f-4f77-9382-dd636d6f26e9"), new DateTime(2020, 5, 31, 16, 18, 45, 374, DateTimeKind.Utc).AddTicks(8989), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, null }
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
