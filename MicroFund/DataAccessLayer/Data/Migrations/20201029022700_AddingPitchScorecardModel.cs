using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingPitchScorecardModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PitchScorecard",
                columns: table => new
                {
                    PitchId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    MarketValid = table.Column<int>(nullable: false),
                    ValueProp = table.Column<int>(nullable: false),
                    TargetCustomers = table.Column<int>(nullable: false),
                    Competition = table.Column<int>(nullable: false),
                    GoToStrat = table.Column<int>(nullable: false),
                    FinProjections = table.Column<int>(nullable: false),
                    ManagementTeam = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Presentation = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PitchScorecard", x => new { x.PitchId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_PitchScorecard_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PitchScorecard_Pitch_PitchId",
                        column: x => x.PitchId,
                        principalTable: "Pitch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PitchScorecard_ApplicationUserId",
                table: "PitchScorecard",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PitchScorecard");
        }
    }
}
