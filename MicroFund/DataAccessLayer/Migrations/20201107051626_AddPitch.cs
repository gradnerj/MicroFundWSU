using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddPitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pitch",
                columns: table => new
                {
                    PitchId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(nullable: false),
                    PitchDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pitch", x => x.PitchId);
                    table.ForeignKey(
                        name: "FK_Pitch_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pitch_ApplicationId",
                table: "Pitch",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pitch");
        }
    }
}
