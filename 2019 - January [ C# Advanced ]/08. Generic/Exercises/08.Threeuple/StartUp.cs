namespace _08.Threeuple
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var input1 = Console.ReadLine().Split().ToArray();
            var firstName = input1[0];
            var lastName = input1[1];
            var fullName = firstName + " " + lastName;
            var adress = input1[2];
            var town = string.Join(" ", input1.Skip(3));
            var output1 = new MyThreeuple<string, string, string>(fullName, adress, town);
            Console.WriteLine(output1);

            var input2 = Console.ReadLine().Split().ToArray();
            var name = input2[0];
            var litersOfBeer = int.Parse(input2[1]);
            var type = input2[2];
            bool isDrunk = type == "drunk" ? true : false;
            var output2 = new MyThreeuple<string, int, bool>(name, litersOfBeer, isDrunk);
            Console.WriteLine(output2);

            var input3 = Console.ReadLine().Split().ToArray();
            var name2 = input3[0];
            var accountBalance = double.Parse(input3[1]);
            var bankName = input3[2];
            var output3 = new MyThreeuple<string, double, string>(name2, accountBalance, bankName);
            Console.WriteLine(output3);
        }
    }
}