using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Stadium",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadium", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Club",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Coach = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Country = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Founded = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<byte[]>(type: "longblob", nullable: true),
                    StadiumId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Club", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Club_Stadium_StadiumId",
                        column: x => x.StadiumId,
                        principalTable: "Stadium",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MatchInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    HomeClubId = table.Column<int>(type: "int", nullable: false),
                    AwayClubId = table.Column<int>(type: "int", nullable: false),
                    PossesionHome = table.Column<int>(type: "int", nullable: false),
                    PossesionAway = table.Column<int>(type: "int", nullable: false),
                    HomeTeamGoals = table.Column<int>(type: "int", nullable: false),
                    AwayTeamGoals = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchInfo_Club_AwayClubId",
                        column: x => x.AwayClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MatchInfo_Club_HomeClubId",
                        column: x => x.HomeClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    Nationality = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Position = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<int>(type: "int", nullable: false),
                    SignContractDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExpiredContractTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<byte[]>(type: "longblob", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Player_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Standings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ClubId = table.Column<int>(type: "int", nullable: false),
                    Wins = table.Column<int>(type: "int", nullable: false),
                    Draws = table.Column<int>(type: "int", nullable: false),
                    Looses = table.Column<int>(type: "int", nullable: false),
                    GoalsScored = table.Column<int>(type: "int", nullable: false),
                    GoalsConceded = table.Column<int>(type: "int", nullable: false),
                    GoalsDifference = table.Column<int>(type: "int", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Standings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Standings_Club_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Assist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    MatchInfoId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assist_MatchInfo_MatchInfoId",
                        column: x => x.MatchInfoId,
                        principalTable: "MatchInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Assist_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    matchInfoId = table.Column<int>(type: "int", nullable: true),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    AssistId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    GoalType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Goal_MatchInfo_matchInfoId",
                        column: x => x.matchInfoId,
                        principalTable: "MatchInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Goal_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PlayerStat",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerId1 = table.Column<int>(type: "int", nullable: false),
                    Goals = table.Column<int>(type: "int", nullable: false),
                    Assists = table.Column<int>(type: "int", nullable: false),
                    YellowCards = table.Column<int>(type: "int", nullable: false),
                    RedCards = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerStat", x => x.PlayerId);
                    table.ForeignKey(
                        name: "FK_PlayerStat_Player_PlayerId1",
                        column: x => x.PlayerId1,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Transfer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    ClubFromId = table.Column<int>(type: "int", nullable: false),
                    ClubToId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transfer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transfer_Club_ClubFromId",
                        column: x => x.ClubFromId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfer_Club_ClubToId",
                        column: x => x.ClubToId,
                        principalTable: "Club",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transfer_Player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Assist_MatchInfoId",
                table: "Assist",
                column: "MatchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Assist_PlayerId",
                table: "Assist",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Club_StadiumId",
                table: "Club",
                column: "StadiumId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Goal_matchInfoId",
                table: "Goal",
                column: "matchInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Goal_PlayerId",
                table: "Goal",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchInfo_AwayClubId",
                table: "MatchInfo",
                column: "AwayClubId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchInfo_HomeClubId",
                table: "MatchInfo",
                column: "HomeClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Player_ClubId",
                table: "Player",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerStat_PlayerId1",
                table: "PlayerStat",
                column: "PlayerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Standings_ClubId",
                table: "Standings",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_ClubFromId",
                table: "Transfer",
                column: "ClubFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_ClubToId",
                table: "Transfer",
                column: "ClubToId");

            migrationBuilder.CreateIndex(
                name: "IX_Transfer_PlayerId",
                table: "Transfer",
                column: "PlayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assist");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "PlayerStat");

            migrationBuilder.DropTable(
                name: "Standings");

            migrationBuilder.DropTable(
                name: "Transfer");

            migrationBuilder.DropTable(
                name: "MatchInfo");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Club");

            migrationBuilder.DropTable(
                name: "Stadium");
        }
    }
}
