using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> message = Console
                .ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            char dot = '.';
            char dash = '-';

            var dict = new Dictionary<char, string>{
                { 'A', string.Concat(dot, dash) },
                { 'B', string.Concat(dash, dot, dot, dot)},
                { 'C', string.Concat(dash, dot, dash, dot)},
                { 'D', string.Concat(dash, dot, dot)},
                { 'E', dot.ToString()},
                { 'F', string.Concat(dot, dot, dash, dot)},
                { 'G', string.Concat(dash, dash, dot)},
                { 'H', string.Concat(dot, dot, dot, dot)},
                { 'I', string.Concat(dot, dot)},
                { 'J', string.Concat(dot, dash, dash, dash)},
                { 'K', string.Concat(dash, dot, dash)},
                { 'L', string.Concat(dot, dash, dot, dot)},
                { 'M', string.Concat(dash, dash)},
                { 'N', string.Concat(dash, dot)},
                { 'O', string.Concat(dash, dash, dash)},
                { 'P', string.Concat(dot, dash, dash, dot)},
                { 'Q', string.Concat(dash, dash, dot, dash)},
                { 'R', string.Concat(dot, dash, dot)},
                { 'S', string.Concat(dot, dot, dot)},
                { 'T', string.Concat(dash)},
                { 'U', string.Concat(dot, dot, dash)},
                { 'V', string.Concat(dot, dot, dot, dash)},
                { 'W', string.Concat(dot, dash, dash)},
                { 'X', string.Concat(dash, dot, dot, dash)},
                { 'Y', string.Concat(dash, dot, dash, dash)},
                { 'Z', string.Concat(dash, dash, dot, dot)}};

            var sb = new StringBuilder();

            for (int i = 0; i < message.Count; i++)
            {
                foreach (var kvp in dict)
                {
                    if (kvp.Value == message[i])
                    {
                        sb.Append(kvp.Key);

                        if (!(i == message.Count - 1))
                        {
                            if (message[i + 1] == "|")
                            {
                                sb.Append(" ");
                            }
                        }
                    }
                }
            }

            Console.WriteLine(sb);
        }
    }
}
