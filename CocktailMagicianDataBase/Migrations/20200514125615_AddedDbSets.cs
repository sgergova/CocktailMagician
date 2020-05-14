using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class AddedDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarCocktail_Bars_BarId",
                table: "BarCocktail");

            migrationBuilder.DropForeignKey(
                name: "FK_BarCocktail_Cocktails_CocktailId",
                table: "BarCocktail");

            migrationBuilder.DropForeignKey(
                name: "FK_BarComment_Bars_BarId",
                table: "BarComment");

            migrationBuilder.DropForeignKey(
                name: "FK_BarComment_AspNetUsers_UserId",
                table: "BarComment");

            migrationBuilder.DropForeignKey(
                name: "FK_BarStar_Bars_BarId",
                table: "BarStar");

            migrationBuilder.DropForeignKey(
                name: "FK_BarStar_AspNetUsers_UserId",
                table: "BarStar");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailComment_Cocktails_CocktailId",
                table: "CocktailComment");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailComment_AspNetUsers_UserId",
                table: "CocktailComment");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Cocktails_CocktailId",
                table: "CocktailIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredient_Ingredients_IngredientId",
                table: "CocktailIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailStar_Cocktails_CocktailId",
                table: "CocktailStar");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailStar_AspNetUsers_UserId",
                table: "CocktailStar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CocktailStar",
                table: "CocktailStar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CocktailIngredient",
                table: "CocktailIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CocktailComment",
                table: "CocktailComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarStar",
                table: "BarStar");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarComment",
                table: "BarComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarCocktail",
                table: "BarCocktail");

            migrationBuilder.RenameTable(
                name: "CocktailStar",
                newName: "CocktailStars");

            migrationBuilder.RenameTable(
                name: "CocktailIngredient",
                newName: "CocktailIngredients");

            migrationBuilder.RenameTable(
                name: "CocktailComment",
                newName: "CocktailComments");

            migrationBuilder.RenameTable(
                name: "BarStar",
                newName: "BarStars");

            migrationBuilder.RenameTable(
                name: "BarComment",
                newName: "BarComments");

            migrationBuilder.RenameTable(
                name: "BarCocktail",
                newName: "BarCocktails");

            migrationBuilder.RenameIndex(
                name: "IX_CocktailStar_UserId",
                table: "CocktailStars",
                newName: "IX_CocktailStars_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CocktailIngredient_IngredientId",
                table: "CocktailIngredients",
                newName: "IX_CocktailIngredients_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_CocktailComment_UserId",
                table: "CocktailComments",
                newName: "IX_CocktailComments_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BarStar_UserId",
                table: "BarStars",
                newName: "IX_BarStars_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BarComment_BarId",
                table: "BarComments",
                newName: "IX_BarComments_BarId");

            migrationBuilder.RenameIndex(
                name: "IX_BarCocktail_CocktailId",
                table: "BarCocktails",
                newName: "IX_BarCocktails_CocktailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CocktailStars",
                table: "CocktailStars",
                columns: new[] { "CocktailId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CocktailIngredients",
                table: "CocktailIngredients",
                columns: new[] { "CocktailId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CocktailComments",
                table: "CocktailComments",
                columns: new[] { "CocktailId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarStars",
                table: "BarStars",
                columns: new[] { "BarId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarComments",
                table: "BarComments",
                columns: new[] { "UserId", "BarId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarCocktails",
                table: "BarCocktails",
                columns: new[] { "BarId", "CocktailId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BarCocktails_Bars_BarId",
                table: "BarCocktails",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarCocktails_Cocktails_CocktailId",
                table: "BarCocktails",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarComments_Bars_BarId",
                table: "BarComments",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarComments_AspNetUsers_UserId",
                table: "BarComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarStars_Bars_BarId",
                table: "BarStars",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarStars_AspNetUsers_UserId",
                table: "BarStars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailComments_Cocktails_CocktailId",
                table: "CocktailComments",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailComments_AspNetUsers_UserId",
                table: "CocktailComments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailIngredients_Cocktails_CocktailId",
                table: "CocktailIngredients",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailIngredients_Ingredients_IngredientId",
                table: "CocktailIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailStars_Cocktails_CocktailId",
                table: "CocktailStars",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailStars_AspNetUsers_UserId",
                table: "CocktailStars",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarCocktails_Bars_BarId",
                table: "BarCocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_BarCocktails_Cocktails_CocktailId",
                table: "BarCocktails");

            migrationBuilder.DropForeignKey(
                name: "FK_BarComments_Bars_BarId",
                table: "BarComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BarComments_AspNetUsers_UserId",
                table: "BarComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BarStars_Bars_BarId",
                table: "BarStars");

            migrationBuilder.DropForeignKey(
                name: "FK_BarStars_AspNetUsers_UserId",
                table: "BarStars");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailComments_Cocktails_CocktailId",
                table: "CocktailComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailComments_AspNetUsers_UserId",
                table: "CocktailComments");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredients_Cocktails_CocktailId",
                table: "CocktailIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailIngredients_Ingredients_IngredientId",
                table: "CocktailIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailStars_Cocktails_CocktailId",
                table: "CocktailStars");

            migrationBuilder.DropForeignKey(
                name: "FK_CocktailStars_AspNetUsers_UserId",
                table: "CocktailStars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CocktailStars",
                table: "CocktailStars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CocktailIngredients",
                table: "CocktailIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CocktailComments",
                table: "CocktailComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarStars",
                table: "BarStars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarComments",
                table: "BarComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarCocktails",
                table: "BarCocktails");

            migrationBuilder.RenameTable(
                name: "CocktailStars",
                newName: "CocktailStar");

            migrationBuilder.RenameTable(
                name: "CocktailIngredients",
                newName: "CocktailIngredient");

            migrationBuilder.RenameTable(
                name: "CocktailComments",
                newName: "CocktailComment");

            migrationBuilder.RenameTable(
                name: "BarStars",
                newName: "BarStar");

            migrationBuilder.RenameTable(
                name: "BarComments",
                newName: "BarComment");

            migrationBuilder.RenameTable(
                name: "BarCocktails",
                newName: "BarCocktail");

            migrationBuilder.RenameIndex(
                name: "IX_CocktailStars_UserId",
                table: "CocktailStar",
                newName: "IX_CocktailStar_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_CocktailIngredients_IngredientId",
                table: "CocktailIngredient",
                newName: "IX_CocktailIngredient_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_CocktailComments_UserId",
                table: "CocktailComment",
                newName: "IX_CocktailComment_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BarStars_UserId",
                table: "BarStar",
                newName: "IX_BarStar_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_BarComments_BarId",
                table: "BarComment",
                newName: "IX_BarComment_BarId");

            migrationBuilder.RenameIndex(
                name: "IX_BarCocktails_CocktailId",
                table: "BarCocktail",
                newName: "IX_BarCocktail_CocktailId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CocktailStar",
                table: "CocktailStar",
                columns: new[] { "CocktailId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CocktailIngredient",
                table: "CocktailIngredient",
                columns: new[] { "CocktailId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CocktailComment",
                table: "CocktailComment",
                columns: new[] { "CocktailId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarStar",
                table: "BarStar",
                columns: new[] { "BarId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarComment",
                table: "BarComment",
                columns: new[] { "UserId", "BarId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarCocktail",
                table: "BarCocktail",
                columns: new[] { "BarId", "CocktailId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BarCocktail_Bars_BarId",
                table: "BarCocktail",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarCocktail_Cocktails_CocktailId",
                table: "BarCocktail",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarComment_Bars_BarId",
                table: "BarComment",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarComment_AspNetUsers_UserId",
                table: "BarComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarStar_Bars_BarId",
                table: "BarStar",
                column: "BarId",
                principalTable: "Bars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarStar_AspNetUsers_UserId",
                table: "BarStar",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailComment_Cocktails_CocktailId",
                table: "CocktailComment",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailComment_AspNetUsers_UserId",
                table: "CocktailComment",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailIngredient_Cocktails_CocktailId",
                table: "CocktailIngredient",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailIngredient_Ingredients_IngredientId",
                table: "CocktailIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailStar_Cocktails_CocktailId",
                table: "CocktailStar",
                column: "CocktailId",
                principalTable: "Cocktails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CocktailStar_AspNetUsers_UserId",
                table: "CocktailStar",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
