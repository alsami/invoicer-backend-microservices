using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Autofac;
using Invoicer.Common.Handlers;

namespace Invoicer.Common
{
    public class ContainerConfigurator
    {
        private static ContainerConfigurator instance = null;
        public IContainer Container { get; private set; }
        public ContainerConfigurator(Assembly assembly)
        {
            Configure(assembly);
        }

        private void Configure(Assembly assembly)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new CommandBusModule()
            {
                ExecutingAssembly = assembly
            });
            builder.RegisterModule(new QueryBusModule()
            {
                ExecutingAssembly = assembly
            });
            builder.RegisterModule(new RepositoryModule()
            {
                ExecutingAssembly = assembly
            });
            Container = builder.Build();

        }

        public static ContainerConfigurator GetInstance(Assembly assembly) {
            if (instance == null) {
                instance = new ContainerConfigurator(assembly);
            }
            return instance;
        }

            
    }
}
