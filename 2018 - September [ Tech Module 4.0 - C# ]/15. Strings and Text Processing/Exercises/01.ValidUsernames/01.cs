using System;

namespace _01.ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = Console.ReadLine().Split(", ");

            string[] containt = new string[] { "-", "_" };

            foreach (var user in userNames)
            {
                if (user.Length >= 3 && user.Length <= 16)
                {
                    bool isValid = true;

                    for (int i = 0; i < user.Length; i++)
                    {
                        if (char.IsLetterOrDigit(user[i]) || user[i] == '-' || user[i] == '_')
                        {
                            continue;
                        }
                        else
                        {
                            isValid = false;
                            break;
                        }
                    }

                    if (isValid)
                    {
                        Console.WriteLine(user);
                    }
                }
            }
        }
    }
}