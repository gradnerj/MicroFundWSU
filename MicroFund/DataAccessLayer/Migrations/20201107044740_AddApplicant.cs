using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddApplicant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ApplicantId = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 64, nullable: false),
                    LastName = table.Column<string>(maxLength: 64, nullable: false),
                    DOB = table.Column<DateTime>(nullable: false),
                    HighestEduCompleted = table.Column<string>(maxLength: 64, nullable: false),
                    CurrentStudent = table.Column<bool>(nullable: false),
                    WSUEntrepreneurshipMinor = table.Column<bool>(nullable: false),
                    WSUEmployee = table.Column<bool>(nullable: false),
                    WSUNumber = table.Column<string>(maxLength: 64, nullable: true),
                    Gender = table.Column<string>(nullable: false),
                    RaceEthnicity = table.Column<string>(nullable: false),
                    Income = table.Column<float>(nullable: false),
                    ResidenceEnvironment = table.Column<string>(nullable: false),
                    VeteranStatus = table.Column<bool>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_Applicant_AspNetUsers_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applicant");
        }
    }
}
