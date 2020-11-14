using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class revert_applicationuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_ApplicationUserId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Application_ApplicationUserId",
                table: "Application");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Application");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Application",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicationUserId",
                table: "Application",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_ApplicationUserId",
                table: "Application",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
