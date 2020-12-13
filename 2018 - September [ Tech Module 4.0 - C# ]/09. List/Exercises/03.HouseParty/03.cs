using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int guestsNumber = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < guestsNumber; i++)
            {
                List<string> name = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();


                if (list.Contains(name[0]))
                {
                    if (name[2] == "going!")
                    {
                        Console.WriteLine($"{name[0]} is already in the list!");
                    }
                    else
                    {
                        list.RemoveAll(x => x == $"{name[0]}");
                    }
                }

                else
                {
                    if (name[2] == "going!")
                    {
                        list.Add(name[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{name[0]} is not in the list!");
                    }
                }
            }

            foreach (var name in list)
            {
                Console.WriteLine(name);
            }
        }
    }
}
