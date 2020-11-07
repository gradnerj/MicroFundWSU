﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddMentorNote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MentorNote",
                columns: table => new
                {
                    MentorNoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MentorAssignmentId = table.Column<int>(nullable: false),
                    Notes = table.Column<string>(maxLength: 250, nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorNote", x => x.MentorNoteId);
                    table.ForeignKey(
                        name: "FK_MentorNote_MentorAssignment_MentorAssignmentId",
                        column: x => x.MentorAssignmentId,
                        principalTable: "MentorAssignment",
                        principalColumn: "MentorAssignmentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MentorNote_MentorAssignmentId",
                table: "MentorNote",
                column: "MentorAssignmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MentorNote");
        }
    }
}
