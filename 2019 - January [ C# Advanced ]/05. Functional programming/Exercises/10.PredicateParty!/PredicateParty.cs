namespace _10.PredicateParty_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class PredicateParty
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            Predicate<string> predicate;

            string input;
            while ((input = Console.ReadLine()) != "Party!")
            {
                string[] commandArgs = input.Split();

                string command = commandArgs[0];
                string predicateName = commandArgs[1];
                string value = commandArgs[2];

                predicate = GerPredicate(predicateName, value);

                if (command == "Remove")
                {
                    guests.RemoveAll(predicate);
                }
                else
                {
                    var newGuest = guests.FindAll(predicate);

                    foreach (var guest in newGuest)
                    {
                        int index = guests.IndexOf(guest);

                        guests.Insert(index + 1, guest);
                    }
                }
            }

            if (guests.Any())
            {
                Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
                return;
            }

            Console.WriteLine("Nobody is going to the party!");
        }

        private static Predicate<string> GerPredicate(string predicateName, string value)
        {
            if (predicateName == "StartsWith")
            {
                return p => p.StartsWith(value);
            }
            else if (predicateName == "EndsWith")
            {
                return p => p.EndsWith(value);
            }
            else if (predicateName == "Length")
            {
                return p => p.Length == int.Parse(value);
            }

            return null;
        }
    }
}