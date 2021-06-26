namespace SharedTrip.Models.Trips
{
    using System;

    public class CreateTripFormModel
    {
        public string StartPoint { get; set; }
        
        public string EndPoint { get; set; }
        
        public DateTime DepartureTime { get; set; }

        public string ImagePath { get; set; }
        
        public int Seats { get; set; }
        
        public string Description { get; set; }
    }
}