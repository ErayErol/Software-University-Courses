namespace Logger.Models.Factories
{
    using Contracts;
    using Enumerations;
    using Logger.Models.Appenders;
    using System;

    public class AppenderFactory
    {
        private ILayout layout;
        private LayoutFactory layoutFactory;

        public AppenderFactory()
        {
            this.layoutFactory = new LayoutFactory();
        }

        public IAppender ProduceAppender(string appenderType, string layoutType, string reportLevelType)
        {
            ReportLevel reportLevel;

            var hasParsedReportLevel = Enum.TryParse<ReportLevel>(reportLevelType, true, out reportLevel);

            if (hasParsedReportLevel == false)
            {
                throw new ArgumentException("Invalid report level type!");
            }

            try
            {
                layout = this.layoutFactory.ProduceLayout(layoutType);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }

            IAppender appender;

            if (appenderType == "ConsoleAppender")
            {
                appender = new ConsoleAppender(layout, reportLevel);
            }
            else
            {
                throw new ArgumentException("Invalid layout type!");
            }

            return appender;
        }
    }
}
