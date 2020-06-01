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
                    { new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"), "b7d47c3a-5506-4b91-8771-f32ed57f017d", "Crawler", "CRAWLER" },
                    { new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"), "6733b9bb-de83-4f82-aa83-9068d381316f", "Magician", "MEMBER" },
                    { new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"), "f6c733f3-4536-49a8-9625-feaaf0635806", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedOn", "DeletedOn", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "UserPhoto" },
                values: new object[,]
                {
                    { new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"), 0, "84038a0f-b9ed-4638-bbde-f85f76c47bec", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "crawler@abv.bg", false, false, false, null, null, "crawler@abv.bg", "CRAWLER@ABV.BG", "AQAAAAEAACcQAAAAEK1/onJbmM9Q36a7aJWYxrLIjvEskVZ0E7fAt3ppAzRtyHAd72msErlnDU+2z8MoGw==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "CRAWLER@ABV.BG", null },
                    { new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"), 0, "e8116e46-93b0-4906-abc3-f352791f74d1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@abv.bg", false, false, false, null, null, "ADMIN@ABV.BG", "ADMIN@ABV.BG", "AQAAAAEAACcQAAAAEOJyt8wAoq9w2V12iXPEb97ZwjJtLhS69RyASv/MaJssMGWisE/vv6OeSAWisQXUZQ==", null, false, "15CLJEKQCTLPRXMVXXNSWXZH6R6KJRRU", false, "admin@abv.bg", null },
                    { new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"), 0, "c11d98e0-c04f-4e07-aef8-db8df8439490", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "magician@abv.bg", false, false, false, null, null, "magician@abv.bg", "MAGICIAN@ABV.BG", "AQAAAAEAACcQAAAAECcl8av48l86C+96zFet42EETyK5GXXDufCkMTjqt6dJQtH5UWwmKjwCXXypo0GXRQ==", null, false, "7I5VNHIJTSZNOT3KDWKNFUV5PVYBHGXN", false, "MAGICIAN@ABV.BG", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("9e24fd07-9126-42b8-99e7-0ebf594d24a9"), 4.2000000000000002, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3389), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("f033ce9c-10a6-4f49-a867-a2d38c7c96e8"), 4.5, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3398), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("869a04ea-c1d4-4d90-94eb-94ed1fa7fdfd"), 7.2999999999999998, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3407), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("59fb7ad4-70d3-4e02-a906-ab3a2745219c"), 7.2000000000000002, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3415), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("fead46c3-1a37-4333-85fc-15ced8b57d1a"), 16.0, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3441), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("d1611b30-9c54-4433-96c8-51379bf13eef"), 12.699999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3432), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("42e9f0fc-0922-4b32-bb0c-b3e833da4f51"), 4.0999999999999996, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3380), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("4438f438-f1fe-4d94-8398-3907a5c7d22c"), 12.699999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3450), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("b42e9d9a-ed21-494f-999a-0ccaea4fb547"), 2.5, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3458), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("51b8bcff-8ad9-4d35-84f2-bb0b2245f24e"), 7.4000000000000004, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3424), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("11ce6a08-f065-4414-b8a3-2b1d79765e9a"), 3.8999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3373), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("e0558501-cff6-4ce7-97fc-450bad470acb"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(2057), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("935ae388-a3a9-4cb8-84cd-791cfd97e4db"), 3.7999999999999998, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3350), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("20db3326-d73f-4988-9ea5-1234b9713fd8"), 3.7999999999999998, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3360), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("51056f14-00d9-44c3-9d82-f2617695c463"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3066), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("7f65d0f6-e566-4cd3-8e0e-0987bb2ace93"), 3.5, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3057), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("c63e0e54-39a6-4d0a-a34b-e8fe13fac2d4"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3048), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("71cd5c29-c48b-4063-856b-59e353005319"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3025), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("bd066342-3824-4ee4-b81c-aea333bb0d54"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3097), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("45f06b1c-ddd6-47f1-9c98-99c2d1816ecd"), 16.0, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3088), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("caa679c2-054b-4c27-93b9-b90db4b48f65"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3118), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("eb3eff99-69d5-435a-9b8f-05898a511dc0"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3126), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("09f7a780-8d21-4475-a6f5-60248d9ced6c"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3134), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("7c41be9b-df7f-41ef-acad-338dd87b74e8"), 3.5, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3142), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("a8e0f81d-4d26-4e5d-ac38-5ab6922cecb7"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3150), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("6ae4752b-d84a-4014-982a-8fc7ce95833c"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3160), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("27b2451f-822c-4f38-a625-ee26801a3014"), 3.3999999999999999, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3105), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("1d28c01b-064c-40d8-ade0-ab0245b746a4"), 3.5, new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(3078), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("2bf0add9-d434-49bf-a589-a920f814bcb7"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(211), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("40c04295-5613-4a87-ba05-6c0152ef3ebd"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(221), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("c36b4c92-e8ee-4e2b-be57-bfec8b3a04be"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(216), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("156c2814-4eb9-422f-b5ed-280339686e43"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(214), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("2bda4427-33f0-44fa-b157-25ea54c6ebab"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(208), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("175b272e-2665-4d1f-a670-ce67b4b6f98a"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(202), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("301f5f90-ea3b-406c-b024-7478f057ef67"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(199), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("ce6d255d-0adc-4945-a6b6-59521c40dc7b"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(196), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("a926dc8e-478b-4fce-a6ae-a25e66c9a906"), new DateTime(2020, 5, 31, 12, 52, 53, 300, DateTimeKind.Utc).AddTicks(9608), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("6b32b925-ea18-4faa-8650-fcea60d47fa8"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(162), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("0ab329c2-264f-4cde-b915-7d9e948f68bb"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(176), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("c3a69fe8-b723-4898-9c8e-0f0b8aa561ab"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(179), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("a518016b-4594-4303-aa29-5d57a253d170"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(182), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("7bab26c5-86bf-4210-8f17-a4c58c5c6243"), new DateTime(2020, 5, 31, 12, 52, 53, 301, DateTimeKind.Utc).AddTicks(204), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("66e53899-ca60-4ad2-bc33-8ac7bd011c10"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1647), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("94b35be8-966a-4e05-afc0-4ace60768415"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1650), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("75d9a17d-f2f6-42f1-a77a-fa4cf8bc7000"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1653), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("cda2858c-5186-4c5c-9cfc-7c8dfbc8e4c5"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1656), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("dc2ce2ad-3a6f-4e00-b6b2-4f3211c9f4cf"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1711), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("ea3a64a0-3963-4d04-be23-98d4a6329088"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1663), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("630d43a9-45bb-4ae2-b255-cbbe8ff66a36"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1666), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("54f60c2a-146c-4c8b-bef9-00a06032b43c"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1669), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("d663f575-3655-488f-9624-c3ad2d04c815"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1714), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("4d8d45a8-698d-4abb-8726-1945cccfe57d"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1658), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("4bd3baaf-dea5-4b7b-b8b3-b567c75499ce"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1645), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("dde8fb85-1ff1-42f3-8c9d-371533941b21"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1638), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("1101650b-d00a-4e1a-a5f2-3bfaf5e18ac4"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1633), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("6021a701-0a77-4a03-b8f0-7cf5cea9a67f"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1630), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("eb17056b-77ed-453b-aec7-f86633df1bb0"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1628), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("37a76210-92db-4bbf-91e8-748ce96b1d82"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1625), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("83bbe6a6-921e-4149-8ef4-544f2941882f"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1622), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("7c8a6fca-463f-4c38-93d7-37a9511baf60"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1619), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("2ebdf7df-5445-4199-bef0-74fcc4946423"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1616), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("67197fb6-204b-4df7-918a-1119b76662fe"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1613), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("f7bff35d-6cbd-45e0-b725-97a13b15f424"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1600), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("765da783-471e-4e07-a184-758804abed1c"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1597), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("7c49d94e-969f-4580-8a0b-8fcba4dc737d"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1589), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("9d1e51a3-1333-4fd0-8382-b6c20ffcd1b5"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1586), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("821660dd-95c7-4c8e-a6d8-c8114f1d8c46"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1577), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("d0c7f0d6-5e57-4f3d-ad44-d924219bc90d"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1085), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("257aefd5-2d54-4dba-9e30-6f5684810a06"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1641), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("4482a947-eab1-4b44-9963-6cd4c69ed1fa"), new DateTime(2020, 5, 31, 12, 52, 53, 296, DateTimeKind.Utc).AddTicks(1592), null, null, false, false, null, "Whiskey", 0, 0 }
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
                    { new Guid("8250e136-059f-48d1-b4f5-b01af314878d"), "304 BRUNSWICK ST", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("40c04295-5613-4a87-ba05-6c0152ef3ebd"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2602), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, null },
                    { new Guid("779d255a-0f05-4ebc-b3d0-41662facc09a"), "Storgata 27 Oslo", "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("c36b4c92-e8ee-4e2b-be57-bfec8b3a04be"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2579), null, false, null, "Himkok", "+47 22 42 22 02", 0, null },
                    { new Guid("f3b8843a-7611-44ad-9fab-cf8ff6f5f1df"), "Av. �lvaro Obreg�n 106 Cuauht�moc", "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("156c2814-4eb9-422f-b5ed-280339686e43"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2509), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, null },
                    { new Guid("a4db645d-8395-4739-afe4-883a28c26fc5"), "500 Arguello Street Redwood City", "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("2bf0add9-d434-49bf-a589-a920f814bcb7"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2493), null, false, null, "High Five", "(844) 464-4445", 0, null },
                    { new Guid("87552164-f065-4893-9e52-2770947f14b4"), "52 Rue de Saintonge Paris", "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("2bda4427-33f0-44fa-b157-25ea54c6ebab"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2565), null, false, null, "Candelaria", "+34 910 00 61", 0, null },
                    { new Guid("7eaba018-e11d-47e6-bb27-27c85e1448ea"), "60 Rue Charlot Paris", "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("2bda4427-33f0-44fa-b157-25ea54c6ebab"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2432), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, null },
                    { new Guid("10963921-adee-46b1-b1ff-36401e6a2f5e"), "579 Fuxing Zhong Lu", "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("7bab26c5-86bf-4210-8f17-a4c58c5c6243"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2417), null, false, null, "Speak Low", "6416 0133", 0, null },
                    { new Guid("4a021849-8baa-4271-bf40-82d42f050f63"), "Praxitelous 30 Athens", "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("175b272e-2665-4d1f-a670-ce67b4b6f98a"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2385), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, null },
                    { new Guid("58825ca5-8c62-4a39-942b-cbac5b3c3c37"), "Paceville Main Staircase St Julian's", "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("301f5f90-ea3b-406c-b024-7478f057ef67"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2353), null, false, null, "Native", "+356 2138 0635", 0, null },
                    { new Guid("a487b0d5-3b98-42d0-90a4-c4a8c3cedf6d"), "Calle Echegaray 21 28014 Madrid", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("ce6d255d-0adc-4945-a6b6-59521c40dc7b"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2325), null, false, null, "Salmon Guru", "+34 910 00 61", 0, null },
                    { new Guid("30d02b3a-1cb5-4785-89e6-f81c47fa4f90"), "37 Aberdeen Street Central", "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("a518016b-4594-4303-aa29-5d57a253d170"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2314), null, false, null, "The Old Man", "85227031899", 0, null },
                    { new Guid("5fa6e80f-37a6-4b92-8085-b567b4e35be9"), "7 Ann Siang Hill", "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("c3a69fe8-b723-4898-9c8e-0f0b8aa561ab"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2612), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, null },
                    { new Guid("d587bd9a-b940-4d8b-a859-e902353dfc80"), "Parkview Square", "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("c3a69fe8-b723-4898-9c8e-0f0b8aa561ab"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2521), null, false, null, "Atlas", "+65 6396 4466", 0, null },
                    { new Guid("87dc0158-623c-4491-90bc-0428461104d3"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("0ab329c2-264f-4cde-b915-7d9e948f68bb"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2280), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, null },
                    { new Guid("30d1233e-59c4-495a-a332-7543830b79b3"), "2727 Indian Creek Dr. Miami Beach", "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("6b32b925-ea18-4faa-8650-fcea60d47fa8"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2550), null, false, null, "Broken Shaker", "305-531-2727", 0, null },
                    { new Guid("934b40ad-48c9-4258-a188-8158500e3d01"), "79-81 MacDougal St New York", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("6b32b925-ea18-4faa-8650-fcea60d47fa8"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2531), null, false, null, "Dante", "01 55 5264 4122", 0, null },
                    { new Guid("638d213b-00df-4ed2-a3a0-1726dffb342e"), "134 Eldridge Street New York", "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("6b32b925-ea18-4faa-8650-fcea60d47fa8"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2395), null, false, null, "Attaboy", "+36 1 792 2222", 0, null },
                    { new Guid("53d5dd83-01a8-4ae2-9eac-f43750554879"), "", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("6b32b925-ea18-4faa-8650-fcea60d47fa8"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2372), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("cb5cb9a7-f4d6-4c28-a043-c03dd91f07cc"), "531 Hudson St New York", "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("6b32b925-ea18-4faa-8650-fcea60d47fa8"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2341), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("b9d8f096-8283-4f0d-b332-f3c57d351fd9"), "1170 BROADWAY & 28TH STREET NEW YORK", "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("6b32b925-ea18-4faa-8650-fcea60d47fa8"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2261), null, false, null, "The NoMad", "(347) 472-5660", 0, null },
                    { new Guid("e6c9a1c2-2eb7-40ab-aa72-a2cc7c23551f"), "Point Square North Dock Dublin", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("a926dc8e-478b-4fce-a6ae-a25e66c9a906"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2587), null, false, null, "The Gibson", "+353 1 681 5000", 0, null },
                    { new Guid("cd32acb1-b1d5-43b6-a4c3-e71fc78222ca"), "61�63. Meaden, London", "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("a926dc8e-478b-4fce-a6ae-a25e66c9a906"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2540), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("7fc19b7d-cce4-40f5-b297-943b466473de"), "8-9 Hoxton Square London", "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("a926dc8e-478b-4fce-a6ae-a25e66c9a906"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2441), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, null },
                    { new Guid("d1b5b1a5-08c6-4d78-9ff5-87a1b0e80d39"), "Soho, London", "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("a926dc8e-478b-4fce-a6ae-a25e66c9a906"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2402), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, null },
                    { new Guid("fd2ef1ad-e065-424b-a787-cd91b7ad6033"), "20 Upper Ground South Bank London SE1 9PD", "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("a926dc8e-478b-4fce-a6ae-a25e66c9a906"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2363), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("ee2e76cd-7845-460e-b371-80c47b972bc5"), "The Connaught Carlos Place Mayfair London", "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("a926dc8e-478b-4fce-a6ae-a25e66c9a906"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2302), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("a1a907a2-093e-4806-a8d3-a300d28ed39b"), "1 Cuscaden Road 249715", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("c3a69fe8-b723-4898-9c8e-0f0b8aa561ab"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(2291), null, false, null, "Manhattan", "+65 6725 3377", 0, null },
                    { new Guid("347c6593-b305-4a73-a34e-e64ace060429"), "The Savoy Strand London WC2R 0EZ", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("a926dc8e-478b-4fce-a6ae-a25e66c9a906"), new DateTime(2020, 5, 31, 12, 52, 53, 302, DateTimeKind.Utc).AddTicks(1688), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, null }
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
