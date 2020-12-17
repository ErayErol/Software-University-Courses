namespace Logger.Models.Contracts
{
    using System.Collections.Generic;

    public interface ILogger
    {
        ICollection<IAppender> Appenders { get; }

        void Log(IError error);
    }
}
