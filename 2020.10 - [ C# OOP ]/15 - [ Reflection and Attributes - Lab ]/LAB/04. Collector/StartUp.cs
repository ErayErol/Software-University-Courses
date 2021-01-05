namespace _04._Collector
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Spy spy = new Spy();
                string result = spy.CollectGettersAndSetters("Hacker");
                Console.WriteLine(result);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
