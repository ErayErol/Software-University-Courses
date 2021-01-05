namespace Logger.Models.Appenders
{
    using Contracts;
    using Enumerations;
    using global::Logger.Common;

    using System;
    using System.Globalization;

    class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public long MessagesAppend { get; private set; }

        public void Append(IError error)
        {
            string format = this.Layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            ReportLevel reportLevel = error.ReportLevel;

            string formattedMessage = string.Format(
                format,
                dateTime.ToString(GlobalConstants.DateFormat, CultureInfo.InvariantCulture),
                reportLevel.ToString(),
                message);

            Console.WriteLine(formattedMessage);
            this.MessagesAppend++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesAppend}";
        }
    }
}
