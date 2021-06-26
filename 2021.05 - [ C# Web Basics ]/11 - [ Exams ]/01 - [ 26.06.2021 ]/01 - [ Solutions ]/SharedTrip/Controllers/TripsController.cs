namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Trips;
    using SharedTrip.Services;

    using System.Globalization;
    using System.Linq;

    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public TripsController(
            IValidator validator,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [HttpGet]
        public HttpResponse All()
        {
            if (this.User.IsAuthenticated == false)
            {
                return Redirect("/");
            }

            var trips = this.data
                .Trips
                .Select(r => new TripListingViewModel()
                {
                    Id = r.Id,
                    StartPoint = r.StartPoint,
                    EndPoint = r.EndPoint,
                    Seats = r.Seats,
                    DepartureTime = r.DepartureTime.ToString("dd.MM.yyyy HH:mm")
                }).ToList();

            return View(trips);
        }

        [Authorize]
        [HttpGet]
        public HttpResponse Add() => View();

        [Authorize]
        [HttpPost]
        public HttpResponse Add(CreateTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return Redirect("/Trips/Add");
            }

            var trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = model.DepartureTime,
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath,
                HasSeats = true,
            };

            this.data.Trips.Add(trip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }

        [Authorize]
        [HttpGet]
        public HttpResponse Details(string tripId)
        {
            var tripDetails = this.data
                .Trips
                .Where(c => c.Id == tripId)
                .Select(c => new TripDetailsViewModel()
                {
                    Id = c.Id,
                    ImagePath = c.ImagePath,
                    StartPoint = c.StartPoint,
                    EndPoint = c.EndPoint,
                    DepartureTime = c.DepartureTime.ToString("dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                    Seats = c.Seats,
                    Description = c.Description,
                    HasSeats = c.Seats > 0,
                })
                .FirstOrDefault();

            return tripDetails == null
                ? Error($"Trip with ID '{tripId}' does not exist.")
                : View(tripDetails);
        }

        [Authorize]
        [HttpGet]
        public HttpResponse AddUserToTrip(string tripId)
        {
            var trip = this.data
                .Trips
                .FirstOrDefault(c => c.Id == tripId);

            if (trip == null)
            {
                return Error($"Trip with ID '{tripId}' does not exist.");
            }

            var userJoinTrip = this.data.UserTrips
                .Any(c => c.TripId == tripId && c.UserId == this.User.Id);

            if (userJoinTrip)
            {
                return Error($"You can join the Trip just once.");
            }

            if (trip.HasSeats)
            {
                trip.Seats--;
            }

            var userTrip = new UserTrip()
            {
                TripId = trip.Id,
                UserId = this.User.Id
            };

            this.data.UserTrips.Add(userTrip);

            this.data.SaveChanges();

            return Redirect("/Trips/All");
        }
    }
}