using System;
using System.Text;

namespace _05.DigitsLettersАndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder digit = new StringBuilder();
            StringBuilder letter = new StringBuilder();
            StringBuilder other = new StringBuilder();


            string text = Console.ReadLine();

            foreach (var token in text)
            {
                if (char.IsDigit(token))
                {
                    digit.Append(token);
                }
                else if (char.IsLetter(token))
                {
                    letter.Append(token);
                }
                else
                {
                    other.Append(token);
                }
            }

            Console.WriteLine(digit);
            Console.WriteLine(letter);
            Console.WriteLine(other);
        }
    }
}