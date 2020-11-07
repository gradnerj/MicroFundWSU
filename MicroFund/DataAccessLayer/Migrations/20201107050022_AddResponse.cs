using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Response",
                columns: table => new
                {
                    ResponseId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    ResponseDescription = table.Column<string>(maxLength: 250, nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Response", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_Response_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Response_Question_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Question",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Response_ApplicationId",
                table: "Response",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Response_QuestionId",
                table: "Response",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Response");
        }
    }
}
