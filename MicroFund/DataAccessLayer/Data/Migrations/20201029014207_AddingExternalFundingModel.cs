using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingExternalFundingModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalFunding",
                columns: table => new
                {
                    ApplicationDetailsId = table.Column<int>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Source = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalFunding", x => x.ApplicationDetailsId);
                    table.ForeignKey(
                        name: "FK_ExternalFunding_ApplicationDetails_ApplicationDetailsId",
                        column: x => x.ApplicationDetailsId,
                        principalTable: "ApplicationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalFunding");
        }
    }
}
