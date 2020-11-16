using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddingPitchEventFKToPitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PitchEventId",
                table: "Pitch",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pitch_PitchEventId",
                table: "Pitch",
                column: "PitchEventId");

            /*migrationBuilder.AddForeignKey(
                name: "FK_Pitch_PitchEvents_PitchEventId",
                table: "Pitch",
                column: "PitchEventId",
                principalTable: "PitchEvents",
                principalColumn: "PitchEventId",
                onDelete: ReferentialAction.Restrict);*/
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pitch_PitchEvents_PitchEventId",
                table: "Pitch");

            migrationBuilder.DropIndex(
                name: "IX_Pitch_PitchEventId",
                table: "Pitch");

            migrationBuilder.DropColumn(
                name: "PitchEventId",
                table: "Pitch");
        }
    }
}
