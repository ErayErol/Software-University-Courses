namespace Logger.Models.Appenders
{
    using Contracts;
    using Enumerations;

    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout, ReportLevel reportLevel, IFile file)
        {
            this.Layout = layout;
            this.ReportLevel = reportLevel;
            this.File = file;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; private set; }

        public IFile File { get; private set; }

        public long MessagesAppend { get; private set; }

        public void Append(IError error)
        {
            string formattedMessage = this.File.Write(this.Layout, error);

            System.IO.File.AppendAllText(File.Path, formattedMessage);
            this.MessagesAppend++;
        }

        public override string ToString()
        {
            return $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString().ToUpper()}, Messages appended: {this.MessagesAppend}, File size: {this.File.Size}";
        }
    }
}
