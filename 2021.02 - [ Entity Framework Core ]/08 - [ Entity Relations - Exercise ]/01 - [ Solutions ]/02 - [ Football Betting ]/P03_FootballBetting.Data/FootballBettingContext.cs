namespace P03_FootballBetting.Data
{
    using Microsoft.EntityFrameworkCore;
    using P03_FootballBetting.Data.Models;

    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }

        public FootballBettingContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerStatistic>()
                .HasKey(ps => new
                {
                    ps.GameId,
                    ps.PlayerId
                });

            modelBuilder.Entity<Team>(team =>
            {
                team.HasOne(x => x.PrimaryKitColor)
                    .WithMany(x => x.PrimaryKitTeams)
                    .HasForeignKey(x => x.PrimaryKitColorId)
                    .OnDelete(DeleteBehavior.NoAction); // this is must for one of PrimaryKitColorId or SecondaryKitColorId

                team.HasOne(x => x.SecondaryKitColor)
                    .WithMany(x => x.SecondaryKitTeams)
                    .HasForeignKey(x => x.SecondaryKitColorId);
            });

            modelBuilder.Entity<Game>(game =>
            {
                game.HasOne(x => x.HomeTeam)
                    .WithMany(x => x.HomeGames)
                    .HasForeignKey(x => x.HomeTeamId)
                    .OnDelete(DeleteBehavior.NoAction); // this is must for one of HomeTeamId or AwayTeamId

                game.HasOne(x => x.AwayTeam)
                    .WithMany(x => x.AwayGames)
                    .HasForeignKey(x => x.AwayTeamId);
            });
                
            modelBuilder.Entity<Player>()
                .HasMany(x => x.PlayerStatistics)
                .WithOne(x => x.Player)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }
    }

    public static class Configuration
    {
        public const string ConnectionString = "Server=.;Database=FootballBetting;Integrated Security=true";
    }
}