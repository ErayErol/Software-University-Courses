namespace Git.Services
{
    using Git.Models.Commits;
    using Git.Models.Repositories;
    using Git.Models.Users;

    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    using static Data.DataConstants;

    public class Validator : IValidator
    {
        public ICollection<string> ValidateUser(RegisterUserFormModel model)
        {
            var errors = new List<string>();

            if (model.Username.Length < UserMinUsername || model.Username.Length > DefaultMaxLength)
            {
                errors.Add($"Username '{model.Username}' is not valid. It must be between {UserMinUsername} and {DefaultMaxLength} characters long.");
            }

            if (!Regex.IsMatch(model.Email, UserEmailRegularExpression))
            {
                errors.Add($"Email {model.Email} is not a valid e-mail address.");
            }

            if (model.Password.Length < UserMinPassword || model.Password.Length > DefaultMaxLength)
            {
                errors.Add($"The provided password is not valid. It must be between {UserMinPassword} and {DefaultMaxLength} characters long.");
            }

            if (model.Password.Any(x => x == ' '))
            {
                errors.Add("The provided password cannot contain whitespaces.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                errors.Add("Password and its confirmation are different.");
            }

            return errors;
        }

        public ICollection<string> ValidateRepository(CreateRepositoryFormModel model)
        {
            var errors = new List<string>();

            if (model.Name.Length < RepositoryNameMinLength || model.Name.Length > RepositoryNameMaxLength)
            {
                errors.Add($"Repository Name '{model.Name}' is not valid. It must be between {RepositoryNameMinLength} and {RepositoryNameMaxLength} characters long.");
            }

            if (model.RepositoryType != RepositoryTypePrivate && model.RepositoryType != RepositoryTypePublic)
            {
                errors.Add($"Repository type '{model.RepositoryType}' is not valid. It must be {RepositoryTypePublic} or {RepositoryTypePrivate}.");
            }

            return errors;
        }

        public ICollection<string> ValidateCommit(CreateCommitFormModel model)
        {
            var errors = new List<string>();

            if (model.Description.Length < CommitDescriptionMinLength)
            {
                errors.Add($"Commit description length should be at least {CommitDescriptionMinLength} characters.");
            }

            return errors;
        }
    }
}
