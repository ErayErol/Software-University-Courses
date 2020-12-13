namespace GenericScale
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var es = new EqualityScale<int>(10, 7);

            Console.WriteLine($"Is {es.First} and {es.Second} are equal : {es.AreEqual()}");
            Console.WriteLine($"Whether {es.First} is greater than {es.Second} : {es.IsFirstGreater()}");
        }
    }
}