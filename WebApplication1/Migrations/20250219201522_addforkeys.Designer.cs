﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Chains;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250219201522_addforkeys")]
    partial class addforkeys
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Assist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Assist");
                });

            modelBuilder.Entity("WebApplication1.Models.Club", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Coach")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Founded")
                        .HasColumnType("int");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("longblob");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StadiumId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StadiumId")
                        .IsUnique();

                    b.ToTable("Club");
                });

            modelBuilder.Entity("WebApplication1.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AssistId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GoalType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("MatchId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MatchId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("WebApplication1.Models.MatchInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AwayClubId")
                        .HasColumnType("int");

                    b.Property<int>("AwayTeamGoals")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HomeClubId")
                        .HasColumnType("int");

                    b.Property<int>("HomeTeamGoals")
                        .HasColumnType("int");

                    b.Property<int>("PossesionAway")
                        .HasColumnType("int");

                    b.Property<int>("PossesionHome")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AwayClubId");

                    b.HasIndex("HomeClubId");

                    b.ToTable("MatchInfo");
                });

            modelBuilder.Entity("WebApplication1.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpiredContractTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("longblob");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime>("SignContractDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("WebApplication1.Models.PlayerStat", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("PlayerId"));

                    b.Property<int>("Assists")
                        .HasColumnType("int");

                    b.Property<int>("Goals")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId1")
                        .HasColumnType("int");

                    b.Property<int>("RedCards")
                        .HasColumnType("int");

                    b.Property<int>("YellowCards")
                        .HasColumnType("int");

                    b.HasKey("PlayerId");

                    b.HasIndex("PlayerId1");

                    b.ToTable("PlayerStat");
                });

            modelBuilder.Entity("WebApplication1.Models.Stadium", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Stadium");
                });

            modelBuilder.Entity("WebApplication1.Models.Standings", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubId")
                        .HasColumnType("int");

                    b.Property<int>("Draws")
                        .HasColumnType("int");

                    b.Property<int>("GoalsConceded")
                        .HasColumnType("int");

                    b.Property<int>("GoalsDifference")
                        .HasColumnType("int");

                    b.Property<int>("GoalsScored")
                        .HasColumnType("int");

                    b.Property<int>("Looses")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<int>("Wins")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubId");

                    b.ToTable("Standings");
                });

            modelBuilder.Entity("WebApplication1.Models.Transfer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClubFromId")
                        .HasColumnType("int");

                    b.Property<int>("ClubToId")
                        .HasColumnType("int");

                    b.Property<int>("PlayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClubFromId");

                    b.HasIndex("ClubToId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Transfer");
                });

            modelBuilder.Entity("WebApplication1.Models.Assist", b =>
                {
                    b.HasOne("WebApplication1.Models.MatchInfo", "Match")
                        .WithMany("Assists")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Models.Club", b =>
                {
                    b.HasOne("WebApplication1.Models.Stadium", "Stadium")
                        .WithOne("Club")
                        .HasForeignKey("WebApplication1.Models.Club", "StadiumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stadium");
                });

            modelBuilder.Entity("WebApplication1.Models.Goal", b =>
                {
                    b.HasOne("WebApplication1.Models.MatchInfo", "Match")
                        .WithMany("Goals")
                        .HasForeignKey("MatchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Match");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Models.MatchInfo", b =>
                {
                    b.HasOne("WebApplication1.Models.Club", "AwayClub")
                        .WithMany()
                        .HasForeignKey("AwayClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Club", "HomeClub")
                        .WithMany()
                        .HasForeignKey("HomeClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AwayClub");

                    b.Navigation("HomeClub");
                });

            modelBuilder.Entity("WebApplication1.Models.Player", b =>
                {
                    b.HasOne("WebApplication1.Models.Club", "Club")
                        .WithMany("players")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("WebApplication1.Models.PlayerStat", b =>
                {
                    b.HasOne("WebApplication1.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Models.Standings", b =>
                {
                    b.HasOne("WebApplication1.Models.Club", "Club")
                        .WithMany()
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Club");
                });

            modelBuilder.Entity("WebApplication1.Models.Transfer", b =>
                {
                    b.HasOne("WebApplication1.Models.Club", "ClubFrom")
                        .WithMany("TransferFrom")
                        .HasForeignKey("ClubFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Club", "ClubTo")
                        .WithMany("TransferTo")
                        .HasForeignKey("ClubToId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Player", "Player")
                        .WithMany("Transfer")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClubFrom");

                    b.Navigation("ClubTo");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("WebApplication1.Models.Club", b =>
                {
                    b.Navigation("TransferFrom");

                    b.Navigation("TransferTo");

                    b.Navigation("players");
                });

            modelBuilder.Entity("WebApplication1.Models.MatchInfo", b =>
                {
                    b.Navigation("Assists");

                    b.Navigation("Goals");
                });

            modelBuilder.Entity("WebApplication1.Models.Player", b =>
                {
                    b.Navigation("Transfer");
                });

            modelBuilder.Entity("WebApplication1.Models.Stadium", b =>
                {
                    b.Navigation("Club");
                });
#pragma warning restore 612, 618
        }
    }
}
