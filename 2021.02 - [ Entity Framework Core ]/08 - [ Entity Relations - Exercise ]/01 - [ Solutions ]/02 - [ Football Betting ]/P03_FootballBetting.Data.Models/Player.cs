namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Player
    {
        public Player()
        {
            PlayerStatistics = new HashSet<PlayerStatistic>();
        }

        [Key]
        public int PlayerId { get; set; }

        public string Name { get; set; }

        public int SquadNumber { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }

        public bool IsInjured { get; set; }

        public virtual ICollection<PlayerStatistic> PlayerStatistics { get; set; }
    }
}