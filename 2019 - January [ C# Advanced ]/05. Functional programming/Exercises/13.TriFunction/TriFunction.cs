namespace _13.TriFunction
{
    using System;

    class TriFunction
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            foreach (var name in names)
            {
                int sum = 0;
                foreach (var ch in name)
                {
                    sum += ch;
                }
                if (sum >= num)
                {
                    Console.WriteLine(name);
                    return;
                }
            }
        }
    }
}