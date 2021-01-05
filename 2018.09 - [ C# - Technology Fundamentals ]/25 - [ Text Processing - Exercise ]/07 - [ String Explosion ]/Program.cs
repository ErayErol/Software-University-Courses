using System;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();

            int currBombNumber = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i].ToString() == ">")
                {
                    currBombNumber += int.Parse(str[i + 1].ToString());
                }
                else
                {
                    if (currBombNumber > 0)
                    {
                        str = str.Remove(i, 1);
                        currBombNumber--;
                        i--;
                    }
                }
            }

            Console.WriteLine(str);
        }
    }
}
