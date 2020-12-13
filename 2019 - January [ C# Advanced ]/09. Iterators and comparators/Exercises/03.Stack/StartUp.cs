namespace _03.Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var x = new MyStack<string>();

            while (true)
            {
                var command = Console.ReadLine().Split(new string[] { " ", ", " }, StringSplitOptions.RemoveEmptyEntries).ToArray(); ;

                if (command[0] == "END")
                {
                    foreach (var item in x)
                    {
                        Console.WriteLine(item);
                    }
                    foreach (var item in x)
                    {
                        Console.WriteLine(item);
                    }
                    return;
                }
                else if (command[0] == "Push")
                {
                    var items = command.Skip(1).ToArray();
                    x.Push(items);
                }
                else if (command[0] == "Pop")
                {
                    x.Pop();
                }
            }
        }
    }
}