using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class RemovingFollowUp_TheyHaveBeenAddedToQuestions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.DropForeignKey(
                name: "FK_AwardHistory_Expenditure_ExpenditureId",
                table: "AwardHistory");*/

            migrationBuilder.DropTable(
                name: "FollowUp");

            migrationBuilder.DropTable(
                name: "FollowUpType");

            /*migrationBuilder.DropIndex(
                name: "IX_AwardHistory_ExpenditureId",
                table: "AwardHistory");

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

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "AwardHistory",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

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
                onDelete: ReferentialAction.Restrict);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AwardHistory_PitchEvents_PitchEventId",
                table: "AwardHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenditure_AwardHistory_AwardHistoryId",
                table: "Expenditure");

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

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "AwardHistory",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

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

            migrationBuilder.CreateTable(
                name: "FollowUpType",
                columns: table => new
                {
                    FollowUpTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FollowUpTypeDescription = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUpType", x => x.FollowUpTypeId);
                });

            migrationBuilder.CreateTable(
                name: "FollowUp",
                columns: table => new
                {
                    FollowUpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(type: "int", nullable: false),
                    FollowUpDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FollowUpTypeId = table.Column<int>(type: "int", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    Response = table.Column<bool>(type: "bit", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUp", x => x.FollowUpId);
                    table.ForeignKey(
                        name: "FK_FollowUp_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FollowUp_FollowUpType_FollowUpTypeId",
                        column: x => x.FollowUpTypeId,
                        principalTable: "FollowUpType",
                        principalColumn: "FollowUpTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwardHistory_ExpenditureId",
                table: "AwardHistory",
                column: "ExpenditureId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUp_ApplicationId",
                table: "FollowUp",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUp_FollowUpTypeId",
                table: "FollowUp",
                column: "FollowUpTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AwardHistory_Expenditure_ExpenditureId",
                table: "AwardHistory",
                column: "ExpenditureId",
                principalTable: "Expenditure",
                principalColumn: "ExpenditureId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
