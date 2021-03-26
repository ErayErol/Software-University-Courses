namespace Quiz.Services
{
    public interface IUserAnswerService
    {
        void AddUserAnswer(string userName, int questionId, int answerId);

        int GetUserResult(string userName, int quizId);
    }
}
