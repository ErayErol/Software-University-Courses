namespace CounterStrike.IO
{
    using CounterStrike.IO.Contracts;
    using System;

    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}