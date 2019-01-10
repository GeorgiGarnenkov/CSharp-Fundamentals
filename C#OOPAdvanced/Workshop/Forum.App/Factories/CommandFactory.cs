using System;
using System.Linq;
using System.Reflection;

namespace Forum.App.Factories
{
    using Contracts;

    public class CommandFactory : ICommandFactory
    {
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes()
                .FirstOrDefault(t => t.Name == commandName + "Command");

            if (commandType == null)
            {
                throw new InvalidOperationException($"{commandName} Command not found!");
            }

            if (!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new InvalidOperationException($"{commandType} is not an ICommand!");
            } 

            ParameterInfo[] ctorParams = commandType
                .GetConstructors()
                .First()
                .GetParameters();

            object[] args = new object[ctorParams.Length];

            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider
                    .GetService(ctorParams[i].ParameterType);
            }

            ICommand command = (ICommand)Activator
                .CreateInstance(commandType, args);

            return command;
        }
    }
}
