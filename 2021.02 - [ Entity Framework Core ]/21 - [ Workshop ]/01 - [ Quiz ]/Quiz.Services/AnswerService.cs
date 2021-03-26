using Quiz.Data;
using Quiz.Models;

namespace Quiz.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly ApplicationDbContext applicationDbContext;

        public AnswerService(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int Add(string title, int points, bool isCorrect, int questionId)
        {
            var answer = new Answer
            {
                Title = title,
                Points = points,
                IsCorrect = isCorrect,
                QuestionId = questionId
            };

            this.applicationDbContext.Answers.Add(answer);
            this.applicationDbContext.SaveChanges();

            return answer.Id;
        }
    }
}
