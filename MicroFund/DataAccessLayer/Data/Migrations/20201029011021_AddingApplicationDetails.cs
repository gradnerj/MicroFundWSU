using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingApplicationDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicantId = table.Column<int>(nullable: false),
                    StatusOfBusiness = table.Column<string>(nullable: true),
                    StartedDate = table.Column<DateTime>(nullable: false),
                    Industry = table.Column<string>(nullable: true),
                    ProductServiceDescription = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    PrototypeFile = table.Column<string>(nullable: true),
                    IPDescription = table.Column<string>(nullable: true),
                    SalesDescription = table.Column<string>(nullable: true),
                    HasExternalFunding = table.Column<bool>(nullable: false),
                    MarketOpportunity = table.Column<string>(nullable: true),
                    TargetMarketDemographic = table.Column<string>(nullable: true),
                    ProjectedSalesDescription = table.Column<string>(nullable: true),
                    CompetitionDescription = table.Column<string>(nullable: true),
                    TeamDescription = table.Column<string>(nullable: true),
                    AmountRequested = table.Column<float>(nullable: false),
                    PlanForFunds = table.Column<string>(nullable: true),
                    PreviousMicroFundRecipient = table.Column<bool>(nullable: false),
                    HearAboutMicroFund = table.Column<string>(nullable: true),
                    HaveAttendedMicroFunWorkshop = table.Column<bool>(nullable: false),
                    OneMillionCupsExperience = table.Column<bool>(nullable: false),
                    SmallBusinessDevCenterCounselorDescription = table.Column<string>(nullable: true),
                    CompanyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApplicationDetails_Applicant_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "Applicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationDetails_ApplicantId",
                table: "ApplicationDetails",
                column: "ApplicantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationDetails");
        }
    }
}
