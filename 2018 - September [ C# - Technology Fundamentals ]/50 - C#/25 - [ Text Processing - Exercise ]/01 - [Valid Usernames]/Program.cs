using System;
using System.Linq;

namespace ValidUsername
{
    class Program
    {
        static void Main(string[] args)
        {
            var words = Console
                .ReadLine()
                .Split(", ")
                .ToList();

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Length > 3 && words[i].Length < 16)
                {
                    bool isValid = true;

                    for (int j = 0; j < words[i].Length; j++)
                    {
                        if (!(((words[i][j] >= 'a' && words[i][j] <= 'z') || (words[i][j] >= 'A' && words[i][j] <= 'Z')) ||
                            (words[i][j] >= 48 && words[i][j] <= 57) ||
                            (words[i][j] == '-') ||
                            (words[i][j] == '_')))
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(words[i]);
                    }
                }
            }
        }
    }
}
