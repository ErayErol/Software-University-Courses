namespace CommandPattern.Core
{
    using Contracts;

    using System;
    using System.Linq;
    using System.Reflection;

    // Holds all the reflections we should do in order to execute a command

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_POSTFIX = "Command";

        public CommandInterpreter()
        {
        }

        public string Read(string args)
        {
            string[] commandTokens = args
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string commandName = commandTokens[0] + COMMAND_POSTFIX;
            string[] commandArgs = commandTokens
                .Skip(1)
                .ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            // Create instance of concrete command in order to invoke Execute()

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string result = commandInstance.Execute(commandArgs);

            return result;
        }
    }
}
