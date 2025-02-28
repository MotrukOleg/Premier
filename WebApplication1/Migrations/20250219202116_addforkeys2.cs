using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class addforkeys2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStat_Player_PlayerId1",
                table: "PlayerStat");

            migrationBuilder.DropIndex(
                name: "IX_PlayerStat_PlayerId1",
                table: "PlayerStat");

            migrationBuilder.DropColumn(
                name: "PlayerId1",
                table: "PlayerStat");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerStat",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStat_Player_PlayerId",
                table: "PlayerStat",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlayerStat_Player_PlayerId",
                table: "PlayerStat");

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "PlayerStat",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId1",
                table: "PlayerStat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_PlayerId1",
                table: "PlayerStat",
                column: "PlayerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_PlayerStat_Player_PlayerId1",
                table: "PlayerStat",
                column: "PlayerId1",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
