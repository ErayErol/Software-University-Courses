namespace Logger.Models.Contracts
{
    using Enumerations;

    using System;

    public interface IError
    {
        DateTime DateTime { get; }

        string Message { get; }

        ReportLevel ReportLevel { get; }
    }
}
