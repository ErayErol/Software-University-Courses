namespace Logger.Core
{
    using Logger.Factories;
    using Models.Contracts;

    using System;
    using System.Linq;

    public class Engine : IEngine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

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
                var inputArgs = Console.ReadLine().Split('|').ToArray();

                if (inputArgs[0] == "END")
                {
                    Console.WriteLine(this.logger);
                    break;
                }

                string reportLevel = inputArgs[0];
                string dateTime = inputArgs[1];
                string message = inputArgs[2];

                try
                {
                    IError error = this.errorFactory.ProduceError(dateTime, message, reportLevel);
                    this.logger.Log(error);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
