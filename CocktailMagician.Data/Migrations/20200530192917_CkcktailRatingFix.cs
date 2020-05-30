using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class CkcktailRatingFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"),
                column: "ConcurrencyStamp",
                value: "fb06d712-458f-4d27-a930-ef2a7c1c210b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"),
                column: "ConcurrencyStamp",
                value: "ce0f07fc-a49d-44c6-ad33-661f3ffbc0f4");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"),
                column: "ConcurrencyStamp",
                value: "b0f1a189-0db0-4b3f-8624-e29fbe1110a0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f81a10a4-17f8-4f77-85ce-3b676ea92ea6", "AQAAAAEAACcQAAAAEI8/aTvWeAcuTG9EMhaFmMiNwSp9nkbrHRGpH2mXgzJutIeFSwiG9P7vwRfly5WZUw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "20c2fd63-8d0a-4cbc-aa99-0968f5469f9d", "AQAAAAEAACcQAAAAEP6A3meMVv4tJa6UgsUgqMfBM2NbCax7kzoTRXarjZ++fu91gJh9p63vTEsnpMPA4Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "908c31ee-2c0e-4925-afc5-4eaa1f2ae6eb", "AQAAAAEAACcQAAAAEDNS760MwbybggM/0g9N7rrZPAY2SWfZt2MDIiEWR4auuajZtn1NylirBlvvv/1eTA==" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("6636c210-793b-4ef9-97f8-5d7c7454c171"), 4.2000000000000002, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8171), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("ae4b7f04-6fae-4b41-8db3-94e8bac8ad55"), 4.5, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8211), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("619e84e5-51b3-40e5-9a55-908369e0dc3d"), 7.2999999999999998, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8241), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("90e59c84-d13d-4d41-993c-bd7fdaefa97c"), 7.2000000000000002, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8273), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("d580f017-b2a4-4c91-9f9e-8c3e3aa11581"), 16.0, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8375), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("b88351b4-2fbf-49bc-a0d1-51de08393b89"), 12.699999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8338), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("c41df1ec-2325-4b12-9a40-278e2388635f"), 4.0999999999999996, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8141), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("045716bd-a319-462a-ae26-699baed44fe8"), 12.699999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8407), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("f71dff4f-7f82-400b-9733-ba9095a52a9a"), 2.5, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8437), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("a54649c5-d60f-485a-9732-ae955eff4539"), 7.4000000000000004, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8307), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("913957bd-2a80-4bfe-923e-2edcac57c8aa"), 3.8999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8111), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("eb0b35ea-36f1-48fc-81fc-81c409cf3c6d"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(5329), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("7af2a344-28ba-411f-bdbc-35157ce31d70"), 3.7999999999999998, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8040), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("5feda36f-7b61-427b-9fb5-32755abdd145"), 3.7999999999999998, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8071), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("98995afa-89ee-4633-8153-ebad7578067a"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7446), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("8f442ba5-a63e-4b68-85e9-71c52acb40a3"), 3.5, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7369), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("ea39755c-e87b-4594-9ba7-06f5d1504f8e"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7331), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("efcbcd89-e550-4c46-84f5-af8e004164df"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7242), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("4b4ee755-dfe6-435b-b60d-70b14086a5be"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7570), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("8ae2d224-cd8d-4371-a7ae-8ef53669b85f"), 16.0, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7534), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("f28ed774-cd9d-4df7-805c-fd9177c9c43c"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7646), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("7e459076-4749-446a-89e7-aaad4073266d"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7680), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("20a0fd6c-a728-479b-ad22-b5961d938c0e"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7876), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("13eabb02-a47c-4f3d-83ef-45cd4309bb60"), 3.5, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7932), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("9d882e77-cf3c-4459-a020-fb2b553f5c1e"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7967), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("e8bee7c2-7e93-4561-95a4-237b65497bed"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(8000), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("d042645b-7998-4f03-bd45-b0e56602e379"), 3.3999999999999999, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7603), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("cd710887-e37b-4811-8958-e0ebf6c507ef"), 3.5, new DateTime(2020, 5, 30, 19, 29, 14, 593, DateTimeKind.Utc).AddTicks(7498), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("37097e05-7252-4c0e-9c31-b8ee0f3444bd"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5381), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("1d28e63b-0076-4f90-9020-94087b905e68"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5559), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("cf327115-ec82-4761-842c-0e100cc1c5e1"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5540), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("99936816-537f-4534-bf92-f1ae378489fd"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5389), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("9290b8e2-602d-42ff-a5a1-5ded061bc6ff"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5374), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("3ba72bf4-daa2-427b-8ee3-918d5a47652a"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5353), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("43b19f31-cab0-464a-9406-515a4bb18275"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5346), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("7e68d01a-57b6-4fa2-9db9-04de32ce8fc3"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5338), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(3656), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("f092098a-dfde-4cb5-abfb-b3a649c4905b"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5222), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("d70c3cd7-e79d-43e7-9323-ed59da543466"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5272), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("f48883ba-7c67-447f-80eb-db84e3f610e9"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5281), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("15f20859-dd58-4735-9fab-e34964abfd35"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5289), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("e86db2aa-20cb-4583-a542-d90673338897"), new DateTime(2020, 5, 30, 19, 29, 14, 595, DateTimeKind.Utc).AddTicks(5361), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("59d6c728-0d68-468b-ac8f-53977d3abd3d"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4241), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("e53cbdfd-5f25-43a8-b332-cca846d3e7da"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4249), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("f65987f8-1f95-41b2-a51b-e9c6116096b7"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4257), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("9555b2e1-2eb0-42db-8240-ded80d05b447"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4266), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("12142283-c896-4721-a6ca-9bd519f4e32d"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4307), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("a85db421-faf4-4f8c-8a24-cab322580cd2"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4288), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("0c364dbb-ea83-41f9-8591-d0c1437a6348"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4295), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("fd7dcc7f-fbc4-487c-85be-e5c5167a49d4"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4301), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("65b0bc86-d851-4678-89a9-f9e27e4d2a04"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4314), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("99c57467-deef-4cdf-9785-f9a126980371"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4281), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("0c6f90ff-f1cf-4a38-957f-6e0a572d3c24"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4071), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("77b13441-db5e-4439-af40-b50badc3430b"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4055), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("e532ebbb-7b91-4e68-913c-10aa8468703f"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4048), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("b90ed963-a84f-4abd-9652-c572d0fd022a"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4034), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("4233ad98-5a45-45af-84e8-fe02330453cf"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4028), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("910374df-e73f-430d-8ee8-7c0b39d0e34d"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4021), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("69a624b5-f3b1-4b44-9527-04b6fb69f7a2"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4014), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("58a6fe7e-65a5-4f54-b6a5-1380e180e97d"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4007), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("791477ce-ae71-4d60-8ba7-7bcb85c1ec6b"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(3997), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("6d8a6782-aebc-4b55-a4a4-6badd3a03484"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(3990), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("fddd5170-e21f-403e-be87-2cda0af4aca7"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(3982), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("dad9a173-ada6-4c01-92f8-07d3d8ee5b69"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(3948), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("74cc8c95-dd81-4900-a743-6b12e8e11421"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(3921), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("3c07c81c-7f5a-4f2b-a999-88622480708f"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(3912), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("7a3a2cbf-6c7a-4984-a3a0-96960ef8fdbd"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(3876), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("f365f251-cb3e-457b-ab8e-7cfbf3af566c"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(2504), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("811c615c-1099-486d-af64-2c88b9f3fba0"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(4062), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("4542d3d2-0791-4082-b733-c1abf979104d"), new DateTime(2020, 5, 30, 19, 29, 14, 588, DateTimeKind.Utc).AddTicks(3929), null, null, false, false, null, "Whiskey", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "BarImageURL", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Phone", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("1f6b2605-df56-4c7d-a560-1dd3baa9fc8b"), "The Savoy Strand London WC2R 0EZ", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(541), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("5983ba59-b4d2-4f4b-a792-a95485490449"), "Av. �lvaro Obreg�n 106 Cuauht�moc", "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("99936816-537f-4534-bf92-f1ae378489fd"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3630), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, null },
                    { new Guid("2c38963d-d24e-4d4c-939d-b9498b3a7f9c"), "500 Arguello Street Redwood City", "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("37097e05-7252-4c0e-9c31-b8ee0f3444bd"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3569), null, false, null, "High Five", "(844) 464-4445", 0, null },
                    { new Guid("36140889-3b89-4e8e-a371-76e7305c5e4a"), "52 Rue de Saintonge Paris", "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("9290b8e2-602d-42ff-a5a1-5ded061bc6ff"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3857), null, false, null, "Candelaria", "+34 910 00 61", 0, null },
                    { new Guid("05dbe0ff-76d8-49f8-b97a-56a453c77294"), "60 Rue Charlot Paris", "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("9290b8e2-602d-42ff-a5a1-5ded061bc6ff"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3442), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, null },
                    { new Guid("6eab7982-a2c5-4ebe-af47-4eaad64b4b7f"), "579 Fuxing Zhong Lu", "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("e86db2aa-20cb-4583-a542-d90673338897"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3255), null, false, null, "Speak Low", "6416 0133", 0, null },
                    { new Guid("46b0f9a5-2e33-4c03-a970-dcd68e7b7091"), "Praxitelous 30 Athens", "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("3ba72bf4-daa2-427b-8ee3-918d5a47652a"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3108), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, null },
                    { new Guid("b16bc91b-8f06-4d43-8b4c-b1840c489779"), "Paceville Main Staircase St Julian's", "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("43b19f31-cab0-464a-9406-515a4bb18275"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(2949), null, false, null, "Native", "+356 2138 0635", 0, null },
                    { new Guid("f5cfd300-b4ed-4e9d-b76e-bfef6e603889"), "Calle Echegaray 21 28014 Madrid", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("7e68d01a-57b6-4fa2-9db9-04de32ce8fc3"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(2853), null, false, null, "Salmon Guru", "+34 910 00 61", 0, null },
                    { new Guid("65edee4d-d292-4c2e-849a-dc98542e33ff"), "37 Aberdeen Street Central", "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("15f20859-dd58-4735-9fab-e34964abfd35"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(2802), null, false, null, "The Old Man", "85227031899", 0, null },
                    { new Guid("c4585112-c231-4e3c-a58c-f4bd06f54bb9"), "7 Ann Siang Hill", "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("f48883ba-7c67-447f-80eb-db84e3f610e9"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(4073), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, null },
                    { new Guid("386fee40-8fa7-45e5-b164-a11020ddb7f6"), "Parkview Square", "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("f48883ba-7c67-447f-80eb-db84e3f610e9"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3677), null, false, null, "Atlas", "+65 6396 4466", 0, null },
                    { new Guid("1b7dd6bb-b08e-418a-9261-115e08fbfab1"), "1 Cuscaden Road 249715", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("f48883ba-7c67-447f-80eb-db84e3f610e9"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(2678), null, false, null, "Manhattan", "+65 6725 3377", 0, null },
                    { new Guid("afddc9f3-9b16-4eaa-9ca7-8e8e895eacf0"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("d70c3cd7-e79d-43e7-9323-ed59da543466"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(2630), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, null },
                    { new Guid("813d9e57-baa0-4d0d-a6ba-3dcf8682c475"), "2727 Indian Creek Dr. Miami Beach", "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("f092098a-dfde-4cb5-abfb-b3a649c4905b"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3801), null, false, null, "Broken Shaker", "305-531-2727", 0, null },
                    { new Guid("72ac75bf-1cae-42d7-ab7a-1385ba699385"), "79-81 MacDougal St New York", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("f092098a-dfde-4cb5-abfb-b3a649c4905b"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3720), null, false, null, "Dante", "01 55 5264 4122", 0, null },
                    { new Guid("ba696f0d-bac8-4564-8362-f0e2cd201b55"), "134 Eldridge Street New York", "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("f092098a-dfde-4cb5-abfb-b3a649c4905b"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3157), null, false, null, "Attaboy", "+36 1 792 2222", 0, null },
                    { new Guid("d779c50c-128c-4e15-93c1-47bef362988f"), "", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("f092098a-dfde-4cb5-abfb-b3a649c4905b"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3063), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("3d7f8c6f-e1de-43ce-9cf4-6ab4732dea3b"), "531 Hudson St New York", "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("f092098a-dfde-4cb5-abfb-b3a649c4905b"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(2898), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("4627c0c6-e6e0-4579-bbdc-1366326dc734"), "1170 BROADWAY & 28TH STREET NEW YORK", "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("f092098a-dfde-4cb5-abfb-b3a649c4905b"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(2514), null, false, null, "The NoMad", "(347) 472-5660", 0, null },
                    { new Guid("71374f8f-b346-4428-98ec-bd7f253d9411"), "Point Square North Dock Dublin", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3971), null, false, null, "The Gibson", "+353 1 681 5000", 0, null },
                    { new Guid("4beca65c-2351-4ce8-8ce2-ca695e3db9a9"), "61�63. Meaden, London", "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3759), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("18057c24-2f9d-46e2-b9f5-c8b0e9de7a02"), "8-9 Hoxton Square London", "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3488), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, null },
                    { new Guid("82abac38-0644-430e-8934-11c047ee1784"), "Soho, London", "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3197), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, null },
                    { new Guid("b8694a44-4903-4d59-bf2c-ee3fabf52bd0"), "20 Upper Ground South Bank London SE1 9PD", "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3019), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("27ebf159-9152-4f09-84a0-1756241799ac"), "The Connaught Carlos Place Mayfair London", "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(2729), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("858bd107-e575-4cb4-8b3f-99985a3d71b5"), "Storgata 27 Oslo", "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("cf327115-ec82-4761-842c-0e100cc1c5e1"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(3918), null, false, null, "Himkok", "+47 22 42 22 02", 0, null },
                    { new Guid("eb2a214b-ac66-4ec1-90c2-d90d29d53be2"), "304 BRUNSWICK ST", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("1d28e63b-0076-4f90-9020-94087b905e68"), new DateTime(2020, 5, 30, 19, 29, 14, 600, DateTimeKind.Utc).AddTicks(4032), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("05dbe0ff-76d8-49f8-b97a-56a453c77294"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("18057c24-2f9d-46e2-b9f5-c8b0e9de7a02"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("1b7dd6bb-b08e-418a-9261-115e08fbfab1"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("1f6b2605-df56-4c7d-a560-1dd3baa9fc8b"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("27ebf159-9152-4f09-84a0-1756241799ac"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("2c38963d-d24e-4d4c-939d-b9498b3a7f9c"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("36140889-3b89-4e8e-a371-76e7305c5e4a"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("386fee40-8fa7-45e5-b164-a11020ddb7f6"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("3d7f8c6f-e1de-43ce-9cf4-6ab4732dea3b"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("4627c0c6-e6e0-4579-bbdc-1366326dc734"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("46b0f9a5-2e33-4c03-a970-dcd68e7b7091"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("4beca65c-2351-4ce8-8ce2-ca695e3db9a9"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("5983ba59-b4d2-4f4b-a792-a95485490449"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("65edee4d-d292-4c2e-849a-dc98542e33ff"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("6eab7982-a2c5-4ebe-af47-4eaad64b4b7f"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("71374f8f-b346-4428-98ec-bd7f253d9411"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("72ac75bf-1cae-42d7-ab7a-1385ba699385"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("813d9e57-baa0-4d0d-a6ba-3dcf8682c475"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("82abac38-0644-430e-8934-11c047ee1784"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("858bd107-e575-4cb4-8b3f-99985a3d71b5"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("afddc9f3-9b16-4eaa-9ca7-8e8e895eacf0"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("b16bc91b-8f06-4d43-8b4c-b1840c489779"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("b8694a44-4903-4d59-bf2c-ee3fabf52bd0"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("ba696f0d-bac8-4564-8362-f0e2cd201b55"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("c4585112-c231-4e3c-a58c-f4bd06f54bb9"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("d779c50c-128c-4e15-93c1-47bef362988f"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("eb2a214b-ac66-4ec1-90c2-d90d29d53be2"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("f5cfd300-b4ed-4e9d-b76e-bfef6e603889"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("045716bd-a319-462a-ae26-699baed44fe8"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("13eabb02-a47c-4f3d-83ef-45cd4309bb60"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("20a0fd6c-a728-479b-ad22-b5961d938c0e"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("4b4ee755-dfe6-435b-b60d-70b14086a5be"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("5feda36f-7b61-427b-9fb5-32755abdd145"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("619e84e5-51b3-40e5-9a55-908369e0dc3d"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("6636c210-793b-4ef9-97f8-5d7c7454c171"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("7af2a344-28ba-411f-bdbc-35157ce31d70"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("7e459076-4749-446a-89e7-aaad4073266d"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("8ae2d224-cd8d-4371-a7ae-8ef53669b85f"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("8f442ba5-a63e-4b68-85e9-71c52acb40a3"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("90e59c84-d13d-4d41-993c-bd7fdaefa97c"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("913957bd-2a80-4bfe-923e-2edcac57c8aa"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("98995afa-89ee-4633-8153-ebad7578067a"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("9d882e77-cf3c-4459-a020-fb2b553f5c1e"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("a54649c5-d60f-485a-9732-ae955eff4539"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("ae4b7f04-6fae-4b41-8db3-94e8bac8ad55"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("b88351b4-2fbf-49bc-a0d1-51de08393b89"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("c41df1ec-2325-4b12-9a40-278e2388635f"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("cd710887-e37b-4811-8958-e0ebf6c507ef"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("d042645b-7998-4f03-bd45-b0e56602e379"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("d580f017-b2a4-4c91-9f9e-8c3e3aa11581"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("e8bee7c2-7e93-4561-95a4-237b65497bed"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("ea39755c-e87b-4594-9ba7-06f5d1504f8e"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("eb0b35ea-36f1-48fc-81fc-81c409cf3c6d"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("efcbcd89-e550-4c46-84f5-af8e004164df"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("f28ed774-cd9d-4df7-805c-fd9177c9c43c"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("f71dff4f-7f82-400b-9733-ba9095a52a9a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("0c364dbb-ea83-41f9-8591-d0c1437a6348"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("0c6f90ff-f1cf-4a38-957f-6e0a572d3c24"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("12142283-c896-4721-a6ca-9bd519f4e32d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("3c07c81c-7f5a-4f2b-a999-88622480708f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("4233ad98-5a45-45af-84e8-fe02330453cf"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("4542d3d2-0791-4082-b733-c1abf979104d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("58a6fe7e-65a5-4f54-b6a5-1380e180e97d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("59d6c728-0d68-468b-ac8f-53977d3abd3d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("65b0bc86-d851-4678-89a9-f9e27e4d2a04"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("69a624b5-f3b1-4b44-9527-04b6fb69f7a2"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("6d8a6782-aebc-4b55-a4a4-6badd3a03484"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("74cc8c95-dd81-4900-a743-6b12e8e11421"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("77b13441-db5e-4439-af40-b50badc3430b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("791477ce-ae71-4d60-8ba7-7bcb85c1ec6b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("7a3a2cbf-6c7a-4984-a3a0-96960ef8fdbd"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("811c615c-1099-486d-af64-2c88b9f3fba0"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("910374df-e73f-430d-8ee8-7c0b39d0e34d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("9555b2e1-2eb0-42db-8240-ded80d05b447"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("99c57467-deef-4cdf-9785-f9a126980371"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a85db421-faf4-4f8c-8a24-cab322580cd2"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b90ed963-a84f-4abd-9652-c572d0fd022a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("dad9a173-ada6-4c01-92f8-07d3d8ee5b69"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e532ebbb-7b91-4e68-913c-10aa8468703f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e53cbdfd-5f25-43a8-b332-cca846d3e7da"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f365f251-cb3e-457b-ab8e-7cfbf3af566c"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f65987f8-1f95-41b2-a51b-e9c6116096b7"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("fd7dcc7f-fbc4-487c-85be-e5c5167a49d4"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("fddd5170-e21f-403e-be87-2cda0af4aca7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("15f20859-dd58-4735-9fab-e34964abfd35"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1d28e63b-0076-4f90-9020-94087b905e68"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("37097e05-7252-4c0e-9c31-b8ee0f3444bd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a18a531-9bb4-4db7-b8c0-d4605305ef96"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3ba72bf4-daa2-427b-8ee3-918d5a47652a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("43b19f31-cab0-464a-9406-515a4bb18275"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("7e68d01a-57b6-4fa2-9db9-04de32ce8fc3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9290b8e2-602d-42ff-a5a1-5ded061bc6ff"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("99936816-537f-4534-bf92-f1ae378489fd"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("cf327115-ec82-4761-842c-0e100cc1c5e1"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("d70c3cd7-e79d-43e7-9323-ed59da543466"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e86db2aa-20cb-4583-a542-d90673338897"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f092098a-dfde-4cb5-abfb-b3a649c4905b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f48883ba-7c67-447f-80eb-db84e3f610e9"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"),
                column: "ConcurrencyStamp",
                value: "fee3fc94-ad60-468d-9ee3-74f888506891");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"),
                column: "ConcurrencyStamp",
                value: "ddba1eff-0b3d-4410-9178-38f04b0408ad");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"),
                column: "ConcurrencyStamp",
                value: "a774b827-f60d-4121-83b1-0f5ec9d0133f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2fa0c457-2f0d-4773-a169-bdb2c3e81c90", "AQAAAAEAACcQAAAAEErG+icRCLXXHfumn4UlpBBl28pcOvDaTNoU/n5GbshZUR41e7oMFX8x/8HY5bdkWQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ac91355b-6eab-4d77-b51e-1404cfa5d8bf", "AQAAAAEAACcQAAAAEMolC+3A2Z9F06BvXo1DVgujh22O3syYSTHv/xPGLV2qD2nu+gy+sPTgFDwUukc04A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "84e2cdc7-73af-40af-88ef-0a7ec3bbb2b3", "AQAAAAEAACcQAAAAEOUh86/s5wHq+WDAjk0XHEftCfz77qTC7TyqxkL3NicWt7cbv2ZlqoC+FrOHUL+UOQ==" });
        }
    }
}
