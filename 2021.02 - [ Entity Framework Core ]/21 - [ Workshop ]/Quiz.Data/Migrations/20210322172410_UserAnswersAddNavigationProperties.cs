using Microsoft.EntityFrameworkCore.Migrations;

namespace Quiz.Data.Migrations
{
    public partial class UserAnswersAddNavigationProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserAnswers");

            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "UserAnswers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                columns: new[] { "IdentityUserId", "QuizId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers",
                column: "QuestionId");

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
                name: "FK_UserAnswers_AspNetUsers_IdentityUserId",
                table: "UserAnswers",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers",
                column: "QuestionId",
                principalTable: "Questions",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Answers_AnswerId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_AspNetUsers_IdentityUserId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Questions_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAnswers_Quizes_QuizId",
                table: "UserAnswers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers");

            migrationBuilder.DropIndex(
                name: "IX_UserAnswers_QuizId",
                table: "UserAnswers");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "UserAnswers");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAnswers",
                table: "UserAnswers",
                columns: new[] { "UserId", "QuizId" });
        }
    }
}
