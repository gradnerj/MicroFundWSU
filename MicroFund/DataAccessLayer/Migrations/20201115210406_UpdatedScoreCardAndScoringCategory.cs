using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UpdatedScoreCardAndScoringCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCard_ScoreCardField_ScoreCardFieldId",
                table: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_ScoreCard_ScoreCardFieldId",
                table: "ScoreCard");

            migrationBuilder.DropColumn(
                name: "ScoreCardFieldId",
                table: "ScoreCard");

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardCategoryId",
                table: "ScoreCard",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_ScoreCardCategoryId",
                table: "ScoreCard",
                column: "ScoreCardCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScoreCard_ScoringCategory_ScoreCardCategoryId",
                table: "ScoreCard",
                column: "ScoreCardCategoryId",
                principalTable: "ScoringCategory",
                principalColumn: "ScoringCategoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCard_ScoringCategory_ScoreCardCategoryId",
                table: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_ScoreCard_ScoreCardCategoryId",
                table: "ScoreCard");

            migrationBuilder.DropColumn(
                name: "ScoreCardCategoryId",
                table: "ScoreCard");

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardFieldId",
                table: "ScoreCard",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
