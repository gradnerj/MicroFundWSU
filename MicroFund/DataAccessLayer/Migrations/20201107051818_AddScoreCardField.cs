using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddScoreCardField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScoreCardField",
                columns: table => new
                {
                    ScoreCardFieldId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScoringCategoryId = table.Column<int>(nullable: false),
                    ScoreCardFieldName = table.Column<string>(maxLength: 128, nullable: false),
                    ScoreCardFieldDescription = table.Column<string>(maxLength: 250, nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    UpdatedBy = table.Column<string>(maxLength: 128, nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    IsArchived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCardField", x => x.ScoreCardFieldId);
                    table.ForeignKey(
                        name: "FK_ScoreCardField_ScoringCategory_ScoringCategoryId",
                        column: x => x.ScoringCategoryId,
                        principalTable: "ScoringCategory",
                        principalColumn: "ScoringCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCardField_ScoringCategoryId",
                table: "ScoreCardField",
                column: "ScoringCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScoreCardField");
        }
    }
}
