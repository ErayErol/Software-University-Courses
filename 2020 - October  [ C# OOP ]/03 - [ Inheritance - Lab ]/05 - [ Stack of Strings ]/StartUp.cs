namespace CustomStack
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var stringStack = new StackOfStrings();

            stringStack.Push("HTML");
            stringStack.Push("CSS");
            stringStack.Push("Java");
            stringStack.Push("JavaScript");
            stringStack.Push("C#");
            Console.WriteLine(stringStack.Peek());
            Console.WriteLine(stringStack.Pop());
            Console.WriteLine(stringStack.Pop());
            Console.WriteLine(stringStack.Pop());
            Console.WriteLine(stringStack.IsEmpty());
        }
    }
}
