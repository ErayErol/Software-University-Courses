namespace CreatingTask
{
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() =>
            {
                Console.WriteLine("Task");
            });
        }
    }
}
