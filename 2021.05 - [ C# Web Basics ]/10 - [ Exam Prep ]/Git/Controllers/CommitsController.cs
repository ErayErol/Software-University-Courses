namespace Git.Controllers
{
    using Git.Data;
    using Git.Data.Models;
    using Git.Models.Commits;
    using Git.Services;

    using MyWebServer.Controllers;
    using MyWebServer.Http;

    using System.Linq;

    public class CommitsController : Controller
    {
        private readonly IValidator validator;
        private readonly GitDbContext data;

        public CommitsController(
            IValidator validator,
            GitDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        // this is not require, because by default is [HttpGet]
        [HttpGet]
        // this is when user click [Create button] in (Views/Repository/All.cshtml)
        // this (repository) id comes from href in [Create button] in (Views/Repository/All.cshtml)
        public HttpResponse Create(string id)
        {
            // take repository from data with some logic (LINQ)
            var repository = this.data
                .Repositories
                .Where(r => r.Id == id)
                // create model for Presentation part (Views/Commits/Create.cshtml)
                .Select(r => new CommitToRepositoryViewModel
                {
                    Id = r.Id,
                    Name = r.Name,
                })
                .FirstOrDefault();

            return repository != null
                // passing the list to Presentation part (Views/Commits/Create.cshtml)
                ? View(repository)
                // if list doesn't exist => error (BadRequest)
                : BadRequest();
        }

        // only logged in user can create repository
        [Authorize]
        // this is when user click submit button in form with method post in (Views/Commits/Create.cshtml)
        [HttpPost]
        // model have prop from (Views/Commits/Create.cshtml)
        public HttpResponse Create(CreateCommitFormModel model)
        {
            if (this.data.Repositories.Any(r => r.Id == model.Id) == false)
            {
                return NotFound();
            }

            var modelErrors = this.validator.ValidateCommit(model);

            if (modelErrors.Any())
            {
                return Error(modelErrors);
            }

            // create model (for Database)
            var commit = new Commit()
            {
                Description = model.Description,
                RepositoryId = model.Id,
                CreatorId = this.User.Id,
            };

            this.data.Commits.Add(commit);

            this.data.SaveChanges();

            return Redirect("/Repositories/All");
        }

        // only logged in user can view commits
        [Authorize]
        public HttpResponse All()
        {
            // take commits from data with some logic (LINQ) (LINQ)
            var commits = this.data
                .Commits
                .Where(c => c.CreatorId == this.User.Id)
                .OrderByDescending(c => c.CreatedOn)
                // create list for Presentation part (Views/Commits/All.cshtml)
                .Select(c => new CommitListingViewModel()
                {
                    Id = c.Id,
                    Repository = c.Repository.Name,
                    Description = c.Description,
                    CreatedOn = c.CreatedOn.ToLocalTime().ToString("F"),
                }).ToList();

            return View(commits);
        }

        // only logged in user (owner) can delete commits
        [Authorize]
        public HttpResponse Delete(string id)
        {
            // take commits from data with some logic (LINQ) (LINQ)
            var commit = this.data.Commits.Find(id);

            if (commit == null || commit.CreatorId != this.User.Id)
            {
                return BadRequest();
            }

            this.data.Commits.Remove(commit);

            this.data.SaveChanges();

            return Redirect("/Commits/All");
        }
    }
}
