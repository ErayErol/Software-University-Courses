using System;
using System.Threading.Tasks;

namespace CreatingTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task(() => { Console.WriteLine("Task"); });

        }
    }
}
