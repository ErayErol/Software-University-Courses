namespace _01.Crossroads
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Method(greenLight, freeWindow);
        }

        private static void Method(int greenLight, int freeWindow)
        {
            int greenLightSeconds = greenLight;
            int freeWindowSeconds = freeWindow;

            int passedCars = 0;
            int greenLightLeft = 0;

            var cars = new Queue<string>();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "END")
                {
                    Console.WriteLine("Everyone is safe.");
                    Console.WriteLine($"{passedCars} total cars passed the crossroads.");
                    break;
                }

                if (command == "green")
                {
                    greenLight = greenLightSeconds;
                    freeWindow = freeWindowSeconds;

                    while (cars.Any())
                    {
                        if (greenLight > 0)
                        {
                            greenLightLeft = greenLight - cars.Peek().Length;
                        }
                        else
                        {
                            break;
                        }

                        if (greenLightLeft >= 0)
                        {
                            passedCars++;
                            cars.Dequeue();
                            if (cars.Count > 0)
                            {
                                greenLight = greenLightLeft;
                            }
                        }
                        else
                        {
                            greenLightLeft = greenLight - cars.Peek().Length + freeWindow;
                            if (greenLightLeft >= 0)
                            {
                                passedCars++;
                                greenLight = -1;
                                cars.Dequeue();
                            }
                            else
                            {
                                int position = cars.Peek().Length - Math.Abs(greenLightLeft);
                                char letter = cars.Peek()[position];

                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{cars.Peek()} was hit at {letter}.");
                                return;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }
        }
    }
}