namespace Logger.Models.IOManagement
{
    using Contracts;

    using System;
    using System.IO;

    public class IOManager : IIOManager
    {
        private string currentPath;

        private string folderName;
        private string fileName;

        private IOManager()
        {
            this.currentPath = this.GetCurrentDirectory();
        }

        public IOManager(string folderName, string fileName)
            :this()
        {
            this.folderName = folderName;
            this.fileName = fileName;
        }

        public string CurrentDirectoryPath 
            => this.currentPath + this.folderName;

        public string CurrentFilePath 
            => this.CurrentDirectoryPath + this.fileName;

        public void EnsureDirectoryAndFileExist()
        {
            if (Directory.Exists(this.CurrentDirectoryPath) == false)
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }

            File.WriteAllText(this.CurrentFilePath, string.Empty);
        }

        public string GetCurrentDirectory()
        {
            string currentDir = Directory.GetCurrentDirectory();
            return currentDir;
        }
    }
}
