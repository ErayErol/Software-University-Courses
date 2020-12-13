namespace _11.ThePartyReservationFilterModule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class ThePartyReservationFilterModule
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine().Split().ToList();
            List<string> result = new List<string>(guests);
            Predicate<string> predicate;

            string input;
            while ((input = Console.ReadLine()) != "Print")
            {
                string[] commandArgs = input.Split(';');

                string command = commandArgs[0];
                string predicateName = commandArgs[1];
                string value = commandArgs[2];

                predicate = GerPredicate(predicateName, value);

                if (command == "Add filter")
                {
                    result.RemoveAll(predicate);
                }
                else
                {
                    var newGuest = guests.FindAll(predicate);

                    foreach (var guest in newGuest)
                    {
                        int index = guests.IndexOf(guest);

                        result.Insert(index, guest);
                    }
                }
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static Predicate<string> GerPredicate(string predicateName, string value)
        {
            if (predicateName == "Starts with")
            {
                return p => p.StartsWith(value);
            }
            else if (predicateName == "Ends With")
            {
                return p => p.EndsWith(value);
            }
            else if (predicateName == "Length")
            {
                return p => p.Length == int.Parse(value);
            }
            else if (predicateName == "Contains")
            {
                return p => p.Contains(value);
            }

            return null;
        }
    }
}