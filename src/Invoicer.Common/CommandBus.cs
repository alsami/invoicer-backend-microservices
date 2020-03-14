using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Invoicer.Common.Handlers;

namespace Invoicer.Common
{
    public interface ICommandBus
    {
        void Send<T>(T Command) where T : ICommand;
    }
    public class CommandBus : ICommandBus
    {
        private Assembly ExecutingAssembly { get; set; }
        public CommandBus(Assembly assembly)
        {
            ExecutingAssembly = assembly;
        }
        public void Send<TCommand>(TCommand command) where TCommand : ICommand
        {
            using (var scope = ContainerConfigurator.GetInstance(ExecutingAssembly ?? throw new Exception("Unable to resolve Executing Assembly")).Container.BeginLifetimeScope())
            { 
                var handlers = scope.Resolve<IEnumerable<ICommandHandler<TCommand>>>().ToList();
                if (handlers.Count == 1)
                {
                    handlers[0].Handle(command);
                }
                else if (handlers.Count == 0)
                {
                    throw new Exception($"Command does not have any handler {command.GetType().Name}");
                }
                else
                {
                    throw new Exception($"Too many registred handlers - {handlers.Count} for command {command.GetType().Name}");
                }
            }
        }
    }
}
