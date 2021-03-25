using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Quiz.Models;

namespace Quiz.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Quiz> Quizes { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<UserAnswer> UserAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //FK_Answers_Questions_QuestionId
            builder.Entity<Answer>()
                .HasOne(x => x.Question)
                .WithMany(x => x.Answers)
                .HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Question>()
                .HasOne(x => x.Quiz)
                .WithMany(x => x.Questions)
                .HasForeignKey(x => x.QuizId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
