using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Data.Migrations
{
    public partial class ModelUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Quizes_QuizId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_QuizId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "QuizId",
                table: "UserAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "UserAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuizId",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuizId",
                table: "UserAnswers",
                column: "QuizId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Quizes_QuizId",
                table: "UserAnswers",
                column: "QuizId",
                principalTable: "Quizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
