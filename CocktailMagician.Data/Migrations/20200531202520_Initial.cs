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
                    { new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), "f22171f4-6740-4f4f-89c4-0aaff6d973f5", "Crawler", "CRAWLER" },
                    { new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"), "56efd0cf-10bd-4bed-bbc6-cc42e2ed7f4b", "Magician", "MEMBER" },
                    { new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"), "c42332b5-a814-454b-adbe-2d30d0cdd1e0", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), 0, "1c2a821f-4698-4e20-b108-19a60f8d12c8", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "crawler@abv.bg", false, false, false, null, null, "crawler@abv.bg", "CRAWLER@ABV.BG", "AQAAAAEAACcQAAAAEIT+nDbDCA9OSuuCqj+kS7OjEkommEcRW8i/9fTmvCoIvOMB++93uimCzZj+OT1E5Q==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "CRAWLER@ABV.BG", null },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), 0, "fae45dca-9f05-4caa-a9c7-b79d61c112ab", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@abv.bg", false, false, false, null, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEGQWZJEoELZ+9yZxdE5gQlxREtgLSIf6rTo8RqE2RYI8bOGSnBpH885L9psITNRQSA==", null, false, "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU", false, "admin@abv.bg", null },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), 0, "c07ca4a2-810f-46ea-b9ff-8d5cde200db4", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "magician@abv.bg", false, false, false, null, null, "magician@abv.bg", "MAGICIAN@ABV.BG", "AQAAAAEAACcQAAAAENwm/EeLgyYES7JVoTcb/cC3hc4MgMU0oLwMhKK4mTiAKdbydbvHT+cRmUgNTfAvpw==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "MAGICIAN@ABV.BG", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("6b4bceea-590b-485a-89b3-2fc82d38dd3d"), 4.2000000000000002, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2677), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("180fc34e-dd64-423e-a0a5-cf21d4278832"), 4.5, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2697), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("3bb03fb9-4287-4911-939e-b71c6b5084bd"), 7.2999999999999998, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2713), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("f45d87b4-d088-4c6f-9a10-2cf6067c3b64"), 7.2000000000000002, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2728), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("ade750e8-7c64-4d72-ab8d-f170bf3780dc"), 16.0, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2774), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("f219ce50-1690-40c3-98c9-d457c86177b2"), 12.699999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2760), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("ed84e87b-6c05-4d6b-9239-ddcef569c800"), 4.0999999999999996, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2663), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("8474cde4-5178-45c9-9c3c-7951793602cb"), 12.699999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2822), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("ef88da36-7250-4a5c-adeb-1216612c2845"), 2.5, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2836), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("4b50944f-199b-4070-acb1-8631c0879f6f"), 7.4000000000000004, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2745), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("a6845fa2-36dc-4e4c-8592-3813ae310205"), 3.8999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2643), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("7743d41f-ccad-4583-86c1-f9cd63a8f5c6"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(1139), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("1e5f6f12-1750-4ac6-8b64-bd691a4ca3bc"), 3.7999999999999998, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2609), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("265358fa-da70-4289-9f18-e6420b24093e"), 3.7999999999999998, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2626), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("ce5aa57d-66e2-48c9-bce3-a5f4441ee9e2"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2421), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("6acb3337-6d22-4301-b361-cf1a968654ae"), 3.5, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2382), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("c114d45c-10fb-4df8-9855-1a374e5b8640"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2365), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("d5939674-aeec-45d6-a2b8-653d916b89c1"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2323), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("89951d3d-8ff5-46af-8e01-d3622220c6e6"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2476), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("1bf814c8-9cbb-42a0-b03f-3c676ea0c4ec"), 16.0, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2462), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("7dab3d1f-2a94-437d-9817-47aea1b12c0d"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2505), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("c63607a7-407d-4fba-b7c5-dc6ff998f0fe"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2521), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("5e5c36dd-cabb-4df2-91f8-90cf891eb5b2"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2536), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("e6104c75-19a2-4b50-a35d-3cb5f27dd4dc"), 3.5, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2559), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("d28d0b7b-b3bf-4884-bac6-f6962c3ac312"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2574), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("d82d4117-d160-43fd-a714-4a5a66b68676"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2592), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("15346bd8-34d5-41bd-be75-b8157ca7c92c"), 3.3999999999999999, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2489), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("f13b2fea-1a2c-4cd5-9cc2-6d5ba719ec9f"), 3.5, new DateTime(2020, 5, 31, 20, 25, 19, 175, DateTimeKind.Utc).AddTicks(2445), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("90c6a441-6972-4cb1-8d14-fed3e28b0cfc"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4474), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("878d86e0-bd73-4623-b187-d2f88da18d20"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4485), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("edebaad3-5e2a-401c-9129-856bf329aa47"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4481), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("74ec97f5-0ebe-4a49-b2e1-b65842aa9aaa"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4477), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("29c5a8c4-c2d1-42a1-a25a-12815ac06b95"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4470), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("65b2d477-44ac-4e82-89f6-5e62034388ae"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4452), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("86218876-43fa-418e-9568-be8433226a78"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4448), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("47e048ab-0b58-4ff3-83e0-65a414f48868"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4444), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("09911cd0-68ea-47ed-b498-3648fea60cdb"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(3425), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("49e616ce-6a32-4f73-b98e-6d9e42279ffa"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4405), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("ca1279d2-b2e1-4a61-9d1e-1b2e91c7e18a"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4426), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("51ab7158-df3d-4ba9-8903-938ba1a39792"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4431), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("bca3c23e-141b-409c-b1e7-d72c535bfe74"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4435), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("b8fa399b-55bd-4933-980e-2825a8d89cbc"), new DateTime(2020, 5, 31, 20, 25, 19, 176, DateTimeKind.Utc).AddTicks(4464), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("40ff417c-b8f4-48f7-a120-bd01d1266de0"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2888), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("3af29116-66da-46c1-ab2b-e855c0f47088"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2895), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("5c44fcee-6c43-4c90-8939-30225de1d02e"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2902), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("5ef6ec8e-8e41-49e2-adc8-a30da5520744"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2909), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("2006ecbb-c2e6-487d-a06a-36cbdc612af8"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2951), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("82d8b8b0-25e2-4201-8b66-7a6f7c6d39b8"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2924), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("78d23a0b-82b9-43ff-b19a-51c1f2f9060f"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2937), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("91cc4a21-5ffb-464b-a639-406a7a58ff67"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2944), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("3b4665a8-42c0-4a7f-b2b4-ba53419050ad"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2959), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("09f5b9b6-90d6-4024-8744-f65e809656b1"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2916), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("491f4025-b3db-433f-b186-261608f84dea"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2881), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("ab8c09aa-c7f6-409f-9c70-ff911fc96cec"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2856), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("05e85c5e-d508-4009-bc2f-6207410f2e43"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2849), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("b6a5b6d7-350a-4a9b-bf43-ba2bee29024d"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2842), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("e4bd6a69-f500-45ab-8591-a6df871d23d1"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2835), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("c503cc6e-7072-4b3e-a04f-cc1ca9b83070"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2827), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("90d1c0be-0b24-421c-b59a-25bc4fb45e90"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2820), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("12002fde-6512-40dd-a331-54f1d724d93e"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2813), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("d076667e-8d87-44a8-904d-979ff36f5e46"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2804), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("ec065f01-f9ba-427e-9a24-a5782fb8e427"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2784), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("2601b6d9-661f-4103-aae0-fce28cf5ed90"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2778), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("cccecd21-2c30-4228-994a-0746c92a4618"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2770), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("3850c16c-c9c2-435c-ac4f-bde6f4c8e2d0"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2747), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("ab3202b9-3d1a-4fb9-8be8-373a92da42d8"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2739), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("3f7547e2-e4b7-4469-a04b-1b5eac1fc782"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2706), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("5a8b1896-60b5-46b6-bd93-e3751d9b708e"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(1479), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("0c140fc9-28f8-44a3-8b38-5e31e01ef73b"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2868), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("1bed28a6-1c64-4478-a298-52a6c6462ca8"), new DateTime(2020, 5, 31, 20, 25, 19, 171, DateTimeKind.Utc).AddTicks(2754), null, null, false, false, null, "Whiskey", 0, 0 }
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
                    { new Guid("7a14f473-0efd-409c-a994-428d8273e74c"), "304 BRUNSWICK ST", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("878d86e0-bd73-4623-b187-d2f88da18d20"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(3238), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, null },
                    { new Guid("4edc5870-d8b5-4a11-a348-1a19e1f36679"), "Storgata 27 Oslo", "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("edebaad3-5e2a-401c-9129-856bf329aa47"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(3130), null, false, null, "Himkok", "+47 22 42 22 02", 0, null },
                    { new Guid("6a74e4ef-9679-4e6d-ae68-02cde3851844"), "Av. �lvaro Obreg�n 106 Cuauht�moc", "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("74ec97f5-0ebe-4a49-b2e1-b65842aa9aaa"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2898), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, null },
                    { new Guid("0d753639-41c2-440a-a4de-a71f07c15e47"), "500 Arguello Street Redwood City", "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("90c6a441-6972-4cb1-8d14-fed3e28b0cfc"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2844), null, false, null, "High Five", "(844) 464-4445", 0, null },
                    { new Guid("dc6d6cc4-fd92-4b6b-8a7c-4b8e2d0ba769"), "52 Rue de Saintonge Paris", "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("29c5a8c4-c2d1-42a1-a25a-12815ac06b95"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(3080), null, false, null, "Candelaria", "+34 910 00 61", 0, null },
                    { new Guid("e77244c6-01ff-489a-b264-3b5254ce6f90"), "60 Rue Charlot Paris", "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("29c5a8c4-c2d1-42a1-a25a-12815ac06b95"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2762), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, null },
                    { new Guid("994e3d77-c9fb-4200-b7c3-e5b2c67447de"), "579 Fuxing Zhong Lu", "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("b8fa399b-55bd-4933-980e-2825a8d89cbc"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2714), null, false, null, "Speak Low", "6416 0133", 0, null },
                    { new Guid("4d0ebc47-26bd-4d19-af13-231d5d295fe6"), "Praxitelous 30 Athens", "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("65b2d477-44ac-4e82-89f6-5e62034388ae"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2599), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, null },
                    { new Guid("def98cea-8f65-4b69-a242-354f6b0a7933"), "Paceville Main Staircase St Julian's", "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("86218876-43fa-418e-9568-be8433226a78"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2477), null, false, null, "Native", "+356 2138 0635", 0, null },
                    { new Guid("f5c847eb-3cab-4b32-bb90-86dc6b2e40dd"), "Calle Echegaray 21 28014 Madrid", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("47e048ab-0b58-4ff3-83e0-65a414f48868"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2398), null, false, null, "Salmon Guru", "+34 910 00 61", 0, null },
                    { new Guid("7cdf62ba-56ba-4bd2-aa21-c612f18c8e4a"), "37 Aberdeen Street Central", "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("bca3c23e-141b-409c-b1e7-d72c535bfe74"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2324), null, false, null, "The Old Man", "85227031899", 0, null },
                    { new Guid("15fcbd54-726a-415e-afc7-43895149a6f9"), "7 Ann Siang Hill", "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("51ab7158-df3d-4ba9-8903-938ba1a39792"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(3276), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, null },
                    { new Guid("427e3fb5-16df-4179-ae49-f5715ad899d7"), "Parkview Square", "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("51ab7158-df3d-4ba9-8903-938ba1a39792"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2935), null, false, null, "Atlas", "+65 6396 4466", 0, null },
                    { new Guid("98f9d023-ed0b-4d12-8e9a-0efd458c2676"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("ca1279d2-b2e1-4a61-9d1e-1b2e91c7e18a"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2202), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, null },
                    { new Guid("47aa2f40-e65a-4fdd-9142-71c853464d59"), "2727 Indian Creek Dr. Miami Beach", "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("49e616ce-6a32-4f73-b98e-6d9e42279ffa"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(3033), null, false, null, "Broken Shaker", "305-531-2727", 0, null },
                    { new Guid("cd83948b-befb-4e7b-80ad-d8fc7efd2b5b"), "79-81 MacDougal St New York", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("49e616ce-6a32-4f73-b98e-6d9e42279ffa"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2966), null, false, null, "Dante", "01 55 5264 4122", 0, null },
                    { new Guid("97e75c36-2296-4e64-8444-dce7bd134a38"), "134 Eldridge Street New York", "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("49e616ce-6a32-4f73-b98e-6d9e42279ffa"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2634), null, false, null, "Attaboy", "+36 1 792 2222", 0, null },
                    { new Guid("990c4e5c-ce4a-4ae4-b03b-fe13261b5c1d"), "", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("49e616ce-6a32-4f73-b98e-6d9e42279ffa"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2556), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("b6dc84a5-4433-4801-bb72-b0ebc89175e7"), "531 Hudson St New York", "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("49e616ce-6a32-4f73-b98e-6d9e42279ffa"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2435), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("a2ea549d-77c9-44e1-9e80-8db615ff0bb4"), "1170 BROADWAY & 28TH STREET NEW YORK", "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("49e616ce-6a32-4f73-b98e-6d9e42279ffa"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2114), null, false, null, "The NoMad", "(347) 472-5660", 0, null },
                    { new Guid("38a8d90f-fe40-476c-a3ae-1e717f627b38"), "Point Square North Dock Dublin", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("09911cd0-68ea-47ed-b498-3648fea60cdb"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(3175), null, false, null, "The Gibson", "+353 1 681 5000", 0, null },
                    { new Guid("3ef22c9e-b67c-4bd2-8bdc-a6124242cddf"), "61�63. Meaden, London", "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("09911cd0-68ea-47ed-b498-3648fea60cdb"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2999), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("38381eb2-4a78-4076-89af-93f53c6b902b"), "8-9 Hoxton Square London", "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("09911cd0-68ea-47ed-b498-3648fea60cdb"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2794), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, null },
                    { new Guid("7729a015-9554-4b79-9ed8-18ca57ea72e4"), "Soho, London", "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("09911cd0-68ea-47ed-b498-3648fea60cdb"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2666), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, null },
                    { new Guid("0a9c5951-9c7c-4f71-854a-e481aecdde0d"), "20 Upper Ground South Bank London SE1 9PD", "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("09911cd0-68ea-47ed-b498-3648fea60cdb"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2514), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("30d90f76-d31b-4afa-9b13-1f3fd636bf16"), "The Connaught Carlos Place Mayfair London", "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("09911cd0-68ea-47ed-b498-3648fea60cdb"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2275), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("6d844b26-a521-4653-bafd-1f46313b42df"), "1 Cuscaden Road 249715", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("51ab7158-df3d-4ba9-8903-938ba1a39792"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(2241), null, false, null, "Manhattan", "+65 6725 3377", 0, null },
                    { new Guid("e561eed1-dbdc-42ec-9a84-209846814c98"), "The Savoy Strand London WC2R 0EZ", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("09911cd0-68ea-47ed-b498-3648fea60cdb"), new DateTime(2020, 5, 31, 20, 25, 19, 179, DateTimeKind.Utc).AddTicks(588), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, null }
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
