namespace GenericTask
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task<long> task = Task<long>.Run(() =>
            {
                long sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                }

                return sum;
            });

            Console.WriteLine(task.Result);

        }
    }
}
