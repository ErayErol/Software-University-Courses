namespace _07._CustomException
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Student student = new Student("Gin4o", "errayerrol@gmail.com");
                Console.WriteLine(student);
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
