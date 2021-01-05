namespace Logger.Factories
{
    using Logger.Common;
    using Models.Contracts;
    using Models.Enumerations;
    using Models.Errors;

    using System;
    using System.Globalization;

    public class ErrorFactory
    {
        public IError ProduceError(string date, string message, string reportLevelString)
        {
            DateTime dateTime;
            try
            {
                dateTime = DateTime.ParseExact(date, GlobalConstants.DateFormat, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                throw new ArgumentException("Invalid date format!");
            }

            ReportLevel reportLevel;

            bool hasParsedReportLevel = Enum.TryParse<ReportLevel>(reportLevelString, true, out reportLevel);

            if (hasParsedReportLevel == false)
            {
                throw new ArgumentException("Invalid report level format!");
            }

            IError error = new Error(dateTime, message, reportLevel);

            return error;
        }
    }
}
