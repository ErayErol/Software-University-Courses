using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Data.Migrations
{
    public partial class RemoveCompositeKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_AspNetUsers_IdentityUserId",
                table: "UserAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "UserAnswers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_IdentityUserId",
                table: "UserAnswers",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_AspNetUsers_IdentityUserId",
                table: "UserAnswers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_AspNetUsers_IdentityUserId",
                table: "UserAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_IdentityUserId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserAnswers");

            migrationBuilder.AlterColumn<string>(
                name: "IdentityUserId",
                table: "UserAnswers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                columns: new[] { "IdentityUserId", "QuizId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_AspNetUsers_IdentityUserId",
                table: "UserAnswers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
