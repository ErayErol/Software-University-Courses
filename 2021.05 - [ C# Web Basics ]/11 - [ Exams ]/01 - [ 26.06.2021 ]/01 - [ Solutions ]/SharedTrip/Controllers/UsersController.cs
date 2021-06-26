namespace SharedTrip.Controllers
{
    using MyWebServer.Controllers;
    using MyWebServer.Http;
    
    using SharedTrip.Data;
    using SharedTrip.Data.Models;
    using SharedTrip.Models.Users;
    using SharedTrip.Services;
    
    using System.Linq;
    
    using static Data.DataConstants;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly ApplicationDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        [HttpGet]
        public HttpResponse Register()
        {
            return this.User.IsAuthenticated 
                ? Redirect("/Trips/All") 
                : View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUserRegister(model);

            if (this.data.Users.Any(u => u.Username == model.Username))
            {
                modelErrors.Add($"User with '{model.Username}' username already exists.");
            }

            if (this.data.Users.Any(u => u.Email == model.Email))
            {
                modelErrors.Add($"User with '{model.Email}' e-mail already exists.");
            }

            if (modelErrors.Any())
            {
                return Redirect("/Users/Register");
            }

            var user = new User
            {
                Username = model.Username,
                Password = this.passwordHasher
                    .HashPassword(model.Password)
                    .Substring(0, DefaultMaxLength),
                Email = model.Email,
            };

            this.data.Users.Add(user);

            this.data.SaveChanges();

            return Redirect("/Users/Login");
        }

        [HttpGet]
        public HttpResponse Login()
        {
            return this.User.IsAuthenticated
                ? Redirect("/Trips/All")
                : View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel model)
        {
            var hashedPassword = this.passwordHasher
                .HashPassword(model.Password)
                .Substring(0, DefaultMaxLength);

            var userId = this.data
                .Users
                .Where(u => u.Username == model.Username && u.Password == hashedPassword)
                .Select(u => u.Id)
                .FirstOrDefault();

            var modelErrors = this.validator.ValidateUserLogin(model, userId);

            if (modelErrors.Any())
            {
                return Redirect("/Users/Login");
            }

            this.SignIn(userId);

            return Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            this.SignOut();

            return Redirect("/");
        }
    }
}