using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();

            string password = string.Empty;
            for (int i = username.Length - 1; i >= 0; i--)
            {
                password += username[i];
            }

            string passwordInput = Console.ReadLine();
            int counter = 0;
            while (passwordInput != password)
            {
                counter++;
                if (counter == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");

                passwordInput = Console.ReadLine();
            }

            if (passwordInput == password)
            {
                Console.WriteLine($"User {username} logged in.");
            }
        }
    }
}
