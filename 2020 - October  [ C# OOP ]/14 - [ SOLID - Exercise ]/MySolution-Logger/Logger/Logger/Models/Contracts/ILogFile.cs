using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Contracts
{
    public interface ILogFile
    {
        string Path { get; }

        long Size { get; }

        string Write(ILayout layout, IError error);
    }
}
