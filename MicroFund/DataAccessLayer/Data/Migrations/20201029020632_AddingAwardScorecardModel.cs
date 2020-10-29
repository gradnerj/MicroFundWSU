using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingAwardScorecardModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AwardScorecard",
                columns: table => new
                {
                    PitchId = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    Geographics = table.Column<int>(nullable: false),
                    Diversity = table.Column<int>(nullable: false),
                    ProbabilityOfSuccess = table.Column<int>(nullable: false),
                    NumberOfJobs = table.Column<int>(nullable: false),
                    BenefitToCompany = table.Column<int>(nullable: false),
                    BenefitToCommunity = table.Column<int>(nullable: false),
                    Returning = table.Column<int>(nullable: false),
                    FollowOnApp = table.Column<int>(nullable: false),
                    GreaterOneKRevenue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AwardScorecard", x => new { x.PitchId, x.ApplicationUserId });
                    table.ForeignKey(
                        name: "FK_AwardScorecard_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AwardScorecard_Pitch_PitchId",
                        column: x => x.PitchId,
                        principalTable: "Pitch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AwardScorecard_ApplicationUserId",
                table: "AwardScorecard",
                column: "ApplicationUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AwardScorecard");
        }
    }
}
