using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingMentorModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mentor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDetailsId = table.Column<int>(nullable: false),
                    MentorName = table.Column<string>(nullable: true),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    NumberOfVisits = table.Column<int>(nullable: false),
                    ApprovedToPitchDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mentor_ApplicationDetails_ApplicationDetailsId",
                        column: x => x.ApplicationDetailsId,
                        principalTable: "ApplicationDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mentor_ApplicationDetailsId",
                table: "Mentor",
                column: "ApplicationDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mentor");
        }
    }
}
