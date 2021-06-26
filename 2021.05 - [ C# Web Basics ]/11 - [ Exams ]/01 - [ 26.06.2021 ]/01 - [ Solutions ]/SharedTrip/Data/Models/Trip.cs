namespace SharedTrip.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using static DataConstants;

    public class Trip
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        [MaxLength(TripMaxSeats)]
        public int Seats { get; set; }

        [Required]
        [MaxLength(TripMaxDescription)]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public bool HasSeats { get; set; }

        public virtual IEnumerable<UserTrip> UserTrips { get; init; } = new HashSet<UserTrip>();
    }
}