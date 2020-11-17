using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addQuestionNumberToQuestion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCard_ScoringCategory_ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_ScoreCard_ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard");

            migrationBuilder.DropColumn(
                name: "ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard");

            migrationBuilder.AlterColumn<string>(
                name: "ResponseDescription",
                table: "Response",
                maxLength: 750,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionDescription",
                table: "Question",
                maxLength: 750,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_ScoreCardFieldId",
                table: "ScoreCard",
                column: "ScoreCardFieldId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCard_ScoreCardField_ScoreCardFieldId",
                table: "ScoreCard",
                column: "ScoreCardFieldId",
                principalTable: "ScoreCardField",
                principalColumn: "ScoreCardFieldId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCard_ScoreCardField_ScoreCardFieldId",
                table: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_ScoreCard_ScoreCardFieldId",
                table: "ScoreCard");

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResponseDescription",
                table: "Response",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 750);

            migrationBuilder.AlterColumn<string>(
                name: "QuestionDescription",
                table: "Question",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 750);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard",
                column: "ScoreCardCategoryScoringCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCard_ScoringCategory_ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard",
                column: "ScoreCardCategoryScoringCategoryId",
                principalTable: "ScoringCategory",
                principalColumn: "ScoringCategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
