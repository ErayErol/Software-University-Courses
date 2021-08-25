namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Repositories;
    using Git.Services;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using System.Linq;

    using static Data.DataConstants;

    public class RepositoriesController : Controller
    {
        private readonly IValidator validator;
        private readonly GitDbContext data;

        public RepositoriesController(
            IValidator validator,
            GitDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        // this is not require, because by default is [HttpGet]
        [HttpGet]
        // return (Views/Repositories/All.cshtml)
        public HttpResponse All()
        {
            // take repository from data with some logic (LINQ)
            var repositories = this.data
                .Repositories
                .Where(r => r.IsPublic)
                .OrderByDescending(r => r.CreatedOn)
                // create list for Presentation part (Views/Repositories/All.cshtml)
                .Select(r => new RepositoryListingViewModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Owner = r.Owner.Username,
                    CreatedOn = r.CreatedOn.ToLocalTime().ToString("F"),
                    CommitsCount = r.Commits.Count,
                }).ToList();

            // passing the list to Presentation part (Views/Repositories/All.cshtml)
            return View(repositories);
        }

        // only logged in user can go to (Views/Repositories/Create.cshtml)
        [Authorize]
        // this is not require, because by default is [HttpGet]
        [HttpGet]
        // return (Views/Repositories/Create.cshtml)
        public HttpResponse Create() => View();

        // only logged in user can create repository
        [Authorize]
        // this is when user click submit button in form with method post in (Views/Repositories/Create.cshtml)
        [HttpPost]
        // model have prop from (Views/Repositories/Create.cshtml)
        public HttpResponse Create(CreateRepositoryFormModel model)
        {
            var modelErrors = this.validator.ValidateRepository(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            // create model (for Database)
            var repository = new Repository
            {
                OwnerId = this.User.Id,
                Name = model.Name,
                IsPublic = model.RepositoryType == RepositoryTypePublic,
            };

            this.data.Repositories.Add(repository);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }
    }
}
