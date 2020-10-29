using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingDemographicModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demographic",
                columns: table => new
                {
                    ApplicantId = table.Column<int>(nullable: false),
                    HighestLevelEducationCompleted = table.Column<string>(nullable: true),
                    WNumber = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    RaceOrEthnicity = table.Column<string>(nullable: true),
                    AgeRange = table.Column<string>(nullable: true),
                    IncomeRange = table.Column<string>(nullable: true),
                    ResidenceEnvironment = table.Column<string>(nullable: true),
                    MilitaryStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographic", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_Demographic_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demographic");
        }
    }
}
