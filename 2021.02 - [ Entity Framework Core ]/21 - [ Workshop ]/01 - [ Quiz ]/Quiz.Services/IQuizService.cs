using Quiz.Services.Models;
using System.Collections.Generic;

namespace Quiz.Services
{
    public interface IQuizService
    {
        int Add(string title);

        QuizViewModel GetQuizById(int quizId);

        IEnumerable<UserQuizViewModel> GetQuizesByUserName(string userName);

        void StartQuiz(string userName, int quizId);
    }
}
