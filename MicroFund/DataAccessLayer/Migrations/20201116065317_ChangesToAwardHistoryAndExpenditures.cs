using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ChangesToAwardHistoryAndExpenditures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardHistory_Expenditure_ExpenditureId",
                table: "AwardHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCard_ScoringCategory_ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_ScoreCard_ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_AwardHistory_ExpenditureId",
                table: "AwardHistory");

            migrationBuilder.DropColumn(
                name: "ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "AwardHistory");

            migrationBuilder.DropColumn(
                name: "ExpenditureId",
                table: "AwardHistory");

            migrationBuilder.AddColumn<int>(
                name: "AwardHistoryId",
                table: "Expenditure",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "CashAmount",
                table: "AwardHistory",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "PitchEventId",
                table: "AwardHistory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "ServicesAmount",
                table: "AwardHistory",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_ScoreCardFieldId",
                table: "ScoreCard",
                column: "ScoreCardFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenditure_AwardHistoryId",
                table: "Expenditure",
                column: "AwardHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardHistory_PitchEventId",
                table: "AwardHistory",
                column: "PitchEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardHistory_PitchEvents_PitchEventId",
                table: "AwardHistory",
                column: "PitchEventId",
                principalTable: "PitchEvents",
                principalColumn: "PitchEventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenditure_AwardHistory_AwardHistoryId",
                table: "Expenditure",
                column: "AwardHistoryId",
                principalTable: "AwardHistory",
                principalColumn: "AwardHistoryId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_AwardHistory_PitchEvents_PitchEventId",
                table: "AwardHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenditure_AwardHistory_AwardHistoryId",
                table: "Expenditure");

            migrationBuilder.DropForeignKey(
                name: "FK_ScoreCard_ScoreCardField_ScoreCardFieldId",
                table: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_ScoreCard_ScoreCardFieldId",
                table: "ScoreCard");

            migrationBuilder.DropIndex(
                name: "IX_Expenditure_AwardHistoryId",
                table: "Expenditure");

            migrationBuilder.DropIndex(
                name: "IX_AwardHistory_PitchEventId",
                table: "AwardHistory");

            migrationBuilder.DropColumn(
                name: "AwardHistoryId",
                table: "Expenditure");

            migrationBuilder.DropColumn(
                name: "CashAmount",
                table: "AwardHistory");

            migrationBuilder.DropColumn(
                name: "PitchEventId",
                table: "AwardHistory");

            migrationBuilder.DropColumn(
                name: "ServicesAmount",
                table: "AwardHistory");

            migrationBuilder.AddColumn<int>(
                name: "ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Amount",
                table: "AwardHistory",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "ExpenditureId",
                table: "AwardHistory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_ScoreCardCategoryScoringCategoryId",
                table: "ScoreCard",
                column: "ScoreCardCategoryScoringCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardHistory_ExpenditureId",
                table: "AwardHistory",
                column: "ExpenditureId");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardHistory_Expenditure_ExpenditureId",
                table: "AwardHistory",
                column: "ExpenditureId",
                principalTable: "Expenditure",
                principalColumn: "ExpenditureId",
                onDelete: ReferentialAction.Restrict);

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
