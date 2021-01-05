namespace Logger
{
    using Core;
    using Factories;
    using Models;
    using Models.Contracts;

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();

            ParseAppendersInput(appendersCount, appenders);

            ILogger logger = new Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppendersInput(int appendersCount, ICollection<IAppender> appenders)
        {
            var appenderFactory = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appendersArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string appenderType = appendersArgs[0];
                string layoutType = appendersArgs[1];
                string reportLevelType = "INFO";

                if (appendersArgs.Length == 3)
                {
                    reportLevelType = appendersArgs[2];
                }

                try
                {
                    IAppender appender = appenderFactory.ProduceAppender(appenderType, layoutType, reportLevelType);
                    appenders.Add(appender);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
