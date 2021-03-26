using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz.Services.Models
{
    public class QuizInputModel
    {
        public string UserId { get; set; }

        public int QuizId { get; set; }

        public List<QuestionInputModel> Questions { get; set; }
    }
}
