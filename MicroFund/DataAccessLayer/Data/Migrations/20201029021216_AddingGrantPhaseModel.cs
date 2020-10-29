using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MicroFund.Data.Migrations
{
    public partial class AddingGrantPhaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrantPhase",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PitchId = table.Column<int>(nullable: false),
                    AwardDate = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<float>(nullable: false),
                    Requested = table.Column<float>(nullable: false),
                    Agreement = table.Column<string>(nullable: true),
                    ReqNumber = table.Column<int>(nullable: false),
                    MailedDate = table.Column<DateTime>(nullable: false),
                    Provider = table.Column<string>(nullable: true),
                    DateInKindUsed = table.Column<DateTime>(nullable: false),
                    DateInKindCompleted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrantPhase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrantPhase_Pitch_PitchId",
                        column: x => x.PitchId,
                        principalTable: "Pitch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrantPhase_PitchId",
                table: "GrantPhase",
                column: "PitchId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrantPhase");
        }
    }
}
