using System.Linq;
using Quiz.Data;
using Quiz.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Quiz.Models;
using System;

namespace Quiz.Services
{
    public class QuizSerivce : IQuizService
    {
        private readonly ApplicationDbContext db;

        public QuizSerivce(ApplicationDbContext db)
        {
            this.db = db;
        }

        public int Add(string title)
        {
            var quiz = new Quiz.Models.Quiz
            {
                Title = title
            };

            this.db.Quizes.Add(quiz);
            this.db.SaveChanges();

            return quiz.Id;
        }

        public QuizViewModel GetQuizById(int quizId)
        {
            var quiz = this.db.Quizes
                .Include(x => x.Questions)
                .ThenInclude(x => x.Answers)
                .FirstOrDefault(x => x.Id == quizId);

            var quizViewModel = new QuizViewModel
            {
                Id = quizId,
                Title = quiz.Title,
                Questions = quiz.Questions.OrderBy(r => Guid.NewGuid()).Select(x => new QuestionViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Answers = x.Answers.OrderBy(r => Guid.NewGuid()).Select(a => new AnswerViewModel
                    {
                        Id = a.Id,
                        Title = a.Title
                    })
                    .ToList()
                })
                .ToList()
            };

            return quizViewModel;
        }

        public IEnumerable<UserQuizViewModel> GetQuizesByUserName(string userName)
        {
            var quizes = db.Quizes.Select(x => new UserQuizViewModel
            {
                QuizId = x.Id,
                Title = x.Title,
            }).ToList();

            foreach (var quiz in quizes)
            {
                var questionsCount = db.UserAnswers
                    .Count(ua => ua.IdentityUser.UserName == userName
                                && ua.Question.QuizId == quiz.QuizId);
                if (questionsCount == 0)
                {
                    quiz.Status = QuizStatus.NotStarted;
                    continue;
                }

                var answeredQuestions = db.UserAnswers
                    .Count(ua => ua.IdentityUser.UserName == userName
                                && ua.Question.QuizId == quiz.QuizId
                                && ua.AnswerId.HasValue);
                if (answeredQuestions == questionsCount)
                {
                    quiz.Status = QuizStatus.Finished;
                }
                else
                {
                    quiz.Status = QuizStatus.InProgress;
                }
            }

            return quizes;
        }

        public void StartQuiz(string userName, int quizId)
        {
            if (db.UserAnswers.Any(x => x.IdentityUser.UserName == userName
                && x.Question.QuizId == quizId))
            {
                return;
            }

            var userId = this.db.Users.Where(x => x.UserName == userName)
                .Select(x => x.Id).FirstOrDefault();
            var questions = db.Questions.Where(x => x.QuizId == quizId)
                .Select(x => new { x.Id }).ToList();
            foreach (var question in questions)
            {
                db.UserAnswers.Add(new UserAnswer
                {
                    AnswerId = null,
                    IdentityUserId = userId,
                    QuestionId = question.Id,
                });
            }

            db.SaveChanges();
        }
    }
}
