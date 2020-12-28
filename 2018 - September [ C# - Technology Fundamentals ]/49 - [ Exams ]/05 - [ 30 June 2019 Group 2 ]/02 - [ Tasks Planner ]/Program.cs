using System;
using System.Collections.Generic;
using System.Linq;

namespace TasksPlanner
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> hours = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input;
            int index = 0;
            int time = 0;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] commands = input
                    .Split()
                    .ToArray();

                switch (commands[0])
                {
                    case "Complete":
                        index = int.Parse(commands[1]);

                        CompletingTask(hours, index);
                        break;
                    case "Change":
                        index = int.Parse(commands[1]);
                        time = int.Parse(commands[2]);

                        ChangingTask(hours, index, time);
                        break;
                    case "Drop":
                        index = int.Parse(commands[1]);

                        DroppingTask(hours, index);
                        break;
                    case "Count":
                        switch (commands[1])
                        {
                            case "Completed":
                                int completed = CountingCompletedTasks(hours);

                                Console.WriteLine(completed);
                                break;
                            case "Incomplete":
                                int incompleted = CountingCompletedTasks(hours);

                                Console.WriteLine(incompleted);
                                break;
                            case "Dropped":
                                int dropped = CountingDroppedTasks(hours);

                                Console.WriteLine(dropped);
                                break;
                        }
                        break;
                }
            }

            for (int i = 0; i < hours.Count; i++)
            {
                if (hours[i] > 0)
                {
                    Console.Write(hours[i] + " ");
                }
            }
        }

        static void CompletingTask(List<int> hours, int index)
        {
            if (index >= 0 && index < hours.Count)
            {
                hours[index] = 0;
            }
        }

        static void ChangingTask(List<int> hours, int index, int time)
        {
            if (index >= 0 && index < hours.Count)
            {
                hours[index] = time;
            }
        }

        static void DroppingTask(List<int> hours, int index)
        {
            if (index >= 0 && index < hours.Count)
            {
                hours[index] = -1;
            }
        }

        static int CountingCompletedTasks(List<int> hours)
        {
            int completedCounter = 0;

            for (int i = 0; i < hours.Count; i++)
            {
                if (hours[i] == 0)
                {
                    completedCounter++;
                }
            }

            return completedCounter;
        }

        static int CountingIncompletedTasks(List<int> hours)
        {
            int incompletedCounter = 0;

            for (int i = 0; i < hours.Count; i++)
            {
                if (hours[i] > 0)
                {
                    incompletedCounter++;
                }
            }

            return incompletedCounter;
        }

        static int CountingDroppedTasks(List<int> hours)
        {
            int droppedCounter = 0;

            for (int i = 0; i < hours.Count; i++)
            {
                if (hours[i] < 0)
                {
                    droppedCounter++;
                }
            }

            return droppedCounter;
        }
    }
}
