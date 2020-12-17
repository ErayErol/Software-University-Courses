namespace Logger.Models.Errors
{
    using Contracts;
    using Enumerations;

    public class Error : IError
    {
        public Error(string dateTime, ReportLevel reportLevel, string message)
        {
            this.DateTime = dateTime;
            this.ReportLevel = reportLevel;
            this.Message = message;
        }

        public string DateTime { get; }

        public ReportLevel ReportLevel { get; }

        public string Message { get; }
    }
}
