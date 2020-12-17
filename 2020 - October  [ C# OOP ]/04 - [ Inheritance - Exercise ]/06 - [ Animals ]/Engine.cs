namespace Animals
{
    using System;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        public void Proceed()
        {
            var sb = new StringBuilder();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Beast!")
                {
                    Console.WriteLine(sb.ToString());
                    return;
                }

                var animalType = input;

                var animalArgs = Console.ReadLine().Split().ToList();

                var animalName = animalArgs[0];
                var animalAge = int.Parse(animalArgs[1]);
                var animalGender = animalArgs[2];

                if (animalAge <= 0)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                Animal animal = animalType switch
                {
                    "Dog" => new Dog(animalName, animalAge, animalGender),
                    "Frog" => new Frog(animalName, animalAge, animalGender),
                    "Cat" => new Cat(animalName, animalAge, animalGender),
                    "Kitten" => new Kitten(animalName, animalAge),
                    "Tomcat" => new Tomcat(animalName, animalAge),
                    _ => null
                };

                sb.AppendLine(animal.ToString());
            }
        }
    }
}
