using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.SoftUniCoursePlanning
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> lessons = Console.ReadLine().Split(", ").ToList();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(':');

                if (commands[0] == "course start")
                {
                    for (int i = 0; i < lessons.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{lessons[i]}");
                    }
                    break;
                }

                switch (commands[0])
                {
                    case "Add":
                        GetAdd(lessons, commands);
                        break;
                    case "Insert":
                        GetInsert(lessons, commands);
                        break;
                    case "Remove":
                        GetRemove(lessons, commands);
                        break;
                    case "Exercise":
                        GetExercise(lessons, commands);
                        break;
                    case "Swap":
                        GetSwap(lessons, commands);
                        break;
                }
            }
        }

        static void GetSwap(List<string> lessons, string[] commands)
        {
            string swapLessonFirst = commands[1];
            string swapLessonSecond = commands[2];

            if (lessons.Contains(swapLessonFirst) && lessons.Contains(swapLessonSecond))
            {
                string lessonExerciseFirst = $"{swapLessonFirst}-Exercise";
                string lessonExerciseSecond = $"{swapLessonSecond}-Exercise";

                int indexFirst = lessons.IndexOf(swapLessonFirst);
                int indexSecond = lessons.IndexOf(swapLessonSecond);

                if (lessons.Contains(lessonExerciseFirst) && lessons.Contains(lessonExerciseSecond))
                {
                    lessons.Insert(indexFirst, lessonExerciseSecond);
                    lessons.Insert(indexFirst, swapLessonSecond);
                    lessons.Insert(indexSecond + 2, lessonExerciseFirst);
                    lessons.Insert(indexSecond + 2, swapLessonFirst);

                    lessons.RemoveAt(indexFirst + 2);
                    lessons.RemoveAt(indexFirst + 2);
                    lessons.RemoveAt(indexSecond + 2);
                    lessons.RemoveAt(indexSecond + 2);

                }
                else if (lessons.Contains(lessonExerciseFirst))
                {
                    lessons.Insert(indexFirst, swapLessonSecond);
                    lessons.Insert(indexSecond + 2, lessonExerciseFirst);
                    lessons.Insert(indexSecond + 2, swapLessonFirst);

                    lessons.RemoveAt(indexFirst + 2);
                    lessons.RemoveAt(indexFirst + 2);
                    lessons.RemoveAt(indexSecond + 2);
                }
                else if (lessons.Contains(lessonExerciseSecond))
                {
                    lessons.Insert(indexFirst, lessonExerciseSecond);
                    lessons.Insert(indexFirst, swapLessonSecond);
                    lessons.Insert(indexSecond + 2, swapLessonFirst);

                    lessons.RemoveAt(indexFirst + 2);
                    lessons.RemoveAt(indexSecond + 2);
                    lessons.RemoveAt(indexSecond + 2);
                }
                else
                {
                    lessons.Remove(swapLessonFirst);
                    lessons.Remove(swapLessonSecond);

                    lessons.Insert(indexFirst, swapLessonSecond);
                    lessons.Insert(indexSecond, swapLessonFirst);
                }
            }

        }

        static void GetExercise(List<string> lessons, string[] commands)
        {
            string exerciseLesson = commands[1];

            string exerciseAndLesson = $"{exerciseLesson}-Exercise";

            if (lessons.Contains(exerciseLesson))
            {
                int index = lessons.IndexOf(exerciseLesson);
                lessons.Insert(index + 1, exerciseAndLesson);
            }
            else if (!lessons.Contains(exerciseLesson))
            {
                lessons.Add(exerciseLesson);
                lessons.Add(exerciseAndLesson);
            }
        }

        static void GetRemove(List<string> lessons, string[] commands)
        {
            string removeLesson = commands[1];

            if (lessons.Contains(removeLesson))
            {
                lessons.Remove(removeLesson);
            }
        }

        static void GetInsert(List<string> lessons, string[] commands)
        {
            string currentLesson = commands[1];
            int index = int.Parse(commands[2]);

            if (!lessons.Contains(currentLesson))
            {
                lessons.Insert(index, currentLesson);
            }
        }

        static void GetAdd(List<string> lessons, string[] commands)
        {
            string currentLesson = commands[1];

            if (!lessons.Contains(currentLesson))
            {
                lessons.Add(currentLesson);
            }
        }
    }
}