using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] commands = Console.ReadLine().Split(new string[] { " <-> " }, StringSplitOptions.None);

            List<string> messages = new List<string>();
            List<string> broadcasts = new List<string>();

            bool isValidMessages = false;
            bool isValidBroadcasts = false;

            while (commands[0] != "Hornet is Green")
            {
                bool isMessages = true;
                bool isBroadcasts = false;

                for (int i = 0; i < commands.Length - 1; i++)
                {
                    for (int e = 0; e < commands[i].Length; e++)
                    {
                        if (!char.IsDigit(commands[i][e]))
                        {
                            isMessages = false;
                            isBroadcasts = true;
                            break;
                        }
                    }

                    if (isBroadcasts)
                    {
                        for (int e = 0; e < commands[i + 1].Length; e++)
                        {
                            if (!char.IsLetterOrDigit(commands[i + 1][e]))
                            {
                                isBroadcasts = false;
                                break;
                            }
                        }

                        if (isBroadcasts)
                        {
                            isValidBroadcasts = true;

                            StringBuilder upperOrLower = new StringBuilder();
                            for (int k = 0; k < commands[1].Length; k++)
                            {
                                char c = commands[1][k];
                                if (Char.IsLetter(c))
                                {
                                    if (Char.IsUpper(c))
                                    {
                                        upperOrLower.Append(Char.ToLower(c));
                                    }
                                    else
                                    if (Char.IsLower(c))
                                    {
                                        upperOrLower.Append(Char.ToUpper(c));
                                    }
                                }
                                else
                                {
                                    upperOrLower.Append(c);
                                }
                            }

                            upperOrLower.Append(" -> ").Append(commands[0]);
                            broadcasts.Add(upperOrLower.ToString());
                        }
                    }

                    if (isMessages)
                    {
                        for (int e = 0; e < commands[i + 1].Length; e++)
                        {
                            if (!char.IsLetterOrDigit(commands[i + 1][e]))
                            {
                                isMessages = false;
                                break;
                            }
                        }

                        if (isMessages)
                        {
                            isValidMessages = true;
                            StringBuilder added = new StringBuilder();
                            for (int r = commands[0].Length - 1; r >= 0; r--)
                            {
                                added.Append(commands[0][r].ToString());

                            }

                            added.Append(" -> ").Append(commands[1]);
                            messages.Add(added.ToString());
                        }
                    }
                }

                commands = Console.ReadLine().Split(new string[] { " <-> " }, StringSplitOptions.None);
            }

            if (isValidBroadcasts)
            {
                Console.WriteLine("Broadcasts:");

                foreach (var item in broadcasts)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Broadcasts:");
                Console.WriteLine("None");
            }

            if (isValidMessages)
            {
                Console.WriteLine("Messages:");

                foreach (var item in messages)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("Messages:");
                Console.WriteLine("None");
            }
        }
    }
}
