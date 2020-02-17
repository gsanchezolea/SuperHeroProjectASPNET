using Microsoft.EntityFrameworkCore.Migrations;

namespace SuperHeroProject.Data.Migrations
{
    public partial class PropertyAdjustmentMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryHeroProperty",
                table: "SuperHeroes");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryAbility",
                table: "SuperHeroes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecondaryAbility",
                table: "SuperHeroes");

            migrationBuilder.AddColumn<string>(
                name: "SecondaryHeroProperty",
                table: "SuperHeroes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
