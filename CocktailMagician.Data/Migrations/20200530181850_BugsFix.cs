using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class BugsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"),
                column: "ConcurrencyStamp",
                value: "e3287f44-994b-40b6-966e-fcc4f32df66f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"),
                column: "ConcurrencyStamp",
                value: "8f23a71d-592a-47c6-9a35-70167e4a3c93");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"),
                column: "ConcurrencyStamp",
                value: "c75822a5-ef8e-496b-8702-6790a7e100e6");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "56387f21-609b-4915-a3ee-1efb09db0f1c", "AQAAAAEAACcQAAAAEKjTpi+wjUNwj2aJFmA2FT9sZAnR+c7mFwIqpt1cdJR8fKZdKhLS+h9qKJlFgcMnRw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c9052020-fd26-49f9-a77b-ab57e045c5ec", "AQAAAAEAACcQAAAAENtyR7k9XqfbI9SUgECYGXhxWEqiRukS+amE+vdBnevFq4Qm70+YUFMEwy7pRk4Z3A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a3d1e74d-6564-42b3-8ff4-7a209eaabbfb", "AQAAAAEAACcQAAAAEETAy57nmlmxDEbzpFlGUEouUXsqObsr6+Lftmt+WX9CYuIbzcB3EnhhowSMn3z3fQ==" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("a8ce69cd-46d2-4544-a0fd-5ee78504e18f"), 4.2000000000000002, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4330), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("c7888df6-6738-41f5-9e21-59c54b005a5a"), 4.5, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4343), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("8b0f50fb-05ba-4d00-82e9-f749258c775e"), 7.2999999999999998, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4357), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("62ee9d1a-9cc0-436b-94c8-f4a9abeb5a3f"), 7.2000000000000002, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4371), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("851250a8-b89b-4706-bd20-c31337338e25"), 16.0, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4418), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("815c4db9-e241-4b21-ba6d-5f76b09de303"), 12.699999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4402), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("d9e4363a-fd79-4074-85f2-46c136f8d9bc"), 4.0999999999999996, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4315), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("dcd836a3-c090-431f-b292-5e3b4b9f59c3"), 12.699999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4439), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("1f7fc84f-2913-42e9-ad6c-ffbf2a3c5b8a"), 2.5, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4455), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("267b2e3f-d348-438c-a344-076397e00b2c"), 7.4000000000000004, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4385), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("71109aa8-8699-4b6b-90eb-62ea4e21e719"), 3.8999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4296), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("f7fe758b-44ea-40b0-a006-8082ff04b2b0"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(2833), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("4e9e31d2-35ea-4294-bb3c-1e311ad68b10"), 3.7999999999999998, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4260), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("18a48bd2-e3a1-4e12-add0-7850102eb6bf"), 3.7999999999999998, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4277), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("9723f7a9-a2a9-48e1-8019-ce4eec81a6ec"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4048), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("fcb80628-c39b-4453-9f7c-11903c396058"), 3.5, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4031), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("f78e587a-db7f-40d9-834b-85863defeee1"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4016), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("abe7c45d-2969-4a65-b93e-803111290cb3"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(3950), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("8fe69882-5dde-4993-bf15-61dab2f6744b"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4104), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("7c6996a0-1c13-4422-800d-cf123b3ea064"), 16.0, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4088), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("a4e08e21-3cf1-45e1-9911-1bcf4a9e256c"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4166), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("09db526c-a0f2-4f6a-9903-596fb307d6b4"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4188), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("30d90639-8721-40dd-b671-36b12c6421d8"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4203), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("1db5b89f-dca4-44a2-a15a-4476dd2e767c"), 3.5, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4217), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("62a9f2d6-a4df-4593-a1b8-def1257faa68"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4230), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("eaa2712e-1ebb-462e-ba33-652eef67c74d"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4245), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("0dd1b9d4-ca2b-4b02-909f-f5512fa4ab7c"), 3.3999999999999999, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4147), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("aee2d883-515e-48a9-be11-c33aeb053e26"), 3.5, new DateTime(2020, 5, 30, 18, 18, 49, 655, DateTimeKind.Utc).AddTicks(4073), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("83c37c68-e664-4eb9-930a-b25400befb6f"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3565), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("60a6e97e-e510-411e-9fcc-a3a5cb5da033"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3576), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("bed1ed56-39ba-4f4b-b131-54b6352b0681"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3572), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("49dfda25-b4a2-4650-88dd-afb7be04a6e7"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3569), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("1d2ef8b9-0783-4ac1-a33b-12c1e62259a2"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3561), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("f4da782d-f480-4ad0-a5b7-a8b74ff0e031"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3550), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("b488ac52-efca-45fc-8d81-1fa9a7c1ca52"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3546), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("e39b711b-b08d-4241-b38e-0197bb741274"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3531), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(2550), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("5cf0b811-fa86-4b5a-b17e-00e7d9f806c0"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3486), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("efc8deac-1169-4cb8-9e66-6078ecfca14d"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3504), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("461694cf-9145-4553-b0da-2633780a0a6a"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3509), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("a29b359f-dfeb-40dd-8986-302aa20c7d9a"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3513), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("6987d286-070e-4edd-a66f-26dd2e946791"), new DateTime(2020, 5, 30, 18, 18, 49, 656, DateTimeKind.Utc).AddTicks(3555), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("8d46c370-9cad-4cce-bd34-343aadcd4ead"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6744), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("5ce80936-703b-4f12-9b92-6966333b8175"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6748), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("6a1a8eaf-3020-4448-a453-1e712ba1be29"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6752), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("9c891ea5-c3cd-45cb-b8d6-54ab4c4f9337"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6755), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("3e467fed-253c-468b-9478-96f9949a9bc7"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6778), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("2c48781c-0473-4663-bdbe-e9a527182892"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6767), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("0a1f014f-b14a-4294-9482-c4ad7e4336ab"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6771), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("0ec6eff7-262b-4978-8bec-db13cc2e73b0"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6774), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("83405c7e-6ad3-4695-91e3-6d6cf4d86e38"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6782), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("6a7c131d-4fcc-47d2-ae02-784f4583c61e"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6759), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("74a66304-9112-4fce-a955-edb6ed38b935"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6740), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("390206ba-5797-4b29-93f5-72e2d8b33527"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6729), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("b1af8791-2e06-4c04-b588-46f46d37dd7c"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6719), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("93002dc3-3d63-4376-9ade-adf694b339be"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6715), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("d4ebf6eb-9ad0-4a5e-90f6-b4a0e238eda0"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6697), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("7d34ab7c-2f35-4d8a-aa7d-2191b0a7b256"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6693), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("fa8480ce-2fc8-40ec-b36f-78da8deac49a"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6689), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("d01a308c-1ecc-4240-9628-590a4fc92d8d"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6685), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("e8e7507c-c3f2-47bd-86ea-5a1807205e6b"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6678), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("2de69e8b-f8af-4658-8de8-ce93838459c5"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6672), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("8c14bf15-7631-472a-90dd-f5bf61db90ab"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6641), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("c7ccb1ee-630a-49ea-8afd-456e7542d5b2"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6636), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("a2566bed-c66f-41d7-a501-9f701937224a"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6588), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("cba7231a-af3f-4093-8bc2-e878cc88ca63"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6583), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("e5abeda6-34d9-4fdb-8b19-1c312422b89e"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6563), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("d48bff41-ce1c-4995-bd2e-a3b2bae19a95"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(5571), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("2e89913b-2250-407b-a357-7c133e14f513"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6733), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("2840d774-ddac-49ac-8969-0704a4b83364"), new DateTime(2020, 5, 30, 18, 18, 49, 651, DateTimeKind.Utc).AddTicks(6592), null, null, false, false, null, "Whiskey", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "BarImageURL", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Phone", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("0845c78c-e844-45fb-8f3f-949185d895b8"), "The Savoy Strand London WC2R 0EZ", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(5144), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("cfc7d35b-4043-4675-8286-3fc7981f7123"), "Av. �lvaro Obreg�n 106 Cuauht�moc", "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("49dfda25-b4a2-4650-88dd-afb7be04a6e7"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6815), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, null },
                    { new Guid("df2ab243-9b3a-43cd-bb89-6e7b73b2843f"), "500 Arguello Street Redwood City", "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("83c37c68-e664-4eb9-930a-b25400befb6f"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6787), null, false, null, "High Five", "(844) 464-4445", 0, null },
                    { new Guid("6cf9bb16-9ac5-49e5-9b88-f5c7436e92cb"), "52 Rue de Saintonge Paris", "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("1d2ef8b9-0783-4ac1-a33b-12c1e62259a2"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6919), null, false, null, "Candelaria", "+34 910 00 61", 0, null },
                    { new Guid("c3d72af9-8309-48ec-857f-b5a85c3880b2"), "60 Rue Charlot Paris", "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("1d2ef8b9-0783-4ac1-a33b-12c1e62259a2"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6724), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, null },
                    { new Guid("17914882-7f57-422b-89e2-8bf21f993fd6"), "579 Fuxing Zhong Lu", "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("6987d286-070e-4edd-a66f-26dd2e946791"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6697), null, false, null, "Speak Low", "6416 0133", 0, null },
                    { new Guid("8086dcf7-437d-44a4-be70-99fb27bbeb05"), "Praxitelous 30 Athens", "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("f4da782d-f480-4ad0-a5b7-a8b74ff0e031"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6612), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, null },
                    { new Guid("e7793bdf-4d1d-4c28-bcb4-5275d0572b62"), "Paceville Main Staircase St Julian's", "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("b488ac52-efca-45fc-8d81-1fa9a7c1ca52"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6542), null, false, null, "Native", "+356 2138 0635", 0, null },
                    { new Guid("d2ec0227-81d4-495e-be0d-29dd7012eae1"), "Calle Echegaray 21 28014 Madrid", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("e39b711b-b08d-4241-b38e-0197bb741274"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6482), null, false, null, "Salmon Guru", "+34 910 00 61", 0, null },
                    { new Guid("136436e6-2f72-4a66-a0ed-f0355b3ad8be"), "37 Aberdeen Street Central", "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("a29b359f-dfeb-40dd-8986-302aa20c7d9a"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6458), null, false, null, "The Old Man", "85227031899", 0, null },
                    { new Guid("96af0a66-1a4d-4c02-9b6f-58ffa2e31595"), "7 Ann Siang Hill", "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("461694cf-9145-4553-b0da-2633780a0a6a"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(7023), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, null },
                    { new Guid("6cf95559-aeda-44d5-a73a-f999bd20cf5c"), "Parkview Square", "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("461694cf-9145-4553-b0da-2633780a0a6a"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6837), null, false, null, "Atlas", "+65 6396 4466", 0, null },
                    { new Guid("6718b907-00fe-4d32-8a7b-74f879561b6e"), "1 Cuscaden Road 249715", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("461694cf-9145-4553-b0da-2633780a0a6a"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6408), null, false, null, "Manhattan", "+65 6725 3377", 0, null },
                    { new Guid("239f188e-d794-4da0-85d1-ef01e53a66d3"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("efc8deac-1169-4cb8-9e66-6078ecfca14d"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6384), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, null },
                    { new Guid("a1f66055-e31e-4061-84d3-7e73a4499dd2"), "2727 Indian Creek Dr. Miami Beach", "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("5cf0b811-fa86-4b5a-b17e-00e7d9f806c0"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6893), null, false, null, "Broken Shaker", "305-531-2727", 0, null },
                    { new Guid("b3c4022c-9cbc-4385-be97-b46ca770d6ed"), "79-81 MacDougal St New York", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("5cf0b811-fa86-4b5a-b17e-00e7d9f806c0"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6856), null, false, null, "Dante", "01 55 5264 4122", 0, null },
                    { new Guid("0d4b6557-12b2-4dc2-8631-7779e923ef82"), "134 Eldridge Street New York", "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("5cf0b811-fa86-4b5a-b17e-00e7d9f806c0"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6648), null, false, null, "Attaboy", "+36 1 792 2222", 0, null },
                    { new Guid("0b516a7d-b831-465b-af4c-3efbe8706227"), "", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("5cf0b811-fa86-4b5a-b17e-00e7d9f806c0"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6587), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("11f010b2-14fc-4c31-afaa-78ea18385832"), "531 Hudson St New York", "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("5cf0b811-fa86-4b5a-b17e-00e7d9f806c0"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6503), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("6ea5a1ee-3dc1-458a-b4da-abb8ed25d44e"), "1170 BROADWAY & 28TH STREET NEW YORK", "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("5cf0b811-fa86-4b5a-b17e-00e7d9f806c0"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6329), null, false, null, "The NoMad", "(347) 472-5660", 0, null },
                    { new Guid("5b55a3bb-ef92-4ed3-881f-444e355485a5"), "Point Square North Dock Dublin", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6974), null, false, null, "The Gibson", "+353 1 681 5000", 0, null },
                    { new Guid("44f08583-cc41-4da7-8d6c-c7b885dacd87"), "61�63. Meaden, London", "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6874), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("9a1e5cd9-8f53-4064-9e5a-1d1b4f0bc0c1"), "8-9 Hoxton Square London", "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6752), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, null },
                    { new Guid("00300c3b-adb5-418f-a704-d4771429c6c5"), "Soho, London", "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6669), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, null },
                    { new Guid("4496c7e8-a7bc-41c0-a208-64661a78b607"), "20 Upper Ground South Bank London SE1 9PD", "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6566), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("946d99c6-cd31-410c-b815-df6439968e91"), "The Connaught Carlos Place Mayfair London", "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6429), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("7f2e959e-208e-4c85-af00-5c39cd48126e"), "Storgata 27 Oslo", "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("bed1ed56-39ba-4f4b-b131-54b6352b0681"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(6954), null, false, null, "Himkok", "+47 22 42 22 02", 0, null },
                    { new Guid("fd0e9b86-0110-446b-bf05-7a0faceb4e4e"), "304 BRUNSWICK ST", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("60a6e97e-e510-411e-9fcc-a3a5cb5da033"), new DateTime(2020, 5, 30, 18, 18, 49, 658, DateTimeKind.Utc).AddTicks(7004), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("00300c3b-adb5-418f-a704-d4771429c6c5"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("0845c78c-e844-45fb-8f3f-949185d895b8"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("0b516a7d-b831-465b-af4c-3efbe8706227"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("0d4b6557-12b2-4dc2-8631-7779e923ef82"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("11f010b2-14fc-4c31-afaa-78ea18385832"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("136436e6-2f72-4a66-a0ed-f0355b3ad8be"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("17914882-7f57-422b-89e2-8bf21f993fd6"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("239f188e-d794-4da0-85d1-ef01e53a66d3"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("4496c7e8-a7bc-41c0-a208-64661a78b607"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("44f08583-cc41-4da7-8d6c-c7b885dacd87"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("5b55a3bb-ef92-4ed3-881f-444e355485a5"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("6718b907-00fe-4d32-8a7b-74f879561b6e"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("6cf95559-aeda-44d5-a73a-f999bd20cf5c"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("6cf9bb16-9ac5-49e5-9b88-f5c7436e92cb"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("6ea5a1ee-3dc1-458a-b4da-abb8ed25d44e"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("7f2e959e-208e-4c85-af00-5c39cd48126e"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("8086dcf7-437d-44a4-be70-99fb27bbeb05"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("946d99c6-cd31-410c-b815-df6439968e91"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("96af0a66-1a4d-4c02-9b6f-58ffa2e31595"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("9a1e5cd9-8f53-4064-9e5a-1d1b4f0bc0c1"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("a1f66055-e31e-4061-84d3-7e73a4499dd2"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("b3c4022c-9cbc-4385-be97-b46ca770d6ed"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("c3d72af9-8309-48ec-857f-b5a85c3880b2"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("cfc7d35b-4043-4675-8286-3fc7981f7123"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("d2ec0227-81d4-495e-be0d-29dd7012eae1"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("df2ab243-9b3a-43cd-bb89-6e7b73b2843f"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("e7793bdf-4d1d-4c28-bcb4-5275d0572b62"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("fd0e9b86-0110-446b-bf05-7a0faceb4e4e"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("09db526c-a0f2-4f6a-9903-596fb307d6b4"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("0dd1b9d4-ca2b-4b02-909f-f5512fa4ab7c"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("18a48bd2-e3a1-4e12-add0-7850102eb6bf"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("1db5b89f-dca4-44a2-a15a-4476dd2e767c"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("1f7fc84f-2913-42e9-ad6c-ffbf2a3c5b8a"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("267b2e3f-d348-438c-a344-076397e00b2c"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("30d90639-8721-40dd-b671-36b12c6421d8"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("4e9e31d2-35ea-4294-bb3c-1e311ad68b10"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("62a9f2d6-a4df-4593-a1b8-def1257faa68"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("62ee9d1a-9cc0-436b-94c8-f4a9abeb5a3f"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("71109aa8-8699-4b6b-90eb-62ea4e21e719"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("7c6996a0-1c13-4422-800d-cf123b3ea064"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("815c4db9-e241-4b21-ba6d-5f76b09de303"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("851250a8-b89b-4706-bd20-c31337338e25"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("8b0f50fb-05ba-4d00-82e9-f749258c775e"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("8fe69882-5dde-4993-bf15-61dab2f6744b"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("9723f7a9-a2a9-48e1-8019-ce4eec81a6ec"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("a4e08e21-3cf1-45e1-9911-1bcf4a9e256c"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("a8ce69cd-46d2-4544-a0fd-5ee78504e18f"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("abe7c45d-2969-4a65-b93e-803111290cb3"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("aee2d883-515e-48a9-be11-c33aeb053e26"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("c7888df6-6738-41f5-9e21-59c54b005a5a"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("d9e4363a-fd79-4074-85f2-46c136f8d9bc"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("dcd836a3-c090-431f-b292-5e3b4b9f59c3"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("eaa2712e-1ebb-462e-ba33-652eef67c74d"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("f78e587a-db7f-40d9-834b-85863defeee1"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("f7fe758b-44ea-40b0-a006-8082ff04b2b0"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("fcb80628-c39b-4453-9f7c-11903c396058"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("0a1f014f-b14a-4294-9482-c4ad7e4336ab"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("0ec6eff7-262b-4978-8bec-db13cc2e73b0"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("2840d774-ddac-49ac-8969-0704a4b83364"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("2c48781c-0473-4663-bdbe-e9a527182892"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("2de69e8b-f8af-4658-8de8-ce93838459c5"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("2e89913b-2250-407b-a357-7c133e14f513"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("390206ba-5797-4b29-93f5-72e2d8b33527"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("3e467fed-253c-468b-9478-96f9949a9bc7"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("5ce80936-703b-4f12-9b92-6966333b8175"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("6a1a8eaf-3020-4448-a453-1e712ba1be29"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("6a7c131d-4fcc-47d2-ae02-784f4583c61e"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("74a66304-9112-4fce-a955-edb6ed38b935"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("7d34ab7c-2f35-4d8a-aa7d-2191b0a7b256"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("83405c7e-6ad3-4695-91e3-6d6cf4d86e38"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("8c14bf15-7631-472a-90dd-f5bf61db90ab"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("8d46c370-9cad-4cce-bd34-343aadcd4ead"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("93002dc3-3d63-4376-9ade-adf694b339be"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("9c891ea5-c3cd-45cb-b8d6-54ab4c4f9337"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a2566bed-c66f-41d7-a501-9f701937224a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b1af8791-2e06-4c04-b588-46f46d37dd7c"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c7ccb1ee-630a-49ea-8afd-456e7542d5b2"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("cba7231a-af3f-4093-8bc2-e878cc88ca63"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d01a308c-1ecc-4240-9628-590a4fc92d8d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d48bff41-ce1c-4995-bd2e-a3b2bae19a95"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d4ebf6eb-9ad0-4a5e-90f6-b4a0e238eda0"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e5abeda6-34d9-4fdb-8b19-1c312422b89e"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e8e7507c-c3f2-47bd-86ea-5a1807205e6b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("fa8480ce-2fc8-40ec-b36f-78da8deac49a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("1d2ef8b9-0783-4ac1-a33b-12c1e62259a2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("461694cf-9145-4553-b0da-2633780a0a6a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("49dfda25-b4a2-4650-88dd-afb7be04a6e7"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("5cf0b811-fa86-4b5a-b17e-00e7d9f806c0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("60a6e97e-e510-411e-9fcc-a3a5cb5da033"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6987d286-070e-4edd-a66f-26dd2e946791"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("83c37c68-e664-4eb9-930a-b25400befb6f"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("958916e6-355a-40a6-be2a-6d29e421db7d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("a29b359f-dfeb-40dd-8986-302aa20c7d9a"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b488ac52-efca-45fc-8d81-1fa9a7c1ca52"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("bed1ed56-39ba-4f4b-b131-54b6352b0681"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e39b711b-b08d-4241-b38e-0197bb741274"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("efc8deac-1169-4cb8-9e66-6078ecfca14d"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f4da782d-f480-4ad0-a5b7-a8b74ff0e031"));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"),
                column: "ConcurrencyStamp",
                value: "ffda97a7-dfcc-4d7e-a271-7d4f072ded06");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"),
                column: "ConcurrencyStamp",
                value: "26ea202b-e19c-4a05-b697-a700699d7195");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"),
                column: "ConcurrencyStamp",
                value: "8859e52e-7892-40ed-8756-d9222a41c20b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b670d0e5-9842-4d1b-99f2-ddfb8de967d9", "AQAAAAEAACcQAAAAEGNcCAshvPAe1kbaS+FQvE2FCGXI7T67iXa6g4UZCFQB5IFM4mzfnvXKhuPOSq9eyQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9ab1df9e-499b-4407-964b-b220aabd4b99", "AQAAAAEAACcQAAAAED5vmOtaA9qYbn8r6Y+Xi6BcoE5z2PGb0qD+3lrwNCuaQF368jLBxSirc6J0SYN8Eg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "72c44e72-acc3-44f6-977d-5d73219bc646", "AQAAAAEAACcQAAAAEL759HzU2lkb0ShHesQqfUDM8Z/guTdj2/FrKMm8P6kNYef5MqnVd+jGDuRzFK+o9Q==" });
        }
    }
}
