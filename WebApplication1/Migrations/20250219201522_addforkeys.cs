using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class addforkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assist_MatchInfo_MatchInfoId",
                table: "Assist");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_MatchInfo_matchInfoId",
                table: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_Goal_matchInfoId",
                table: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_Assist_MatchInfoId",
                table: "Assist");

            migrationBuilder.DropColumn(
                name: "matchInfoId",
                table: "Goal");

            migrationBuilder.DropColumn(
                name: "MatchInfoId",
                table: "Assist");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_MatchId",
                table: "Goal",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Assist_MatchId",
                table: "Assist",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assist_MatchInfo_MatchId",
                table: "Assist",
                column: "MatchId",
                principalTable: "MatchInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_MatchInfo_MatchId",
                table: "Goal",
                column: "MatchId",
                principalTable: "MatchInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assist_MatchInfo_MatchId",
                table: "Assist");

            migrationBuilder.DropForeignKey(
                name: "FK_Goal_MatchInfo_MatchId",
                table: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_Goal_MatchId",
                table: "Goal");

            migrationBuilder.DropIndex(
                name: "IX_Assist_MatchId",
                table: "Assist");

            migrationBuilder.AddColumn<int>(
                name: "matchInfoId",
                table: "Goal",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchInfoId",
                table: "Assist",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goal_matchInfoId",
                table: "Goal",
                column: "matchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Assist_MatchInfoId",
                table: "Assist",
                column: "MatchInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Assist_MatchInfo_MatchInfoId",
                table: "Assist",
                column: "MatchInfoId",
                principalTable: "MatchInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Goal_MatchInfo_matchInfoId",
                table: "Goal",
                column: "matchInfoId",
                principalTable: "MatchInfo",
                principalColumn: "Id");
        }
    }
}
