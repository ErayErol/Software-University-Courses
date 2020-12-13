namespace StudentData
{
    public interface IInputOutputProvider
    {
        /// <summary>
        /// Getting the input.
        /// </summary>
        /// <returns></returns>
        string GetInput();

        /// <summary>
        /// Showing the output.
        /// </summary>
        /// <param name="data"></param>
        void ShowOutput(string data);
    }
}
