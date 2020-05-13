using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class ChangesOfBarEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Bars");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Bars");

            migrationBuilder.AddColumn<bool>(
                name: "IsAlcoholic",
                table: "Ingredients",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAlcoholic",
                table: "Ingredients");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Bars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Bars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
