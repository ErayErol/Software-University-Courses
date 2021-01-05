namespace Logger.Models.Appenders
{
    using Contracts;
    using Enumerations;

    using System;

    public class ConsoleAppender : IAppender
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

            string formatted = string.Format(
                format,
                error.DateTime,
                error.ReportLevel,
                error.Message);

            Console.WriteLine(formatted);
            this.MessagesAppend++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel}, Messages appended: {this.MessagesAppend}";
        }
    }
}
