namespace _07.Tuple
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split().ToArray();
            var firstName = input1[0];
            var lastName = input1[1];
            var fullName = firstName + " " + lastName;
            var adress = input1[2];
            var output1 = new MyTyple<string, string>(fullName, adress);
            Console.WriteLine(output1);

            var input2 = Console.ReadLine().Split().ToArray();
            var name = input2[0];
            var litersOfBeer = int.Parse(input2[1]);
            var output2 = new MyTyple<string, int>(name, litersOfBeer);
            Console.WriteLine(output2);

            var input3 = Console.ReadLine().Split().ToArray();
            var x = int.Parse(input3[0]);
            var y = double.Parse(input3[1]);
            var output3 = new MyTyple<int, double>(x, y);
            Console.WriteLine(output3);
        }
    }
}