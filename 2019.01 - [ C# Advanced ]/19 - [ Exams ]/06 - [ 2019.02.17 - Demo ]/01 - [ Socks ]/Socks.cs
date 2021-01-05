namespace _01.Socks
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    class Socks
    {
        static void Main(string[] args)
        {
            var leftSock = new Stack<int>(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var rightSock = new Queue<int>(Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            var set = new List<int>();

            while (leftSock.Any() && rightSock.Any())
            {
                var currLeft = leftSock.Pop();
                var currRight = rightSock.Peek();

                if (currLeft > currRight)
                {
                    var value = leftSock.Pop() + rightSock.Dequeue();
                    set.Add(value);
                }
                else if (currRight == currLeft)
                {
                    rightSock.Dequeue();
                    leftSock.Push(++currLeft);
                }
            }

            Console.WriteLine(set.Max());
            Console.WriteLine(string.Join(" ", set));
        }
    }
}