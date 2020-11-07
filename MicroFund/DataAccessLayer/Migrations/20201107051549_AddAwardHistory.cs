using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddAwardHistory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwardHistory",
                columns: table => new
                {
                    AwardHistoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(nullable: false),
                    ExpenditureId = table.Column<int>(nullable: false),
                    AwardDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Agreement = table.Column<string>(maxLength: 64, nullable: false),
                    ReqNumber = table.Column<int>(nullable: false),
                    MailedDate = table.Column<DateTime>(nullable: false),
                    Provider = table.Column<string>(maxLength: 64, nullable: true),
                    AwardType = table.Column<string>(maxLength: 64, nullable: true),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardHistory", x => x.AwardHistoryId);
                    table.ForeignKey(
                        name: "FK_AwardHistory_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AwardHistory_Expenditure_ExpenditureId",
                        column: x => x.ExpenditureId,
                        principalTable: "Expenditure",
                        principalColumn: "ExpenditureId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwardHistory_ApplicationId",
                table: "AwardHistory",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AwardHistory_ExpenditureId",
                table: "AwardHistory",
                column: "ExpenditureId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwardHistory");
        }
    }
}
