using Microsoft.EntityFrameworkCore.Migrations;

namespace RealEstates.Data.Migrations
{
    public partial class PropertyNullablePrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Buildings_BuildingTypeId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "BuildingTypes");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BuildingTypes",
                table: "BuildingTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BuildingTypes_BuildingTypeId",
                table: "Properties",
                column: "BuildingTypeId",
                principalTable: "BuildingTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BuildingTypes_BuildingTypeId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BuildingTypes",
                table: "BuildingTypes");

            migrationBuilder.RenameTable(
                name: "BuildingTypes",
                newName: "Buildings");

            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Buildings_BuildingTypeId",
                table: "Properties",
                column: "BuildingTypeId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
