namespace Logger.Factories
{
    using Logger.Models.Appenders;
    using Logger.Models.Enumerations;
    using Logger.Models.Files;
    using Models.Contracts;

    using System;

    public class AppenderFactory
    {
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender ProduceAppender(string appenderType, string layoutType, string reportLevelType)
        {
            ReportLevel reportLevel;

            bool hasParsedReportLevel = Enum.TryParse<ReportLevel>(reportLevelType, true, out reportLevel);

            if (hasParsedReportLevel == false)
            {
                throw new ArgumentException("Invalid report level format!");
            }

            ILayout layout = this.layoutFactory.ProduceLayout(layoutType);

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, reportLevel);
            }
            else if (appenderType == "FileAppender")
            {
                IFile file = new LogFile("\\data\\", "logs.txt");

                appender = new FileAppender(layout, reportLevel, file);
            }
            else
            {
                throw new ArgumentException("Invalid appender format!");
            }

            return appender;
        }
    }
}
