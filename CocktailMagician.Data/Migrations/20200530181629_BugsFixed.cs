using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class BugsFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("02023021-7e81-4941-a8d2-4fc33590f2c4"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("07869b06-b74f-4652-91a5-9d8e0eaed288"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("11b8511f-936b-4f90-9c3d-d76f445129c5"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("185222b5-45f9-4777-a7bc-d71d31929b15"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("18f574da-94db-42fe-abc5-4a1bfc244270"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("225f0468-42c4-4612-9dba-2ccd1b7bc83f"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("3284c2da-51e5-47b8-8b6c-095b803f46d2"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("4e685008-0a8b-4262-9bc7-82acc23e4a77"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("4f21d388-d018-41be-9cf4-85822f148d75"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("5fd19100-8d44-4167-8ed0-c029adc4883c"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("65ee9998-f59f-436d-9cd8-d82bd07fd044"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("68a95b21-18e2-4f27-8031-853f019a4acf"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("6b3d7f6c-0eba-4678-965c-5b2939ff7995"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("78191da4-2d4a-4b2d-bdc7-140d5dfa0729"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("8316949c-5913-4b48-bf66-279e2b3d58c9"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("88d460df-756e-42ed-930c-5ae7fab8d721"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("894c4305-519c-4471-b5e7-bc8c686abab1"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("96f9515a-3061-4259-8dc8-d701ae10458b"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("996c4768-1731-4a4d-9d93-209db8764078"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("9a8700da-6105-4c8e-8a3c-eebe0f64552b"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("abec7768-05f9-4227-b268-0a517a92aa4d"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("b1151c1b-8c95-4a83-ad89-7cc1013264d0"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("b9988a7c-fec4-4fda-a40b-11d7f4de379e"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("c16870ca-f72f-4b42-ad5c-8a0abdb67464"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("cc07de3a-850f-4da6-ba04-3a6f0ed7bb6e"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("cc644dad-918f-4745-8496-26e08e571b1e"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("d0561021-c518-4c29-bd7e-52896eea7bcf"));

            migrationBuilder.DeleteData(
                table: "Bars",
                keyColumn: "Id",
                keyValue: new Guid("f25438cf-abcb-40ba-a823-ceadf095114e"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("18318f04-3b02-4803-b499-86a852ee87f4"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("196556f5-7a6d-45ca-a974-266c9e7b7535"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("1d068c49-f492-4177-b09a-b74eef2a9283"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("2114a475-366e-4d74-b1ed-413436eef019"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("24010530-18f4-41ee-9357-daa628b6ad2b"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("3f7554a9-9425-431f-8c41-735085ce0e1d"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("45126164-0ee0-4803-8cf3-1f6df79d6088"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("47d3cffa-1e4a-4d55-8943-ed8273a8ac15"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("5c85b6e3-b762-47d2-9685-3e681c48882d"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("5c9f41d4-a8c5-4e75-8689-2e616bbca2e3"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("6979cd15-1cf7-490d-bca8-3d5eec19b190"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("7696edab-a112-4ede-bd29-faece6e42c22"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("7d96f193-7b26-4ef3-932c-dcb0c392497a"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("9708ed85-0c43-43a9-b26f-61ad6839ecf7"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("a0b7d6fc-ec55-438e-baa6-28817ae10639"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("a68a838a-0b48-48c1-9d1d-3289126f2249"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("b0aab0a2-bc8a-4b97-9764-d75d38fa0588"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("c33c9dcd-5667-4591-b0a6-c5a52bdf6929"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("c4277d5e-e403-460c-ba33-e067f2e67c25"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("c7427fb1-0615-4292-a43d-87cbd7f65b27"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("c8ef69ba-03d9-4aaa-abf0-05a10f62aec8"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("d375c1dc-6dab-4fdc-a10f-4c258b33abf4"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("e4665999-f9de-4548-a84a-3f7061d5e110"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("e4743f82-678a-4806-bfb6-f8afba5462dc"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("e70f1f3a-aec0-433f-918b-ef482d515ffb"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("f0262cc8-c281-4700-8df7-fa3db0246c81"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("f2bb4b0a-cc20-41f2-a196-8f48ebab136e"));

            migrationBuilder.DeleteData(
                table: "Cocktails",
                keyColumn: "Id",
                keyValue: new Guid("f502b46e-a4f1-4f59-b510-89b73ab19884"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("1a441d2b-1fa8-45fb-b22e-cafc5f10d243"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("1f58d88f-5d33-41a8-a959-6a3628537209"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("23c962de-a093-4f87-b8ea-dba05e6bb46c"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("2eac126e-5856-4593-8a8e-d20ad1c83882"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("332d47d4-0fcb-4653-9347-9a833fd19c73"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("3dcc9bec-4f9f-4585-95bd-bf81848602d5"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("3e2ac263-08fe-4a21-b8f2-ee9ed94129c5"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("3f148195-eb63-466e-8cd3-11b40a8bdadf"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("5697efa1-d42a-4841-96d7-29dbb7c4458a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("5d90b87f-9977-4229-b9b9-5da2b9491f00"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("5ec83e69-78f2-49cc-a6fc-597822f5a3ba"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("7beffb57-16b9-4d4f-bcbe-aa0100a48616"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("80408ad5-b4f6-452d-8d71-145990eda1a2"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("82a85f66-2382-4e0e-9b3c-660c0cb1a598"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("88b3f4be-3249-40ce-b7f7-7352a1eb20a2"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("8f5287fd-16af-45d1-ad41-ced1a2bdad95"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("9aa3369a-abe9-4e83-bd51-9c07ccf636d9"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b839c1dd-d8a2-4c27-bbe8-e29a61e6d132"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b905b752-337c-419a-a2aa-8021b60a6656"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("bf1ae328-be44-4505-b39d-5648cc2b4ace"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d25158c1-cc2c-4003-a662-f83d1b54d3de"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d6f6c1e6-b17c-42db-b0ec-ed7372b24c7b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d83eee68-52da-48d8-a4b5-575e1fbc8269"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e60ceafa-bfea-4bb8-9994-e8289ab067a0"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e829051b-731c-49dc-b042-90f75727fcd8"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f2f78a88-fd9c-4e46-b181-6de2c51fb304"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f72e80c5-fae9-4743-baaa-7d27bff7b308"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f7c2ba57-1cea-4e1f-88c1-5b8285cf71d3"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("3a12cf75-ed3d-4c9b-8d97-950f599d448e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("4f22c01a-9d0e-40f0-b8fb-5dac3e6ca26b"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("673a66a4-90bc-436e-8b7d-df0e0c5afde2"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("6ef12378-4b01-4307-836c-cb6e6fd6e627"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("71777afc-e19f-482b-884f-f8beb1864d3e"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("85482ea4-271e-4bd9-8d7a-ddc5003806fc"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("982172f7-0b3d-4acc-b092-385ef514ac04"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("9f56e970-20fb-4284-8302-614dc81496b0"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("b1968897-ac64-4010-a2e0-04897300ce9c"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("ddcf1bb3-5ac1-4358-8741-be8c58be1506"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e535bcdf-f4ba-4897-9677-653671253b66"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("eeef9066-4245-4f07-947b-f9fdb662f903"));

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: new Guid("f3074417-e084-424f-8b77-ac26f7118bd2"));

            migrationBuilder.DropColumn(
                name: "Vote",
                table: "BarRatings");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "BarRatings",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "BarRatings");

            migrationBuilder.AddColumn<bool>(
                name: "Vote",
                table: "BarRatings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("01bc7e12-c30b-47d1-a0a0-b146bb93ccdb"),
                column: "ConcurrencyStamp",
                value: "a4688da0-18d4-4723-adba-c76c119ea26e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c611672d-5da5-43d3-bbbf-e897e4456cb9"),
                column: "ConcurrencyStamp",
                value: "31dd7f7d-5c9d-4829-9f5c-6ba93a599155");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f476e48e-0586-4f40-92b2-2279ce6f6db7"),
                column: "ConcurrencyStamp",
                value: "385fa6ba-83db-4e3d-8b81-c31cd532f5ae");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("4734cf2f-fcb8-461b-88dc-06152e89bc97"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "01b2188a-a2d1-4842-9653-617b76afb9c8", "AQAAAAEAACcQAAAAECDDrlBPMkr379/BApNMebNp27KXR7H9W0Pxpua4u0qlOeeScWh+BRMIfRJDDA0EkQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5874617e-289f-4eb2-94ee-20b52faf67fa"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "98348f6b-3a3d-4b41-8b5c-f83a6e7d3ff4", "AQAAAAEAACcQAAAAEBnKv6fu6RX4c/F9QPww0K0OFHBfYBi4NfmY39LSX5bGylAPgQeMqKbD5mkHk4lw7g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("baf374a9-0e81-4656-b0bb-16fe10985320"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "ea3bfcf5-51a9-4d22-8cc9-721eb91724d2", "AQAAAAEAACcQAAAAEP8hmG5MfHG/RgJva/6Gk1jjFQd55gFQuhnbVZEJ6Lx0pVQwlGxqhZsWdul67zCn8w==" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "AlcoholPercentage", "CreatedOn", "DeletedOn", "ImageURL", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("d375c1dc-6dab-4fdc-a10f-4c258b33abf4"), 4.2000000000000002, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2438), null, "https://www.thespruceeats.com/thmb/_Eo444fpQZYRfERGYBBwXZ0jqsw=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/vieux-carre-cocktail-recipe-761512-hero-6438e708bfe14454b9ff17168163b12a.jpg", false, false, null, "Vieux Carre", 0.0, null },
                    { new Guid("5c85b6e3-b762-47d2-9685-3e681c48882d"), 4.5, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2475), null, "https://noseychef.com/wp-content/uploads/2018/04/hemingwaydaiquiri.jpg", false, false, null, "Hemingway Daiquiri", 0.0, null },
                    { new Guid("c33c9dcd-5667-4591-b0a6-c5a52bdf6929"), 7.2999999999999998, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2505), null, "https://www.liquor.com/thmb/OdGMZLH9XqRF1_WzYCg8V_jvX38=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__05__08113350__bourbon-old-fashioned-720x720-recipe-ade6f7780c304999be3577e565c9bcdd.jpg", false, false, null, "Old Fashioned", 0.0, null },
                    { new Guid("6979cd15-1cf7-490d-bca8-3d5eec19b190"), 7.2000000000000002, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2533), null, "https://ik.imagekit.io/0tvlktvw2l3s5/wp-content/uploads/2017/02/DSC_1281-1024x1024.jpg", false, false, null, "Cherry Sazerac", 0.0, null },
                    { new Guid("3f7554a9-9425-431f-8c41-735085ce0e1d"), 16.0, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2623), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/orange-raspberry-mimosa-1557496595.jpg?crop=0.668xw:1.00xh;0.189xw,0.00255xh&resize=768:*", false, false, null, "Orange Raspberry Mimosa", 0.0, null },
                    { new Guid("24010530-18f4-41ee-9357-daa628b6ad2b"), 12.699999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2594), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/easter-cocktails-1583163536.jpg?crop=1.00xw:1.00xh;0,0&resize=640:*", false, false, null, "Easter Champagne", 0.0, null },
                    { new Guid("7d96f193-7b26-4ef3-932c-dcb0c392497a"), 4.0999999999999996, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2407), null, "https://cookieandkate.com/images/2017/12/french-75-recipe-2-3-768x1151.jpg", false, false, null, "French 75", 0.0, null },
                    { new Guid("f0262cc8-c281-4700-8df7-fa3db0246c81"), 12.699999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2653), null, "https://www.recipetineats.com/wp-content/uploads/2019/09/Tequila-Sunrise.jpg", false, false, null, "Tequila Sunrise", 0.0, null },
                    { new Guid("c4277d5e-e403-460c-ba33-e067f2e67c25"), 2.5, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2685), null, "https://allfood.recipes/wp-content/uploads/2019/12/Disney-Dole-Pineapple-Whip-Margarita.jpg Dagger", false, false, null, "Dole Whip Margarita", 0.0, null },
                    { new Guid("f2bb4b0a-cc20-41f2-a196-8f48ebab136e"), 7.4000000000000004, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2563), null, "https://media.istockphoto.com/photos/raspberry-sangria-lemonade-or-mojito-picture-id918469144", false, false, null, "Sangria Lemonade", 0.0, null },
                    { new Guid("9708ed85-0c43-43a9-b26f-61ad6839ecf7"), 3.8999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2374), null, "https://253qv1sx4ey389p9wtpp9sj0-wpengine.netdna-ssl.com/wp-content/uploads/2017/12/Classic_Hot_Toddy-700x461.jpg", false, false, null, "Hot Toddy", 0.0, null },
                    { new Guid("b0aab0a2-bc8a-4b97-9764-d75d38fa0588"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(9), null, "https://s3-eu-west-1.amazonaws.com/ballantines.com/prod/DrinkToMarket/1720/hero/1/hero_1988x994.jpeg", false, false, null, "Bacardi", 0.0, null },
                    { new Guid("c7427fb1-0615-4292-a43d-87cbd7f65b27"), 3.7999999999999998, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2309), null, "https://www.artofdrink.com/wp-content/uploads/2011/02/vesper-martini-750x500.jpg", false, false, null, "Vesper", 0.0, null },
                    { new Guid("5c9f41d4-a8c5-4e75-8689-2e616bbca2e3"), 3.7999999999999998, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2339), null, "https://www.liquor.com/thmb/VMoOrrQzOV00AY3rgSK6XxOR0EE=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/__opt__aboutcom__coeus__resources__content_migration__liquor__2018__09__04153106__mojito-720x720-recipe-a55b114fc99c4a64b38c9ef6d1660e20.jpg", false, false, null, "Mojito", 0.0, null },
                    { new Guid("7696edab-a112-4ede-bd29-faece6e42c22"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(1885), null, "https://www.bbcgoodfood.com/sites/default/files/styles/recipe/public/recipe/recipe-image/2018/08/bramble.jpg?itok=vmHp8xTV", false, false, null, "Bramble", 0.0, null },
                    { new Guid("a68a838a-0b48-48c1-9d1d-3289126f2249"), 3.5, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(1819), null, "https://files2.hungryforever.com/wp-content/uploads/2018/03/23125131/caipirinha-cocktail.jpg", false, false, null, "Caipirinha", 0.0, null },
                    { new Guid("e70f1f3a-aec0-433f-918b-ef482d515ffb"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(1787), null, "https://unsobered.com/wp-content/uploads/2019/04/Caipiroska01-696x364.jpg", false, false, null, "Caipiroska", 0.0, null },
                    { new Guid("e4743f82-678a-4806-bfb6-f8afba5462dc"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(1714), null, "http://saltandwind.com/media/_versions/recipes/americano-cocktail-recipe_v_medium.jpg", false, false, null, "Americano", 0.0, null },
                    { new Guid("196556f5-7a6d-45ca-a974-266c9e7b7535"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2047), null, "https://dujour.com/wp-content/uploads/8297551ed0cc-500x600.jpg", false, false, null, "Barracuda", 0.0, null },
                    { new Guid("18318f04-3b02-4803-b499-86a852ee87f4"), 16.0, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(1969), null, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/delish-190816-white-russian-0119-landscape-pf-1568744178.jpg?crop=0.668xw:1.00xh;0.241xw,0&resize=980:*", false, false, null, "White Russian", 0.0, null },
                    { new Guid("a0b7d6fc-ec55-438e-baa6-28817ae10639"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2115), null, "https://makemeacocktail.com/images/cocktails/6868/400_601_margarita_2_2.jpg", false, false, null, "Margarita", 0.0, null },
                    { new Guid("2114a475-366e-4d74-b1ed-413436eef019"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2144), null, "https://www.thespruceeats.com/thmb/AHWO_swapE-OzY_e3-Ufk2YAR2s=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/negroni-cocktail-recipe-759327-6-5b3f965b46e0fb00364f8d61.jpg", false, false, null, "Negroni", 0.0, null },
                    { new Guid("45126164-0ee0-4803-8cf3-1f6df79d6088"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2174), null, "https://www.thespruceeats.com/thmb/SZ4ZYUfFLuTxyE7QhutTS_XWgHA=/960x0/filters:no_upscale():max_bytes(150000):strip_icc():format(webp)/dirty-martini-cocktail-recipe-759643-15_preview-5b02f935c064710036ff4c24.jpeg", false, false, null, "Dry Martini", 0.0, null },
                    { new Guid("c8ef69ba-03d9-4aaa-abf0-05a10f62aec8"), 3.5, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2217), null, "https://www.spendwithpennies.com/wp-content/uploads/2019/11/Bloody-Mary-SpendWithPennies-4.jpg", false, false, null, "Bloody Marry", 0.0, null },
                    { new Guid("47d3cffa-1e4a-4d55-8943-ed8273a8ac15"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2250), null, "https://stevethebartender.com.au/wp-content/uploads/2014/06/manhattan-cocktail-recipe.jpg", false, false, null, "Manhattan", 0.0, null },
                    { new Guid("e4665999-f9de-4548-a84a-3f7061d5e110"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2279), null, "https://i1.wp.com/abarabove.com/wp-content/uploads/2020/02/P2-SingaporeSling.jpg?w=1080&ssl=1", false, false, null, "Singapore Sling", 0.0, null },
                    { new Guid("1d068c49-f492-4177-b09a-b74eef2a9283"), 3.3999999999999999, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(2078), null, "https://media02.stockfood.com/previews/NDY2OTI4NA==/00389107-Campari-Orange.jpg", false, false, null, "Campari Orange", 0.0, null },
                    { new Guid("f502b46e-a4f1-4f59-b510-89b73ab19884"), 3.5, new DateTime(2020, 5, 29, 14, 20, 30, 841, DateTimeKind.Utc).AddTicks(1937), null, "https://mixthatdrink.com/wp-content/uploads/2009/03/black-russian-drink-1024x1536.jpg", false, false, null, "Black Russian", 0.0, null }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("71777afc-e19f-482b-884f-f8beb1864d3e"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6509), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Japan" },
                    { new Guid("ddcf1bb3-5ac1-4358-8741-be8c58be1506"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6533), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Australia" },
                    { new Guid("6ef12378-4b01-4307-836c-cb6e6fd6e627"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6525), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Norway" },
                    { new Guid("eeef9066-4245-4f07-947b-f9fdb662f903"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6517), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mexico" },
                    { new Guid("673a66a4-90bc-436e-8b7d-df0e0c5afde2"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6501), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "France" },
                    { new Guid("f3074417-e084-424f-8b77-ac26f7118bd2"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6469), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Greece" },
                    { new Guid("e535bcdf-f4ba-4897-9677-653671253b66"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6461), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Malta" },
                    { new Guid("b1968897-ac64-4010-a2e0-04897300ce9c"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6452), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spain" },
                    { new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(5021), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Kingdom" },
                    { new Guid("3a12cf75-ed3d-4c9b-8d97-950f599d448e"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6352), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "United Stated Of America" },
                    { new Guid("9f56e970-20fb-4284-8302-614dc81496b0"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6384), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Italy" },
                    { new Guid("85482ea4-271e-4bd9-8d7a-ddc5003806fc"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6427), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Singapore" },
                    { new Guid("4f22c01a-9d0e-40f0-b8fb-5dac3e6ca26b"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6435), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hong Kong" },
                    { new Guid("982172f7-0b3d-4acc-b092-385ef514ac04"), new DateTime(2020, 5, 29, 14, 20, 30, 842, DateTimeKind.Utc).AddTicks(6489), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "China" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "CreatedOn", "DeletedOn", "Description", "IsAlcoholic", "IsDeleted", "ModifiedOn", "Name", "Quantity", "Rating" },
                values: new object[,]
                {
                    { new Guid("5ec83e69-78f2-49cc-a6fc-597822f5a3ba"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5159), null, null, false, false, null, "Fresh mint leaves", 0, 0 },
                    { new Guid("e829051b-731c-49dc-b042-90f75727fcd8"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5165), null, null, false, false, null, "Absinthe", 0, 0 },
                    { new Guid("9aa3369a-abe9-4e83-bd51-9c07ccf636d9"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5172), null, null, false, false, null, "Amaretto liqueur", 0, 0 },
                    { new Guid("d83eee68-52da-48d8-a4b5-575e1fbc8269"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5179), null, null, false, false, null, "Milk", 0, 0 },
                    { new Guid("1f58d88f-5d33-41a8-a959-6a3628537209"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5221), null, null, false, false, null, "Coffee liqueur", 0, 0 },
                    { new Guid("bf1ae328-be44-4505-b39d-5648cc2b4ace"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5201), null, null, false, false, null, "Ginger Ale", 0, 0 },
                    { new Guid("2eac126e-5856-4593-8a8e-d20ad1c83882"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5208), null, null, false, false, null, "Lime", 0, 0 },
                    { new Guid("23c962de-a093-4f87-b8ea-dba05e6bb46c"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5214), null, null, false, false, null, "Blue curacao liqueur", 0, 0 },
                    { new Guid("1a441d2b-1fa8-45fb-b22e-cafc5f10d243"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5228), null, null, false, false, null, "Grapefruit juice", 0, 0 },
                    { new Guid("d25158c1-cc2c-4003-a662-f83d1b54d3de"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5194), null, null, false, false, null, "Cachaca", 0, 0 },
                    { new Guid("f72e80c5-fae9-4743-baaa-7d27bff7b308"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5152), null, null, false, false, null, "Brut champagne", 0, 0 },
                    { new Guid("80408ad5-b4f6-452d-8d71-145990eda1a2"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5135), null, null, false, false, null, "Cream", 0, 0 },
                    { new Guid("f2f78a88-fd9c-4e46-b181-6de2c51fb304"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5127), null, null, false, false, null, "Club soda", 0, 0 },
                    { new Guid("3e2ac263-08fe-4a21-b8f2-ee9ed94129c5"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5114), null, null, false, false, null, "Tequila", 0, 0 },
                    { new Guid("f7c2ba57-1cea-4e1f-88c1-5b8285cf71d3"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5107), null, null, false, false, null, "Sweet vermouth", 0, 0 },
                    { new Guid("3f148195-eb63-466e-8cd3-11b40a8bdadf"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5100), null, null, false, false, null, "Dry vermouth", 0, 0 },
                    { new Guid("5d90b87f-9977-4229-b9b9-5da2b9491f00"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5071), null, null, false, false, null, "Triple sec liqueur", 0, 0 },
                    { new Guid("3dcc9bec-4f9f-4585-95bd-bf81848602d5"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5064), null, null, false, false, null, "Sugar syrup", 0, 0 },
                    { new Guid("88b3f4be-3249-40ce-b7f7-7352a1eb20a2"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5053), null, null, false, false, null, "Rum", 0, 0 },
                    { new Guid("d6f6c1e6-b17c-42db-b0ec-ed7372b24c7b"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5045), null, null, false, false, null, "Campari", 0, 0 },
                    { new Guid("5697efa1-d42a-4841-96d7-29dbb7c4458a"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5037), null, null, false, false, null, "Gin", 0, 0 },
                    { new Guid("e60ceafa-bfea-4bb8-9994-e8289ab067a0"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5005), null, null, false, false, null, "Coffee", 0, 0 },
                    { new Guid("82a85f66-2382-4e0e-9b3c-660c0cb1a598"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(4984), null, null, false, false, null, "Orange juice", 0, 0 },
                    { new Guid("b905b752-337c-419a-a2aa-8021b60a6656"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(4974), null, null, false, false, null, "Vodka", 0, 0 },
                    { new Guid("7beffb57-16b9-4d4f-bcbe-aa0100a48616"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(4946), null, null, false, false, null, "Banana Juice", 0, 0 },
                    { new Guid("b839c1dd-d8a2-4c27-bbe8-e29a61e6d132"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(3679), null, null, false, false, null, "Banana Daiquiri", 0, 0 },
                    { new Guid("8f5287fd-16af-45d1-ad41-ced1a2bdad95"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(5142), null, null, false, false, null, "Maraschino liqueur", 0, 0 },
                    { new Guid("332d47d4-0fcb-4653-9347-9a833fd19c73"), new DateTime(2020, 5, 29, 14, 20, 30, 828, DateTimeKind.Utc).AddTicks(4992), null, null, false, false, null, "Whiskey", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "BarImageURL", "CountryId", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Name", "Phone", "Rating", "UserId" },
                values: new object[,]
                {
                    { new Guid("c16870ca-f72f-4b42-ad5c-8a0abdb67464"), "The Savoy Strand London WC2R 0EZ", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-large", new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"), new DateTime(2020, 5, 29, 14, 20, 30, 845, DateTimeKind.Utc).AddTicks(9197), null, false, null, "American Bar", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("9a8700da-6105-4c8e-8a3c-eebe0f64552b"), "Av. �lvaro Obreg�n 106 Cuauht�moc", "https://i.vivit-tours.com/img/other/58/food-tour-roma-norte-mexico-citys-hippest-hood.jpg", new Guid("eeef9066-4245-4f07-947b-f9fdb662f903"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1960), null, false, null, "Licorera Limantour", "01 55 5264 4122", 0, null },
                    { new Guid("cc07de3a-850f-4da6-ba04-3a6f0ed7bb6e"), "500 Arguello Street Redwood City", "https://images.squarespace-cdn.com/content/v1/5a0bb36d6f4ca3bf77c236b1/1523588347811-6GO1NX5NIL150ZVGA1YV/ke17ZwdGBToddI8pDm48kLkXF2pIyv_F2eUT9F60jBl7gQa3H78H3Y0txjaiv_0fDoOvxcdMmMKkDsyUqMSsMWxHk725yiiHCCLfrh8O1z4YTzHvnKhyp6Da-NYroOW3ZGjoBKy3azqku80C789l0iyqMbMesKd95J-X4EagrgU9L3Sa3U8cogeb0tjXbfawd0urKshkc5MgdBeJmALQKw/_GU89474.jpg?format=1000w", new Guid("71777afc-e19f-482b-884f-f8beb1864d3e"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1896), null, false, null, "High Five", "(844) 464-4445", 0, null },
                    { new Guid("cc644dad-918f-4745-8496-26e08e571b1e"), "52 Rue de Saintonge Paris", "https://wordpress.zarkov.de/wp-content/uploads/2019/09/20190908_03-Candelaria-11-Backboard-Ecke-1038x576.jpg", new Guid("673a66a4-90bc-436e-8b7d-df0e0c5afde2"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2179), null, false, null, "Candelaria", "+34 910 00 61", 0, null },
                    { new Guid("3284c2da-51e5-47b8-8b6c-095b803f46d2"), "60 Rue Charlot Paris", "https://savourexperience.com/wp-content/uploads/2016/05/little-red-door-parallax-01-the-parisianist.jpg", new Guid("673a66a4-90bc-436e-8b7d-df0e0c5afde2"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1796), null, false, null, "Little Red Door", "+33 1 42 71 19 32", 0, null },
                    { new Guid("b9988a7c-fec4-4fda-a40b-11d7f4de379e"), "579 Fuxing Zhong Lu", "http://www.smartshanghai.com/uploads/venues/thumbs/thumb_1553153257.jpg", new Guid("982172f7-0b3d-4acc-b092-385ef514ac04"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1739), null, false, null, "Speak Low", "6416 0133", 0, null },
                    { new Guid("02023021-7e81-4941-a8d2-4fc33590f2c4"), "Praxitelous 30 Athens", "https://www.thegreekfoundation.com/wp-content/uploads/2015/07/3b-1000x666.jpg", new Guid("f3074417-e084-424f-8b77-ac26f7118bd2"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1566), null, false, null, "The Clumsies", "+30 21 0323 2682", 0, null },
                    { new Guid("b1151c1b-8c95-4a83-ad89-7cc1013264d0"), "Paceville Main Staircase St Julian's", "https://media-cdn.tripadvisor.com/media/photo-s/12/a2/9f/4c/good-food-drinks-and.jpg", new Guid("e535bcdf-f4ba-4897-9677-653671253b66"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1435), null, false, null, "Native", "+356 2138 0635", 0, null },
                    { new Guid("6b3d7f6c-0eba-4678-965c-5b2939ff7995"), "Calle Echegaray 21 28014 Madrid", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2017/11/European-bars.jpg", new Guid("b1968897-ac64-4010-a2e0-04897300ce9c"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1334), null, false, null, "Salmon Guru", "+34 910 00 61", 0, null },
                    { new Guid("5fd19100-8d44-4167-8ed0-c029adc4883c"), "37 Aberdeen Street Central", "https://www.worlds50bestbars.com/filestore/jpg/TheOldManS-WORLD-2019-003.jpg", new Guid("4f22c01a-9d0e-40f0-b8fb-5dac3e6ca26b"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1282), null, false, null, "The Old Man", "85227031899", 0, null },
                    { new Guid("894c4305-519c-4471-b5e7-bc8c686abab1"), "7 Ann Siang Hill", "https://media.timeout.com/images/101805101/1024/576/image.jpg", new Guid("85482ea4-271e-4bd9-8d7a-ddc5003806fc"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2384), null, false, null, "Operation Dagger", "+39 06 2348 8666", 0, null },
                    { new Guid("11b8511f-936b-4f90-9c3d-d76f445129c5"), "Parkview Square", "https://www.traveller.com.au/content/dam/images/h/1/c/8/y/p/image.related.articleLeadwide.620x349.h1c8s1.png/1552972222305.jpg", new Guid("85482ea4-271e-4bd9-8d7a-ddc5003806fc"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2003), null, false, null, "Atlas", "+65 6396 4466", 0, null },
                    { new Guid("d0561021-c518-4c29-bd7e-52896eea7bcf"), "1 Cuscaden Road 249715", "https://im1.dineout.co.in/images/uploads/restaurant/sharpen/1/i/l/p12602-15475381735c3d8efdc738b.jpg?tr=tr:n-xlarge", new Guid("85482ea4-271e-4bd9-8d7a-ddc5003806fc"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1157), null, false, null, "Manhattan", "+65 6725 3377", 0, null },
                    { new Guid("abec7768-05f9-4227-b268-0a517a92aa4d"), "Piazza di S. Martino Ai Monti 8 00154 Roma RM", "https://www.puntarellarossa.it/wp/wp-content/uploads/2018/09/drink-kong-pat--850x566.jpg", new Guid("9f56e970-20fb-4284-8302-614dc81496b0"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1111), null, false, null, "Drink Kong", "+39 06 2348 8666", 0, null },
                    { new Guid("78191da4-2d4a-4b2d-bdc7-140d5dfa0729"), "2727 Indian Creek Dr. Miami Beach", "https://media.cntraveler.com/photos/5a70f846e2c45625a77b0834/master/w_767,c_limit/Broken-Shaker__2018FreehandLA_BrokenShaker4_WonhoFrankLee.jpg", new Guid("3a12cf75-ed3d-4c9b-8d97-950f599d448e"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2125), null, false, null, "Broken Shaker", "305-531-2727", 0, null },
                    { new Guid("185222b5-45f9-4777-a7bc-d71d31929b15"), "79-81 MacDougal St New York", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/dante-cocktail-bar-001.jpg", new Guid("3a12cf75-ed3d-4c9b-8d97-950f599d448e"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2044), null, false, null, "Dante", "01 55 5264 4122", 0, null },
                    { new Guid("4f21d388-d018-41be-9cf4-85822f148d75"), "134 Eldridge Street New York", "https://cdn.vox-cdn.com/thumbor/VJquLyS0TlbhkQfJENqnPg45tyo=/21x0:228x155/920x613/filters:focal(21x0:228x155):format(webp)/cdn.vox-cdn.com/uploads/chorus_image/image/38982652/2013_3_Attaboy2.0.jpg", new Guid("3a12cf75-ed3d-4c9b-8d97-950f599d448e"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1637), null, false, null, "Attaboy", "+36 1 792 2222", 0, null },
                    { new Guid("8316949c-5913-4b48-bf66-279e2b3d58c9"), "", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/01/Dead-Rabbit.jpg", new Guid("3a12cf75-ed3d-4c9b-8d97-950f599d448e"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1515), null, false, null, "The Dead Rabbit", "+ 44 (0)20 7836 4343", 0, null },
                    { new Guid("18f574da-94db-42fe-abc5-4a1bfc244270"), "531 Hudson St New York", "https://wswd-wordpress-production.s3.amazonaws.com/content/uploads/2018/08/28140308/Katana-Kitten-NYC-West-Village-bar.jpg", new Guid("3a12cf75-ed3d-4c9b-8d97-950f599d448e"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1378), null, false, null, "Katana Kitten", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("225f0468-42c4-4612-9dba-2ccd1b7bc83f"), "1170 BROADWAY & 28TH STREET NEW YORK", "https://www.theworlds50best.com/discovery/filestore/jpg/NoMadBar-NewYork-USA-03.jpg", new Guid("3a12cf75-ed3d-4c9b-8d97-950f599d448e"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1032), null, false, null, "The NoMad", "(347) 472-5660", 0, null },
                    { new Guid("68a95b21-18e2-4f27-8031-853f019a4acf"), "Point Square North Dock Dublin", "https://www.thespiritsbusiness.com/content/http://www.thespiritsbusiness.com/media/2018/02/The-Gibson.jpg", new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2278), null, false, null, "The Gibson", "+353 1 681 5000", 0, null },
                    { new Guid("07869b06-b74f-4652-91a5-9d8e0eaed288"), "61�63. Meaden, London", "https://aplo.co/admin/web/uploads/space/oriolebar-1-yes.jpg", new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2085), null, false, null, "Oriole", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("996c4768-1731-4a4d-9d93-209db8764078"), "8-9 Hoxton Square London", "https://www.top50cocktailbars.com/wp-content/uploads/2019/06/HappinessForgets3.jpg", new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1834), null, false, null, "Happiness Forgets", "+44 (0) 20 7613 0325", 0, null },
                    { new Guid("f25438cf-abcb-40ba-a823-ceadf095114e"), "Soho, London", "https://media.timeout.com/images/103972748/1024/576/image.jpg", new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1683), null, false, null, "Bar Termini", "+44 20 7622 4004", 0, null },
                    { new Guid("4e685008-0a8b-4262-9bc7-82acc23e4a77"), "20 Upper Ground South Bank London SE1 9PD", "https://static.standard.co.uk/s3fs-public/thumbnails/image/2018/04/20/17/dandelyan-london.jpg?w968", new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1476), null, false, null, "Dandelyan", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("88d460df-756e-42ed-930c-5ae7fab8d721"), "The Connaught Carlos Place Mayfair London", "https://iwillmakeualist.files.wordpress.com/2017/07/img_6198.jpg", new Guid("e7558d0f-9bc2-48cb-8c13-a7433741b924"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(1194), null, false, null, "Connaught Bar", "+44 (0)20 7314 3419", 0, null },
                    { new Guid("65ee9998-f59f-436d-9cd8-d82bd07fd044"), "Storgata 27 Oslo", "https://www.thespiritsbusiness.com/content/http:/www.thespiritsbusiness.com/media/2015/11/Top-six-Europe-bars-to-visit-in-2016.jpg", new Guid("6ef12378-4b01-4307-836c-cb6e6fd6e627"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2240), null, false, null, "Himkok", "+47 22 42 22 02", 0, null },
                    { new Guid("96f9515a-3061-4259-8dc8-d701ae10458b"), "304 BRUNSWICK ST", "https://www.worldsbestbars.com/wp-content/uploads/2018/05/bar_640_480_Black-Pearl_54b7d78180c89_5579556b49c71.jpg", new Guid("ddcf1bb3-5ac1-4358-8741-be8c58be1506"), new DateTime(2020, 5, 29, 14, 20, 30, 846, DateTimeKind.Utc).AddTicks(2343), null, false, null, "Black Pearl", "+61 2 8624 3131", 0, null }
                });
        }
    }
}
