using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingBusinessModelAnalysisModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusinessModelAnalysis",
                columns: table => new
                {
                    MentorId = table.Column<int>(nullable: false),
                    MarketValidation = table.Column<string>(nullable: true),
                    ValueProp = table.Column<string>(nullable: true),
                    ValuePropValidation = table.Column<string>(nullable: true),
                    TargetCustomers = table.Column<string>(nullable: true),
                    Competition = table.Column<string>(nullable: true),
                    ToMarketStrategy = table.Column<string>(nullable: true),
                    FinancialProjections = table.Column<string>(nullable: true),
                    ManagementTeam = table.Column<string>(nullable: true),
                    CurrentStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessModelAnalysis", x => x.MentorId);
                    table.ForeignKey(
                        name: "FK_BusinessModelAnalysis_Mentor_MentorId",
                        column: x => x.MentorId,
                        principalTable: "Mentor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusinessModelAnalysis");
        }
    }
}
