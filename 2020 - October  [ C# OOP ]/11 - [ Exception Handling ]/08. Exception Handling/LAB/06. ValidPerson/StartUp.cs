namespace _06._ValidPerson
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Person validPerson = new Person("Eray", "Erol", 25);
                Console.WriteLine(validPerson);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            try
            {
                Person noName = new Person("", "noName", 30);
                Console.WriteLine(noName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Person oldestWomanEver = new Person("Jeanne", "Calment", 122);
                Console.WriteLine(oldestWomanEver);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
