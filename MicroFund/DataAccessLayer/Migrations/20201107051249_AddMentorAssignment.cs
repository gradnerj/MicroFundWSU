using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddMentorAssignment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AddressType_AddressTypeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Applicant_ApplicantId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_AspNetUsers_ApplicantId",
                table: "Applicant");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Applicant_ApplicantId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_ApplicationStatus_ApplicationStatusId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Applicant_ApplicantId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowUp_Application_ApplicationId",
                table: "FollowUp");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowUp_FollowUpType_FollowUpTypeId",
                table: "FollowUp");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_QuestionCategory_QuestionCategoryId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Application_ApplicationId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Question_QuestionId",
                table: "Response");

            migrationBuilder.CreateTable(
                name: "MentorAssignment",
                columns: table => new
                {
                    MentorAssignmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorId = table.Column<string>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    DateAssigned = table.Column<DateTime>(nullable: false),
                    ApprovedToPitchDate = table.Column<DateTime>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorAssignment", x => x.MentorAssignmentId);
                    table.ForeignKey(
                        name: "FK_MentorAssignment_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MentorAssignment_AspNetUsers_MentorId",
                        column: x => x.MentorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentorAssignment_ApplicationId",
                table: "MentorAssignment",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_MentorAssignment_MentorId",
                table: "MentorAssignment",
                column: "MentorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AddressType_AddressTypeId",
                table: "Address",
                column: "AddressTypeId",
                principalTable: "AddressType",
                principalColumn: "AddressTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Applicant_ApplicantId",
                table: "Address",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicant_AspNetUsers_ApplicantId",
                table: "Applicant",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Applicant_ApplicantId",
                table: "Application",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_ApplicationStatus_ApplicationStatusId",
                table: "Application",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatus",
                principalColumn: "ApplicationStatusId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Applicant_ApplicantId",
                table: "ContactInfo",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId",
                table: "ContactInfo",
                column: "ContactTypeId",
                principalTable: "ContactType",
                principalColumn: "ContactTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUp_Application_ApplicationId",
                table: "FollowUp",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUp_FollowUpType_FollowUpTypeId",
                table: "FollowUp",
                column: "FollowUpTypeId",
                principalTable: "FollowUpType",
                principalColumn: "FollowUpTypeId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_QuestionCategory_QuestionCategoryId",
                table: "Question",
                column: "QuestionCategoryId",
                principalTable: "QuestionCategory",
                principalColumn: "QuestionCategoryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Application_ApplicationId",
                table: "Response",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Question_QuestionId",
                table: "Response",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_AddressType_AddressTypeId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Address_Applicant_ApplicantId",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_Applicant_AspNetUsers_ApplicantId",
                table: "Applicant");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Applicant_ApplicantId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_ApplicationStatus_ApplicationStatusId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Applicant_ApplicantId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowUp_Application_ApplicationId",
                table: "FollowUp");

            migrationBuilder.DropForeignKey(
                name: "FK_FollowUp_FollowUpType_FollowUpTypeId",
                table: "FollowUp");

            migrationBuilder.DropForeignKey(
                name: "FK_Question_QuestionCategory_QuestionCategoryId",
                table: "Question");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Application_ApplicationId",
                table: "Response");

            migrationBuilder.DropForeignKey(
                name: "FK_Response_Question_QuestionId",
                table: "Response");

            migrationBuilder.DropTable(
                name: "MentorAssignment");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_AddressType_AddressTypeId",
                table: "Address",
                column: "AddressTypeId",
                principalTable: "AddressType",
                principalColumn: "AddressTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Applicant_ApplicantId",
                table: "Address",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applicant_AspNetUsers_ApplicantId",
                table: "Applicant",
                column: "ApplicantId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Applicant_ApplicantId",
                table: "Application",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_ApplicationStatus_ApplicationStatusId",
                table: "Application",
                column: "ApplicationStatusId",
                principalTable: "ApplicationStatus",
                principalColumn: "ApplicationStatusId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Applicant_ApplicantId",
                table: "ContactInfo",
                column: "ApplicantId",
                principalTable: "Applicant",
                principalColumn: "ApplicantId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_ContactType_ContactTypeId",
                table: "ContactInfo",
                column: "ContactTypeId",
                principalTable: "ContactType",
                principalColumn: "ContactTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUp_Application_ApplicationId",
                table: "FollowUp",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FollowUp_FollowUpType_FollowUpTypeId",
                table: "FollowUp",
                column: "FollowUpTypeId",
                principalTable: "FollowUpType",
                principalColumn: "FollowUpTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Question_QuestionCategory_QuestionCategoryId",
                table: "Question",
                column: "QuestionCategoryId",
                principalTable: "QuestionCategory",
                principalColumn: "QuestionCategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Application_ApplicationId",
                table: "Response",
                column: "ApplicationId",
                principalTable: "Application",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Response_Question_QuestionId",
                table: "Response",
                column: "QuestionId",
                principalTable: "Question",
                principalColumn: "QuestionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
