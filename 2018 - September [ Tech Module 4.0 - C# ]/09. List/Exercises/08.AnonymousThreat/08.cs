using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> someText = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            string[] commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            StringBuilder merged = new StringBuilder();
            while (commands[0] != "3:1")
            {
                switch (commands[0])
                {
                    case "merge": ReternMerge(someText, commands, merged); break;
                    case "divide": ReternDivide(someText, commands); break;
                }

                commands = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(" ", someText));
        }

        static void ReternDivide(List<string> someText, string[] commands)
        {
            int indexOfWord = int.Parse(commands[1]);
            int parts = int.Parse(commands[2]);

            string element = someText[indexOfWord];
            someText.RemoveAt(indexOfWord);

            List<string> newWords = new List<string>();

            int partLength = element.Length / parts;
            int lastPartLength = partLength + element.Length % parts;

            for (int i = 0; i < parts; i++)
            {
                string newWord = element.Substring(i * partLength, partLength);

                if (i == parts - 1)
                {
                    newWord = element.Substring(i * partLength, lastPartLength);
                }

                newWords.Add(newWord);
            }

            someText.InsertRange(indexOfWord, newWords);
        }

        static void ReternMerge(List<string> someText, string[] commands, StringBuilder merged)
        {
            int start = int.Parse(commands[1]);
            int finish = int.Parse(commands[2]);

            if (start < 0)
            {
                start = 0;
            }

            if (start > someText.Count -1 || finish < 0)
            {
                return;
            }

            if (finish >= someText.Count - 1)
            {
                finish = someText.Count - 1;
                for (int i = start; i <= finish; i++)
                {
                    merged.Append(someText[i]);
                }

                int indexForDelete = start;
                for (int i = start; i <= finish; i++)
                {
                    someText.RemoveAt(indexForDelete);
                }

                someText.Insert(start, merged.ToString());
            }
            else
            {
                for (int i = start; i <= finish; i++)
                {
                    merged.Append(someText[i]);
                }

                int indexForDelete = start;
                for (int i = start; i <= finish; i++)
                {
                    someText.RemoveAt(indexForDelete);
                }

                someText.Insert(start, merged.ToString());
            }

            merged.Clear();
        }
    }
}
