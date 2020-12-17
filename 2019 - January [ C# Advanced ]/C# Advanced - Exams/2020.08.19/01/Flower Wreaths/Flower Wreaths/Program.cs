namespace Flower_Wreaths
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int wreath = 0;
            List<int> storedFlowers = new List<int>();

            List<int> lilies = Reading();
            List<int> roses = Reading();

            // You will start crafting from the last lilies and the first roses.
            var stack = new Stack<int>(lilies);
            var queue = new Queue<int>(roses);

            while (stack.Any() && queue.Any())
            {
                var lastLilie = stack.Peek();
                var firstRose = queue.Peek();

                var sum = lastLilie + firstRose;

                if (sum > 15)
                {
                    // just decrease the value of the lilies by 2
                    var newLastLilie = lastLilie - 2;
                    stack.Pop();
                    stack.Push(newLastLilie);

                    sum -= lastLilie;
                    sum += newLastLilie;
                }

                if (sum == 15)
                {
                    // – create one wreath and remove them
                    wreath++;
                    queue.Dequeue();
                    stack.Pop();
                }
                else if (sum < 15)
                {
                    // you have to store them for later and remove them   
                    queue.Dequeue();
                    stack.Pop();
                    storedFlowers.Add(sum);
                }
            }

            int wreathLeft = storedFlowers.Sum() / 15;

            wreath += wreathLeft;

            if (wreath >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreath} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreath} wreaths more!");
            }

        }

        private static List<int> Reading()
            => Console
                .ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToList();
    }
}
