namespace BoxOfT
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var data = new Box<int>();
            data.Add(2);
            data.Add(1);
            data.Add(2);
            data.Remove();
            data.Add(3);
            data.Add(4);
            Console.WriteLine(data.Count);
        }
    }
}