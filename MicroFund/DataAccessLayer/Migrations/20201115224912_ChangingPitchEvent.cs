using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class ChangingPitchEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PitchEvents",
                table: "PitchEvents");

            migrationBuilder.DropColumn(
                name: "PitchId",
                table: "PitchEvents");

            migrationBuilder.AddColumn<int>(
                name: "PitchEventId",
                table: "PitchEvents",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PitchEvents",
                table: "PitchEvents",
                column: "PitchEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PitchEvents",
                table: "PitchEvents");

            migrationBuilder.DropColumn(
                name: "PitchEventId",
                table: "PitchEvents");

            migrationBuilder.AddColumn<int>(
                name: "PitchId",
                table: "PitchEvents",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PitchEvents",
                table: "PitchEvents",
                column: "PitchId");
        }
    }
}
