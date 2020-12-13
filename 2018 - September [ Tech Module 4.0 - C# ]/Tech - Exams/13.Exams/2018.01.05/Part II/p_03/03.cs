using System;

namespace p_03
{
    class Program
    {
        static void Main(string[] args)
        {
            string surface = Console.ReadLine();
            for (int i = 0; i < surface.Length; i++)
            {
                if (char.IsLetter(surface[i]) || char.IsDigit(surface[i]))
                {
                    Console.WriteLine("Invalid");
                    return;
                }
            }

            string mantle = Console.ReadLine();
            for (int i = 0; i < mantle.Length; i++)
            {
                if (char.IsDigit(mantle[i]) || mantle[i] == '_')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid");
                    return;
                }
            }

            int count = 0;
            bool isValid = false;
            string surfaceMantleCoreMantleSurface = Console.ReadLine();
            for (int i = 0; i < surfaceMantleCoreMantleSurface.Length; i++)
            {
                if (char.IsLetter(surfaceMantleCoreMantleSurface[i]) || char.IsDigit(surfaceMantleCoreMantleSurface[i]))
                {
                    for (int j = i; j < surfaceMantleCoreMantleSurface.Length; j++)
                    {
                        if (char.IsDigit(surfaceMantleCoreMantleSurface[j]) || surfaceMantleCoreMantleSurface[j] == '_')
                        {
                            continue;
                        }
                        else
                        {
                            for (int k = j; k < surfaceMantleCoreMantleSurface.Length; k++)
                            {
                                if (char.IsLetter(surfaceMantleCoreMantleSurface[k]))
                                {
                                    isValid = true;
                                    count++;
                                }
                                else
                                {
                                    if (char.IsDigit(surfaceMantleCoreMantleSurface[k]) || surfaceMantleCoreMantleSurface[k] == '_')
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        for (int l = k; l < surfaceMantleCoreMantleSurface.Length; l++)
                                        {
                                            if (char.IsLetter(surfaceMantleCoreMantleSurface[l]) || char.IsDigit(surfaceMantleCoreMantleSurface[l]))
                                            {
                                                Console.WriteLine("Invalid");
                                                return;
                                            }
                                        }

                                        if (isValid)
                                        {
                                            string mantle2 = Console.ReadLine();
                                            for (int m = 0; m < mantle2.Length; m++)
                                            {
                                                if (char.IsDigit(mantle2[m]) || mantle2[m] == '_')
                                                {
                                                    continue;
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Invalid");
                                                    return;
                                                }
                                            }

                                            string surface2 = Console.ReadLine();
                                            for (int n = 0; n < surface2.Length; n++)
                                            {
                                                if (char.IsLetter(surface2[n]) || char.IsDigit(surface2[n]))
                                                {
                                                    Console.WriteLine("Invalid");
                                                    return;
                                                }
                                            }

                                            Console.WriteLine("Valid");
                                            Console.WriteLine(count);
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    continue;
                }
            }
        }
    }
}