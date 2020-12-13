using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex pattern = new Regex(@"(\+359)( |-)(2)( |-)(\d{3})( |-)(\d{4})\b");

            string phoneNumbers = Console.ReadLine();

            List<string> result = new List<string>();

            foreach (Match phoneNumber in pattern.Matches(phoneNumbers))
            {
                string one = phoneNumber.Groups[2].Value;
                string two = phoneNumber.Groups[4].Value;
                string three = phoneNumber.Groups[6].Value;

                if (one == " " && two == " " && three == " " ||
                    one == "-" && two == "-" && three == "-")
                {
                    result.Add(phoneNumber.ToString());
                }
            }

            Console.WriteLine(string.Join(", ", result));
        }
    }
}