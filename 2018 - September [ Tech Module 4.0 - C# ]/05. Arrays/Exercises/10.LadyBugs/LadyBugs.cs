namespace p_02
{
    using System;

    class LadyBugs
    {
        public static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());
            int[] ladybugField = new int[fieldSize];

            string[] occupiedIndexes = Console.ReadLine().Split();

            for (int i = 0; i < occupiedIndexes.Length; i++)
            {
                int currentIndex = int.Parse(occupiedIndexes[i]);

                if (currentIndex >= 0 && currentIndex < fieldSize)
                {
                    ladybugField[currentIndex] = 1;
                }
            }

            string[] command = Console.ReadLine().Split();

            while (command[0] != "end")
            {
                bool isFirst = true;
                int currentIndex = int.Parse(command[0]);

                while (currentIndex >= 0 && currentIndex < fieldSize
                    && ladybugField[currentIndex] != 0)
                {
                    if (isFirst)
                    {
                        ladybugField[currentIndex] = 0;
                        isFirst = false;
                    }

                    string direction = command[1];
                    int flightLength = int.Parse(command[2]);

                    if (direction == "left")
                    {
                        currentIndex -= flightLength;

                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugField[currentIndex] == 0)
                            {
                                ladybugField[currentIndex] = 1;
                                break;
                            }
                        }
                    }
                    else
                    {
                        currentIndex += flightLength;

                        if (currentIndex >= 0 && currentIndex < fieldSize)
                        {
                            if (ladybugField[currentIndex] == 0)
                            {
                                ladybugField[currentIndex] = 1;
                                break;
                            }
                        }
                    }

                }

                command = Console.ReadLine().Split();
            }

            Console.WriteLine(string.Join(" ", ladybugField));
        }
    }
}