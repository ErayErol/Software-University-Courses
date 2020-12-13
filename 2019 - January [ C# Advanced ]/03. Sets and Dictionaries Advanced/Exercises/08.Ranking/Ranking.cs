namespace _08.Ranking
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Ranking
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var students = new SortedDictionary<string, Dictionary<string, int>>();

            Contest(contests);
            Students(students, contests);
            Print(students);
        }

        private static void Students(SortedDictionary<string, Dictionary<string, int>> students, Dictionary<string, string> contests)
        {
            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] {"=>"}, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "end of submissions")
                {
                    break;
                }

                string currContest = commands[0];
                string password = commands[1];
                string name = commands[2];
                int currPoint = int.Parse(commands[3]);

                if (contests.ContainsKey(currContest) && contests[currContest] == password)
                {
                    if (students.ContainsKey(name) == false)
                    {
                        students.Add(name, new Dictionary<string, int>());
                    }

                    if (students[name].ContainsKey(currContest) == false)
                    {
                        students[name].Add(currContest, currPoint);
                    }

                    if (currPoint > students[name][currContest])
                    {
                        students[name][currContest] = currPoint;
                    }
                }
            }
        }

        private static void Print(SortedDictionary<string, Dictionary<string, int>> students)
        {
            var topStudent = students.OrderByDescending(x => x.Value.Sum(s => s.Value)).FirstOrDefault();
            Console.WriteLine($"Best candidate is {topStudent.Key} with total {topStudent.Value.Values.Sum()} points.");

            Console.WriteLine("Ranking:");
            foreach (var kvp in students)
            {
                Console.WriteLine(kvp.Key);
                foreach (var kv in kvp.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {kv.Key} -> {kv.Value}");
                }
            }
        }

        private static void Contest(Dictionary<string, string> contests)
        {
            while (true)
            {
                var commands = Console.ReadLine().Split(new string[] {":"}, StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "end of contests")
                {
                    break;
                }

                string currContest = commands[0];
                string password = commands[1];

                if (contests.ContainsKey(currContest) == false)
                {
                    contests.Add(currContest, password);
                }
            }
        }
    }
}