using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace p_02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> songs = Console.ReadLine().Split(new char[] { ',' }).ToList();
            songs = songs.Select(t => t.Trim()).ToList();

            while (true)
            {
                List<string> commands = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                commands = commands.Select(t => t.Trim()).ToList();
                if (commands[0] == "dawn")
                {
                    return;
                }

                if (names.Contains(commands[0]))
                {
                    if (songs.Contains(commands[1]))
                    {

                    }
                }
            }
        }
    }
}
