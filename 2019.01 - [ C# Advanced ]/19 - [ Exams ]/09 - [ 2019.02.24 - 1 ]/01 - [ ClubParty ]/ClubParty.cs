namespace _01.ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ClubParty
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Array.Reverse(input);
            var reverse = input;

            var dic1 = new Dictionary<char, int>();
            var halls = new Queue<char>();

            var list = new List<int>();

            for (int i = 0; i < reverse.Length; i++)
            {
                if (char.IsLetter(reverse[i][0]))
                {
                    halls.Enqueue(reverse[i][0]);
                    if (dic1.ContainsKey(reverse[i][0]) == false)
                    {
                        dic1.Add(reverse[i][0], 0);
                        continue;
                    }
                }
                else
                {
                    if (dic1.Count == 0)
                    {
                        continue;
                    }

                    var value = int.Parse(reverse[i]);
                    if (halls.Any() == false)
                    {
                        continue;
                    }
                    dic1[halls.Peek()] += value;

                    if (dic1[halls.Peek()] < maxCapacity)
                    {
                        list.Add(value);
                        continue;
                    }
                    else
                    {
                        if (dic1[halls.Peek()] == maxCapacity)
                        {
                            list.Add(value);
                        }
                        Console.Write(halls.Dequeue() + " -> ");
                        Console.WriteLine(string.Join(", ", list));
                        list.Clear();

                        if (halls.Any() == false)
                        {
                            continue;
                        }
                        dic1[halls.Peek()] += value;
                        list.Add(value);

                    }
                }


            }
        }
    }
}
