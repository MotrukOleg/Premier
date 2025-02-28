using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Chains
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Stadium> Stadium { get; set; } = null!;
        public DbSet<Club> Club {  get; set; } = null!;
        public DbSet<Standings> Standings{ get; set; } = null!;
        public DbSet<Player> Player { get; set; }
        public DbSet<PlayerStat> PlayerStat { get; set; }
        public DbSet<MatchInfo> MatchInfo { get; set; }
        public DbSet<Transfer> Transfer { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<Assist> Assist{ get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Club>()
                .HasOne(Club => Club.Stadium)
                .WithOne(Stadium => Stadium.Club)
                .HasForeignKey<Club>(Club => Club.StadiumId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Player>()
                .HasOne(Player => Player.Club)
                .WithMany(Club => Club.players)
                .HasForeignKey(Player => Player.ClubId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PlayerStat>()
                .HasOne(PlayerStat => PlayerStat.Player)
                .WithOne(Player => Player.PlayerStat)
                .HasForeignKey<PlayerStat>(PlayerStat => PlayerStat.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transfer>()
                .HasOne(Transfer => Transfer.Player)
                .WithMany(Player => Player.Transfer)
                .HasForeignKey(Transfer => Transfer.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transfer>()
                .HasOne(Transfer => Transfer.ClubFrom)
                .WithMany(Club => Club.TransferFrom)
                .HasForeignKey(Tranfer => Tranfer.ClubFromId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Transfer>()
                .HasOne(Transfer => Transfer.ClubTo)
                .WithMany(Club => Club.TransferTo)
                .HasForeignKey(Tranfer => Tranfer.ClubToId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Assist>()
                .HasOne(Assist => Assist.Match)
                .WithMany(Match => Match.Assists)
                .HasForeignKey(Assist => Assist.MatchId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Goal>()
                .HasOne(Goal => Goal.Match)
                .WithMany(Match => Match.Goals)
                .HasForeignKey(Goal => Goal.MatchId)
                .OnDelete (DeleteBehavior.Cascade);
        }
    }
}
