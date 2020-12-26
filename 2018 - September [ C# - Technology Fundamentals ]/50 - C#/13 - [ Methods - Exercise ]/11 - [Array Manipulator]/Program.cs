using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "end")
            {
                string[] commands = command.Split();

                if (commands[0] == "exchange")
                {
                    int index = int.Parse(commands[1]);

                    if (index < 0 || index > arr.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }

                    ExchangingTheArrayByIndex(arr, index);
                }
                else if (commands[0] == "max" || commands[0] == "min")
                {
                    string evenOrOdd = commands[1];

                    if (commands[0] == "max" && commands[1] == "even")
                    {
                        MaxEvenElement(arr);

                    }
                    else if (commands[0] == "min" && commands[1] == "even")
                    {
                        MinEvenElement(arr);
                    }
                    else if (commands[0] == "max" && commands[1] == "odd")
                    {
                        MaxOddElement(arr);
                    }
                    else if (commands[0] == "min" && commands[1] == "odd")
                    {
                        MinOddElement(arr);
                    }
                }
                else if (commands[0] == "first" || commands[0] == "last")
                {
                    int counter = int.Parse(commands[1]);

                    if (counter > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }

                    if (commands[0] == "first" && commands[2] == "even")
                    {
                        FirstEvensCount(arr, counter);
                    }
                    else if (commands[0] == "last" && commands[2] == "even")
                    {
                        LastEvensCount(arr, counter);
                    }
                    else if (commands[0] == "first" && commands[2] == "odd")
                    {
                        FirstOddsCount(arr, counter);
                    }
                    else if (commands[0] == "last" && commands[2] == "odd")
                    {
                        LastOddsCount(arr, counter);
                    }
                }
            }

            Console.WriteLine($"[{string.Join(", ", arr)}]");
        }

        static void ExchangingTheArrayByIndex(int[] array, int index)
        {
            int[] firstArray = new int[array.Length - index - 1];
            int[] secondArray = new int[index + 1];

            int counter = 0;
            
            for (int i = index + 1; i < array.Length; i++)
            {
                firstArray[counter] = array[i];
                counter++;
            }

            for (int i = 0; i < index + 1; i++)
            {
                secondArray[i] = array[i];
            }

            for (int i = 0; i < firstArray.Length; i++)
            {
                array[i] = firstArray[i];
            }

            for (int i = 0; i < secondArray.Length; i++)
            {
                array[firstArray.Length + i] = secondArray[i];
            }
        }

        static void MaxEvenElement(int[] array)
        {
            int maxValue = int.MinValue;
            int indexCounter = 0;
            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] >= maxValue)
                    {
                        maxValue = array[i];
                        indexCounter = i;
                        isFound = true;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexCounter);
            }
        }

        static void MinEvenElement(int[] array)
        {
            int minValue = int.MaxValue;
            int indexCounter = 0;
            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] <= minValue)
                    {
                        minValue = array[i];
                        indexCounter = i;
                        isFound = true;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexCounter);
            }
        }

        static void MaxOddElement(int[] array)
        {
            int maxValue = int.MinValue;
            int indexCounter = 0;
            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] >= maxValue)
                    {
                        maxValue = array[i];
                        indexCounter = i;
                        isFound = true;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexCounter);
            }

        }

        static void MinOddElement(int[] array)
        {
            int minValue = int.MaxValue;
            int indexCounter = 0;
            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] <= minValue)
                    {
                        minValue = array[i];
                        indexCounter = i;
                        isFound = true;
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine(indexCounter);
            }

        }

        static void FirstEvensCount(int[] array, int counter)
        {
            int evensCounter = 0;
            string numbers = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (evensCounter == counter)
                    {
                        break;
                    }

                    numbers += array[i] + " ";
                    evensCounter++;
                }
            }

            var result = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if ((evensCounter > 0) && (evensCounter <= counter))
            {
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
            else
            {
                Console.WriteLine("[]");
            }
        }

        static void LastEvensCount(int[] array, int counter)
        {
            int evensCounter = 0;
            string numbers = string.Empty;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 == 0)
                {
                    if (evensCounter == counter)
                    {
                        break;
                    }

                    numbers += array[i] + " ";
                    evensCounter++;
                }
            }

            var result = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse();

            if ((evensCounter > 0) && (evensCounter <= counter))
            {
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
            else
            {
                Console.WriteLine("[]");
            }
        }

        static void FirstOddsCount(int[] array, int counter)
        {
            int oddsCounter = 0;
            string numbers = string.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (oddsCounter == counter)
                    {
                        break;
                    }

                    numbers += array[i] + " ";
                    oddsCounter++;
                }
            }

            var result = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if ((oddsCounter > 0) && (oddsCounter <= counter))
            {
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
            else
            {
                Console.WriteLine("[]");
            }
        }

        static void LastOddsCount(int[] array, int counter)
        {
            int oddsCounter = 0;
            string numbers = string.Empty;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                if (array[i] % 2 != 0)
                {
                    if (oddsCounter == counter)
                    {
                        break;
                    }

                    numbers += array[i] + " ";
                    oddsCounter++;
                }
            }

            var result = numbers.Split(" ", StringSplitOptions.RemoveEmptyEntries).Reverse();

            if ((oddsCounter > 0) && (oddsCounter <= counter))
            {
                Console.WriteLine($"[{string.Join(", ", result)}]");
            }
            else
            {
                Console.WriteLine("[]");
            }
        }
    }
}
