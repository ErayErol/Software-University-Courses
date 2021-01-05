namespace _01._Stealer
{
    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                Spy spy = new Spy();
                string result = spy.StealFieldInfo("Hacker", "username", "password");
                Console.WriteLine(result);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
