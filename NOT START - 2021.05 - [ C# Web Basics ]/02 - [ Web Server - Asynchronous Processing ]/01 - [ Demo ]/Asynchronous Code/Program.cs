namespace Asynchronous_Code
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            PrintNumbersInRange(0, 100);
            var task = Task.Run(() => PrintNumbersInRange(100, 200));

            Console.WriteLine("Done.1");
            task.Wait();
        }

        private static void PrintNumbersInRange(int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                Console.WriteLine(i);
            }
        }
    }
}
