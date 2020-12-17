namespace Logger.Models.Files
{
    using Contracts;
    using IOManagement;
    using Enumerations;
    using global::Logger.Common;

    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class LogFile : IFile
    {
        private IOManager IOManager;

        public LogFile(string folderName, string fileName)
        {
            this.IOManager = new IOManager(folderName, fileName);
            this.IOManager.EnsureDirectoryAndFileExist();
        }

        public string Path
            => this.IOManager.CurrentFilePath;

        public long Size
            => this.GetFileSize();

        /// <summary>
        /// Returns formatted message in provided layout with provided error's data
        /// </summary>
        /// <param name="layout"></param>
        /// <param name="error"></param>
        /// <returns></returns>
        public string Write(ILayout layout, IError error)
        {
            string format = layout.Format;

            DateTime dateTime = error.DateTime;
            string message = error.Message;
            ReportLevel reportLevel = error.ReportLevel;

            string formattedMessage = string.Format(
                format,
                dateTime.ToString(GlobalConstants.DateFormat, CultureInfo.InvariantCulture),
                reportLevel.ToString(),
                message);

            return formattedMessage + Environment.NewLine;
        }

        private long GetFileSize()
        {
            string text = File.ReadAllText(this.Path);

            long size = text
                .Where(char.IsLetter)
                .Sum(c => c);

            return size;
        }
    }
}
