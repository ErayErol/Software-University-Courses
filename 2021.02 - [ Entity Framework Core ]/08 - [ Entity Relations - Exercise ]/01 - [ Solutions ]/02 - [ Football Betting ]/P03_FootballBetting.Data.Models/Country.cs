namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        public Country()
        {
            Towns = new HashSet<Town>();
        }
        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Town> Towns { get; set; }
    }
}