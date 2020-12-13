using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            Validator(password);
        }

        static void Validator(string password)
        {
            bool first = Rules0(password);
            bool second = Rules1(password);
            bool third = Rules2(password);

            if (first && second && third)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool Rules2(string password)
        {
            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                }
            }

            if (counter >= 2)
            {
                return true;
            }

            Console.WriteLine($"Password must have at least 2 digits");
            return false;
        }

        static bool Rules1(string password)
        {
            int counter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]) || char.IsLetter(password[i]))
                {
                    counter++;
                }
            }

            if (counter == password.Length)
            {
                return true;
            }

            Console.WriteLine($"Password must consist only of letters and digits");
            return false;
        }

        static bool Rules0(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
            {
                return true;
            }

            Console.WriteLine($"Password must be between 6 and 10 characters ");
            return false;
        }
    }
}
