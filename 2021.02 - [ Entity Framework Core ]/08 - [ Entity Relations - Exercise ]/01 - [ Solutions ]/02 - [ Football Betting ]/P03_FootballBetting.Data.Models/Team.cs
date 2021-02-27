namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Team
    {
        public Team()
        {
            Players = new HashSet<Player>();
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
        }

        [Key]
        public int TeamId { get; set; }

        public decimal Budget { get; set; }

        public string Initials { get; set; }

        public string LogoUrl { get; set; }

        public string Name { get; set; }

        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }

        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }

        public int TownId { get; set; }
        public Town Town { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Game> HomeGames { get; set; }
        public virtual ICollection<Game> AwayGames { get; set; }
    }
}