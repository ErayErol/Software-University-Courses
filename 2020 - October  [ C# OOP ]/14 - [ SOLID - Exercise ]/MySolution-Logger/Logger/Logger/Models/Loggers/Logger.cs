namespace Logger.Models.Loggers
{
    using Contracts;

    using System.Collections.Generic;
    using System.Linq;

    public class Logger : ILogger
    {
        private IReadOnlyCollection<IAppender> appenders;

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders.ToList().AsReadOnly();
        }

        public ICollection<IAppender> Appenders
            => appenders.ToList().AsReadOnly();

        public void Log(IError error)
        {
            foreach (var appender in appenders)
            {
                if (error.ReportLevel >= appender.ReportLevel)
                {
                    appender.Append(error);
                }
            }
        }

        
    }
}
