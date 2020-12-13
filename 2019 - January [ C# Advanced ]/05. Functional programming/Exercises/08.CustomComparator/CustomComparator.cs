namespace _08.CustomComparator
{
    using System;
    using System.Linq;

    class CustomComparator
    {
        static void Main(string[] args)
        {
            Func<int, int, int> myCustomComparer = (a, b) =>
              {
                  if (a % 2 == 0)
                  {
                      return 1;
                  }
                  else if (a % 2 != 1)
                  {
                      return -1;
                  }
                  else
                  {
                      return 0;
                  }

              };

            var input = Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(input, new Comparison<int>(myCustomComparer));


        }
    }
}