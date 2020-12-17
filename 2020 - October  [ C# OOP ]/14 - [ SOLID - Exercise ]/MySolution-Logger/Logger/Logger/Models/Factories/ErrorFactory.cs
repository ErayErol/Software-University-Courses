namespace Logger.Models.Factories
{
    using Contracts;
    using Enumerations;
    using Errors;
    using Logger.Common;
    using System;
    using System.Globalization;

    public class ErrorFactory
    {
        private IError error;

        public IError ProduceError(string dateTimeString, string reportLevelString, string message)
        {
            ReportLevel reportLevel;
            var hasParsedReportLevel = Enum.TryParse<ReportLevel>(reportLevelString, true, out reportLevel);

            if (hasParsedReportLevel == false)
            {
                throw new ArgumentException("Invalid report level type!");
            }

            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(dateTimeString, Globalization.DateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid DateTime type!");
            }

            this.error = new Error(dateTimeString, reportLevel, message);
            return error;
        }
    }
}
