using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());
            string str = string.Empty;

            for (int i = 0; i < counter; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (number == 0)
                {
                    str += " ";
                }
                else if (number == 2)
                {
                    str += "a";
                }
                else if (number == 22)
                {
                    str += "b";
                }
                else if (number == 222)
                {
                    str += "c";
                }
                else if (number == 3)
                {
                    str += "d";
                }
                else if (number == 33)
                {
                    str += "e";
                }
                else if (number == 333)
                {
                    str += "f";
                }
                else if (number == 4)
                {
                    str += "g";
                }
                else if (number == 44)
                {
                    str += "h";
                }
                else if (number == 444)
                {
                    str += "i";
                }
                else if (number == 5)
                {
                    str += "j";
                }
                else if (number == 55)
                {
                    str += "k";
                }
                else if (number == 555)
                {
                    str += "l";
                }
                else if (number == 6)
                {
                    str += "m";
                }
                else if (number == 66)
                {
                    str += "n";
                }
                else if (number == 666)
                {
                    str += "o";
                }
                else if (number == 7)
                {
                    str += "p";
                }
                else if (number == 77)
                {
                    str += "q";
                }
                else if (number == 777)
                {
                    str += "r";
                }
                else if (number == 7777)
                {
                    str += "s";
                }
                else if (number == 8)
                {
                    str += "t";
                }
                else if (number == 88)
                {
                    str += "u";
                }
                else if (number == 888)
                {
                    str += "v";
                }
                else if (number == 9)
                {
                    str += "w";
                }
                else if (number == 99)
                {
                    str += "x";
                }
                else if (number == 999)
                {
                    str += "y";
                }
                else if (number == 9999)
                {
                    str += "z";
                }
            }
            Console.WriteLine(str);
        }

    }
}


