using Microsoft.AspNetCore.Identity;

namespace Quiz.Models
{
    public class UserAnswer
    {
        public int Id { get; set; }

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int? AnswerId { get; set; }
        public Answer Answer { get; set; }
    }
}
