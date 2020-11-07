using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddScoreCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScoreCard",
                columns: table => new
                {
                    ScoreCardId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PitchId = table.Column<int>(nullable: false),
                    JudgeId = table.Column<string>(nullable: false),
                    ScoreCardFieldId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(maxLength: 250, nullable: true),
                    Score = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCard", x => x.ScoreCardId);
                    table.ForeignKey(
                        name: "FK_ScoreCard_AspNetUsers_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScoreCard_Pitch_PitchId",
                        column: x => x.PitchId,
                        principalTable: "Pitch",
                        principalColumn: "PitchId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScoreCard_ScoreCardField_ScoreCardFieldId",
                        column: x => x.ScoreCardFieldId,
                        principalTable: "ScoreCardField",
                        principalColumn: "ScoreCardFieldId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_JudgeId",
                table: "ScoreCard",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_PitchId",
                table: "ScoreCard",
                column: "PitchId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCard_ScoreCardFieldId",
                table: "ScoreCard",
                column: "ScoreCardFieldId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreCard");
        }
    }
}
