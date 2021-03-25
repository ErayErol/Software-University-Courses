using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services.Models
{
    public class UserQuizViewModel
    {
        public int QuizId { get; set; }

        public string Title { get; set; }

        public QuizStatus Status { get; set; }
    }

    public enum QuizStatus
    {
        NotStarted = 1,
        InProgress = 2,
        Finished = 3,
    }
}
