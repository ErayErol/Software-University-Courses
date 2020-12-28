using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> contacts = Console
                .ReadLine()
                .Split()
                .ToList();

            string input = Console.ReadLine();
            string[] commands = input
                    .Split()
                    .ToArray();

            string contact = string.Empty;
            int index = 0;
            int count = 0;

            while (commands[0] != "Print")
            {
                switch (commands[0])
                {
                    case "Add":
                        contact = commands[1];
                        index = int.Parse(commands[2]);

                        AddingContact(contacts, contact, index);
                        break;
                    case "Remove":
                        index = int.Parse(commands[1]);

                        RemovingContact(contacts, index);
                        break;
                    case "Export":
                        index = int.Parse(commands[1]);
                        count = int.Parse(commands[2]);

                        ExportingContact(contacts, index, count);
                        break;
                }

                input = Console.ReadLine();

                commands = input
                    .Split()
                    .ToArray();
            }

            if (commands[1] == "Reversed")
            {
                contacts.Reverse();
            }

            PrintingContacts(contacts);
        }

        static void AddingContact(List<string> contacts, string contact, int index)
        {
            if (contacts.Contains(contact))
            {
                if (index >= 0 && index < contacts.Count)
                {
                    contacts.Insert(index, contact);
                }
            }
            else
            {
                contacts.Add(contact);
            }
        }

        static void RemovingContact(List<string> contacts, int index)
        {
            if (index >= 0 && index < contacts.Count)
            {
                contacts.RemoveAt(index);
            }
        }

        static void ExportingContact(List<string> contacts, int index, int count)
        {
            List<string> exportedContacts = new List<string>();

            exportedContacts = contacts.Skip(index).Take(Math.Min(count, contacts.Count)).ToList();
            
            Console.WriteLine(string.Join(" ", exportedContacts));
        }

        static void PrintingContacts(List<string> contacts)
        {
            Console.WriteLine($"Contacts: {string.Join(" ", contacts)}");
        }
    }
}
