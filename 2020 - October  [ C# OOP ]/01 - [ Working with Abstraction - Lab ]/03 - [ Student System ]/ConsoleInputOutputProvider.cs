namespace StudentData
{
    using System;

    public class ConsoleInputOutputProvider : IInputOutputProvider
    {
        /// <summary>
        /// Reading the input.
        /// </summary>
        /// <returns></returns>
        public string GetInput()
            => Console.ReadLine();

        /// <summary>
        /// Printing the output.
        /// </summary>
        /// <param name="data"></param>
        public void ShowOutput(string data)
            => Console.WriteLine(data);
    }
}
