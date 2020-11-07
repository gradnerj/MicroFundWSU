using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UpdateApplicantType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Applicant_ApplicantId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Applicant_ApplicantId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Applicant_ApplicantId",
                table: "ContactInfo");

            migrationBuilder.DropTable(
                name: "Applicant");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CurrentStudent",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HighestEduCompleted",
                table: "AspNetUsers",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Income",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsArchived",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaceEthnicity",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidenceEnvironment",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "AspNetUsers",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VeteranStatus",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WSUEmployee",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WSUEntrepreneurshipMinor",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WSUNumber",
                table: "AspNetUsers",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AspNetUsers_ApplicantId",
                table: "Address",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_AspNetUsers_ApplicantId",
                table: "Application",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_AspNetUsers_ApplicantId",
                table: "ContactInfo",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AspNetUsers_ApplicantId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_AspNetUsers_ApplicantId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_AspNetUsers_ApplicantId",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CurrentStudent",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DOB",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HighestEduCompleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Income",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IsArchived",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RaceEthnicity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ResidenceEnvironment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VeteranStatus",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WSUEmployee",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WSUEntrepreneurshipMinor",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WSUNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Applicant",
                columns: table => new
                {
                    ApplicantId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CurrentStudent = table.Column<bool>(type: "bit", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HighestEduCompleted = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Income = table.Column<float>(type: "real", nullable: false),
                    IsArchived = table.Column<bool>(type: "bit", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    RaceEthnicity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidenceEnvironment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VeteranStatus = table.Column<bool>(type: "bit", nullable: false),
                    WSUEmployee = table.Column<bool>(type: "bit", nullable: false),
                    WSUEntrepreneurshipMinor = table.Column<bool>(type: "bit", nullable: false),
                    WSUNumber = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applicant", x => x.ApplicantId);
                    table.ForeignKey(
                        name: "FK_Applicant_AspNetUsers_ApplicantId",
                        column: x => x.ApplicantId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Applicant_ApplicantId",
                table: "Address",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Applicant_ApplicantId",
                table: "Application",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Applicant_ApplicantId",
                table: "ContactInfo",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
