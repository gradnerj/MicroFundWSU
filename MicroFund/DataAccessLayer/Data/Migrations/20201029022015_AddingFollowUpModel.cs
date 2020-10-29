using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingFollowUpModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FollowUp",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrantPhaseId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Response = table.Column<bool>(nullable: false),
                    ResponseDate = table.Column<DateTime>(nullable: false),
                    JobsAdded = table.Column<int>(nullable: false),
                    SalesIncrease = table.Column<float>(nullable: false),
                    Profitable = table.Column<bool>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    NumberOfEmployees = table.Column<int>(nullable: false),
                    Revenue = table.Column<float>(nullable: false),
                    Exit = table.Column<bool>(nullable: false),
                    Funding = table.Column<bool>(nullable: false),
                    FundingAmount = table.Column<float>(nullable: false),
                    FundingType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUp", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FollowUp_GrantPhase_GrantPhaseId",
                        column: x => x.GrantPhaseId,
                        principalTable: "GrantPhase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowUp_GrantPhaseId",
                table: "FollowUp",
                column: "GrantPhaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowUp");
        }
    }
}
