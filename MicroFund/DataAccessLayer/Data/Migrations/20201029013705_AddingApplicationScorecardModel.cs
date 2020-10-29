using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingApplicationScorecardModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationScorecard",
                columns: table => new
                {
                    ApplicationDetailsId = table.Column<int>(nullable: false),
                    MarketOpportunity = table.Column<int>(nullable: false),
                    Customers = table.Column<int>(nullable: false),
                    MarketingAndSales = table.Column<int>(nullable: false),
                    Competition = table.Column<int>(nullable: false),
                    Team = table.Column<int>(nullable: false),
                    Outcome = table.Column<string>(nullable: true),
                    OutcomeDate = table.Column<DateTime>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationScorecard", x => x.ApplicationDetailsId);
                    table.ForeignKey(
                        name: "FK_ApplicationScorecard_ApplicationDetails_ApplicationDetailsId",
                        column: x => x.ApplicationDetailsId,
                        principalTable: "ApplicationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationScorecard_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationScorecard_ApplicationUserId",
                table: "ApplicationScorecard",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationScorecard");
        }
    }
}
