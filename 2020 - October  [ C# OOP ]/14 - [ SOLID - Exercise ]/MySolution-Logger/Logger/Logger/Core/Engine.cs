namespace Logger.Core
{
    using Contracts;
    using Logger.Models.Factories;
    using Models.Contracts;
    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private ErrorFactory errorFactory;
        private ILogger logger;

        public Engine()
        {
            this.errorFactory = new ErrorFactory();
        }

        public Engine(ILogger logger)
            : this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            while (true)
            {
                string[] commands = Console.ReadLine().Split('|').ToArray();
                
                if (commands[0] == "END")
                {
                    foreach (var appender in this.logger.Appenders)
                    {
                        Console.WriteLine(appender);
                    }
                    break;
                }

                string reportLevelString = commands[0];
                string dateTimeString = commands[1];
                string message = commands[2];

                try
                {
                    IError error = this.errorFactory.ProduceError(dateTimeString, reportLevelString, message);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
