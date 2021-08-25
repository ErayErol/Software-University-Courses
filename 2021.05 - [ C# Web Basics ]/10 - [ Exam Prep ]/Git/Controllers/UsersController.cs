namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Users;
    using Git.Services;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using System.Linq;

    using static Data.DataConstants;

    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IPasswordHasher passwordHasher;
        private readonly GitDbContext data;

        public UsersController(
            IValidator validator,
            IPasswordHasher passwordHasher,
            GitDbContext data)
        {
            this.validator = validator;
            this.passwordHasher = passwordHasher;
            this.data = data;
        }

        // this is not require, because by default is [HttpGet]
        [HttpGet]
        // return (Views/Users/Register.cshtml)
        public HttpResponse Register() => View();

        // this is when user click submit button in form with method post in (Views/Users/Register.cshtml)
        [HttpPost]
        // model have prop from (Views/Users/Register.cshtml)
        public HttpResponse Register(RegisterUserFormModel model)
        {
            var modelErrors = this.validator.ValidateUser(model);

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
                return Error(modelErrors);
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

        // this is not require, because by default is [HttpGet]
        [HttpGet]
        // return (Views/Users/Login.cshtml)
        public HttpResponse Login() => View();

        // this is when user click submit button in form with method post in (Views/Users/Login.cshtml)
        [HttpPost]
        // model have prop from (Views/Users/Login.cshtml)
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

            if (userId == null)
            {
                return Error($"Username and password combination is not valid or user with '{model.Username}' is not registered.");
            }

            // user is logged in
            this.SignIn(userId);

            return Redirect("/Repositories/All");
        }

        [Authorize]
        public HttpResponse Logout()
        {
            // user is logged out
            this.SignOut();

            return Redirect("/");
        }
    }
}