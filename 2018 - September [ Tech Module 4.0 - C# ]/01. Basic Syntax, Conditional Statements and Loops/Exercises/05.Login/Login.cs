using System;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = Console.ReadLine();
            string commands = Console.ReadLine();

            var password = Reverse(userName);
            int blocked = 0;

            while (true)
            {
                blocked++;
                if (commands == password)
                {
                    Console.WriteLine($"User {userName} logged in.");
                    return;
                }
                else if (blocked == 4)
                {
                    Console.WriteLine($"User {userName} blocked!");
                    return;
                }
                else
                {
                    Console.WriteLine("Incorrect password. Try again.");
                }

                commands = Console.ReadLine();
            }
        }

        public static string Reverse(string userName)
        {
            char[] charArray = userName.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}