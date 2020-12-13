namespace _03.CountUppercaseWords
{
    using System;
    using System.Linq;

    class CountUppercaseWords
    {
        static void Main(string[] args)
        {
            Console.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => char.IsUpper(w[0])).ToList()
                .ForEach(w => Console.WriteLine(w));
        }
    }
}