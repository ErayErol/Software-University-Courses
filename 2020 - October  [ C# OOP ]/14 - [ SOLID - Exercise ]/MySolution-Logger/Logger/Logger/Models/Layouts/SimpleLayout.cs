using Logger.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Models.Layouts
{
    class SimpleLayout : ILayout
    {
        public string Format
            => "{0} - {1} - {2}";
    }
}
