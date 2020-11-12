using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class addedDemographics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_ApplicantId",
                table: "ContactInfo");

            migrationBuilder.DropIndex(
                name: "IX_Application_ApplicantId",
                table: "Application");

            migrationBuilder.DropIndex(
                name: "IX_Address_ApplicantId",
                table: "Address");

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
                name: "Gender",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HighestEduCompleted",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Income",
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

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "ContactInfo",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Application",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Address",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateTable(
                name: "Demographics",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
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
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demographics", x => x.ApplicationUserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demographics");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "ContactInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CurrentStudent",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DOB",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HighestEduCompleted",
                table: "AspNetUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Income",
                table: "AspNetUsers",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RaceEthnicity",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ResidenceEnvironment",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "AspNetUsers",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VeteranStatus",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WSUEmployee",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WSUEntrepreneurshipMinor",
                table: "AspNetUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WSUNumber",
                table: "AspNetUsers",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Application",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ApplicantId",
                table: "Address",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_ApplicantId",
                table: "ContactInfo",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Application_ApplicantId",
                table: "Application",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_ApplicantId",
                table: "Address",
                column: "ApplicantId");

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
    }
}
