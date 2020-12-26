using System;

namespace Messages
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = int.Parse(Console.ReadLine());

            string str = string.Empty;
            for (int i = 1; i <= counter; i++)
            {
                int number = int.Parse(Console.ReadLine());
                switch (number)
                {
                    case 0:
                        str += " ";
                        break;
                    case 2:
                        str += "a";
                        break;
                    case 22:
                        str += "b";
                        break;
                    case 222:
                        str += "c";
                        break;
                    case 3:
                        str += "d";
                        break;
                    case 33:
                        str += "e";
                        break;
                    case 333:
                        str += "f";
                        break;
                    case 4:
                        str += "g";
                        break;
                    case 44:
                        str += "h";
                        break;
                    case 444:
                        str += "i";
                        break;
                    case 5:
                        str += "j";
                        break;
                    case 55:
                        str += "k";
                        break;
                    case 555:
                        str += "l";
                        break;
                    case 6:
                        str += "m";
                        break;
                    case 66:
                        str += "n";
                        break;
                    case 666:
                        str += "o";
                        break;
                    case 7:
                        str += "p";
                        break;
                    case 77:
                        str += "q";
                        break;
                    case 777:
                        str += "r";
                        break;
                    case 7777:
                        str += "s";
                        break;
                    case 8:
                        str += "t";
                        break;
                    case 88:
                        str += "u";
                        break;
                    case 888:
                        str += "v";
                        break;
                    case 9:
                        str += "w";
                        break;
                    case 99:
                        str += "x";
                        break;
                    case 999:
                        str += "y";
                        break;
                    case 9999:
                        str += "z";
                        break;
                }
            }
            Console.WriteLine(str);
        }
    }
}
