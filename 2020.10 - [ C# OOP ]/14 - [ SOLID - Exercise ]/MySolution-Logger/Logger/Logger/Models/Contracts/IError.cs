namespace Logger.Models.Contracts
{
    using Enumerations;

    public interface IError
    {
        string DateTime { get; }

        ReportLevel ReportLevel { get; }

        string Message { get; }
    }
}
