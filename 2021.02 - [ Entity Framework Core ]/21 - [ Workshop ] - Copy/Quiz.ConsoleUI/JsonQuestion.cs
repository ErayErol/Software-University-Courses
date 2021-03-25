using System.Collections.Generic;

namespace Quiz.ConsoleUI
{
    public class JsonQuestion
    {
        public string Question { get; set; }

        public IEnumerable<JsonAnswer> Answers { get; set; }
    }
}
