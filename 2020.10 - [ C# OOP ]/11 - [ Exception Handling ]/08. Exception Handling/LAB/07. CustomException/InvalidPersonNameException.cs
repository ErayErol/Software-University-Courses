namespace _07._CustomException
{
    using System;

    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException(string msg)
        : base(msg)
        {
        }
    }
}
