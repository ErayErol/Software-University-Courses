namespace _02._HighQualityMistakes
{
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                Spy spy = new Spy();
                string result = spy.AnalyzeAcessModifiers("Hacker");
                Console.WriteLine(result);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
