namespace Logger.Models.Errors
{
    using Contracts;
    using Enumerations;

    using System;

    public class Error : IError
    {
        public Error(DateTime dateTime, string message, ReportLevel reportLevel)
        {
            this.DateTime = dateTime;
            this.Message = message;
            this.ReportLevel = reportLevel;
        }

        public DateTime DateTime { get; private set; }

        public string Message { get; private set; }

        public ReportLevel ReportLevel { get; private set; }
    }
}
