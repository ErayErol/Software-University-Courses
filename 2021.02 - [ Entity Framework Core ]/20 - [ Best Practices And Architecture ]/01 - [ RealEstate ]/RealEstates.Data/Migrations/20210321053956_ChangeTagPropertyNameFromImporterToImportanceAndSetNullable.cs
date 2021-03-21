using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstates.Data.Migrations
{
    public partial class ChangeTagPropertyNameFromImporterToImportanceAndSetNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importer",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "Importance",
                table: "Tags",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Importance",
                table: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "Importer",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
