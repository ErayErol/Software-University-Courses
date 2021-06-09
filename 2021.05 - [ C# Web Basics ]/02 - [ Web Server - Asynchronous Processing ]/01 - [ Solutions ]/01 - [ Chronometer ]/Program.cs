namespace Chronometer
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var chronometer = new Chronometer();
            var command = Console.ReadLine();

            while (command != "exit")
            {
                if (command == "start")
                {
                    chronometer.Start();
                }
                else if (command == "lap")
                {
                    string lap = chronometer.Lab();
                    Console.WriteLine(lap);
                }
                else if (command == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                    else
                    {
                        Console.WriteLine("Laps:");

                        foreach (var item in chronometer.Laps.Select((value, i) => (value, i)))
                        {
                            var lapTime = item.value;
                            var lapNumber = item.i;

                            Console.WriteLine($"{lapNumber}. {lapTime}");
                        }
                    }
                }
                else if (command == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (command == "stop")
                {
                    chronometer.Stop();
                }
                else if (command == "reset")
                {
                    chronometer.Reset();
                }

                command = Console.ReadLine();
            }
        }
    }
}