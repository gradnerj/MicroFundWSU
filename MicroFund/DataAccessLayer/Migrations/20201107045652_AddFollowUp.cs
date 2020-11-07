using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddFollowUp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FollowUp",
                columns: table => new
                {
                    FollowUpId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(nullable: false),
                    FollowUpTypeId = table.Column<int>(nullable: false),
                    FollowUpDate = table.Column<DateTime>(nullable: false),
                    Response = table.Column<bool>(nullable: false),
                    ResponseDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowUp", x => x.FollowUpId);
                    table.ForeignKey(
                        name: "FK_FollowUp_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowUp_FollowUpType_FollowUpTypeId",
                        column: x => x.FollowUpTypeId,
                        principalTable: "FollowUpType",
                        principalColumn: "FollowUpTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FollowUp_ApplicationId",
                table: "FollowUp",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_FollowUp_FollowUpTypeId",
                table: "FollowUp",
                column: "FollowUpTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FollowUp");
        }
    }
}
