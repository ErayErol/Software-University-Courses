namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Color
    {
        public Color()
        {
            PrimaryKitTeams = new HashSet<Team>();
            SecondaryKitTeams = new HashSet<Team>();
        }

        [Key]
        public int ColorId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Team> PrimaryKitTeams { get; set; }

        public virtual ICollection<Team> SecondaryKitTeams { get; set; }
    }
}