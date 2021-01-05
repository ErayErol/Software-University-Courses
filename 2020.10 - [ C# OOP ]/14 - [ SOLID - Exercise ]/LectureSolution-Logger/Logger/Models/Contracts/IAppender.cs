namespace Logger.Models.Contracts
{
    using Enumerations;

    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        long MessagesAppend { get; }

        void Append(IError error);
    }
}
