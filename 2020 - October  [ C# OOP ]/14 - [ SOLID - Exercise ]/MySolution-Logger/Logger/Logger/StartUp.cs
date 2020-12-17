namespace Logger
{
    using Core;
    using Core.Contracts;
    using Models.Contracts;
    using Models.Factories;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int numberOfAppenders = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            string[] input = Console.ReadLine().Split().ToArray();

            var appenderFactory = new AppenderFactory();

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string appenderType = input[0];
                string layoutType = input[1];
                string reportLevelType = "INFO";

                if (input.Length > 2)
                {
                    reportLevelType = input[2];
                }

                try
                {
                    IAppender appender = appenderFactory.ProduceAppender(appenderType, layoutType, reportLevelType);
                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            ILogger logger = new Models.Loggers.Logger(appenders);

            try
            {
                IEngine engine = new Engine(logger);
                engine.Run();
            }
            catch (Exception ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

    }
}
