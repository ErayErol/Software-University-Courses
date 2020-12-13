using System;
using System.Collections.Generic;
using System.Text;

namespace _09.SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var stack = new Stack<string>();

            var text = new StringBuilder("");
            stack.Push(text.ToString());

            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split();

                switch (commands[0])
                {
                    case "1":
                        text.Append(commands[1]);
                        stack.Push(text.ToString());
                        break;

                    case "2":
                        var count = int.Parse(commands[1]);
                        string temp = text.ToString();
                        temp = temp.Substring(0, temp.Length - count);

                        text.Clear();
                        text.Append(temp);
                        stack.Push(text.ToString());
                        break;

                    case "3":
                        var index = int.Parse(commands[1]);
                        Console.WriteLine(text[index - 1]);
                        break;

                    case "4":
                        stack.Pop();
                        text.Clear();
                        text.Append(stack.Peek());
                        break;
                }
            }
        }
    }
}