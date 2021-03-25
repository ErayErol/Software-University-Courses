using Newtonsoft.Json;
using Quiz.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace Quiz.ConsoleUI
{
    public class JsonImportService : IJsonImportService
    {
        private readonly IQuizService quizService;
        private readonly IQuestionService questionService;
        private readonly IAnswerService answerService;

        public JsonImportService(
            IQuizService quizService,
            IQuestionService questionService,
            IAnswerService answerService)
        {
            this.quizService = quizService;
            this.questionService = questionService;
            this.answerService = answerService;
        }

        public void Import(string fileName, string quizName)
        {
            var json = File.ReadAllText(fileName);
            var questions = JsonConvert.DeserializeObject<IEnumerable<JsonQuestion>>(json);

            var quizId = quizService.Add(quizName);
            foreach (var question in questions)
            {
                var questionId = questionService.Add(question.Question, quizId);
                foreach (var answer in question.Answers)
                {
                    answerService.Add(answer.Answer, answer.Correct ? 1 : 0, answer.Correct, questionId);
                }
            }
        }
    }
}
