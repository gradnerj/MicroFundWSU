using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddExternalFunding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExternalFunding",
                columns: table => new
                {
                    ExternalFundingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Source = table.Column<string>(maxLength: 64, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalFunding", x => x.ExternalFundingId);
                    table.ForeignKey(
                        name: "FK_ExternalFunding_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExternalFunding_ApplicationId",
                table: "ExternalFunding",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExternalFunding");
        }
    }
}
